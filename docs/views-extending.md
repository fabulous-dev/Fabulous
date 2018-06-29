Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Using Additional View Components
------

Many open source and 3rd-party Xamarin.Forms control libraries exist.  To use additional controls, a small amount of wrapper code must
be written to make the control fit the incremental-update model used by Elmish.XamarinForms.

An example for `Xamarin.Forms.Maps` is shown below. To use this sample, you must
additionally [follow the instructions Xamarin.Forms Maps](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map#Maps_Initialization).

> **NOTE** The API used to write these extensions is subject to change, as is all of this sample.

```fsharp
[<AutoOpen>]
module Maps = 
    open Xamarin.Forms.Maps
    open System.Collections.Generic

    type Xaml with
        /// Describes a Map in the view
        static member internal Map(?pins: seq<ViewElement>, ?isShowingUser: bool, ?mapType: bool, ?hasScrollEnabled: bool, ?hasZoomEnabled: bool, ?requestedRegion: bool) = 

            let baseElement : ViewElement = Xaml.View() 
            //let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
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
                source.UpdatePrimitive(prevOpt, target, "Map_HasScrollEnabled", (fun target -> target.HasScrollEnabled), (fun target v -> target.HasScrollEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_HasZoomEnabled", (fun target -> target.HasZoomEnabled), (fun target v -> target.HasZoomEnabled <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_IsShowingUser", (fun target -> target.IsShowingUser), (fun target v -> target.IsShowingUser <- v))
                source.UpdatePrimitive(prevOpt, target, "Map_MapType", (fun target -> target.MapType), (fun target v -> target.MapType <- v))
                source.UpdateElementCollection(prevOpt, target, "Map_Pins", (fun target -> target.Pins))
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
    Xaml.Map(hasZoomEnabled=true, hasScrollEnabled=true).With(horizontalOptions=LayoutOptions.FillAndExpand)
```

See also: 
* [Core Elements](elements.md).
* [Views and Performance](views-perf.md).

