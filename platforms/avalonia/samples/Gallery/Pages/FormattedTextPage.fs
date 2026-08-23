namespace Gallery

open System.Globalization
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Fabulous

open type Fabulous.Avalonia.View

type FormattedText() =
    inherit Control()

    override this.Render(context: DrawingContext) =
        let testString =
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor"
        // Create the initial formatted text string.
        let formattedText =
            Avalonia.Media.FormattedText(testString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 32, Brushes.Black)

        formattedText.MaxTextWidth <- 300
        formattedText.MaxTextHeight <- 240

        // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
        // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
        // The font size is calculated in terms of points -- not as device-independent pixels.
        formattedText.SetFontSize(36. * 96.0 / 72.0, 0, 5)

        // Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
        formattedText.SetFontWeight(FontWeight.Bold, 6, 11)

        let gradientStops = new GradientStops()
        gradientStops.Add(new GradientStop(Colors.Orange, 0))
        gradientStops.Add(new GradientStop(Colors.Teal, 1))
        let gradient = new LinearGradientBrush()
        gradient.GradientStops <- gradientStops
        gradient.StartPoint <- new RelativePoint(0, 0, RelativeUnit.Relative)
        gradient.EndPoint <- new RelativePoint(0, 1, RelativeUnit.Relative)

        // Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
        formattedText.SetForegroundBrush(gradient, 6, 11)

        // Use an Italic font style beginning at the 28th character and continuing for 28 characters.
        formattedText.SetFontStyle(FontStyle.Italic, 28, 28)

        context.DrawText(formattedText, new Point(10, 0))

        let geometry =
            formattedText.BuildGeometry(Point(10. + formattedText.Width + 10., 0))

        //if (geometry <> null) then
        context.DrawGeometry(gradient, null, geometry)

        let highlightGeometry =
            formattedText.BuildHighlightGeometry(new Point(10. + formattedText.Width + 10., 0))

        context.DrawGeometry(null, ImmutablePen(gradient.ToImmutable(), 2), highlightGeometry)

type IFabFormattedTextControl =
    inherit IFabControl

module FormattedText =
    let WidgetKey = Widgets.register<FormattedText>()

[<AutoOpen>]
module FormattedTextBuilders =

    type Fabulous.Avalonia.View with

        static member FormattedText() =
            WidgetBuilder<'msg, IFabFormattedTextControl>(FormattedText.WidgetKey)

module FormattedTextPage =
    let view () = Grid() { View.FormattedText() }
