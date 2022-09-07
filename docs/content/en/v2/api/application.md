---
id: "v2-application"
title: "Application"
description: ""
lead: ""
date: 2022-06-21T00:00:00+00:00
lastmod: 2022-06-21T00:00:00+00:00
draft: false
images: []
weight: 402
menu:
  docs:
    parent: "api"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}})  
**Xamarin.Forms documentation:** Application [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.application)

## Constructors

| Constructors | Description |
|--|--|
| Application<'msg, 'marker when 'marker :> IPage>(mainPage: WidgetBuilder<'msg, 'marker>) | Creates a new instance of the Application with a Page |

## Properties

| Properties | Description |
|--|--|
| userAppTheme(value: OSAppTheme) | Sets the application theme. |
| resources(value: ResourceDictionary) | Sets the global resources for the application. |
| reference(value: ViewRef&lt;Application&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Application` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onRequestedThemeChanged(onRequestedThemeChanged: OSAppTheme -> 'msg) | Event that is fired when the application theme is changed. |
| onModalPopped(onModalPopped: ModalPoppedEventArgs -> 'msg) | Event that is fired when a modal page is popped. |
| onModalPopping(onModalPopping: ModalPoppingEventArgs -> 'msg) | Event that is fired when a modal page is popping. |
| onModalPushed(onModalPushed: ModalPushedEventArgs -> 'msg) | Event that is fired when a modal page is pushed. |
| onModalPushing(onModalPushing: ModalPushingEventArgs -> 'msg) | Event that is fired when a modal page is pushing. |
| onStart(onStart: 'msg) | Dispatch a message when the application starts |
| onSleep(onSleep: 'msg) | Dispatch a message when the application is paused by the OS |
| onResume(onResume: 'msg) | Dispatch a message when the application is resumed by the OS |

## Usages

```fs
Application(
    ContentPage(
        "Title",
        Stack() {
            Label("Hello World!")
        }
    )
)
  .userAppTheme(OSAppTheme.Light)
  .onRequestedThemeChanged(ThemeChanged)
  .onModalPopped(ModalPopped)
  .onModalPopping(ModalPopping)
  .onModalPushed(ModalPushed)
  .onModalPushing(ModalPushing)
  .onStart(Started)
  .onSleep(WentToSleep)
  .onResume(Resumed)
```

### Get access to the underlying Xamarin.Forms.Entry

```fs
let applicationRef = ViewRef<Application>()

Application(
    ContentPage(
        "Tilte",
        Stack() {
            Label("Hello World!")
        }
    )
).reference(applicationRef)
```
