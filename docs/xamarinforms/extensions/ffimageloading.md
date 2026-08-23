# FFImageLoading

The FFImageLoading plugin allows you to cache images as opposed to wasting time and memory with the built-in Image view. Using FFImageLoading, you have an easy way to cache images in your Fabulous.XamarinForms application.

FFImageLoading was created by Daniel Luberda and Fabien Molinet. The original project can be found in [this github repository](https://github.com/luberda-molinet/FFImageLoading).

The nuget [`Fabulous.XamarinForms.FFImageLoading`](https://www.nuget.org/packages/Fabulous.XamarinForms.FFImageLoading) implements a view component for the type [CachedImage](https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-API#basic-example).

Source: The FFImageLoading github project by Daniel Luberda and Fabien Molinet

<figure><img src="../../.gitbook/assets/image (1).png" alt=""><figcaption></figcaption></figure>

### Installation&#x20;

To use `Fabulous.XamarinForms.FFImageLoading`, you must:

1. Add a reference to [this NuGet package](https://www.nuget.org/packages/Fabulous.XamarinForms.FFImageLoading) across your whole solution. This will add appropriate references to your platform-specific Android, iOS, UWP, WPF etc projects too.
2. Add this line to your platform specific projects (AppDelegate.fs, MainActivity.fs, MainPage.xaml.cs, etc) before you use FFImageLoading:

* If you’re using Android:

```fsharp
FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer = Nullable [true]/[false])
```

* If you’re using non-Android platforms:

```fsharp
FFImageLoading.Forms.Platform.CachedImageRenderer.Init()
```

1. Use CachedImage in your view function. Here is a simple example of using CachedImage to display a scenic image:

```fsharp
View.CachedImage(
  source = ImagePath "http://loremflickr.com/600/600/nature?filename=simple.jpg",
  height = 600.,
  width = 600.
)
```

#### Performance considerations&#x20;

Use `FileImageSource`, `UriImageSource` or FFImageLoading’s `EmbeddedResourceImageSource` instead of `StreamImageSource` or `ImageSource.FromResource` to ensure the images are cached properly.\
[Read more here on the FFImageLoading wiki](https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-Advanced)
