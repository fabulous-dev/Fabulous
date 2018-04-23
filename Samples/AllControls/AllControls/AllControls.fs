// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace AllControls

open System
open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

type Model = 
  { Count : int
    CountForSlider : int
    CountForActivityIndicator : int
    StepForSlider : int 
    StartDate : System.DateTime
    EndDate : System.DateTime
    NumTaps : int 
    NumTaps2 : int 
    PickedColorIndex: int
    GridSize: double
    GridPortal: int * int }

type Msg = 
    | Increment 
    | Decrement 
    | Reset
    | IncrementForSlider
    | DecrementForSlider
    | IncrementForActivityIndicator
    | DecrementForActivityIndicator
    | SliderValueChanged of int
    | TextChanged of string * string
    | EditorEditCompleted 
    | EntryEditCompleted 
    | GridEditCompleted of int * int
    | StartDateSelected of DateTime 
    | EndDateSelected of DateTime 
    | PickerItemChanged of int
    | ListViewSelectedItemChanged of int option
    | ListViewGroupedSelectedItemChanged of (int * int) option
    | FrameTapped 
    | FrameTapped2 
    | UpdateGridSize of double
    | UpdateGridPortal of int * int

type AllControls () = 
    inherit Application ()

    let init () = 
        { Count = 0
          CountForSlider = 0
          CountForActivityIndicator = 0
          StepForSlider = 3
          PickedColorIndex = 0
          GridSize = 6.0
          GridPortal=(0,0)
          StartDate=System.DateTime.Today
          EndDate=System.DateTime.Today.AddDays(1.0)
          NumTaps=0
          NumTaps2=0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1}
        | IncrementForSlider -> { model with CountForSlider = model.CountForSlider + model.StepForSlider }
        | DecrementForSlider -> { model with CountForSlider = model.CountForSlider + model.StepForSlider }
        | IncrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator + 1 }
        | DecrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator - 1 }
        | Reset -> init ()
        | SliderValueChanged n -> { model with StepForSlider = n }
        | TextChanged (oldValue, newValue) -> model
        | EditorEditCompleted -> model
        | EntryEditCompleted  -> model
        | StartDateSelected d -> { model with StartDate = d; EndDate = d + (model.EndDate - model.StartDate) }
        | EndDateSelected d -> { model with EndDate = d }
        | GridEditCompleted (i, j) -> model
        | ListViewSelectedItemChanged item -> model
        | ListViewGroupedSelectedItemChanged item -> model
        | PickerItemChanged i -> { model with PickedColorIndex = i }
        | FrameTapped -> { model with NumTaps= model.NumTaps + 1 }
        | FrameTapped2 -> { model with NumTaps2= model.NumTaps2 + 1 }
        | UpdateGridSize n -> { model with GridSize = n }
        | UpdateGridPortal (x,y) -> { model with GridPortal = (x,y) }

    let pickerItems = 
        [ ( "Aqua", Color.Aqua ); ( "Black", Color.Black );
          ( "Blue", Color.Blue ); ( "Fucshia", Color.Fuchsia);
          ( "Gray", Color.Gray ); ( "Green", Color.Green );
          ( "Lime", Color.Lime ); ( "Maroon", Color.Maroon );
          ( "Navy", Color.Navy ); ( "Olive", Color.Olive );
          ( "Purple", Color.Purple ); ( "Red", Color.Red );
          ( "Silver", Color.Silver ); ( "Teal", Color.Teal );
          ( "White", Color.White ); ( "Yellow", Color.Yellow ) ]

    let view (model: Model) dispatch =
      Xaml.TabbedPage(
        children=[
         Xaml.ContentPage(
          title="Button",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="Label:")
                Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button:")
                Xaml.Button(text="Increment", command= (fun () -> dispatch Increment), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button (cornerRadius=5):")
                Xaml.Button(text="Decrement", cornerRadius=5, command= (fun () -> dispatch Decrement), horizontalOptions=LayoutOptions.CenterAndExpand)
                
              ])))
         Xaml.ContentPage(
          title="Slider",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="Label:")
                Xaml.Label(text= sprintf "%d" model.CountForSlider, horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="Button:")
                Xaml.Button(text="Increment", command= (fun () -> dispatch IncrementForSlider), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button:")
                Xaml.Button(text="Decrement", command= (fun () -> dispatch DecrementForSlider), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Slider:")
                Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.StepForSlider, 
                            valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), 
                            horizontalOptions=LayoutOptions.Fill) 
              ])))
         Xaml.ContentPage(
          title="ActivityIndicator",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="Label:")
                Xaml.Label(text= sprintf "%d" model.CountForActivityIndicator, horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="ActivityIndicator (when count > 0):")
                Xaml.ActivityIndicator(isRunning=(model.CountForActivityIndicator > 0), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button:")
                Xaml.Button(text="Increment", command= (fun () -> dispatch IncrementForActivityIndicator), horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="Button:")
                Xaml.Button(text="Decrement", command= (fun () -> dispatch DecrementForActivityIndicator), horizontalOptions=LayoutOptions.CenterAndExpand)
                
              ])))

         Xaml.ContentPage(
          title="DatePicker",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="DatePicker (start):")
                Xaml.DatePicker(minimumDate= System.DateTime.Today, maximumDate=DateTime.Today + TimeSpan.FromDays(365.0), 
                                date=model.StartDate,
                                dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)), 
                                horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="DatePicker (end):")
                Xaml.DatePicker(minimumDate= model.StartDate, maximumDate=model.StartDate + TimeSpan.FromDays(365.0), 
                                date=model.EndDate,
                                dateSelected=(fun args -> dispatch (EndDateSelected args.NewDate)), 
                                horizontalOptions=LayoutOptions.CenterAndExpand)
                
              ])))
         Xaml.ContentPage(
          title="Editor",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="Editor:")
                Xaml.Editor(text= "Hic haec hoc", horizontalOptions=LayoutOptions.CenterAndExpand, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EditorEditCompleted))

              ])))
         Xaml.ContentPage(
          title="Entry",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="Entry:")
                Xaml.Entry(text= "the initial entry", horizontalOptions=LayoutOptions.CenterAndExpand, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))

                Xaml.Label(text="Entry (password):")
                Xaml.Entry(text= "secret", isPassword=true, horizontalOptions=LayoutOptions.CenterAndExpand, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))
                Xaml.Label(text="Entry (placeholder):")
                Xaml.Entry(placeholder= "Enter some text", horizontalOptions=LayoutOptions.CenterAndExpand, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))

              ])))
         Xaml.ContentPage(
          title="Frame",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[

                Xaml.Label(text="Frame (hasShadow=true):")
                Xaml.Frame(hasShadow=true, backgroundColor=Color.AliceBlue, horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="Frame (tap once gesture):")
                Xaml.Frame(hasShadow=true, backgroundColor=snd (pickerItems.[model.NumTaps % pickerItems.Length]), horizontalOptions=LayoutOptions.CenterAndExpand,
                           gestureRecognizers=[ Xaml.TapGestureRecognizer(command=(fun () -> dispatch FrameTapped)) ] )

                Xaml.Label(text="Frame (tap twice gesture):")
                Xaml.Frame(hasShadow=true, backgroundColor=snd (pickerItems.[model.NumTaps2 % pickerItems.Length]), horizontalOptions=LayoutOptions.CenterAndExpand,
                           gestureRecognizers=[ Xaml.TapGestureRecognizer(numberOfTapsRequired=2, command=(fun () -> dispatch FrameTapped2)) ] )

              ])))

         Xaml.ContentPage(
          title="Grid",
          content=
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text=sprintf "Grid (nxn, auto, size = %f):" model.GridSize)
                Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"], coldefs=[for i in 1 .. 6 -> box "auto"], 
                          children = [ for i in 1 .. 6 do for j in 1 .. 6 -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ] )
              ] ))

         Xaml.ContentPage(
          title="Grid+Pinch",
          content=
              Xaml.StackLayout(padding=20.0,
               children=[

                Xaml.Label(text=sprintf "Grid (nxn, auto, pinch, size = %f):" model.GridSize)
                (let sz = int model.GridSize
                 Xaml.Grid(rowdefs= [for i in 1 .. sz -> box "auto"], coldefs=[for i in 1 .. sz -> box "auto"], 
                           children = [ for i in 1 .. sz do for j in 1 .. sz -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ],
                           gestureRecognizers=[ Xaml.PinchGestureRecognizer(pinchUpdated=(fun pinchArgs -> dispatch (UpdateGridSize (model.GridSize * pinchArgs.Scale)))) ] ))
              ] ))

         Xaml.ContentPage(
          title="Grid+Pan",
          content=
              Xaml.StackLayout(padding=20.0,
               children=[

                (let dx, dy = model.GridPortal
                 Xaml.Label(text= sprintf "Grid (nxn, auto, edit diagonal, 1-touch pan, (%d, %d):" dx dy))
                (let dx, dy = model.GridPortal
                 Xaml.Grid(rowdefs= [for row in 1 .. 6 -> box "auto"], coldefs=[for col in 1 .. 6 -> box "auto"], 
                           children = [ for row in 1 .. 6 do 
                                         for col in 1 .. 6 ->
                                           let item = 
                                               if row+dy = col+dx then Xaml.Entry(text=sprintf "%d" (row+dy), backgroundColor=Color.White, textColor=Color.Black) 
                                               else Xaml.BoxView(Color.White)
                                           item.GridRow(row-1).GridColumn(col-1) ],
                           gestureRecognizers=[ Xaml.PanGestureRecognizer(touchPoints=1,panUpdated=(fun panArgs -> if panArgs.StatusType = GestureStatus.Running then dispatch (UpdateGridPortal (int -(panArgs.TotalX/10.0), int -(panArgs.TotalY/10.0))))) ] ))
              ]))

         Xaml.ContentPage(
          title="Picker",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[

                Xaml.Label(text="Picker:")
                Xaml.Picker(title="Choose Color:", textColor= snd pickerItems.[model.PickedColorIndex], selectedIndex=model.PickedColorIndex, itemsSource=(List.map fst pickerItems), horizontalOptions=LayoutOptions.CenterAndExpand,selectedIndexChanged=(fun (i, item) -> dispatch (PickerItemChanged i)))
              ])))

         Xaml.ContentPage(
          title="ListView",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="ListView:")
                // Note: the view contents of lists must always be amortized, otherwise 'itemSelected' can't find the
                // correct index for the item using object reference identity
                Xaml.ListView(items = amortize () (fun () -> 
                                        [ for i in 0 .. 10 do 
                                           yield Xaml.Label "Ionide"
                                           yield Xaml.Label "Visual Studio"
                                           yield Xaml.Label "Emacs"
                                           yield Xaml.Label "Visual Studio Code"
                                           yield Xaml.Label "Rider"]), 
                              horizontalOptions=LayoutOptions.CenterAndExpand,
                              itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))

              ]))) 

         Xaml.ContentPage(
          title="ListViewGrouped",
          content=
            Xaml.ScrollView(
              Xaml.StackLayout(padding=20.0,
               children=[
                Xaml.Label(text="ListView (grouped):")
                // Note: the view contents of lists must always be amortized, otherwise 'itemSelected' can't find the
                // correct index for the item using object reference identity
                Xaml.ListViewGrouped(items= amortize () (fun () -> 
                                        [  yield Xaml.Label "Europe", [ Xaml.Label "Russia"; Xaml.Label "Germany"; Xaml.Label "Poland"; Xaml.Label "Greece"   ]
                                           yield Xaml.Label "Asia", [ Xaml.Label "China"; Xaml.Label "Japan"; Xaml.Label "North Korea"; Xaml.Label "South Korea"   ]
                                           yield Xaml.Label "Australasia", [ Xaml.Label "Australia"; Xaml.Label "New Zealand"; Xaml.Label "Fiji" ] ]), 
                              horizontalOptions=LayoutOptions.CenterAndExpand,
                              isGroupingEnabled=true,
                              itemSelected=(fun idx -> dispatch (ListViewGroupedSelectedItemChanged idx)))

              ]))) ])

                //Xaml.ListView() // Persistent selection in grouping
                //
                //Xaml.Image(source="icon") // TODO
                //
                // Xaml.Table, EntryCell and others: TODO
                //
                // Xaml.NavigationPage: TODO
                // Xaml.Menu: TODO
                // Xaml.MenuItem: TODO
                // Xaml.NavigationMenu: TODO
                // Xaml.Accelerator: TODO
                //
                // Xaml.CarouselPage: ok, needs sample
                //
                // Xaml.AbsoluteLayout: ok, needs sample
                //
                // Xaml.MasterDetailPage: TODO
                //
                // Xaml.Animation: TODO
                //
                // Xaml.OpenGLView: TODO
                //
                // Xaml.AppLinkEntry: TODO
                // Xaml.MessagingCenter: TODO
                // TODO: fix slider where minimum = 1.0 (gets set before maximum..)
                // TODO: better recovery from exceptions on modifications

    do
        let page = 
            Program.mkSimple init update view
            |> Program.withConsoleTrace
            |> Program.withDynamicView
            |> Program.run

        base.MainPage <- page
