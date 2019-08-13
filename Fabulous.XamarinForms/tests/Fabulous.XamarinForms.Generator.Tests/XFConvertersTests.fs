// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Generator.Tests

open Fabulous.XamarinForms.Generator
open FsUnit
open NUnit.Framework

module XFConvertersTests =
    [<TestCase("Xamarin.Forms.UriImageSource", false)>]
    [<TestCase("Xamarin.Forms.ItemsView", false)>]
    [<TestCase("Xamarin.Forms.ListItemsLayout", false)>]
    [<TestCase("Xamarin.Forms.Button", true)>]
    let ``isTypeResolvable should return false for excluded types``(typeName, expectedValue) =
        XFConverters.isTypeResolvable typeName |> should equal expectedValue

    [<TestCase("Xamarin.Forms.Grid.IGridList`1<Xamarin.Forms.View>", "ViewElement list")>]
    [<TestCase("System.Collections.Generic.IList`1<Xamarin.Forms.Effect>", "ViewElement list")>]
    [<TestCase("System.Collections.Generic.IList`1<T>", "ViewElement list")>]
    [<TestCase("System.Collections.Generic.IList`1<Xamarin.Forms.Behavior>", "ViewElement list")>]
    [<TestCase("System.Windows.Input.ICommand", "unit -> unit")>]
    let ``convertTypeName should convert known Xamarin.Forms types``(typeName, expectedValue) =
        XFConverters.convertTypeName typeName |> should equal expectedValue