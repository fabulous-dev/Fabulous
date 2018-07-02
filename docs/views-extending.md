Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Using Additional View Components
------

Many open source and 3rd-party Xamarin.Forms control libraries exist.  To use these additional controls, a small amount of wrapper code must
currently be written to make the control fit the incremental-update model used by Elmish.XamarinForms.

> NOTE: we are considering adding a code generator or type provider to automate this process, though the code is not complex to write.

The basic shape of an extension view component is shown below. Here we assume the view component defines one extra visual element
called `XYZ` that has one collection property `Property1` and two basic properties `Property2` and `Property3`.
A collection property is a one that may contain further sub-elements, e.g. `children` for StackLayout, `gestureRecognizers` for any `View`
and `pins` in the Maps example further below.

Note that an extension simply defines a static member.  The extension "extends" the existing element `Xaml.View` uses a prototype-like inheritance
mechanism.
```fsharp
module MyViewExtensions = 

	open Elmish.XamarinForms
	open Elmish.XamarinForms.DynamicViews

    type Xaml with
        /// Describes a XYZ in the view
        static member internal XYZ(?property1: seq<ViewElement>, ?property2: bool, ?property3: string) = 

            let baseElement : ViewElement = Xaml.View() 

            let attribs = [| 
                yield! baseElement.Attributes
                match property1 with None -> () | Some v -> yield KeyValuePair("XYZ_Property1", box v) 
                match property2 with None -> () | Some v -> yield KeyValuePair("XYZ_Property2", box v) 
                match property3 with None -> () | Some v -> yield KeyValuePair("XYZ_Property3", box v) 
              |]

            let create () = box (new XYZ())

            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                baseElement.UpdateMethod prevOpt source targetObj
                let target = (targetObj :?> XYZ)
                source.UpdateElementCollection(prevOpt, "XYZ_Property1", target.Property1,)
                source.UpdatePrimitive(prevOpt, target, "XYZ_Property2", (fun target -> target.Property2), (fun target v -> target.Property2 <- v))
                source.UpdatePrimitive(prevOpt, target, "XYZ_Property3", (fun target -> target.Property3), (fun target v -> target.Property3 <- v))

            new ViewElement(typeof<XYZ>, create, update, attribs)
```
The control is then used as follows:
```fsharp
    Xaml.XYZ(property1 = [ Xaml.Label("hello") ], property2 = true, property3 = "Yo!")
```


### Example: Xamarin.Forms.Maps

An example for `Xamarin.Forms.Maps` is shown below. The sample is a property mapping for the types [Map](https://docs.microsoft.com/dotnet/api/xamarin.forms.maps.map?view=xamarin-forms]) and
[Pin](https://docs.microsoft.com/en-gb/dotnet/api/xamarin.forms.maps.pin?view=xamarin-forms).

[![Maps in the MobileCRM sample](map-images/maps-zoom-sml.png "Map Control Example")](https://docs.microsoft.com/en-gb/xamarin/xamarin-forms/user-interface/map-images/maps-zoom-sml.png)

> NOTE: To use `Xamarin.Forms.Maps`, you must additionally [follow the instructions to initialize Xamarin.Forms Maps](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/map#Maps_Initialization).
(For example, on Android you must enable Google Play servies, add a call to `Xamarin.FormsMaps.Init(this, bundle)` to `MainActivity.fs` and add both and API key and
`uses-permission` to `AndroidManifest.xml`.)
> 
> **NOTE** The API used to write these extensions is subject to change, as is all of `Elmish.XamarinForms`.

```fsharp
[<AutoOpen>]
module Maps = 
    open Xamarin.Forms.Maps
    open System.Collections.Generic

    type Xaml with
        /// Describes a Map in the view
        static member internal Map(?pins: seq<ViewElement>, ?isShowingUser: bool, ?mapType: bool, ?hasScrollEnabled: bool, ?hasZoomEnabled: bool, ?requestedRegion: bool) = 

            let baseElement : ViewElement = Xaml.View() 
            let attribs = [| 
                yield! baseElement.Attributes
                match pins with None -> () | Some v -> yield KeyValuePair("Map_Pins", box v) 
                match hasScrollEnabled with None -> () | Some v -> yield KeyValuePair("Map_HasScrollEnabled", box v) 
                match isShowingUser with None -> () | Some v -> yield KeyValuePair("Map_IsShowingUser", box v) 
                match mapType with None -> () | Some v -> yield KeyValuePair("Map_MapType", box v) 
                match hasZoomEnabled with None -> () | Some v -> yield KeyValuePair("Map_HasZoomEnabled", box v) 
                match requestedRegion with None -> () | Some v -> yield KeyValuePair("Map_RequestedRegion", box v) 
              |]

            let create () = box (new Xamarin.Forms.Maps.Map())

            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                baseElement.UpdateMethod prevOpt source targetObj
                let target = (targetObj :?> Xamarin.Forms.Maps.Map)
                source.UpdateElementCollection(prevOpt, target, "Map_Pins", (fun target -> target.Pins))
                source.UpdatePrimitive(prevOpt, target, "Map_HasScrollEnabled", (fun target -> target.HasScrollEnabled), (fun target v -> target.HasScrollEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_HasZoomEnabled", (fun target -> target.HasZoomEnabled), (fun target v -> target.HasZoomEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_IsShowingUser", (fun target -> target.IsShowingUser), (fun target v -> target.IsShowingUser <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_MapType", (fun target -> target.MapType), (fun target v -> target.MapType <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_RequestedRegion", (fun target -> target.VisibleRegion), (fun target v -> target.MoveToRegion(v)))

            new ViewElement(typeof<Xamarin.Forms.Maps.Map>, create, update, attribs)

        /// Describes a Pin in the view
        static member internal Pin(?position: Position, ?label: string, ?pinType: PinType, ?address: string) = 

            let attribs = [| 
                match position with None -> () | Some v -> yield KeyValuePair("Pin_Position", box v) 
                match label with None -> () | Some v -> yield KeyValuePair("Pin_Label", box v) 
                match pinType with None -> () | Some v -> yield KeyValuePair("Pin_Type", box v) 
                match address with None -> () | Some v -> yield KeyValuePair("Pin_Address", box v) 
              |]

            let create () = box (new Xamarin.Forms.Maps.Pin())

            let update (prevOpt: ViewElement voption) (source: ViewElement) (targetObj:obj) = 
                let target = (targetObj :?> Xamarin.Forms.Maps.Pin)
                source.UpdatePrimitive(prevOpt, target, "Pin_Position", (fun target -> target.Position), (fun target v -> target.Position <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Label", (fun target -> target.Label), (fun target v -> target.Label <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Type", (fun target -> target.Type), (fun target v -> target.Type <- v))
                source.UpdatePrimitive(prevOpt, target, "Pin_Address", (fun target -> target.Address), (fun target v -> target.Address <- v))

            new ViewElement(typeof<Xamarin.Forms.Maps.Pin>, create, update, attribs)
```
The control is then used as follows:
```fsharp
    Xaml.Map(hasZoomEnabled = true, hasScrollEnabled = true).With(horizontalOptions = LayoutOptions.FillAndExpand)
```
Pins can be added using:
```fsharp
    Xaml.Map(pins = [ Xaml.Pin(...); Xaml.Pin(...) ])
```

See also: 
* [Core Elements](elements.md).
* [Views and Performance](views-perf.md).

