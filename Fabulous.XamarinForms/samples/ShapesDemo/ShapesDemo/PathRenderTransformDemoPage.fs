namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms

module PathRenderTransformDemoPage =
    [<Literal>]
    let pathData = "M13.908992,16.207977L32.000049,16.207977 32.000049,31.999985 13.908992,30.109983z M0,16.207977L11.904009,16.207977 11.904009,29.900984 0,28.657984z M11.904036,2.0979624L11.904036,14.202982 2.7656555E-05,14.202982 2.7656555E-05,3.3409645z M32.000058,0L32.000058,14.203001 13.909059,14.203001 13.909059,1.8890382z"

    type Model =
        { CenterX: float
          CenterY: float
          Rotation: float
          ScaleX: float
          ScaleY: float
          SkewX: float
          SkewY: float
          TranslateX: float
          TranslateY: float }

    type Msg =
        | CenterXChanged of float
        | CenterYChanged of float
        | RotationChanged of float
        | ScaleXChanged of float
        | ScaleYChanged of float
        | SkewXChanged of float
        | SkewYChanged of float
        | TranslateXChanged of float
        | TranslateYChanged of float

    let init () =
        { CenterX = 0.
          CenterY = 0.
          Rotation = 0.
          ScaleX = 1.
          ScaleY = 1.
          SkewX = 0.
          SkewY = 0.
          TranslateX = 0.
          TranslateY = 0. }

    let update msg model =
        match msg with
        | CenterXChanged centerX -> { model with CenterX = centerX }
        | CenterYChanged centerY -> { model with CenterY = centerY }
        | RotationChanged rotation -> { model with Rotation = rotation }
        | ScaleXChanged scaleX -> { model with ScaleX = scaleX }
        | ScaleYChanged scaleY -> { model with ScaleY = scaleY }
        | SkewXChanged skewX -> { model with SkewX = skewX }
        | SkewYChanged skewY -> { model with SkewY = skewY }
        | TranslateXChanged translateX -> { model with TranslateX = translateX }
        | TranslateYChanged translateY -> { model with TranslateY = translateY }

    let headerLabel text =
        View.Label(
            text = text,
            fontSize = FontSize.fromValue 14.,
            margin = Thickness(6., 12., 0., 0.)
        )
    let valueLabel text =
        View.Label(
            text = text,
            fontSize = FontSize.fromValue 10.,
            margin = Thickness(12., 0.)
        )

    let view model dispatch =
        View.ContentPage(
            View.Grid(
                margin = Thickness(20.),
                rowdefs = [ Auto; Star ],
                children = [
                    View.Grid(
                        backgroundColor = Color.FromHex("#E5E5E5"),
                        height = 200.,
                        width = 200.,
                        horizontalOptions = LayoutOptions.Center,
                        children = [
                            View.Path(
                                stroke = View.SolidColorBrush(Color.Black),
                                strokeThickness = 1.,
                                aspect = Stretch.Uniform,
                                height = 100.,
                                width = 100.,
                                data = Content.fromString pathData,
                                renderTransform = Content.fromElement(
                                    View.TransformGroup([
                                        View.RotateTransform(
                                            angle = model.Rotation,
                                            centerX = model.CenterX,
                                            centerY = model.CenterY
                                        )
                                        View.ScaleTransform(
                                            scaleX = model.ScaleX,
                                            scaleY = model.ScaleY,
                                            centerX = model.CenterX,
                                            centerY = model.CenterY
                                        )
                                        View.SkewTransform(
                                            angleX = model.SkewX,
                                            angleY = model.SkewY,
                                            centerX = model.CenterX,
                                            centerY = model.CenterY
                                        )
                                        View.TranslateTransform(
                                            x = model.TranslateX,
                                            y = model.TranslateY
                                        )
                                    ])
                                )
                            )
                        ]
                    )
                    View.ScrollView(
                        View.StackLayout([
                            headerLabel "Center"
                            valueLabel (sprintf "CenterX: %0f" model.CenterX)
                            View.Slider(
                                minimumMaximum = (0., 360.),
                                value = model.CenterX,
                                valueChanged = fun e -> dispatch (CenterXChanged e.NewValue)
                            )
                            valueLabel (sprintf "CenterY: %0f" model.CenterY)
                            View.Slider(
                                minimumMaximum = (0., 360.),
                                value = model.CenterY,
                                valueChanged = fun e -> dispatch (CenterYChanged e.NewValue)
                            )

                            headerLabel "RotateTransform"
                            valueLabel (sprintf "Rotation: %0f" model.Rotation)
                            View.Slider(
                                minimumMaximum = (0., 360.),
                                value = model.Rotation,
                                valueChanged = fun e -> dispatch (RotationChanged e.NewValue)
                            )

                            headerLabel "Scale"
                            valueLabel (sprintf "ScaleX: %0f" model.ScaleX)
                            View.Slider(
                                minimumMaximum = (0.5, 2.),
                                value = model.ScaleX,
                                valueChanged = fun e -> dispatch (ScaleXChanged e.NewValue)
                            )
                            valueLabel (sprintf "ScaleY: %0f" model.ScaleY)
                            View.Slider(
                                minimumMaximum = (0.5, 2.),
                                value = model.ScaleY,
                                valueChanged = fun e -> dispatch (ScaleYChanged e.NewValue)
                            )

                            headerLabel "Skew"
                            valueLabel (sprintf "SkewX: %0f" model.SkewX)
                            View.Slider(
                                minimumMaximum = (0., 100.),
                                value = model.SkewX,
                                valueChanged = fun e -> dispatch (SkewXChanged e.NewValue)
                            )
                            valueLabel (sprintf "SkewY: %0f" model.SkewY)
                            View.Slider(
                                minimumMaximum = (0., 100.),
                                value = model.SkewY,
                                valueChanged = fun e -> dispatch (SkewYChanged e.NewValue)
                            )

                            headerLabel "Translate"
                            valueLabel (sprintf "TranslateX: %0f" model.TranslateX)
                            View.Slider(
                                minimumMaximum = (0., 200.),
                                value = model.TranslateX,
                                valueChanged = fun e -> dispatch (TranslateXChanged e.NewValue)
                            )
                            valueLabel (sprintf "TranslateY: %0f" model.TranslateY)
                            View.Slider(
                                minimumMaximum = (0., 200.),
                                value = model.TranslateY,
                                valueChanged = fun e -> dispatch (TranslateYChanged e.NewValue)
                            )
                        ])
                    ).Row(1)
                ]
            )
        )

