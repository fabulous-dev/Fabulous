namespace Gallery.Samples

open Fabulous.XamarinForms
open Xamarin.Forms

open type Fabulous.XamarinForms.View

module Label =
    let view model =
        VStack(spacing = 15.) {
            Label("Regular label")
            
            Label("Label with styling")
                .backgroundColor("#FF0000")
                .textColor("#5dadb3")
                        
            Label("Default font with named size: Title")
                .font(NamedSize.Title)
                
            Label("Bold + NamedSize.Caption")
                .font(NamedSize.Caption, attributes = FontAttributes.Bold)
                
            Label("Size = 16 + FontFamily: Arial")
                .font(size = 16., fontFamily = "Arial")
        }
        
    let sampleCode = """
|C://Regular Label:|
|T:Label:|(|S:"Regular label":|)

|C://Label with styling:|
|T:Label:|(|S:"Label with styling":|)
    .|T:backgroundColor:|(|S:"#FF0000":|)
    .|T:textColor:|(|S:"#5dadb3":|)
    
|C://Label with different fonts:|
|T:Label:|(|S:"Default font with named size: Title":|)
    .|T:font:|(|M:NamedSize:|.|P:Title:|)
    
|T:Label:|(|S:"Bold + NamedSize.Caption":|)
    .|T:font:|(|M:NamedSize:|.|P:Caption:|, attributes = |M:FontAttributes:|.|P:Bold:|)
    
|T:Label:|(|S:"Size = 16 + FontFamily: Arial":|)
    .|T:font:|(|V:16.:|, fontFamily = |S:"Arial":|)
"""
        
    let sample =
        { Name = "Label"
          Description = "A widget that displays text."
          SourceFilename = "Views/Controls/Label.fs"
          SourceLink = "https://github.com/fsprojects/Fabulous/blob/v2.0/src/Fabulous.XamarinForms/Views/Controls/Label.fs"
          DocumentationName = "Label API reference"
          DocumentationLink = "https://docs.fabulous.dev/v2/api/controls/label"
          SampleCode = Helper.cleanMarkersFromSampleCode sampleCode
          SampleCodeFormatted = Helper.createSampleCodeFormatted sampleCode
          Program = Helper.createViewOnlyProgram view }