namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms

module ClipViewsDemoPage =
    
    let view () =
        View.ContentPage(
            title = "View clipping demos",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Button(
                            text = "Button",
                            backgroundColor = Color.Red,
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.DatePicker(
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.Entry(
                            backgroundColor = Color.Blue,
                            placeholder = "Entry",
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.Editor(
                            backgroundColor = Color.Yellow,
                            placeholder = "Editor",
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.Grid(
                            backgroundColor = Color.Orange,
                            height = 50.,
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.SearchBar(
                            backgroundColor = Color.Purple,
                            placeholder = "SearchBar",
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                        View.TimePicker(
                            backgroundColor = Color.Teal,
                            clip = View.EllipseGeometry(
                                radiusX = 300.,
                                radiusY = 50.
                            )
                        )
                    ]
                )
            )
        )

