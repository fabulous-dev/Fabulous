namespace Gallery.Samples

open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

type SampleDescription =
    { Name: string
      Description: string
      ApiRefLink: string
      XFDocLink: string
      SampleCode: string }

type SampleProgram =
    { init: unit -> obj
      update: obj -> obj -> obj
      view: obj -> WidgetBuilder<obj, IView> }
    
type Sample =
    { Description: SampleDescription
      Program: SampleProgram }

module Helper =
    let createProgram (init: unit -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { init = init >> box
          update = (fun msg model -> update (unbox msg) (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view (unbox model)))) }