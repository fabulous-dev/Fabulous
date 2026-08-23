namespace Gallery

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

type SampleProgram =
    { init: unit -> obj
      update: obj -> obj -> obj
      view: obj -> WidgetBuilder<obj, IFabView> }

type Sample =
    { Name: string
      Description: string
      Program: SampleProgram }

module Helper =
    let createProgram (init: unit -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { init = init >> box
          update = (fun msg model -> update (unbox msg) (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view(unbox model)))) }

    let createStatelessProgram (view: unit -> WidgetBuilder<'msg, 'marker>) =
        { init = fun () -> box()
          update = (fun _ model -> model)
          view = (fun model -> AnyView(View.map box (view(unbox model)))) }
