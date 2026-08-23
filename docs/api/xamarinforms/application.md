# Application

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/)\
**Xamarin.Forms documentation:** Application [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.application)

### Constructors&#x20;

| Constructors                                                                             | Description                                           |
| ---------------------------------------------------------------------------------------- | ----------------------------------------------------- |
| Application<‘msg, ‘marker when ‘marker :> IPage>(mainPage: WidgetBuilder<‘msg, ‘marker>) | Creates a new instance of the Application with a Page |

### Properties&#x20;

| Properties                              | Description                                                                                              |
| --------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| userAppTheme(value: OSAppTheme)         | Sets the application theme.                                                                              |
| resources(value: ResourceDictionary)    | Sets the global resources for the application.                                                           |
| reference(value: ViewRef\<Application>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Application` instance associated to this widget |

### Events&#x20;

| Properties                                                           | Description                                                  |
| -------------------------------------------------------------------- | ------------------------------------------------------------ |
| onRequestedThemeChanged(onRequestedThemeChanged: OSAppTheme -> ‘msg) | Event that is fired when the application theme is changed.   |
| onModalPopped(onModalPopped: ModalPoppedEventArgs -> ‘msg)           | Event that is fired when a modal page is popped.             |
| onModalPopping(onModalPopping: ModalPoppingEventArgs -> ‘msg)        | Event that is fired when a modal page is popping.            |
| onModalPushed(onModalPushed: ModalPushedEventArgs -> ‘msg)           | Event that is fired when a modal page is pushed.             |
| onModalPushing(onModalPushing: ModalPushingEventArgs -> ‘msg)        | Event that is fired when a modal page is pushing.            |
| onStart(onStart: ‘msg)                                               | Dispatch a message when the application starts               |
| onSleep(onSleep: ‘msg)                                               | Dispatch a message when the application is paused by the OS  |
| onResume(onResume: ‘msg)                                             | Dispatch a message when the application is resumed by the OS |

### Usages&#x20;

```fsharp
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

#### Get access to the underlying Xamarin.Forms.Entry&#x20;

```fsharp
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
