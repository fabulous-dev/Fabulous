namespace Fabulous.Maui.Widgets

open Fabulous.Widgets.Controls

type IApplicationControlWidget<'msg> =
    inherit IApplicationWidget<'msg>
    inherit IControlWidget

type IWindowControlWidget<'msg> =
    inherit IWindowWidget<'msg>
    inherit IControlWidget

type IViewControlWidget<'msg> =
    inherit IViewWidget<'msg>
    inherit IControlWidget