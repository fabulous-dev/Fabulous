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

/// Starts Elmish dispatch loop for the page with the given Elmish program
let runPage (page : Xamarin.Forms.Page) (program : Program<unit, 'model, 'msg, ViewBindings<'model, 'msg>>) = 

    let mutable lastModel = None

    let setState model dispatch = 
        match lastModel with
        | None -> 
            // Compute the view mappings once, on startup
            let mapping = program.view model dispatch

            // Construct the binding context for the view model
            let vm = ViewModel<'model, 'msg> (model, dispatch, mapping)
            System.Console.WriteLine ("seting data context")
            page.BindingContext <- vm
            lastModel <- Some vm
            System.Console.WriteLine ("set data context, CounterValue = {0}. vm = {1}", vm.["CounterValue"], vm)
            

        | Some vm ->
            System.Console.WriteLine ("updating model")
            vm.UpdateModel model
            System.Console.WriteLine ("updated model")
            ()
                  
    // Start Elmish dispatch loop  
    { program with setState = setState } 
    |> Program.run
