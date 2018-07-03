Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Using Additional View Components
------

Many open source and 3rd-party Xamarin.Forms control libraries exist.  To use these additional controls, a small amount of wrapper code must
currently be written to make the control fit the incremental-update model used by Elmish.XamarinForms.

The basic shape of an extension view component is shown below. Here we assume the view component defines one extra element 
called ABC deriving from existing element kind BASE, and that ABC has one additional
collection property `Prop1` and two basic properties `Prop2` and `Property3`.
A collection property is a one that may contain further sub-elements, e.g. `children` for StackLayout, `gestureRecognizers` for any `View`
and `pins` in the Maps example further below.

An extension simply defines a static member that extends `Xaml`.
The returned object inherits the attributes and update functionality from BASE via prototype inheritance.

> **NOTE**: we are considering adding a code generator or type provider to automate this process, though the code is not complex to write.
> 
> **NOTE**: The API used to write these extensions is subject to change.

```fsharp
[<AutoOpen>]
module MyViewExtensions =

    open Elmish.XamarinForms
    open Elmish.XamarinForms.DynamicViews

    let Prop1AttribKey = AttributeKey<seq<ViewElement>> "ABC_Prop1"
    let Prop2AttribKey = AttributeKey<bool> "ABC_Prop2"

    type Xaml with
        /// Describes a ABC in the view
        static member ABC(?prop1: seq<ViewElement>, ?prop2: bool, ... inherited attributes ... ) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match prop1 with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match prop2 with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = Xaml._BuildBASE(attribCount, ... inherited attributes ... ) 

            // Add our own attributes. They must have unique names which must match the names below.
            match prop1 with None -> () | Some v -> attribs.Add(Prop1AttribKey, v) 
            match prop2 with None -> () | Some v -> attribs.Add(Prop2AttribKey, v) 
            ...

            // The creation method
            let create () = box (new ABC())

            // The incremental update method
            let update (prev: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                Xaml._UpdateBASE prev source targetObj
                let target = (targetObj :?> ABC)
                source.UpdateElementCollection(prev, rop1AttribKey, target.Prop1)
                source.UpdatePrimitive(prev, target, Prop2AttribKey, (fun target -> target.Prop2), (fun target v -> target.Prop2 <- v))
                ...

            new ViewElement(typeof<ABC>, create, update, attribs)
```
The control is then used as follows:
```fsharp
    Xaml.ABC(Prop1 = [ Xaml.Label("hello") ], prop2 = true, property3 = "Yo!")
```

The `update` method of the extension is specified using:
* `source.UpdatePrimitive(prev, target, attribKey, setter, ?defaultValue)` - incrementally update a primitive
* `source.UpdateElement(prev, target, attribKey, getter, setter)` - incrementally update a nested element
* `source.UpdateElementCollection(prev, attribKey, targetCollection)` - incrementally update a collection of nested elements
* `source.UpdateEvent(prev, target, attribKey, setter, ?defaultValue)` - incrementally update a primitive event

Sometimes it makes sense to "massage" the input values before storing them in attibutes, e.g. to apply a conversion from an F#-friendly value
to a stored attribte value here:
```
            match prop1 with None -> () | Some v -> attribs.Add(Prop1AttribKey, box (CONV v)) 
```

It is common to mark view extensions as `inline`. This allows the F# compiler to create more optimized element-creation code for each particular instantiation
based on the small set of properties specified at a particular usage point.

### Example: Xamarin.Forms.Maps

An example for `Xamarin.Forms.Maps` is shown below - this extension is available in `Elmish.XamarinForms.Maps.dll`.
The sample implements the extension for the types [Map](https://docs.microsoft.com/dotnet/api/xamarin.forms.maps.map?view=xamarin-forms]) and
[Pin](https://docs.microsoft.com/en-gb/dotnet/api/xamarin.forms.maps.pin?view=xamarin-forms).

[![Maps example from Microsoft](https://user-images.githubusercontent.com/7204669/42186154-60437d42-7e43-11e8-805b-7200282f3b98.png)](https://user-images.githubusercontent.com/7204669/42186154-60437d42-7e43-11e8-805b-7200282f3b98.png)

> NOTE: To use `Xamarin.Forms.Maps`, you must additionally [follow the instructions to initialize Xamarin.Forms Maps](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/map#Maps_Initialization).
(For example, on Android you must enable Google Play servies, add a call to `Xamarin.FormsMaps.Init(this, bundle)` to `MainActivity.fs` and add both and API key and
`uses-permission` to `AndroidManifest.xml`.)

```fsharp
[<AutoOpen>]
module Maps =
    open Xamarin.Forms.Maps

    let MapHasScrollEnabledAttribKey = AttributeKey "Map_HasScrollEnabled"
    let MapIsShowingUserAttribKey = AttributeKey "Map_IsShowingUser"
    let MapPinsAttribKey = AttributeKey "Map_Pins"
    let MapTypeAttribKey = AttributeKey "Map_MapType"
    let MapHasZoomEnabledAttribKey = AttributeKey "Map_HasZoomEnabled"
    let MapRequestingRegionAttribKey = AttributeKey "Map_RequestedRegion"

    let PinPositionAttribKey = AttributeKey "Pin_Position"
    let PinLabelAttribKey = AttributeKey "Pin_Label"
    let PinTypeAttribKey = AttributeKey "Pin_PinType"
    let PinAddressAttribKey = AttributeKey "Pin_Address"

        /// Describes a Map in the view
        static member inline Map
            (?pins: seq<ViewElement>, ?isShowingUser: bool, ?mapType: MapType, ?hasScrollEnabled: bool, ?hasZoomEnabled: bool, ?requestedRegion: MapSpan,
             //inherited properties
             ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, 
             ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color,
             ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, 
             ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, 
             ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, 
             ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
             ?classId: string, ?styleId: string) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match pins with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match hasScrollEnabled with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match isShowingUser with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match mapType with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match hasZoomEnabled with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match requestedRegion with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = 
                Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin,
                                ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, 
                                ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, 
                                ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, 
                                ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, 
                                ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, 
                                ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

            // Add our own attributes. They must have unique names which must match the names below.
            match pins with None -> () | Some v -> attribs.Add(MapPinsAttribKey, v) 
            match hasScrollEnabled with None -> () | Some v -> attribs.Add(MapHasScrollEnabledAttribKey, v) 
            match isShowingUser with None -> () | Some v -> attribs.Add(MapIsShowingUserAttribKey, v) 
            match mapType with None -> () | Some v -> attribs.Add(MapTypeAttribKey, v) 
            match hasZoomEnabled with None -> () | Some v -> attribs.Add(MapHasZoomEnabledAttribKey, v) 
            match requestedRegion with None -> () | Some v -> attribs.Add(MapRequestingRegionAttribKey, v) 

            // The create method
            let create () = new Xamarin.Forms.Maps.Map()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: Map) = 
                Xaml._UpdateView prevOpt source (target :> View)
                source.UpdatePrimitive(prevOpt, target, MapHasScrollEnabledAttribKey, (fun target v -> target.HasScrollEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, MapHasZoomEnabledAttribKey, (fun target v -> target.HasZoomEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, MapIsShowingUserAttribKey, (fun target v -> target.IsShowingUser <- v))
                source.UpdatePrimitive(prevOpt, target, MapTypeAttribKey, (fun target v -> target.MapType <- v))
                source.UpdateElementCollection(prevOpt, MapPinsAttribKey, target.Pins)
                source.UpdatePrimitive(prevOpt, target, MapRequestingRegionAttribKey, (fun target v -> target.MoveToRegion(v)))

            // The element
            ViewElement.Create<Xamarin.Forms.Maps.Map>(create, update, attribs)

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
            match position with None -> () | Some v -> attribs.Add(PinPositionAttribKey, v) 
            match label with None -> () | Some v -> attribs.Add(PinLabelAttribKey, v) 
            match pinType with None -> () | Some v -> attribs.Add(PinTypeAttribKey, v) 
            match address with None -> () | Some v -> attribs.Add(PinAddressAttribKey, v) 

            // The create method
            let create () = box (new Xamarin.Forms.Maps.Pin())

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                let target = (targetObj :?> Xamarin.Forms.Maps.Pin)
                source.UpdatePrimitive(prevOpt, target, PinPositionAttribKey, (fun target v -> target.Position <- v))
                source.UpdatePrimitive(prevOpt, target, PinLabelAttribKey, (fun target v -> target.Label <- v))
                source.UpdatePrimitive(prevOpt, target, PinTypeAttribKey, (fun target v -> target.Type <- v))
                source.UpdatePrimitive(prevOpt, target, PinAddressAttribKey, (fun target v -> target.Address <- v))

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
In the above example, inherited properties from `View` (such as `margin` or `horizontalOptions`) have been included in the facade for `Map`.  These properties
need not be added, you can set them on elements using the helper `With`, usable for all `View` properties:
```fsharp
    Xaml.Map(hasZoomEnabled = true, hasScrollEnabled = true).With(horizontalOptions = LayoutOptions.FillAndExpand)
```

See also: 
* [Core Elements](elements.md).
* [Views and Performance](views-perf.md).

