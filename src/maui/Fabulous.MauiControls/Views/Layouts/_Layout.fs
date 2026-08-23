namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabLayout =
    inherit IFabView

module Layout =
    let CascadeInputTransparent =
        Attributes.defineBindableBool Layout.CascadeInputTransparentProperty

    let IgnoreSafeArea =
        Attributes.defineSmallScalar "Layout_IgnoreSafeArea" SmallScalars.Bool.decode (fun prevOpt currOpt node ->
            let target = node.Target :?> Layout

            match struct (prevOpt, currOpt) with
            | ValueNone, ValueNone -> ()
            | ValueSome _, ValueNone -> target.IgnoreSafeArea <- false
            | _, ValueSome value -> target.IgnoreSafeArea <- value)

    let IsClippedToBounds =
        Attributes.defineBindableBool Layout.IsClippedToBoundsProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Layout.PaddingProperty

[<Extension>]
type LayoutModifiers =
    /// <summary>Set whether the input transparency is cascaded to children</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the input transparency is cascaded</param>
    [<Extension>]
    static member inline cascadeInputTransparent(this: WidgetBuilder<'msg, #IFabLayout>, value: bool) =
        this.AddScalar(Layout.CascadeInputTransparent.WithValue(value))

    /// <summary>Set whether the layout can extend inside the safe area on iOS</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">false, the layout is constrained outside the safe area; true, the layout can extend into the safe area</param>
    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<'msg, #IFabLayout>, value: bool) =
        this.AddScalar(Layout.IgnoreSafeArea.WithValue(value))

    /// <summary>Set whether the content is clipped to the layout's bounds</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the content will be clipped</param>
    [<Extension>]
    static member inline isClippedToBounds(this: WidgetBuilder<'msg, #IFabLayout>, value: bool) =
        this.AddScalar(Layout.IsClippedToBounds.WithValue(value))

    /// <summary>Set the padding inside the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The padding value</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLayout>, value: Thickness) =
        this.AddScalar(Layout.Padding.WithValue(value))

[<Extension>]
type LayoutExtraModifiers =
    /// <summary>Allow the layout to extend into the safe area</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<'msg, #IFabLayout>) = this.ignoreSafeArea(true)

    /// <summary>Set the padding inside the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The uniform padding value that will be applied to all sides</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLayout>, uniformSize: float) = this.padding(Thickness(uniformSize))

    /// <summary>Set the padding inside the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="left">The left padding value</param>
    /// <param name="top">The top padding value</param>
    /// <param name="right">The right padding value</param>
    /// <param name="bottom">The bottom padding value</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLayout>, left: float, top: float, right: float, bottom: float) =
        this.padding(Thickness(left, top, right, bottom))
