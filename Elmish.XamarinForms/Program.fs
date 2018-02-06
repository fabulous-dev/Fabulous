[<RequireQualifiedAccess>]
module Elmish.XamarinForms.Program

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms

(*
let withMessageBoxErrorHandler program =
    program 
    |> Program.withErrorHandler (fun (_, ex) -> System.Windows.MessageBox.Show(ex.Message) |> ignore)

*)

/// Starts the Elmish dispatch loop for the page with the given Elmish program
let runPage (page: Page) (program: Program<unit, 'model, 'msg, ViewBindings<'model, 'msg>>) = 

    let mutable lastModel = None

    let setState model dispatch = 
        match lastModel with
        | None -> 
            // Compute the view mappings once, on startup. 
            let mapping = program.view model dispatch

            // Construct the binding context for the view model
            let vm = ViewModel<'model, 'msg> (model, dispatch, mapping)

            console.log "view: seting data context"
            page.BindingContext <- vm
            lastModel <- Some vm
            console.log "view: set data context"

        | Some vm ->
            vm.UpdateModel model
            ()
                  
    // Start Elmish dispatch loop  
    { program with setState = setState } 
    |> Program.run
