# Editor

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/) -> [InputView](https://docs.fabulous.dev/v2/api/controls/input-view/)\
**Xamarin.Forms documentation:** Editor [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.editor) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/editor)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/editor).

### Constructors&#x20;

| Constructors                                        | Description                                                  |
| --------------------------------------------------- | ------------------------------------------------------------ |
| Editor(text: string, onTextChanged: string -> ‘msg) | Defines a Editor widget with a text and onTextChanged event. |

### Properties&#x20;

| Properties                                                                                  | Description                                                                                                |
| ------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| autoSize(value: EditorAutoSizeOption)                                                       | Sets a value that controls whether the editor will change size to accommodate input as the user enters it. |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used                                                                                  |
| isTextPredictionEnabled(value: bool)                                                        | Sets whether the text prediction is enabled.                                                               |
| reference(value: ViewRef\<Editor>)                                                          | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Editor` instance associated to this widget        |

### Events&#x20;

| Properties                     | Description                                            |
| ------------------------------ | ------------------------------------------------------ |
| onCompleted(onCompleted: ‘msg) | Sets the event handler for the entry onCompleted event |

### Usages&#x20;

```fsharp
Editor("Enter a description", TextChanged)
    .keyboard(Keyboard.Email)
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
    .onCompleted(TextCompleted)
```

#### Get access to the underlying Xamarin.Forms.Editor&#x20;

```fsharp
let editorRef = ViewRef<Editor>()

Editor("Enter a description", TexChanged)
    .reference(editorRef)
```
