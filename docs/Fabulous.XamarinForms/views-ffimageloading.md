Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Using FFImageLoading
------

The FFImageLoading plugin allows you to cache images as opposed to wasting time and space with the built-in Image view. Using FFImageLoading, you have an easy way to cache images in your Fabulous.XamarinForms application.

FFImageLoading was created by Daniel Luberda and Fabien Molinet. The original project can be found in [this github repository](https://github.com/luberda-molinet/FFImageLoading).

The nuget [`Fabulous.XamarinForms.FFImageLoading`](https://www.nuget.org/packages/Fabulous.XamarinForms.FFImageLoading) implements a view component for the type [CahcedImage](https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-API#basic-example).

![How the view looks](https://raw.githubusercontent.com/luberda-molinet/FFImageLoading/master/samples/Screenshots/ffimageloading_large.png)
###### Source: The FFImageLoading github project by Daniel Luberda and Fabien Molinet

To use `Fabulous.XamarinForms.FFImageLoading`, you must add a reference to this [NuGet package](https://www.nuget.org/packages/Fabulous.XamarinForms.FFImageLoading) across your whole solution.  This will add appropriate references to your platform-specific Android, iOS, UWP, WPF etc projects too.

After these steps you can use CachedImage in your view function. Here is a simple example of using CachedImage to display a scenic image:

```fsharp
open Xamarin.Forms
open Fabulous.XamarinForms

View.CachedImage(
  source = ImageSource.FromFile "https://loremflickr.com/cache/resized/65535_48577442711_890a6e6d83_b_600_600_nofilter.jpg",
  height = 600.,
  width = 600.)
```

Performance considerations
-------
Use `FileImageSource`, `UriImageSource` or FFImageLoading's `EmbeddedResourceImageSource` instead of `StreamImageSource` or `ImageSource.FromResource` to ensure the images are cached properly.
[Read more here on the FFImageLoading wiki](https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-Advanced)

See also:

* [Core Elements](views-elements.md)
* [The FFImageLoading wiki](https://github.com/luberda-molinet/FFImageLoading/wiki)
* [Source for the FFImageLoading extension](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/extensions/FFImageLoading/CachedImage.fs)
* [Source of FFImageLoading](https://github.com/luberda-molinet/FFImageLoading)
* [Defining Extensions](views-extending.md)
