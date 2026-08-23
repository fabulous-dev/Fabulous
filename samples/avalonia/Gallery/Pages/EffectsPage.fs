namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module EffectsPage =
    let view () =
        (VStack(spacing = 15.) {
            Image("avares://Gallery/Assets/delicate-arch.jpg")
                .width(300.)
                .height(300.)
                .effect(BlurEffect(10.))

            TextBlock("Shadow Text")
                .foreground(Brushes.Teal)
                .fontSize(30.)
                .effect(DropShadowEffect(30., 30.))

            TextBlock("Shadow Text")
                .foreground(Brushes.Teal)
                .fontSize(30.)
                .effect(
                    DropShadowDirectionEffect(4., 330.)
                        .blurRadius(4.)
                        .opacity(0.5)
                        .color(Colors.White)
                )

            Grid() {
                TextBlock("Shadow Text")
                    .foreground(Brushes.White)
                    .renderTransform(TranslateTransform(3., 3.))
                    .gridRow(0)
                    .gridColumn(0)

                TextBlock("Shadow Text")
                    .foreground(Brushes.Coral)
                    .gridRow(0)
                    .gridColumn(0)

            }

        })
            .horizontalAlignment(HorizontalAlignment.Center)
