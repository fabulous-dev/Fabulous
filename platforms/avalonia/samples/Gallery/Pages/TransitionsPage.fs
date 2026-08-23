namespace Gallery

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module TransitionsPage =
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
        Grid() {
            (VStack() {
                (HStack(20.) {
                    TextBlock("Hover to activate Transitions.")
                        .verticalAlignment(VerticalAlignment.Center)
                })
                    .verticalAlignment(VerticalAlignment.Center)

                UserControl(
                    (HWrap() {
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
                            .background(Brushes.Orange)
                            .transition(
                                TransformOperationsTransition(Border.RenderTransformProperty, TimeSpan.FromMilliseconds(500.))
                                    .delay(TimeSpan.FromMilliseconds(1000.))
                            )

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect7" ])
                            .background(Brushes.Gold)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect8" ])
                            .background(Brushes.Gray)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect9" ])
                            .background(Brushes.Red)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Shadow" ])
                            .cornerRadius(CornerRadius(10.))

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Shadow" ])
                            .cornerRadius(CornerRadius(0., 30., 60., 0.))

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Shadow" ])
                            .cornerRadius(CornerRadius(0., 30., 60., 0.))

                        Border().style(borderTest1).classes([ "Test"; "Rect10" ])


                        Border().style(borderTest1).classes([ "Test"; "Rect11" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect12" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect13" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])
                    })
                        .clipToBounds(false)
                )
                    .styleInclude([ "avares://Gallery/Styles/Transitions.xaml" ])

            })
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)
                .clipToBounds(false)
        }
