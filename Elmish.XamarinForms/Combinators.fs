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
            (page :?> ContentPage).Content <- f model dispatch

    let internal pageUpdate (page: Page) contentf model dispatch =
        // TODO: make this incremental
        //page.BatchBegin()
        match contentf with 
        | None -> ()
        | Some f -> 
            (page :?> ContentPage).Content <- f model dispatch
        //page.BatchCommit()

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
    open System.Windows.Input

    let gridLength (v: obj) = 
       match v with 
       | :? string as s when s = "*" -> GridLength.Star
       | :? string as s when s = "auto" -> GridLength.Auto
       | :? float as f -> GridLength.op_Implicit f
       | _ -> failwithf "gridLength: invalid argument %O" v
       
    let rowdef h = RowDefinition(Height=gridLength h)
    let rowdefs xs = 
        let c = RowDefinitionCollection() 
        for xd in xs do 
            c.Add(xd)
        c


    let coldef h = ColumnDefinition(Width=gridLength h)
    let coldefs xs = 
        let c = ColumnDefinitionCollection() 
        for x in xs do 
            c.Add(x)
        c

    let rows rds (els: View list) = 
        let x = Grid(RowDefinitions=rowdefs rds)
        for (i, el) in List.indexed els do 
            x.Children.Add(el); Grid.SetRow(el,i)
        x

    let cols cds (els: View list) = 
        let x = Grid(ColumnDefinitions=coldefs cds)
        for (i, el) in List.indexed els do 
            x.Children.Add(el); Grid.SetColumn(el,i)
        x

    let rect col = Grid(BackgroundColor=col)

    let command f = 
        let ev = Event<_,_>()
        { new ICommand with 
            member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member x.CanExecute _ = true 
            member x.Execute _ = f() }

    type RowNumber = int
    type ColumnNumber = int
    type RowSpan = int
    type ColumnSpan = int
    type GridSpan = GridSpan of RowNumber option * ColumnNumber option * RowSpan option * ColumnSpan option
    let gridLoc row col = GridSpan (Some row, Some col, None, None)
    let gridRow row = GridSpan (Some row, None, None, None)
    let gridCol col = GridSpan (None, Some col, None, None)
    let gridBlock row col rowspan colspan = GridSpan (Some row, Some col, Some rowspan, Some colspan)


    let (@@) (v:View) (loc: GridSpan) = (v, loc)

    let grid rds cds (els: (View * GridSpan) list) =
        let cdefs = coldefs cds
        let rdefs = rowdefs rds
        let x = Grid(RowDefinitions=rdefs, ColumnDefinitions=cdefs)
        for (el, loc) in els do 
            x.Children.Add(el); 
            match loc with 
            | GridSpan(Some row, None, None, None) -> 
                Grid.SetRow(el,row)
                Grid.SetColumnSpan(el,cdefs.Count)
            | GridSpan(None, Some col, None, None) -> 
                Grid.SetColumn(el,col)
                Grid.SetRowSpan(el,rdefs.Count)

            | GridSpan(row, col, rowspan, colspan) -> 
                row |> Option.iter (fun i -> Grid.SetRow(el,i))
                col |> Option.iter (fun i -> Grid.SetColumn(el,i))
                rowspan |> Option.iter (fun i -> Grid.SetRowSpan(el,i))
                colspan |> Option.iter (fun i -> Grid.SetColumnSpan(el,i))
        x

    let label msg = Label(Text = msg)

    let button f = Button(Command=command f)

    let imageResource (res: string) = 
        Image(Source = ImageSource.op_Implicit res)

    [<Extension>]
    type VisualElementExtensions () =
        
        [<Extension>]
        static member With<'T when 'T :> VisualElement>(x: 'T) = x
        
        [<Extension>]
        static member WithBackgroundColor<'T when 'T :> VisualElement>(x: 'T, c) = x.With<'T>(BackgroundColor=c)

    [<Extension>]
    type ViewExtensions () =
        [<Extension>]
        static member With<'T when 'T :> View>(x: 'T) = x
        
        [<Extension>]
        static member WithMargin<'T when 'T :> View>(x: 'T, m:double) = x.With<'T>(Margin=Thickness.op_Implicit m)
        
        [<Extension>]
        static member WithHorizontalOptions<'T when 'T :> View>(x: 'T, opts) = x.With<'T>(HorizontalOptions=opts)
        
        [<Extension>]
        static member WithVerticalOptions<'T when 'T :> View>(x: 'T, opts) = x.With<'T>(VerticalOptions=opts)

        
    [<Extension>]
    type LabelExtensions () =
        [<Extension>]
        static member With<'T when 'T :> Label>(x: 'T) = x
        
        [<Extension>]
        static member WithTextColor<'T when 'T :> Label>(x: 'T, c) = x.With<'T>(TextColor=c)
        
        [<Extension>]
        static member WithHorizontalTextAlignment<'T when 'T :> Label>(x: 'T, c) = x.With<'T>(HorizontalTextAlignment=c)

    [<Extension>]
    type ButtonExtensions () =
        [<Extension>]
        static member With<'T when 'T :> Button>(x: 'T) = x
        
        [<Extension>]
        static member WithText<'T when 'T :> Button>(x: 'T, c) = x.With<'T>(Text=c)
        
        [<Extension>]
        static member WithTextColor<'T when 'T :> Button>(x: 'T, c) = x.With<'T>(TextColor=c)
        
    [<Extension>]
    type GridExtensions () =
        [<Extension>]
        static member With<'T when 'T :> Grid>(x: 'T) = x

        [<Extension>]
        static member WithRowSpacing<'T when 'T :> Grid>(x: 'T, c) = x.With<'T>(RowSpacing=c)
       
        [<Extension>]
        static member WithColumnSpacing<'T when 'T :> Grid>(x: 'T, c) = x.With<'T>(ColumnSpacing=c)

    let withMargin<'T when 'T :> View> (m:double) (x: 'T) = x.With(Margin=Thickness.op_Implicit m)
        
    let withHorizontalOptions<'T when 'T :> View> opts (x: 'T) = x.With<'T>(HorizontalOptions=opts)
        
    let withVerticalOptions<'T when 'T :> View> opts (x: 'T) = x.With<'T>(VerticalOptions=opts)

    let withLabelTextColor<'T when 'T :> Label> color (x: 'T) = x.With<'T>(TextColor=color)

    let withHorizontalTextAlignment<'T when 'T :> Label> alignment (x: 'T) = x.With<'T>(HorizontalTextAlignment=alignment)

    let withRowSpacing<'T when 'T :> Grid> spacing (x: 'T) = x.With<'T>(RowSpacing=spacing)

    let withColumnSpacing<'T when 'T :> Grid> spacing (x: 'T) = x.With<'T>(ColumnSpacing=spacing)

    let withText<'T when 'T :> Button> text (x: 'T) = x.With<'T>(Text=text)

    let withButtonTextColor<'T when 'T :> Button> color (x: 'T) = x.With<'T>(TextColor=color)

    let withBackgroundColor<'T when 'T :> VisualElement> color (x: 'T) = x.With<'T>(BackgroundColor=color)

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

