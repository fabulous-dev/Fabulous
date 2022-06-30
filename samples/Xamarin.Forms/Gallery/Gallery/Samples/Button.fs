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
        VStack(spacing = 0.) {
            Button("Click me!", Clicked)
            Label($"Click count: {model.Count}")
                .centerTextHorizontal()
        }
        
    let sampleCodeFormatted () =
        FormattedLabel() {
            Span("Button").textColor(FabColor.fromHex "#449275")
            Span("(").textColor(FabColor.fromHex "#383838")
            Span("\"Click me!\"").textColor(FabColor.fromHex "#8a714b")
            Span(", ").textColor(FabColor.fromHex "#383838")
            Span("Clicked").textColor(FabColor.fromHex "#6833b6")
            Span(")").textColor(FabColor.fromHex "#383838")
        }

    let sample =
        { Name = "Button"
          Description = "A button widget that reacts to touch events."
          SourceFilename = "Views/Controls/Button.fs"
          SourceLink = "https://github.com/fsprojects/Fabulous/blob/v2.0/src/Fabulous.XamarinForms/Views/Controls/Button.fs"
          DocumentationName = "Button API reference"
          DocumentationLink = "https://docs.fabulous.dev/v2/api/controls/button"
          SampleCode = """Button("Click me!", Clicked)"""
          SampleCodeFormatted = Helper.createSampleCodeFormatted sampleCodeFormatted
          Program = Helper.createProgram init update view }