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
        VStack(spacing = 15.) {
            Label("Default Buttons")
                .font(namedSize = NamedSize.Subtitle)
            
            Frame(
                VStack() {
                    // Regular button
                    Button($"Click count: {model.Count}", Clicked)
                    
                    // Disabled button
                    Button("Disabled button", Clicked)
                        .isEnabled(false)
                }
            )
                .hasShadow(false)
                .borderColor(Color.Gray.ToFabColor())
        }
        
    let sampleCode = """
|C:// Regular button:|
|T:Button:|(|S:$"Click count:| {model.|P:Count:|}|S:":|, |M:Clicked:|)

|C:// Disabled button:|
|T:Button:|(|S:"Disabled button":|, |M:Clicked:|)
    .|T:isEnabled:|(|K:false:|)
"""
        
    let sample =
        { Name = "Button"
          Description = "A button widget that reacts to touch events."
          SourceFilename = "Views/Controls/Button.fs"
          SourceLink = "https://github.com/fsprojects/Fabulous/blob/v2.0/src/Fabulous.XamarinForms/Views/Controls/Button.fs"
          DocumentationName = "Button API reference"
          DocumentationLink = "https://docs.fabulous.dev/v2/api/controls/button"
          SampleCode = Helper.cleanMarkersFromSampleCode sampleCode
          SampleCodeFormatted = Helper.createSampleCodeFormatted sampleCode
          Program = Helper.createProgram init update view }