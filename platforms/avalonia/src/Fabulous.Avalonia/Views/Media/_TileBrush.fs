namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabTileBrush =
    inherit IFabBrush

module TileBrush =
    let AlignmentX =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.AlignmentXProperty

    let AlignmentY =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.AlignmentYProperty

    let DestinationRect =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.DestinationRectProperty

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.SourceRectProperty

    let Stretch =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.StretchProperty

    let TileMode =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.TileModeProperty

type TileBrushModifiers =

    /// <summary>Sets the AlignmentX property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AlignmentX value.</param>
    [<Extension>]
    static member inline alignmentX(this: WidgetBuilder<'msg, #IFabTileBrush>, value: AlignmentX) =
        this.AddScalar(TileBrush.AlignmentX.WithValue(value))

    /// <summary>Sets the AlignmentY property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AlignmentY value.</param>
    [<Extension>]
    static member inline alignmentY(this: WidgetBuilder<'msg, #IFabTileBrush>, value: AlignmentY) =
        this.AddScalar(TileBrush.AlignmentY.WithValue(value))

    /// <summary>Sets the DestinationRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DestinationRect value.</param>
    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, value: RelativeRect) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(value))

    /// <summary>Sets the DestinationRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="rect">The Rect value.</param>
    /// <param name="unit">The RelativeUnit value.</param>
    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, rect: Rect, unit: RelativeUnit) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(RelativeRect(rect, unit)))

    /// <summary>Sets the DestinationRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="rect">The Rect value.</param>
    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, rect: Rect) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(RelativeRect(rect, RelativeUnit.Relative)))

    /// <summary>Sets the DestinationRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="point">The Point value.</param>
    /// <param name="size">The Size value.</param>
    /// <param name="unit">The RelativeUnit value.</param>
    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, point: Point, size: Size, unit: RelativeUnit) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(RelativeRect(point, size, unit)))

    /// <summary>Sets the SourceRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SourceRect value.</param>
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, value: RelativeRect) =
        this.AddScalar(TileBrush.SourceRect.WithValue(value))

    /// <summary>Sets the SourceRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="rect">The Rect value.</param>
    /// <param name="unit">The RelativeUnit value.</param>
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, rect: Rect, unit: RelativeUnit) =
        this.AddScalar(TileBrush.SourceRect.WithValue(RelativeRect(rect, unit)))

    /// <summary>Sets the SourceRect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="point">The Point value.</param>
    /// <param name="size">The Size value.</param>
    /// <param name="unit">The RelativeUnit value.</param>
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, point: Point, size: Size, unit: RelativeUnit) =
        this.AddScalar(TileBrush.SourceRect.WithValue(RelativeRect(point, size, unit)))

    /// <summary>Sets the Stretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stretch value.</param>
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabTileBrush>, value: Stretch) =
        this.AddScalar(TileBrush.Stretch.WithValue(value))

    /// <summary>Sets the TileMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TileMode value.</param>
    [<Extension>]
    static member inline tileMode(this: WidgetBuilder<'msg, #IFabTileBrush>, value: TileMode) =
        this.AddScalar(TileBrush.TileMode.WithValue(value))
