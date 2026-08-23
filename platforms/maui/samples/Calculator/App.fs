namespace Calculator

open System
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

open type Fabulous.Maui.View

module App =
    type Operator =
        | Add
        | Subtract
        | Multiply
        | Divide

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
        | OperandOperatorOperand(_, Divide, 0.0) -> Error
        | OperandOperatorOperand(op1, operator, op2) ->
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
            | Initial
            | Error
            | Result _ -> Operand(double digit)
            | Operand op -> Operand(double(string op + string digit))
            | OperandOperator(operand, operator) -> OperandOperatorOperand(operand, operator, double digit)
            | OperandOperatorOperand(op1, operator, op2) -> OperandOperatorOperand(op1, operator, double(string op2 + string digit))
        | Operator operator ->
            match model with
            | Initial
            | Error -> model
            | Result operand // previously calculated result is now the first operand
            | Operand operand
            | OperandOperator(operand, _) -> OperandOperator(operand, operator)
            | OperandOperatorOperand _ -> calculate model msg
        | Equals -> calculate model msg

    let display model =
        match model with
        | Initial -> "0"
        | Operand op
        | OperandOperator(op, _)
        | OperandOperatorOperand(_, _, op) -> string op
        | Result res -> string res
        | Error -> "Error"

    let view (model: Model) =
        let mkButton text (onClicked: 'msg) row column =
            Button(text, onClicked)
                .gridRow(row)
                .gridColumn(column)
                .font(size = 36.0)
                .cornerRadius(0)

        let mkNumberButton number row column =
            (mkButton (string number) (Digit number) row column)
                .background(Colors.White)
                .textColor(Colors.Black)

        let orange = Color.FromRgb(0xff, 0xa5, 0)
        let gray = Color.FromRgb(0x80, 0x80, 0x80)

        let mkOperatorButton text operator row column =
            (mkButton text (Operator operator) row column)
                .background(orange)
                .textColor(Colors.Black)

        Application(
            ContentPage(
                (Grid(rowdefs = [ Star; Star; Star; Star; Star; Star ], coldefs = [ Star; Star; Star; Star ]) {
                    View
                        .Label(display model)
                        .font(size = 48.0, attributes = FontAttributes.Bold)
                        .background(Colors.Black)
                        .textColor(Colors.White)
                        .alignEndTextHorizontal()
                        .centerTextVertical()
                        .gridColumnSpan(4)

                    mkNumberButton 7 1 0
                    mkNumberButton 8 1 1
                    mkNumberButton 9 1 2
                    mkNumberButton 4 2 0
                    mkNumberButton 5 2 1
                    mkNumberButton 6 2 2
                    mkNumberButton 1 3 0
                    mkNumberButton 2 3 1
                    mkNumberButton 3 3 2

                    (mkNumberButton 0 4 0).gridColumnSpan(3)

                    mkOperatorButton "÷" Divide 1 3
                    mkOperatorButton "×" Multiply 2 3
                    mkOperatorButton "-" Subtract 3 3
                    mkOperatorButton "+" Add 4 3
                    (mkButton "A" Clear 5 0).background(gray).textColor(Colors.White)
                    (mkButton "." Equals 5 1).background(orange).textColor(Colors.Black)

                    (mkButton "=" Equals 5 2)
                        .background(orange)
                        .gridColumnSpan(2)
                        .textColor(Colors.White)
                })
                    .rowSpacing(1.0)
                    .columnSpacing(1.0)
                    .background(gray)
            )
        )

    let program =
        Program.stateful (fun () -> Initial) update
        |> Program.withTrace Console.WriteLine
        |> Program.withView view
