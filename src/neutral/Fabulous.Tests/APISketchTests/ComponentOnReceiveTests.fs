namespace Fabulous.Tests.APISketchTests

open NUnit.Framework
open Fabulous
open Fabulous.Tests.APISketchTests.Platform
open TestUI_Widgets
open System

open type View
open type Context

type IntArgs(delta: int) =
    inherit EventArgs()
    member _.Delta = delta

type NetEventSource() =
    let evt = new Event<EventHandler<IntArgs>, IntArgs>()

    [<CLIEvent>]
    member _.Tick = evt.Publish

    member _.Fire(delta: int) = evt.Trigger(null, IntArgs delta)

module ComponentOnReceiveTests =

    [<Test>]
    let ``Component onReceive with .NET EventHandler<'T> increments label`` () =
        // Arrange (IEvent<EventHandler<'T>,'T> overload)

        let src = NetEventSource()

        let view =
            Component("onReceive-netevent") {
                let! count = State(0)

                Stack().automationId("root") {
                    Label(count.Current.ToString()).automationId("label").onReceive(src.Tick, fun args -> count.Set(count.Current + args.Delta))
                }
            }

        let tree = Run.startView view
        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual("0", label.Text)
        src.Fire 1
        Assert.AreEqual("1", label.Text)
        src.Fire 2
        Assert.AreEqual("3", label.Text)

    [<Test>]
    let ``Component onReceive with F# Event<'T> increments label`` () =
        // Arrange (Event<'T> overload)
        let tick = new Event<int>()

        let view =
            Component("onReceive-fsharp-event") {
                let! count = State(0)

                Stack().automationId("root") {
                    Label(count.Current.ToString()).automationId("label").onReceive(tick, fun delta -> count.Set(count.Current + delta))
                }
            }

        let tree = Run.startView view
        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual("0", label.Text)
        tick.Trigger 1
        Assert.AreEqual("1", label.Text)
        tick.Trigger 2
        Assert.AreEqual("3", label.Text)
