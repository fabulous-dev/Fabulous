namespace Gallery.Samples

open Fabulous.Maui
open Microsoft.Maui.Graphics
open Gallery

open type Fabulous.Maui.View

module ThemeAware =
    let view () =
        (VStack(spacing = 15.) {
            Label("Default label")

            Label("This text will always be green").textColor(Colors.Green)

            Label(ThemeAware.With("Current theme is Light", "Current theme is Dark"))
                .textColor(ThemeAware.With(Colors.Blue, Colors.Red))
                .font(size = ThemeAware.With(12., 20.))

            Image(ThemeAware.With("dotnet_bot.png", "fabulous.png")).size(200., 200.)
        })
            .padding(20.)
            .background(ThemeAware.With(Colors.LightBlue, Colors.DarkBlue))

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "ThemeAware"
          Description = "React to theme changes"
          Program = sampleProgram }
