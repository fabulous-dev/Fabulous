namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabContentControl =
    inherit IFabTemplatedControl

module ContentControl =
    let ContentWidget =
        Attributes.defineAvaloniaPropertyWidget ContentControl.ContentProperty

    let ContentString =
        Attributes.defineAvaloniaProperty<string, obj> ContentControl.ContentProperty box ScalarAttributeComparers.equalityCompare

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ContentControl.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ContentControl.VerticalContentAlignmentProperty

type ContentControlModifiers =
    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabContentControl>, value: HorizontalAlignment) =
        this.AddScalar(ContentControl.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabContentControl>, value: VerticalAlignment) =
        this.AddScalar(ContentControl.VerticalContentAlignment.WithValue(value))

    /// <summary>Sets the HorizontalContentAlignment property to Center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerContentHorizontal(this: WidgetBuilder<'msg, #IFabContentControl>) =
        this.horizontalContentAlignment(HorizontalAlignment.Center)

    /// <summary>Sets the VerticalContentAlignment property to Center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerContentVertical(this: WidgetBuilder<'msg, #IFabContentControl>) =
        this.verticalContentAlignment(VerticalAlignment.Center)

    // <summary>Sets the HorizontalContentAlignment and VerticalContentAlignment properties to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabContentControl>) =
        this.centerContentHorizontal().centerContentVertical()
