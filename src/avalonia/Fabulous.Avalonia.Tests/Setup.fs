namespace Fabulous.Avalonia.Tests

open Fabulous
open Fabulous.Avalonia
open NUnit.Framework

[<SetUpFixture>]
type Setup() =
    static member RegisteredWidgets = ResizeArray<WidgetKey>()

    [<OneTimeSetUp>]
    member this.Setup() =
        // Force the widgets to register before the tests start
        Setup.RegisteredWidgets.Add(TextBlock.WidgetKey)
