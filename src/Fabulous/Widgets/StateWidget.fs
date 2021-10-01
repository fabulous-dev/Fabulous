namespace Fabulous

open Fabulous.Widgets
open Fabulous.Widgets.Controls

type [<Struct>] RunnerKey = RunnerKey of int

/// Logical element without state able to generate a logical tree composed of child widgets
type IStatelessWidget<'view when 'view :> IWidget> =
    abstract View: Attribute[] -> 'view 

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type IStatefulWidget<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
    abstract State: RunnerKey option
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model * Attribute[] -> 'view

