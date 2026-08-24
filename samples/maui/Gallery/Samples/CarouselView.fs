namespace Gallery.Samples

open Fabulous
open Fabulous.Maui
open Gallery
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

open type Fabulous.Maui.View

module CarouselView =
    type Slide = { Title: string; Color: Color }

    let slides =
        [ { Title = "First"
            Color = Colors.LightBlue }
          { Title = "Second"
            Color = Colors.LightGreen }
          { Title = "Third"
            Color = Colors.LightPink } ]

    let indicator = ViewRef<IndicatorView>()

    let view () =
        Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
            (View.CarouselView (slides) (fun slide -> Border(Label(slide.Title).font(size = 30.).center()).background(SolidColorBrush(slide.Color)).margin(20.)))
                .indicatorView(indicator)
                .loop(false)
                .gridRow(0)

            IndicatorView(indicator).indicatorColor(Colors.Gray).selectedIndicatorColor(Colors.Blue).centerHorizontal().margin(0., 12., 0., 12.).gridRow(1)
        }

    let sample =
        { Name = "CarouselView"
          Description = "A templated carousel linked to an IndicatorView"
          Program = Helper.createStatelessProgram view }
