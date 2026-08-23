namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Data.Converters
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open System.Globalization
open System.Runtime.CompilerServices

module NumericUpDownUpdaters =
    let updateNumericUpDownMinMax _ (newValueOpt: struct (decimal * decimal) voption) (node: IViewNode) =
        let numericUpDown = node.Target :?> NumericUpDown

        match newValueOpt with
        | ValueNone ->
            numericUpDown.ClearValue(NumericUpDown.MinimumProperty)
            numericUpDown.ClearValue(NumericUpDown.MaximumProperty)
        | ValueSome(min, max) ->
            let currMax = numericUpDown.GetValue(NumericUpDown.MaximumProperty)

            if min > currMax then
                numericUpDown.SetValue(NumericUpDown.MaximumProperty, max) |> ignore
                numericUpDown.SetValue(NumericUpDown.MinimumProperty, min) |> ignore
            else
                numericUpDown.SetValue(NumericUpDown.MinimumProperty, min) |> ignore
                numericUpDown.SetValue(NumericUpDown.MaximumProperty, max) |> ignore

type IFabNumericUpDown =
    inherit IFabTemplatedControl

module NumericUpDown =
    let WidgetKey = Widgets.register<NumericUpDown>()

    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (decimal * decimal)> "NumericUpDown_MinimumMaximum" NumericUpDownUpdaters.updateNumericUpDownMinMax

    let AllowSpin =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.AllowSpinProperty

    let ButtonSpinnerLocation =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ButtonSpinnerLocationProperty

    let ClipValueToMinMax =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ClipValueToMinMaxProperty

    let FormatString =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.FormatStringProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.VerticalContentAlignmentProperty

    let Increment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.IncrementProperty

    let IsReadOnly =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.IsReadOnlyProperty

    let Maximum =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.MaximumProperty

    let Minimum =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.MinimumProperty

    let NumberFormat =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.NumberFormatProperty

    let ParsingNumberStyle =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ParsingNumberStyleProperty

    let ShowButtonSpinner =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ShowButtonSpinnerProperty

    let Text = Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.TextProperty

    let TextConverter =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.TextConverterProperty

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.WatermarkProperty

    let TextAlignment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.TextAlignmentProperty


type NumericUpDownModifiers =

    /// <summary>Sets the AllowSpin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowSpin value.</param>
    [<Extension>]
    static member inline allowSpin(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.AllowSpin.WithValue(value))

    /// <summary>Sets the ButtonSpinnerLocation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ButtonSpinnerLocation value.</param>
    [<Extension>]
    static member inline buttonSpinnerLocation(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: Location) =
        this.AddScalar(NumericUpDown.ButtonSpinnerLocation.WithValue(value))

    /// <summary>Sets the ClipValueToMinMax property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClipValueToMinMax value.</param>
    [<Extension>]
    static member inline clipValueToMinMax(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.ClipValueToMinMax.WithValue(value))

    /// <summary>Sets the FormatString property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FormatString value.</param>
    [<Extension>]
    static member inline formatString(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.FormatString.WithValue(value))

    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: HorizontalAlignment) =
        this.AddScalar(NumericUpDown.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: VerticalAlignment) =
        this.AddScalar(NumericUpDown.VerticalContentAlignment.WithValue(value))

    /// <summary>Sets the Increment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Increment value.</param>
    [<Extension>]
    static member inline increment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: float) =
        this.AddScalar(NumericUpDown.Increment.WithValue(decimal value))

    /// <summary>Sets the IsReadOnly property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsReadOnly value.</param>
    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.IsReadOnly.WithValue(value))

    /// <summary>Sets the NumberFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NumberFormat value.</param>
    [<Extension>]
    static member inline numberFormat(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: NumberFormatInfo) =
        this.AddScalar(NumericUpDown.NumberFormat.WithValue(value))

    /// <summary>Sets the ParsingNumberStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ParsingNumberStyle value.</param>
    [<Extension>]
    static member inline parsingNumberStyle(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: NumberStyles) =
        this.AddScalar(NumericUpDown.ParsingNumberStyle.WithValue(value))

    /// <summary>Sets the ShowButtonSpinner property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowButtonSpinner value.</param>
    [<Extension>]
    static member inline showButtonSpinner(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.ShowButtonSpinner.WithValue(value))

    /// <summary>Sets the Text property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Text value.</param>
    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.Text.WithValue(value))

    /// <summary>Sets the TextConverter property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextConverter value.</param>
    [<Extension>]
    static member inline textConverter(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: IValueConverter) =
        this.AddScalar(NumericUpDown.TextConverter.WithValue(value))

    /// <summary>Sets the Watermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Watermark value.</param>
    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.Watermark.WithValue(value))

    /// <summary>Sets the TextAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextAlignment value.</param>
    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: TextAlignment) =
        this.AddScalar(NumericUpDown.TextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct NumericUpDown control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNumericUpDown>, value: ViewRef<NumericUpDown>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
