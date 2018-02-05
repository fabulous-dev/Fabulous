[<RequireQualifiedAccess>]
module Elmish.XamarinForms.Program

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.ViewModel

(*
let withMessageBoxErrorHandler program =
    program 
    |> Program.withErrorHandler (fun (_, ex) -> System.Windows.MessageBox.Show(ex.Message) |> ignore)

*)

let _runPage debug (page : Xamarin.Forms.Page) (program : Program<unit, 'model, 'msg, ViewBindings<'model, 'msg>>) = 

    let mutable lastModel = None

    let setState model dispatch = 
        match lastModel with
        | None -> 
            // Compute the view mappings once, on startup
            let mapping = program.view model dispatch

            // Construct the binding context for the view model
            let vm = ViewModel<'model, 'msg> (model, dispatch, mapping, debug)
            page.BindingContext <- vm
            lastModel <- Some vm
        | Some vm ->
            vm.UpdateModel model
                  
    // Start Elmish dispatch loop  
    { program with setState = setState } 
    |> Program.run

/// Starts both Elmish and Xamarin.Forms dispatch loops.
let runPage page program = _runPage false page program

/// Starts both Elmish and Xamarin.Forms dispatch loops.
/// Enables debug console logging.
let runDebugPage page program = _runPage true page program