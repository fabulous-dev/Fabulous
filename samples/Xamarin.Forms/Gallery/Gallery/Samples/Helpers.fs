namespace Gallery.Samples

open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

type SampleProgram =
    { init: unit -> obj
      update: obj -> obj -> obj
      view: obj -> WidgetBuilder<obj, IView> }
    
type Sample =
    { Name: string
      Description: string
      SourceFilename: string
      SourceLink: string
      DocumentationName: string
      DocumentationLink: string
      SampleCode: string
      SampleCodeFormatted: unit -> WidgetBuilder<obj, IView>
      Program: SampleProgram }

module Helper =
    let createProgram (init: unit -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { init = init >> box
          update = (fun msg model -> update (unbox msg) (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view (unbox model)))) }
        
    let createSampleCodeFormatted (fn: unit -> WidgetBuilder<obj, IFormattedLabel>) =
        let fn2 () =
            AnyView(fn ())
        fn2