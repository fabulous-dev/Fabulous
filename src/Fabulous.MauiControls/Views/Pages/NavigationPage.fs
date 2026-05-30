namespace Fabulous.Maui

#nowarn "44"

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration
open Microsoft.Maui.Graphics

type IFabNavigationPage =
    inherit IFabPage

// https://stackoverflow.com/a/2113902
type RequiresSubscriptionEvent() =
    let evt = Event<EventHandler, EventArgs>()
    let mutable counter = 0

    let published =
        { new IEvent<EventHandler, EventArgs> with
            member x.AddHandler(h) =
                evt.Publish.AddHandler(h)
                counter <- counter + 1

            member x.RemoveHandler(h) =
                evt.Publish.RemoveHandler(h)
                counter <- counter - 1

            member x.Subscribe(s) =
                let h = EventHandler(fun _ -> s.OnNext)
                x.AddHandler(h)

                { new IDisposable with
                    member y.Dispose() = x.RemoveHandler(h) } }

    member x.Trigger(v) = evt.Trigger(v)
    member x.Publish = published
    member x.HasListeners = counter > 0

/// Maui handles pages asynchronously, meaning a page will be added to the stack only after the animation is finished.
/// This is a problem for Fabulous, because the nav stack needs to be synchronized with the widget trees.
/// Otherwise rapid consecutive updates might end up with a wrong nav stack.
///
/// To work around that, we keep our own nav stack, and we update it synchronously.
type FabNavigationPage() as this =
    inherit NavigationPage()

    let _pagesSync =
        System.Collections.Generic.List((this :> INavigationPageController).Pages)

    let mutable popCount = 0

    let backNavigated = Event<EventHandler, EventArgs>()
    let backButtonPressed = RequiresSubscriptionEvent()

    do this.Popped.Add(this.OnPopped)

    [<CLIEvent>]
    member _.BackNavigated = backNavigated.Publish

    [<CLIEvent>]
    member _.BackButtonPressed = backButtonPressed.Publish

    member this.PagesSync = _pagesSync :> System.Collections.Generic.IReadOnlyList<Page>

    member this.PushSync(page: Page, ?animated: bool) =
        _pagesSync.Add(page)

        this.PushAsync(page, (animated <> Some false)) |> ignore

    member this.InsertPageBeforeSync(page: Page, index: int) =
        let next = _pagesSync[index]
        _pagesSync.Insert(index, page)
        this.Navigation.InsertPageBefore(page, next)

    member this.RemovePageSync(index: int) =
        if index < _pagesSync.Count then
            popCount <- popCount + 1
            let page = _pagesSync[index]
            _pagesSync.RemoveAt(index)
            this.Navigation.RemovePage(page)

    member this.PopSync(?animated: bool) =
        if _pagesSync.Count > 0 then
            popCount <- popCount + 1
            _pagesSync.RemoveAt(_pagesSync.Count - 1)
            this.PopAsync(animated <> Some false) |> ignore

    member this.OnPopped(_: NavigationEventArgs) =
        // Only trigger BackNavigated if Fabulous isn't the one popping the page (e.g. user tapped back button)
        if popCount > 0 then
            popCount <- popCount - 1
        else
            _pagesSync.RemoveAt(_pagesSync.Count - 1)
            backNavigated.Trigger(this, EventArgs())

    /// If we are listening to the BackButtonPressed event, cancel the automatic back navigation and trigger the event;
    /// otherwise just let the automatic back navigation happen
    override this.OnBackButtonPressed() =
        if backButtonPressed.HasListeners then
            backButtonPressed.Trigger(this, EventArgs())
            true
        else
            false

module NavigationPageUpdaters =
    let applyDiffNavigationPagePages _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
        let navigationPage = node.Target :?> FabNavigationPage
        let pages = Array.ofSeq navigationPage.PagesSync

        let mutable popLastWithAnimation = false

        for diff in diffs do
            match diff with
            | WidgetCollectionItemChange.Insert(index, widget) ->
                let struct (itemNode, page) = Helpers.createViewForWidget node widget
                let page = page :?> Page

                node.TreeContext.Logger.Debug(
                    "[NavigationPage] applyDiffNavigationPagePages: Inserting page with index '{0}' and automationId = '{1}'",
                    index,
                    page.AutomationId
                )

                if index >= pages.Length then
                    navigationPage.PushSync(page)
                else
                    navigationPage.InsertPageBeforeSync(page, index)


                // Trigger the mounted event
                Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

            | WidgetCollectionItemChange.Update(index, diff) ->
                let page = pages[index]
                let childNode = node.TreeContext.GetViewNode(page)

                node.TreeContext.Logger.Debug(
                    "[NavigationPage] applyDiffNavigationPagePages: Updating page with index '{0}' and automationId = '{1}'",
                    index,
                    page.AutomationId
                )

                childNode.ApplyDiff(&diff)

            | WidgetCollectionItemChange.Replace(index, prevWidget, currWidget) ->
                let prevPage = pages[index]
                let prevItemNode = node.TreeContext.GetViewNode(prevPage)

                let struct (currItemNode, currPage) = Helpers.createViewForWidget node currWidget
                let currPage = currPage :?> Page

                node.TreeContext.Logger.Debug(
                    "[NavigationPage] applyDiffNavigationPagePages: Replacing page at index '{0}'. Old automationId = '{1}', new automationId = '{2}'",
                    index,
                    prevPage.AutomationId,
                    currPage.AutomationId
                )

                // Trigger the unmounted event for the old child
                Dispatcher.dispatchEventForAllChildren prevItemNode prevWidget Lifecycle.Unmounted
                prevItemNode.Dispose()

                if index = 0 && pages.Length = 1 then
                    // We are trying to replace the root page
                    // First we push the new page, then we remove the old one
                    navigationPage.PushSync(currPage, false)
                    navigationPage.RemovePageSync(index)

                elif index = pages.Length - 1 then
                    // Last page, we pop it and push the new one
                    navigationPage.PushSync(currPage, animated = true)
                    navigationPage.RemovePageSync(index)

                else
                    // Page is not visible, we just replace it
                    navigationPage.RemovePageSync(index)
                    navigationPage.InsertPageBeforeSync(currPage, index)

                // Trigger the mounted event for the new child
                Dispatcher.dispatchEventForAllChildren currItemNode currWidget Lifecycle.Mounted

            | WidgetCollectionItemChange.Remove(index, prevWidget) ->
                // If back navigation is triggered by user via the back button, Maui would have already removed the page from the stack
                // We need to check if the page is still in the stack before removing it
                if index > pages.Length - 1 then
                    node.TreeContext.Logger.Debug(
                        "[NavigationPage] applyDiffNavigationPagePages: Trying to remove page at index '{0}' but the page already removed.",
                        index
                    )
                else
                    let prevPage = pages[index]
                    let prevItemNode = node.TreeContext.GetViewNode(prevPage)

                    node.TreeContext.Logger.Debug(
                        "[NavigationPage] applyDiffNavigationPagePages: Removing page at index '{0}' and automationId = '{1}'",
                        index,
                        prevPage.AutomationId
                    )

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode prevWidget Lifecycle.Unmounted
                    prevItemNode.Dispose()

                    if index = pages.Length - 1 then
                        popLastWithAnimation <- true
                    else
                        navigationPage.RemovePageSync(index)

        if popLastWithAnimation then
            navigationPage.PopSync()

    let updateNavigationPagePages (oldValueOpt: ArraySlice<Widget> voption) (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
        let navigationPage = node.Target :?> FabNavigationPage

        match newValueOpt with
        | ValueNone -> failwith "NavigationPage requires its Pages modifier to be set"

        | ValueSome widgets ->
            // Push all new pages but only animate the last one
            let mutable i = 0
            let span = ArraySlice.toSpan widgets

            for widget in span do
                let struct (itemNode, page) = Helpers.createViewForWidget node widget
                let page = page :?> Page

                node.TreeContext.Logger.Debug(
                    "[NavigationPage] updateNavigationPagePages: Inserting page with index '{0}' and automationId = '{1}'",
                    i,
                    page.AutomationId
                )

                let animateIfLastPage = i = span.Length - 1
                navigationPage.PushSync(page, animateIfLastPage)

                // Trigger the mounted event
                Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                i <- i + 1

            // Silently remove all old pages
            match oldValueOpt with
            | ValueNone -> ()
            | ValueSome oldWidgets ->
                let pages = Array.ofSeq navigationPage.PagesSync
                let span = ArraySlice.toSpan oldWidgets

                for i = 0 to span.Length - 1 do
                    let prevPage = pages[i]
                    let prevItemNode = node.TreeContext.GetViewNode(prevPage)

                    node.TreeContext.Logger.Debug(
                        "[NavigationPage] updateNavigationPagePages: Removing page at index '{0}' and automationId = '{1}'",
                        i,
                        prevPage.AutomationId
                    )

                    navigationPage.Navigation.RemovePage(prevPage)

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode span[i] Lifecycle.Unmounted
                    prevItemNode.Dispose()

module NavigationPage =
    let WidgetKey = Widgets.register<FabNavigationPage>()

    let BackButtonPressed =
        Attributes.Mvu.defineEventNoArg "NavigationPage_BackButtonPressed" (fun target -> (target :?> FabNavigationPage).BackButtonPressed)

    let BackNavigated =
        Attributes.Mvu.defineEventNoArg "NavigationPage_BackNavigated" (fun target -> (target :?> FabNavigationPage).BackNavigated)

    let BarBackground =
        Attributes.defineBindableWithEquality NavigationPage.BarBackgroundProperty

    let BarBackgroundWidget =
        Attributes.defineBindableWidget NavigationPage.BarBackgroundProperty

    let BarTextColor =
        Attributes.defineBindableColor NavigationPage.BarTextColorProperty

    let Pages =
        Attributes.defineWidgetCollection
            "NavigationPage_Pages"
            NavigationPageUpdaters.applyDiffNavigationPagePages
            NavigationPageUpdaters.updateNavigationPagePages

module NavigationPageAttached =
    let BackButtonTitle =
        Attributes.defineBindableWithEquality<string> NavigationPage.BackButtonTitleProperty

    let HasBackButton =
        Attributes.defineBindableBool NavigationPage.HasBackButtonProperty

    let HasNavigationBar =
        Attributes.defineBindableBool NavigationPage.HasNavigationBarProperty

    let IconColor = Attributes.defineBindableColor NavigationPage.IconColorProperty

    let TitleIconImageSource =
        Attributes.defineBindableImageSource NavigationPage.TitleIconImageSourceProperty

    let TitleView = Attributes.defineBindableWidget NavigationPage.TitleViewProperty

module NavigationPagePlatform =
    let HideNavigationBarSeparator =
        Attributes.defineBool "NavigationPage_HideNavigationBarSeparator" (fun _ newValueOpt node ->
            let page = node.Target :?> NavigationPage

            let value =
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            iOSSpecific.NavigationPage.SetHideNavigationBarSeparator(page, value))

    let IsNavigationBarTranslucent =
        Attributes.defineBool "NavigationPage_IsNavigationBarTranslucent" (fun _ newValueOpt node ->
            let page = node.Target :?> NavigationPage

            let value =
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            iOSSpecific.NavigationPage.SetIsNavigationBarTranslucent(page, value))

    let PrefersLargeTitles =
        Attributes.defineBool "NavigationPage_PrefersLargeTitles" (fun _ newValueOpt node ->
            let page = node.Target :?> NavigationPage

            let value =
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            iOSSpecific.NavigationPage.SetPrefersLargeTitles(page, value))

[<AutoOpen>]
module NavigationPageBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a NavigationPage widget</summary>
        static member inline NavigationPage<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabNavigationPage, IFabPage>(NavigationPage.WidgetKey, NavigationPage.Pages)

[<Extension>]
type NavigationPageModifiers =
    /// <summary>Set the background brush of the bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The background brush value</param>
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #IFabNavigationPage>, value: Brush) =
        this.AddScalar(NavigationPage.BarBackground.WithValue(value))

    /// <summary>Set the background color of the bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The background color value</param>
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #IFabNavigationPage>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(NavigationPage.BarBackgroundWidget.WithValue(content.Compile()))

    /// <summary>Set the text color of the bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color value</param>
    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #IFabNavigationPage>, value: Color) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(value))

    /// <summary>Listen to the user pressing the system back button. Doesn't support the iOS back button</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Msg to dispatch</param>
    /// <remarks>Setting this modifier will prevent the default behavior of the system back button. It's up to you to update the navigation stack.</remarks>
    [<Extension>]
    static member inline onBackButtonPressed(this: WidgetBuilder<'msg, #IFabNavigationPage>, msg: 'msg) =
        this.AddScalar(NavigationPage.BackButtonPressed.WithValue(MsgValue(msg)))

    /// <summary>Listen to the user back navigating</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onBackNavigated(this: WidgetBuilder<'msg, #IFabNavigationPage>, msg: 'msg) =
        this.AddScalar(NavigationPage.BackNavigated.WithValue(MsgValue(msg)))

    /// <summary>Link a ViewRef to access the direct NavigationPage control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNavigationPage>, value: ViewRef<NavigationPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type NavigationPageAttachedModifiers =
    /// <summary>Set the title of the back button</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "value">The title of the back button</param>
    [<Extension>]
    static member inline backButtonTitle(this: WidgetBuilder<'msg, #IFabPage>, value: string) =
        this.AddScalar(NavigationPageAttached.BackButtonTitle.WithValue(value))

    /// <summary>Set whether the page has a back button</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "value">true if the page has back button ; otherwise, false</param>
    [<Extension>]
    static member inline hasBackButton(this: WidgetBuilder<'msg, #IFabPage>, value: bool) =
        this.AddScalar(NavigationPageAttached.HasBackButton.WithValue(value))

    /// <summary>Set whether the page has a navigation bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "value">true if the page has navigation bar ; otherwise, false</param>
    [<Extension>]
    static member inline hasNavigationBar(this: WidgetBuilder<'msg, #IFabPage>, value: bool) =
        this.AddScalar(NavigationPageAttached.HasNavigationBar.WithValue(value))

    /// <summary>Set the color of the page icon</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "value">The color of the page icon</param>
    [<Extension>]
    static member inline iconColor(this: WidgetBuilder<'msg, #IFabPage>, value: Color) =
        this.AddScalar(NavigationPageAttached.IconColor.WithValue(value))

    /// <summary>Set the image source of the title icon</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IFabPage>, value: ImageSource) =
        this.AddScalar(NavigationPageAttached.TitleIconImageSource.WithValue(ImageSourceValue.Source value))

    /// <summary>Sets the value for TitleView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The title view widget</param>
    [<Extension>]
    static member inline titleView(this: WidgetBuilder<'msg, #IFabPage>, content: WidgetBuilder<'msg, #IFabView>) =
        this.AddWidget(NavigationPageAttached.TitleView.WithValue(content.Compile()))

[<Extension>]
type NavigationPageExtraAttachedModifiers =
    /// <summary>Set the image source of the title icon</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IFabPage>, value: string) =
        this.AddScalar(NavigationPageAttached.TitleIconImageSource.WithValue(ImageSourceValue.File value))

    /// <summary>Set the image source of the title icon</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IFabPage>, value: Uri) =
        this.AddScalar(NavigationPageAttached.TitleIconImageSource.WithValue(ImageSourceValue.Uri value))

    /// <summary>Set the image source of the title icon</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline titleIcon(this: WidgetBuilder<'msg, #IFabPage>, value: Stream) =
        this.AddScalar(NavigationPageAttached.TitleIconImageSource.WithValue(ImageSourceValue.Stream value))

[<Extension>]
type NavigationPagePlatformModifiers =
    /// <summary>iOS platform specific. Set whether navigation bar separator is hidden</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true to hide the separator. Otherwise, false</param>
    [<Extension>]
    static member inline hideNavigationBarSeparator(this: WidgetBuilder<'msg, #IFabNavigationPage>, value: bool) =
        this.AddScalar(NavigationPagePlatform.HideNavigationBarSeparator.WithValue(value))

    /// <summary>iOS platform specific. Set whether navigation bar is translucent</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true to enable translucency of the navigation bar. Otherwise, false</param>
    [<Extension>]
    static member inline isNavigationBarTranslucent(this: WidgetBuilder<'msg, #IFabNavigationPage>, value: bool) =
        this.AddScalar(NavigationPagePlatform.IsNavigationBarTranslucent.WithValue(value))

    /// <summary>iOS platform specific. Set whether to use large title display</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true to enable large title display. Otherwise, false</param>
    [<Extension>]
    static member inline prefersLargeTitles(this: WidgetBuilder<'msg, #IFabNavigationPage>, value: bool) =
        this.AddScalar(NavigationPagePlatform.PrefersLargeTitles.WithValue(value))

[<Extension>]
type NavigationPageYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabNavigationPage, IFabPage>, x: WidgetBuilder<'msg, #IFabPage>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabNavigationPage, IFabPage>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabPage>>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
