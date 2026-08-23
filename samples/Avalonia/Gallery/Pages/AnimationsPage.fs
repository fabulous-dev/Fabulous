namespace Gallery

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous


open type Fabulous.Avalonia.View

module AnimationsPage =
    let borderTest1 (this: WidgetBuilder<'msg, IFabBorder>) =
        this.child(
            Path(Paths.Path1)
                .fill(SolidColorBrush(Colors.White))
                .stretch(Stretch.Uniform)
        )

    let borderTest2 (this: WidgetBuilder<'msg, IFabBorder>) =
        this.child(
            Path(Paths.Path2)
                .fill(SolidColorBrush(Colors.Red))
                .stretch(Stretch.Uniform)
        )

    let view () =
        ScrollViewer(
            VStack() {
                Grid() {
                    (VStack() {
                        (HStack(20.) {
                            TextBlock("Hover to activate Keyframe Animations.")
                                .verticalAlignment(VerticalAlignment.Center)
                        })
                            .verticalAlignment(VerticalAlignment.Center)

                        UserControl(
                            HWrap() {
                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect1" ])
                                    .background(Brushes.DarkRed)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect2" ])
                                    .background(Brushes.Magenta)

                                Border().style(borderTest2).classes([ "Test"; "Rect3" ])

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect4" ])
                                    .background(Brushes.Navy)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect5" ])
                                    .background(Brushes.SeaGreen)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect6" ])
                                    .background(Brushes.Red)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(10.))

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(0., 30., 60., 0.))

                                Border().style(borderTest1).classes([ "Test"; "Rect7" ])

                                Border().style(borderTest1).classes([ "Test"; "Rect8" ])

                                Border().style(borderTest1).classes([ "Test"; "Rect9" ])

                                Border().style(borderTest1).classes([ "Test"; "Rect10" ])

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Blur" ])
                                    .background(Brushes.AliceBlue)
                                    .borderThickness(Thickness(4.))
                                    .borderBrush(Brushes.Yellow)
                                    .padding(Thickness(10.))

                                Border(
                                    TextBlock("Drop Shadow")
                                        .verticalAlignment(VerticalAlignment.Center)
                                        .horizontalAlignment(HorizontalAlignment.Center)
                                )
                                    .style(borderTest1)
                                    .classes([ "Test"; "DropShadow" ])
                                    .background(Brushes.Transparent)
                                    .borderThickness(Thickness(4.))
                                    .borderBrush(Brushes.Yellow)
                                    .child(
                                        TextBlock("Drop Shadow")
                                            .verticalAlignment(VerticalAlignment.Center)
                                            .horizontalAlignment(HorizontalAlignment.Center)
                                    )
                            }
                        )
                            .styleInclude([ "avares://Gallery/Styles/Animations.xaml" ])
                    })
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Center)
                        .clipToBounds(false)
                }
            }
        )
