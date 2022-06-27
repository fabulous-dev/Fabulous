namespace Gallery

open Fabulous
open Fabulous.XamarinForms
open Gallery.Samples

open type Fabulous.XamarinForms.View

module WidgetPage =
    type Model =
        { Sample: Sample
          SampleModel: obj }

    type Msg =
        | SampleMsg of obj
        
    let init index =
        let sample = Registry.getForIndex index
        { Sample = sample
          SampleModel = sample.Program.init() }
        
    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with
                SampleModel = sampleModel }
        
    let view model =
        ContentPage(
            model.Sample.Description.Name,
            VStack() {
                Label(model.Sample.Description.Name)
                Label(model.Sample.Description.Description)
                
                View.map SampleMsg (model.Sample.Program.view model.SampleModel)
            }
        )