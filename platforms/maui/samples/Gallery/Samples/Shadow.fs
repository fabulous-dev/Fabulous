namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module Shadow =
    let view () =
        VStack(spacing = 15.) {
            Image("dotnet_bot.png")
                .width(250.)
                .height(310.)
                .centerHorizontal()
                .shadow(Shadow(Brush.Black, Point(20., 20.)).opacity(0.8).blurRadius(40.))

            Image("dotnet_bot.png", Aspect.AspectFill)
                .width(100.)
                .height(100.)
                .centerHorizontal()
                .clip(EllipseGeometry(Point(100., 100.), 100., 100.))
                .shadow(Shadow(Brush.Black, Point(10., 10.)).opacity(0.8).blurRadius(40.))
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "Shadow"
          Description = "Control that paints a shadow around a layout or view."
          Program = sampleProgram }
