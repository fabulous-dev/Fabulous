namespace HelloWorld

open Microsoft.Maui.Accessibility
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml
open System

type MainPage() as this =
    inherit ContentPage()

    do this.LoadFromXaml(typeof<MainPage>) |> ignore

    let mutable count = 0
    let mutable clickHandler = null

    let CounterBtn = this.FindByName<Button>("CounterBtn")

    override this.OnAppearing() =
        clickHandler <- EventHandler(this.CounterBtnClicked)
        CounterBtn.Clicked.AddHandler(clickHandler)

    override this.OnDisappearing() =
        CounterBtn.Clicked.RemoveHandler(clickHandler)
        clickHandler <- null

    member this.CounterBtnClicked (_sender: obj) (_args: EventArgs) =
        count <- count + 1
        
        CounterBtn.Text <-
            if count = 1 then
                $"Clicked {count} time"
            else
                $"Clicked {count} times"

        SemanticScreenReader.Announce(CounterBtn.Text)