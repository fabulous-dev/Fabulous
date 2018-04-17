// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open Xamarin.Forms

open Elmish
open Elmish.XamarinForms

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
        | None -> ()
        | Some f -> 
            let viewData: InterpretedUI.Forms.XamlElement = f model dispatch
            let contentPage = (page :?> ContentPage)
            contentPage.Content <- viewData.CreateView() 

    let internal pageUpdate (page: Page) contentf model dispatch =
        match contentf with 
        | None -> ()
        | Some f -> 
            let viewData: InterpretedUI.Forms.XamlElement = f model dispatch
            viewData.Apply((page :?> ContentPage).Content)

    let pageInitUntyped (page: ContentPage) (bindings: ViewBindings<'model, 'msg>) =
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

                StaticView.pageInit page None bindings viewModel model dispatch

                lastModel <- Some viewModel
                console.log "view: set data context"

            | Some viewModel ->
                StaticView.pageUpdate page None model dispatch
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

                StaticView.pageInit page (Some contentf) bindings viewModel model dispatch

                lastModel <- Some viewModel
                console.log "view: set data context"

            | Some viewModel ->
                StaticView.pageUpdate page (Some contentf) model dispatch
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

module DynamicViewHelpers = 
    open System.Runtime.CompilerServices
    open System.Collections.Generic
    open System.Windows.Input
    open InterpretedUI.Forms
       
    type XamlElement with 
        /// Get the RowDefinition_Height property in the visual element
        member x.RowDefinition_Height = match x.Attributes.TryFind("RowDefinition_Height") with Some v -> unbox<GridLength>(v) | None -> GridLength.Auto

        /// Get the ColumnDefinition_Width property in the visual element
        member x.ColumnDefinition_Width = match x.Attributes.TryFind("ColumnDefinition_Width") with Some v -> unbox<GridLength>(v) | None -> GridLength.Auto

        /// Get the RowSpacing property in the visual element
        member x.RowSpacing = match x.Attributes.TryFind("RowSpacing") with Some v -> unbox<double>(v) | None -> Unchecked.defaultof<double>

        /// Get the ColumnSpacing property in the visual element
        member x.ColumnSpacing = match x.Attributes.TryFind("ColumnSpacing") with Some v -> unbox<double>(v) | None -> Unchecked.defaultof<double>

        /// Get the RowDefinitions property in the visual element
        member x.RowDefinitions = match x.Attributes.TryFind("RowDefinitions") with Some v -> unbox<IList<XamlElement>>(v) | None -> Unchecked.defaultof<_>

        /// Get the ColumnDefinitions property in the visual element
        member x.ColumnDefinitions = match x.Attributes.TryFind("ColumnDefinitions") with Some v -> unbox<IList<XamlElement>>(v) | None -> Unchecked.defaultof<_>

        /// Adjust the RowSpacing property in the visual element
        member x.WithRowSpacing(value: double) = x.WithAttribute("RowSpacing", box value)

        /// Adjust the ColumnSpacing property in the visual element
        member x.WithColumnSpacing(value: double) = x.WithAttribute("ColumnSpacing", box value)
        
        /// Adjust the RowDefinitions property in the visual element
        member x.WithRowDefinitions (value: IList<XamlElement>) = x.WithAttribute("RowDefinitions", box value)

        /// Adjust the Column property in the visual element
        member x.WithColumnDefinitions (value: IList<XamlElement>) = x.WithAttribute("Column", box value)

        member x.CreateColumnDefinition () = x.Create() :?> ColumnDefinition
        member x.CreateRowDefinition () = x.Create() :?> RowDefinition

    /// Represents a ListViewDescription in the view desription
    type Xaml with 
        static member RowDefinition(?height) = 
            let create () = Xamarin.Forms.RowDefinition() |> box
            let apply (this: XamlElement) (target: obj) = 
                let target = (target :?> RowDefinition)
                target.Height <- this.RowDefinition_Height
            let attribs = [| 
                match height with | None -> () | Some v -> yield ("Height", box v) 
              |]
            new XamlElement(typeof<Xamarin.Forms.RowDefinition>, create, apply, Map.ofArray attribs)

        static member ColumnDefinition(?width) = 
            let create () = Xamarin.Forms.ColumnDefinition() |> box
            let apply (this: XamlElement) (target: obj) = 
                let target = (target :?> ColumnDefinition)
                target.Width <- this.ColumnDefinition_Width
            let attribs = [| 
                match width with | None -> () | Some v -> yield ("ColumnDefinition_Width", box v) 
              |]
            new XamlElement(typeof<Xamarin.Forms.ColumnDefinition>, create, apply, Map.ofArray attribs)

        static member Grid(?children: IList<XamlElement>, ?rowDefinitions: IList<XamlElement>, ?columnDefinitions: IList<XamlElement>, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
            let create () =
                box (new Xamarin.Forms.Grid())

            let apply (this: XamlElement) (target:obj) = 
                let target = (target :?> Xamarin.Forms.Grid)

                if (this.RowDefinitions = null || this.RowDefinitions.Count = 0) then
                    match target.RowDefinitions with
                    | null -> ()
                    | coll -> coll.Clear() 
                else
                    while (target.RowDefinitions.Count > this.RowDefinitions.Count) do target.RowDefinitions.RemoveAt(target.RowDefinitions.Count - 1)
                    let n = target.RowDefinitions.Count;
                    for i in n .. this.RowDefinitions.Count-1 do
                        target.RowDefinitions.Insert(i, this.RowDefinitions.[i].CreateRowDefinition())
                    for i in 0 .. n - 1 do
                        this.RowDefinitions.[i].Apply(target.RowDefinitions.[i])

                if (this.ColumnDefinitions = null || this.ColumnDefinitions.Count = 0) then
                    match target.ColumnDefinitions with
                    | null -> ()
                    | coll -> coll.Clear() 
                else
                    while (target.ColumnDefinitions.Count > this.ColumnDefinitions.Count) do target.ColumnDefinitions.RemoveAt(target.ColumnDefinitions.Count - 1)
                    let n = target.ColumnDefinitions.Count;
                    for i in n .. this.ColumnDefinitions.Count-1 do
                        target.ColumnDefinitions.Insert(i, this.ColumnDefinitions.[i].CreateColumnDefinition())
                    for i in 0 .. n - 1 do
                        this.ColumnDefinitions.[i].Apply(target.ColumnDefinitions.[i])


                if (this.Children = null || this.Children.Count = 0) then
                    match target.Children with
                    | null -> ()
                    | children -> children.Clear() 
                else
                    while (target.Children.Count > this.Children.Count) do target.Children.RemoveAt(target.Children.Count - 1)
                    let n = target.Children.Count;
                    for i in n .. this.Children.Count-1 do
                        target.Children.Insert(i, this.Children.[i].CreateView())
                    for i in 0 .. n - 1 do
                        this.Children.[i].Apply(target.Children.[i])

                for i in 0 .. this.Children.Count-1 do
                    match this.Children.[i].Attributes.TryFind("Row") with 
                    | Some (:? int as v) -> Grid.SetRow(target.Children.[i], v)
                    | _ -> ()
                    match this.Children.[i].Attributes.TryFind("Column") with 
                    | Some (:? int as v) -> Grid.SetColumn(target.Children.[i], v)
                    | _ -> ()
                    match this.Children.[i].Attributes.TryFind("RowSpan") with 
                    | Some (:? int as v) -> Grid.SetRowSpan(target.Children.[i], v)
                    | _ -> ()
                    match this.Children.[i].Attributes.TryFind("ColumnSpan") with 
                    | Some (:? int as v) -> Grid.SetColumnSpan(target.Children.[i], v)
                    | _ -> ()

                target.HorizontalOptions <- this.HorizontalOptions
                target.VerticalOptions <- this.VerticalOptions
                target.Margin <- this.Margin
                target.BackgroundColor <- this.BackgroundColor
                target.IsVisible <- this.IsVisible
                target.Opacity <- this.Opacity
                target.WidthRequest <- this.WidthRequest
                target.HeightRequest <- this.HeightRequest
                target.IsEnabled <- this.IsEnabled
            let attribs = [| 
                match children with | None -> () | Some v -> yield ("Children", box children) 
                match rowDefinitions with | None -> () | Some v -> yield ("RowDefinitions", box rowDefinitions) 
                match columnDefinitions with | None -> () | Some v -> yield ("ColumnDefinitions", box columnDefinitions) 
                match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box horizontalOptions) 
                match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box verticalOptions) 
                match margin with | None -> () | Some v -> yield ("Margin", box margin) 
                match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box backgroundColor) 
                match isVisible with | None -> () | Some v -> yield ("IsVisible", box isVisible) 
                match opacity with | None -> () | Some v -> yield ("Opacity", box opacity) 
                match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box widthRequest) 
                match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box heightRequest) 
                match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box isEnabled) 
              |]
            new XamlElement(typeof<Xamarin.Forms.Grid>, create, apply, Map.ofArray attribs)


    let gridLength (v: obj) = 
       match v with 
       | :? string as s when s = "*" -> GridLength.Star
       | :? string as s when s = "auto" -> GridLength.Auto
       | :? float as f -> GridLength.op_Implicit f
       | _ -> failwithf "gridLength: invalid argument %O" v

    let rowdef h = Xaml.RowDefinition(height=gridLength h)
    let rowdefs (xs: XamlElement list) = Array.ofList xs

    let coldef h = Xaml.ColumnDefinition(width=gridLength h)
    let coldefs (xs: XamlElement list) = Array.ofList  xs

    let rows rds (els: XamlElement list) = 
        let children = Array.ofList els |> Array.mapi (fun i x -> x.WithAttribute("Row", box i))
        Xaml.Grid(rowDefinitions=rowdefs rds, children=children)

    let cols cds (els: XamlElement list) = 
        let children = Array.ofList els |> Array.mapi (fun i x -> x.WithAttribute("Column", box i))
        Xaml.Grid(columnDefinitions=coldefs cds, children=children)

    let rectangle col = Xaml.Grid(backgroundColor=col)

    type RowNumber = int
    type ColumnNumber = int
    type RowSpan = int
    type ColumnSpan = int
    type GridSpanDescription = GridSpanDescription of RowNumber option * ColumnNumber option * RowSpan option * ColumnSpan option
    let gridLoc row col = GridSpanDescription (Some row, Some col, None, None)
    let gridRow row = GridSpanDescription (Some row, None, None, None)
    let gridCol col = GridSpanDescription (None, Some col, None, None)
    let gridBlock row col rowspan colspan = GridSpanDescription (Some row, Some col, Some rowspan, Some colspan)


    let (@@) (v:XamlElement) (loc: GridSpanDescription) = (v, loc)

    let grid rds cds (els: (XamlElement * GridSpanDescription) list) =
        let cdefs = coldefs cds
        let rdefs = rowdefs rds
        let children = 
          [| for (el, loc) in els ->
                match loc with 
                | GridSpanDescription(Some row, None, None, None) -> 
                    el.WithAttribute("Row", row).WithAttribute("ColumnSpan", cdefs.Length)
                | GridSpanDescription(None, Some col, None, None) -> 
                    el.WithAttribute("Column", col).WithAttribute("RowSpan", rdefs.Length)
                | GridSpanDescription(row, col, rowspan, colspan) -> 
                    let el = match row with None -> el | Some i -> el.WithAttribute("Row", box i)
                    let el = match col with None -> el | Some i -> el.WithAttribute("Column", box i)
                    let el = match rowspan with None -> el | Some i -> el.WithAttribute("RowSpan", box i)
                    let el = match colspan with None -> el | Some i -> el.WithAttribute("ColumnSpan", box i)
                    el
           |]
        Xaml.Grid(rowDefinitions=rdefs, columnDefinitions=cdefs, children = children)

    let withMargin (m: double) (x: XamlElement) = x.WithMargin (Thickness.op_Implicit m)
    let margin m x = withMargin m x
        
    let withSource (m: ImageSource) (x: XamlElement) = x.WithImageSource m
    let source m x = withSource m x

    let withHorizontalOptions m (x: XamlElement) = x.WithHorizontalOptions m
    let horizontalOptions m x = withHorizontalOptions m x
        
    let withVerticalOptions m (x: XamlElement) = x.WithVerticalOptions m
    let verticalOptions m x = withVerticalOptions m x

    let withTextColor m (x: XamlElement) = x.WithTextColor m
    let textColor m x = withTextColor m x

    let withHorizontalTextAlignment m (x: XamlElement) = x.WithHorizontalTextAlignment m
    let horizontalTextAlignment m x = withHorizontalTextAlignment m x

    let withRowSpacing m (x: XamlElement) = x.WithRowSpacing m
    let rowSpacing m x = withRowSpacing m x

    let withColumnSpacing m (x: XamlElement) = x.WithColumnSpacing m
    let columnSpacing m (x: XamlElement) = withColumnSpacing m x

    let withText m (x: XamlElement) = x.WithText m
    let text m (x: XamlElement) = x.WithText m

    let withCommand f (x: XamlElement) = 
        let ev = Event<_,_>()
        let command = 
            { new ICommand with 
                member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
                member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
                member x.CanExecute _ = true 
                member x.Execute _ = f() }
        x.WithCommand command

    let command f (x: XamlElement) = withCommand f x

    let withBackgroundColor m (x: XamlElement) = x.WithBackgroundColor m
    let backgroundColor m (x: XamlElement) = withBackgroundColor m x

    let label = Xaml.Label()

    let button = Xaml.Button()

    let image = Xaml.Image()

    let imageResource (res: string) = image |> withSource (ImageSource.op_Implicit res)

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

