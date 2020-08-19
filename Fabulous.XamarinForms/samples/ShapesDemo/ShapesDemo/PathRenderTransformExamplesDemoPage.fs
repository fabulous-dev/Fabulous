namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module PathRenderTransformExamplesDemoPage =
    let [<Literal>] pathData = "M13.908992,16.207977L32.000049,16.207977 32.000049,31.999985 13.908992,30.109983z M0,16.207977L11.904009,16.207977 11.904009,29.900984 0,28.657984z M11.904036,2.0979624L11.904036,14.202982 2.7656555E-05,14.202982 2.7656555E-05,3.3409645z M32.000058,0L32.000058,14.203001 13.909059,14.203001 13.909059,1.8890382z"

    let view () =
        View.ContentPage(
            title = "Path render transform examples",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("Path with RotateTransform")
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.RotateTransform(
                                    centerX = 0.,
                                    centerY = 0.,
                                    angle = 45.
                                )
                            )
                        )

                        View.Label(
                            text = "Path with ScaleTransform",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.ScaleTransform(
                                    centerX = 0.,
                                    centerY = 0.,
                                    scaleX = 1.5,
                                    scaleY = 1.5
                                )
                            )
                        )

                        View.Label(
                            text = "Path with SkewTransform",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.SkewTransform(
                                    centerX = 0.,
                                    centerY = 0.,
                                    angleX = 45.,
                                    angleY = 0.
                                )
                            )
                        )

                        View.Label(
                            text = "Path with TranslateTransform",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.TranslateTransform(
                                    x = 50.,
                                    y = 50.
                                )
                            )
                        )

                        View.Label(
                            text = "Path with TransformGroup",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.TransformGroup([
                                    View.ScaleTransform(
                                        scaleX = 1.5,
                                        scaleY = 1.5
                                    )
                                    View.RotateTransform(
                                        angle = 45.
                                    )
                                ])
                            )
                        )

                        View.Label(
                            text = "Path with CompositeTransform",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.CompositeTransform(
                                    scaleX = 1.5,
                                    scaleY = 1.5,
                                    rotation = 45.,
                                    translateX = 50.,
                                    translateY = 50.
                                )
                            )
                        )

                        View.Label(
                            text = "Path with MatrixTransform",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromElement(
                                View.MatrixTransform(
                                    matrix = Matrix(OffsetX = 10., OffsetY = 100., M11 = 1.5, M12 = 1.)
                                )
                            )
                        )

                        View.Label(
                            text = "Path with MatrixTransform via converter",
                            margin = Thickness(0., 50., 0., 0.)
                        )
                        View.Path(
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 1.,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Center,
                            height = 100.,
                            width = 100.,
                            data = Content.fromString pathData,
                            renderTransform = Content.fromString "1.5,1,0,1,10,100"
                        )
                    ]
                )
            )
        )

