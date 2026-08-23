namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media

open Fabulous
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module Common =
    let acrylicBorderStyle1 (this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>) =
        this.height(100.).margin(10.).maxWidth(200.)

    let acrylicBorderStyle (this: WidgetBuilder<'msg, IFabExperimentalAcrylicBorder>) =
        this.cornerRadius(CornerRadius(5.)).maxWidth(660.)

    let textBlockStyle (this: WidgetBuilder<'msg, IFabTextBlock>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .foreground(SolidColorBrush(Colors.Black))

    let sliderStyle (this: WidgetBuilder<'msg, IFabSlider>) =
        this.margin(8., 0.).largeChange(0.2).smallChange(0.1)

module MvuAcrylicPage =
    type Model =
        { TintOpacitySlider: float
          BorderWidth: float
          MaterialOpacitySlider: float }

    type Msg =
        | TintOpacitySliderValueChanged of float
        | MaterialOpacitySliderValueChanged of float
        | Previous

    let init () =
        { TintOpacitySlider = 0.9
          BorderWidth = 160.
          MaterialOpacitySlider = 0.8 },
        Cmd.none

    let bordersGridRef = ViewRef<UniformGrid>()

    let update msg model =
        match msg with
        | TintOpacitySliderValueChanged value ->
            let borderWidth =
                match bordersGridRef.TryValue with
                | Some ref -> ref.Bounds.Width
                | _ -> 160.

            { model with
                TintOpacitySlider = value
                BorderWidth = borderWidth },
            Cmd.none
        | MaterialOpacitySliderValueChanged value ->
            let borderWidth =
                match bordersGridRef.TryValue with
                | Some ref -> ref.Bounds.Width
                | _ -> 160.

            { model with
                MaterialOpacitySlider = value
                BorderWidth = borderWidth },
            Cmd.none

        | Previous -> model, Cmd.none

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

    let view () =
        Component("MvuAcrylicPage") {
            let! model = Context.Mvu program

            VStack(spacing = 20.) {
                ExperimentalAcrylicBorder(
                    VStack(0.) {
                        (Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Auto ]) {
                            TextBlock("TintOpacity").style(Common.textBlockStyle)

                            Slider(0., 1., model.TintOpacitySlider, TintOpacitySliderValueChanged)
                                .gridColumn(1)
                                .style(Common.sliderStyle)

                            TextBlock($"{Math.Round(model.TintOpacitySlider, 2)}")
                                .gridColumn(2)
                                .style(Common.textBlockStyle)
                        })
                            .margin(20., 10.)

                        (Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Auto ]) {
                            TextBlock("MaterialOpacity").style(Common.textBlockStyle)

                            Slider(0., 1., model.MaterialOpacitySlider, MaterialOpacitySliderValueChanged)
                                .gridColumn(1)
                                .style(Common.sliderStyle)

                            TextBlock($"{Math.Round(model.MaterialOpacitySlider, 2)}")
                                .gridColumn(2)
                                .style(Common.textBlockStyle)
                        })
                            .margin(20., 10.)
                    }
                )
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Colors.White)
                    )
                    .style(Common.acrylicBorderStyle)

                (UniformGrid() {
                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#FF0000"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#00FF00"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Colors.White)
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#3c3c3c"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)


                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Colors.White)
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#000000"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#FFFF00"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)


                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#0000FF"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)

                    ExperimentalAcrylicBorder()
                        .material(
                            ExperimentalAcrylicMaterial()
                                .backgroundSource(AcrylicBackgroundSource.Digger)
                                .tintColor(Color.Parse("#0000FF"))
                                .tintOpacity(model.TintOpacitySlider)
                                .materialOpacity(model.MaterialOpacitySlider)
                        )
                        .style(Common.acrylicBorderStyle1)
                })
                    .reference(bordersGridRef)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#0000FF"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .width(model.BorderWidth)
                    .height(160.)
            }
        }
