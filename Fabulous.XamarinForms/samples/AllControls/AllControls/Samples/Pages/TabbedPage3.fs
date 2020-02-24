namespace AllControls.Samples.Pages

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module TabbedPage3 =
    let tab1View () =
        View.ContentPage(
            title = "FlexLayout",
            useSafeArea = true,
            padding = Thickness (10.0, 20.0, 10.0, 5.0), 
            content = View.FlexLayout(
                direction = FlexDirection.Column,
                children = [
                    View.ScrollView(
                        View.FlexLayout(
                            children = [
                                View.Frame(
                                    height = 480.0,
                                    width = 300.0, 
                                    content = View.FlexLayout(
                                        direction = FlexDirection.Column,
                                        children = [ 
                                            View.Label(
                                                text = "Seated Monkey",
                                                margin = Thickness (0.0, 8.0),
                                                fontSize = Named NamedSize.Large,
                                                textColor = Color.Blue
                                            )
                                            View.Label(
                                                text = "This monkey is laid back and relaxed, and likes to watch the world go by.",
                                                margin = Thickness (0.0, 4.0),
                                                textColor = Color.Black
                                            )
                                            View.Label(
                                                text = "  • Often smiles mysteriously",
                                                margin = Thickness (0.0, 4.0),
                                                textColor = Color.Black
                                            )
                                            View.Label(
                                                text = "  • Sleeps sitting up",
                                                margin = Thickness (0.0, 4.0), textColor=Color.Black
                                            )
                                            View.Image(
                                                height = 240.0, 
                                                width = 160.0, 
                                                source = Path "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg/160px-Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg"
                                            ).Order(-1)
                                             .AlignSelf(FlexAlignSelf.Center)
                                            
                                            View.Label(margin = Thickness (0.0, 4.0)).Grow(1.0)
                                            View.Button(
                                                text = "Learn More",
                                                fontSize = Named NamedSize.Large,
                                                textColor = Color.White,
                                                backgroundColor = Color.Green,
                                                cornerRadius = 20
                                            )
                                        ]
                                    ),
                                    backgroundColor = Color.LightYellow,
                                    borderColor = Color.Blue,
                                    margin = Thickness 10.0,
                                    cornerRadius = 15.0
                                )

                                View.Frame(
                                    height = 480.0,
                                    width = 300.0, 
                                    content = View.FlexLayout(
                                        direction = FlexDirection.Column,
                                        children = [ 
                                            View.Label(
                                                text = "Banana Monkey",
                                                margin = Thickness (0.0, 8.0),
                                                fontSize = Named NamedSize.Large,
                                                textColor = Color.Blue
                                            )
                                            View.Label(
                                                text = "Watch this monkey eat a giant banana.",
                                                margin = Thickness (0.0, 4.0),
                                                textColor = Color.Black
                                            )
                                            View.Label(
                                                text = "  • More fun than a barrel of monkeys",
                                                margin = Thickness (0.0, 4.0),
                                                textColor = Color.Black
                                            )
                                            View.Label(
                                                text = "  • Banana not included",
                                                margin = Thickness (0.0, 4.0),
                                                textColor = Color.Black
                                            )
                                            View.Image(
                                                height = 213.0, 
                                                width = 320.0, 
                                                source = Path "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Crab_eating_macaque_in_Ubud_with_banana.JPG/320px-Crab_eating_macaque_in_Ubud_with_banana.JPG"
                                            ).Order(-1)
                                             .AlignSelf(FlexAlignSelf.Center)
                                             
                                            View.Label(margin = Thickness (0.0, 4.0)).Grow(1.0)
                                            View.Button(
                                                text = "Learn More",
                                                fontSize = Named NamedSize.Large,
                                                textColor = Color.White,
                                                backgroundColor = Color.Green,
                                                cornerRadius = 20
                                            )
                                        ]
                                    ),
                                    backgroundColor=Color.LightYellow,
                                    borderColor=Color.Blue,
                                    margin=Thickness 10.0,
                                    cornerRadius=15.0
                                )
                            ]
                        ),
                        orientation=ScrollOrientation.Both)
                    ]
                )
            )
        
    let tab2View () =
        View.ScrollingContentPage(
            title = "TableView",
            content = View.StackLayout([
                View.Label(text = "TableView:")
                View.TableView(
                    horizontalOptions = LayoutOptions.StartAndExpand,
                    root = View.TableRoot(
                        items = [
                            View.TableSection(
                                title = "Videos",
                                items = [
                                    View.SwitchCell(on = true, text = "Luca 2008") 
                                    View.SwitchCell(on = true, text = "Don 2010")
                                ]
                            )
                            View.TableSection(
                                title = "Books",
                                items = [
                                    View.SwitchCell(on = true, text = "Expert F#") 
                                    View.SwitchCell(on = false, text = "Programming F#")
                                ]
                            )
                            View.TableSection(
                                title = "Contact",
                                items = [
                                    View.EntryCell(label = "Email", placeholder = "foo@bar.com")
                                    View.EntryCell(label = "Phone", placeholder = "+44 87654321")
                                ]
                            )
                        ]
                    )
                )
            ])
        )
        
    let tab3View () =
        View.ContentPage(
            title = "RelativeLayout", 
            padding = Thickness (10.0, 20.0, 10.0, 5.0), 
            content = View.RelativeLayout(
                children = [ 
                  View.Label(text = "RelativeLayout Example", textColor = Color.Red)
                      .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
                        
                  View.Label(text = "Positioned relative to my parent", textColor = Color.Red)
                      .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                      .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
                ]
            )
        )
        
    let tab4View () =
        View.ContentPage(
            title = "AbsoluteLayout",
            useSafeArea = true,
            padding = Thickness (10.0, 20.0, 10.0, 5.0), 
            content = View.StackLayout(
                children = [ 
                    View.Label(
                        text = "AbsoluteLayout Demo",
                        fontSize = Named NamedSize.Large,
                        horizontalOptions = LayoutOptions.Center
                    )
                    View.AbsoluteLayout(
                       backgroundColor = Color.Blue.WithLuminosity(0.9), 
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
                ]
            )
        )

    let view () =
        View.TabbedPage(
            useSafeArea = true, 
            children = [ 
                tab1View()
                tab2View()
                tab3View()
                tab4View()
            ]
        )

