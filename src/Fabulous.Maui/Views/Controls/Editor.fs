namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous

module Editor =
    let Completed = Attributes.defineMauiEventNoArgs "Completed"
    
type FabEditor(handler: IViewHandler) =
    inherit FabView(handler)
    
    let mutable _placeholderColor = Placeholder.Defaults.PlaceholderColor
    let mutable _cursorPosition = TextInput.Defaults.CursorPosition
    let mutable _selectionLength = TextInput.Defaults.SelectionLength
    let mutable _text = Text.Defaults.Text
    
    static let _widgetKey = Widgets.register<FabEditor>()
    static member WidgetKey = _widgetKey

    new() = FabEditor(EditorHandler())
        
    interface ITextStyle with
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, TextStyle.Defaults.CharacterSpacing)
        member this.Font = this.GetScalar(TextStyle.Font, TextStyle.Defaults.createDefaultFont())
        member this.TextColor = this.GetScalar(TextStyle.TextColor, TextStyle.Defaults.TextColor)
    
    interface IText with
        member this.Text = this.GetScalar(Text.Text, _text)
        
    interface IPlaceholder with
        member this.Placeholder = this.GetScalar(Placeholder.Placeholder, Placeholder.Defaults.Placeholder)
        member this.PlaceholderColor
            with get () = this.GetScalar(Placeholder.PlaceholderColor, _placeholderColor)
            and set v = _placeholderColor <- v
        
    interface ITextAlignment with
        member this.HorizontalTextAlignment = this.GetScalar(TextAlignment.HorizontalTextAlignment, TextAlignment.Defaults.HorizontalTextAlignment)
        member this.VerticalTextAlignment = this.GetScalar(TextAlignment.VerticalTextAlignment, TextAlignment.Defaults.VerticalTextAlignment)
        
    interface ITextInput with
        member this.CursorPosition
            with get () = this.GetScalar(TextInput.CursorPosition, _cursorPosition)
            and set v = _cursorPosition <- v
        member this.IsReadOnly = this.GetScalar(TextInput.IsReadOnly, TextInput.Defaults.IsReadOnly)
        member this.IsTextPredictionEnabled = this.GetScalar(TextInput.IsTextPredictionEnabled, TextInput.Defaults.IsTextPredictionEnabled)
        member this.Keyboard = this.GetScalar(TextInput.Keyboard, TextInput.Defaults.createDefaultKeyboard())
        member this.MaxLength = this.GetScalar(TextInput.MaxLength, TextInput.Defaults.MaxLength)
        member this.SelectionLength
            with get () = this.GetScalar(TextInput.SelectionLength, _selectionLength)
            and set v = _selectionLength <- v
        member this.Text
            with get () = this.GetScalar(Text.Text, _text)
            and set v =
                _text <- v
                this.InvokeEvent(Text.TextChanged, v)
        
    interface IEditor with
        member this.Completed() = this.InvokeEvent(Editor.Completed)
        
[<AutoOpen>]
module EditorBuilders =
    type Fabulous.Maui.View with
        static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEditor>(
                FabEditor.WidgetKey,
                Text.Text.WithValue(text),
                Text.TextChanged.WithValue(fun v -> onTextChanged v |> box)
            )