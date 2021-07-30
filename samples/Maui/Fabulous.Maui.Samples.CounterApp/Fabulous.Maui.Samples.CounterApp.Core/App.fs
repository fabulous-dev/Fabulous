namespace Fabulous.Maui.Samples.CounterApp.Core

open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Graphics

module App =
    type Model = { Count: int }
    
    type Msg = Increment
    
    let init initialCount = { Count = initialCount }
    
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        
    let view model =
        View.Application([
            View.Window("Main",
                View.StackLayout([
                    View.Label().TextColor(Colors.Aqua).Font("")
                    View.Button().Font("")
                ])
            )
        ])
        
    let runner = StatefulWidget.mkSimple init update view