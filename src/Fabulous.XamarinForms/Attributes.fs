namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System

module Attributes =
    /// Define an attribute storing a Widget for a bindable property
    let defineBindableWidget (bindableProperty: BindableProperty) =
        Attributes.defineWidget
            ViewNode.getViewNode
            bindableProperty.PropertyName
            (fun parent ->
                let p = (parent :?> BindableObject)
                let x = p.GetValue(bindableProperty)
                x
            )
            (fun target value ->
                let bindableObject = target :?> BindableObject
                if value = null then
                    bindableObject.ClearValue(bindableProperty)
                else
                    bindableObject.SetValue(bindableProperty, value)
            )

    let defineBindableWithComparer<'inputType, 'modelType> (bindableProperty: Xamarin.Forms.BindableProperty) (convert: 'inputType -> 'modelType) (compare: ('modelType * 'modelType) -> ScalarAttributeComparison) =
        Attributes.defineScalarWithConverter<'inputType, 'modelType>
            bindableProperty.PropertyName
            (fun () -> Unchecked.defaultof<'modelType>)
            convert
            compare
            (fun (newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome v -> (target :?> BindableObject).SetValue(bindableProperty, v)
            )

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T> bindableProperty id ScalarAttributeComparers.equalityCompare

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition : ScalarAttributeDefinition<_,_> =
            { Key = key
              Name = name
              DefaultWith = fun () -> null
              Convert = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateTarget = fun (newValueOpt, target) ->
                let event = getEvent target
                let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData

                match viewNodeData.TryGetHandler(key) with
                | None -> ()
                | Some handler -> event.RemoveHandler handler

                match newValueOpt with
                | ValueNone ->
                    viewNodeData.SetHandler(key, ValueNone)

                | ValueSome msg ->
                    let handler = EventHandler(fun _ _ ->
                        viewNodeData.ViewNode.Context.Dispatch msg
                    )
                    event.AddHandler handler
                    viewNodeData.SetHandler(key, ValueSome handler) }
        AttributeDefinitionStore.set key definition
        definition

    let defineEvent<'args> name (getEvent: obj -> IEvent<EventHandler<'args>, 'args>) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition : ScalarAttributeDefinition<_,_> =
            { Key = key
              Name = name
              DefaultWith = fun () -> fun _ -> null
              Convert = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateTarget = fun (newValueOpt: ('args -> obj) voption, target) ->

                let event = getEvent target
                let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData

                match viewNodeData.TryGetHandler(key) with
                | None ->
                    printfn $"No old handler for {name}"
                | Some handler ->
                    printfn $"Removed old handler for {name}"
                    event.RemoveHandler handler

                match newValueOpt with
                | ValueNone ->
                    viewNodeData.SetHandler(key, ValueNone)

                | ValueSome fn ->
                    let handler = EventHandler<'args>(fun sender args ->
                        printfn $"Handler for {name} triggered"
                        let viewNodeData = (sender :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData
                        let r = fn args
                        viewNodeData.ViewNode.Context.Dispatch r
                    )
                    viewNodeData.SetHandler(key, ValueSome handler)
                    event.AddHandler handler
                    printfn $"Added new handler for {name}"
            }
        AttributeDefinitionStore.set key definition
        definition
