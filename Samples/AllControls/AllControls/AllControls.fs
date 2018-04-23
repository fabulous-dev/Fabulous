// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace AllControls

open System
open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

type Model = 
  { Count : int
    Step : int 
    PickedColorIndex: int }

type Msg = 
    | Increment 
    | Decrement 
    | Reset
    | SliderValueChanged of int
    | TextChanged of string * string
    | EditorEditCompleted 
    | EntryEditCompleted 
    | GridEditCompleted of int * int
    | DateSelected of DateTime * DateTime
    | PickerItemChanged of int
    | ListViewSelectedItemChanged of string option

type AllControls () = 
    inherit Application ()

    let init () = { Count = 0; Step = 3; PickedColorIndex = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }
        | Decrement -> { model with Count = model.Count - model.Step }
        | Reset -> init ()
        | SliderValueChanged n -> { model with Step = n }
        | TextChanged (oldValue, newValue) -> model
        | EditorEditCompleted -> model
        | EntryEditCompleted  -> model
        | DateSelected (oldValue, newValue) -> model
        | GridEditCompleted (i, j) -> model
        | ListViewSelectedItemChanged item -> model
        | PickerItemChanged i -> { model with PickedColorIndex = i }

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
      Xaml.ContentPage(
        Xaml.ScrollView(
           Xaml.StackLayout(padding=20.0,
              children=[
                Xaml.Label(text="Label:")
                Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.CenterAndExpand)

                Xaml.Label(text="ActivityIndicator (when count > 5):")
                Xaml.ActivityIndicator(isRunning=(model.Count > 5), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button:")
                Xaml.Button(text="Increment", command= (fun () -> dispatch Increment), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Button (cornerRadius=3):")
                Xaml.Button(text="Decrement", cornerRadius=3, command= (fun () -> dispatch Decrement), horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Slider:")
                Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, 
                            valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), 
                            horizontalOptions=LayoutOptions.Fill)

                Xaml.Label(text="DatePicker:")
                Xaml.DatePicker(minimumDate= System.DateTime.Now, maximumDate=DateTime.Now + TimeSpan.FromDays(365.0), 
                                dateSelected=(fun args -> dispatch (DateSelected (args.OldDate, args.NewDate))), 
                                horizontalOptions=LayoutOptions.CenterAndExpand)
                
                Xaml.Label(text="Editor:")
                Xaml.Editor(text= "Hic haec hoc", horizontalOptions=LayoutOptions.CenterAndExpand, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EditorEditCompleted))

                Xaml.Label(text="Entry:")
                Xaml.Entry(text= "the initial entru=y", horizontalOptions=LayoutOptions.CenterAndExpand, 
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

                Xaml.Label(text="Frame (hasShadow=true):")
                Xaml.Frame(hasShadow=true, backgroundColor=Color.AliceBlue, horizontalOptions=LayoutOptions.CenterAndExpand)


                Xaml.Label(text="Grid (6x6, auto):")
                Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"], coldefs=[for i in 1 .. 6 -> box "auto"], 
                          children = [ for i in 1 .. 6 do for j in 1 .. 6 -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).GridRow(i-1).GridColumn(j-1) ])

                Xaml.Label(text="Grid (6x6, auto, edit diagonal):")
                Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"], coldefs=[for i in 1 .. 6 -> box "auto"], 
                          children = [ for i in 1 .. 6 do 
                                         for j in 1 .. 6 ->
                                           let item = 
                                               if i = j then Xaml.Entry(text=sprintf "%d" i, backgroundColor=Color.White, textColor=Color.Black) 
                                               else Xaml.BoxView(Color.White)
                                           item.GridRow(i-1).GridColumn(j-1) ])

                //Xaml.Label(text="Image:")
                //Xaml.Image(source="icon")

                // Xaml.AbsoluteLayout: TODO
                // Xaml.Accelerator: TODO
                // Xaml.Animation: TODO
                // Xaml.AppLinkEntry: TODO
                // Xaml.BoxView: TODO
                // Xaml.Cell, EntryCell: TODO
                // Xaml.CarouselPage: TODO
                // Xaml.MasterDetailPage: TODO
                // Xaml.Menu: TODO
                // Xaml.MenuItem: TODO
                // Xaml.MessagingCenter: TODO
                // Xaml.MultiPage<T>: TODO
                // Xaml.NavigationMenu: TODO
                // Xaml.NavigationPage: TODO
                // Xaml.OpenGLView: TODO
                // Xaml.PanGestureRecognizer and others: TODO
                // TODO: fix slider where minimum = 1.0 (gets set before maximum..)

                Xaml.Label(text="Picker:")
                Xaml.Picker(title="Choose Color:", textColor= snd pickerItems.[model.PickedColorIndex], selectedIndex=model.PickedColorIndex, itemsSource=(List.map fst pickerItems), horizontalOptions=LayoutOptions.CenterAndExpand,selectedIndexChanged=(fun (i, item) -> dispatch (PickerItemChanged i)))

                // Xaml.ListView - TODO - consider templating and itemsSource
                // "A little more on collections: I think ListView should just have an immutable list of Cell-typed Items instead of ItemsSource/DataTemplate. If that list is in the model, then the diff I described above can be used and you can do smooth updates when the data changes. This was yet another feature I didn't get to."
                // https://github.com/praeclarum/ImmutableUI/issues/4#issuecomment-382498256
                Xaml.Label(text="ListView:")
                Xaml.ListView(itemsSource= ["Ionide"; "Visual Studio"; "Emacs"; "Visual Studio Code"; "Rider"], horizontalOptions=LayoutOptions.CenterAndExpand,
                              itemSelected=(fun item -> dispatch (ListViewSelectedItemChanged item)))

              ])))

    do
        let page = 
            Program.mkSimple init update view
            |> Program.withConsoleTrace
            |> Program.withDynamicView
            |> Program.run

        base.MainPage <- page
