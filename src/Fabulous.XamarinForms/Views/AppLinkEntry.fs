namespace Fabulous.XamarinForms

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IAppLinkEntry =
    inherit IElement

module AppLinkEntry =
    let WidgetKey = Widgets.register<AppLinkEntry>()

    let AppLinkUri =
        Attributes.defineSimpleScalarWithEquality<Uri>
            "AppLinkEntry_AppLinkUri"
            (fun _ newValueOpt node ->
                let appLinkEntry = node.Target :?> AppLinkEntry

                match newValueOpt with
                | ValueNone -> appLinkEntry.AppLinkUri <- null
                | ValueSome data -> appLinkEntry.AppLinkUri <- data)

    let Description =
        Attributes.defineBindableWithEquality<string> AppLinkEntry.DescriptionProperty

    let IsLinkActive =
        Attributes.defineBindableWithEquality AppLinkEntry.IsLinkActiveProperty

    let Thumbnail =
        Attributes.defineBindableWithEquality<ImageSource> AppLinkEntry.ThumbnailProperty

    let Title =
        Attributes.defineBindableWithEquality<string> AppLinkEntry.TitleProperty

[<AutoOpen>]
module AppLinkEntryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline AppLinkEntry<'msg>(title: string, uri: Uri) =
            WidgetBuilder<'msg, IAppLinkEntry>(
                AppLinkEntry.WidgetKey,
                AppLinkEntry.Title.WithValue(title),
                AppLinkEntry.AppLinkUri.WithValue(uri)
            )

        static member inline AppLinkEntry<'msg>(title: string, url: string) =
            View.AppLinkEntry<'msg>(title, Uri(url))

[<Extension>]
type AppLinkEntryModifiers =
    [<Extension>]
    static member inline description(this: WidgetBuilder<'msg, #IAppLinkEntry>, value: string) =
        this.AddScalar(AppLinkEntry.Description.WithValue(value))

    [<Extension>]
    static member inline isLinkActive(this: WidgetBuilder<'msg, #IAppLinkEntry>, value: bool) =
        this.AddScalar(AppLinkEntry.IsLinkActive.WithValue(value))

    [<Extension>]
    static member inline thumbnail(this: WidgetBuilder<'msg, #IAppLinkEntry>, source: ImageSource) =
        this.AddScalar(AppLinkEntry.Thumbnail.WithValue(source))

    [<Extension>]
    static member inline thumbnail(this: WidgetBuilder<'msg, #IAppLinkEntry>, source: string) =
        let source = ImageSource.FromFile(source)
        AppLinkEntryModifiers.thumbnail(this, source)

    [<Extension>]
    static member inline thumbnail(this: WidgetBuilder<'msg, #IAppLinkEntry>, uri: Uri) =
        let source = ImageSource.FromUri(uri)
        AppLinkEntryModifiers.thumbnail(this, source)

    [<Extension>]
    static member inline thumbnail(this: WidgetBuilder<'msg, #IAppLinkEntry>, stream: Stream) =
        let source = ImageSource.FromStream(fun () -> stream)
        AppLinkEntryModifiers.thumbnail(this, source)
