namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IImageButton =
    inherit IView

module ImageButton =
    let WidgetKey = Widgets.register<ImageButton>()

    let Source =
        Attributes.defineBindable<ImageSource> ImageButton.SourceProperty

    let Aspect =
        Attributes.defineBindable<Xamarin.Forms.Aspect> ImageButton.AspectProperty

    let Clicked =
        Attributes.defineEventNoArg "ImageButton_Clicked" (fun target -> (target :?> ImageButton).Clicked)

[<AutoOpen>]
module ImageButtonBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ImageButton<'msg>
            (
                source: ImageSource,
                onClicked: 'msg,
                aspect: Xamarin.Forms.Aspect
            ) =
            WidgetBuilder<'msg, IImageButton>(
                ImageButton.WidgetKey,
                ImageButton.Source.WithValue(source),
                ImageButton.Clicked.WithValue(onClicked),
                ImageButton.Aspect.WithValue(aspect)
            )

        static member inline ImageButton<'msg>(path: string, onClicked, aspect) =
            View.ImageButton<'msg>(ImageSource.FromFile(path), onClicked, aspect)

        static member inline ImageButton<'msg>(uri: System.Uri, onClicked, aspect) =
            View.ImageButton<'msg>(ImageSource.FromUri(uri), onClicked, aspect)

        static member inline ImageButton<'msg>(stream: System.IO.Stream, onClicked, aspect) =
            View.ImageButton<'msg>(ImageSource.FromStream(fun () -> stream), onClicked, aspect)