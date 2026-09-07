# SearchBar

**Inheritance:** [Element](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/element.md) -> [NavigableElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/navigableelement.md) -> [VisualElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/visualelement.md) -> [View](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/view.md) -> [InputView](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/controls/inputview.md)\
**Xamarin.Forms documentation:** SearchBar [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar).

### Constructors&#x20;

| Constructors                                                                        | Description                                                                             |
| ----------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| SearchBar(text: string, onTextChanged: string -> ‘msg, onSearchButtonPressed: ‘msg) | Defines a SearchBar widget with a text, onTextChanged and onSearchButtonPressed events. |

### Properties&#x20;

| Properties                                                                                  | Description                                                                                            |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| cancelButtonColor(light: FabColor, ?dark: FabColor)                                         | Sets a value that indicates the color of the cancel button depending if light or dark mode.            |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used                                                                              |
| horizontalTextAlignment(value: TextAlignment)                                               | Sets the horizontal text alignment.                                                                    |
| verticalTextAlignment(value: TextAlignment)                                                 | Sets the vertical text alignment.                                                                      |
| reference(value: ViewRef\<SearchBar>)                                                       | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.SearchBar` instance associated to this widget |

### Usages&#x20;

```fsharp
SearchBar("Enter a description", TextChanged, SearchButtonPressed)
    .keyboard(Keyboard.Email)
    .cancelButtonColor(Color.Green.ToFabColor(), Color.White.ToFabColor())
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

#### Get access to the underlying Xamarin.Forms.SearchBar [#](https://fabulous-dev.github.io/Fabulous/v2/api/controls/search-bar/#get-access-to-the-underlying-xamarinformssearchbar) <a href="#get-access-to-the-underlying-xamarinformssearchbar" id="get-access-to-the-underlying-xamarinformssearchbar"></a>

```fsharp
let searchBarRef = ViewRef<SearchBar>()

SearchBar("Enter a description", TexChanged, SearchButtonPressed)
    .reference(searchBarRef)
```
