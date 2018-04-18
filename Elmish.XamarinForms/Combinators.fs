// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews

/// Represents a model when you don't have a model.  A Clayton's model.
type NoModel = 
    | NoModel

type Update<'model, 'msg> = 'msg -> 'model -> 'model * Cmd<'msg>
type Update<'model, 'msg, 'extmsg> = 'msg -> 'model -> 'model * Cmd<'msg> * 'extmsg
type StaticView<'model, 'msg, 'page> = unit -> 'page * ViewBindings<'model, 'msg>
type DynamicView<'model, 'msg, 'page> = unit -> 'page * ViewBindings<'model, 'msg> * ('model -> 'msg -> View)

[<AutoOpen>]
module Values =
    let NoCmd<'a> : Cmd<'a> = Cmd.none
    let mutable currentPage : Page = null

[<RequireQualifiedAccess>]
module Nav =

    // TODO: modify the Elmish framework we use to remove this global state and pass it into all commands??
    let mutable globalNavMap : Map<System.IComparable, Page> = Map.empty

    /// Push new location into history and navigate there
    let push (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
       [ fun _ -> 
           let fromPage = globalNavMap.[fromPageTag]
           let toPage = globalNavMap.[toPageTag]
           let nav = fromPage.Navigation
           nav.PushAsync toPage |> ignore ]

    /// Push new location into history and navigate there
    let pushModal (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
       [ fun _ -> 
           let fromPage = globalNavMap.[fromPageTag]
           let toPage = globalNavMap.[toPageTag]
           let nav = fromPage.Navigation
           nav.PushModalAsync toPage |> ignore ]

    let popToRoot (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
       [ fun _ -> 
           let fromPage = globalNavMap.[fromPageTag]
           let nav = fromPage.Navigation
           nav.PopToRootAsync() |> ignore ]

    let popModal (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
       [ fun _ -> 
           let fromPage = globalNavMap.[fromPageTag]
           let nav = fromPage.Navigation
           nav.PopModalAsync() |> ignore ]

    let pop (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
       [ fun _ -> 
           let fromPage = globalNavMap.[fromPageTag]
           let nav = fromPage.Navigation
           nav.PopAsync() |> ignore ]

[<RequireQualifiedAccess>]
module Init =
    let combo2 init1 init2 () = 
        let model1 = init1()
        let model2 = init2()
        (model1, model2)

    let combo3 init1 init2 init3 () = 
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        (model1, model2, model3)

    let combo4 init1 init2 init3 init4 () = 
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        let model4 = init4()
        (model1, model2, model3, model4)

    let combo5 init1 init2 init3 init4 init5 () =
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        let model4 = init4()
        let model5 = init5()
        (model1, model2, model3, model4, model5)

[<RequireQualifiedAccess>]
module InitCmd =
    let combo2 init1 init2 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        (model1, model2), Cmd.batch [cmd1; cmd2]

    let combo3 init1 init2 init3 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        (model1, model2, model3), Cmd.batch [cmd1; cmd2; cmd3]

    let combo4 init1 init2 init3 init4 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        let model4, cmd4 = init4()
        (model1, model2, model3, model4), Cmd.batch [cmd1; cmd2; cmd3; cmd4]

    let combo5 init1 init2 init3 init4 init5 () =
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        let model4, cmd4 = init4()
        let model5, cmd5 = init5()
        (model1, model2, model3, model4, model5), Cmd.batch [cmd1; cmd2; cmd3; cmd4; cmd5]


[<RequireQualifiedAccess>]
module Update =

    let combo2 (update1: Update<_, _, _>) (update2: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2) ->
        match msg with
        | Choice1Of2 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2), Cmd.map Choice1Of2 cmds, extmsg 
        | Choice2Of2 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel), Cmd.map Choice2Of2 cmds, extmsg 

    let combo3 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3) ->
        match msg with
        | Choice1Of3 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3), Cmd.map Choice1Of3 cmds, extmsg  
        | Choice2Of3 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3), Cmd.map Choice2Of3 cmds, extmsg  
        | Choice3Of3 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel), Cmd.map Choice3Of3 cmds, extmsg  

    let combo4 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) (update4: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3, model4) ->
        match msg with
        | Choice1Of4 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4), Cmd.map Choice1Of4 cmds, extmsg  
        | Choice2Of4 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4), Cmd.map Choice2Of4 cmds, extmsg  
        | Choice3Of4 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4), Cmd.map Choice3Of4 cmds, extmsg  
        | Choice4Of4 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel), Cmd.map Choice4Of4 cmds, extmsg  

    let combo5 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) (update4: Update<_, _, _>) (update5: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3, model4, model5) ->
        match msg with
        | Choice1Of5 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4, model5), Cmd.map Choice1Of5 cmds, extmsg 
        | Choice2Of5 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4, model5), Cmd.map Choice2Of5 cmds, extmsg 
        | Choice3Of5 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4, model5), Cmd.map Choice3Of5 cmds, extmsg 
        | Choice4Of5 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel, model5), Cmd.map Choice4Of5 cmds, extmsg 
        | Choice5Of5 msg5 -> let newModel, cmds, extmsg = update5 msg5 model5 in (model1, model2, model3, model4, newModel), Cmd.map Choice5Of5 cmds, extmsg 

    /// Reconcile external messages by turning them into changes in the composed model and/or commands
    let reconcile f (update: Update<'model,'msg,'extmsg>) : Update<'model,'msg> = fun msg model ->
        let newModel, cmds, extmsg = update msg model
        let newModel2, cmds2 = f extmsg newModel
        newModel2, Cmd.batch [cmds; cmds2]

[<RequireQualifiedAccess>]
module StaticView =

    let internal setBindingContextsUntyped (bindings: ViewBindings<'model, 'msg>) (viewModel: ViewModel<obj, obj>) = 
        for (bindingName, binding) in bindings do 
            match binding with 
            | BindSubModel (ViewSubModel (initf, _, _, _, _)) -> 
                console.log (sprintf "view: seting data context for %s" bindingName)
                let subModel = viewModel.[bindingName]
                initf subModel
            | _ -> ()

    let internal setBindingContexts (bindings: ViewBindings<'model, 'msg>) (viewModel: ViewModel<'model, 'msg>) = 
        for (bindingName, binding) in bindings do 
            match binding with 
            | BindSubModel (ViewSubModel (initf, _, _, _, _)) -> 
                console.log (sprintf "view: seting data context for %s" bindingName)
                let subModel = viewModel.[bindingName]
                initf subModel
            | _ -> ()

    let internal pageInit (page: Page) contentf bindings (viewModel: ViewModel<'model, 'msg>) model dispatch =
        setBindingContexts bindings viewModel
        page.BindingContext <- box viewModel
        match contentf with 
        | None -> None
        | Some f -> 
            let viewData: XamlElement = f model dispatch
            let contentPage = (page :?> ContentPage)
            contentPage.Content <- viewData.CreateAsView() 
            Some viewData

    let internal pageUpdate (page: Page) contentf model prevViewDataOpt dispatch =
        match contentf, prevViewDataOpt with 
        | Some f, Some prevViewData -> 
            let viewData: XamlElement = f model dispatch
            viewData.ApplyIncremental (prevViewData, (page :?> ContentPage).Content)
            Some viewData
        | _ -> 
            prevViewDataOpt

    let internal pageInitUntyped (page: ContentPage) (bindings: ViewBindings<'model, 'msg>) =
        fun (objViewModel: obj) ->
            match objViewModel with
            | :? ViewModel<obj, obj> as viewModel -> 
                setBindingContextsUntyped bindings viewModel
                page.BindingContext <- objViewModel
            | _ -> failwithf "unexpected type in pageInitUntyped: %A" (objViewModel.GetType())

    let internal genViewName = let mutable c = 0 in fun () -> c <- c + 1; "StaticView"+string c

    let internal apply (view: StaticView<_, _, _>) = 
        let page, bindings = view() 
        let name = genViewName()
        name, page, bindings

    let subPage (view1: StaticView<_, _, _>) =
        let nm1, page1, bindings1 = apply view1
        page1,
        [ nm1 |> Binding.subView (pageInitUntyped page1 bindings1) id id bindings1 ]

    let combo2 (view1: StaticView<_, _, _>) (view2: StaticView<_, _, _>) =
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        (page1, page2),
        [ nm1 |> Binding.subView (pageInitUntyped page1 bindings1) (fun (a,_) -> a) Choice1Of2 bindings1
          nm2 |> Binding.subView (pageInitUntyped page1 bindings2) (fun (_,a) -> a) Choice2Of2 bindings2 ]

    let combo3 (view1: StaticView<_, _, _>) (view2: StaticView<_, _, _>) (view3: StaticView<_, _, _>) = 
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        let nm3, page3, bindings3 = apply view3
        (page1, page2, page3),
        [ nm1 |> Binding.subView (pageInitUntyped page1 bindings1) (fun (a,_,_) -> a) Choice1Of3 bindings1
          nm2 |> Binding.subView (pageInitUntyped page2 bindings2) (fun (_,a,_) -> a) Choice2Of3 bindings2
          nm3 |> Binding.subView (pageInitUntyped page3 bindings3) (fun (_,_,a) -> a) Choice3Of3 bindings3 ]

    let combo4 (view1: StaticView<_, _, _>) (view2: StaticView<_, _, _>) (view3: StaticView<_, _, _>) (view4: StaticView<_, _, _>) =
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        let nm3, page3, bindings3 = apply view3
        let nm4, page4, bindings4 = apply view4
        (page1, page2, page3, page4),
        [ nm1 |> Binding.subView (pageInitUntyped page1 bindings1) (fun (a,_,_,_) -> a) Choice1Of4 bindings1
          nm2 |> Binding.subView (pageInitUntyped page2 bindings2) (fun (_,a,_,_) -> a) Choice2Of4 bindings2
          nm3 |> Binding.subView (pageInitUntyped page3 bindings3) (fun (_,_,a,_) -> a) Choice3Of4 bindings3
          nm4 |> Binding.subView (pageInitUntyped page4 bindings4) (fun (_,_,_,a) -> a) Choice4Of4 bindings4 ]

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
                //System.Diagnostics.Debugger.Log(ex.Message)
                //System.Diagnostics.Debug.Fail(ex.Message)
                System.Diagnostics.Debugger.Break()
                program.onError ("Unable to process a message:", ex)

        and dispatch msg = Device.BeginInvokeOnMainThread(fun () -> processMsg msg)
        program.setState model dispatch
        program.subscribe model
        @ cmd |> List.iter (fun sub -> sub dispatch)

    /// Start the dispatch loop with `unit` for the init() function.
    let runOnGuiThread (program: Program<unit, 'model, 'msg, 'view>) = runOnGuiThreadWith () program

    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let _runStaticView debug (program: Program<_, _, _, _>)  = 

        // Compute the view mappings once, on startup. 
        console.log "view: computing initial view with dummy model/dispatch"
        let page,bindings = program.view Unchecked.defaultof<_> (fun _ -> failwith "do not call disaptch in the view")

        let mutable lastModel = None

        let setState model dispatch = 
            match lastModel with
            | None -> 

                // Construct the binding context for the view model
                let viewModel = ViewModel (model, dispatch, bindings, debug)

                let viewData = StaticView.pageInit page None bindings viewModel model dispatch

                lastModel <- Some (viewModel, viewData)
                console.log "view: set data context"

            | Some (viewModel, prevViewData) ->
                let viewData = StaticView.pageUpdate page None model prevViewData dispatch
                lastModel <- Some (viewModel, viewData)
                viewModel.UpdateModel model
                      
        // Start Elmish dispatch loop  
        { program with setState = setState } 
        |> runOnGuiThread

        page

    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    let _runDynamicView debug  (program: Program<_, _, _, _>)  = 

        // Compute the view mappings once, on startup. 
        console.log "view: computing initial page"
        let page, bindings, contentf = program.view Unchecked.defaultof<_> (fun _ -> failwith "do not call disaptch in the view")

        let mutable lastModel = None

        let setState model dispatch = 
            match lastModel with
            | None -> 

                // Construct the binding context for the view model
                let viewModel = ViewModel (model, dispatch, bindings, debug)

                let viewData = StaticView.pageInit page (Some contentf) bindings viewModel model dispatch

                lastModel <- Some (viewModel, viewData)
                console.log "view: set data context"

            | Some (viewModel, prevViewData) ->
                let viewData = StaticView.pageUpdate page (Some contentf) model prevViewData dispatch
                lastModel <- Some (viewModel, viewData)
                viewModel.UpdateModel model
                      
        // Start Elmish dispatch loop  
        { program with setState = setState } 
        |> runOnGuiThread

        page


    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let runDynamicView program = _runDynamicView false program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let runStaticView program = _runStaticView false program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let run program = runStaticView program
            
    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let runDebugDynamicView program = _runDynamicView true program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let runDebugStaticView program = _runStaticView true program

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let runDebug program = runDebugStaticView program


    let withNavigation (program: Program<_,_,_,_>) = 
        { init = program.init
          update = program.update
          subscribe = program.subscribe
          setState = program.setState
          onError = program.onError
          view = (fun m d -> 
                let page, bindings, navMap = program.view m d
                console.log "view: setting global navigation map"
                // TODO: modify the Elmish framework we use to remove this global state and pass it into all commands??
                Nav.globalNavMap <- (navMap |> List.map (fun (tg, page) -> ((tg :> System.IComparable), page)) |> Map.ofList)
                page, bindings  )}

namespace Elmish.XamarinForms.DynamicViews 

    open Xamarin.Forms

    open Elmish
    open Elmish.XamarinForms
    open Elmish.XamarinForms.DynamicViews

    [<AutoOpen>]
    module GridHelpers = 

        open System.Runtime.CompilerServices
        open System.Collections.Generic
        open System.Windows.Input
       
        type XamlElement with 
            /// Get the GridRow property in the visual element
            member x.GridRow = match x.Attributes.TryFind("GridRow") with Some v -> unbox<int>(v) | None -> 0

            /// Get the GridColumn property in the visual element
            member x.GridColumn = match x.Attributes.TryFind("GridColumn") with Some v -> unbox<int>(v) | None -> 0

            /// Get the RowDefinition_Height property in the visual element
            member x.GridRowDefinition_Height = match x.Attributes.TryFind("GridRowDefinition_Height") with Some v -> unbox<GridLength>(v) | None -> GridLength.Auto

            /// Get the ColumnDefinition_Width property in the visual element
            member x.GridColumnDefinition_Width = match x.Attributes.TryFind("GridColumnDefinition_Width") with Some v -> unbox<GridLength>(v) | None -> GridLength.Auto

            /// Get the RowSpacing property in the visual element
            member x.GridRowSpacing = match x.Attributes.TryFind("GridRowSpacing") with Some v -> unbox<double>(v) | None -> Unchecked.defaultof<double>

            /// Get the ColumnSpacing property in the visual element
            member x.GridColumnSpacing = match x.Attributes.TryFind("GridColumnSpacing") with Some v -> unbox<double>(v) | None -> Unchecked.defaultof<double>

            /// Get the RowDefinitions property in the visual element
            member x.GridRowDefinitions = match x.Attributes.TryFind("GridRowDefinitions") with Some v -> unbox<IList<XamlElement>>(v) | None -> Unchecked.defaultof<_>

            /// Get the ColumnDefinitions property in the visual element
            member x.GridColumnDefinitions = match x.Attributes.TryFind("GridColumnDefinitions") with Some v -> unbox<IList<XamlElement>>(v) | None -> Unchecked.defaultof<_>

            /// Adjust the RowSpacing property in the visual element
            member x.WithGridRowSpacing(value: double) = x.WithAttribute("GridRowSpacing", box value)

            /// Adjust the ColumnSpacing property in the visual element
            member x.WithGridColumnSpacing(value: double) = x.WithAttribute("GridColumnSpacing", box value)
        
            /// Adjust the RowDefinitions property in the visual element
            member x.WithGridRowDefinitions (value: IList<XamlElement>) = x.WithAttribute("GridRowDefinitions", box value)

            /// Adjust the Column property in the visual element
            member x.WithGridColumnDefinitions (value: IList<XamlElement>) = x.WithAttribute("GridColumnDefinitions", box value)

            /// Adjust the Grid Row property in the visual element
            member x.WithGridRow(value: int) = x.WithAttribute("GridRow", box value)
        
            /// Adjust the Grid Column property in the visual element
            member x.WithGridColumn(value: int) = x.WithAttribute("GridColumn", box value)
        
            /// Adjust the Grid RowSpan property in the visual element
            member x.WithGridRowSpan(value: int) = x.WithAttribute("GridRowSpan", box value)
        
            /// Adjust the Grid ColumnSpan property in the visual element
            member x.WithGridColumnSpan(value: int) = x.WithAttribute("GridColumnSpan", box value)
        
            /// Try to get the Grid Row property in the visual element
            member x.TryGridRow = match x.Attributes.TryFind("GridRow") with Some v -> Some(unbox<int>(v)) | None -> None

            /// Try to get the Grid Column property in the visual element
            member x.TryGridColumn = match x.Attributes.TryFind("GridColumn") with Some v -> Some(unbox<int>(v)) | None -> None

            /// Try to get the Grid RowSpan property in the visual element
            member x.TryGridRowSpan = match x.Attributes.TryFind("GridRowSpan") with Some v -> Some(unbox<int>(v)) | None -> None

            /// Try to get the Grid ColumnSpan property in the visual element
            member x.TryGridColumnSpan = match x.Attributes.TryFind("GridColumnSpan") with Some v -> Some(unbox<int>(v)) | None -> None

            /// Try to get the Grid RowSpacing property in the visual element
            member x.TryGridRowSpacing = match x.Attributes.TryFind("GridRowSpacing") with Some v -> Some(unbox<double>(v)) | None -> None

            /// Try to get the Grid ColumnSpacing property in the visual element
            member x.TryGridColumnSpacing = match x.Attributes.TryFind("GridColumnSpacing") with Some v -> Some(unbox<double>(v)) | None -> None

            /// Get the RowDefinition_Height property in the visual element
            member x.TryGridRowDefinition_Height = match x.Attributes.TryFind("GridRowDefinition_Height") with Some v -> Some(unbox<GridLength>(v)) | None -> None

            /// Get the ColumnDefinition_Width property in the visual element
            member x.TryGridColumnDefinition_Width = match x.Attributes.TryFind("GridColumnDefinition_Width") with Some v -> Some(unbox<GridLength>(v)) | None -> None

            /// Get the RowDefinitions property in the visual element
            member x.TryGridRowDefinitions = match x.Attributes.TryFind("GridRowDefinitions") with Some v -> Some(unbox<IList<XamlElement>>(v)) | None -> None

            /// Get the ColumnDefinitions property in the visual element
            member x.TryGridColumnDefinitions = match x.Attributes.TryFind("GridColumnDefinitions") with Some v -> Some(unbox<IList<XamlElement>>(v)) | None -> None

            /// Create as a ColumnDefinition element
            member x.CreateAsGridColumnDefinition () = x.Create() :?> ColumnDefinition

            /// Create as a RowDefinition element
            member x.CreateAsGridRowDefinition () = x.Create() :?> RowDefinition

        /// Represents a ListViewDescription in the view desription
        type Xaml with 
            static member RowDefinition(?height: GridLength) = 
                let create () = Xamarin.Forms.RowDefinition() |> box
                let apply (prevOpt: XamlElement option) (source: XamlElement) (target: obj) = 
                    let target = (target :?> RowDefinition)
                    let prevHeightOpt = match prevOpt with Some prev -> prev.TryGridRowDefinition_Height | _ -> None
                    match prevHeightOpt, source.TryGridRowDefinition_Height with
                    | Some prevHeight, Some v when prevHeight = v -> ()
                    | _, Some v -> target.Height <- v
                    | _ -> ()
                let attribs = [| 
                    match height with | None -> () | Some v -> yield ("GridRowDefinition_Height", box v) 
                  |]
                new XamlElement(typeof<Xamarin.Forms.RowDefinition>, create, apply, Map.ofArray attribs)

            static member ColumnDefinition(?width: GridLength) = 
                let create () = Xamarin.Forms.ColumnDefinition() |> box
                let apply (prevOpt: XamlElement option) (source: XamlElement) (target: obj) = 
                    let target = (target :?> ColumnDefinition)
                    let prevWidthOpt = match prevOpt with Some prev -> prev.TryGridColumnDefinition_Width | _ -> None
                    match prevWidthOpt, source.TryGridColumnDefinition_Width with
                    | Some prevWidth, Some v when prevWidth = v -> ()
                    | _, Some v -> target.Width <- v
                    | _ -> ()
                let attribs = [| 
                    match width with | None -> () | Some v -> yield ("GridColumnDefinition_Width", box v) 
                  |]
                new XamlElement(typeof<Xamarin.Forms.ColumnDefinition>, create, apply, Map.ofArray attribs)

            static member Grid(?rowDefinitions: IList<XamlElement>, ?columnDefinitions: IList<XamlElement>, ?children: IList<XamlElement>, ?rowSpacing: GridLength, ?columnSpacing: GridLength, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
            
                let create () =
                     box (new Xamarin.Forms.Grid())

                let apply (prevOpt: XamlElement option) (source: XamlElement) (targetObj:obj) = 
                    let target = (targetObj :?> Xamarin.Forms.Grid)

                    if (source.GridRowDefinitions = null || source.GridRowDefinitions.Count = 0) then
                        match target.RowDefinitions with
                        | null -> ()
                        | coll -> coll.Clear() 
                    else
                        // Remove the excess children
                        while (target.RowDefinitions.Count > source.GridRowDefinitions.Count) do 
                            target.RowDefinitions.RemoveAt(target.RowDefinitions.Count - 1)

                        // Count the existing children
                        let n = target.RowDefinitions.Count

                        // Adjust the existing children and create new children
                        for i in 0 .. n - 1 do
                            let newChild = source.GridRowDefinitions.[i]
                            let prevChildOpt = match prevOpt with None -> None | Some prev -> match prev.TryChildren with None -> None | Some coll when i < coll.Count -> Some coll.[i] | _ -> None
                            if (match prevChildOpt with None -> true | Some prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                                let targetChild = target.Children.[i]
                                if (match prevChildOpt with None -> true | Some prevChild -> newChild.TargetType <> prevChild.TargetType) then
                                    target.RowDefinitions.[i] <- newChild.CreateAsGridRowDefinition()
                                else
                                    newChild.ApplyIncremental(prevChildOpt.Value, targetChild)

                        // Create the new children
                        for i in n .. source.GridRowDefinitions.Count-1 do
                            target.RowDefinitions.Insert(i, source.GridRowDefinitions.[i].CreateAsGridRowDefinition())

                    if (source.GridColumnDefinitions = null || source.GridColumnDefinitions.Count = 0) then
                        match target.ColumnDefinitions with
                        | null -> ()
                        | coll -> coll.Clear() 
                    else
                        // Remove the excess children
                        while (target.ColumnDefinitions.Count > source.GridColumnDefinitions.Count) do 
                            target.ColumnDefinitions.RemoveAt(target.ColumnDefinitions.Count - 1)

                        // Count the existing children
                        let n = target.ColumnDefinitions.Count

                        // Adjust the existing children 
                        for i in 0 .. n - 1 do
                            let newChild = source.GridColumnDefinitions.[i]
                            let prevChildOpt = match prevOpt with None -> None | Some prev -> match prev.TryChildren with None -> None | Some coll when i < coll.Count -> Some coll.[i] | _ -> None
                            if (match prevChildOpt with None -> true | Some prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                                let targetChild = target.Children.[i]
                                if (match prevChildOpt with None -> true | Some prevChild -> newChild.TargetType <> prevChild.TargetType) then
                                    target.ColumnDefinitions.[i] <- newChild.CreateAsGridColumnDefinition()
                                else
                                    newChild.ApplyIncremental(prevChildOpt.Value, targetChild)

                        // Create the new children
                        for i in n .. source.GridColumnDefinitions.Count-1 do
                            target.ColumnDefinitions.Insert(i, source.GridColumnDefinitions.[i].CreateAsGridColumnDefinition())

                    if (source.Children = null || source.Children.Count = 0) then
                        match target.Children with
                        | null -> ()
                        | children -> children.Clear() 
                    else
                        // Remove the excess children
                        while (target.Children.Count > source.Children.Count) do 
                            target.Children.RemoveAt(target.Children.Count - 1)

                        // Count the existing children
                        let n = target.Children.Count

                        // Adjust the existing children and create new children
                        for i in 0 .. source.Children.Count-1 do
                            let newChild = source.Children.[i]
                            let prevChildOpt = match prevOpt with None -> None | Some prev -> match prev.TryChildren with Some coll when i < coll.Count && i < n -> Some coll.[i] | _ -> None
                            let prevChildOpt, targetChild =
                                if (match prevChildOpt with None -> true | Some prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                                    let mustCreate = (i >= n || match prevChildOpt with None -> true | Some prevChild -> newChild.TargetType <> prevChild.TargetType)
                                    if mustCreate then
                                        let targetChild = newChild.CreateAsView()

                                        if i >= n then 
                                            target.Children.Insert(i, targetChild)
                                        else 
                                            target.Children.[i] <- targetChild
                                        None, targetChild
                                    else
                                        let targetChild1 = target.Children.[i]
                                        let targetChild = target.Children.[i]
                                        if (targetChild.GetType() <> newChild.TargetType) then 
                                            System.Diagnostics.Debugger.Break()
                                        newChild.ApplyIncremental(prevChildOpt.Value, targetChild)
                                        prevChildOpt, targetChild
                                else
                                    prevChildOpt, target.Children.[i]

                            // Adjust the attached properties
                            match (match prevChildOpt with None -> None | Some prevChild -> prevChild.TryGridRow), newChild.TryGridRow with 
                            | Some prev, Some v when prev = v -> ()
                            | _, Some v -> Grid.SetRow(targetChild, v)
                            | _ -> ()
                            match (match prevChildOpt with None -> None | Some prevChild -> prevChild.TryGridColumn), newChild.TryGridColumn with 
                            | Some prev, Some v when prev = v -> ()
                            | _, Some v -> Grid.SetColumn(targetChild, v)
                            | _ -> ()
                            match (match prevChildOpt with None -> None | Some prevChild -> prevChild.TryGridRowSpan), newChild.TryGridRowSpan with 
                            | Some prev, Some v when prev = v -> ()
                            | _, Some v -> Grid.SetRowSpan(targetChild, v)
                            | _ -> ()
                            match (match prevChildOpt with None -> None | Some prevChild -> prevChild.TryGridColumnSpan), newChild.TryGridColumnSpan with 
                            | Some prev, Some v when prev = v -> ()
                            | _, Some v -> Grid.SetColumnSpan(targetChild, v)
                            | _ -> ()

                    let prevRowSpacing = match prevOpt with Some prev -> prev.TryGridRowSpacing | _ -> None
                    match prevRowSpacing, source.TryGridRowSpacing with
                    | Some prev, Some v when prev = v -> ()
                    | _, Some v -> target.RowSpacing <- v
                    | _, None -> () 

                    let prevColumnSpacing = match prevOpt with Some prev -> prev.TryGridColumnSpacing | _ -> None
                    match prevColumnSpacing, source.TryGridColumnSpacing with
                    | Some prev, Some v when prev = v -> ()
                    | _, Some v -> target.ColumnSpacing <- v
                    | _, None -> () 

                let attribs = [| 
                    match children with None -> () | Some v -> yield ("Children", box v) 
                    match rowSpacing with None -> () | Some v -> yield ("GridRowSpacing", box v) 
                    match columnSpacing with None -> () | Some v -> yield ("GridColumnSpacing", box v) 
                    match rowDefinitions with None -> () | Some v -> yield ("GridRowDefinitions", box v) 
                    match columnDefinitions with None -> () | Some v -> yield ("GridColumnDefinitions", box v) 
                  |]
                Xaml.Layout().Inherit(typeof<Xamarin.Forms.Grid>, create, apply, attribs)
            
        let withRowSpacing m (x: XamlElement) = x.WithGridRowSpacing m
        let rowSpacing m x = withRowSpacing m x

        let withColumnSpacing m (x: XamlElement) = x.WithGridColumnSpacing m
        let columnSpacing m (x: XamlElement) = withColumnSpacing m x

    [<AutoOpen>]
    module SimplerHelpers = 
        open System.Runtime.CompilerServices
        open System.Collections.Generic
        open System.Windows.Input

        let convCommand f = 
            let ev = Event<_,_>()
            { new ICommand with 
                member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
                member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
                member x.CanExecute _ = true 
                member x.Execute _ = f() }

        let convImageSource (image: string) = ImageSource.op_Implicit image

        let convThickness (v: double) = Thickness.op_Implicit v

        let convGridLength (v: obj) = 
           match v with 
           | :? string as s when s = "*" -> GridLength.Star
           | :? string as s when s = "auto" -> GridLength.Auto
           | :? float as f -> GridLength.op_Implicit f
           | _ -> failwithf "gridLength: invalid argument %O" v

        let convFontSize (v: obj) = 
            match box v with 
            | :? string as s -> (FontSizeConverter().ConvertFromInvariantString(s) :?> double)
            | :? int as i -> double i
            | :? double as v -> v
            | _ -> System.Convert.ToDouble(v)


        let withCommand f (el: XamlElement) = el.WithCommand (convCommand f)
        let command f el = withCommand f el

        let withImageSource (image: string) (el: XamlElement) = el.WithImageSource (convImageSource image)
        let imageSource image el = withImageSource image el

        let rowdef h = Xaml.RowDefinition(height=convGridLength h)

        let rowdefs (xs: XamlElement list) = Array.ofList xs

        let coldef h = Xaml.ColumnDefinition(width=convGridLength h)

        let coldefs (xs: XamlElement list) = Array.ofList  xs

        let rows rds (els: XamlElement list) = 
            let children = Array.ofList els |> Array.mapi (fun i x -> x.WithGridRow i)
            Xaml.Grid(rowDefinitions=rowdefs rds, children=children)

        let cols cds (els: XamlElement list) = 
            let children = Array.ofList els |> Array.mapi (fun i x -> x.WithGridColumn i)
            Xaml.Grid(columnDefinitions=coldefs cds, children=children)

        let rectangle col = Xaml.Grid(backgroundColor=col)

        let gridLoc row col (el: XamlElement) = el.WithGridRow(row).WithGridColumn(col)

        let gridRow row colspan (el: XamlElement) = el.WithGridRow(row).WithGridColumnSpan(colspan)

        let gridCol col rowspan (el: XamlElement) = el.WithGridColumn(col).WithGridRowSpan(rowspan)

        let gridBlock row col rowspan colspan (el: XamlElement) = el.WithGridColumn(col).WithGridRow(row).WithGridRowSpan(rowspan).WithGridColumnSpan(colspan)

        let grid rds cds (children: XamlElement list) =
            let cdefs = coldefs cds
            let rdefs = rowdefs rds
            Xaml.Grid(rowDefinitions=rdefs, columnDefinitions=cdefs, children = Array.ofList children)

        let withMargin (v: double) (el: XamlElement) = el.WithMargin (convThickness v)
        let margin image el = withMargin image el

        let withFontSize (v: obj) (el: XamlElement) = 
            el.WithFontSize(convFontSize v)

        let fontSize size el = withFontSize size el

        // Helper page for the TicTacToe sample
        // Need to generlize the HeightRequest phase of the XF content digestion process...
        type HelperPage(viewAllocatedSizeFixup) as self =
            inherit ContentPage()
            do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, true)

            // painful.... It is unfortunately not possible to simpy recreate the whole
            // view here, you have to mutate the content in-place.
            override this.OnSizeAllocated(width, height) =
                base.OnSizeAllocated(width, height)
                viewAllocatedSizeFixup self.Content (width, height)

