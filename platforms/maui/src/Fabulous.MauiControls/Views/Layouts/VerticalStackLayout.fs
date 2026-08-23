namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabVerticalStackLayout =
    inherit IFabStackBase

module VerticalStackLayout =
    let WidgetKey = Widgets.register<VerticalStackLayout>()

[<AutoOpen>]
module VerticalStackLayoutBuilders =
    type Fabulous.Maui.View with

        /// <summary>Creates a VStack widget</summary>
        static member inline VStack<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabVerticalStackLayout, IFabView>(VerticalStackLayout.WidgetKey, LayoutOfView.Children)

        /// <summary>Creates a VStack widget with spacing between children</summary>
        /// <param name="spacing">The spacing between children</param>
        static member inline VStack<'msg when 'msg: equality>(spacing: float) =
            CollectionBuilder<'msg, IFabVerticalStackLayout, IFabView>(
                VerticalStackLayout.WidgetKey,
                LayoutOfView.Children,
                StackBase.Spacing.WithValue(spacing)
            )

[<Extension>]
type VerticalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct VerticalStackLayout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabVerticalStackLayout>, value: ViewRef<VerticalStackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
