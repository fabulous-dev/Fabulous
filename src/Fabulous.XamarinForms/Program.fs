namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms.Widgets

module Program =
    let private define<'arg, 'model, 'msg, 'view when 'view :> IWidgetBuilder<'msg>> (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) (view: 'model -> 'view) =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          View = fun model -> (view model).Compile()
          CanReuseView = Helpers.canReuseView }

    let statelessApplication (view: unit -> #IApplicationWidgetBuilder<unit>) =
        define
            (fun () -> (), Cmd.none)
            (fun () () -> (), Cmd.none)
            view

    let statefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidgetBuilder<'msg>> (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> 'view) =
        define
            (fun arg -> init arg, Cmd.none)
            (fun msg model -> update msg model, Cmd.none)
            view
            
    let statefulApplicationWithCmd<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidgetBuilder<'msg>> (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) (view: 'model -> 'view) =
        define init update view
        
    let statefulApplicationWithCmdMsg<'arg, 'model, 'msg, 'view, 'cmdMsg when 'view :> IApplicationWidgetBuilder<'msg>> (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (view: 'model -> 'view) (mapCmd: 'cmdMsg -> Cmd<'msg>) =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch
        define
            (fun arg -> let m, c = init arg in m, mapCmds c)
            (fun msg model -> let m, c = update msg model in m, mapCmds c)
            view

    let create<'arg, 'model, 'msg> (program: Program<'arg, 'model, 'msg>) (arg: 'arg) =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create runner ViewNode.getViewNode program.CanReuseView
        adapter.CreateView() |> unbox