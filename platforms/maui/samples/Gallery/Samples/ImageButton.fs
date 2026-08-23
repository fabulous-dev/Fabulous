namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module ImageButton =
    let view () =
        VStack(spacing = 15.) {
            Label("Default ImageButton")
            ImageButton("dotnet_bot.png", ())

            Label("ImageButton with background and width/height")

            ImageButton("dotnet_bot.png", ())
                .background(Colors.LightBlue)
                .width(250.)
                .height(50.)

            Label("ImageButton with Aspect = Fill")
            ImageButton("dotnet_bot.png", (), Aspect.Fill)
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "ImageButton"
          Description = "A button widget with an image that reacts to touch events"
          Program = sampleProgram }
