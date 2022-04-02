---
id: "v1-videomanager"
title : "VideoManager"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "extensions"
toc: true
---

The MediaManager plugin allow to play audio and video with Xamarin. Using this VideoManager, you can create a dedicated view to render a video in your fabulous application.

MediaManager has been created by Martijn van Dijk and its original project can be found on [its github repository](https://github.com/martijn00/XamarinMediaManager).

The nuget [`Fabulous.XamarinForms.VideoManager`](https://www.nuget.org/packages/Fabulous.VideoManager) implements a view component for the type [VideoView](https://github.com/martijn00/XamarinMediaManager).

![VideoView example from Microsoft](https://devblogs.microsoft.com/wp-content/uploads/sites/44/2019/03/VideoPlayer.png)

To use `Fabulous.XamarinForms.VideoView`, you must

1. Add a reference to `Plugin.MediaManager` and `Plugin.MediaManager.Forms` across your whole solution.  This will add appropriate references to your platform-specific Android and iOS projects too.
2. Next add a reference to `Fabulous.XamarinForms.VideoManager` across your whole solution.

After these steps you can use VideoView in your view function. Here is a simple example of using VideoView to
display a video player of Big Buck Bunny:

```fs
open Fabulous.XamarinForms

View.VideoView(
  source = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
  showControls = false,
  heightRequest = 500.,
  widthRequest = 200.)
```

See also:

* [Interface Objects](view-interface-objects.html).
* [Using MediaManager for Xamarin](https://devblogs.microsoft.com/xamarin/play-audio-and-video-with-the-mediamanager-plugin-for-xamarin/).
* [Source for the VideoManager extension](https://github.com/fsprojects/Fabulous/blob/v1.0/Fabulous.XamarinForms/extensions/VideoManager/VideoManager.fs)
* [Source for the Xamarin MediaManager](https://github.com/martijn00/XamarinMediaManager)
* [Defining Extensions](view-a-extensions.html)
