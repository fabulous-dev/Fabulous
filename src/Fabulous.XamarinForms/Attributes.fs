namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

[<Struct>]
type AppThemeValues<'T> =
    { Light: 'T
      Dark: 'T voption }
    static member inline create<'T>(light : 'T, ?dark: 'T) =
        { Light = light
          Dark =
              match dark with
              | None -> ValueNone
              | Some v -> ValueSome v }

module Attributes =
    /// Define an attribute storing a Widget for a bindable property
    let defineBindableWidget (bindableProperty: BindableProperty) =
        Attributes.defineWidget
            bindableProperty.PropertyName
            (fun target ->
                let childTarget =
                    (target :?> BindableObject)
                        .GetValue(bindableProperty)

                ViewNode.get childTarget)
            (fun target value ->
                let bindableObject = target :?> BindableObject

                if value = null then
                    bindableObject.ClearValue(bindableProperty)
                else
                    bindableObject.SetValue(bindableProperty, value))

    let defineBindableWithComparer<'inputType, 'modelType, 'valueType>
        (bindableProperty: BindableProperty)
        (convert: 'inputType -> 'modelType)
        (convertValue: 'modelType -> 'valueType)
        (compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalarWithConverter<'inputType, 'modelType, 'valueType>
            bindableProperty.PropertyName
            convert
            convertValue
            compare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome v -> target.SetValue(bindableProperty, v))

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T, 'T> bindableProperty id id ScalarAttributeComparers.equalityCompare

    let inline defineAppThemeBindable<'T when 'T: equality> (bindableProperty: BindableProperty) =
        Attributes.defineScalarWithConverter<AppThemeValues<'T>, AppThemeValues<'T>, AppThemeValues<'T>>
            bindableProperty.PropertyName
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome { Light = light; Dark = ValueNone } -> target.SetValue(bindableProperty, light)
                | ValueSome { Light = light; Dark = ValueSome dark } ->
                    target.SetOnAppTheme(bindableProperty, light, dark))

    let inline getAppTheme<'T> light dark =
        match dark with
        | Some dark -> AppThemeValues<'T>.create (light, dark)
        | None -> AppThemeValues<'T>.create(light)
