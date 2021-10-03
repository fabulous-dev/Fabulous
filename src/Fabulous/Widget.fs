namespace Fabulous

type ViewTreeContext =
    { Dispatch: obj -> unit }

[<Struct; RequireQualifiedAccess>]
type AttributeDiff =
    | Identical
    | NewValue of obj

[<Struct; RequireQualifiedAccess>]
type WidgetDiff =
    | Identical
    | ReplacedBy of newWidget: IWidget
    | Updated of attributeDiffs: AttributeDiff array

and IViewNode =
    abstract Context: ViewTreeContext
    abstract SetContext: ViewTreeContext -> unit
    abstract ApplyDiff: WidgetDiff -> unit

and IWidget =
    abstract CreateView: ViewTreeContext -> IViewNode

type ITypedWidget<'msg> = inherit IWidget

type [<Struct>] RunnerKey = RunnerKey of int

/// Logical element without state able to generate a logical tree composed of child widgets
type IStatelessWidget<'view when 'view :> IWidget> =
    abstract View: unit -> 'view 

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type IStatefulWidget<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
    abstract State: RunnerKey option
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model -> 'view
