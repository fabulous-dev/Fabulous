Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Using Additional View Components
------

Many open source and 3rd-party Xamarin.Forms control libraries exist.  To use these additional controls, a small amount of wrapper code must
currently be written to make the control fit the incremental-update model used by Elmish.XamarinForms.

The basic shape of an extension view component is shown below. Here we assume the view component defines one extra element 
called ABC deriving from existing element kind BASE, and that ABC has one additional
collection property `Property1` and two basic properties `Property2` and `Property3`.
A collection property is a one that may contain further sub-elements, e.g. `children` for StackLayout, `gestureRecognizers` for any `View`
and `pins` in the Maps example further below.

An extension simply defines a static member that extends `Xaml`.
The returned object inherits the attributes and update functionality from BASE via prototype inheritance.

> **NOTE**: we are considering adding a code generator or type provider to automate this process, though the code is not complex to write.
> 
> **NOTE**: The API used to write these extensions is subject to change.

```fsharp
module MyViewExtensions = 

	open Elmish.XamarinForms
	open Elmish.XamarinForms.DynamicViews

    type Xaml with
        /// Describes a ABC in the view
        static member ABC(?property1: seq<ViewElement>, ?property2: bool, ... inherited attributes ... ) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match property1 with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match property2 with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
			let attribs = Xaml._BuildBASE(attribCount, ... inherited attributes ... ) 

            // Add our own attributes. They must have unique names which must match the names below.
            match property1 with None -> () | Some v -> attribs.Add("ABC_Property1", box v) 
            match property2 with None -> () | Some v -> attribs.Add("ABC_Property2", box v) 
            ...

            // The creation method
            let create () = box (new ABC())

            // The incremental update method
            let update (prev: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                Xaml._UpdateBASE prev source targetObj
                let target = (targetObj :?> ABC)
                source.UpdateElementCollection(prev, target, "ABC_Property1", target.Property1)
                source.UpdatePrimitive(prev, target, "ABC_Property2", (fun target -> target.Property2), (fun target v -> target.Property2 <- v))
                ...

            new ViewElement(typeof<ABC>, create, update, attribs)
```
The control is then used as follows:
```fsharp
    Xaml.ABC(property1 = [ Xaml.Label("hello") ], property2 = true, property3 = "Yo!")
```
It is common to mark view extensions as `inline`. This allows the F# compiler to create more optimized element-creation code for each particular instantiation
based on the small set of properties specified at a particular usage point.

### Example: Xamarin.Forms.Maps

An example for `Xamarin.Forms.Maps` is shown below. The sample is a property mapping for the types [Map](https://docs.microsoft.com/dotnet/api/xamarin.forms.maps.map?view=xamarin-forms]) and
[Pin](https://docs.microsoft.com/en-gb/dotnet/api/xamarin.forms.maps.pin?view=xamarin-forms).

[![Maps example from Microsoft](https://user-images.githubusercontent.com/7204669/42186154-60437d42-7e43-11e8-805b-7200282f3b98.png)](https://user-images.githubusercontent.com/7204669/42186154-60437d42-7e43-11e8-805b-7200282f3b98.png)

> NOTE: To use `Xamarin.Forms.Maps`, you must additionally [follow the instructions to initialize Xamarin.Forms Maps](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/map#Maps_Initialization).
(For example, on Android you must enable Google Play servies, add a call to `Xamarin.FormsMaps.Init(this, bundle)` to `MainActivity.fs` and add both and API key and
`uses-permission` to `AndroidManifest.xml`.)

```fsharp
[<AutoOpen>]
module Maps = 
    open Xamarin.Forms.Maps

    type Xaml with
        /// Describes a Map in the view
        static member Map(?pins: seq<ViewElement>, ?isShowingUser: bool, ?mapType: bool, ?hasScrollEnabled: bool, ?hasZoomEnabled: bool, ?requestedRegion: bool) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match pins with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match hasScrollEnabled with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match isShowingUser with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match mapType with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match hasZoomEnabled with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match requestedRegion with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = Xaml._BuildView(attribCount) 

            // Add our own attributes. They must have unique names which must match the names below.
            match pins with None -> () | Some v -> attribs.Add("Map_Pins", box v) 
            match hasScrollEnabled with None -> () | Some v -> attribs.Add("Map_HasScrollEnabled", box v) 
            match isShowingUser with None -> () | Some v -> attribs.Add("Map_IsShowingUser", box v) 
            match mapType with None -> () | Some v -> attribs.Add("Map_MapType", box v) 
            match hasZoomEnabled with None -> () | Some v -> attribs.Add("Map_HasZoomEnabled", box v) 
            match requestedRegion with None -> () | Some v -> attribs.Add("Map_RequestedRegion", box v) 

            // The create method
            let create () = box (new Xamarin.Forms.Maps.Map())

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                Xaml._UpdateView prevOpt source targetObj
                let target = (targetObj :?> Xamarin.Forms.Maps.Map)
                source.UpdatePrimitive(prevOpt, target, "Map_HasScrollEnabled", (fun target -> target.HasScrollEnabled), (fun target v -> target.HasScrollEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_HasZoomEnabled", (fun target -> target.HasZoomEnabled), (fun target v -> target.HasZoomEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_IsShowingUser", (fun target -> target.IsShowingUser), (fun target v -> target.IsShowingUser <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_MapType", (fun target -> target.MapType), (fun target v -> target.MapType <- v))
                source.UpdateElementCollection(prevOpt, "Map_Pins", target.Pins)
                source.UpdatePrimitive(prevOpt, target, "Map_RequestedRegion", (fun target -> target.VisibleRegion), (fun target v -> target.MoveToRegion(v)))

            // The element
            new ViewElement(typeof<Xamarin.Forms.Maps.Map>, create, update, attribs)

        /// Describes a Pin in the view
        static member Pin(?position: Position, ?label: string, ?pinType: PinType, ?address: string) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match position with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match label with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match pinType with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match address with Some _ -> attribCount + 1 | None -> attribCount

            let attribs = AttributesBuilder(attribCount)

            // Add our own attributes. They must have unique names which must match the names below.
            match position with None -> () | Some v -> attribs.Add("Pin_Position", box v) 
            match label with None -> () | Some v -> attribs.Add("Pin_Label", box v) 
            match pinType with None -> () | Some v -> attribs.Add("Pin_Type", box v) 
            match address with None -> () | Some v -> attribs.Add("Pin_Address", box v) 

            // The create method
            let create () = box (new Xamarin.Forms.Maps.Pin())

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                let target = (targetObj :?> Xamarin.Forms.Maps.Pin)
                source.UpdatePrimitive(prevOpt, target, "Pin_Position", (fun target -> target.Position), (fun target v -> target.Position <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Label", (fun target -> target.Label), (fun target v -> target.Label <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Type", (fun target -> target.Type), (fun target v -> target.Type <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Address", (fun target -> target.Address), (fun target v -> target.Address <- v))

            // The element
            new ViewElement(typeof<Xamarin.Forms.Maps.Pin>, create, update, attribs)
```
The control is then used as follows:
```fsharp
    Xaml.Map(hasZoomEnabled = true, hasScrollEnabled = true)
```
Pins can be added using:
```fsharp
    Xaml.Map(pins = [ Xaml.Pin(...); Xaml.Pin(...) ])
```
In the above example, no inherited properties from `View` (such as `margin` or `horizontalOptions`) have been included in the facade for `Map`.  These properties
can be added, or you can set them on elements using the helper `With`, usable for all `View` properties:
```fsharp
    Xaml.Map(hasZoomEnabled = true, hasScrollEnabled = true).With(horizontalOptions = LayoutOptions.FillAndExpand)
```

See also: 
* [Core Elements](elements.md).
* [Views and Performance](views-perf.md).

