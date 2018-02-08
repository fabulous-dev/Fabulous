[<RequireQualifiedAccess>]
module Elmish.XamarinForms.Program

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms

(*
type Model<'m1,'m2> = 
    { Model1: 'm1
      Model2: 'm2 }

type Msg<'msg1, 'msg2> = 
    | Msg1 of 'msg1
    | Msg2 of 'msg2

type View<'view1, 'view2> = 
    { View1: 'view1
      View2: 'view2 }

let combine2 program1 program2 = 
     {
        init = (fun arg ->  
                  let model1, cmds1 = program1.init arg 
                  let model2, cmds2 = program2.init arg
                  { Model1 = model1; Model2 = model2 }, Cmd.map Msg1 cmds1 @ Cmd.map Msg2 cmds2)
        update = (fun msg model -> 
                    match msg with 
                    | Msg1 msg1 -> let model1, cmds1 = program1.update msg1 model.Model1 in { model with Model1 = model1}, Cmd.map Msg1 cmds1
                    | Msg2 msg1 -> let model1, cmds1 = program2.update msg1 model.Model2 in { model with Model2 = model1}, Cmd.map Msg2 cmds1)
        subscribe = (fun model -> Cmd.map Msg1 (program1.subscribe model.Model1) @ Cmd.map Msg2 (program2.subscribe model.Model2))
        view = (fun model dispatch -> { View1 = program1.view model.Model1 (Msg1 >> dispatch); View2 = program2.view model.Model2 (Msg2 >> dispatch) })
        setState = (fun model dispatch -> program1.setState model.Model1 (Msg1 >> dispatch); program2.setState model.Model2 (Msg2 >> dispatch))
        onError = (fun err -> program1.onError err; program2.onError err)
    }
*)
let combine2 program1 program2 = 
     {
        init = (fun arg ->  
                  let model1, cmds1 = program1.init arg 
                  let model2, cmds2 = program2.init arg
                  (model1, model2), Cmd.map Choice1Of2 cmds1 @ Cmd.map Choice2Of2 cmds2)
        update = (fun msg (model1, model2) -> 
                    match msg with 
                    | Choice1Of2 msg1 -> let model1, cmds1 = program1.update msg1 model1 in (model1, model2), Cmd.map Choice1Of2 cmds1
                    | Choice2Of2 msg2 -> let model2, cmds2 = program2.update msg2 model2 in (model1, model2), Cmd.map Choice2Of2 cmds2)
        subscribe = (fun (model1, model2) -> 
            Cmd.map Choice1Of2 (program1.subscribe model1) @ 
            Cmd.map Choice2Of2 (program2.subscribe model2)
           )
        view = (fun (model1, model2) dispatch -> 
            (program1.view model1 (Choice1Of2 >> dispatch), 
             program2.view model2 (Choice2Of2 >> dispatch)))
        setState = (fun (model1, model2) dispatch -> 
            program1.setState model1 (Choice1Of2 >> dispatch)
            program2.setState model2 (Choice2Of2 >> dispatch))
        onError = (fun err -> 
            program1.onError err; program2.onError err)
    }

let combine3 program1 program2 program3 = 
     {
        init = (fun arg ->  
                  let model1, cmds1 = program1.init arg 
                  let model2, cmds2 = program2.init arg
                  let model3, cmds3 = program3.init arg
                  (model1, model2, model3), 
                  Cmd.map Choice1Of3 cmds1 @ 
                  Cmd.map Choice2Of3 cmds2 @ 
                  Cmd.map Choice3Of3 cmds3)
        update = (fun msg (model1, model2, model3) -> 
                    match msg with 
                    | Choice1Of3 msg1 -> let model1, cmds1 = program1.update msg1 model1 in (model1, model2, model3), Cmd.map Choice1Of3 cmds1
                    | Choice2Of3 msg2 -> let model2, cmds2 = program2.update msg2 model2 in (model1, model2, model3), Cmd.map Choice2Of3 cmds2
                    | Choice3Of3 msg3 -> let model3, cmds3 = program3.update msg3 model3 in (model1, model2, model3), Cmd.map Choice3Of3 cmds3
                 )
        subscribe = (fun (model1, model2, model3) -> 
            Cmd.map Choice1Of3 (program1.subscribe model1) @ 
            Cmd.map Choice2Of3 (program2.subscribe model2) @
            Cmd.map Choice3Of3 (program3.subscribe model3)
           )
        view = (fun (model1, model2, model3) dispatch -> 
            (program1.view model1 (Choice1Of3 >> dispatch), 
             program2.view model2 (Choice2Of3 >> dispatch),
             program3.view model3 (Choice3Of3 >> dispatch)))
        setState = (fun (model1, model2, model3) dispatch -> 
            program1.setState model1 (Choice1Of3 >> dispatch)
            program2.setState model2 (Choice2Of3 >> dispatch)
            program3.setState model3 (Choice3Of3 >> dispatch))
        onError = (fun err -> 
            program1.onError err
            program2.onError err
            program3.onError err)
    }

(*
let withMessageBoxErrorHandler program =
    program 
    |> Program.withErrorHandler (fun (_, ex) -> System.Windows.MessageBox.Show(ex.Message) |> ignore)

*)

/// Starts the Elmish dispatch loop for the page with the given Elmish program
let _run vmf setf updatef (program: Program<unit, _, _, _>)  = 

    let mutable lastModel = None

    let setState model dispatch = 
        match lastModel with
        | None -> 
            // Compute the view mappings once, on startup. 
            let mapping = program.view model dispatch

            // Construct the binding context for the view model
            let vm = vmf (model, dispatch, mapping)

            console.log "view: seting data context"
            setf vm
            lastModel <- Some vm
            console.log "view: set data context"

        | Some vm ->
            updatef vm model
            ()
                  
    // Start Elmish dispatch loop  
    { program with setState = setState } 
    |> Program.run

/// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
/// Starts the Elmish dispatch loop for the page with the given Elmish program
let runPage (page: Page) program = 
    _run 
        (fun (model, dispatch, mapping) -> ViewModel (model, dispatch, mapping))
        (fun vm -> page.BindingContext <- vm) 
        (fun vm model -> vm.UpdateModel model)
        program
        
/// Creates the view models for the given pages and starts the Elmish dispatch loop for the matching program
let runPages2 (page1: Page) (page2: Page) program = 
    _run 
        (fun ((model1, model2), dispatch, (mapping1, mapping2)) -> 
            let vm1 = ViewModel (model1, (Choice1Of2 >> dispatch), mapping1)
            let vm2 = ViewModel (model2, (Choice2Of2 >> dispatch), mapping2)
            (vm1, vm2))
        (fun (vm1, vm2) -> 
            page1.BindingContext <- vm1
            page2.BindingContext <- vm2) 
        (fun (vm1,vm2) (model1, model2) -> 
            vm1.UpdateModel model1
            vm2.UpdateModel model2)
        program

/// Creates the view models for the given pages and starts the Elmish dispatch loop for the matching program
let runPages3 (page1: Page) (page2: Page) (page3: Page) program = 
    _run 
        (fun ((model1, model2, model3), dispatch, (mapping1, mapping2, mapping3)) -> 
            let vm1 = ViewModel (model1, (Choice1Of3 >> dispatch), mapping1)
            let vm2 = ViewModel (model2, (Choice2Of3 >> dispatch), mapping2)
            let vm3 = ViewModel (model3, (Choice3Of3 >> dispatch), mapping3)
            (vm1, vm2, vm3))
        (fun (vm1, vm2, vm3) -> 
            page1.BindingContext <- vm1
            page2.BindingContext <- vm2
            page3.BindingContext <- vm3) 
        (fun (vm1,vm2,vm3) (model1, model2, model3) -> 
            vm1.UpdateModel model1
            vm2.UpdateModel model2
            vm3.UpdateModel model3)
        program
