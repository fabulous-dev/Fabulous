namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module PanelPage =
    let view () =
        (Panel() {
            Rectangle()
                .fill(SolidColorBrush(Colors.Red))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Top)

            Rectangle()
                .fill(SolidColorBrush(Colors.Blue))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Right)

            Rectangle()
                .fill(SolidColorBrush(Colors.Green))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Bottom)

            Rectangle()
                .fill(SolidColorBrush(Colors.Orange))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Left)
        })
            .width(300.)
            .height(300.)
