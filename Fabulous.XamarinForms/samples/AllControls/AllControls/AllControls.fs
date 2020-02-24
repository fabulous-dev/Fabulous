// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace AllControls

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Maps
open FSharp.Data
open SkiaSharp
open SkiaSharp.Views.Forms
open OxyPlot
open OxyPlot.Axes
open OxyPlot.Series
open AllControls.Effects

type RootPageKind = 
    | Choice of bool
    | Tabbed1 
    | Tabbed2 
    | Tabbed3 
    | Navigation 
    | Carousel 
    | MasterDetail
    | InfiniteScrollList
    | Animations
    | WebCall
    | ScrollView
    | ShellView
    | CollectionView
    | CarouselView
    | Effects
    | RefreshView
    | SkiaCanvas
    | MapSamples
    | OxyPlotSamples
    | SwipeSample
    //| VideoSamples
    //| CachedImageSamples

type Model = 
  { RootPageKind: RootPageKind
    CountForSlider : int
    StepForSlider : int 
    MinimumForSlider : int
    MaximumForSlider : int
    PickedColorIndex: int
    // For MasterDetailPage demo
    IsMasterPresented: bool 
    DetailPage: string
    // For NavigationPage demo
    PageStack: string option list
    // For InfiniteScroll page demo. It's not really an "infinite" scroll, just an unbounded set of data whose growth is prompted by the need formore of it in the UI
    
    SearchTerm: string
    }

type Msg = 
    | SliderValueChanged of int
    | GridEditCompleted of int * int
    | PickerItemChanged of int
    | ListViewSelectedItemChanged of int option
    | ListViewGroupedSelectedItemChanged of (int * int) option
    // For NavigationPage demo
    | GoHomePage
    | PopPage 
    | PagePopped 
    | ReplacePage of string
    | PushPage of string
    | SetRootPageKind of RootPageKind
    // For MasterDetail page demo
    | IsMasterPresentedChanged of bool
    | SetDetailPage of string
    // For InfiniteScroll page demo. It's not really an "infinite" scroll, just a growing set of "data"
    
    | ExecuteSearch of string

[<AutoOpen>]
module MyExtension = 
    /// Test the extension API be making a 2nd wrapper for "Label":
    let TestLabelTextAttribKey = AttributeKey<_> "TestLabel_Text"
    let TestLabelFontFamilyAttribKey = AttributeKey<_> "TestLabel_FontFamily"

    type View with 

        static member TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) = 

            // Get the attributes for the base element. The number is the expected number of attributes.
            // You can add additional base element attributes here if you like
            let attribCount = 0
            let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount, ?backgroundColor = backgroundColor, ?rotation = rotation) 

            // Add our own attributes. They must have unique names.
            match text with None -> () | Some v -> attribs.Add(TestLabelTextAttribKey, v) 
            match fontFamily with None -> () | Some v -> attribs.Add(TestLabelFontFamilyAttribKey, v) 

            // The creation method
            let create () = new Xamarin.Forms.Label()

            // The incremental update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.Label) = 
                ViewBuilders.UpdateView(prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, TestLabelTextAttribKey, (fun target v -> target.Text <- v))
                source.UpdatePrimitive(prevOpt, target, TestLabelFontFamilyAttribKey, (fun target v -> target.FontFamily <- v))

            ViewElement.Create<Xamarin.Forms.Label>(create, update, attribs)

    // Test some adhoc functional abstractions
    type View with 
        static member ScrollingContentPage(title, children) =
            View.ContentPage(title=title, content=View.ScrollView(View.StackLayout(padding=Thickness 20.0, children=children) ), useSafeArea=true)

        static member NonScrollingContentPage(title, children, ?gestureRecognizers) =
            View.ContentPage(title=title, content=View.StackLayout(padding=Thickness 20.0, children=children, ?gestureRecognizers=gestureRecognizers), useSafeArea=true)


module App = 
    let init () = 
        { RootPageKind = Choice false
          PickedColorIndex = 0
          IsMasterPresented=false
          PageStack=[ Some "Home" ]
          DetailPage="A"
          SearchTerm = "nothing!"
          
          RefreshViewIsRefreshing = false
          SKPoints = [] }, Cmd.none

    let refreshAsync () =
        (async {
            do! Async.Sleep 2000
            return RefreshViewRefreshDone
        }) |> Cmd.ofAsyncMsg        
    
    let update msg model =
        match msg with
        | GridEditCompleted _ -> model, Cmd.none
        | ListViewSelectedItemChanged _ -> model, Cmd.none
        | ListViewGroupedSelectedItemChanged _ -> model, Cmd.none
        | PickerItemChanged i -> { model with PickedColorIndex = i }, Cmd.none
        // For NavigationPage
        | GoHomePage -> { model with PageStack = [ Some "Home" ] }, Cmd.none
        | PagePopped -> 
            if model.PageStack |> List.exists Option.isNone then 
               { model with PageStack = model.PageStack |> List.filter Option.isSome }, Cmd.none
            else
               { model with PageStack = (match model.PageStack with [] -> model.PageStack | _ :: t -> t) }, Cmd.none
        | PopPage -> 
               { model with PageStack = (match model.PageStack with [] -> model.PageStack | _ :: t -> None :: t) }, Cmd.none
        | PushPage page -> 
            { model with PageStack = Some page :: model.PageStack}, Cmd.none
        | ReplacePage page -> 
            { model with PageStack = (match model.PageStack with [] -> Some page :: model.PageStack | _ :: t -> Some page :: t) }, Cmd.none
        // For MasterDetail
        | IsMasterPresentedChanged b -> { model with IsMasterPresented = b }, Cmd.none
        | SetDetailPage s -> { model with DetailPage = s ; IsMasterPresented=false}, Cmd.none
        
        // For selection page
        | SetRootPageKind kind -> { model with RootPageKind = kind }, Cmd.none
        | ExecuteSearch search -> { model with SearchTerm = search }, Cmd.none
        // For pop-ups
        
        
        | ReceivedLowMemoryWarning ->
            Application.Current.MainPage.DisplayAlert("Low memory!", "Cleaning up data...", "OK") |> ignore
            { model with
                EditorText = ""
                EntryText = ""
                Placeholder = ""
                Password = ""
                SearchTerm = "" }, Cmd.none
        // For RefreshView
        | RefreshViewRefreshing ->
            { model with RefreshViewIsRefreshing = true }, refreshAsync ()
        | RefreshViewRefreshDone ->
            { model with RefreshViewIsRefreshing = false }, Cmd.none
        | SKSurfaceTouched point -> { model with SKPoints = point :: model.SKPoints }, Cmd.none

    let frontPage model showAbout dispatch =
        View.NavigationPage(pages=
            [ yield 
                View.ContentPage(
                    View.ScrollView(
                        View.StackLayout(
                            children = [ 
                                    View.Button(text = "TabbedPage #1 (various controls)", command=(fun () -> dispatch (SetRootPageKind Tabbed1)))
                                    View.Button(text = "TabbedPage #2 (various controls)", command=(fun () -> dispatch (SetRootPageKind Tabbed2)))
                                    View.Button(text = "TabbedPage #3 (various controls)", command=(fun () -> dispatch (SetRootPageKind Tabbed3)))
                                    View.Button(text = "CarouselPage (various controls)", command=(fun () -> dispatch (SetRootPageKind Carousel)))
                                    View.Button(text = "NavigationPage with push/pop", command=(fun () -> dispatch (SetRootPageKind Navigation)))
                                    View.Button(text = "MasterDetail Page", command=(fun () -> dispatch (SetRootPageKind MasterDetail)))
                                    View.Button(text = "Infinite scrolling ListView", command=(fun () -> dispatch (SetRootPageKind InfiniteScrollList)))
                                    View.Button(text = "Animations", command=(fun () -> dispatch (SetRootPageKind Animations)))
                                    View.Button(text = "WebRequest", command=(fun () -> dispatch (SetRootPageKind WebCall)))
                                    View.Button(text = "ScrollView", command=(fun () -> dispatch (SetRootPageKind ScrollView)))
                                    View.Button(text = "Shell", command=(fun () -> dispatch (SetRootPageKind ShellView)))
                                    View.Button(text = "CollectionView", command=(fun () -> dispatch (SetRootPageKind CollectionView)))
                                    View.Button(text = "CarouselView", command=(fun () -> dispatch (SetRootPageKind CarouselView)))
                                    View.Button(text = "Effects", command=(fun () -> dispatch (SetRootPageKind Effects)))
                                    View.Button(text = "RefreshView", command=(fun () -> dispatch (SetRootPageKind RefreshView)))
                                    View.Button(text = "Skia Canvas", command = (fun () -> dispatch (SetRootPageKind SkiaCanvas)))
                                    View.Button(text = "Map Samples", command = (fun () -> dispatch (SetRootPageKind MapSamples)))
                                    View.Button(text = "OxyPlot Samples", command = (fun () -> dispatch (SetRootPageKind OxyPlotSamples)))
                                    View.Button(text = "SwipeView Samples", command = (fun () -> dispatch (SetRootPageKind SwipeSample)))
                                    //View.Button(text = "VideoManager Samples", command = (fun () -> dispatch (SetRootPageKind VideoSamples)))
                                    //View.Button(text = "CachedImage Samples", command = (fun () -> dispatch (SetRootPageKind CachedImageSamples)))
                            ])),
                    useSafeArea=true,
                    padding = Thickness (10.0, 20.0, 10.0, 5.0)
                )
                .ToolbarItems([View.ToolbarItem(text="about", command=(fun () -> dispatch (SetRootPageKind (Choice true))))] )
                .TitleView(
                    View.StackLayout(
                        [
                            View.Label(text="fabulous", verticalOptions=LayoutOptions.Center)
                            View.Label(text="rootpage", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.CenterAndExpand)
                        ],
                        orientation=StackOrientation.Horizontal
                    ))

              if showAbout then 
                yield 
                    View.ContentPage(title="About", useSafeArea=true, 
                        padding = Thickness (10.0, 20.0, 10.0, 5.0), 
                        content= View.StackLayout(
                            children=[ 
                                View.TestLabel(text = "Fabulous, version " + string (typeof<ViewElement>.Assembly.GetName().Version))
                                View.Label(text = "Now with CSS styling", styleClasses = [ "cssCallout" ])
                                View.Button(text = "Continue", command=(fun () -> dispatch (SetRootPageKind (Choice false)) ))
                            ]))
            ])
    

    let mainPageButton dispatch = 
        View.Button(text="Main page", 
                    command=(fun () -> dispatch (SetRootPageKind (Choice false))), 
                    horizontalOptions=LayoutOptions.CenterAndExpand)

    

    

    let tabbedPageSamples2 model dispatch =
        View.TabbedPage(useSafeArea=true, 
          children= [
            dependsOn (model.PickedColorIndex) (fun model (pickedColorIndex) -> 
                View.ScrollingContentPage("Picker", 
                    [ View.Label(text="Picker:")
                      View.Picker(title="Choose Color:", textColor=snd pickerItems.[pickedColorIndex], selectedIndex=pickedColorIndex, items=(List.map fst pickerItems), horizontalOptions=LayoutOptions.CenterAndExpand, selectedIndexChanged=(fun (i, item) -> dispatch (PickerItemChanged i)))
                      mainPageButton dispatch
                    ]))
                      
            dependsOn () (fun model () -> 
                View.ScrollingContentPage("ListView", 
                    [ mainPageButton dispatch
                      View.Label(text="ListView:")
                      View.ListView( 
                          items = [ 
                            for i in 0 .. 10 do 
                                yield View.TextCell "Ionide"
                                yield View.ViewCell(
                                    view = View.Label(
                                        formattedText = View.FormattedString(
                                          [
                                            View.Span(text="Visual ", backgroundColor = Color.Green)
                                            View.Span(text="Studio ", fontSize = FontSize 10.)
                                          ])
                                    )
                                ) 
                                yield View.TextCell "Emacs"
                                yield View.ViewCell(
                                    view = View.Label(
                                        formattedText = View.FormattedString(
                                          [
                                            View.Span(text="Visual ", fontAttributes=FontAttributes.Bold)
                                            View.Span(text="Studio ", fontAttributes=FontAttributes.Italic)
                                            View.Span(text="Code", foregroundColor = Color.Blue)
                                          ])
                                    )
                                )
                                yield View.TextCell "Rider" ], 
                        horizontalOptions=LayoutOptions.CenterAndExpand, 
                        itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
            ]))

                      
            dependsOn (model.SearchTerm) (fun model (searchTerm) -> 
                View.ScrollingContentPage("SearchBar", 
                    [ View.Label(text="SearchBar:")
                      View.SearchBar(
                        placeholder = "Enter search term",
                        searchCommand = (fun searchBarText -> dispatch (ExecuteSearch searchBarText)),
                        searchCommandCanExecute = true) 
                      View.Label(text="You searched for " + searchTerm) 
                      mainPageButton dispatch ]))

            dependsOn () (fun model () -> 
                View.NonScrollingContentPage("ListViewGrouped", 
                    [ View.Label(text="ListView (grouped):")
                      View.ListViewGrouped(
                            showJumpList=true,
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
                            horizontalOptions=LayoutOptions.CenterAndExpand,
                            itemSelected=(fun idx -> dispatch (ListViewGroupedSelectedItemChanged idx)))
                      mainPageButton dispatch
                ]))

            ])

    let tabbedPageSamples3 model dispatch =
        View.TabbedPage(useSafeArea=true, 
            children=
             [ 
               dependsOn model.Count (fun model count -> 
                   View.ContentPage(title="FlexLayout", useSafeArea=true,
                       padding = Thickness (10.0, 20.0, 10.0, 5.0), 
                       content= 
                           View.FlexLayout(
                            direction = FlexDirection.Column,
                            children = [
                                View.ScrollView(
                                  View.FlexLayout(
                                      children = [
                                          View.Frame(height=480.0, width=300.0, 
                                              content = View.FlexLayout( direction=FlexDirection.Column,
                                                  children = [ 
                                                      View.Label(text="Seated Monkey", margin=Thickness (0.0, 8.0), fontSize=Named NamedSize.Large, textColor=Color.Blue)
                                                      View.Label(text="This monkey is laid back and relaxed, and likes to watch the world go by.", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Label(text="  • Often smiles mysteriously", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Label(text="  • Sleeps sitting up", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Image(height=240.0, 
                                                          width=160.0, 
                                                          source=Path "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg/160px-Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg"
                                                      ).Order(-1).AlignSelf(FlexAlignSelf.Center)
                                                      View.Label(margin=Thickness (0.0, 4.0)).Grow(1.0)
                                                      View.Button(text="Learn More", fontSize=Named NamedSize.Large, textColor=Color.White, backgroundColor=Color.Green, cornerRadius=20) ]),
                                              backgroundColor=Color.LightYellow,
                                              borderColor=Color.Blue,
                                              margin=Thickness 10.0,
                                              cornerRadius=15.0)
                                          View.Frame(height=480.0, width=300.0, 
                                              content = View.FlexLayout( direction=FlexDirection.Column,
                                                  children = [ 
                                                      View.Label(text="Banana Monkey", margin=Thickness (0.0, 8.0), fontSize=Named NamedSize.Large, textColor=Color.Blue)
                                                      View.Label(text="Watch this monkey eat a giant banana.", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Label(text="  • More fun than a barrel of monkeys", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Label(text="  • Banana not included", margin=Thickness (0.0, 4.0), textColor=Color.Black)
                                                      View.Image(height=213.0, 
                                                          width=320.0, 
                                                          source=Path "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Crab_eating_macaque_in_Ubud_with_banana.JPG/320px-Crab_eating_macaque_in_Ubud_with_banana.JPG"
                                                      ).Order(-1).AlignSelf(FlexAlignSelf.Center)
                                                      View.Label(margin=Thickness (0.0, 4.0)).Grow(1.0)
                                                      View.Button(text="Learn More", fontSize=Named NamedSize.Large, textColor=Color.White, backgroundColor=Color.Green, cornerRadius=20) ]),
                                              backgroundColor=Color.LightYellow,
                                              borderColor=Color.Blue,
                                              margin=Thickness 10.0,
                                              cornerRadius=15.0)

                                      ] ),
                                  orientation=ScrollOrientation.Both)
                                mainPageButton dispatch
                            ])) )

               dependsOn () (fun model () -> 
                View.ScrollingContentPage("TableView", 
                 [View.Label(text="TableView:")
                  View.TableView(
                    horizontalOptions = LayoutOptions.StartAndExpand,
                    root = View.TableRoot(
                        items = [
                            View.TableSection(
                                title = "Videos",
                                items = [
                                    View.SwitchCell(on=true, text="Luca 2008", onChanged=(fun args -> ()) ) 
                                    View.SwitchCell(on=true, text="Don 2010", onChanged=(fun args -> ()) )
                                ]
                            )
                            View.TableSection(
                                title = "Books",
                                items = [
                                    View.SwitchCell(on=true, text="Expert F#", onChanged=(fun args -> ()) ) 
                                    View.SwitchCell(on=false, text="Programming F#", onChanged=(fun args -> ()) )
                                ]
                            )
                            View.TableSection(
                                title = "Contact",
                                items = [
                                    View.EntryCell(label="Email", placeholder="foo@bar.com", completed=(fun args -> ()) )
                                    View.EntryCell(label="Phone", placeholder="+44 87654321", completed=(fun args -> ()) )
                                ]
                            )
                        ]
                    )
                  )
                  mainPageButton dispatch
                    ]))

               dependsOn model.Count (fun model count -> 
                 View.ContentPage(title="RelativeLayout", 
                  padding = Thickness (10.0, 20.0, 10.0, 5.0), 
                  content= View.RelativeLayout(
                      children=[ 
                          View.Label(text = "RelativeLayout Example", textColor = Color.Red)
                                .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
                          View.Label(text = "Positioned relative to my parent", textColor = Color.Red)
                                .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                                .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
                          (mainPageButton dispatch)
                                .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 2.0))
                      ])))


               dependsOn model.Count (fun model count -> 
                   View.ContentPage(title="AbsoluteLayout", useSafeArea=true,
                       padding = Thickness (10.0, 20.0, 10.0, 5.0), 
                       content= View.StackLayout(
                           children=[ 
                               View.Label(text = "AbsoluteLayout Demo", fontSize = Named NamedSize.Large, horizontalOptions = LayoutOptions.Center)
                               View.AbsoluteLayout(backgroundColor = Color.Blue.WithLuminosity(0.9), 
                                   verticalOptions = LayoutOptions.FillAndExpand, 
                                   children = [
                                      View.Label(text = "Top Left", textColor = Color.Black)
                                          .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                                          .LayoutBounds(Rectangle(0.0, 0.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                                      View.Label(text = "Centered", textColor = Color.Black)
                                          .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                                          .LayoutBounds(Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                                      View.Label(text = "Bottom Right", textColor = Color.Black)
                                          .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                                          .LayoutBounds(Rectangle(1.0, 1.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)) ])
                               mainPageButton dispatch
                            ])))

                ])

    let navigationPageSample model dispatch =

         // NavigationPage example
           dependsOn model.PageStack (fun model pageStack -> 
              View.NavigationPage(pages=
                      [ for page in List.rev pageStack do
                          match page with 
                          | Some "Home" -> 
                              yield 
                                  View.ContentPage(useSafeArea=true,
                                    content=View.StackLayout(
                                     children=
                                       [ View.Label(text="Home Page", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                         View.Button(text="Push Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "A")))
                                         View.Button(text="Push Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "B")))
                
                                         View.Button(text="Main page", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (SetRootPageKind (Choice false))), horizontalOptions=LayoutOptions.CenterAndExpand, verticalOptions=LayoutOptions.End)
                                        ]) ).HasNavigationBar(true).HasBackButton(false)
                          | Some "A" -> 
                              yield 
                                View.ContentPage(useSafeArea=true,
                                    content=
                                     View.StackLayout(
                                      children=
                                       [View.Label(text="Page A", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center)
                                        View.Button(text="Page B", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "B")))
                                        View.Button(text="Page C", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "C")))
                                        View.Button(text="Replace by Page B", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (ReplacePage "B")))
                                        View.Button(text="Replace by Page C", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (ReplacePage "C")))
                                        View.Button(text="Back", verticalOptions=LayoutOptions.Center, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch PopPage ))
                                        ]) ).HasNavigationBar(true).HasBackButton(true)
                          | Some "B" -> 
                              yield 
                                View.ContentPage(useSafeArea=true,
                                    content=View.StackLayout(
                                         children=
                                             [View.Label(text="Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                              View.Label(text="(nb. no back button in navbar)", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                              View.Button(text="Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "A")))
                                              View.Button(text="Page C", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "C")))
                                              View.Button(text="Back", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch PopPage ))
                                             ]) ).HasNavigationBar(true).HasBackButton(false)
                          | Some "C" -> 
                              yield 
                                View.ContentPage(useSafeArea=true,
                                    content=View.StackLayout(
                                      children=
                                       [View.Label(text="Page C", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                        View.Label(text="(nb. no navbar)", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center)
                                        View.Button(text="Page A", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "A")))
                                        View.Button(text="Page B", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch (PushPage "B")))
                                        View.Button(text="Back", verticalOptions=LayoutOptions.CenterAndExpand, horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch PopPage ))
                                        mainPageButton dispatch
                                        ]) ).HasNavigationBar(false).HasBackButton(false)

                          | _ -> 
                               ()  ], 
                     popped=(fun args -> dispatch PagePopped) , 
                     poppedToRoot=(fun args -> dispatch GoHomePage)  ))

    

    let masterDetailPageSample model dispatch =
         // MasterDetail where the Master acts as a hamburger-style menu
          dependsOn (model.DetailPage, model.IsMasterPresented) (fun model (detailPage, isMasterPresented) -> 
            View.MasterDetailPage(
               masterBehavior=MasterBehavior.Popover, 
               isPresented=isMasterPresented, 
               isPresentedChanged=(fun b -> dispatch (IsMasterPresentedChanged b)), 
               master = 
                 View.ContentPage(useSafeArea=true, title="Master", 
                  content = 
                    View.StackLayout(backgroundColor=Color.Gray, 
                      children=[ View.Button(text="Detail A", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (SetDetailPage "A")))
                                 View.Button(text="Detail B", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (SetDetailPage "B")))
                                 View.Button(text="Main page", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (SetRootPageKind (Choice false))), horizontalOptions=LayoutOptions.CenterAndExpand, verticalOptions=LayoutOptions.End) 
                               ]) ), 
               detail = 
                 View.NavigationPage( 
                   pages=[
                     View.ContentPage(title="Detail", useSafeArea=true,
                      content = 
                        View.StackLayout(backgroundColor=Color.Gray, 
                          children=[ View.Label(text="Detail " + detailPage, textColor=Color.White, backgroundColor=Color.Navy)
                                     View.Button(text="Main page", textColor=Color.White, backgroundColor=Color.Navy, command=(fun () -> dispatch (SetRootPageKind (Choice false))), horizontalOptions=LayoutOptions.CenterAndExpand, verticalOptions=LayoutOptions.End)  ]) 
                          ).HasNavigationBar(true).HasBackButton(true) ], 
                   poppedToRoot=(fun args -> dispatch (IsMasterPresentedChanged true) ) ) ) )

    

    

    let shellViewSample model dispatch =
            
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 

            View.Shell( title = "TitleShell", 
              items = [
                View.ShellItem(
                  items = [
                    View.ShellSection(
                      items = [
                        View.ShellContent(content=View.ContentPage(content=mainPageButton dispatch, title="ContentpageTitle"))         
                      ])
                  ])
              ])
        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    mainPageButton dispatch
                    View.Label(text="Your Platform does not support Shell")
                  ])

    //let chachedImageSamplesActual model dispatch =
    //    View.ScrollingContentPage("CachedImage Sample", 
    //      [ 
    //        View.Label "Note, when last checked this did not work on Android"
    //        View.Label "However maybe the sample is not configured correctly"
    //        mainPageButton dispatch
    //        View.CachedImage(
    //            source = Path "http://loremflickr.com/600/600/nature?filename=simple.jpg",
    //            //loadingPlaceholder = Path "path/to/loading-placeholder.png",
    //            //errorPlaceholder = Path "path/to/error-placeholder.png",
    //            height = 600.,
    //            width = 600. ) 
    //      ])

    //let chachedImageSamples model dispatch =
        //match Device.RuntimePlatform with
        //| Device.Android  | Device.iOS  | Device.Tizen | Device.UWP | Device.macOS -> 
        //    chachedImageSamplesActual model dispatch
        //| _ -> 
            //View.ContentPage( 
                //View.StackLayout [
                  //  mainPageButton dispatch
                  //  View.Label(text="Theis version of FFImageLoading for XamarinForms does not support your platform")
                  //  View.Label(text="For status see https://github.com/luberda-molinet/FFImageLoading")
                  //])

    let view (model: Model) dispatch =

        match model.RootPageKind with 
        | Choice showAbout ->  frontPage model showAbout dispatch
        | Carousel -> carouselPageSample model dispatch
        | Tabbed2 -> tabbedPageSamples2 model dispatch
        | Tabbed3 -> tabbedPageSamples3 model dispatch
        | Navigation -> navigationPageSample model dispatch
        | MasterDetail -> masterDetailPageSample model dispatch
        | ShellView -> shellViewSample model dispatch
        //| CachedImageSamples -> chachedImageSamples model dispatch

    
type App () as app = 
    inherit Application ()
    do app.Resources.Add(Xamarin.Forms.StyleSheets.StyleSheet.FromAssemblyResource(System.Reflection.Assembly.GetExecutingAssembly(), "AllControls.styles.css"))
    
    let runner = 
        Program.mkProgram App.init App.update App.view
        |> Program.withConsoleTrace
        |> XamarinFormsProgram.run app

    member __.Program = runner
