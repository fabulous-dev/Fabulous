namespace Gallery

open Microsoft.Maui
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module Fonts =
    let OpenSansRegular = "OpenSansRegular"
    let OpenSansSemibold = "OpenSansSemibold"
    let OpenSansBold = "OpenSansBold"
    let SourceSansProRegular = "SourceSansProRegular"
    let SourceSansProBold = "SourceSansProBold"
    let SourceSansProBoldItalic = "SourceSansProBoldItalic"
    let SourceSansProItalic = "SourceSansProItalic"

module Styles =
    let inline title (widget: WidgetBuilder<'msg, #IFabLabel>) =
        widget.centerHorizontal().font(fontFamily = Fonts.OpenSansBold, size = 30.)

    let inline subtitle (widget: WidgetBuilder<'msg, #IFabLabel>) =
        widget.centerHorizontal().font(fontFamily = Fonts.OpenSansSemibold, size = 24.)
