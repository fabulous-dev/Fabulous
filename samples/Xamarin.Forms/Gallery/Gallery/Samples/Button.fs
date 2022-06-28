namespace Gallery.Samples

open Fabulous.XamarinForms
open Xamarin.Forms

open type Fabulous.XamarinForms.View

module Button =
    type Model =
        { Count: int }
        
    type Msg =
        | Clicked
        
    let init () =
        { Count = 0 }
        
    let update msg model =
        match msg with
        | Clicked ->
            { model with Count = model.Count + 1 }
    
    let view model =
        VStack(spacing = 10.) {
            Button("Click me!", Clicked)
            Label($"Click count: {model.Count}")
                .centerTextHorizontal()
        }
        
    let sampleCodeFormatted () =
        FormattedLabel() {
            Span("Button").textColor(Color.Green.ToFabColor())
            Span("(")
            Span("\"Click me!\"").textColor(FabColor.fromHex "#8a714b")
            Span(", ")
            Span("Clicked").textColor(Color.Purple.ToFabColor())
            Span(")")
        }

    let sample =
        { Name = "Button"
          Description = "A button widget that reacts to touch events."
          ApiRefLink = "https://docs.fabulous.dev/v2/api/controls/button"
          XFDocLink = "https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button"
          SampleCode = """Button("Click me!", Clicked)"""
          SampleCodeFormatted = sampleCodeFormatted
          Program = Helper.createProgram init update view }