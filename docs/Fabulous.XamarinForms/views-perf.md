Fabulous for Xamarin.Forms - Guide
=======

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
1. trims of excess elements from TARGET down to size LIM = min(NEW.Count, PREV.Count)
2. incrementally updates existing elements 0..MIN-1 in TARGET (skips this if PREV.[i] is reference-equal to NEW.[i])
3. creates elements LIM..NEW.Count-1

This means
1. Incremental update costs minimally one transition of the whole list.
2. Incremental update recycles visual elements at the start of the list and handles add/remove at end of list relatively efficiently
3. Returning a new list that inserts an element at the beginning will recreate all elements down the way.

Basically, incremental update is faster if items are being added/removed at the end, rather than the beginning of the list. 

The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.  Care must also be taken whenever data updates very rapidly.


