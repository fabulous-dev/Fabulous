namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabHorizontalStackLayout =
    inherit IFabStackBase

module HorizontalStackLayout =
    let WidgetKey = Widgets.register<HorizontalStackLayout>()

[<AutoOpen>]
module HorizontalStackLayoutBuilders =
    type Fabulous.Maui.View with

        /// <summary>Creates a HStack widget</summary>
        static member inline HStack<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabHorizontalStackLayout, IFabView>(HorizontalStackLayout.WidgetKey, LayoutOfView.Children)

        /// <summary>Creates a HStack widget with spacing between children</summary>
        /// <param name="spacing">The spacing between children</param>
        static member inline HStack<'msg when 'msg: equality>(spacing: float) =
            CollectionBuilder<'msg, IFabHorizontalStackLayout, IFabView>(
                HorizontalStackLayout.WidgetKey,
                LayoutOfView.Children,
                StackBase.Spacing.WithValue(spacing)
            )

[<Extension>]
type HorizontalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct HorizontalStackLayout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHorizontalStackLayout>, value: ViewRef<HorizontalStackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
