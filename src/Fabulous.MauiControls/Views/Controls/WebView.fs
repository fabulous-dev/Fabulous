namespace Fabulous.Maui

open System
open System.Net
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
// open Microsoft.Maui.PlatformConfiguration

type IWebView =
    inherit Fabulous.Maui.IView

module WebView =

    let WidgetKey = Widgets.register<WebView>()

    let CanGoBack =
        Attributes.defineBindableBool WebView.CanGoBackProperty

    let CanGoForward =
        Attributes.defineBindableBool WebView.CanGoForwardProperty

    let Source =
        Attributes.defineBindableWithEquality<WebViewSource> WebView.SourceProperty

    let Cookies =
        Attributes.defineBindableWithEquality<CookieContainer> WebView.CookiesProperty

    let Navigating =
        Attributes.defineEvent<WebNavigatingEventArgs>
            "WebView_Navigating"
            (fun target -> (target :?> WebView).Navigating)

    let Navigated =
        Attributes.defineEvent<WebNavigatedEventArgs> "WebView_Navigated" (fun target -> (target :?> WebView).Navigated)

// let ReloadRequested =
//     Attributes.defineEventNoArg "WebView_ReloadRequested" (fun target -> (target :?> WebView).ReloadRequested)

// let EnableZoomControls =
//     Attributes.defineBool
//         "WebView_EnableZoomControls"
//         (fun _ newValueOpt node ->
//             let webview = node.Target :?> WebView
//
//             let value =
//                 match newValueOpt with
//                 | ValueNone -> false
//                 | ValueSome v -> v
//
//             AndroidSpecific.WebView.SetEnableZoomControls(webview, value))

// let DisplayZoomControls =
//     Attributes.defineBool
//         "WebView_DisplayZoomControls"
//         (fun _ newValueOpt node ->
//             let webview = node.Target :?> WebView
//
//             let value =
//                 match newValueOpt with
//                 | ValueNone -> false
//                 | ValueSome v -> v
//
//             AndroidSpecific.WebView.SetDisplayZoomControls(webview, value))

[<AutoOpen>]
module WebViewBuilders =
    type Fabulous.Maui.View with
        static member inline WebView<'msg>(source: WebViewSource) =
            WidgetBuilder<'msg, IWebView>(WebView.WidgetKey, WebView.Source.WithValue(source))

        static member inline WebView<'msg>(html: string, ?baseUrl: string) =
            let source = HtmlWebViewSource()
            source.Html <- html

            match baseUrl with
            | Some url -> source.BaseUrl <- url
            | None -> ()

            View.WebView<'msg>(source)

        static member inline WebView<'msg>(uri: Uri) =
            View.WebView<'msg>(WebViewSource.op_Implicit uri)

        static member inline WebView<'msg>(url: string) =
            View.WebView<'msg>(WebViewSource.op_Implicit url)

[<Extension>]
type WebViewModifiers() =
    /// <summary>Sets a value that indicates whether the user can navigate to previous pages.</summary>
    /// <param name="value">true if the user can navigate to previous pages; otherwise, false.</param>
    [<Extension>]
    static member inline canGoBack(this: WidgetBuilder<'msg, #IWebView>, value: bool) =
        this.AddScalar(WebView.CanGoBack.WithValue(value))

    /// <summary>Sets a value that indicates whether the user can navigate to the next pages.</summary>
    /// <param name="value">true if the user can navigate to the next pages; otherwise, false.</param>
    [<Extension>]
    static member inline canGoForward(this: WidgetBuilder<'msg, #IWebView>, value: bool) =
        this.AddScalar(WebView.CanGoForward.WithValue(value))

    /// <summary>When set this will act as a sync for cookies.</summary>
    /// <param name="value">The cookie container.</param>
    [<Extension>]
    static member inline cookies(this: WidgetBuilder<'msg, #IWebView>, value: CookieContainer) =
        this.AddScalar(WebView.Cookies.WithValue(value))

    [<Extension>]
    static member inline onNavigating
        (
            this: WidgetBuilder<'msg, #IWebView>,
            onNavigating: WebNavigatingEventArgs -> 'msg
        ) =
        this.AddScalar(WebView.Navigating.WithValue(fun args -> onNavigating args |> box))

    [<Extension>]
    static member inline onNavigated(this: WidgetBuilder<'msg, #IWebView>, onNavigated: WebNavigatedEventArgs -> 'msg) =
        this.AddScalar(WebView.Navigated.WithValue(fun args -> onNavigated args |> box))

    // [<Extension>]
    // static member inline onReloadRequested(this: WidgetBuilder<'msg, #IWebView>, onReloadRequested: 'msg) =
    //     this.AddScalar(WebView.ReloadRequested.WithValue(onReloadRequested))

    /// <summary>Link a ViewRef to access the direct WebView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IWebView>, value: ViewRef<WebView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

// [<Extension>]
// type WebViewPlatformModifiers =
//     [<Extension>]
//     static member inline enableZoomControls(this: WidgetBuilder<'msg, #IWebView>, value: bool) =
//         this.AddScalar(WebView.EnableZoomControls.WithValue(value))
//
//     [<Extension>]
//     static member displayZoomControls(this: WidgetBuilder<'msg, #IWebView>, value: bool) =
//         this.AddScalar(WebView.DisplayZoomControls.WithValue(value))
