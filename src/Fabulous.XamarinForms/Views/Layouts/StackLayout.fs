namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IStackLayout =
    inherit ILayoutOfView

module StackLayout =
    let WidgetKey = Widgets.register<StackLayout>()

    let Orientation =
        Attributes.defineBindableEnum<StackOrientation> StackLayout.OrientationProperty

    let Spacing =
        Attributes.defineBindableFloat StackLayout.SpacingProperty

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

[<Extension>]
type StackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct StackLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IStackLayout>, value: ViewRef<StackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
