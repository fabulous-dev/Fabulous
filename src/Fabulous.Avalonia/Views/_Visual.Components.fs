namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentVisual =
    let AttachedToVisualTree =
        Attributes.Component.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).AttachedToVisualTree)

    let DetachedFromVisualTree =
        Attributes.Component.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).DetachedFromVisualTree)

type ComponentVisualModifiers =
    /// <summary>Listens to the Visual AttachedToVisualTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is attached to a rooted visual tree.</param>
    [<Extension>]
    static member inline onAttachedToVisualTree(this: WidgetBuilder<'msg, #IFabVisual>, fn: VisualTreeAttachmentEventArgs -> unit) =
        this.AddScalar(ComponentVisual.AttachedToVisualTree.WithValue(fn))

    /// <summary>Listens to the Visual DetachedFromVisualTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is detached from a rooted visual tree.</param>
    [<Extension>]
    static member inline onDetachedFromVisualTree(this: WidgetBuilder<'msg, #IFabVisual>, fn: VisualTreeAttachmentEventArgs -> unit) =
        this.AddScalar(ComponentVisual.DetachedFromVisualTree.WithValue(fn))

type ComponentVisualExtraModifiers =
    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: Color) =
        VisualModifiers.opacityMask(this, View.SolidColorBrush(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: string) =
        VisualModifiers.opacityMask(this, View.SolidColorBrush(value))
