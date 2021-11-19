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
            convert
            compare
            (fun (newValueOpt, target) ->
                match newValueOpt with
                | ValueNone -> (target :?> BindableObject).ClearValue(bindableProperty)
                | ValueSome v -> (target :?> BindableObject).SetValue(bindableProperty, v)
            )

    let inline defineBindable<'T when 'T: equality> bindableProperty =
        defineBindableWithComparer<'T, 'T> bindableProperty id ScalarAttributeComparers.equalityCompare
