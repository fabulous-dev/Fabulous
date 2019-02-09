// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace CounterApp.Tests

open NUnit.Framework
open FsUnit
open CounterApp
open CounterApp.App
open Fabulous.Core
open Fabulous.DynamicViews

module ``Init tests`` =
    [<Test>]
    let ``Init should return a valid initial state``() =
        let initialState = { Count = 0; Step = 1; TimerOn = false }, Cmd.none
        App.init () |> should equal initialState

module ``Update tests`` =
    [<Test>]
    let ``Given the message Increment, Update should increment Count using Step``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedState = { Count = 9; Step = 4; TimerOn = false }, Cmd.none
        App.update Increment initialModel |> should equal expectedState

    [<Test>]
    let ``Given the message Decrement, Update should decrement Count using Step``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedState = { Count = 1; Step = 4; TimerOn = false }, Cmd.none
        App.update Decrement initialModel |> should equal expectedState

    [<Test>]
    let ``Given the message Reset, Update should reset the state``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedState = { Count = 0; Step = 1; TimerOn = false }, Cmd.none
        App.update Reset initialModel |> should equal expectedState

    [<Test>]
    let ``Given the message SetStep, Update should change the Step with the given value``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedState = { Count = 5; Step = 12; TimerOn = false }, Cmd.none
        App.update (SetStep 12) initialModel |> should equal expectedState

    [<Test>]
    let ``Given the message TimerToggled false, Update should disable the timer``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = true }
        let expectedState = { Count = 5; Step = 4; TimerOn = false }, Cmd.none
        App.update (TimerToggled false) initialModel |> should equal expectedState

    [<Test>]
    let ``Given the message TimerToggled true, Update should enable the timer and return a new TimerCmd``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedModel = { Count = 5; Step = 4; TimerOn = true }
        let expectedCommandMsg = [ TimedTick ]

        let actualModel, actualCmd = App.update (TimerToggled true) initialModel
        //let actualCommandMsg = execute actualCmd

        actualModel |> should equal expectedModel
        //actualCommandMsg |> should equal expectedCommandMsg

    [<Test>]
    let ``Given the message TimedTick and the timer is still on, Update should increment Count using Step and return a new TimerCmd``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = true }
        let expectedModel = { Count = 9; Step = 4; TimerOn = true }
        let expectedCommandMsg = [ TimedTick ]

        let actualModel, actualCmd = App.update TimedTick initialModel
        //let actualCommandMsg = execute actualCmd

        actualModel |> should equal expectedModel
        //actualCommandMsg |> should equal expectedCommandMsg

    [<Test>]
    let ``Given the message TimedTick and the timer is off, Update should do nothing``() =
        let initialModel = { Count = 5; Step = 4; TimerOn = false }
        let expectedState = { Count = 5; Step = 4; TimerOn = false }, Cmd.none
        App.update TimedTick initialModel |> should equal expectedState

module ``View tests`` =
    [<Test>]
    let ``View should generate a valid interface``() =
        let model = { Count = 5; Step = 4; TimerOn = true }
        let actualView = App.view model ignore

        let stackLayout = StackLayoutViewer(ContentPageViewer(actualView).Content)
        let countLabel = LabelViewer(stackLayout.Children.[0])
        let timerSwitch = SwitchViewer(StackLayoutViewer(stackLayout.Children.[3]).Children.[1])
        let stepSlider = SliderViewer(stackLayout.Children.[4])
        let stepSizeLabel = LabelViewer(stackLayout.Children.[5])

        countLabel.Text |> should equal "5"
        timerSwitch.IsToggled |> should equal true
        stepSlider.Value |> should equal 4.0
        stepSizeLabel.Text |> should equal "Step size: 4"

    [<Test>]
    let ``Clicking the button Increment should send the message Increment``() =
        let mockedDispatch msg =
            msg |> should equal Increment

        let model = { Count = 5; Step = 4; TimerOn = true }
        let actualView = App.view model mockedDispatch

        let contentPage = ContentPageViewer(actualView)
        let stackLayout = StackLayoutViewer(contentPage.Content)
        let incrementButton = ButtonViewer(stackLayout.Children.[1])

        incrementButton.Command ()

    [<Test>]
    let ``Clicking the button Decrement should send the message Decrement``() =
        let mockedDispatch msg =
            msg |> should equal Decrement

        let model = { Count = 5; Step = 4; TimerOn = true }
        let actualView = App.view model mockedDispatch

        let contentPage = ContentPageViewer(actualView)
        let stackLayout = StackLayoutViewer(contentPage.Content)
        let decrementButton = ButtonViewer(stackLayout.Children.[2])

        decrementButton.Command ()