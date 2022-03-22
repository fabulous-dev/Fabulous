namespace Fabulous.XamarinForms

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type INavigationPage =
    inherit IPage

module NavigationPage =
    let WidgetKey = Widgets.register<NavigationPage> ()

    let BackButtonTitle =
        Attributes.defineBindable<string> NavigationPage.BackButtonTitleProperty

    let Pages =
        Attributes.defineWidgetCollectionWithConverter
            "NavigationPage_Pages"
            ViewUpdaters.applyDiffNavigationPagePages
            ViewUpdaters.updateNavigationPagePages

    let BarBackgroundColor =
        Attributes.defineAppThemeBindable<Color> NavigationPage.BarBackgroundColorProperty

    let BarBackground =
        Attributes.defineAppThemeBindable<Brush> NavigationPage.BarBackgroundProperty

    let BarTextColor =
        Attributes.defineAppThemeBindable<Color> NavigationPage.BarTextColorProperty

    let IconColor =
        Attributes.defineAppThemeBindable<Color> NavigationPage.IconColorProperty

    let HasNavigationBar =
        Attributes.defineBindable<bool> NavigationPage.HasNavigationBarProperty

    let HasBackButton =
        Attributes.defineBindable<bool> NavigationPage.HasBackButtonProperty

    let TitleIconImageSource =
        Attributes.defineAppThemeBindable<ImageSource> NavigationPage.TitleIconImageSourceProperty

    let Popped =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_Popped"
            (fun target -> (target :?> NavigationPage).Popped)

    let Pushed =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_Pushed"
            (fun target -> (target :?> NavigationPage).Pushed)

    let PoppedToRoot =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_PoppedToRoot"
            (fun target -> (target :?> NavigationPage).PoppedToRoot)

    let TitleView =
        Attributes.defineBindableWidget NavigationPage.TitleViewProperty

    open Xamarin.Forms.PlatformConfiguration
    open Xamarin.Forms.PlatformConfiguration.iOSSpecific

    let HideNavigationBarSeparator =
        Attributes.define<bool>
            "NavigationPage_HideNavigationBarSeparator"
            (fun newValueOpt node ->
                let page =
                    node.Target :?> Xamarin.Forms.NavigationPage

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                page
                    .On<iOS>()
                    .SetHideNavigationBarSeparator(value)
                |> ignore)

[<AutoOpen>]
module NavigationPageBuilders =
    type Fabulous.XamarinForms.View with
        static member inline NavigationPage<'msg>() =
            CollectionBuilder<'msg, INavigationPage, IPage>(NavigationPage.WidgetKey, NavigationPage.Pages)

[<Extension>]
type NavigationPageModifiers =
    /// <summary>Set the color of the BarBackgroundColor.</summary>
    /// <param name="light">The color of the barBackgroundColor in the light theme.</param>
    /// <param name="dark">The color of the barBackgroundColor in the dark theme.</param>
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #INavigationPage>, light: Color, ?dark: Color) =
        this.AddScalar(NavigationPage.BarBackgroundColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the BarBackground.</summary>
    /// <param name="light">The color of the barBackground in the light theme.</param>
    /// <param name="dark">The color of the barBackground in the dark theme.</param>
    [<Extension>]
    static member inline barBackground(this: WidgetBuilder<'msg, #INavigationPage>, light: Brush, ?dark: Brush) =
        this.AddScalar(NavigationPage.BarBackground.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the BarTextColor.</summary>
    /// <param name="light">The color of the barTextColor in the light theme.</param>
    /// <param name="dark">The color of the barTextColor in the dark theme.</param>
    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #INavigationPage>, light: Color, ?dark: Color) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(AppTheme.create light dark))

    /// <summary>Event that is fired when the page is popped.</summary>
    /// <param name="onPopped">Msg to dispatch when then page is popped.</param>
    [<Extension>]
    static member inline onPopped(this: WidgetBuilder<'msg, #INavigationPage>, onPopped: 'msg) =
        this.AddScalar(NavigationPage.Popped.WithValue(fun _ -> box onPopped))

    /// <summary>Event that is fired when the page is pushed.</summary>
    /// <param name="onPushed">Msg to dispatch when then page is pushed.</param>
    [<Extension>]
    static member inline onPushed(this: WidgetBuilder<'msg, #INavigationPage>, onPushed: 'msg) =
        this.AddScalar(NavigationPage.Pushed.WithValue(fun _ -> box onPushed))

    /// <summary>Event that is fired when the page is popped to root.</summary>
    /// <param name="onPoppedToRoot">Msg to dispatch when then page is popped to root.</param>
    [<Extension>]
    static member inline onPoppedToRoot(this: WidgetBuilder<'msg, #INavigationPage>, onPoppedToRoot: 'msg) =
        this.AddScalar(NavigationPage.PoppedToRoot.WithValue(fun _ -> box onPoppedToRoot))

[<Extension>]
type NavigationPageAttachedModifiers =
    /// <summary>Set the value for HasNavigationBar</summary>
    /// <param name= "value">true if the page has navigation bar ; otherwise, false.</param>
    [<Extension>]
    static member inline hasNavigationBar(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasNavigationBar.WithValue(value))

    /// <summary>Set the value for HasBackButton</summary>
    /// <param name= "value">true if the page has back button ; otherwise, false.</param>
    [<Extension>]
    static member inline hasBackButton(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasBackButton.WithValue(value))

    /// <summary>Set the value for BackButtonTitle</summary>
    /// <param name= "value">The title of the back button for the specified page.</param>
    [<Extension>]
    static member inline backButtonTitle(this: WidgetBuilder<'msg, #IPage>, value: string) =
        this.AddScalar(NavigationPage.BackButtonTitle.WithValue(value))

    /// <summary>Set the color of the IconColor.</summary>
    /// <param name="light">The color of the iconColor in the light theme.</param>
    /// <param name="dark">The color of the iconColor in the dark theme.</param>
    [<Extension>]
    static member inline iconColor(this: WidgetBuilder<'msg, #IPage>, light: Color, ?dark: Color) =
        this.AddScalar(NavigationPage.IconColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIconImageSource in the light theme.</param>
    /// <param name="dark">The source of the titleIconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline titleIconImageSource
        (
            this: WidgetBuilder<'msg, #IPage>,
            light: ImageSource,
            ?dark: ImageSource
        ) =
        this.AddScalar(NavigationPage.TitleIconImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIconImageSource in the light theme.</param>
    /// <param name="dark">The source of the titleIconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline titleIconImageSource(this: WidgetBuilder<'msg, #IPage>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        NavigationPageAttachedModifiers.titleIconImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIconImageSource in the light theme.</param>
    /// <param name="dark">The source of the titleIconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline titleIconImageSource(this: WidgetBuilder<'msg, #IPage>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        NavigationPageAttachedModifiers.titleIconImageSource (this, light, ?dark = dark)

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIconImageSource in the light theme.</param>
    /// <param name="dark">The source of the titleIconImageSource in the dark theme.</param>
    [<Extension>]
    static member inline titleIconImageSource(this: WidgetBuilder<'msg, #IPage>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        NavigationPageAttachedModifiers.titleIconImageSource (this, light, ?dark = dark)

    /// <summary>Sets the value for TitleView</summary>
    /// <param name= "content">View to use as a title for the navigation page.</param>
    [<Extension>]
    static member inline titleView<'msg, 'marker, 'contentMarker when 'marker :> IPage and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(NavigationPage.TitleView.WithValue(content.Compile()))

    /// <summary>Link a ViewRef to access the direct NavigationPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, INavigationPage>, value: ViewRef<NavigationPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type NavigationPagePlatformModifiers =
    /// <summary>iOS platform specific. Sets a value that hides the navigation bar separator.</summary>
    /// <param name="value">true to hide the separator. Otherwise, false.</param>
    [<Extension>]
    static member inline hideNavigationBarSeparator(this: WidgetBuilder<'msg, #INavigationPage>, value: bool) =
        this.AddScalar(NavigationPage.HideNavigationBarSeparator.WithValue(value))
