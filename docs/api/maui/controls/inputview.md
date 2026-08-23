# InputView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/)\
**Xamarin.Forms documentation:** InputView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.inputview)

### Constructors&#x20;

This control can’t be instantiated on its own. Its properties and events are inherited by its descendants.

### Properties&#x20;

| Properties                                         | Description                                                                                                                                                                  |
| -------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| characterSpacing(value: float)                     | Sets a value that indicates the number of device-independent units that should be in between characters in the text displayed by the Entry. Applies to Text and Placeholder. |
| isReadOnly(value: bool)                            | Sets a value that indicates whether the user can edit the text in the entry.                                                                                                 |
| isSpellCheckEnabled(value: bool)                   | Sets a value that indicates whether the text in the entry is to be spell-checked.                                                                                            |
| maxLength(value: int)                              | Sets a value that indicates the maximum number of characters that can be entered in the entry.                                                                               |
| placeholder(value: string)                         | Sets a value that indicates the placeholder text to display when the entry is empty.                                                                                         |
| placeholderColor(light: FabColor, ?dark: FabColor) | Sets a value that indicates the color of the placeholder text depending if light or dark mode.                                                                               |
| textColor(light: FabColor, ?dark: FabColor)        | Sets a value that indicates the color of the text in the entry depending if light or dark mode.                                                                              |
| keyboard(value: Keyboard)                          | Sets a value that indicates the keyboard to use when the entry is focused.                                                                                                   |
| textTransform(value: TextTransform)                | Sets a value that indicates how the text in the entry is to be transformed. i.e. Lowercase, Uppercase, None.                                                                 |
