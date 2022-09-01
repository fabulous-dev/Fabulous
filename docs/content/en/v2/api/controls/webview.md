---
id: "v2-webview"
title: "WebView"
description: ""
lead: ""
date: 2022-09-01T00:00:00+00:00
lastmod: 2022-09-01T00:00:00+00:00
draft: false
images: []
menu:
docs:
parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}})  -> [View]({{< ref "view.md" >}}) -> [View]({{< ref "items-view.md" >}})  
**Xamarin.Forms documentation:** WebView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.webview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview).
[Virtualized Collections]({{< ref "../../architecture/virtualized-collections.md" >}})

## Constructors

| Constructors | Description |
|--|--|
| WebView(source: WebViewSource) | Creates a new WebView with the given items. |
| WebView(html: string, ?baseUrl: string) | //TODO |
| WebView(uri: Uri) | //TODO |
| WebView(url: string) | //TODO |

## Properties

//TODO add description
| Properties | Description |
|--|--|
| canGoBack(value: bool) ||
| canGoForward(value: bool) ||
| cookies(value: CookieContainer) ||
| onNavigating(onNavigating: WebNavigatingEventArgs -> 'msg) ||
| onNavigated(onNavigated: WebNavigatedEventArgs -> 'msg) ||
| onReloadRequested(onReloadRequested: 'msg) ||
| reference(value: ViewRef<WebView>) ||
| enableZoomControls(value: bool) ||
| displayZoomControls(value: bool) ||


## Usages
// TODO fill the parentheses
```fs
WebView(//TODO)
    .canGoBack(value: bool) 
    .canGoForward(value: bool)
    .cookies(value: CookieContainer)
    .onNavigating(onNavigating: WebNavigatingEventArgs -> 'msg)
    .onNavigated(onNavigated: WebNavigatedEventArgs -> 'msg)
    .onReloadRequested(onReloadRequested: 'msg)
    .reference(value: ViewRef<WebView>)
    .enableZoomControls(value: bool)
    .displayZoomControls(value: bool)
```

### Get access to the underlying Xamarin.Forms.WebView

```fs
let webViewRef = ViewRef<WebView>()
WebView(//TODO)
    .reference(webViewRef)
```
