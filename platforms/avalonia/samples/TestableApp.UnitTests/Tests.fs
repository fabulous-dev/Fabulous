namespace TestableApp

open App
open Xunit
open FsUnitTyped

module Tests =
    [<Fact>]
    let ``Initial state should be 0`` () =
        let expectedState = { Count = 0; Step = 1; TimerOn = false }
        let expectedCmdMsg = List.empty
        let actualState, cmdMsg = init()

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``Increment should increment the count`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }
        let expectedState = { Count = 1; Step = 1; TimerOn = false }
        let expectedCmdMsg = List.empty

        let actualState, cmdMsg = update Increment previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``Decrement should decrement the count`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }

        let expectedState =
            { Count = -1
              Step = 1
              TimerOn = false }

        let expectedCmdMsg = List.empty
        let actualState, cmdMsg = update Decrement previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``Reset should reset the count`` () =
        let previousState =
            { Count = 10
              Step = 1
              TimerOn = false }

        let expectedState = { Count = 0; Step = 1; TimerOn = false }
        let expectedCmdMsg = List.empty

        let actualState, cmdMsg = update Reset previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``SetStep should set the step`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }
        let expectedState = { Count = 0; Step = 2; TimerOn = false }
        let expectedCmdMsg = List.empty

        let actualState, cmdMsg = update (SetStep 2.) previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``TimerToggled should start the timer`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }
        let expectedState = { Count = 0; Step = 1; TimerOn = true }
        let expectedCmdMsg = [ TimerToggling true ]

        let actualState, cmdMsg = update (TimerToggled true) previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``TimedTick should increment the count`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = true }
        let expectedState = { Count = 1; Step = 1; TimerOn = true }
        let expectedCmdMsg = [ TimerToggling true ]

        let actualState, cmdMsg = update TimedTick previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``TimedTick when TimerOn is false`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }
        let expectedState = { Count = 0; Step = 1; TimerOn = false }
        let expectedCmdMsg = List.empty

        let actualState, cmdMsg = update TimedTick previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``TimerToggled should stop the timer`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = true }
        let expectedState = { Count = 0; Step = 1; TimerOn = false }
        let expectedCmdMsg = [ TimerToggling false ]

        let actualState, cmdMsg = update (TimerToggled false) previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState

    [<Fact>]
    let ``TimerToggled when TimerOn is false`` () =
        let previousState = { Count = 0; Step = 1; TimerOn = false }
        let expectedState = { Count = 0; Step = 1; TimerOn = false }
        let expectedCmdMsg = [ TimerToggling false ]

        let actualState, cmdMsg = update (TimerToggled false) previousState

        cmdMsg |> shouldEqual expectedCmdMsg
        actualState |> shouldEqual expectedState
