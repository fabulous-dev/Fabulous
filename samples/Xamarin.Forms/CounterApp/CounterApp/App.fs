namespace Fabulous.XamarinForms.Samples.CounterApp

open Xamarin.Forms
open Fabulous.XamarinForms
open type Fabulous.XamarinForms.View

module App =
    let view () =
        Application(
            ContentPage(
                VerticalStackLayout(spacing = 30., children = [
                    Label("Hello Fabulous")
                        .centerAndExpand()
                    Label("Test")
                        .centerHorizontally()
                    Label("Test2")
                        .centerHorizontally()
                    Label("End")
                        .centerAndExpand()
                ])
            )
        )

    let program = Program.statelessApplication view