namespace Fabulous.Maui.Samples.CounterApp.Core

open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open System.Runtime.CompilerServices

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
        
    let view model =
        VerticalStackLayout([
            Button("-", Decrement)
            Label(model.CountX.ToString())
            Button("+", Increment)
        ])
    
    type Fabulous.Maui.View with
        static member inline CounterWidget() = StatefulWidget.mkSimpleView init update view

module Extensions =
    open Fabulous.Maui.Attributes

    [<Extension>]
    type MyCustomExtensions =
        [<Extension>]
        static member inline margin(this: #IViewWidget<_>, ?left: float, ?top: float, ?right: float, ?bottom: float) =
            let value =
                Thickness(
                    (match left with None -> 0. | Some v -> v),
                    (match top with None -> 0. | Some v -> v),
                    (match right with None -> 0. | Some v -> v),
                    (match bottom with None -> 0. | Some v -> v)
                )

            this.AddAttribute(View.Margin.WithValue(value))

        [<Extension>]
        static member inline centerHorizontally(this: #IViewWidget<_>) =
            this.AddAttribute(View.HorizontalLayoutAlignment.WithValue(Primitives.LayoutAlignment.Center))

module App =
    open CounterWidget
    open StatelessLabel
    open Extensions
    open type Fabulous.Maui.View

    type Model = { Count: int }
    
    type Msg = Increment
    
    let init () = { Count = 0 }
    
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        
    let view model =
        Application([
            Window("Main",
                VerticalStackLayout([
                    Label($"Hello World from Fabulous: {model.Count}")
                        .font(Font.SystemFontOfSize(20.))
                        .horizontalLayoutAlignment(Primitives.LayoutAlignment.Fill)
                        .verticalLayoutAlignment(Primitives.LayoutAlignment.Fill)
                        .horizontalTextAlignment(TextAlignment.Center)
                        .background(SolidPaint(Colors.Red))
                        
                    //Label($"Count is {model.Count}")
                        
                    Button("Click me", Increment)
                    //    .font(Font.SystemFontOfSize(15.))
                        
                    //CounterWidget()
                    
                    //StatelessLabel()
                    
                ]).spacing(10.)
                  .background(SolidPaint(Colors.Aqua))
            )
        ])
        
    let widget = StatefulWidget.mkSimpleApp init update view