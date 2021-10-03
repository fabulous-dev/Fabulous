namespace Fabulous.Maui.Widgets

open Fabulous

type IApplicationWidget = inherit IWidget
type IWindowWidget = inherit IWidget
type IViewWidget = inherit IWidget

type IApplicationWidget<'msg> =
    inherit IApplicationWidget
    inherit ITypedWidget<'msg>

type IWindowWidget<'msg> =
    inherit IWindowWidget
    inherit ITypedWidget<'msg>

type IViewWidget<'msg> =
    inherit IViewWidget
    inherit ITypedWidget<'msg>