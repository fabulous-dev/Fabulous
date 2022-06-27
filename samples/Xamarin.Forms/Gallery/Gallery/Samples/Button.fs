namespace Gallery.Samples

open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

module Button =
    let description =
        { Name = "Button"
          Description = "A button"
          ApiRefLink = "https://docs.fabulous.dev/v2/api/controls/button"
          XFDocLink = "https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button"
          SampleCode = """Button("Click me!", Clicked)""" }
    
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
        VStack(spacing = 20.) {
            Button("Click me!", Clicked)
                
            Label($"Click count: {model.Count}")
        }

    let sample =
        { Description = description
          Program = Helper.createProgram init update view }