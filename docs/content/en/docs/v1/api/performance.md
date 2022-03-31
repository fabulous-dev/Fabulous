---
title : "View and performance"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "api"
weight: 101
toc: true
---

The performance of your app may in some cases be dominated by your view function.  
This is particularly the case if many  message updates are being generated and processed, though not if other operations dominate such as network latency.
Improving the performance of your view function should be done with respect to your overall performance targets and needs.

On each update to the model, the view function is executed. The resulting view is then compared item by item with the previous view
and updates are made to the underlying controls.

As a result, views functions that are frequently executed (because of many message updates) are generally only
efficient for large UIs if the unchanging parts of a UI are "memoized", returning identical
objects on each invocation of the `view` function. 
This must be done explicitly. One way of doing this is to use `dependsOn`.
Here is an example for a 6x6 Grid that depends on nothing, i.e. never changes:
```fs
let view model dispatch =
    ...
    dependsOn () (fun model () -> 
        View.StackLayout(
          children=
            [ View.Label(text=sprintf "Grid (6x6, auto):")
              View.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"],
                coldefs=[for i in 1 .. 6 -> box "auto"], 
                children = [ for i in 1 .. 6 do for j in 1 .. 6 -> 
                                View.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) )
                                        .GridRow(i-1).GridColumn(j-1) ] )
            ])
```
Inside the function - the one passed to `dependsOn` - the `model` is rebound to be inaccessbile with a `DoNotUseMe` type so you can't use it. Here is an example where some of the model is extracted:
```fs
let view model dispatch =
    ...
    dependsOn (model.CountForSlider, model.StepForSlider) (fun model (count, step) -> 
        View.Slider(minimum=0.0, maximum=10.0, value= double step, 
                    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))))) 
    ...
```
In the example, we extract properties `CountForSlider` and `StepForSlider` from the model, and bind them to `count` and `step`.  If either of these change, the section of the view will be recomputed and no adjustments will be made to the UI.
If not, this section of the view will be reused. This helps ensure that this part of the view description only depends on the parts of the model extracted.

You can also use 
* the `fix` function for portions of a view that have no dependencies at all (besides the "dispatch" function)
* the `fixf` function for command callbacks that have no dependencies at all (besides the "dispatch" function)

### Optimizing view performance in advanced scenarios: the `key` property

Each time the `view` function is called, Fabulous will try to update the UI the most efficiently possible by reusing existing controls as much as possible (for exact details, see [Views: Differential Update of Lists of Things](#views-differential-update-of-lists-of-things)).  
This is fine in the majority of scenarios, but some times Fabulous might reuse controls that don't really match the expectations we can have from the code.  

This is especially true if the ordering of the elements are changed, or an element has been added/removed before other elements.  
This can result in unnecessary creation of controls (lower performance) or losing state of a control (like a video playing).

This is because Fabulous doesn't know about the intent of your code, and will try to reuse controls from first to last in the list.

Say we have the following code:

```fs
View.StackLayout([
    if model.ShowFirstVideo then
        yield View.MediaElement(source = MediaPath "path/to/video.mp4")

    yield View.MediaElement(source = MediaPath "path/to/other-video.mp4")
    yield View.Button(text = "Toggle first video", command = (fun () -> dispatch ToggleFirstVideo))
])
```

In this case, when `ShowFirstVideo` = `true`, the StackLayout will have 3 children, the 1st and 2nd video players + the button.  
When `ShowFirstVideo` = `false`, there will be only 2 child left, the 2nd video player and the button.

Due to how Fabulous reuses controls between updates, when switching `ShowFirstVideo` from `false` to `true`, Fabulous will remove the 2nd video player and reuse/update the 1st video player, which will lose the state of the 2nd video if it was playing.  
That's because Fabulous has no way of knowing the real intent behind your code. For it, all MediaElements are interchangeable.

To prevent that, the first thing you can do is to change ordering as little as possible.  
If you really must change ordering, you can help Fabulous by providing a `key` value to let Fabulous know that a specific element should reuse the same control as previously.

In our example, this would be:

```fs
View.StackLayout([
    if model.ShowFirstVideo then
        yield View.MediaElement(source = MediaPath "path/to/video.mp4")

    yield View.MediaElement(key = "second-player", source = MediaPath "path/to/other-video.mp4")
    yield View.Button(text = "Toggle first video", command = (fun () -> dispatch ToggleFirstVideo))
])
```

Now, Fabulous will be aware that `second-player` should remain the same between updates and that the first MediaElement should be added/removed given the value of `ShowFirstVideo`.

`key` must be unique among its sibling inside a collection (e.g. `items`, `children`).  
Using the same key at different places is ok.
   
### Views: Differential Update of Lists of Things

There are a few different kinds of list in view descriptions:
1. lists of raw data (e.g. data for a chart control, though there are no samples like that yet in this library)
2. long lists of UI elements that are used to produce cells (e.g. `ListView`, see above)
3. short lists of UI elements (e.g. StackLayout `children`)
4. short lists of pages (e.g. NavigationPages `pages`)

The perf of incremental update to these is progressively less important as you go down that list above.  

For all of the above, the typical, naive implementation of the `view` function returns a new list
instance on each invocation. The incremental update of dynamic views maintains a corresponding mutable target
(e.g. the `Children` property of a `Xamarin.Forms.StackLayout`, or an `ObservableCollection` to use as an `ItemsSource` to a `ListView`) based on the previous (PREV) list and the new (NEW) list.

Fabulous prioritizes reuse in the following order:
1. Same ViewElement instance (when using dependsOn)
```fs
View.Grid([
    dependsOn () (fun _ _ -> View.Label(text = "Hello, World!"))
])
```

2. Same key and control type (aka. `canReuseView` returns true)

```fs
// Previous View
View.Grid([
    View.Label(key = "header", text = "Previous Header")
    View.Label(key = "body", text = "Previous body")
])

// New View
View.Grid([
    View.Label(key = "header", text = "New Header") // Will reuse previous header
    View.Button(key = "body", text = "New body") // Won't be able to reuse previous body since Label != Button
])
```

3. If none of the above, Fabulous will select the first element that returns `canReuseView = true` among the eligible remaining previous elements.

4. If no previous element can be reused, a new one is created

Note that old keyed elements that didn't had a matching key in the new list will be destroyed instead of being reused by new unkeyed elements to help developers avoid undesired animations, such as fade-in/fade-out on Button Text changes on iOS ([#308](https://github.com/fsprojects/Fabulous/issues/308)) or ripple effects on Android Button.

In the end, controls that weren't reused are destroyed.

This means
1. Incremental update costs minimally one transition of the whole list.
2. Incremental update recycles controls as much as possible if you use the same instance or `key` property.  
   Otherwise, there is no guarantee that you get same control next time.

NOTE: The list diffing will limit mutations to only Move, Remove, and Insert, even when more straightforward operations could be done.
This is to support the limitations imposed by how Xamarin.Forms reacts to changes in `System.Collections.ObjectModel.ObservableCollection<'T>`.

The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.  Care must also be taken whenever data updates very rapidly.


