# WebView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/) -> [View](https://docs.fabulous.dev/v2/api/collections/items-view/)\
**Xamarin.Forms documentation:** WebView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.webview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview)

### Constructors&#x20;

| Constructors                            | Description                                                                   |
| --------------------------------------- | ----------------------------------------------------------------------------- |
| WebView(source: WebViewSource)          | Define a WebView widget with a WebViewSource                                  |
| WebView(html: string, ?baseUrl: string) | Define a WebView widget with html content and a base URL for all links inside |
| WebView(uri: Uri)                       | Define a WebView with a URI                                                   |
| WebView(url: string)                    | Define a WebView with a URL as string                                         |

### Properties&#x20;

| Properties                          | Description                                                                                          |
| ----------------------------------- | ---------------------------------------------------------------------------------------------------- |
| canGoBack(value: bool)              | Sets if the user can navigate back                                                                   |
| canGoForward(value: bool)           | Sets if the user can navigate forward                                                                |
| cookies(value: CookieContainer)     | Sets the cookies                                                                                     |
| enableZoomControls(value: bool)     | Sets if the zoom controls are enabled                                                                |
| displayZoomControls(value: bool)    | Sets if the zoom controls are shown on the screen                                                    |
| reference(value: ViewRef\<WebView>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.WebView` instance associated to this widget |

### Events&#x20;

| Properties                                                 | Description                                            |
| ---------------------------------------------------------- | ------------------------------------------------------ |
| onNavigating(onNavigating: WebNavigatingEventArgs -> ‘msg) | Sets the event listener for the navigating event       |
| onNavigated(onNavigated: WebNavigatedEventArgs -> ‘msg)    | Sets the event listener for the navigated event        |
| onReloadRequested(onReloadRequested: ‘msg)                 | Sets the event listener for the reload requested event |

### Usages&#x20;

```fsharp
let cookies = CookieContainer()

WebView("https://fabulous.dev")
    .canGoBack(false) 
    .canGoForward(true)
    .cookies(cookies)
    .enableZoomControls(true)
    .displayZoomControls(false)
    .onNavigating(NavigatingMsg)
    .onNavigated(NavigatedMsg)
    .onReloadRequested(ReloadedMsg)
```

#### Get access to the underlying Xamarin.Forms.WebView&#x20;

```fsharp
let webViewRef = ViewRef<WebView>()

WebView("https://fabulous.dev")
    .reference(webViewRef)
```
