namespace Fabulous.Maui.Widgets

open Fabulous

type StatefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IApplicationWidget<'msg> with
        member x.CreateView(context) = failwith "todo"
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View model
        
type StatefulWindow<'arg, 'model, 'msg, 'view when 'view :> IWindowWidget<'msg>> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IWindowWidget<'msg> with
        member x.CreateView(context) = failwith "todo"
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View model

type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IViewWidget<'msg>> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> 'view }
    interface IViewWidget<'msg> with
        member x.CreateView(context) = failwith "todo"
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model) = x.View model
    
module StatefulWidget =
    let mkSimpleView init update view : StatefulView<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }
        
    let mkSimpleApp init update view : StatefulApplication<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }

type StatelessView<'view when 'view :> IViewWidget<unit>> =
    { View: unit -> 'view }
    interface IViewWidget<unit> with
        member x.CreateView(context) = failwith "todo"
    interface IStatelessWidget<'view> with
        member x.View() = x.View()
        
module StatelessWidget =
    let mkSimpleView view : StatelessView<_> =
        { View = view }