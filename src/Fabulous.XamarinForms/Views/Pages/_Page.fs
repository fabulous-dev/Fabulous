namespace Fabulous.XamarinForms

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type IPage =
    inherit IVisualElement

module Page =
    let BackgroundImageSource =
        Attributes.defineAppThemeBindable<ImageSource> Page.BackgroundImageSourceProperty

    let IconImageSource =
        Attributes.defineAppThemeBindable<ImageSource> Page.IconImageSourceProperty

    let IsBusy =
        Attributes.defineBindable<bool> Page.IsBusyProperty

    let Padding =
        Attributes.defineBindable<Thickness> Page.PaddingProperty

    let Title =
        Attributes.defineBindable<string> Page.TitleProperty

    let ToolbarItems =
        Attributes.defineWidgetCollection<ToolbarItem>
            "Page_ToolbarItems"
            (fun target -> (target :?> Page).ToolbarItems)

    let Appearing =
        Attributes.defineEventNoArg "Page_Appearing" (fun target -> (target :?> Page).Appearing)

    let Disappearing =
        Attributes.defineEventNoArg "Page_Disappearing" (fun target -> (target :?> Page).Disappearing)

    let LayoutChanged =
        Attributes.defineEventNoArg "Page_LayoutChanged" (fun target -> (target :?> Page).LayoutChanged)

    let UseSafeArea =
        Attributes.define<bool>
            "Page_UseSafeArea"
            (fun newValueOpt node ->
                let page = node.Target :?> Page

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                iOSSpecific.Page.SetUseSafeArea(page, value))

[<Extension>]
type PageModifiers =
    /// <summary>The Page's title.</summary>
    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IPage>, value: string) =
        this.AddScalar(Page.Title.WithValue(value))

    /// <summary>Set the source of the IconImageSource.</summary>
    /// <param name="light">The source of the iconImageSource in the light theme.</param>
    /// <param name="dark">The source of the iconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline iconImageSource(this: WidgetBuilder<'msg, #IPage>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(Page.IconImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the IconImageSource.</summary>
    /// <param name="light">The source of the iconImageSource in the light theme.</param>
    /// <param name="dark">The source of the iconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline iconImageSource(this: WidgetBuilder<'msg, #IPage>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        PageModifiers.iconImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the IconImageSource.</summary>
    /// <param name="light">The source of the iconImageSource in the light theme.</param>
    /// <param name="dark">The source of the iconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline iconImageSource(this: WidgetBuilder<'msg, #IPage>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        PageModifiers.iconImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the IconImageSource.</summary>
    /// <param name="light">The source of the iconImageSource in the light theme.</param>
    /// <param name="dark">The source of the iconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline iconImageSource(this: WidgetBuilder<'msg, #IPage>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        PageModifiers.iconImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the BackgroundImageSource.</summary>
    /// <param name="light">The source of the backgroundImageSource in the light theme.</param>
    /// <param name="dark">The source of the backgroundImageSource in the dark theme.</param>
    [<Extension>]
    static member inline backgroundImageSource
        (
            this: WidgetBuilder<'msg, #IPage>,
            light: ImageSource,
            ?dark: ImageSource
        ) =
        this.AddScalar(Page.BackgroundImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the BackgroundImageSource.</summary>
    /// <param name="light">The source of the backgroundImageSource in the light theme.</param>
    /// <param name="dark">The source of the backgroundImageSource in the dark theme.</param>
    [<Extension>]
    static member inline backgroundImageSource(this: WidgetBuilder<'msg, #IPage>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        PageModifiers.backgroundImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the BackgroundImageSource.</summary>
    /// <param name="light">The source of the backgroundImageSource in the light theme.</param>
    /// <param name="dark">The source of the backgroundImageSource in the dark theme.</param>
    [<Extension>]
    static member inline backgroundImageSource(this: WidgetBuilder<'msg, #IPage>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        PageModifiers.backgroundImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the BackgroundImageSource.</summary>
    /// <param name="light">The source of the backgroundImageSource in the light theme.</param>
    /// <param name="dark">The source of the backgroundImageSource in the dark theme.</param>
    [<Extension>]
    static member inline backgroundImageSource(this: WidgetBuilder<'msg, #IPage>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        PageModifiers.backgroundImageSource (this, light, ?dark = dark)

    /// <summary>Event that is fired when the page is appearing.</summary>
    /// <param name="onAppearing">Msg to dispatch when then page is appearing.</param>
    [<Extension>]
    static member inline onAppearing(this: WidgetBuilder<'msg, #IPage>, onAppearing: 'msg) =
        this.AddScalar(Page.Appearing.WithValue(onAppearing))

    /// <summary>Event that is fired when the page is disappearing.</summary>
    /// <param name="onDisappearing">Msg to dispatch when then page is disappearing.</param>
    [<Extension>]
    static member inline onDisappearing(this: WidgetBuilder<'msg, #IPage>, onDisappearing: 'msg) =
        this.AddScalar(Page.Disappearing.WithValue(onDisappearing))

    /// <summary>Event that is fired when the page layout has Changed.</summary>
    /// <param name="onLayoutChanged">Msg to dispatch when then page layout has Changed.</param>
    [<Extension>]
    static member inline onLayoutChanged(this: WidgetBuilder<'msg, #IPage>, onLayoutChanged: 'msg) =
        this.AddScalar(Page.LayoutChanged.WithValue(onLayoutChanged))

    [<Extension>]
    static member inline toolbarItems<'msg, 'marker when 'marker :> IPage>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IToolbarItem> Page.ToolbarItems this

    /// <summary>Marks the Page as busy. This will cause the platform specific global activity indicator to show a busy state.</summary>
    /// <param name="value">A bool indicating if the Page is busy or not.</param>
    [<Extension>]
    static member inline isBusy(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(Page.IsBusy.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPage>, value: Thickness) =
        this.AddScalar(Page.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPage>, value: float) =
        PageModifiers.padding (this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #IPage>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        PageModifiers.padding (this, Thickness(left, top, right, bottom))

[<Extension>]
type PagePlatformModifiers =

    /// <summary>iOS platform specific. Sets a value that controls whether padding values are overridden with the safe area insets.</summary>
    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<'msg, #IPage>) =
        this.AddScalar(Page.UseSafeArea.WithValue(false))
