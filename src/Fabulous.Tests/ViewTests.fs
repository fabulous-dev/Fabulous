namespace Fabulous.Tests

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open NUnit.Framework

type ITestControl = interface end

module TestControl =
    let WidgetKey: WidgetKey = 1

type Msg = ChildMsg of unit

[<TestFixture>]
type ``View helper functions tests``() =

    /// Test: https://github.com/fabulous-dev/Fabulous/pull/1037
    [<Test>]
    member _.``Mapping a WidgetBuilder with Unit Msg to another Msg is supported``() =
        let widgetBuilder = WidgetBuilder<unit, ITestControl>(TestControl.WidgetKey)

        let mapMsg (oldMsg: unit) = ChildMsg oldMsg

        let mappedWidgetBuilder = View.map mapMsg widgetBuilder

        Assert.AreEqual(widgetBuilder.Key, mappedWidgetBuilder.Key)

        let struct (scalars, _, _, _) = mappedWidgetBuilder.Attributes
        let scalars = StackList.toArray &scalars

        Assert.AreEqual(1, scalars.Length)
        Assert.AreEqual(MapMsg.MapMsg.Key, scalars[0].Key)
