namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module Border =
    let view () =
        VStack(spacing = 15.) {
            (VStack(16.) {
                Border(Label("Border"))
                    .stroke(SolidColorBrush(Colors.BlueViolet))
                    .background(SolidColorBrush(Colors.ForestGreen))
                    .strokeThickness(2.)
                    .padding(16.)
            })
                .margin(0., 16., 0., 0.)
                .centerHorizontal()

            Border(Label("Border and Background"))
                .stroke(SolidColorBrush(Colors.BlueViolet))
                .background(SolidColorBrush(Colors.ForestGreen))
                .strokeThickness(4.)
                .padding(16.)
                .centerHorizontal()

            Border(Label("Rounded Corners"))
                .stroke(SolidColorBrush(Colors.BlueViolet))
                .strokeShape(RoundRectangle(CornerRadius(8.)))
                .strokeThickness(8.)
                .padding(16.)
                .centerHorizontal()


            Border(Label("Rounded Corners"))
                .stroke(SolidColorBrush(Colors.Magenta))
                .background(SolidColorBrush(Colors.Green))
                .strokeShape(RoundRectangle(CornerRadius(8.)))
                .padding(16.)
                .centerHorizontal()


            Border(Image("dotnet_bot.png"))
                .stroke(SolidColorBrush(Colors.Green))
                .width(100.)
                .height(100.)
                .strokeThickness(0.)
                .background(SolidColorBrush(Colors.Green))
                .strokeShape(RoundRectangle(CornerRadius(100.)))
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "Border"
          Description = "A control which decorates a child with a border and background"
          Program = sampleProgram }
