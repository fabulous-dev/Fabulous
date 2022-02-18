namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IStackLayout =
    inherit ILayoutOfView

module StackLayout =
    let WidgetKey = Widgets.register<StackLayout> ()

    let Orientation =
        Attributes.defineBindable<StackOrientation> StackLayout.OrientationProperty

    let Spacing =
        Attributes.defineBindable<float> StackLayout.SpacingProperty

[<AutoOpen>]
module StackLayoutBuilders =
    type Fabulous.XamarinForms.View with
        static member inline private StackLayout<'msg>(orientation: StackOrientation, ?spacing: float) =
            match spacing with
            | None ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    StackLayout.WidgetKey,
                    LayoutOfView.Children,
                    StackLayout.Orientation.WithValue(orientation)
                )

            | Some v ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    StackLayout.WidgetKey,
                    LayoutOfView.Children,
                    StackLayout.Orientation.WithValue(orientation),
                    StackLayout.Spacing.WithValue(v)
                )

        static member inline HStack<'msg>(?spacing) =
            View.StackLayout<'msg>(StackOrientation.Horizontal, ?spacing = spacing)

        static member inline VStack<'msg>(?spacing) =
            View.StackLayout<'msg>(StackOrientation.Vertical, ?spacing = spacing)
