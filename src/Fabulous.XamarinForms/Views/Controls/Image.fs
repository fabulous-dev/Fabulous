namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IImage =
    inherit IView
    
module Image =
    let WidgetKey = Widgets.register<Image> ()

    let Source =
        Attributes.defineBindable<ImageSource> Image.SourceProperty

    let Aspect =
        Attributes.defineBindable<Aspect> Image.AspectProperty
        
[<AutoOpen>]
module ImageBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Image<'msg>(imageSource: ImageSource, aspect: Aspect) =
            WidgetBuilder<'msg, IImage>(Image.WidgetKey, Image.Source.WithValue(imageSource), Image.Aspect.WithValue(aspect))

        static member inline Image<'msg>(path: string, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromFile(path), aspect)

        static member inline Image<'msg>(uri: System.Uri, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromUri(uri), aspect)

        static member inline Image<'msg>(stream: System.IO.Stream, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromStream(fun () -> stream), aspect)