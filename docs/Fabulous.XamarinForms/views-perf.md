{% include_relative _header.md %}

{% include_relative contents-views.md %}

Views and Performance
------

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
```fsharp
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
```fsharp
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

### View keys 101 
  1. What is view key? 
      View key is a little helper property like in this sample: 
      
     ```fsharp
         // Previous View
         View.Grid([
                 View.Label(key = "header", text = "Old Header")
                 View.Label(key = "body", text = "Old Body")
             ])
         
         // New View
         View.Grid([
             View.Label(key = "header", text = "New Header") // Will reuse previous header
             View.Button(key = "body", text = "New body") // Won't be able to reuse previous body since Label != Button
         ])
     ```
         
  As we can see here, we have added a 'key' parameter to each Label.
  Key should be unique across view elements in same collection, i.e.
  Children of StackLayout and so on.
  
  2.What is a purpose of key? 
   Purpose of key is following: 
  * make determination of proper view element to replace easier(just by key,yes)
  * most important,to keep a reference to previous XF control(so we would not create it, but reuse existing).
  
  In many scenarios this is essential thing, for example, you draw a control
  that streams video, and its position changed due some conditions.Without 'key' set,
  we get continuous recreating of control with a bunch of issues like video interrupt.
  With key, we continue reuse  same control on each view cycle.
  
   
### Views: Differential Update of Lists of Things

There are a few different kinds of list in view descriptions:
1. lists of raw data (e.g. data for a chart control, though there are no samples like that yet in this library)
2. long lists of UI elements that are used to produce cells (e.g. `ListView`, see above)
3. short lists of UI elements (e.g. StackLayout `children`)
4. short lists of pages (e.g. NavigationPages `pages`)

The perf of incremental update to these is progressively less important as you go down that list above.  

For all of the above, the typical, naive implementation of the `view` function returns a new list
instance on each invocation. The incremental update of dynamic views maintains a corresponding mutable target
(e.g. the `Children` property of a `Xamarin.Forms.StackLayout`, or an `ObservableCollection` to use as an `ItemsSource` to a `ListView`) based on the previous (PREV) list and the new (NEW) list.  The list diffing currently does the following:

Fabulous first prioritizes the reuse of the same ViewElement instances, when using dependsOn for instance.
```fsharp
View.Grid([
    dependsOn () (fun _ _ -> View.Label(text = "Hello, World!"))
])
```

Only then it will try to reuse ViewElements sharing the same key, if canReuseView returns true.

```fsharp
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

If still no reusable controls found, it will try to reuse one of the remaining previous elements to find the first one for which canReuseView returns true.
If it finds one, it reuses it, if not it creates a new control.

In the end, controls that weren't reused are destroyed.
This means
1. Incremental update costs minimally one transition of the whole list.
2. Incremental update recycles visual elements as much as possible if you use 'key' attribute.
   Otherwise, there is no guarantee that you get same visual element next time.

NOTE: The list diffing will limit mutations to only Move, Remove, and Insert, even when more straightforward operations could be done.
This is to support the limitations imposed by how Xamarin.Forms reacts to changes in `System.Collections.ObjectModel.ObservableCollection<'T>`.
The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.  Care must also be taken whenever data updates very rapidly.


