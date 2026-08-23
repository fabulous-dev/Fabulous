namespace Gallery

open System
open System.Diagnostics
open System.Globalization
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open Avalonia.Data.Converters

open type Fabulous.Avalonia.View

module NumericUpDownPage =
    type FormatObject = { Value: string; Name: string }

    type Model =
        { ShowButtonSpinner: bool
          IsReadOnly: bool
          AllowSpin: bool
          SpinnerLocations: string list
          Watermark: string
          Text: string
          ClipValueToMinMax: bool
          Cultures: CultureInfo list
          Formats: FormatObject list
          MinValue: float option
          MaxValue: float option
          IncrementValue: float option
          Value: float option
          DecimalValue: float option
          DoubleValue: float option
          NumberFormat: NumberFormatInfo
          SelectedFormat: FormatObject }

    type Msg =
        | ShowButtonSpinnerValueChanged of bool
        | IsReadOnlyValueChanged of bool
        | AllowSpinValueChanged of bool
        | ClipValueToMinMaxValueChanged of bool
        | WatermarkTextChanged of string
        | TextChanged of string
        | MinimumValueChanged of float option
        | MaximumValueChanged of float option
        | IncrementValueChanged of float option
        | DecimalValueChanged of float option
        | DoubleValueChanged of float option
        | ValueChanged of float option
        | CultureSelectionChanged of SelectionChangedEventArgs
        | SelectedFormatChanged of SelectionChangedEventArgs

    let init () =
        { MinValue = Some(1.)
          ShowButtonSpinner = false
          IsReadOnly = false
          AllowSpin = false
          ClipValueToMinMax = false
          Watermark = ""
          Text = ""
          SpinnerLocations = [ "Left"; "Right" ]
          Cultures =
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            |> Array.filter(fun x ->
                [| "en-US"; "en-GB"; "fr-FR"; "ar-DZ"; "zh-CH"; "cs-CZ" |]
                |> Array.contains x.Name)
            |> Array.toList
          Formats =
            [ { Name = "Currency"; Value = "C2" }
              { Name = "Fixed point"; Value = "F2" }
              { Name = "General"; Value = "G" }
              { Name = "Number"; Value = "N" }
              { Name = "Percent"; Value = "P" }
              { Name = "Degrees"; Value = "{0:N2} °" } ]
          MaxValue = None
          IncrementValue = None
          DecimalValue = None
          DoubleValue = None
          Value = None
          NumberFormat = CultureInfo.CurrentCulture.NumberFormat
          SelectedFormat = { Name = "Currency"; Value = "C2" } },
        Cmd.none

    let update msg model =
        match msg with
        | ShowButtonSpinnerValueChanged args -> { model with ShowButtonSpinner = args }, Cmd.none
        | IsReadOnlyValueChanged args -> { model with IsReadOnly = args }, Cmd.none
        | AllowSpinValueChanged args -> { model with AllowSpin = args }, Cmd.none
        | ClipValueToMinMaxValueChanged args -> { model with ClipValueToMinMax = args }, Cmd.none
        | WatermarkTextChanged s -> { model with Watermark = s }, Cmd.none
        | TextChanged s -> { model with Text = s }, Cmd.none
        | MinimumValueChanged min -> { model with MinValue = Some min.Value }, Cmd.none
        | MaximumValueChanged max -> { model with MaxValue = Some max.Value }, Cmd.none
        | IncrementValueChanged inc -> { model with IncrementValue = inc }, Cmd.none
        | DecimalValueChanged value -> { model with DecimalValue = value }, Cmd.none
        | CultureSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let culture = model.Cultures[control.SelectedIndex]

            { model with
                NumberFormat = culture.NumberFormat },
            Cmd.none

        | SelectedFormatChanged args ->
            let control = args.Source :?> ComboBox
            let format = model.Formats[control.SelectedIndex]
            { model with SelectedFormat = format }, Cmd.none

        | DoubleValueChanged value -> { model with DoubleValue = value }, Cmd.none

        | ValueChanged value -> { model with Value = value }, Cmd.none

    let cultureConverter () =
        { new IValueConverter with
            member this.Convert(value, targetType, parameter, culture) =
                if culture <> null then
                    CultureInfo.CurrentCulture.NumberFormat
                else
                    culture.NumberFormat

            member this.ConvertBack(value, targetType, parameter, culture) = () }

    let hexConverter () =
        { new IValueConverter with
            member this.Convert(value, targetType, parameter, culture) =
                let str = value.ToString()
                let mutable property = null

                if (str = null) then
                    property <- AvaloniaProperty.UnsetValue

                let isValid, x =
                    Int32.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture)

                if isValid then
                    property <- x

                property

            member this.ConvertBack(value, targetType, parameter, culture) =
                try
                    match value with
                    | :? decimal as x ->
                        let x = Decimal.ToInt32(x)
                        x.ToString("X8")
                    | _ -> AvaloniaProperty.UnsetValue
                with _ ->
                    AvaloniaProperty.UnsetValue }

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("NumericUpDownPage") {
            let! model = Context.Mvu program

            VStack(spacing = 4.) {
                TextBlock("Features:")
                    .margin(2., 5., 2., 2.)
                    .fontSize(14.)
                    .fontWeight(FontWeight.Bold)

                VWrap() {
                    Grid(coldefs = [ Auto; Auto ], rowdefs = [ Auto; Auto; Auto; Auto; Auto ]) {
                        TextBlock("ShowButtonSpinner:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)

                        CheckBox(model.ShowButtonSpinner, ShowButtonSpinnerValueChanged)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(0)
                            .gridColumn(1)

                        TextBlock("IsReadOnly:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(1)
                            .gridColumn(0)

                        CheckBox(model.IsReadOnly, IsReadOnlyValueChanged)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(1)
                            .gridColumn(1)

                        TextBlock("AllowSpin:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(2)
                            .gridColumn(0)

                        CheckBox(model.AllowSpin, AllowSpinValueChanged)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(2)
                            .gridColumn(1)

                        TextBlock("Number:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(3)
                            .gridColumn(0)

                        CheckBox(model.ClipValueToMinMax, ClipValueToMinMaxValueChanged)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(3)
                            .gridColumn(1)
                    }

                    (Grid(coldefs = [ Auto; Pixel(120.) ], rowdefs = [ Auto; Auto; Auto; Auto; Auto ]) {
                        TextBlock("FormatString:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)

                        ComboBox(
                            model.Formats,
                            fun format ->
                                HStack(2.) {
                                    TextBlock(format.Name)
                                    TextBlock("-")
                                    TextBlock(format.Value)
                                }
                        )
                            .gridRow(0)
                            .gridColumn(1)
                            .selectedIndex(0)
                            .margin(2.)
                            .verticalAlignment(VerticalAlignment.Center)
                            .onSelectionChanged(SelectedFormatChanged)

                        TextBlock("ButtonSpinnerLocation:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(1)
                            .gridColumn(0)

                        ComboBox(model.SpinnerLocations)
                            .gridRow(1)
                            .gridColumn(1)
                            .selectedIndex(0)
                            .margin(2.)
                            .verticalAlignment(VerticalAlignment.Center)

                        TextBlock("CultureInfo:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(2)
                            .gridColumn(0)

                        ComboBox(model.Cultures)
                            .gridRow(2)
                            .gridColumn(1)
                            .selectedIndex(0)
                            .margin(2.)
                            .verticalAlignment(VerticalAlignment.Center)
                            .onSelectionChanged(CultureSelectionChanged)

                        TextBlock("Watermark:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(3)
                            .gridColumn(0)

                        TextBox(model.Watermark, WatermarkTextChanged)
                            .gridRow(3)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)

                        TextBlock("Text:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(4)
                            .gridColumn(0)

                        TextBox(model.Text, TextChanged)
                            .gridRow(4)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                    })
                        .margin(8.)

                    Grid(coldefs = [ Auto; Auto ], rowdefs = [ Auto; Auto; Auto; Auto; Auto ]) {
                        TextBlock("Minimum:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(0)
                            .gridColumn(0)

                        NumericUpDown(0., 10., model.MinValue, MinimumValueChanged)
                            .numberFormat(model.NumberFormat)
                            .gridRow(0)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .horizontalAlignment(HorizontalAlignment.Center)

                        TextBlock("Maximum:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(1)
                            .gridColumn(0)

                        NumericUpDown(0., 10., model.MaxValue, MaximumValueChanged)
                            .numberFormat(model.NumberFormat)
                            .gridRow(1)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .horizontalAlignment(HorizontalAlignment.Center)

                        TextBlock("Increment:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(2)
                            .gridColumn(0)

                        NumericUpDown(0., 10., model.IncrementValue, IncrementValueChanged)
                            .gridRow(2)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .horizontalAlignment(HorizontalAlignment.Center)

                        TextBlock("Value:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .gridRow(3)
                            .gridColumn(0)

                        NumericUpDown(0., 10., model.DecimalValue, DecimalValueChanged)
                            .gridRow(3)
                            .gridColumn(1)
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(2.)
                            .horizontalAlignment(HorizontalAlignment.Center)
                    }
                }

                VWrap() {
                    VStack() {
                        TextBlock("Usage of decimal NumericUpDown:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .fontWeight(FontWeight.Bold)
                            .fontSize(14.)
                            .margin(2.)

                        NumericUpDown(0., 10., model.DecimalValue, DecimalValueChanged)
                            .increment(0.5)
                            .verticalAlignment(VerticalAlignment.Center)
                            .numberFormat(model.NumberFormat)
                            .formatString(model.SelectedFormat.Value)
                            .watermark("Enter text")
                            .textConverter(cultureConverter())
                            .margin(2.)
                    }

                    VStack() {
                        TextBlock("Usage of double NumericUpDown:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .fontWeight(FontWeight.Bold)
                            .fontSize(14.)
                            .margin(2.)

                        NumericUpDown(0., 10., model.DoubleValue, DoubleValueChanged)
                            .increment(0.5)
                            .verticalAlignment(VerticalAlignment.Center)
                            .numberFormat(model.NumberFormat)
                            .formatString(model.SelectedFormat.Value)
                            .watermark("Enter text")
                            .margin(2.)
                    }

                    VStack() {
                        TextBlock("NumericUpDown with Validation Errors:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .fontWeight(FontWeight.Bold)
                            .fontSize(14.)
                            .margin(2.)

                        NumericUpDown(0, 10., model.DecimalValue, DecimalValueChanged)
                            .increment(0.5)
                            .verticalAlignment(VerticalAlignment.Center)
                            .numberFormat(model.NumberFormat)
                            .formatString(model.SelectedFormat.Value)
                            .watermark("Enter text")
                            .margin(2.)
                            .dataValidationErrors([ Exception() ])
                    }

                    VStack() {
                        TextBlock("NumericUpDown in HEX mode:")
                            .verticalAlignment(VerticalAlignment.Center)
                            .fontWeight(FontWeight.Bold)
                            .fontSize(14.)
                            .margin(2.)

                        NumericUpDown(0., 10., model.Value, ValueChanged)
                            .increment(0.5)
                            .verticalAlignment(VerticalAlignment.Center)
                            .numberFormat(model.NumberFormat)
                            .formatString(model.SelectedFormat.Value)
                            .watermark("Enter text")
                            .margin(2.)
                            .textConverter(hexConverter())
                    }
                }
            }
        }
