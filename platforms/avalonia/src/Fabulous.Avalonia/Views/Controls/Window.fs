namespace Fabulous.Avalonia

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous

type IFabWindow =
    inherit IFabWindowBase

[<AllowNullLiteral>]
type FabWindow() =
    inherit Window()

    let mutable _windowId = ""

    member this.WindowId
        with get () = _windowId
        and set value = _windowId <- value

module Window =
    let WidgetKey = Widgets.register<FabWindow>()

    let SizeToContent =
        Attributes.defineAvaloniaPropertyWithEquality Window.SizeToContentProperty

    let ExtendClientAreaToDecorationsHint =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaToDecorationsHintProperty

    let ExtendClientAreaChromeHints =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaChromeHintsProperty

    let ExtendClientAreaTitleBarHeightHint =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaTitleBarHeightHintProperty

    let SystemDecorations =
        Attributes.defineAvaloniaPropertyWithEquality Window.SystemDecorationsProperty

    let ShowActivated =
        Attributes.defineAvaloniaPropertyWithEquality Window.ShowActivatedProperty

    let ShowInTaskbar =
        Attributes.defineAvaloniaPropertyWithEquality Window.ShowInTaskbarProperty

    let WindowState =
        Attributes.defineAvaloniaPropertyWithEquality Window.WindowStateProperty

    let Title = Attributes.defineAvaloniaPropertyWithEquality Window.TitleProperty

    let IconSource = Attributes.defineBindableWindowIconSource Window.IconProperty

    let WindowStartupLocation =
        Attributes.defineAvaloniaPropertyWithEquality Window.WindowStartupLocationProperty

    let CanResize =
        Attributes.defineAvaloniaPropertyWithEquality Window.CanResizeProperty

    let WindowId =
        Attributes.defineSimpleScalarWithEquality<string> "WindowId" (fun _ newValueOpt node ->
            let target = node.Target :?> FabWindow

            match newValueOpt with
            | ValueSome id -> target.WindowId <- id
            | ValueNone -> target.WindowId <- "")

[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a Window widget.</summary>
        /// <param name="content">The content of the window.</param>
        static member Window(content: WidgetBuilder<'msg, #IFabElement>) =
            WidgetBuilder<'msg, IFabWindow>(Window.WidgetKey, ContentControl.ContentWidget.WithValue(content.Compile()))

type WindowModifiers =
    /// <summary>Sets the SizeToContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SizeToContent value.</param>
    [<Extension>]
    static member inline sizeToContent(this: WidgetBuilder<'msg, #IFabWindow>, value: SizeToContent) =
        this.AddScalar(Window.SizeToContent.WithValue(value))

    /// <summary>Sets the ExtendClientAreaToDecorationsHint property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ExtendClientAreaToDecorationsHint value.</param>
    [<Extension>]
    static member inline extendClientAreaToDecorationsHint(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ExtendClientAreaToDecorationsHint.WithValue(value))

    /// <summary>Sets the ExtendClientAreaChromeHints property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ExtendClientAreaChromeHints value.</param>
    [<Extension>]
    static member inline extendClientAreaChromeHints(this: WidgetBuilder<'msg, #IFabWindow>, value: ExtendClientAreaChromeHints) =
        this.AddScalar(Window.ExtendClientAreaChromeHints.WithValue(value))

    /// <summary>Sets the ExtendClientAreaTitleBarHeightHint property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline extendClientAreaTitleBarHeightHint(this: WidgetBuilder<'msg, #IFabWindow>, value: float) =
        this.AddScalar(Window.ExtendClientAreaTitleBarHeightHint.WithValue(value))

    /// <summary>Sets the SystemDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemDecorations value.</param>
    [<Extension>]
    static member inline systemDecorations(this: WidgetBuilder<'msg, #IFabWindow>, value: SystemDecorations) =
        this.AddScalar(Window.SystemDecorations.WithValue(value))

    /// <summary>Sets the ShowActivated property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowActivated value.</param>
    [<Extension>]
    static member inline showActivated(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ShowActivated.WithValue(value))

    /// <summary>Sets the ShowInTaskbar property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowInTaskbar value.</param>
    [<Extension>]
    static member inline showInTaskbar(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ShowInTaskbar.WithValue(value))

    /// <summary>Sets the WindowState property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WindowState value.</param>
    [<Extension>]
    static member inline windowState(this: WidgetBuilder<'msg, #IFabWindow>, value: WindowState) =
        this.AddScalar(Window.WindowState.WithValue(value))

    /// <summary>Sets the Title property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Title value.</param>
    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IFabWindow>, value: string) =
        this.AddScalar(Window.Title.WithValue(value))

    /// <summary>Sets the WindowStartupLocation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WindowStartupLocation value.</param>
    [<Extension>]
    static member inline windowStartupLocation(this: WidgetBuilder<'msg, #IFabWindow>, value: WindowStartupLocation) =
        this.AddScalar(Window.WindowStartupLocation.WithValue(value))

    /// <summary>Sets the CanResize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanResize value.</param>
    [<Extension>]
    static member inline canResize(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.CanResize.WithValue(value))

    /// <summary>Sets the WindowId property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WindowId value.</param>
    [<Extension>]
    static member inline windowId(this: WidgetBuilder<'msg, #IFabWindow>, value: string) =
        this.AddScalar(Window.WindowId.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Window control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabWindow>, value: ViewRef<Window>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type WindowExtraModifiers =
    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabWindow>, value: Bitmap) =
        this.AddScalar(Window.IconSource.WithValue(ImageSourceValue.Bitmap(value)))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabWindow>, value: string) =
        this.AddScalar(Window.IconSource.WithValue(ImageSourceValue.File(value)))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabWindow>, value: Stream) =
        this.AddScalar(Window.IconSource.WithValue(ImageSourceValue.Stream(value)))
