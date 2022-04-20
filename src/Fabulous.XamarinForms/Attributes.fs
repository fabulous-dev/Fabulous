namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System

[<Struct>]
type AppThemeValues<'T> = { Light: 'T; Dark: 'T voption }

module AppTheme =
    let inline create<'T> (light: 'T) (dark: 'T option) =
        { Light = light
          Dark =
            match dark with
            | None -> ValueNone
            | Some v -> ValueSome v }

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data
      Event: 'eventArgs -> obj }

module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> obj) = { Value = value; Event = event }

module Attributes =
    /// Define an attribute storing a Widget for a bindable property
    let inline defineBindableWidget (bindableProperty: BindableProperty) =
        Attributes.defineWidget
            bindableProperty.PropertyName
            (fun target ->
                let childTarget =
                    (target :?> BindableObject)
                        .GetValue(bindableProperty)

                ViewNode.get childTarget)
            (fun target value ->
                let bindableObject =
                    target :?> BindableObject

                if value = null then
                    bindableObject.ClearValue(bindableProperty)
                else
                    bindableObject.SetValue(bindableProperty, value))

    let inline defineBindableWithComparer<'inputType, 'modelType, 'valueType>
        (bindableProperty: BindableProperty)
        ([<InlineIfLambda>] convert: 'inputType -> 'modelType)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalarWithConverter<'inputType, 'modelType, 'valueType>
            bindableProperty.PropertyName
            convert
            convertValue
            compare
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome v -> target.SetValue(bindableProperty, v))

    let inline defineBindable<'T when 'T: equality> (bindableProperty: BindableProperty) =
        Attributes.define<'T> bindableProperty.PropertyName (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    let inline defineAppThemeBindable<'T when 'T: equality> (bindableProperty: BindableProperty) =
        Attributes.define<AppThemeValues<'T>> bindableProperty.PropertyName (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome { Light = light; Dark = ValueNone } -> target.SetValue(bindableProperty, light)
            | ValueSome { Light = light; Dark = ValueSome dark } -> target.SetOnAppTheme(bindableProperty, light, dark))

    /// Update both a property and its related event.
    /// This definition makes sure that the event is only raised when the property is changed by the user,
    /// and not when the property is set by the code
    let defineBindableWithEvent<'data, 'args>
        name
        (bindableProperty: BindableProperty)
        (getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<ValueEventData<'data, 'args>, _, _> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun oldValueOpt newValueOpt node ->
                      let target = node.Target :?> BindableObject
                      let event = getEvent target

                      match newValueOpt with
                      | ValueNone ->
                          // The attribute is no longer applied, so we clean up the event
                          match node.TryGetHandler(key) with
                          | ValueNone -> ()
                          | ValueSome handler -> event.RemoveHandler(handler)

                          // Only clear the property if a value was set before
                          match oldValueOpt with
                          | ValueNone -> ()
                          | ValueSome _ -> target.ClearValue(bindableProperty)

                      | ValueSome curr ->
                          // Clean up the old event handler if any
                          match node.TryGetHandler(key) with
                          | ValueNone -> ()
                          | ValueSome handler -> event.RemoveHandler(handler)

                          // Set the new value
                          target.SetValue(bindableProperty, curr.Value)

                          // Set the new event handler
                          let handler =
                              EventHandler<'args>
                                  (fun _ args ->
                                      let r = curr.Event args
                                      Dispatcher.dispatch node r)

                          node.SetHandler(key, ValueSome handler)
                          event.AddHandler(handler) }

        AttributeDefinitionStore.set key definition
        definition
