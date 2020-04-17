Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents.md %}

Migrating from v0.52 to v0.53
--------

Fabulous.XamarinForms 0.53 added the support for Xamarin.Forms 4.5, along with the new MediaElement control.  
Take a look at [Xamarin.Forms 4.5 release notes](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/release-notes/4.5/4.5.0) to know what changed.

This MediaElement control uses `MediaSource` to load videos.  
Since `ImageSource` and `MediaSource` are very close in usage and yet different, we introduced some renaming in Fabulous.XamarinForms to avoid naming collision.

### `Image.Path` becomes `Image.ImagePath`, or just `ImagePath`

Previously when loading an image from the file system, or from an URI, you would use `Image.Path` or just `Path` (this discriminated union name `Image` could be omitted).  
To avoid collision with loading a video from a file system/URI, `Path` was renamed to `ImagePath`. Videos use `MediaPath`.

_Old:_
```fsharp
View.Image(
    Source = Path "path/to/image.png"
)
```

_New:_
```fsharp
View.Image(
    Source = ImagePath "path/to/image.png"
)

View.MediaElement(
    Source = MediaPath "path/to/video.mp4"
)
```

### `Image.Byte` becomes `Image.ImageBytes`

Previously when loading an image from a byte array, you would use `Image.Bytes` or just `Bytes` (this discriminated union name `Image` could be omitted).  
To avoid future collision with loading a video and having consistent naming, `Bytes` was renamed to `ImageBytes`.

_Old:_
```fsharp
View.Image(
    Source = Bytes myByteArray
)
```

_New:_
```fsharp
View.Image(
    Source = ImageBytes myByteArray
)
```

### `Image.Source` becomes `Image.ImageSource`, or just `ImageSource`

Previously when loading an image from a custom Xamarin.Forms.ImageSource, you would use `Image.Source` or just `Source` (this discriminated union name `Image` could be omitted).  
To avoid collision with loading a video from a custom Xamarin.Forms.ImageSource, `Source` was renamed to `ImageSrc` (abbreviated to avoid collision with `Xamarin.Forms.ImageSource`). Videos use `MediaSrc`.

_Old:_
```fsharp
let getImageSource() = ...

View.Image(
    Source = Source (getImageSource())
)
```

_New:_
```fsharp
let getImageSource() = ...
let getMediaSource() = ...

View.Image(
    Source = ImageSrc (getImageSource())
)

View.MediaElement(
    Source = MediaSrc (getMediaSource())
)
```