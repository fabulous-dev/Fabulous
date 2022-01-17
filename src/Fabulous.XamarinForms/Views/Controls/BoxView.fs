namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IBoxView =
    inherit IView
    
module BoxView =
    let WidgetKey = Widgets.register<BoxView>()

    let Color =
        Attributes.defineBindable<Color> BoxView.ColorProperty

[<AutoOpen>]
module BoxViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline BoxView<'msg>(color: Color) =
            WidgetBuilder<'msg, IBoxView>(BoxView.WidgetKey, BoxView.Color.WithValue(color))