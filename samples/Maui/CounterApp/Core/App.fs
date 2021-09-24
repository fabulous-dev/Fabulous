namespace Fabulous.Maui.Samples.CounterApp.Core

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics

module StatelessLabel =
    open type Fabulous.Maui.View
    
    let view _ =
        Label("Stateless Hello World")
        
    type Fabulous.Maui.View with
        static member inline StatelessLabel() = StatelessWidget.mkSimpleView view

module CounterWidget =
    open type Fabulous.Maui.View
    
    type Model = { CountX: int }
    
    type Msg =
        | Increment
        | Decrement
        
    let init () =
        { CountX = 0 }
        
    let update msg model =
        match msg with
        | Increment -> { model with CountX = model.CountX + 1 }
        | Decrement -> { model with CountX = model.CountX - 1 }
        
    let view model _ =
        StackLayout([
            Button("-", Decrement)
            Label(model.CountX.ToString())
            Button("+", Increment)
        ])
    
    type Fabulous.Maui.View with
        static member inline CounterWidget() = StatefulWidget.mkSimpleView init update view


module App =
    open CounterWidget
    open StatelessLabel
    open type Fabulous.Maui.View

    type Model = { Count: int }
    
    type Msg = Increment
    
    let init () = { Count = 0 }
    
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        
    let view model _ =
        Application([
            Window("Main",
                StackLayout([
                    Label("Hello World from Fabulous")
                        
                    //Label($"Count is {model.Count}")
                        
                    //Button("Click me", Increment)
                    //    .font(Font.SystemFontOfSize(15.))
                        
                    //CounterWidget()
                    
                    //StatelessLabel()
                    
                ]).spacing(10)
            )
        ])
        
    let widget = StatefulWidget.mkSimpleApp init update view