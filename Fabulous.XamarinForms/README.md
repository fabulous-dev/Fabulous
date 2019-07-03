Fabulous for Xamarin.Forms - Write cross-platform apps with Xamarin.Forms, using MVU architecture and dynamic UI
=======

[![Fabulous.XamarinForms NuGet version](https://badge.fury.io/nu/Fabulous.XamarinForms.svg)](https://badge.fury.io/nu/Fabulous.XamarinForms)

This library allows you to use the ultra-simple Model-View-Update architecture to build applications for iOS, Android, Mac, WPF and more using Xamarin.Forms. It is built on Fabulous.

With Fabulous for Xamarin.Forms, you will be able to write complete applications fully in F#, like this:
```fsharp
type Model = { Text: string }
type Msg = ButtonClicked

let init () = { Text = "Hello Fabulous!" }

let update msg model =
    match msg with
    | ButtonClicked -> { model with Text = "Thanks for using Fabulous!" }

let view model dispatch =
    View.ContentPage(
        View.StackLayout(
            children=[
                View.Image(source = "fabulous.png")
                View.Label(text = model.Text, fontSize = 22.)
                View.Button(text = "Click me", command = (fun () -> dispatch ButtonClicked))
            ]
        )
    )
```
For more information, please take a look at the documentation.

* [Getting started](https://fsprojects.github.io/Fabulous/index.html#getting=started)

* [Documentation Guide](https://fsprojects.github.io/Fabulous/guide.html)

* [Roadmap](ROADMAP.md)

* [Release Notes](RELEASE_NOTES.md)

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.