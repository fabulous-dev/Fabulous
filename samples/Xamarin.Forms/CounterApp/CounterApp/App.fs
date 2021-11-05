namespace Fabulous.XamarinForms.Samples.CounterApp

open Xamarin.Forms

type App () as app = 
    inherit Application ()
    let page = ContentPage()
    let label = Label()
    do label.Text <- "Hello Fabulous"
    do label.HorizontalOptions <- LayoutOptions.Center
    do label.VerticalOptions <- LayoutOptions.Center
    do page.Content <- label
    do app.MainPage <- page