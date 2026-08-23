namespace BasicNavigation

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

module PageC =
    let content () =
        Component("Page C") {
            let! count = State(0)

            (VStack() {
                Label("Page C")
                    .foreground(Brushes.White)
                    .fontSize(32.)
                    .centerHorizontal()
                    .margin(0., 0., 0., 30.)

                TextBlock($"%d{count.Current}").centerText()

                Button("Increment", (fun _ -> count.Set(count.Current + 1)))
                    .centerHorizontal()

                Button("Decrement", (fun _ -> count.Set(count.Current - 1)))
                    .centerHorizontal()
            })
                .center()
        }
