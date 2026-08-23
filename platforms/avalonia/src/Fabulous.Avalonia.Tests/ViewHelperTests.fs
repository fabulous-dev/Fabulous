namespace Fabulous.Avalonia.Tests

open Fabulous
open FsCheck
open NUnit.Framework
open FsUnit
open FsCheck.NUnit
open Fabulous.Avalonia

[<TestFixture>]
type ViewHelpers() =
    [<Test>]
    member _.``Existing Avalonia control can be reused if previous and current widgets are of the same type``() =
        for widgetKey in Setup.RegisteredWidgets do

            let prev: Widget =
                { Key = widgetKey
                  ScalarAttributes = [||]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes = [||]
                  EnvironmentAttributes = [||] }

            let curr: Widget =
                { Key = widgetKey
                  ScalarAttributes = [||]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes = [||]
                  EnvironmentAttributes = [||] }

            let actual = ViewHelpers.canReuseView prev curr

            actual |> should equal true

    [<Property>]
    member _.``Existing TextBlock control can not be reused if previous widget uses Text and current widget uses Inlines``() =
        let arb = Arb.fromGen Generators.nonNullString

        Prop.forAll arb (fun text ->
            let prev =
                { Key = TextBlock.WidgetKey
                  ScalarAttributes =
                    [| { Key = TextBlock.Text.Key
                         Value = text
                         NumericValue = 0uL } |]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes = [||]
                  EnvironmentAttributes = [||] }

            let curr =
                { Key = TextBlock.WidgetKey
                  ScalarAttributes = [||]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes =
                    [| { Key = TextBlock.Inlines.Key
                         Value = ArraySlice.emptyWithNull() } |]
                  EnvironmentAttributes = [||] }

            let actual = ViewHelpers.canReuseView prev curr

            actual |> should equal false)

    [<Property>]
    member _.``Existing TextBlock control can not be reused if previous widget uses Inlines and current widget uses Text``() =
        let arb = Arb.fromGen Generators.nonNullString

        Prop.forAll arb (fun text ->
            let prev =
                { Key = TextBlock.WidgetKey
                  ScalarAttributes = [||]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes =
                    [| { Key = TextBlock.Inlines.Key
                         Value = ArraySlice.emptyWithNull() } |]
                  EnvironmentAttributes = [||] }

            let curr =
                { Key = TextBlock.WidgetKey
                  ScalarAttributes =
                    [| { Key = TextBlock.Text.Key
                         Value = text
                         NumericValue = 0uL } |]
                  WidgetAttributes = [||]
                  WidgetCollectionAttributes = [||]
                  EnvironmentAttributes = [||] }

            let actual = ViewHelpers.canReuseView prev curr

            actual |> should equal false)
