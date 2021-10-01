namespace Fabulous.Widgets

type ViewTreeContext =
    { Dispatch: obj -> unit }

type IWidget =
    abstract CreateView: ViewTreeContext -> obj

type ITypedWidget<'msg> = inherit IWidget