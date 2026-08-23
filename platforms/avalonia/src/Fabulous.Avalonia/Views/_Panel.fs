namespace Fabulous.Avalonia

open Avalonia.Controls

type IFabPanel =
    inherit IFabControl

module Panel =
    let WidgetKey = Widgets.register<Panel>()

    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Panel.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality Panel.BackgroundProperty

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)
