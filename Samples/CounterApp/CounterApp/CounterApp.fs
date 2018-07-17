// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace CounterApp

open System.Diagnostics
open Elmish.XamarinForms 
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

module App = 
#if CALCULATOR
    type Operator = Add | Subtract | Multiply | Divide 

    /// Represents a calculator button press
    type Msg =
        | Operator of Operator
        | Digit of int
        | Equals
        | Clear

    type Operand = double

    // We can't represent an invalid state with this model.
    // This greatly reduces the amount of validation required.
    type Model =
        | Initial
        | Operand of Operand // 1
        | OperandOperator of Operand * Operator // 1 +
        | OperandOperatorOperand of Operand * Operator * Operand // 1 + 1
        | Result of double // 2
        | Error

    let calculateOperation op1 op2 operator =
        match operator with
        | Add -> op1 + op2
        | Subtract -> op1 - op2
        | Multiply -> op1 * op2
        | Divide -> op1 / op2

    let calculate model msg =
        match model with
        | OperandOperatorOperand (_, Divide, 0.0) -> Error
        | OperandOperatorOperand (op1, operator, op2) ->
            let res = calculateOperation op1 op2 operator
            match msg with
            | Equals -> Result(res)
            | Operator operator ->
                // pass the result in as the start of a new calculation (1 + 1 + -> 2 +)
                OperandOperator(res, operator)
            | _ -> model
        | _ -> model

    let update msg model =
        match msg with
        | Clear -> Initial
        | Digit digit ->
            match model with
            | Initial | Error | Result _ -> Operand (double digit)
            | Operand op -> Operand (double (string op + string digit))
            | OperandOperator (operand, operator) -> OperandOperatorOperand (operand, operator, double digit)
            | OperandOperatorOperand (op1, operator, op2) -> OperandOperatorOperand (op1, operator, double (string op2 + string digit))
        | Operator operator ->
            match model with
            | Initial | Error -> model
            | Result operand // previously calculated result is now the first operand
            | Operand operand | OperandOperator (operand, _) -> OperandOperator(operand, operator) 
            | OperandOperatorOperand _ -> calculate model msg
        | Equals -> calculate model msg

    let display model =
        match model with
        | Initial -> "0"
        | Operand op | OperandOperator (op, _) | OperandOperatorOperand (_, _, op) -> string op
        | Result res -> string res
        | Error -> "Error"

    let view (model: Model) dispatch =
        let mkButton text command row column =
            View.Button(text = text, command=(fun () -> dispatch command))
                .GridRow(row)
                .GridColumn(column)
                .FontSize(36.0)
                //.ButtonCornerRadius(0)

        let mkNumberButton number row column =
            (mkButton (string number) (Digit number) row column)
                .BackgroundColor(Color.White)
                .TextColor(Color.Black)

        let orange = Color.FromRgb(0xff, 0xa5, 0)
        let gray = Color.FromRgb(0x80, 0x80, 0x80)

        let mkOperatorButton text operator row column =
            (mkButton text (Operator operator) row column)
                .BackgroundColor(orange)
                .TextColor(Color.Black) 

        View.ContentPage(
            View.Grid(rowdefs=[ "*"; "*"; "*"; "*"; "*"; "*" ], coldefs=[ "*"; "*"; "*"; "*" ],
                children=[
                    View.Label(text = display model, fontSize = 48.0, fontAttributes = FontAttributes.Bold, backgroundColor = Color.Black, textColor = Color.White, horizontalTextAlignment = TextAlignment.End, verticalTextAlignment = TextAlignment.Center).GridColumnSpan(4)
                    mkNumberButton 7 1 0; mkNumberButton 8 1 1; mkNumberButton 9 1 2
                    mkNumberButton 4 2 0; mkNumberButton 5 2 1; mkNumberButton 6 2 2
                    mkNumberButton 1 3 0; mkNumberButton 2 3 1; mkNumberButton 3 3 2
                    (mkNumberButton 0 4 0).GridColumnSpan(3)
                    mkOperatorButton "÷÷" Divide 1 3
                    mkOperatorButton "×" Multiply 2 3
                    mkOperatorButton "-" Subtract 3 3
                    mkOperatorButton "+" Add 4 3
                    (mkButton "A" Clear 5 0).BackgroundColor(gray).TextColor(Color.White)
                    (mkButton "." Equals 5 1).BackgroundColor(orange).TextColor(Color.Black)
                    (mkButton "=" Equals 5 2).BackgroundColor(orange).GridColumnSpan(2).TextColor(Color.White)
                ], rowSpacing = 1.0, columnSpacing = 1.0, backgroundColor = gray
            )
        )

    let program = 
        Program.mkSimple (fun() -> Initial) update view
        |> Program.withConsoleTrace
#else
    type Model = 
      { Count : int 
        Step : int
        TimerOn: bool }

    type Msg = 
        | Increment 
        | Decrement 
        | Reset
        | SetStep of int
        | TimerToggled of bool
        | TimedTick

    let initModel () = { Count = 0; Step = 1; TimerOn=false }

    let init () = initModel () , Cmd.none

    let timerCmd () = 
        async { do! Async.Sleep 200
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, Cmd.none
        | Decrement -> { model with Count = model.Count - model.Step }, Cmd.none
        | Reset -> init ()
        | SetStep n -> { model with Step = n }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd() else Cmd.none)
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, timerCmd() else model, Cmd.none 

    let view (model: Model) dispatch =  
        View.ContentPage(
          content=View.StackLayout(padding=30.0,verticalOptions = LayoutOptions.Center,
            children=[ 
              // If you want the button to disappear when in the initial condition then use this:
              yield View.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center, fontSize = "Large")
              yield View.Button(text="Increment", command= (fun () -> dispatch Increment))
              yield View.Button(text="Decrement", command= (fun () -> dispatch Decrement)) 
              yield View.StackLayout(padding=20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center,
                              children = [ View.Label(text="Timer")
                                           View.Switch(isToggled=model.TimerOn, toggled=(fun on -> dispatch (TimerToggled on.Value))) ])
              yield View.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=(fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
              yield View.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
              //if model <> initModel () then 
              yield View.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch Reset), canExecute = (model <> initModel () ))
            ]))   
             
    let program = 
        Program.mkProgram init update view 
        |> Program.withConsoleTrace
#endif

#if TESTEVAL
    let testInit = fst (init ())
    let testView = view testInit (fun _ -> ())
#endif

type CounterApp () as app = 
    inherit Application ()

    let runner = App.program |> Program.runWithDynamicView app

#if DEBUG && !TESTEVAL
    do runner.EnableLiveUpdate ()
#endif


#if SAVE_MODEL_WITH_JSON && !TESTEVAL
    let modelId = "model"
    override __.OnSleep() = 

        let json = Newtonsoft.Json.JsonConvert.SerializeObject(runner.CurrentModel)
        Debug.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() = 
        Debug.WriteLine "OnResume: checking for model in app.Properties"
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 

                Debug.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)
                let model = Newtonsoft.Json.JsonConvert.DeserializeObject<App.Model>(json)

                Debug.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel (model, Cmd.none)

            | _ -> ()
        with ex -> 
            App.program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = 
        Debug.WriteLine "OnStart: using same logic as OnResume()"
        this.OnResume()

#endif
