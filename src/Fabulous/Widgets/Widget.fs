namespace Fabulous.Widgets

type IWidget =
    abstract CreateView: unit -> obj

type ITypedWidget<'msg> = inherit IWidget