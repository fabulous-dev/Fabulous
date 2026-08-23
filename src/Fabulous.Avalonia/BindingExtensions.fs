namespace Fabulous.Avalonia

open System
open System.Linq.Expressions
open System.Reflection
open System.Runtime.CompilerServices
open Avalonia.Data
open Avalonia.Data.Converters

type BindingExtensions =

    /// <summary>Allows multi-binding a bound property on a control of type T to the properties identified by the propertyNames in the specified format.</summary>
    /// <param name="control">The control to bind the property to.</param>
    /// <param name="property">The bound property to bind to.</param>
    /// <param name="format">The format string to use when binding the properties.</param>
    /// <param name="propertyNames">The property names to bind to the bound property.</param>
    [<Extension>]
    static member multiBind<'T>(control: obj, property: Expression<Func<'T, IBinding>>, format: string, [<ParamArray>] propertyNames: string array) =
        let binding = MultiBinding()
        binding.Converter <- FuncMultiValueConverter<obj, string>(fun parts -> String.Format(format, parts |> Seq.toArray))

        for property in propertyNames do
            binding.Bindings.Add(Binding(property))

        // Get member information from the expression
        let memberExpression = property.Body :?> MemberExpression
        let propertyInfo = memberExpression.Member :?> PropertyInfo

        // Set property value on control
        propertyInfo.SetValue(control, binding, null)
