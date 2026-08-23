namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabGridSplitter =
    inherit IFabTemplatedControl

module GridSplitter =
    let WidgetKey = Widgets.register<GridSplitter>()

    let ResizeDirection =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ResizeDirectionProperty

    let ResizeBehavior =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ResizeBehaviorProperty

    let ShowsPreview =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ShowsPreviewProperty

    let KeyboardIncrement =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.KeyboardIncrementProperty

    let DragIncrement =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.DragIncrementProperty

[<AutoOpen>]
module GridSplitterBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GridSplitter widget.</summary>
        static member GridSplitter() =
            WidgetBuilder<'msg, IFabGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(GridResizeDirection.Auto))

        /// <summary>Creates a GridSplitter widget.</summary>
        /// <param name="resizeDirection">The direction in which the GridSplitter can be resized.</param>
        static member GridSplitter(resizeDirection: GridResizeDirection) =
            WidgetBuilder<'msg, IFabGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(resizeDirection))


type GridSplitterModifiers =
    /// <summary>Sets the ResizeBehavior property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ResizeBehavior value.</param>
    [<Extension>]
    static member inline resizeBehavior(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: GridResizeBehavior) =
        this.AddScalar(GridSplitter.ResizeBehavior.WithValue(value))

    /// <summary>Sets the ShowsPreview property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowsPreview value.</param>
    [<Extension>]
    static member inline showsPreview(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: bool) =
        this.AddScalar(GridSplitter.ShowsPreview.WithValue(value))

    /// <summary>Sets the KeyboardIncrement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The KeyboardIncrement value.</param>
    [<Extension>]
    static member inline keyboardIncrement(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: float) =
        this.AddScalar(GridSplitter.KeyboardIncrement.WithValue(value))

    /// <summary>Sets the DragIncrement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DragIncrement value.</param>
    [<Extension>]
    static member inline dragIncrement(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: float) =
        this.AddScalar(GridSplitter.DragIncrement.WithValue(value))

    /// <summary>Link a ViewRef to access the direct GridSplitter control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGridSplitter>, value: ViewRef<GridSplitter>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
