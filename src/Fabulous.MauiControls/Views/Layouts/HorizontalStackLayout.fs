namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IHorizontalStackLayout =
    inherit IStackBase

module HorizontalStackLayout =
    let WidgetKey =
        Widgets.register<HorizontalStackLayout>()

[<AutoOpen>]
module HorizontalStackLayoutBuilders =
    type Fabulous.Maui.View with
        static member inline HStack<'msg>(?spacing: float) =
            match spacing with
            | None ->
                CollectionBuilder<'msg, IHorizontalStackLayout, Fabulous.Maui.IView>(
                    HorizontalStackLayout.WidgetKey,
                    LayoutOfView.Children
                )
            | Some v ->
                CollectionBuilder<'msg, IHorizontalStackLayout, Fabulous.Maui.IView>(
                    HorizontalStackLayout.WidgetKey,
                    LayoutOfView.Children,
                    StackBase.Spacing.WithValue(v)
                )

[<Extension>]
type HorizontalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct HorizontalStackLayout control instance</summary>
    [<Extension>]
    static member inline reference
        (
            this: WidgetBuilder<'msg, IHorizontalStackLayout>,
            value: ViewRef<HorizontalStackLayout>
        ) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
