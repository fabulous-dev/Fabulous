namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.Attributes
open Xamarin.Forms
open System

module XamarinFormsAttributeComparers =
    let widgetComparer (struct (prevOpt: Widget voption, currOpt: Widget voption)) =
        match prevOpt, currOpt with
        | ValueNone, ValueNone -> AttributeComparison.Identical
        | ValueSome prev, ValueSome curr when prev = curr -> AttributeComparison.Identical
        | _, ValueSome curr -> AttributeComparison.Different (ValueSome (box curr))
        | _, ValueNone -> AttributeComparison.Different ValueNone

module XamarinFormsAttributes =
    type IXamarinFormsAttributeDefinition =
        abstract member UpdateTarget: obj voption * obj voption * obj -> unit

    type XamarinFormsAttributeDefinition<'inputType, 'modelType> =
        {
            Key: AttributeKey
            Name: string
            DefaultWith: unit -> 'modelType
            Convert: 'inputType -> 'modelType
            Compare: struct ('modelType voption * 'modelType voption) -> AttributeComparison
            UpdateTarget: struct ('modelType voption * 'modelType voption * obj) -> unit
        }

        member x.WithValue(value) =
            { Key = x.Key
#if DEBUG
              DebugName = x.Name
#endif
              Value = x.Convert(value) }

        interface IXamarinFormsAttributeDefinition with
            member x.UpdateTarget(oldValueOpt, newValueOpt, target) =
                let oldValueOpt = match oldValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<'modelType> v)
                let newValueOpt = match newValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<'modelType> v)
                x.UpdateTarget (struct (oldValueOpt, newValueOpt, target))

        interface IAttributeDefinition<'inputType, 'modelType> with
            member x.Key = x.Key
            member x.DefaultWith () = x.DefaultWith ()
            member x.CompareBoxed(a, b) = x.Compare(struct (unbox a, unbox b))

    let defineWithConverter<'inputType, 'modelType> name defaultWith (convert: 'inputType -> 'modelType) (compare: struct ('modelType voption * 'modelType voption) -> AttributeComparison) (updateTarget: struct ('modelType voption * 'modelType voption * obj) -> unit) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = defaultWith
              Convert = convert
              Compare = compare
              UpdateTarget = updateTarget }
        AttributeDefinitionStore.set key definition
        definition

    let defineCollection<'elementType> name (updateTarget: struct ('elementType array voption * 'elementType array voption * obj) -> unit) =
        defineWithConverter<'elementType seq, 'elementType array> name (fun () -> Array.empty) Seq.toArray AttributeComparers.collectionComparer updateTarget

    let defineWidgetCollection name updateTarget =
        defineCollection<Widget> name updateTarget

    let inline define<'T when 'T: equality> name defaultValue updateTarget =
        defineWithConverter<'T, 'T> name defaultValue id AttributeComparers.equalityComparer updateTarget

    let defineBindableWithComparer<'inputType, 'modelType> (bindableProperty: Xamarin.Forms.BindableProperty) (convert: 'inputType -> 'modelType) (comparer: struct ('modelType voption * 'modelType voption) -> AttributeComparison) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = bindableProperty.PropertyName
              DefaultWith = fun () -> Unchecked.defaultof<'modelType>
              Convert = convert
              Compare = comparer
              UpdateTarget = fun struct(_, newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome v -> (target :?> BindableObject).SetValue(bindableProperty, v) }
        AttributeDefinitionStore.set key definition
        definition

    let inline defineBindableWidget (bindableProperty: Xamarin.Forms.BindableProperty) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = bindableProperty.PropertyName
              DefaultWith = fun () -> Unchecked.defaultof<Widget>
              Convert = id
              Compare = XamarinFormsAttributeComparers.widgetComparer
              UpdateTarget = fun struct(_, newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome widget ->
                    let widgetDefinition = WidgetDefinitionStore.get widget.Key
                    let view = widgetDefinition.CreateView (widget, Unchecked.defaultof<_>)
                    (target :?> BindableObject).SetValue(bindableProperty, view) }
        AttributeDefinitionStore.set key definition
        definition

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T> bindableProperty id AttributeComparers.equalityComparer

    let defineEventNoArg name (getEvent: obj -> IEvent<EventHandler, EventArgs>) =
        let key = AttributeDefinitionStore.getNextKey()
        let definition =
            { Key = key
              Name = name
              DefaultWith = fun () -> null
              Convert = id
              Compare = AttributeComparers.noCompare
              UpdateTarget = fun struct (oldValueOpt, newValueOpt: obj voption, target) -> () }
        AttributeDefinitionStore.set key definition
        definition