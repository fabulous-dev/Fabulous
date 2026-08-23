namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabAdornerLayer =
    inherit IFabCanvas

module AdornerLayer =
    let AdornedElement =
        Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornedElementProperty

    let Adorner = Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornerProperty

    let IsIsClipEnabled =
        Attributes.defineAvaloniaPropertyWithEquality AdornerLayer.IsClipEnabledProperty

type AdornerLayerAttachedModifiers =
    /// <summary>Sets the Adorner property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Adorner value.</param>
    [<Extension>]
    static member inline adorner(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(AdornerLayer.Adorner.WithValue(value.Compile()))

    /// <summary>Sets the AdornedElement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AdornedElement value.</param>
    [<Extension>]
    static member inline adornedElement(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabVisual>) =
        this.AddWidget(AdornerLayer.AdornedElement.WithValue(value.Compile()))

    /// <summary>Sets the IsClipEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsClipEnabled value.</param>
    [<Extension>]
    static member inline isClipEnabled(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(AdornerLayer.IsIsClipEnabled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
