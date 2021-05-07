namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module Button =
    type Model =
        { Button1Clicked: bool
          Button2Clicked: bool
          IsButton2Enabled: bool
          Button3Pressed: bool }

    type Msg =
        | Button1Clicked
        | Button2Clicked
        | Button2EnableToggled of bool
        | Button3Pressed
        | Button3Released

    let init () =
        { Button1Clicked = false
          Button2Clicked = false
          IsButton2Enabled = true
          Button3Pressed = false }

    let update msg model =
        match msg with
        | Button1Clicked -> { model with Button1Clicked = true }
        | Button2Clicked -> { model with Button2Clicked = true }
        | Button2EnableToggled value -> { model with IsButton2Enabled = value }
        | Button3Pressed -> { model with Button3Pressed = true }
        | Button3Released -> { model with Button3Pressed = false }

    let view model dispatch =
        View.ScrollingContentPage(
            title = "Button sample",
            content = View.StackLayout([
                View.Label("Button with command")
                View.Button(
                    text = "Click me",
                    command = fun () -> dispatch Button1Clicked
                )
                View.Label(
                    text = if model.Button1Clicked then "Clicked" else "Not clicked"
                )

                View.Label("Button with enable state")
                View.StackLayout(
                    orientation = StackOrientation.Horizontal,
                    children = [
                        View.Switch(
                            isToggled = model.IsButton2Enabled,
                            toggled = fun args -> dispatch (Button2EnableToggled args.Value)
                        )
                        View.Label(
                            if model.IsButton2Enabled then "Enabled" else "Disabled"
                        )
                    ]
                )
                View.Button(
                    text = "Click me",
                    commandCanExecute = model.IsButton2Enabled,
                    command = fun () -> dispatch Button2Clicked
                )
                View.Label(
                    text = if model.Button2Clicked then "Clicked" else "Not clicked"
                )

                View.Label("Button with Pressed/Released events")
                View.Button(
                    text = "Click me",
                    pressed = (fun () -> dispatch Button3Pressed),
                    released = (fun () -> dispatch Button3Released)
                )
                View.Label(
                    text = if model.Button3Pressed then "Pressed" else "Released"
                )
            ])
        )