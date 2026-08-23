# Image

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** Image [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.image) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=macos)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=macos).

### Constructors&#x20;

| Constructors                                                  | Description                                                                    |
| ------------------------------------------------------------- | ------------------------------------------------------------------------------ |
| Image(aspect: Aspect, light: ImageSource, ?dark: ImageSource) | Defines an Image widget with a image for light and dark mode using ImageSource |
| Image(aspect: Aspect, light: string, ?dark: string)           | Defines an Image widget with a image for light and dark mode using a path      |
| Image(aspect: Aspect, light: Uri, ?dark: Uri)                 | Defines a Image widget with a image for light and dark mode using an URI       |
| Image(aspect: Aspect, light: Stream, ?dark: Stream)           | Defines a Image widget with a image for light and dark mode using a stream     |

### Properties&#x20;

| Properties                        | Description                                                                                        |
| --------------------------------- | -------------------------------------------------------------------------------------------------- |
| isLoading(value: bool)            | Sets if the image is currently loading                                                             |
| isOpaque(value: bool)             | Sets if the image is opaque                                                                        |
| reference(value: ViewRef\<Image>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Image` instance associated to this widget |

### Usages&#x20;

```fsharp
Image("image-light.png", dark = "image-dark.png")
    .isAnimationPlaying(true)
    .isOpaque(false)
```

#### Get access to the underlying Xamarin.Forms.Image&#x20;

```fsharp
let imageRef = ViewRef<Image>()

Image("image-light.png", dark = "image-dark.png")
    .reference(imageRef)
```
