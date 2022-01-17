namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IMenuItem =
    inherit IElement

module MenuItem =
    let WidgetKey = Widgets.register<MenuItem>()

    let Text =
        Attributes.defineBindable<string> MenuItem.TextProperty

    let Clicked =
        Attributes.defineEventNoArg "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Clicked)
        
[<AutoOpen>]
module MenuItemBuilders =
    type Fabulous.XamarinForms.View with
        static member inline MenuItem<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IMenuItem>(
                MenuItem.WidgetKey,
                MenuItem.Text.WithValue(text),
                MenuItem.Clicked.WithValue(onClicked)
            )