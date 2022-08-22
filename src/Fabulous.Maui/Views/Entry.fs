namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Handlers

module Entry =
    let ClearButtonVisibility = Attributes.defineMauiScalarWithEquality<ClearButtonVisibility> "ClearButtonVisibility"
    let IsPassword = Attributes.defineMauiScalarWithEquality<bool> "IsPassword"
    let ReturnType = Attributes.defineMauiScalarWithEquality<ReturnType> "ReturnType"
    
    let Completed = Attributes.defineMauiEventNoArgs "Completed"
    
    module Defaults =
        let [<Literal>] ClearButtonVisibility = Microsoft.Maui.ClearButtonVisibility.WhileEditing
        let [<Literal>] IsPassword = false
        let [<Literal>] ReturnType = Microsoft.Maui.ReturnType.Default
    
type FabEntry(handler: IViewHandler) =
    inherit FabView(handler)
    
    let mutable _cursorPosition = TextInput.Defaults.CursorPosition
    let mutable _placeholderColor = Placeholder.Defaults.PlaceholderColor
    let mutable _selectionLength = TextInput.Defaults.SelectionLength
    let mutable _text = Text.Defaults.Text
    
    static let _widgetKey = Widgets.register<FabEntry>()
    static member WidgetKey = _widgetKey
    
    new() = FabEntry(EntryHandler())
    
    interface IText with
        // NOTE: To avoid a conflicting interface member (both defined in IText and ITextInput) we have to isolate it
        member this.Text = this.GetScalar(Text.Text, _text)
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, TextStyle.Defaults.CharacterSpacing)
        member this.Font = this.GetScalar(TextStyle.Font, TextStyle.Defaults.createDefaultFont())
        member this.TextColor = this.GetScalar(TextStyle.TextColor, TextStyle.Defaults.TextColor)
    
    interface IEntry with
        member this.Completed() = this.InvokeEvent(Entry.Completed)
        member this.ClearButtonVisibility = this.GetScalar(Entry.ClearButtonVisibility, Entry.Defaults.ClearButtonVisibility)
        member this.CursorPosition
            with get () = this.GetScalar(TextInput.CursorPosition, _cursorPosition)
            and set v = _cursorPosition <- v
        member this.HorizontalTextAlignment = this.GetScalar(TextAlignment.HorizontalTextAlignment, TextAlignment.Defaults.HorizontalTextAlignment)
        member this.IsPassword = this.GetScalar(Entry.IsPassword, Entry.Defaults.IsPassword)
        member this.IsReadOnly = this.GetScalar(TextInput.IsReadOnly, TextInput.Defaults.IsReadOnly)
        member this.IsTextPredictionEnabled = this.GetScalar(TextInput.IsTextPredictionEnabled, TextInput.Defaults.IsTextPredictionEnabled)
        member this.Keyboard = this.GetScalar(TextInput.Keyboard, TextInput.Defaults.createDefaultKeyboard())
        member this.MaxLength = this.GetScalar(TextInput.MaxLength, TextInput.Defaults.MaxLength)
        member this.Placeholder = this.GetScalar(Placeholder.Placeholder, Placeholder.Defaults.Placeholder)
        member this.PlaceholderColor
            with get () = this.GetScalar(Placeholder.PlaceholderColor, _placeholderColor)
            and set v = _placeholderColor <- v
        member this.ReturnType = this.GetScalar(Entry.ReturnType, Entry.Defaults.ReturnType)
        member this.SelectionLength
            with get () = this.GetScalar(TextInput.SelectionLength, _selectionLength)
            and set v = _selectionLength <- v
        member this.Text
            with get () = this.GetScalar(Text.Text, _text)
            and set v =
                _text <- v
                this.InvokeEvent(Text.TextChanged, v)
        member this.VerticalTextAlignment = this.GetScalar(TextAlignment.VerticalTextAlignment, TextAlignment.Defaults.VerticalTextAlignment)
        
[<AutoOpen>]
module EntryBuilders =
    type Fabulous.Maui.View with
        static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEntry>(
                FabEntry.WidgetKey,
                Text.Text.WithValue(text),
                Text.TextChanged.WithValue(fun v -> onTextChanged v |> box)
            )

