namespace Fabulous.Maui

open System
open System.Net
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration

type IFabWebView =
    inherit IFabView

module WebView =
    let WidgetKey = Widgets.register<WebView>()

    let CanGoBack = Attributes.defineBindableBool WebView.CanGoBackProperty

    let CanGoForward = Attributes.defineBindableBool WebView.CanGoForwardProperty

    let Cookies =
        Attributes.defineBindableWithEquality<CookieContainer> WebView.CookiesProperty

    let Navigated =
        Attributes.Mvu.defineEvent<WebNavigatedEventArgs> "WebView_Navigated" (fun target -> (target :?> WebView).Navigated)

    let Navigating =
        Attributes.Mvu.defineEvent<WebNavigatingEventArgs> "WebView_Navigating" (fun target -> (target :?> WebView).Navigating)

    let Source =
        Attributes.defineBindableWithEquality<WebViewSource> WebView.SourceProperty

module WebViewPlatform =
    let DisplayZoomControls =
        Attributes.defineBool "WebView_DisplayZoomControls" (fun _ newValueOpt node ->
            let webview = node.Target :?> WebView

            let value =
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            AndroidSpecific.WebView.SetDisplayZoomControls(webview, value))

    let EnableZoomControls =
        Attributes.defineBool "WebView_EnableZoomControls" (fun _ newValueOpt node ->
            let webview = node.Target :?> WebView

            let value =
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            AndroidSpecific.WebView.SetEnableZoomControls(webview, value))

[<AutoOpen>]
module WebViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a WebView with a source</summary>
        /// <param name="source">The web source</param>
        static member inline WebView<'msg when 'msg: equality>(source: WebViewSource) =
            WidgetBuilder<'msg, IFabWebView>(WebView.WidgetKey, WebView.Source.WithValue(source))

        /// <summary>Create a WebView with an HTML content</summary>
        /// <param name="html">The HTML content</param>
        /// <param name="baseUrl">The base URL</param>
        static member inline WebView<'msg when 'msg: equality>(html: string, ?baseUrl: string) =
            let source =
                match baseUrl with
                | Some url -> HtmlWebViewSource(Html = html, BaseUrl = url)
                | None -> HtmlWebViewSource(Html = html)

            View.WebView<'msg>(source)

        /// <summary>Create a WebView with a Uri source</summary>
        /// <param name="uri">The Uri source</param>
        static member inline WebView<'msg when 'msg: equality>(uri: Uri) =
            View.WebView<'msg>(WebViewSource.op_Implicit uri)

        /// <summary>Create a WebView with a Url source</summary>
        /// <param name="url">The Url source</param>
        static member inline WebView<'msg when 'msg: equality>(url: string) =
            View.WebView<'msg>(WebViewSource.op_Implicit url)

[<Extension>]
type WebViewModifiers() =
    /// <summary>Set a value that indicates whether the user can navigate to previous pages</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true if the user can navigate to previous pages; otherwise, false</param>
    [<Extension>]
    static member inline canGoBack(this: WidgetBuilder<'msg, #IFabWebView>, value: bool) =
        this.AddScalar(WebView.CanGoBack.WithValue(value))

    /// <summary>Set a value that indicates whether the user can navigate to the next pages</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true if the user can navigate to the next pages; otherwise, false</param>
    [<Extension>]
    static member inline canGoForward(this: WidgetBuilder<'msg, #IFabWebView>, value: bool) =
        this.AddScalar(WebView.CanGoForward.WithValue(value))

    /// <summary>Set the cookie container</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The cookie container</param>
    [<Extension>]
    static member inline cookies(this: WidgetBuilder<'msg, #IFabWebView>, value: CookieContainer) =
        this.AddScalar(WebView.Cookies.WithValue(value))

    /// <summary>Listen for the Navigated event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onNavigated(this: WidgetBuilder<'msg, #IFabWebView>, fn: WebNavigatedEventArgs -> 'msg) =
        this.AddScalar(WebView.Navigated.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the Navigating event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onNavigating(this: WidgetBuilder<'msg, #IFabWebView>, fn: WebNavigatingEventArgs -> 'msg) =
        this.AddScalar(WebView.Navigating.WithValue(fun args -> fn args |> box))

    /// <summary>Link a ViewRef to access the direct WebView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabWebView>, value: ViewRef<WebView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type WebViewPlatformModifiers =
    /// <summary>Android platform-specific. Set a value indicating whether the zoom controls are enabled</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the zoom controls are enabled</param>
    [<Extension>]
    static member inline enableZoomControls(this: WidgetBuilder<'msg, #IFabWebView>, value: bool) =
        this.AddScalar(WebViewPlatform.EnableZoomControls.WithValue(value))

    /// <summary>Android platform-specific. Set a value indicating whether the zoom controls are displayed</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the zoom controls are displayed</param>
    [<Extension>]
    static member displayZoomControls(this: WidgetBuilder<'msg, #IFabWebView>, value: bool) =
        this.AddScalar(WebViewPlatform.DisplayZoomControls.WithValue(value))
