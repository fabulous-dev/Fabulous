namespace Fabulous.Maui

open Fabulous

type IApplicationWidget = inherit IWidget
type IWindowWidget = inherit IWidget
type IViewWidget = inherit IWidget

type StatefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget and 'view :> IWidget> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> Attribute[] -> 'view }
    interface IApplicationWidget with
        member x.CreateView() = failwith "todo"
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model, attributes) = x.View model attributes

type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IViewWidget and 'view :> IWidget> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> Attribute[] -> 'view }
    interface IViewWidget with
        member x.CreateView() = failwith "todo"
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model, attributes) = x.View model attributes
    
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

type StatelessView<'view when 'view :> IViewWidget and 'view :> IWidget> =
    { View: Attribute[] -> 'view }
    interface IViewWidget with
        member x.CreateView() = failwith "todo"
    interface IStatelessWidget<'view> with
        member x.View(attrs) = x.View attrs
        
module StatelessWidget =
    let mkSimpleView view : StatelessView<_> =
        { View = view }