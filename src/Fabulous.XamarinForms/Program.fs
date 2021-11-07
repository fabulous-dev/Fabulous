namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms.Widgets

module Program =
    let statelessApplication (view: unit -> #IApplicationWidgetBuilder<unit>) =
        { Init = ignore
          Update = ignore
          View = fun () -> (view ()).Compile() } : Program<unit, unit, unit>

    let getViewNode (target: obj) =
        (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNode.ViewNodeProperty) :?> IViewNode

    let create<'arg, 'model, 'msg> (program: Program<'arg, 'model, 'msg>) (arg: 'arg) =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create runner getViewNode
        adapter.CreateView() |> unbox