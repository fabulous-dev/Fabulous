// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace AllControls

open System
open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

type Model = 
  { Count : int
    CountForSlider : int
    CountForActivityIndicator : int
    StepForSlider : int 
    StartDate : System.DateTime
    EndDate : System.DateTime
    EditorText : string
    EntryText : string
    Placeholder : string
    Password : string
    NumTaps : int 
    NumTaps2 : int 
    PickedColorIndex: int
    GridSize: int
    NewGridSize: double // used during pinch
    GridPortal: int * int 
    // 
    IsPresented: bool 
    PageStack: string list }

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
    | EditorEditCompleted of string
    | EntryEditCompleted of string
    | PasswordEntryEditCompleted of string
    | PlaceholderEntryEditCompleted of string
    | GridEditCompleted of int * int
    | StartDateSelected of DateTime 
    | EndDateSelected of DateTime 
    | PickerItemChanged of int
    | ListViewSelectedItemChanged of int option
    | ListViewGroupedSelectedItemChanged of (int * int) option
    | FrameTapped 
    | FrameTapped2 
    | UpdateNewGridSize of double * GestureStatus
    | UpdateGridPortal of int * int
    // For MasterDetail
    | IsPresentedChanged of bool
    | GoHomePage
    | PopPage
    | PushPage of string

module App = 
    let init () = 
        { Count = 0
          CountForSlider = 0
          CountForActivityIndicator = 0
          StepForSlider = 3
          PickedColorIndex = 0
          EditorText = "hic hac hoc"
          Placeholder = "cogito ergo sum"
          Password = "in omnibus errant"
          EntryText = "quod erat demonstrandum"
          GridSize = 6
          NewGridSize = 6.0
          GridPortal=(0,0)
          StartDate=System.DateTime.Today
          EndDate=System.DateTime.Today.AddDays(1.0)
          NumTaps=0
          NumTaps2=0
          IsPresented=false
          PageStack=["Home"]}

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1}
        | IncrementForSlider -> { model with CountForSlider = model.CountForSlider + model.StepForSlider }
        | DecrementForSlider -> { model with CountForSlider = model.CountForSlider - model.StepForSlider }
        | IncrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator + 1 }
        | DecrementForActivityIndicator -> { model with CountForActivityIndicator = model.CountForActivityIndicator - 1 }
        | Reset -> init ()
        | SliderValueChanged n -> { model with StepForSlider = n }
        | TextChanged (oldValue, newValue) -> model
        | EditorEditCompleted t -> { model with EditorText = t }
        | EntryEditCompleted t -> { model with EntryText = t }
        | PasswordEntryEditCompleted t -> { model with Password = t }
        | PlaceholderEntryEditCompleted t -> { model with Placeholder = t }
        | StartDateSelected d -> { model with StartDate = d; EndDate = d + (model.EndDate - model.StartDate) }
        | EndDateSelected d -> { model with EndDate = d }
        | GridEditCompleted (i, j) -> model
        | ListViewSelectedItemChanged item -> model
        | ListViewGroupedSelectedItemChanged item -> model
        | PickerItemChanged i -> { model with PickedColorIndex = i }
        | FrameTapped -> { model with NumTaps= model.NumTaps + 1 }
        | FrameTapped2 -> { model with NumTaps2= model.NumTaps2 + 1 }
        | UpdateNewGridSize (n, status) -> 
            match status with 
            | GestureStatus.Running -> { model with NewGridSize = model.NewGridSize * n}
            | GestureStatus.Completed -> let sz = int (model.NewGridSize + 0.5) in { model with GridSize = sz; NewGridSize = float sz }
            | GestureStatus.Canceled -> { model with NewGridSize = double model.GridSize }
            | _ -> model
        | UpdateGridPortal (x,y) -> { model with GridPortal = (x,y) }
        // For NavigationPage
        | IsPresentedChanged b -> { model with IsPresented = b }
        | GoHomePage -> { model with PageStack = ["Home"]; IsPresented=false}
        | PopPage -> { model with PageStack = (match model.PageStack with [] | [_] -> model.PageStack | _ :: t -> t); IsPresented=false }
        | PushPage page -> { model with PageStack = page :: model.PageStack; IsPresented=false  }

    let pickerItems = 
        [ ("Aqua", Color.Aqua); ("Black", Color.Black);
          ("Blue", Color.Blue); ("Fucshia", Color.Fuchsia);
          ("Gray", Color.Gray); ("Green", Color.Green);
          ("Lime", Color.Lime); ("Maroon", Color.Maroon);
          ("Navy", Color.Navy); ("Olive", Color.Olive);
          ("Purple", Color.Purple); ("Red", Color.Red);
          ("Silver", Color.Silver); ("Teal", Color.Teal);
          ("White", Color.White); ("Yellow", Color.Yellow ) ]

    type Xaml with 
        static member ScrollingContentPage(title, children) =
            Xaml.ContentPage(title=title, content=Xaml.ScrollView(Xaml.StackLayout(padding=20.0,children=children)))
        static member NonScrollingContentPage(title, children, ?gestureRecognizers) =
            Xaml.ContentPage(title=title, content=Xaml.StackLayout(padding=20.0,children=children, ?gestureRecognizers=gestureRecognizers))

    let view (model: Model) dispatch =
      Xaml.TabbedPage 
       [ 
         dependsOn model.Count (fun model count -> 
          Xaml.ScrollingContentPage("Button", 
           [Xaml.Label(text="Label:")
            Xaml.Label(text= sprintf "%d" count, horizontalOptions=LayoutOptions.CenterAndExpand)
                
            Xaml.Label(text="Button:")
            Xaml.Button(text="Increment", command=(fun () -> dispatch Increment), horizontalOptions=LayoutOptions.CenterAndExpand)
                
            Xaml.Label(text="Button (cornerRadius=5):")
            Xaml.Button(text="Decrement", cornerRadius=5, command=(fun () -> dispatch Decrement), horizontalOptions=LayoutOptions.CenterAndExpand)
               
            Xaml.Label(text="Button (relative layout):")
            Xaml.Button(text="Decrement", cornerRadius=5, command=(fun () -> dispatch Decrement), horizontalOptions=LayoutOptions.CenterAndExpand)
               
           ]))


         dependsOn (model.CountForSlider, model.StepForSlider) (fun model (count, step) -> 
          Xaml.ScrollingContentPage("Slider", 
           [Xaml.Label(text="Label:")
            Xaml.Label(text= sprintf "%d" count, horizontalOptions=LayoutOptions.CenterAndExpand)

            Xaml.Label(text="Button:")
            Xaml.Button(text="Increment", command=(fun () -> dispatch IncrementForSlider), horizontalOptions=LayoutOptions.CenterAndExpand)
                
            Xaml.Label(text="Button:")
            Xaml.Button(text="Decrement", command=(fun () -> dispatch DecrementForSlider), horizontalOptions=LayoutOptions.CenterAndExpand)
                
            Xaml.Label(text="Slider:")
            Xaml.Slider(minimum=0.0, maximum=10.0, value= double step, 
                        valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), 
                            horizontalOptions=LayoutOptions.Fill) 
           ]))

         dependsOn model.CountForActivityIndicator (fun model count -> 
          Xaml.ScrollingContentPage("ActivityIndicator",
           [Xaml.Label(text="Label:")
            Xaml.Label(text= sprintf "%d" count, horizontalOptions=LayoutOptions.CenterAndExpand)

            Xaml.Label(text="ActivityIndicator (when count > 0):")
            Xaml.ActivityIndicator(isRunning=(count > 0), horizontalOptions=LayoutOptions.CenterAndExpand)
                
            Xaml.Label(text="Button:")
            Xaml.Button(text="Increment", command=(fun () -> dispatch IncrementForActivityIndicator), horizontalOptions=LayoutOptions.CenterAndExpand)

            Xaml.Label(text="Button:")
            Xaml.Button(text="Decrement", command=(fun () -> dispatch DecrementForActivityIndicator), horizontalOptions=LayoutOptions.CenterAndExpand)
                
          ]))

         dependsOn (model.StartDate, model.EndDate) (fun model (startDate, endDate) -> 
          Xaml.ScrollingContentPage("DatePicker",
           [Xaml.Label(text="DatePicker (start):")
            Xaml.DatePicker(minimumDate= System.DateTime.Today, maximumDate=DateTime.Today + TimeSpan.FromDays(365.0), 
                            date=startDate,
                            dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)), 
                            horizontalOptions=LayoutOptions.CenterAndExpand)

            Xaml.Label(text="DatePicker (end):")
            Xaml.DatePicker(minimumDate= startDate, maximumDate=startDate + TimeSpan.FromDays(365.0), 
                            date=endDate,
                            dateSelected=(fun args -> dispatch (EndDateSelected args.NewDate)), 
                            horizontalOptions=LayoutOptions.CenterAndExpand)
          ]))

         dependsOn model.EditorText (fun model editorText -> 
          Xaml.ScrollingContentPage("Editor",
           [Xaml.Label(text="Editor:")
            Xaml.Editor(text= editorText, horizontalOptions=LayoutOptions.CenterAndExpand, 
                        textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                        completed=(fun text -> dispatch (EditorEditCompleted text)))

          ]))

         dependsOn (model.EntryText, model.Password, model.Placeholder) (fun model (entryText, password, placeholder) -> 
          Xaml.ScrollingContentPage("Entry",
           [Xaml.Label(text="Entry:")
            Xaml.Entry(text= entryText, horizontalOptions=LayoutOptions.CenterAndExpand, 
                       textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                       completed=(fun text -> dispatch (EntryEditCompleted text)))

            Xaml.Label(text="Entry (password):")
            Xaml.Entry(text= password, isPassword=true, horizontalOptions=LayoutOptions.CenterAndExpand, 
                       textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                       completed=(fun text -> dispatch (PasswordEntryEditCompleted text)))

            Xaml.Label(text="Entry (placeholder):")
            Xaml.Entry(placeholder= placeholder, horizontalOptions=LayoutOptions.CenterAndExpand, 
                       textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                       completed=(fun text -> dispatch (PlaceholderEntryEditCompleted text)))

          ]))

         dependsOn (model.NumTaps, model.NumTaps2) (fun model (numTaps, numTaps2) -> 
          Xaml.ScrollingContentPage("Frame",
           [Xaml.Label(text="Frame (hasShadow=true):")
            Xaml.Frame(hasShadow=true, backgroundColor=Color.AliceBlue, horizontalOptions=LayoutOptions.CenterAndExpand)

            Xaml.Label(text="Frame (tap once gesture):")
            Xaml.Frame(hasShadow=true, backgroundColor=snd (pickerItems.[numTaps % pickerItems.Length]), horizontalOptions=LayoutOptions.CenterAndExpand,
                       gestureRecognizers=[ Xaml.TapGestureRecognizer(command=(fun () -> dispatch FrameTapped)) ] )

            Xaml.Label(text="Frame (tap twice gesture):")
            Xaml.Frame(hasShadow=true, backgroundColor=snd (pickerItems.[numTaps2 % pickerItems.Length]), horizontalOptions=LayoutOptions.CenterAndExpand,
                       gestureRecognizers=[ Xaml.TapGestureRecognizer(numberOfTapsRequired=2, command=(fun () -> dispatch FrameTapped2)) ] )

           ]))

         dependsOn () (fun model () -> 
          Xaml.NonScrollingContentPage("Grid",
           [Xaml.Label(text=sprintf "Grid (6x6, auto):")
            Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"], coldefs=[for i in 1 .. 6 -> box "auto"], 
                      children = [ for i in 1 .. 6 do for j in 1 .. 6 -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ] )
           ]))

         dependsOn () (fun model () -> 
          Xaml.NonScrollingContentPage("Grid",
           [Xaml.Label(text=sprintf "Grid (6x6, *):")
            Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "*"], coldefs=[for i in 1 .. 6 -> box "*"], 
                      children = [ for i in 1 .. 6 do for j in 1 .. 6 -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ] )
           ]))

         dependsOn (model.GridSize, model.NewGridSize) (fun model (gridSize, newGridSize) -> 
          Xaml.NonScrollingContentPage("Grid+Pinch",
           [Xaml.Label(text=sprintf "Grid (nxn, pinch, size = %f):" newGridSize)
            // The Grid doesn't change during the pinch...
            dependsOn gridSize (fun _ _ -> 
              Xaml.Grid(rowdefs= [for i in 1 .. gridSize -> box "*"], coldefs=[for i in 1 .. gridSize -> box "*"], 
                      children = 
                          [ for i in 1 .. gridSize do for j in 1 .. gridSize -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ]))
           ],
           gestureRecognizers=[ Xaml.PinchGestureRecognizer(pinchUpdated=(fun pinchArgs -> 
                                        dispatch (UpdateNewGridSize (pinchArgs.Scale, pinchArgs.Status)))) ] ))

         dependsOn model.GridPortal (fun model gridPortal -> 
          let dx, dy = gridPortal
          Xaml.NonScrollingContentPage("Grid+Pan",
           [Xaml.Label(text= sprintf "Grid (nxn, auto, edit entries, 1-touch pan, (%d, %d):" dx dy)
            Xaml.Grid(rowdefs= [for row in 1 .. 6 -> box "*"], coldefs=[for col in 1 .. 6 -> box "*"], 
                      children = [ for row in 1 .. 6 do 
                                     for col in 1 .. 6 ->
                                       let item = Xaml.Label(text=sprintf "(%d,%d)" (col+dx) (row+dy), backgroundColor=Color.White, textColor=Color.Black) 
                                       item.GridRow(row-1).GridColumn(col-1) ])
              ],
            gestureRecognizers=[ Xaml.PanGestureRecognizer(touchPoints=1,panUpdated=(fun panArgs -> 
                                    if panArgs.StatusType = GestureStatus.Running then 
                                        dispatch (UpdateGridPortal (dx - int (panArgs.TotalX/10.0), dy - int (panArgs.TotalY/10.0))))) ] ))

         dependsOn (model.PickedColorIndex) (fun model (pickedColorIndex) -> 
          Xaml.NonScrollingContentPage("Image", 
           [Xaml.Label(text="Image:")
            Xaml.Image(source="icon", horizontalOptions=LayoutOptions.CenterAndExpand) ]))

         dependsOn (model.PickedColorIndex) (fun model (pickedColorIndex) -> 
          Xaml.ScrollingContentPage("Picker",
           [Xaml.Label(text="Picker:")
            Xaml.Picker(title="Choose Color:", textColor= snd pickerItems.[pickedColorIndex], selectedIndex=pickedColorIndex, itemsSource=(List.map fst pickerItems), horizontalOptions=LayoutOptions.CenterAndExpand,selectedIndexChanged=(fun (i, item) -> dispatch (PickerItemChanged i)))
           ]))

         dependsOn () (fun model () -> 
          Xaml.ScrollingContentPage("ListView",
           [Xaml.Label(text="ListView:")
            Xaml.ListView(items = [ for i in 0 .. 10 do 
                                      yield Xaml.Label "Ionide"
                                      yield Xaml.Label "Visual Studio"
                                      yield Xaml.Label "Emacs"
                                      yield Xaml.Label "Visual Studio Code"
                                      yield Xaml.Label "Rider"], 
                          horizontalOptions=LayoutOptions.CenterAndExpand,
                          itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
           ]))

         dependsOn () (fun model () -> 
          Xaml.ScrollingContentPage("ListViewGrouped",
           [Xaml.Label(text="ListView (grouped):")
            Xaml.ListViewGrouped(items= 
                                    [ Xaml.Label "Europe", [ Xaml.Label "Russia"; Xaml.Label "Germany"; Xaml.Label "Poland"; Xaml.Label "Greece"   ]
                                      Xaml.Label "Asia", [ Xaml.Label "China"; Xaml.Label "Japan"; Xaml.Label "North Korea"; Xaml.Label "South Korea"   ]
                                      Xaml.Label "Australasia", [ Xaml.Label "Australia"; Xaml.Label "New Zealand"; Xaml.Label "Fiji" ] ], 
                            horizontalOptions=LayoutOptions.CenterAndExpand,
                            isGroupingEnabled=true,
                            itemSelected=(fun idx -> dispatch (ListViewGroupedSelectedItemChanged idx)))

              ]))

         dependsOn () (fun model () -> 
          Xaml.ScrollingContentPage("TableView",
           [Xaml.Label(text="TableView:")
            Xaml.TableView(items= [ ("Videos", [ Xaml.SwitchCell(on=true,text="Luca 2008",onChanged=(fun args -> ()) ) 
                                                 Xaml.SwitchCell(on=true,text="Don 2010",onChanged=(fun args -> ()) ) ] )
                                    ("Books", [ Xaml.SwitchCell(on=true,text="Expert F#",onChanged=(fun args -> ()) ) 
                                                Xaml.SwitchCell(on=false,text="Programming F#",onChanged=(fun args -> ()) ) ])
                                    ("Contact", [ Xaml.EntryCell(label="Email",placeholder="foo@bar.com",completed=(fun args -> ()) )
                                                  Xaml.EntryCell(label="Phone",placeholder="+44 87654321",completed=(fun args -> ()) )] )],
                            horizontalOptions=LayoutOptions.StartAndExpand) 
              ]))

         dependsOn model.Count (fun model count -> 
          Xaml.ContentPage(title="RelativeLayout", 
             padding = new Thickness (10.0, 20.0, 10.0, 5.0),
             content= Xaml.RelativeLayout(
                 children=[ 
                     Xaml.Label(text = "RelativeLayout Example",textColor = Color.Red)
                           .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
                     Xaml.Label(text = "Positioned relative to my parent",textColor = Color.Red)
                           .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                           .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
                 ])))


         dependsOn model.Count (fun model count -> 
          Xaml.ContentPage(title="AbsoluteLayout", 
             padding = new Thickness (10.0, 20.0, 10.0, 5.0),
             content= Xaml.StackLayout(
                 children=[ 
                    Xaml.Label(text = "AbsoluteLayout Demo", fontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>), horizontalOptions = LayoutOptions.Center)
                    Xaml.AbsoluteLayout(backgroundColor = Color.Blue.WithLuminosity(0.9), verticalOptions = LayoutOptions.FillAndExpand,
                      children = [
                         Xaml.Label(text = "Top Left", textColor = Color.Black)
                             .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                             .LayoutBounds(Rectangle(0.0, 0.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                         Xaml.Label(text = "Centered", textColor = Color.Black)
                             .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                             .LayoutBounds(Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                         Xaml.Label(text = "Bottom Right", textColor = Color.Black)
                             .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                             .LayoutBounds(Rectangle(1.0, 1.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)) ])
                 ])))
        ] 
(*
        // NavigationPage example
         dependsOn (model.IsPresented, model.PageStack) (fun model (isPresented, pageStack) -> 
           Xaml.NavigationPage(pages=
                     [ for page in List.rev pageStack do
                         match page with 
                         | "Home" -> 
                             yield 
                                 Xaml.ContentPage(
                                   Xaml.StackLayout(
                                    children=
                                      [Xaml.Label(text="Home Page", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                       Xaml.Button(text="Push Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "A")))
                                       Xaml.Button(text="Push Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "B")))
                                       ]) ).HasNavigationBar(true).HasBackButton(false)
                         | "A" -> 
                             yield 
                               Xaml.ContentPage(
                                Xaml.StackLayout(
                                 children=
                                  [Xaml.Label(text="Page A", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center)
                                   Xaml.Button(text="Page B", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "B")))
                                   Xaml.Button(text="Page C", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "C")))
                                   Xaml.Button(text="Replace by Page B", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch PopPage; dispatch (PushPage "B")))
                                   Xaml.Button(text="Replace by Page C", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch PopPage; dispatch (PushPage "C")))
                                   Xaml.Button(text="Back", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch PopPage))
                                   ]) ).HasNavigationBar(true).HasBackButton(true)
                         | "B" -> 
                             yield 
                               Xaml.ContentPage(
                                Xaml.StackLayout(
                                 children=
                                  [Xaml.Label(text="Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                   Xaml.Label(text="(nb. no back button in navbar)", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                   Xaml.Button(text="Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "A")))
                                   Xaml.Button(text="Page C", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "C")))
                                   Xaml.Button(text="Back", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch PopPage))
                                   ]) ).HasNavigationBar(true).HasBackButton(false)
                         | "C" -> 
                             yield 
                               Xaml.ContentPage(
                                Xaml.StackLayout(
                                 children=
                                  [Xaml.Label(text="Page C", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                   Xaml.Label(text="(nb. no navbar)", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                   Xaml.Button(text="Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "A")))
                                   Xaml.Button(text="Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch (PushPage "B")))
                                   Xaml.Button(text="Back", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center,command=(fun () -> dispatch PopPage))
                                   ]) ).HasNavigationBar(false).HasBackButton(false)

                         | _ -> failwith "unknown page" ] (* ,
                    popped=(fun args -> dispatch PopPage),
                    poppedToRoot=(fun args -> dispatch GoHomePage) *) ))
*)
(*
        // MasterDetail where the Master acts as a hamburger-style menu
         dependsOn (model.IsPresented, model.PageStack) (fun model (isPresented, pageStack) -> 
           Xaml.MasterDetailPage(
              masterBehavior=MasterBehavior.Popover, 
              isPresented=isPresented,
              isPresentedChanged=(fun b -> dispatch (IsPresentedChanged b)),
              master = 
                Xaml.ContentPage(title="Master", 
                 content = 
                   Xaml.StackLayout(backgroundColor=Color.Gray, 
                     children=[ Xaml.Button(text="Home", textColor=Color.White, backgroundColor=Color.Green, command=(fun () -> dispatch GoHomePage)) 
                                Xaml.Button(text="Page A", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (PushPage 1)))
                                Xaml.Button(text="Page B", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (PushPage 2)))]) ),
              detail = 
                 (Xaml.NavigationPage(pages=
                     [ yield Xaml.ContentPage(Xaml.Label(text="Home Page", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center) )
                       for page in List.rev pageStack do
                         match page with 
                         | 1 -> yield Xaml.ContentPage(Xaml.Label(text="Page A", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center) )
                         | _ -> yield Xaml.ContentPage(Xaml.Label(text="Page B", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center) )],
                    popped=(fun args -> dispatch PopPage),
                    poppedToRoot=(fun args -> dispatch GoHomePage))) ))

*)

type App () = 
    inherit Application ()

    let page = 
        Program.mkSimple App.init App.update App.view
        |> Program.withConsoleTrace
        |> Program.withDynamicView
        |> Program.run
    do PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(page.On<PlatformConfiguration.iOS>(), true) |> ignore

    do base.MainPage <- page
