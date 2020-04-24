namespace AllControls.Samples.Pages

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module TabbedPage2 =
    type Msg =
        | PickerItemChanged of int
        | ListViewSelectedItemChanged of int option
        | ListViewGroupedSelectedItemChanged of (int * int) option
        | ExecuteSearch of string
        
    type CmdMsg = Nothing
    
    type Model =
        { PickedColorIndex: int
          SearchTerm: string }
        
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
        { PickedColorIndex = 0
          SearchTerm = "nothing!" }
        
    let update msg model =
        match msg with
        | PickerItemChanged i -> { model with PickedColorIndex = i }, []
        | ListViewSelectedItemChanged _ -> model, []
        | ListViewGroupedSelectedItemChanged _ -> model, []
        | ExecuteSearch search -> { model with SearchTerm = search }, []
        
    let tab1View pickedColorIndex dispatch =
        View.ScrollingContentPage(
            title = "Picker",
            content = View.StackLayout([
                View.Label(text = "Picker:")
                View.Picker(
                    title = "Choose Color:",
                    textColor = snd pickerItems.[pickedColorIndex],
                    selectedIndex = pickedColorIndex,
                    items = (List.map fst pickerItems),
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    selectedIndexChanged = fun (i, _) -> dispatch (PickerItemChanged i)
                )
            ])
        )
        
    let tab2View dispatch =
        View.ScrollingContentPage(
            title = "ListView",
            content = View.StackLayout([
                View.Label(text = "ListView:")
                View.ListView( 
                    items = [ 
                        for _ in 0 .. 10 do 
                            yield View.TextCell "Ionide"
                            yield View.ViewCell(
                                view = View.Label(
                                    formattedText = View.FormattedString([
                                        View.Span(
                                            text = "Visual ",
                                            backgroundColor = Color.Green
                                        )
                                        View.Span(
                                            text = "Studio ",
                                            fontSize = FontSize 10.
                                        )
                                    ])
                                )
                            ) 
                            yield View.TextCell "Emacs"
                            yield View.ViewCell(
                                view = View.Label(
                                    formattedText = View.FormattedString([
                                        View.Span(
                                            text = "Visual ",
                                            fontAttributes = FontAttributes.Bold
                                        )
                                        View.Span(
                                            text = "Studio ",
                                            fontAttributes = FontAttributes.Italic
                                        )
                                        View.Span(
                                            text = "Code",
                                            textColor = Color.Blue
                                        )
                                    ])
                                )
                            )
                            yield View.TextCell "Rider"
                    ], 
                    horizontalOptions = LayoutOptions.CenterAndExpand, 
                    itemSelected = fun idx -> dispatch (ListViewSelectedItemChanged idx)
                )
            ])
        )
        
    let tab3View searchTerm dispatch =
        View.ScrollingContentPage(
            title = "SearchBar",
            content = View.StackLayout([
                View.Label(text = "SearchBar:")
                View.SearchBar(
                    placeholder = "Enter search term",
                    searchCommand = (fun searchBarText -> dispatch (ExecuteSearch searchBarText)),
                    searchCommandCanExecute = true
                ) 
                View.Label(text = "You searched for " + searchTerm)
            ])
        )
        
    let tab4View dispatch =
        View.NonScrollingContentPage(
            title = "ListViewGrouped",
            content = View.StackLayout([
                View.Label(text = "ListView (grouped):")
                View.ListViewGrouped(
                    showJumpList = true,
                    items= [ 
                        "B", View.TextCell "B", [ View.TextCell "Baboon"; View.TextCell "Blue Monkey" ]
                        "C", View.TextCell "C", [ View.TextCell "Capuchin Monkey"; View.TextCell "Common Marmoset" ]
                        "G", View.TextCell "G", [ View.TextCell "Gibbon"; View.TextCell "Golden Lion Tamarin" ]
                        "H", View.TextCell "H", [ View.TextCell "Howler Monkey" ]
                        "J", View.TextCell "J", [ View.TextCell "Japanese Macaque" ]
                        "M", View.TextCell "M", [ View.TextCell "Mandrill" ]
                        "P", View.TextCell "P", [ View.TextCell "Proboscis Monkey"; View.TextCell "Pygmy Marmoset" ]
                        "R", View.TextCell "R", [ View.TextCell "Rhesus Macaque" ]
                        "S", View.TextCell "S", [ View.TextCell "Spider Monkey"; View.TextCell "Squirrel Monkey" ]
                        "V", View.TextCell "V", [ View.TextCell "Vervet Monkey" ]
                    ], 
                    horizontalOptions = LayoutOptions.CenterAndExpand,
                    itemSelected = fun idx -> dispatch (ListViewGroupedSelectedItemChanged idx)
                )
            ])
        )
    
    let view model dispatch =
        View.TabbedPage(
            useSafeArea = true, 
            children = [
                dependsOn (model.PickedColorIndex) (fun model (pickedColorIndex) ->
                    tab1View pickedColorIndex dispatch
                )
                      
                dependsOn () (fun model () ->
                    tab2View dispatch
                )
     
                dependsOn (model.SearchTerm) (fun model (searchTerm) ->
                    tab3View searchTerm dispatch
                )

                dependsOn () (fun model () ->
                    tab4View dispatch
                )
            ]
        )

