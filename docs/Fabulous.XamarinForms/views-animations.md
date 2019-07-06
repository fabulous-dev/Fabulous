Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

ViewRefs
------

Animations and focus are specified by accessing the underlying Xamarin.Forms control and using
Xamarin.Forms animation specifications. The underlying control is usually accessed
via a `ViewRef`, akin to a `ref` in HTML/JavaScript and React. 

* A `ViewRef` must have a sufficient scope that it lives long enough, e.g. a global scope
  or the scope of the model.  The `ViewRef` can be held in the model itself if necessary.

* Initially `ViewRef` are empty. They will only be populated after the `view` function
  has been called and its results applied to the visual display.

For example, the following shows the creation of a `ViewRef` and associating it
with a particular element:

```fsharp
let animatedLabelRef = ViewRef<Label>()

let view dispatch model = 
    View.Label(text="Rotate", ref=animatedLabelRef) 
```

The underlying control can also be accessed by using the `created` handler:

```fsharp
let mutable label = None

View.Label(text="hello", created=(fun l ->  label <- Some l))
```

> NOTE: A `ViewRef` only holds a weak handle to the underlying control.  
The `Value` property may thus fail if the underlying control has been collected.  
As a result it is often sensible to use the `TryValue` property which returns an option.

Animations
------

Animations are specified by using a Xamarin.Forms animation specification on the underlying control, e.g. 

```fsharp
let animatedLabelRef = ViewRef<Label>()

let update msg model =
    match msg with 
    | Poked ->
        match animatedLabelRef.TryValue with 
        | None -> () 
        | Some c -> c.RotateTo (360.0, 2000u) |> ignore

let view dispatch model = 
    View.StackLayout [
        View.Label(text="Rotate", ref=animatedLabelRef) 
        View.Button(text="Rotate", command=(fun () -> dispatch Poked)) 
    ]
```

Animations in Xamarin.Forms specify tasks.  These are ignorable if the animation is simple.
Composite animations must compose tasks, either by using `async { ...}` and `Async.AwaitTask`
and `Async.StartAsTask`, or by using `task { ... }` from the F# community `TaskBuilder` library.

Examples of custom tasks are shown in C# syntax in [Animation in Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/).  

See also
* [Animation in Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/)
* [Simple Animations in Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple)
* [Easing Functions in Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/easing)
* [Custom Animations in Xamarin.Forms](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/animation/custom)


Focus
------

ViewRefs can be used to give focus to particular elements using `.Focus()`.

See also
* [VisualElement.Focus Method](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualelement.focus?view=xamarin-forms)
