namespace Gallery

open System.Diagnostics
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module RadioButtonPage =
    type Model =
        { IsChecked1: bool
          IsChecked2: bool
          IsChecked3: bool
          IsChecked4: bool
          IsChecked5: bool
          IsChecked6: bool
          IsChecked7: bool
          IsChecked8: bool
          IsChecked9: bool
          IsChecked10: bool
          IsChecked11: bool

          ThreeStateChecked1: bool option
          ThreeStateChecked2: bool option
          ThreeStateChecked3: bool option
          ThreeStateChecked4: bool option
          ThreeStateChecked5: bool option
          ThreeStateChecked6: bool option
          ThreeStateChecked7: bool option
          ThreeStateChecked8: bool option
          ThreeStateChecked9: bool option
          ThreeStateChecked10: bool option
          ThreeStateChecked11: bool option
          ThreeStateChecked12: bool option
          ThreeStateChecked13: bool option
          ThreeStateChecked14: bool option }

    type Msg =
        | OnCheckedChanged1 of bool
        | OnCheckedChanged2 of bool
        | OnCheckedChanged3 of bool
        | OnCheckedChanged4 of bool
        | OnCheckedChanged5 of bool
        | OnCheckedChanged6 of bool
        | OnCheckedChanged7 of bool
        | OnCheckedChanged8 of bool
        | OnCheckedChanged9 of bool
        | OnCheckedChanged10 of bool
        | OnCheckedChanged11 of bool

        | OnThreeStateCheckedChanged1 of bool option
        | OnThreeStateCheckedChanged2 of bool option
        | OnThreeStateCheckedChanged3 of bool option
        | OnThreeStateCheckedChanged4 of bool option
        | OnThreeStateCheckedChanged5 of bool option
        | OnThreeStateCheckedChanged6 of bool option
        | OnThreeStateCheckedChanged7 of bool option
        | OnThreeStateCheckedChanged8 of bool option
        | OnThreeStateCheckedChanged9 of bool option
        | OnThreeStateCheckedChanged10 of bool option
        | OnThreeStateCheckedChanged11 of bool option
        | OnThreeStateCheckedChanged12 of bool option
        | OnThreeStateCheckedChanged13 of bool option
        | OnThreeStateCheckedChanged14 of bool option

    let init () =
        { IsChecked1 = false
          IsChecked2 = false
          IsChecked3 = false
          IsChecked4 = false
          IsChecked5 = false
          IsChecked6 = false
          IsChecked7 = false
          IsChecked8 = false
          IsChecked9 = false
          IsChecked10 = false
          IsChecked11 = false


          ThreeStateChecked1 = None
          ThreeStateChecked2 = None
          ThreeStateChecked3 = Some false
          ThreeStateChecked4 = Some false
          ThreeStateChecked5 = Some false
          ThreeStateChecked6 = Some false
          ThreeStateChecked7 = Some false
          ThreeStateChecked8 = Some false
          ThreeStateChecked9 = Some false
          ThreeStateChecked10 = Some false
          ThreeStateChecked11 = Some false
          ThreeStateChecked12 = Some false
          ThreeStateChecked13 = Some false
          ThreeStateChecked14 = Some false },
        Cmd.none

    let update msg model =
        match msg with
        | OnCheckedChanged1 v -> { model with IsChecked1 = v }, Cmd.none
        | OnCheckedChanged2 v -> { model with IsChecked2 = v }, Cmd.none
        | OnCheckedChanged3 v -> { model with IsChecked3 = v }, Cmd.none
        | OnCheckedChanged4 v -> { model with IsChecked4 = v }, Cmd.none
        | OnCheckedChanged5 v -> { model with IsChecked5 = v }, Cmd.none
        | OnCheckedChanged6 v -> { model with IsChecked6 = v }, Cmd.none
        | OnCheckedChanged7 v -> { model with IsChecked7 = v }, Cmd.none
        | OnCheckedChanged8 v -> { model with IsChecked8 = v }, Cmd.none
        | OnCheckedChanged9 v -> { model with IsChecked9 = v }, Cmd.none
        | OnCheckedChanged10 v -> { model with IsChecked10 = v }, Cmd.none
        | OnCheckedChanged11 v -> { model with IsChecked11 = v }, Cmd.none

        | OnThreeStateCheckedChanged1 v -> { model with ThreeStateChecked1 = v }, Cmd.none
        | OnThreeStateCheckedChanged2 v -> { model with ThreeStateChecked2 = v }, Cmd.none
        | OnThreeStateCheckedChanged3 v -> { model with ThreeStateChecked3 = v }, Cmd.none
        | OnThreeStateCheckedChanged4 v -> { model with ThreeStateChecked4 = v }, Cmd.none
        | OnThreeStateCheckedChanged5 v -> { model with ThreeStateChecked5 = v }, Cmd.none
        | OnThreeStateCheckedChanged6 v -> { model with ThreeStateChecked6 = v }, Cmd.none
        | OnThreeStateCheckedChanged7 v -> { model with ThreeStateChecked7 = v }, Cmd.none
        | OnThreeStateCheckedChanged8 v -> { model with ThreeStateChecked8 = v }, Cmd.none
        | OnThreeStateCheckedChanged9 v -> { model with ThreeStateChecked9 = v }, Cmd.none
        | OnThreeStateCheckedChanged10 v -> { model with ThreeStateChecked10 = v }, Cmd.none
        | OnThreeStateCheckedChanged11 v -> { model with ThreeStateChecked11 = v }, Cmd.none
        | OnThreeStateCheckedChanged12 v -> { model with ThreeStateChecked12 = v }, Cmd.none
        | OnThreeStateCheckedChanged13 v -> { model with ThreeStateChecked13 = v }, Cmd.none
        | OnThreeStateCheckedChanged14 v -> { model with ThreeStateChecked14 = v }, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("RadioButtonPage") {
            let! model = Context.Mvu program

            VStack() {
                TextBlock("Allows the selection of a single option of many")

                HStack(16.) {
                    VStack(16.) {
                        RadioButton("Option 1", model.IsChecked1, OnCheckedChanged1)

                        RadioButton("Option 1", model.IsChecked2, OnCheckedChanged2)
                        RadioButton("Option 2", model.IsChecked3, OnCheckedChanged3)

                        RadioButton("Disabled", model.IsChecked4, OnCheckedChanged4)
                            .isEnabled(false)

                        ThreeStateRadioButton("Option 3", model.ThreeStateChecked1, OnThreeStateCheckedChanged1)
                        ThreeStateRadioButton("Option 4", model.ThreeStateChecked2, OnThreeStateCheckedChanged2)
                    }

                    VStack(16.) {
                        ThreeStateRadioButton("Three States: Option 1", model.ThreeStateChecked3, OnThreeStateCheckedChanged3)
                        ThreeStateRadioButton("Three States: Option 1", model.ThreeStateChecked4, OnThreeStateCheckedChanged4)
                        ThreeStateRadioButton("Three States: Option 2", model.ThreeStateChecked5, OnThreeStateCheckedChanged5)
                        ThreeStateRadioButton("Three States: Option 2", model.ThreeStateChecked6, OnThreeStateCheckedChanged6)
                        ThreeStateRadioButton("Three States: Option 3", model.ThreeStateChecked7, OnThreeStateCheckedChanged7)
                        ThreeStateRadioButton("Three States: Option 3", model.ThreeStateChecked8, OnThreeStateCheckedChanged8)

                        ThreeStateRadioButton("Disabled", model.ThreeStateChecked9, OnThreeStateCheckedChanged9)
                            .isEnabled(false)

                        ThreeStateRadioButton("Disabled", model.ThreeStateChecked10, OnThreeStateCheckedChanged10)
                            .isEnabled(false)
                    }

                    VStack(16.) {
                        RadioButton("Group A: Option 1", model.IsChecked5, OnCheckedChanged5)
                            .groupName("A")

                        RadioButton("Group A: Option 1", model.IsChecked6, OnCheckedChanged6)
                            .groupName("A")

                        RadioButton("Group A: Disabled", model.IsChecked7, OnCheckedChanged7)
                            .groupName("A")
                            .isEnabled(false)

                        RadioButton("Group B: Option 1", model.IsChecked8, OnCheckedChanged8)
                            .groupName("B")

                        ThreeStateRadioButton("Group B: Option 3", model.ThreeStateChecked11, OnThreeStateCheckedChanged11)
                            .groupName("B")

                        ThreeStateRadioButton("Group B: Option 3", model.ThreeStateChecked12, OnThreeStateCheckedChanged12)
                            .groupName("B")
                    }

                    VStack(16.) {
                        RadioButton("Group A: Option 2", model.IsChecked9, OnCheckedChanged9)
                            .groupName("A")

                        RadioButton("Group A: Option 2", model.IsChecked10, OnCheckedChanged10)
                            .groupName("A")

                        RadioButton("Group B: Option 2", model.IsChecked11, OnCheckedChanged11)
                            .groupName("B")

                        ThreeStateRadioButton("Group B: Option 4", model.ThreeStateChecked13, OnThreeStateCheckedChanged13)
                            .groupName("B")

                        ThreeStateRadioButton("Group B: Option 4", model.ThreeStateChecked14, OnThreeStateCheckedChanged14)
                            .groupName("B")
                    }
                }
            }
        }
