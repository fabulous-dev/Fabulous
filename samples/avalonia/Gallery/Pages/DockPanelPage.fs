namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module DockPanelPage =
    let view () =
        VStack(spacing = 20.) {
            TextBlock("Basic DockPanel")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)
                .margin(0., 0., 0., 10.)

            (Dock() {
                Rectangle()
                    .fill(SolidColorBrush(Colors.Red))
                    .height(100.)
                    .dock(Dock.Top)

                Rectangle()
                    .fill(SolidColorBrush(Colors.Blue))
                    .width(100.)
                    .dock(Dock.Left)

                Rectangle()
                    .fill(SolidColorBrush(Colors.Green))
                    .height(100.)
                    .dock(Dock.Bottom)

                Rectangle()
                    .fill(SolidColorBrush(Colors.Orange))
                    .width(100.)
                    .dock(Dock.Right)

                Rectangle().fill(SolidColorBrush(Colors.Gray))
            })
                .size(300., 300.)

            TextBlock("DockPanel with Spacing")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)
                .margin(0., 20., 0., 10.)

            (Dock() {
                Border()
                    .width(500.)
                    .height(50.)
                    .background(SolidColorBrush(Colors.LightBlue))
                    .dock(Dock.Top)

                Border()
                    .width(500.)
                    .height(50.)
                    .background(SolidColorBrush(Colors.LightGreen))
                    .dock(Dock.Bottom)

                Border()
                    .width(50.)
                    .height(400.)
                    .background(SolidColorBrush(Colors.LightPink))
                    .dock(Dock.Left)

                Border()
                    .width(50.)
                    .height(400.)
                    .background(SolidColorBrush(Colors.LightYellow))
                    .dock(Dock.Right)

                Border().background(SolidColorBrush(Colors.LightGray))
            })
                .horizontalSpacing(10.)
                .verticalSpacing(10.)
                .margin(10.)

            TextBlock(
                "In this example, the DockPanel with spacing shows exactly how the horizontal and vertical spacing properties affect layout. Borders are positioned with the same dimensions as in the C# test case, resulting in proper spacing between elements."
            )
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 20., 0., 0.)
        }
