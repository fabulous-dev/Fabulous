## MediaElement for Fabulous.MauiControls

The MediaElement control is a cross-platform view for playing video and audio. You can find all the details about this control in the [.NET MAUI Community Toolkit Media Element documentation](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement).

![](Fabulous_MauiControls_MediaElement_Demo.gif)

### How to use

Please see the `HelloMediaElement` sample app in this repo to see a working example, or follow the steps below to get up and running with the MediaElement.

#### Initial Set-up

1: Add the `Fabulous.MauiControls.MediaElement` package to your project.

2: Add `.UseFabulousMediaElement()` to your MauiProgram after `.UseFabulousApp()`.

```fsharp
open Fabulous.Maui.MediaElement

type MauiProgram =
static member CreateMauiApp() =
    MauiApp
        .CreateBuilder()
        .UseFabulousApp(App.program)
        .UseFabulousMediaElement()
        ...
        .Build()
```

3: Open `Fabulous.Maui.MediaElement` at the top of the file where you declare your Fabulous program (eg. Program.stateful).

```fsharp
open Fabulous.Maui.MediaElement
```

The `MediaElement` uses native media controls under the hood that shouldn't require any additional config i.e. in general you probably won't need to touch `AndroidManifest.xml` on Android or `info.plist` on iOS. 

However, you will need to make sure that your app has the relevant permissions to access to the source of the media you are planning on playing with the media element. 
e.g. if you are going to be playing remote media from a url then your app will require permissions to make network requests, but it will most likely have these permissions by default anyway.

#### Using the `MediaElement` Widget

Now you can use the `MediaElement` widget in your Fabulous app as follows:

```fsharp
MediaElement()
    .source("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
```

##### Binding to the `MediaElement`'s properties

You can access and bind to the `MediaElement`'s properties by using modifiers. E.g. you can set the `ShouldAutoPlay`property to `true` as follows:

```fsharp
MediaElement()
    ...
    .shouldAutoPlay(true)
```

###### Note: The `widthRequest` and `heightRequest` properties have been renamed `width` and `height` in Fabulous, for convenience.

##### Binding to the `MediaElement`'s events

To bind to the `MediaElement`'s events you can also use the corresponding modifiers. E.g. if you'd like to bind to the `MediaOpened` and `OnPositionChanged(Position)` events then you can do the following:

```fsharp
type Msg =
| MediaOpened
| PositionChanged of System.TimeSpan

...

MediaElement()
    .onMediaEnded(MediaEnded)
    .onPositionChanged(fun x -> PositionChanged(x.Position))
```

##### Using a controller to call the `MediaElement`'s methods

To call the `MediaElements`'s methods (e.g. `Play`, `Pause`, [etc...](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement#methods)) you can use a controller as follows:
```fsharp
let controller = MediaElementController()

    let update msg model =
        match msg with
        ...
        | VideoPaused -> model, Cmd.none

let pauseVideoCmd () =
    async {
        do controller.Pause()
        return VideoPaused
    }
    |> Cmd.ofAsyncMsg

...

MediaElement()
    .controller(controller)
```

A full, working example is included in the `HelloMediaElement` sample project in the `/samples` directory.

##### Accessing read-only bindable properties

You can access read-only bindable properties of the media element as follows:

```fsharp
let mediaElementRef = ViewRef<MediaElement>()

let update msg model =
    | Msg ->
    mediaElementRef.Value.Duration // Here you will get the read-only value
    model


let view model =
    VStack() {
        MediaElement(...)
        .reference(mediaElementRef)
    }
```