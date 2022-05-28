namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ISwipeItem =
    inherit IMenuItem

module SwipeItem =

    let WidgetKey = Widgets.register<SwipeItem>()

    let BackgroundColor =
        Attributes.defineBindableAppThemeColor SwipeItem.BackgroundColorProperty

    let IsVisible =
        Attributes.defineBindableBool SwipeItem.IsVisibleProperty

    let Clicked =
        Attributes.defineEvent "SwipeItem_Invoked" (fun target -> (target :?> SwipeItem).Invoked)

[<AutoOpen>]
module SwipeItemBuilders =

    type Fabulous.XamarinForms.View with
        static member inline SwipeItem<'msg>(onInvoked: 'msg) =
            WidgetBuilder<'msg, ISwipeItem>(SwipeItem.WidgetKey, SwipeItem.Clicked.WithValue(fun _ -> onInvoked |> box))

[<Extension>]
type SwipeItemModifiers() =

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #ISwipeItem>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SwipeItem.BackgroundColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #ISwipeItem>, value: bool) =
        this.AddScalar(SwipeItem.IsVisible.WithValue(value))

    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #ISwipeItem>, value: string) =
        this.AddScalar(MenuItem.Text.WithValue(value))

    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISwipeItem>, value: ViewRef<SwipeItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
