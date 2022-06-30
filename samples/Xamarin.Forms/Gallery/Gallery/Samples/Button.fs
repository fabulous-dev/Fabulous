namespace Gallery.Samples

open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

module Button =
    type Model =
        { Count: int }
        
    type Msg =
        | Clicked
        | Increment
        | Decrement
        
    let init () =
        { Count = 0 }
        
    let update msg model =
        match msg with
        | Clicked -> model
        | Increment ->
            { model with Count = model.Count + 1 }
        | Decrement ->
            { model with Count = model.Count - 1 }
    
    let view model =
        VStack(spacing = 15.) {
            Label("Regular button")
            Button("Click me!", Clicked)
            
            Label("Disabled button")
            Button("Disabled button", Clicked)
                .isEnabled(false)
            
            Label("Button with styling")
            (HStack(spacing = 15.) {
                Button("Decrement", Decrement)
                    .backgroundColor("#FF0000")
                    .textColor("#FFFFFF")
                    .padding(5.)
                
                Label($"Count: {model.Count}")
                    .centerTextVertical()
                
                Button("Increment", Increment)
                    .textColor("#43ab2f")
                    .padding(5.)
            })
                .centerHorizontal()
        }
        
    let sampleCode = """
|C:// Regular button:|
|T:Button:|(|S:"Click me!":|, |M:Clicked:|)

|C:// Disabled button:|
|T:Button:|(|S:"Disabled button":|, |M:Clicked:|)
    .|T:isEnabled:|(|K:false:|)
    
|C:// Button with styling:|
|T:HStack:|(spacing = |V:15.:|) {
    |T:Button:|(|S:"Decrement":|, |M:Decrement:|)
        .|T:backgroundColor:|(|S:"#FF0000":|)
        .|T:textColor:|(|S:"#FFFFFF":|)
        .|T:padding:|(|V:5.:|)
    
    |T:Label:|(|S:"Count: {:|model.|P:Count:||S:}":|)
        .|T:centerTextVertical:|()
    
    |T:Button:|(|S:"Increment":|, |M:Increment:|)
        .|T:textColor:|(|S:"#43ab2f":|)
        .|T:padding:|(|V:5.:|)
)
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