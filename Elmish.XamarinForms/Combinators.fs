namespace Elmish.XamarinForms

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms
            
type NoModel = 
    | NoModel

type Update<'model, 'msg> = 'msg -> 'model -> 'model * Cmd<'msg>
type Update<'model, 'msg, 'extmsg> = 'msg -> 'model -> 'model * Cmd<'msg> * 'extmsg
type Update<'model, '_msg, 'msg, 'extmsg> = '_msg -> 'model -> 'model * Cmd<'msg> * 'extmsg
type View<'model, 'msg> = 'model -> Dispatch<'msg> -> ViewBindings<'model, 'msg>

[<RequireQualifiedAccess>]
module Init =
    let combine2 init1 init2 () = (init1(), init2())
    let combine3 init1 init2 init3 () = (init1(), init2(), init3())
    let combine4 init1 init2 init3 init4 () = (init1(), init2(), init3(), init4())
    let combine5 init1 init2 init3 init4 init5 () = (init1(), init2(), init3(), init4(), init5())

[<RequireQualifiedAccess>]
module Update =

    let combine2 (update1: Update<_,_,_,_>) (update2: Update<_,_,_,_>) : Update<_,_,_> = fun msg (model1, model2) ->
        match msg with
        | Choice1Of2 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2), Cmd.map Choice1Of2 cmds, extmsg 
        | Choice2Of2 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel), Cmd.map Choice2Of2 cmds, extmsg 

    let combine3 (update1: Update<_,_,_,_>) (update2: Update<_,_,_,_>) (update3: Update<_,_,_,_>) : Update<_,_,_> = fun msg (model1, model2, model3) ->
        match msg with
        | Choice1Of3 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3), Cmd.map Choice1Of3 cmds, extmsg  
        | Choice2Of3 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3), Cmd.map Choice2Of3 cmds, extmsg  
        | Choice3Of3 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel), Cmd.map Choice3Of3 cmds, extmsg  

    let combine4 (update1: Update<_,_,_,_>) (update2: Update<_,_,_,_>) (update3: Update<_,_,_,_>) (update4: Update<_,_,_,_>) : Update<_,_,_> = fun msg (model1, model2, model3, model4) ->
        match msg with
        | Choice1Of4 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4), Cmd.map Choice1Of4 cmds, extmsg  
        | Choice2Of4 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4), Cmd.map Choice2Of4 cmds, extmsg  
        | Choice3Of4 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4), Cmd.map Choice3Of4 cmds, extmsg  
        | Choice4Of4 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel), Cmd.map Choice4Of4 cmds, extmsg  

    let combine5 (update1: Update<_,_,_,_>) (update2: Update<_,_,_,_>) (update3: Update<_,_,_,_>) (update4: Update<_,_,_,_>) (update5: Update<_,_,_,_>) : Update<_,_,_> = fun msg (model1, model2, model3, model4, model5) ->
        match msg with
        | Choice1Of5 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4, model5), Cmd.map Choice1Of5 cmds, extmsg 
        | Choice2Of5 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4, model5), Cmd.map Choice2Of5 cmds, extmsg 
        | Choice3Of5 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4, model5), Cmd.map Choice3Of5 cmds, extmsg 
        | Choice4Of5 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel, model5), Cmd.map Choice4Of5 cmds, extmsg 
        | Choice5Of5 msg5 -> let newModel, cmds, extmsg = update5 msg5 model5 in (model1, model2, model3, model4, newModel), Cmd.map Choice5Of5 cmds, extmsg 

    let reconcile f (update: Update<_,_,_>) : Update<_,_> = fun msg model ->
        let newModel, cmds, extmsg = update msg model
        let newModel2 = f extmsg newModel
        newModel2, cmds

[<RequireQualifiedAccess>]
module View =

    let none<'model,'msg> : View<'model,'msg> = (fun _ _ -> [])

    let combine2 (nm1, view1: View<_,_>) (nm2, view2: View<_,_>) : View<_,_> =
        (fun (model1, model2) (dispatch: Dispatch<_>) ->
            [ nm1 |> Binding.subView (fun (a,_) -> a) Choice1Of2 (view1 model1 (Choice1Of2 >> dispatch))
              nm2 |> Binding.subView (fun (_,a) -> a) Choice2Of2 (view2 model2 (Choice2Of2 >> dispatch)) ])

    let combine3 (nm1, view1: View<_,_>) (nm2, view2: View<_,_>) (nm3, view3: View<_,_>) : View<_,_> = 
        (fun (model1, model2, model3) (dispatch: Dispatch<_>) ->
            [ nm1 |> Binding.subView (fun (a,_,_) -> a) Choice1Of3 (view1 model1 (Choice1Of3 >> dispatch))
              nm2 |> Binding.subView (fun (_,a,_) -> a) Choice2Of3 (view2 model2 (Choice2Of3 >> dispatch))
              nm3 |> Binding.subView (fun (_,_,a) -> a) Choice3Of3 (view3 model3 (Choice3Of3 >> dispatch)) ])

    let combine4 (nm1, view1: View<_,_>) (nm2, view2: View<_,_>) (nm3, view3: View<_,_>) (nm4, view4: View<_,_>) : View<_,_> =
        (fun (model1, model2, model3, model4) (dispatch: Dispatch<_>)  -> 
            [ nm1 |> Binding.subView (fun (a,_,_,_) -> a) Choice1Of4 (view1 model1 (Choice1Of4 >> dispatch))
              nm2 |> Binding.subView (fun (_,a,_,_) -> a) Choice2Of4 (view2 model2 (Choice2Of4 >> dispatch))
              nm3 |> Binding.subView (fun (_,_,a,_) -> a) Choice3Of4 (view3 model3 (Choice3Of4 >> dispatch))
              nm4 |> Binding.subView (fun (_,_,_,a) -> a) Choice4Of4 (view4 model4 (Choice4Of4 >> dispatch)) ])

    let combine5 (nm1, view1: View<_,_>) (nm2, view2: View<_,_>) (nm3, view3: View<_,_>) (nm4, view4: View<_,_>) (nm5, view5: View<_,_>) : View<_,_> =
        (fun (model1, model2, model3, model4, model5) (dispatch: Dispatch<_>)  -> 
            [ nm1 |> Binding.subView (fun (a,_,_,_,_) -> a) Choice1Of5 (view1 model1 (Choice1Of5 >> dispatch))
              nm2 |> Binding.subView (fun (_,a,_,_,_) -> a) Choice2Of5 (view2 model2 (Choice2Of5 >> dispatch))
              nm3 |> Binding.subView (fun (_,_,a,_,_) -> a) Choice3Of5 (view3 model3 (Choice3Of5 >> dispatch))
              nm4 |> Binding.subView (fun (_,_,_,a,_) -> a) Choice4Of5 (view4 model4 (Choice4Of5 >> dispatch))
              nm5 |> Binding.subView (fun (_,_,_,_,a) -> a) Choice5Of5 (view5 model5 (Choice5Of5 >> dispatch)) ])

module Pages =
    let compose2
            nm1 init1 update1 view1 (page1: Page)
            nm2 init2 update2 view2 (page2: Page)
            extMessageReconciler =
        let init arg = Init.combine2     init1   init2   arg, Cmd.none
        let update = Update.combine2 update1 update2  
        let view  = View.combine2    (nm1,view1)   (nm2,view2) 
        let update = Update.reconcile extMessageReconciler update
        let pages = [nm1, page1; nm2, page2 ]
        let program = Program.mkProgram init update view
        program, pages

    let compose3
            nm1 init1 update1 view1 (page1: Page)
            nm2 init2 update2 view2 (page2: Page)
            nm3 init3 update3 view3 (page3: Page)
            extMessageReconciler =
        let init arg = Init.combine3     init1   init2   init3   arg, Cmd.none
        let update = Update.combine3 update1 update2 update3 
        let view  = View.combine3    (nm1,view1)   (nm2,view2)   (nm3, view3)   
        let update = Update.reconcile extMessageReconciler update
        let pages = [nm1, page1; nm2, page2; nm3, page3]
        let program = Program.mkProgram init update view
        program, pages

    let compose4 
            nm1 init1 update1 view1 (page1: Page)
            nm2 init2 update2 view2 (page2: Page)
            nm3 init3 update3 view3 (page3: Page)
            nm4 init4 update4 view4 (page4: Page)
            extMessageReconciler =
        let init arg = Init.combine4     init1   init2   init3   init4   arg, Cmd.none
        let update = Update.combine4 update1 update2 update3 update4 
        let view  = View.combine4    (nm1,view1)   (nm2,view2)   (nm3, view3)   (nm4, view4)  
        let update = Update.reconcile extMessageReconciler update
        let pages = [nm1, page1; nm2, page2; nm3, page3; nm4, page4 ]
        let program = Program.mkProgram init update view
        program, pages

    let compose5 
            nm1 init1 update1 view1 (page1: Page)
            nm2 init2 update2 view2 (page2: Page)
            nm3 init3 update3 view3 (page3: Page)
            nm4 init4 update4 view4 (page4: Page)
            nm5 init5 update5 view5 (page5: Page) 
            extMessageReconciler =
        let init arg = Init.combine5     init1   init2   init3   init4   init5 arg, Cmd.none
        let update = Update.combine5 update1 update2 update3 update4 update5
        let view  = View.combine5    (nm1,view1)   (nm2,view2)   (nm3, view3)   (nm4, view4)   (nm5, view5)
        let update = Update.reconcile extMessageReconciler update
        let pages = [nm1, page1; nm2, page2; nm3, page3; nm4, page4; nm5, page5]
        let program = Program.mkProgram init update view
        program, pages


[<RequireQualifiedAccess>]
module Program =

    /// Start the program loop.
    /// arg: argument to pass to the init() function.
    /// program: program created with 'mkSimple' or 'mkProgram'.
    let runOnGuiThreadWith (arg: 'arg) (program: Program<'arg, 'model, 'msg, 'view>) =
        let (model,cmd) = program.init arg
        let mutable state = model
        let rec processMsg msg = 
            try
                let (updatedModel,newCommands) = program.update msg state
                program.setState updatedModel dispatch
                newCommands |> List.iter (fun sub -> sub dispatch)
                state <- updatedModel
            with ex ->
                program.onError ("Unable to process a message:", ex)

        and dispatch msg = Device.BeginInvokeOnMainThread(fun () -> processMsg msg)
        program.setState model dispatch
        program.subscribe model
        @ cmd |> List.iter (fun sub -> sub dispatch)

    /// Start the dispatch loop with `unit` for the init() function.
    let runOnGuiThread (program: Program<unit, 'model, 'msg, 'view>) = runOnGuiThreadWith () program

    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let _runPages (pages: (string * Page) list) debug (program: Program<_, _, _, _>)  = 

        let mutable lastModel = None

        let setState model dispatch = 
            match lastModel with
            | None -> 
                // Compute the view mappings once, on startup. 
                let mapping = program.view model dispatch

                // Construct the binding context for the view model
                let vm = ViewModel (model, dispatch, mapping, debug)

                for pageName, page in pages do 
                    if page <> null then 
                        console.log (sprintf "view: seting data context for %s" pageName)
                        page.BindingContext <- vm.[pageName]

                lastModel <- Some vm
                console.log "view: set data context"

            | Some vm ->
                vm.UpdateModel model
                      
        // Start Elmish dispatch loop  
        { program with setState = setState } 
        |> runOnGuiThread

            
    let _runPage (page: Page) debug program = _runPages [("Page", page)] debug program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let runPages pages program = _runPages pages false program
            
    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let runPagesDebug pages program = _runPages pages true program
            
    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let runPage page program = _runPage page false program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let runPageDebug page program = _runPage page true program



type Navigable<'msg> =
     | Push of Page
     | UserMsg of 'msg

[<RequireQualifiedAccess>]
module Navigation =

    /// Push new location into history and navigate there
    let pushPage (nav: INavigation) page : Cmd<_> =
       [ fun _ -> nav.PushAsync page |> ignore ]










(*
 let box (program: Program<'arg, 'model, 'msg, 'view>) : Program<'arg, obj, obj, obj>  = 
      {
         init = (fun arg ->  
                   let model, cmds = program.init arg 
                   (box model, Cmd.map box cmds))
         update = (fun msg model -> 
                   let model, cmds = program.update (unbox msg) (unbox model)
                   (box model, Cmd.map box cmds))
         subscribe = (fun model -> 
                   Cmd.map box (program.subscribe (unbox model)))
         view = (fun model dispatch -> 
                   box (program.view (unbox model) (box >> dispatch)))
         setState = (fun model dispatch -> 
                   program.setState (unbox model) (box >> dispatch))
         onError = program.onError
     }
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
 *)
