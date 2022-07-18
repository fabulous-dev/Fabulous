namespace Fabulous.XamarinForms

#nowarn "44"

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type INavigationPage =
    inherit IPage

module NavigationPageUpdaters =
    /// NOTE: Would be better to have a custom diff logic for Navigation
    /// because it's a Stack and not a random access collection
    let applyDiffNavigationPagePages (prev: ArraySlice<Widget>) (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
        let navigationPage = node.Target :?> CustomNavigationPage
        let pages = Array.ofSeq navigationPage.Pages

        let mutable pagesLength =
            let struct (size, _) = prev
            int size

        let mutable popLastWithAnimation = false

        for diff in diffs do
            match diff with
            | WidgetCollectionItemChange.Insert (index, widget) ->
                let struct (_, page) = Helpers.createViewForWidget node widget
                let page = page :?> Page

                if index >= pagesLength then
                    navigationPage.Push(page)
                else
                    navigationPage.Navigation.InsertPageBefore(page, pages.[index])

                pagesLength <- pagesLength + 1

            | WidgetCollectionItemChange.Update (index, diff) ->
                let childNode =
                    node.TreeContext.GetViewNode(box pages.[index])

                childNode.ApplyDiff(&diff)

            | WidgetCollectionItemChange.Replace (index, _, newWidget) ->
                let struct (_, page) =
                    Helpers.createViewForWidget node newWidget

                let page = page :?> Page

                if index = 0 && pagesLength = 1 then
                    // We are trying to replace the root page
                    // First we push the new page, then we remove the old one
                    navigationPage.Push(page, false)
                    navigationPage.Navigation.RemovePage(pages.[index])

                elif index = pagesLength - 1 then
                    // Last page, we pop it and push the new one
                    navigationPage.Pop()
                    navigationPage.Push(page)

                else
                    // Page is not visible, we just replace it
                    let nextPage = pages.[index + 1]
                    navigationPage.Navigation.RemovePage(pages.[index])
                    navigationPage.Navigation.InsertPageBefore(page, nextPage)

            | WidgetCollectionItemChange.Remove (index, _) ->
                if pagesLength > pages.Length then
                    // NavigationPage already popped the page before notifying Fabulous, we do nothing
                    pagesLength <- pagesLength - 1
                elif index > pagesLength - 1 then
                    () // Do nothing, page has already been popped
                elif index = pagesLength - 1 then

                    // Pop with an animation if it's the last page of the NavigationPage
                    if index = pages.Length - 1 then
                        popLastWithAnimation <- true
                    else
                        navigationPage.Navigation.RemovePage(pages.[index])

                    pagesLength <- pagesLength - 1
                else
                    // Page is not visible, we just remove it
                    navigationPage.Navigation.RemovePage(pages.[index])
                    pagesLength <- pagesLength - 1

        if popLastWithAnimation then
            navigationPage.Pop()

    let updateNavigationPagePages
        (oldValueOpt: ArraySlice<Widget> voption)
        (newValueOpt: ArraySlice<Widget> voption)
        (node: IViewNode)
        =
        let navigationPage = node.Target :?> CustomNavigationPage

        match newValueOpt with
        | ValueNone -> failwith "NavigationPage requires its Pages modifier to be set"

        | ValueSome widgets ->
            // Push all new pages but only animate the last one
            let mutable i = 0
            let span = ArraySlice.toSpan widgets

            for widget in span do
                let animateIfLastPage = i = span.Length - 1
                let struct (_, page) = Helpers.createViewForWidget node widget

                navigationPage.Push(page :?> Page, animateIfLastPage)
                i <- i + 1

            // Silently remove all old pages
            match oldValueOpt with
            | ValueNone -> ()
            | ValueSome oldWidgets ->
                let pages = Array.ofSeq navigationPage.Pages
                let span = ArraySlice.toSpan oldWidgets

                for i = 0 to span.Length - 1 do
                    navigationPage.Navigation.RemovePage(pages.[i])

module NavigationPage =
    let WidgetKey = Widgets.register<CustomNavigationPage>()

    let BackButtonTitle =
        Attributes.defineBindableWithEquality<string> NavigationPage.BackButtonTitleProperty

    let Pages =
        Attributes.defineWidgetCollection
            "NavigationPage_Pages"
            NavigationPageUpdaters.applyDiffNavigationPagePages
            NavigationPageUpdaters.updateNavigationPagePages

    let BarBackgroundColor =
        Attributes.defineBindableAppThemeColor NavigationPage.BarBackgroundColorProperty

    let BarBackground =
        Attributes.defineBindableAppTheme<Brush> NavigationPage.BarBackgroundProperty

    let BarTextColor =
        Attributes.defineBindableAppThemeColor NavigationPage.BarTextColorProperty

    let IconColor =
        Attributes.defineBindableAppThemeColor NavigationPage.IconColorProperty

    let HasNavigationBar =
        Attributes.defineBindableBool NavigationPage.HasNavigationBarProperty

    let HasBackButton =
        Attributes.defineBindableBool NavigationPage.HasBackButtonProperty

    let TitleIconImageSource =
        Attributes.defineBindableAppTheme<ImageSource> NavigationPage.TitleIconImageSourceProperty

    let BackNavigated =
        Attributes.defineEventNoArg
            "NavigationPage_BackNavigated"
            (fun target -> (target :?> CustomNavigationPage).BackNavigated)

    [<Obsolete("Use BackNavigated instead")>]
    let Popped =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_Popped"
            (fun target -> (target :?> NavigationPage).Popped)

    [<Obsolete("Will be removed in next major version")>]
    let Pushed =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_Pushed"
            (fun target -> (target :?> NavigationPage).Pushed)

    [<Obsolete("Use BackNavigated instead")>]
    let PoppedToRoot =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_PoppedToRoot"
            (fun target -> (target :?> NavigationPage).PoppedToRoot)

    let TitleView =
        Attributes.defineBindableWidget NavigationPage.TitleViewProperty

    let HideNavigationBarSeparator =
        Attributes.defineBool
            "NavigationPage_HideNavigationBarSeparator"
            (fun _ newValueOpt node ->
                let page = node.Target :?> NavigationPage

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                iOSSpecific.NavigationPage.SetHideNavigationBarSeparator(page, value))

    let IsNavigationBarTranslucent =
        Attributes.defineBool
            "NavigationPage_IsNavigationBarTranslucent"
            (fun _ newValueOpt node ->
                let page = node.Target :?> NavigationPage

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                iOSSpecific.NavigationPage.SetIsNavigationBarTranslucent(page, value))

    let PrefersLargeTitles =
        Attributes.defineBool
            "NavigationPage_PrefersLargeTitles"
            (fun _ newValueOpt node ->
                let page = node.Target :?> NavigationPage

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                iOSSpecific.NavigationPage.SetPrefersLargeTitles(page, value))

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
    static member inline barBackgroundColor
        (
            this: WidgetBuilder<'msg, #INavigationPage>,
            light: FabColor,
            ?dark: FabColor
        ) =
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
    static member inline barTextColor(this: WidgetBuilder<'msg, #INavigationPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(AppTheme.create light dark))

    /// <summary>Event that is fired when the user back navigated.</summary>
    /// <param name="onPopped">Msg to dispatch when the user back navigated.</param>
    [<Extension>]
    static member inline onBackNavigated(this: WidgetBuilder<'msg, #INavigationPage>, onBackNavigated: 'msg) =
        this.AddScalar(NavigationPage.BackNavigated.WithValue(onBackNavigated))

    /// <summary>Event that is fired when the page is popped.</summary>
    /// <param name="onPopped">Msg to dispatch when then page is popped.</param>
    [<Extension; Obsolete("Use onBackNavigated instead")>]
    static member inline onPopped(this: WidgetBuilder<'msg, #INavigationPage>, onPopped: 'msg) =
        this.AddScalar(NavigationPage.Popped.WithValue(fun _ -> box onPopped))

    /// <summary>Event that is fired when the page is pushed.</summary>
    /// <param name="onPushed">Msg to dispatch when then page is pushed.</param>
    [<Extension; Obsolete("Will be removed in next major version")>]
    static member inline onPushed(this: WidgetBuilder<'msg, #INavigationPage>, onPushed: 'msg) =
        this.AddScalar(NavigationPage.Pushed.WithValue(fun _ -> box onPushed))

    /// <summary>Event that is fired when the page is popped to root.</summary>
    /// <param name="onPoppedToRoot">Msg to dispatch when then page is popped to root.</param>
    [<Extension; Obsolete("Use BackNavigated instead")>]
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
    static member inline iconColor(this: WidgetBuilder<'msg, #IPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(NavigationPage.IconColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIcon in the light theme.</param>
    /// <param name="dark">The source of the titleIcon in the dark theme.</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IPage>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(NavigationPage.TitleIconImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIcon in the light theme.</param>
    /// <param name="dark">The source of the titleIcon in the dark theme.</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IPage>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        NavigationPageAttachedModifiers.titleIcon(this, light, ?dark = dark)

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIcon in the light theme.</param>
    /// <param name="dark">The source of the titleIcon in the dark theme.</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IPage>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        NavigationPageAttachedModifiers.titleIcon(this, light, ?dark = dark)

    /// <summary>Set the source of the TitleIconImageSource.</summary>
    /// <param name="light">The source of the titleIcon in the light theme.</param>
    /// <param name="dark">The source of the titleIcon in the dark theme.</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IPage>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        NavigationPageAttachedModifiers.titleIcon(this, light, ?dark = dark)

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

    [<Extension>]
    static member inline isNavigationBarTranslucent(this: WidgetBuilder<'msg, #INavigationPage>, value: bool) =
        this.AddScalar(NavigationPage.IsNavigationBarTranslucent.WithValue(value))

    [<Extension>]
    static member inline prefersLargeTitles(this: WidgetBuilder<'msg, #INavigationPage>, value: bool) =
        this.AddScalar(NavigationPage.PrefersLargeTitles.WithValue(value))
