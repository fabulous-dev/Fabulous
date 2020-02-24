namespace AllControls.Pages

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open System
open Xamarin.Forms

module CarouselPage =
    type Msg =
        | SetCarouselCurrentPage of int
        | Increment 
        | Decrement 
        | Reset
        | IncrementForActivityIndicator
        | DecrementForActivityIndicator
        | StartDateSelected of DateTime 
        | EndDateSelected of DateTime 
        | TextChanged of string * string
        | EditorEditCompleted of string
        | EntryEditCompleted of string
        | PasswordEntryEditCompleted of string
        | PlaceholderEntryEditCompleted of string
        | FrameTapped 
        | FrameTapped2
    
    type CmdMsg = Nothing
    
    type Model =
        { CarouselCurrentPageIndex: int
          Count: int
          CountForActivityIndicator: int
          StartDate: DateTime
          EndDate: DateTime
          EditorText: string
          EntryText: string
          Placeholder: string
          Password: string
          NumTaps: int 
          NumTaps2: int }

    let pickerItems = 
        [ ("Aqua", Color.Aqua); ("Black", Color.Black);
          ("Blue", Color.Blue); ("Fuchsia", Color.Fuchsia);
          ("Gray", Color.Gray); ("Green", Color.Green);
          ("Lime", Color.Lime); ("Maroon", Color.Maroon);
          ("Navy", Color.Navy); ("Olive", Color.Olive);
          ("Purple", Color.Purple); ("Red", Color.Red);
          ("Silver", Color.Silver); ("Teal", Color.Teal);
          ("White", Color.White); ("Yellow", Color.Yellow ) ]
        
    let mapToCmd _ = Cmd.none
        
    let init () =
        { CarouselCurrentPageIndex = 0
          Count = 0
          CountForActivityIndicator = 0
          StartDate = DateTime.Today
          EndDate = DateTime.Today.AddDays(1.0)
          EditorText = "hic hac hoc"
          Placeholder = "cogito ergo sum"
          Password = "in omnibus errant"
          EntryText = "quod erat demonstrandum"
          NumTaps = 0
          NumTaps2 = 0 }
        
    let update msg model =
        match msg with
        | SetCarouselCurrentPage index ->
            { model with CarouselCurrentPageIndex = index }, []
        | Increment -> { model with Count = model.Count + 1 }, []
        | Decrement -> { model with Count = model.Count - 1 }, []
        | Reset -> init (), []
        | IncrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator + 1 }, []
        | DecrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator - 1 }, []
        | StartDateSelected d -> { model with StartDate = d; EndDate = d + (model.EndDate - model.StartDate) }, []
        | EndDateSelected d -> { model with EndDate = d }, []
        | TextChanged _ -> model, []
        | EditorEditCompleted t -> { model with EditorText = t }, []
        | EntryEditCompleted t -> { model with EntryText = t }, []
        | PasswordEntryEditCompleted t -> { model with Password = t }, []
        | PlaceholderEntryEditCompleted t -> { model with Placeholder = t }, []
        | FrameTapped -> { model with NumTaps= model.NumTaps + 1 }, []
        | FrameTapped2 -> { model with NumTaps2= model.NumTaps2 + 1 }, []
        
    let pane1View count dispatch =
        View.ScrollingContentPage(
            title = "Button", 
            content = View.StackLayout([
                View.Label(text = "Label:")
                View.Label(
                    text = sprintf "%d" count,
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )
                 
                View.Label(text = "Button:")
                View.Button(
                    horizontalOptions=LayoutOptions.CenterAndExpand,
                    text = "Increment",
                    command = fun () -> dispatch Increment
                )

                View.Label(text = "Button:")
                View.Button(
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    text = "Decrement",
                    command=(fun () -> dispatch Decrement)
                )

                View.Button(
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    verticalOptions = LayoutOptions.End,
                    text = "Go to grid",
                    cornerRadius = 5,
                    command = fun () -> dispatch (SetCarouselCurrentPage 6) 
                )
            ])
        )
        
    let pane2View count dispatch =
        View.ScrollingContentPage(
            title = "ActivityIndicator",
            content = View.StackLayout([
                View.Label(text = "Label:")
                View.Label(
                    text = sprintf "%d" count,
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )

                View.Label(text = "ActivityIndicator (when count > 0):")
                View.ActivityIndicator(
                    isRunning = (count > 0),
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )
              
                View.Label(text = "Button:")
                View.Button(
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    text = "Increment",
                    command = fun () -> dispatch IncrementForActivityIndicator
                )

                View.Label(text = "Button:")
                View.Button(
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    text = "Decrement",
                    command = fun () -> dispatch DecrementForActivityIndicator
                )
            ])
        )
        
    let pane3View startDate endDate dispatch =
        View.ScrollingContentPage(
            title = "DatePicker", 
            content = View.StackLayout([
                View.Label(text = "DatePicker (start):")
                View.DatePicker(
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    minimumDate = DateTime.Today,
                    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0), 
                    date = startDate, 
                    dateSelected = fun args -> dispatch (StartDateSelected args.NewDate)
                )

                View.Label(text = "DatePicker (end):")
                View.DatePicker( 
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    minimumDate = startDate,
                    maximumDate = startDate + TimeSpan.FromDays(365.0), 
                    date = endDate, 
                    dateSelected = fun args -> dispatch (EndDateSelected args.NewDate)
                )
            ])
        )
        
    let pane4View editorText dispatch =
        View.ScrollingContentPage(
            title = "Editor",
            content = View.StackLayout([
                View.Label(text="Editor:")
                View.Editor(
                    text = editorText,
                    horizontalOptions = LayoutOptions.FillAndExpand, 
                    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
                    completed = fun text -> dispatch (EditorEditCompleted text))
            ])
        )
        
    let pane5View entryText password placeholder dispatch =
        View.ScrollingContentPage(
            title = "Entry",
            content = View.StackLayout([
                View.Label(text = "Entry:")
                View.Entry(
                    text = entryText,
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
                    completed = fun text -> dispatch (EntryEditCompleted text)
                )

                View.Label(text = "Entry (password):")
                View.Entry(
                    text = password,
                    isPassword = true,
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
                    completed = fun text -> dispatch (PasswordEntryEditCompleted text)
                )

                View.Label(text = "Entry (placeholder):")
                View.Entry(
                    placeholder = placeholder,
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
                    completed = fun text -> dispatch (PlaceholderEntryEditCompleted text)
                )
            ])
        )
        
    let pane6View numTaps numTaps2 dispatch =
        View.ScrollingContentPage(
            title = "Frame",
            content = View.StackLayout([
                View.Label(text = "Frame (hasShadow=true):")
                View.Frame(
                    hasShadow = true,
                    backgroundColor = Color.AliceBlue,
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )

                View.Label(text = "Frame (tap once gesture):")
                View.Frame(
                    hasShadow = true, 
                    backgroundColor = snd (pickerItems.[numTaps % pickerItems.Length]), 
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    gestureRecognizers = [
                        View.TapGestureRecognizer(
                            command = fun () -> dispatch FrameTapped
                        )
                    ]
                )

                View.Label(text = "Frame (tap twice gesture):")
                View.Frame(
                    hasShadow = true, 
                    backgroundColor = snd (pickerItems.[numTaps2 % pickerItems.Length]), 
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    gestureRecognizers = [
                        View.TapGestureRecognizer(
                            numberOfTapsRequired = 2,
                            command = fun () -> dispatch FrameTapped2
                        )
                    ]
                )
            ])
        )
        
    let pane7View () =
        View.NonScrollingContentPage(
            title = "Grid",
            content = View.StackLayout([
                View.Label(text = sprintf "Grid (6x6, auto):")
                View.Grid(
                    rowdefs = [for i in 1 .. 6 -> Auto], 
                    coldefs = [for i in 1 .. 6 -> Auto], 
                    children = 
                        [ for i in 1 .. 6 do 
                            for j in 1 .. 6 -> 
                                let color = Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0)
                                View.BoxView(color).Row(i-1).Column(j-1) ]
                )
            ])
        )
    
    let view model dispatch =
        View.CarouselPage(
            useSafeArea = true,
            currentPageChanged = (fun index -> 
                match index with
                | None -> printfn "No page selected"
                | Some ind ->
                    printfn "Page changed : %i" ind
                    dispatch (SetCarouselCurrentPage ind)
            ),
            currentPage = model.CarouselCurrentPageIndex,
            children = [
                dependsOn model.Count (fun model count ->
                    pane1View count dispatch
                )

                dependsOn model.CountForActivityIndicator (fun model count ->
                    pane2View count dispatch
                )

                dependsOn (model.StartDate, model.EndDate) (fun model (startDate, endDate) ->
                    pane3View startDate endDate dispatch
                )

                dependsOn model.EditorText (fun model editorText ->
                    pane4View editorText dispatch
                )

                dependsOn (model.EntryText, model.Password, model.Placeholder) (fun model (entryText, password, placeholder) ->
                   pane5View entryText password placeholder dispatch
                )

                dependsOn (model.NumTaps, model.NumTaps2) (fun model (numTaps, numTaps2) ->
                    pane6View numTaps numTaps2 dispatch
                )

                dependsOn () (fun model () ->
                    pane7View()
                )
        ])

