namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms.Widgets

module Program =
    let statelessApplication (view: unit -> #IApplicationWidgetBuilder<unit>) =
        { Init = ignore
          Update = ignore
          View = fun () -> (view ()).Compile() } : Program<unit, unit, unit>

    let statefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidgetBuilder<'msg>> (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> 'view) =
        { Init = init
          Update = fun (msg, model) -> update msg model
          View = fun model -> (view model).Compile() }

    let getViewNode (target: obj) =
        let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> ViewNodeData
        viewNodeData.ViewNode :> IViewNode

    let create<'arg, 'model, 'msg> (program: Program<'arg, 'model, 'msg>) (arg: 'arg) =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create runner getViewNode
        adapter.CreateView() |> unbox