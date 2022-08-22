namespace Fabulous.Maui

open Microsoft.Maui

module TextInput =
    let IsTextPredictionEnabled = Attributes.defineMauiScalarWithEquality<bool> "IsTextPredictionEnabled"
    let IsReadOnly = Attributes.defineMauiScalarWithEquality<bool> "IsReadOnly"
    let Keyboard = Attributes.defineMauiScalarWithEquality<Keyboard> "Keyboard"
    let MaxLength = Attributes.defineMauiScalarWithEquality<int> "MaxLength"
    let CursorPosition = Attributes.defineMauiScalarWithEquality<int> "CursorPosition"
    let SelectionLength = Attributes.defineMauiScalarWithEquality<int> "SelectionLength"
    
    module Defaults =
        let [<Literal>] IsTextPredictionEnabled = true
        let [<Literal>] IsReadOnly = false
        let [<Literal>] MaxLength = System.Int32.MaxValue
        let [<Literal>] CursorPosition = 0
        let [<Literal>] SelectionLength = 0
        let inline createDefaultKeyboard() = Microsoft.Maui.Keyboard.Default
