namespace Gallery

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.TextFormatting
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Fabulous

open type Fabulous.Avalonia.View


type ControlRun(control: Control, defaultProperties: TextRunProperties) =
    inherit DrawableTextRun()
    member this.Control = control
    override this.Properties: TextRunProperties = defaultProperties
    override this.Size = control.DesiredSize
    override this.Baseline = 0
    override this.Draw(control, properties) = ()


type CustomTextSource(control: Control, defaultProperties: TextRunProperties) =
    let _text: string = "<-Hello World->"

    interface ITextSource with
        member this.GetTextRun(textSourceIndex) : TextRun =
            if (textSourceIndex >= _text.Length * 2 + TextRun.DefaultTextSourceLength) then
                null
            elif (textSourceIndex = _text.Length) then
                ControlRun(control, defaultProperties)
            else
                TextCharacters(_text, defaultProperties)

type TextFormatter() =
    inherit UserControl()
    let mutable _textLine: TextLine = null

    override this.Render(context: DrawingContext) = _textLine.Draw(context, Point())

    override this.MeasureOverride(availableSize: Size) =
        let defaultRunProperties =
            GenericTextRunProperties(Typeface.Default, foregroundBrush = Brushes.Black, baselineAlignment = BaselineAlignment.Center)

        let paragraphProperties = GenericTextParagraphProperties(defaultRunProperties)

        let control = new Button()
        let textBlock = new TextBlock()
        textBlock.Text <- "Click me!"
        control.Content <- textBlock
        this.Content <- control

        let textSource = CustomTextSource(control, defaultRunProperties)

        control.Measure(Size.Infinity)

        _textLine <- TextFormatter.Current.FormatLine(textSource, 0, Double.PositiveInfinity, paragraphProperties)

        base.MeasureOverride(availableSize)

    override this.ArrangeOverride(finalSize: Size) =
        let mutable currentX = 0.

        for textRun in _textLine.TextRuns do
            match textRun with
            | :? ControlRun as controlRun ->
                controlRun.Control.Arrange(Rect(Point(currentX, 0.), controlRun.Size))
                currentX <- currentX + controlRun.Size.Width
            | :? DrawableTextRun as drawableTextRun -> currentX <- currentX + drawableTextRun.Size.Width

            | _ -> ()

        finalSize


type IFabTextFormatterControl =
    inherit IFabControl

module TextFormatter =
    let WidgetKey = Widgets.register<TextFormatter>()

[<AutoOpen>]
module TextFormatterBuilders =

    type Fabulous.Avalonia.View with

        static member TextFormatter() =
            WidgetBuilder<'msg, IFabTextFormatterControl>(TextFormatter.WidgetKey)

module TextFormatterPage =
    let view () = Grid() { View.TextFormatter() }
