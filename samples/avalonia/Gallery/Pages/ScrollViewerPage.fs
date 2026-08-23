namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ScrollViewerPage =
    type Model =
        { AllowAutoHide: bool
          EnableInertia: bool
          AreSnapPointsRegular: bool
          AvailableVisibility: string list
          AvailableSnapPointsType: string list
          AvailableSnapPointsAlignment: string list
          VerticalScrollBarVisibility: ScrollBarVisibility
          HorizontalScrollBarVisibility: ScrollBarVisibility
          VerticalSnapPointsType: SnapPointsType
          HorizontalSnapPointsType: SnapPointsType
          VerticalSnapPointsAlignment: SnapPointsAlignment
          HorizontalSnapPointsAlignment: SnapPointsAlignment }

    type Msg =
        | AllowAutoHideChanged of bool
        | EnableInertiaChanged of bool
        | VerticalSelectionChanged of SelectionChangedEventArgs
        | HorizontalSelectionChanged of SelectionChangedEventArgs
        | SnapPointsTypeSelectionChanged of SelectionChangedEventArgs
        | SnapPointsAlignmentSelectionChanged of SelectionChangedEventArgs
        | AreSnapPointsRegularChanged of bool

    let init () =
        { AllowAutoHide = false
          EnableInertia = false
          AvailableVisibility = [ "Disabled"; "Auto"; "Hidden"; "Visible" ]
          AvailableSnapPointsType = [ "None"; "Mandatory"; "MandatorySingle" ]
          AvailableSnapPointsAlignment = [ "Near"; "Center"; "Far" ]
          VerticalScrollBarVisibility = ScrollBarVisibility.Disabled
          HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
          VerticalSnapPointsType = SnapPointsType.None
          HorizontalSnapPointsType = SnapPointsType.None
          VerticalSnapPointsAlignment = SnapPointsAlignment.Near
          HorizontalSnapPointsAlignment = SnapPointsAlignment.Near
          AreSnapPointsRegular = false },
        Cmd.none

    let update msg model =
        match msg with
        | AllowAutoHideChanged b -> { model with AllowAutoHide = b }, Cmd.none
        | EnableInertiaChanged b -> { model with EnableInertia = b }, Cmd.none
        | VerticalSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let visibility = model.AvailableVisibility.[index]

            let scrollBarVisibility =
                match visibility with
                | "Disabled" -> ScrollBarVisibility.Disabled
                | "Auto" -> ScrollBarVisibility.Auto
                | "Hidden" -> ScrollBarVisibility.Hidden
                | "Visible" -> ScrollBarVisibility.Visible
                | _ -> ScrollBarVisibility.Auto

            { model with
                VerticalScrollBarVisibility = scrollBarVisibility },
            Cmd.none

        | HorizontalSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let visibility = model.AvailableVisibility.[index]

            let scrollBarVisibility =
                match visibility with
                | "Disabled" -> ScrollBarVisibility.Disabled
                | "Auto" -> ScrollBarVisibility.Auto
                | "Hidden" -> ScrollBarVisibility.Hidden
                | "Visible" -> ScrollBarVisibility.Visible
                | _ -> ScrollBarVisibility.Auto

            { model with
                HorizontalScrollBarVisibility = scrollBarVisibility },
            Cmd.none

        | SnapPointsTypeSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let snapPointsType = model.AvailableSnapPointsType.[index]

            let snapPointsType =
                match snapPointsType with
                | "None" -> SnapPointsType.None
                | "Mandatory" -> SnapPointsType.Mandatory
                | "MandatorySingle" -> SnapPointsType.MandatorySingle
                | _ -> SnapPointsType.None

            { model with
                VerticalSnapPointsType = snapPointsType
                HorizontalSnapPointsType = snapPointsType },
            Cmd.none

        | SnapPointsAlignmentSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let snapPointsAlignment = model.AvailableSnapPointsAlignment.[index]

            let snapPointsAlignment =
                match snapPointsAlignment with
                | "Near" -> SnapPointsAlignment.Near
                | "Center" -> SnapPointsAlignment.Center
                | "Far" -> SnapPointsAlignment.Far
                | _ -> SnapPointsAlignment.Near

            { model with
                VerticalSnapPointsAlignment = snapPointsAlignment
                HorizontalSnapPointsAlignment = snapPointsAlignment },
            Cmd.none

        | AreSnapPointsRegularChanged b -> { model with AreSnapPointsRegular = b }, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let tab1 model =
        TabItem(
            "ScrollViewer",
            VStack(20.) {
                TextBlock("Allows for horizontal and vertical content scrolling. Supports snapping on touch and pointer wheel scrolling.")
                    .textWrapping(TextWrapping.Wrap)

                Grid(coldefs = [ Auto; Star ], rowdefs = []) {
                    VStack(4.) {
                        ToggleSwitch(model.AllowAutoHide, AllowAutoHideChanged)
                            .content("Allow auto hide")

                        ToggleSwitch(model.EnableInertia, EnableInertiaChanged)
                            .content("Enable inertia")

                        VStack(4.) {
                            TextBlock("Horizontal scroll")

                            ComboBox(model.AvailableVisibility)
                                .selectedIndex(0)
                                .onSelectionChanged(HorizontalSelectionChanged)
                        }

                        VStack(4.) {
                            TextBlock("Vertical scroll")

                            ComboBox(model.AvailableVisibility)
                                .selectedIndex(0)
                                .onSelectionChanged(VerticalSelectionChanged)
                        }
                    }

                    ScrollViewer(
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .width(400.)
                            .height(400.)

                    )
                        .gridColumn(1)
                        .width(400.)
                        .height(400.)
                        .isScrollInertiaEnabled(model.EnableInertia)
                        .allowAutoHide(model.AllowAutoHide)
                        .horizontalScrollBarVisibility(model.HorizontalScrollBarVisibility)
                        .verticalScrollBarVisibility(model.VerticalScrollBarVisibility)
                }
            }
        )

    let scrollContent2 model =
        (HStack() {
            Border(
                TextBlock("Child 1")
                    .fontWeight(FontWeight.Bold)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .borderBrush(Brushes.Red)
                .width(300.)
                .borderThickness(1.)
                .padding(5., 30.)
                .verticalAlignment(VerticalAlignment.Stretch)

            Border(
                TextBlock("Child 2")
                    .fontWeight(FontWeight.Bold)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .borderBrush(Brushes.Red)
                .width(300.)
                .borderThickness(1.)
                .padding(5., 20.)
                .verticalAlignment(VerticalAlignment.Stretch)

            Border(
                TextBlock("Child 3")
                    .fontWeight(FontWeight.Bold)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .borderBrush(Brushes.Red)
                .width(300.)
                .borderThickness(1.)
                .padding(5., 20.)
                .verticalAlignment(VerticalAlignment.Stretch)

            Border(
                TextBlock("Child 4")
                    .fontWeight(FontWeight.Bold)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .borderBrush(Brushes.Red)
                .width(300.)
                .borderThickness(1.)
                .padding(5., 20.)
                .verticalAlignment(VerticalAlignment.Stretch)

            Border(
                TextBlock("Child 5")
                    .fontWeight(FontWeight.Bold)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .borderBrush(Brushes.Red)
                .width(300.)
                .borderThickness(1.)
                .padding(5., 20.)
                .verticalAlignment(VerticalAlignment.Stretch)
        })
            .areHorizontalSnapPointsRegular(model.AreSnapPointsRegular)

    let tab2 model =
        TabItem(
            "Snapping",
            VStack(4.) {
                TextBlock("ScrollViewer can snap supported content both vertically and horizontally. Snapping occurs from scrolling with touch or pen")
                    .textWrapping(TextWrapping.Wrap)

                Grid(rowdefs = [ Auto; Auto; Auto; Auto; Auto ], coldefs = []) {
                    HStack(4.) {
                        VStack(4.) {
                            TextBlock("Snap Point Type")

                            ComboBox(model.AvailableSnapPointsType)
                                .selectedIndex(0)
                                .onSelectionChanged(SnapPointsTypeSelectionChanged)
                        }

                        VStack(4.) {
                            TextBlock("Snap Point Alignment")

                            ComboBox(model.AvailableSnapPointsAlignment)
                                .selectedIndex(0)
                                .onSelectionChanged(SnapPointsAlignmentSelectionChanged)
                        }

                        ToggleSwitch(model.AreSnapPointsRegular, AreSnapPointsRegularChanged)
                            .content("Are Snap Points regular?")
                            .offContent("No")
                            .onContent("Yes")
                    }

                    TextBlock("Vertical Snapping").gridRow(1).margin(0., 10.)

                    Border(
                        ScrollViewer(
                            (VStack() {
                                Border(TextBlock("Child 1").fontWeight(FontWeight.Bold))
                                    .borderBrush(Brushes.Red)
                                    .borderThickness(1.)
                                    .padding(5., 30.)
                                    .horizontalAlignment(HorizontalAlignment.Stretch)

                                Border(TextBlock("Child 2").fontWeight(FontWeight.Bold))
                                    .borderBrush(Brushes.Red)
                                    .borderThickness(1.)
                                    .padding(5., 20.)
                                    .horizontalAlignment(HorizontalAlignment.Stretch)

                                Border(TextBlock("Child 3").fontWeight(FontWeight.Bold))
                                    .borderBrush(Brushes.Red)
                                    .borderThickness(1.)
                                    .padding(5., 20.)
                                    .horizontalAlignment(HorizontalAlignment.Stretch)

                                Border(TextBlock("Child 4").fontWeight(FontWeight.Bold))
                                    .borderBrush(Brushes.Red)
                                    .borderThickness(1.)
                                    .padding(5., 20.)
                                    .horizontalAlignment(HorizontalAlignment.Stretch)

                                Border(TextBlock("Child 5").fontWeight(FontWeight.Bold))
                                    .borderBrush(Brushes.Red)
                                    .borderThickness(1.)
                                    .padding(5., 20.)
                                    .horizontalAlignment(HorizontalAlignment.Stretch)
                            })
                                .areVerticalSnapPointsRegular(model.AreSnapPointsRegular)
                        )
                            .verticalSnapPointsType(model.VerticalSnapPointsType)
                            .verticalSnapPointsAlignment(model.VerticalSnapPointsAlignment)
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .height(350.)
                            .horizontalScrollBarVisibility(ScrollBarVisibility.Disabled)
                    )
                        .borderBrush(Brushes.Green)
                        .borderThickness(1.)
                        .gridRow(2)
                        .padding(0.)
                        .margin(10., 5.)

                    TextBlock("Horizontal Snapping").gridRow(3).margin(0., 10.)

                    Border(
                        ScrollViewer(scrollContent2 model)
                            .horizontalSnapPointsType(model.HorizontalSnapPointsType)
                            .horizontalSnapPointsAlignment(model.HorizontalSnapPointsAlignment)
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .height(350.)
                            .horizontalScrollBarVisibility(ScrollBarVisibility.Auto)
                            .verticalScrollBarVisibility(ScrollBarVisibility.Disabled)
                    )
                        .borderBrush(Brushes.Green)
                        .borderThickness(1.)
                        .gridRow(4)
                        .padding(0.)
                        .margin(10., 10.)
                }
            }
        )

    let view () =
        Component("ScrollViewerPage") {
            let! model = Context.Mvu program

            TabControl() {
                tab1 model
                tab2 model
            }
        }
