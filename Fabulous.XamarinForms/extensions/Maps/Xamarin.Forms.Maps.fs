// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Maps

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let MapClickedAttribKey : AttributeKey<_> = AttributeKey<_>("MapClicked")
    let HasScrollEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("HasScrollEnabled")
    let HasZoomEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("HasZoomEnabled")
    let IsShowingUserAttribKey : AttributeKey<_> = AttributeKey<_>("IsShowingUser")
    let MapTypeAttribKey : AttributeKey<_> = AttributeKey<_>("MapType")
    let MoveToLastRegionOnLayoutChangeAttribKey : AttributeKey<_> = AttributeKey<_>("MoveToLastRegionOnLayoutChange")
    let PinsAttribKey : AttributeKey<_> = AttributeKey<_>("Pins")
    let MapElementsAttribKey : AttributeKey<_> = AttributeKey<_>("MapElements")
    let RequestedRegionAttribKey : AttributeKey<_> = AttributeKey<_>("RequestedRegion")
    let StrokeColorAttribKey : AttributeKey<_> = AttributeKey<_>("StrokeColor")
    let StrokeWidthAttribKey : AttributeKey<_> = AttributeKey<_>("StrokeWidth")
    let FillColorAttribKey : AttributeKey<_> = AttributeKey<_>("FillColor")
    let GeopathAttribKey : AttributeKey<_> = AttributeKey<_>("Geopath")
    let ClickedAttribKey : AttributeKey<_> = AttributeKey<_>("Clicked")
    let MarkerClickedAttribKey : AttributeKey<_> = AttributeKey<_>("MarkerClicked")
    let InfoWindowClickedAttribKey : AttributeKey<_> = AttributeKey<_>("InfoWindowClicked")
    let AddressAttribKey : AttributeKey<_> = AttributeKey<_>("Address")
    let LabelAttribKey : AttributeKey<_> = AttributeKey<_>("Label")
    let PinPositionAttribKey : AttributeKey<_> = AttributeKey<_>("PinPosition")
    let PinTypeAttribKey : AttributeKey<_> = AttributeKey<_>("PinType")

type ViewBuilders() =
    /// Builds the attributes for a Map in the view
    static member inline BuildMap(attribCount: int,
                                  ?hasScrollEnabled: bool,
                                  ?hasZoomEnabled: bool,
                                  ?isShowingUser: bool,
                                  ?mapType: Xamarin.Forms.Maps.MapType,
                                  ?moveToLastRegionOnLayoutChange: bool,
                                  ?pins: ViewElement list,
                                  ?mapElements: ViewElement list,
                                  ?requestedRegion: Xamarin.Forms.Maps.MapSpan,
                                  ?gestureRecognizers: ViewElement list,
                                  ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                  ?margin: Xamarin.Forms.Thickness,
                                  ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                  ?anchorX: float,
                                  ?anchorY: float,
                                  ?backgroundColor: Xamarin.Forms.Color,
                                  ?behaviors: ViewElement list,
                                  ?flowDirection: Xamarin.Forms.FlowDirection,
                                  ?height: float,
                                  ?inputTransparent: bool,
                                  ?isEnabled: bool,
                                  ?isTabStop: bool,
                                  ?isVisible: bool,
                                  ?minimumHeight: float,
                                  ?minimumWidth: float,
                                  ?opacity: float,
                                  ?resources: (string * obj) list,
                                  ?rotation: float,
                                  ?rotationX: float,
                                  ?rotationY: float,
                                  ?scale: float,
                                  ?scaleX: float,
                                  ?scaleY: float,
                                  ?styles: Xamarin.Forms.Style list,
                                  ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                  ?tabIndex: int,
                                  ?translationX: float,
                                  ?translationY: float,
                                  ?visual: Xamarin.Forms.IVisual,
                                  ?width: float,
                                  ?style: Xamarin.Forms.Style,
                                  ?styleClasses: string list,
                                  ?shellBackButtonBehavior: ViewElement,
                                  ?shellBackgroundColor: Xamarin.Forms.Color,
                                  ?shellDisabledColor: Xamarin.Forms.Color,
                                  ?shellForegroundColor: Xamarin.Forms.Color,
                                  ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                                  ?shellNavBarIsVisible: bool,
                                  ?shellSearchHandler: ViewElement,
                                  ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                                  ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                                  ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                                  ?shellTabBarIsVisible: bool,
                                  ?shellTabBarTitleColor: Xamarin.Forms.Color,
                                  ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                                  ?shellTitleColor: Xamarin.Forms.Color,
                                  ?shellTitleView: ViewElement,
                                  ?shellUnselectedColor: Xamarin.Forms.Color,
                                  ?shellNavBarHasShadow: bool,
                                  ?automationId: string,
                                  ?classId: string,
                                  ?effects: ViewElement list,
                                  ?menu: ViewElement,
                                  ?styleId: string,
                                  ?ref: ViewRef,
                                  ?tag: obj,
                                  ?mapClicked: Xamarin.Forms.Maps.MapClickedEventArgs -> unit,
                                  ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                  ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                  ?created: obj -> unit) = 

        let attribCount = match hasScrollEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasZoomEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isShowingUser with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match mapType with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match moveToLastRegionOnLayoutChange with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pins with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match mapElements with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match requestedRegion with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match mapClicked with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?gestureRecognizers=gestureRecognizers, ?horizontalOptions=horizontalOptions, ?margin=margin, ?verticalOptions=verticalOptions, ?anchorX=anchorX, 
                                                   ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?behaviors=behaviors, ?flowDirection=flowDirection, ?height=height, 
                                                   ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isTabStop=isTabStop, ?isVisible=isVisible, ?minimumHeight=minimumHeight, 
                                                   ?minimumWidth=minimumWidth, ?opacity=opacity, ?resources=resources, ?rotation=rotation, ?rotationX=rotationX, 
                                                   ?rotationY=rotationY, ?scale=scale, ?scaleX=scaleX, ?scaleY=scaleY, ?styles=styles, 
                                                   ?styleSheets=styleSheets, ?tabIndex=tabIndex, ?translationX=translationX, ?translationY=translationY, ?visual=visual, 
                                                   ?width=width, ?style=style, ?styleClasses=styleClasses, ?shellBackButtonBehavior=shellBackButtonBehavior, ?shellBackgroundColor=shellBackgroundColor, 
                                                   ?shellDisabledColor=shellDisabledColor, ?shellForegroundColor=shellForegroundColor, ?shellFlyoutBehavior=shellFlyoutBehavior, ?shellNavBarIsVisible=shellNavBarIsVisible, ?shellSearchHandler=shellSearchHandler, 
                                                   ?shellTabBarBackgroundColor=shellTabBarBackgroundColor, ?shellTabBarDisabledColor=shellTabBarDisabledColor, ?shellTabBarForegroundColor=shellTabBarForegroundColor, ?shellTabBarIsVisible=shellTabBarIsVisible, ?shellTabBarTitleColor=shellTabBarTitleColor, 
                                                   ?shellTabBarUnselectedColor=shellTabBarUnselectedColor, ?shellTitleColor=shellTitleColor, ?shellTitleView=shellTitleView, ?shellUnselectedColor=shellUnselectedColor, ?shellNavBarHasShadow=shellNavBarHasShadow, 
                                                   ?automationId=automationId, ?classId=classId, ?effects=effects, ?menu=menu, ?styleId=styleId, 
                                                   ?ref=ref, ?tag=tag, ?focused=focused, ?unfocused=unfocused, ?created=created)
        match hasScrollEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.HasScrollEnabledAttribKey, (v)) 
        match hasZoomEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.HasZoomEnabledAttribKey, (v)) 
        match isShowingUser with None -> () | Some v -> attribBuilder.Add(ViewAttributes.IsShowingUserAttribKey, (v)) 
        match mapType with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MapTypeAttribKey, (v)) 
        match moveToLastRegionOnLayoutChange with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MoveToLastRegionOnLayoutChangeAttribKey, (v)) 
        match pins with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinsAttribKey, Array.ofList(v)) 
        match mapElements with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MapElementsAttribKey, Array.ofList(v)) 
        match requestedRegion with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RequestedRegionAttribKey, (v)) 
        match mapClicked with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MapClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs>(fun _sender _args -> f _args))(v)) 
        attribBuilder

    static member CreateMap () : Xamarin.Forms.Maps.Map =
        Xamarin.Forms.Maps.Map()

    static member UpdateMap (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Maps.Map) = 
        let mutable prevMapClickedOpt = ValueNone
        let mutable currMapClickedOpt = ValueNone
        let mutable prevHasScrollEnabledOpt = ValueNone
        let mutable currHasScrollEnabledOpt = ValueNone
        let mutable prevHasZoomEnabledOpt = ValueNone
        let mutable currHasZoomEnabledOpt = ValueNone
        let mutable prevIsShowingUserOpt = ValueNone
        let mutable currIsShowingUserOpt = ValueNone
        let mutable prevMapTypeOpt = ValueNone
        let mutable currMapTypeOpt = ValueNone
        let mutable prevMoveToLastRegionOnLayoutChangeOpt = ValueNone
        let mutable currMoveToLastRegionOnLayoutChangeOpt = ValueNone
        let mutable prevPinsOpt = ValueNone
        let mutable currPinsOpt = ValueNone
        let mutable prevMapElementsOpt = ValueNone
        let mutable currMapElementsOpt = ValueNone
        let mutable prevRequestedRegionOpt = ValueNone
        let mutable currRequestedRegionOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.MapClickedAttribKey.KeyValue then 
                currMapClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs>)
            if kvp.Key = ViewAttributes.HasScrollEnabledAttribKey.KeyValue then 
                currHasScrollEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.HasZoomEnabledAttribKey.KeyValue then 
                currHasZoomEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.IsShowingUserAttribKey.KeyValue then 
                currIsShowingUserOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.MapTypeAttribKey.KeyValue then 
                currMapTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.MapType)
            if kvp.Key = ViewAttributes.MoveToLastRegionOnLayoutChangeAttribKey.KeyValue then 
                currMoveToLastRegionOnLayoutChangeOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.PinsAttribKey.KeyValue then 
                currPinsOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.MapElementsAttribKey.KeyValue then 
                currMapElementsOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.RequestedRegionAttribKey.KeyValue then 
                currRequestedRegionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.MapSpan)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.MapClickedAttribKey.KeyValue then 
                    prevMapClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs>)
                if kvp.Key = ViewAttributes.HasScrollEnabledAttribKey.KeyValue then 
                    prevHasScrollEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.HasZoomEnabledAttribKey.KeyValue then 
                    prevHasZoomEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.IsShowingUserAttribKey.KeyValue then 
                    prevIsShowingUserOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.MapTypeAttribKey.KeyValue then 
                    prevMapTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.MapType)
                if kvp.Key = ViewAttributes.MoveToLastRegionOnLayoutChangeAttribKey.KeyValue then 
                    prevMoveToLastRegionOnLayoutChangeOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.PinsAttribKey.KeyValue then 
                    prevPinsOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.MapElementsAttribKey.KeyValue then 
                    prevMapElementsOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.RequestedRegionAttribKey.KeyValue then 
                    prevRequestedRegionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.MapSpan)
        // Unsubscribe previous event handlers
        let shouldUpdateMapClicked = not ((identical prevMapClickedOpt currMapClickedOpt))
        if shouldUpdateMapClicked then
            match prevMapClickedOpt with
            | ValueSome prevValue -> target.MapClicked.RemoveHandler(prevValue)
            | ValueNone -> ()
        // Update inherited members
        ViewBuilders.UpdateView (prevOpt, curr, target)
        // Update properties
        match prevHasScrollEnabledOpt, currHasScrollEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasScrollEnabled <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Map.HasScrollEnabledProperty
        | ValueNone, ValueNone -> ()
        match prevHasZoomEnabledOpt, currHasZoomEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasZoomEnabled <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Map.HasZoomEnabledProperty
        | ValueNone, ValueNone -> ()
        match prevIsShowingUserOpt, currIsShowingUserOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsShowingUser <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Map.IsShowingUserProperty
        | ValueNone, ValueNone -> ()
        match prevMapTypeOpt, currMapTypeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MapType <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Map.MapTypeProperty
        | ValueNone, ValueNone -> ()
        match prevMoveToLastRegionOnLayoutChangeOpt, currMoveToLastRegionOnLayoutChangeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MoveToLastRegionOnLayoutChange <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Map.MoveToLastRegionOnLayoutChangeProperty
        | ValueNone, ValueNone -> ()
        ViewUpdaters.updateCollectionGeneric prevPinsOpt currPinsOpt target.Pins
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Maps.Pin)
            (fun _ _ _ -> ())
            ViewHelpers.canReuseView
            ViewUpdaters.updateChild
        ViewUpdaters.updateCollectionGeneric prevMapElementsOpt currMapElementsOpt target.MapElements
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Maps.MapElement)
            (fun _ _ _ -> ())
            ViewHelpers.canReuseView
            ViewUpdaters.updateChild
        ViewUpdaters.updateMapRequestedRegion prevRequestedRegionOpt currRequestedRegionOpt target
        // Subscribe new event handlers
        if shouldUpdateMapClicked then
            match currMapClickedOpt with
            | ValueSome currValue -> target.MapClicked.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructMap(?hasScrollEnabled: bool,
                                      ?hasZoomEnabled: bool,
                                      ?isShowingUser: bool,
                                      ?mapType: Xamarin.Forms.Maps.MapType,
                                      ?moveToLastRegionOnLayoutChange: bool,
                                      ?pins: ViewElement list,
                                      ?mapElements: ViewElement list,
                                      ?requestedRegion: Xamarin.Forms.Maps.MapSpan,
                                      ?gestureRecognizers: ViewElement list,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: Xamarin.Forms.Thickness,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?anchorX: float,
                                      ?anchorY: float,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?behaviors: ViewElement list,
                                      ?flowDirection: Xamarin.Forms.FlowDirection,
                                      ?height: float,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isTabStop: bool,
                                      ?isVisible: bool,
                                      ?minimumHeight: float,
                                      ?minimumWidth: float,
                                      ?opacity: float,
                                      ?resources: (string * obj) list,
                                      ?rotation: float,
                                      ?rotationX: float,
                                      ?rotationY: float,
                                      ?scale: float,
                                      ?scaleX: float,
                                      ?scaleY: float,
                                      ?styles: Xamarin.Forms.Style list,
                                      ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                      ?tabIndex: int,
                                      ?translationX: float,
                                      ?translationY: float,
                                      ?visual: Xamarin.Forms.IVisual,
                                      ?width: float,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClasses: string list,
                                      ?shellBackButtonBehavior: ViewElement,
                                      ?shellBackgroundColor: Xamarin.Forms.Color,
                                      ?shellDisabledColor: Xamarin.Forms.Color,
                                      ?shellForegroundColor: Xamarin.Forms.Color,
                                      ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                                      ?shellNavBarIsVisible: bool,
                                      ?shellSearchHandler: ViewElement,
                                      ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                                      ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                                      ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                                      ?shellTabBarIsVisible: bool,
                                      ?shellTabBarTitleColor: Xamarin.Forms.Color,
                                      ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                                      ?shellTitleColor: Xamarin.Forms.Color,
                                      ?shellTitleView: ViewElement,
                                      ?shellUnselectedColor: Xamarin.Forms.Color,
                                      ?shellNavBarHasShadow: bool,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?effects: ViewElement list,
                                      ?menu: ViewElement,
                                      ?styleId: string,
                                      ?ref: ViewRef<Xamarin.Forms.Maps.Map>,
                                      ?tag: obj,
                                      ?mapClicked: Xamarin.Forms.Maps.MapClickedEventArgs -> unit,
                                      ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?created: (Xamarin.Forms.Maps.Map -> unit)) = 

        let attribBuilder = ViewBuilders.BuildMap(0,
                               ?hasScrollEnabled=hasScrollEnabled,
                               ?hasZoomEnabled=hasZoomEnabled,
                               ?isShowingUser=isShowingUser,
                               ?mapType=mapType,
                               ?moveToLastRegionOnLayoutChange=moveToLastRegionOnLayoutChange,
                               ?pins=pins,
                               ?mapElements=mapElements,
                               ?requestedRegion=requestedRegion,
                               ?gestureRecognizers=gestureRecognizers,
                               ?horizontalOptions=horizontalOptions,
                               ?margin=margin,
                               ?verticalOptions=verticalOptions,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?behaviors=behaviors,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?resources=resources,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClasses=styleClasses,
                               ?shellBackButtonBehavior=shellBackButtonBehavior,
                               ?shellBackgroundColor=shellBackgroundColor,
                               ?shellDisabledColor=shellDisabledColor,
                               ?shellForegroundColor=shellForegroundColor,
                               ?shellFlyoutBehavior=shellFlyoutBehavior,
                               ?shellNavBarIsVisible=shellNavBarIsVisible,
                               ?shellSearchHandler=shellSearchHandler,
                               ?shellTabBarBackgroundColor=shellTabBarBackgroundColor,
                               ?shellTabBarDisabledColor=shellTabBarDisabledColor,
                               ?shellTabBarForegroundColor=shellTabBarForegroundColor,
                               ?shellTabBarIsVisible=shellTabBarIsVisible,
                               ?shellTabBarTitleColor=shellTabBarTitleColor,
                               ?shellTabBarUnselectedColor=shellTabBarUnselectedColor,
                               ?shellTitleColor=shellTitleColor,
                               ?shellTitleView=shellTitleView,
                               ?shellUnselectedColor=shellUnselectedColor,
                               ?shellNavBarHasShadow=shellNavBarHasShadow,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?effects=effects,
                               ?menu=menu,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Maps.Map>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?mapClicked=mapClicked,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Maps.Map> target))))

        ViewElement.Create<Xamarin.Forms.Maps.Map>(ViewBuilders.CreateMap, (fun prevOpt curr target -> ViewBuilders.UpdateMap(prevOpt, curr, target)), attribBuilder)

    /// Builds the attributes for a MapElement in the view
    static member inline BuildMapElement(attribCount: int,
                                         ?strokeColor: Xamarin.Forms.Color,
                                         ?strokeWidth: single,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?effects: ViewElement list,
                                         ?menu: ViewElement,
                                         ?styleId: string,
                                         ?ref: ViewRef,
                                         ?tag: obj,
                                         ?created: obj -> unit) = 

        let attribCount = match strokeColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match strokeWidth with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId=automationId, ?classId=classId, ?effects=effects, ?menu=menu, ?styleId=styleId, 
                                                      ?ref=ref, ?tag=tag, ?created=created)
        match strokeColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StrokeColorAttribKey, (v)) 
        match strokeWidth with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StrokeWidthAttribKey, (v)) 
        attribBuilder

    static member UpdateMapElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Maps.MapElement) = 
        let mutable prevStrokeColorOpt = ValueNone
        let mutable currStrokeColorOpt = ValueNone
        let mutable prevStrokeWidthOpt = ValueNone
        let mutable currStrokeWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.StrokeColorAttribKey.KeyValue then 
                currStrokeColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.StrokeWidthAttribKey.KeyValue then 
                currStrokeWidthOpt <- ValueSome (kvp.Value :?> single)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.StrokeColorAttribKey.KeyValue then 
                    prevStrokeColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.StrokeWidthAttribKey.KeyValue then 
                    prevStrokeWidthOpt <- ValueSome (kvp.Value :?> single)
        // Update inherited members
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        // Update properties
        match prevStrokeColorOpt, currStrokeColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StrokeColor <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.MapElement.StrokeColorProperty
        | ValueNone, ValueNone -> ()
        match prevStrokeWidthOpt, currStrokeWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StrokeWidth <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.MapElement.StrokeWidthProperty
        | ValueNone, ValueNone -> ()

    /// Builds the attributes for a Polygon in the view
    static member inline BuildPolygon(attribCount: int,
                                      ?fillColor: Xamarin.Forms.Color,
                                      ?geopath: Xamarin.Forms.Maps.Position list,
                                      ?strokeColor: Xamarin.Forms.Color,
                                      ?strokeWidth: single,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?effects: ViewElement list,
                                      ?menu: ViewElement,
                                      ?styleId: string,
                                      ?ref: ViewRef,
                                      ?tag: obj,
                                      ?created: obj -> unit) = 

        let attribCount = match fillColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match geopath with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildMapElement(attribCount, ?strokeColor=strokeColor, ?strokeWidth=strokeWidth, ?automationId=automationId, ?classId=classId, ?effects=effects, 
                                                         ?menu=menu, ?styleId=styleId, ?ref=ref, ?tag=tag, ?created=created)
        match fillColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FillColorAttribKey, (v)) 
        match geopath with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GeopathAttribKey, Array.ofList(v)) 
        attribBuilder

    static member CreatePolygon () : Xamarin.Forms.Maps.Polygon =
        Xamarin.Forms.Maps.Polygon()

    static member UpdatePolygon (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Maps.Polygon) = 
        let mutable prevFillColorOpt = ValueNone
        let mutable currFillColorOpt = ValueNone
        let mutable prevGeopathOpt = ValueNone
        let mutable currGeopathOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.FillColorAttribKey.KeyValue then 
                currFillColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.GeopathAttribKey.KeyValue then 
                currGeopathOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position array)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.FillColorAttribKey.KeyValue then 
                    prevFillColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.GeopathAttribKey.KeyValue then 
                    prevGeopathOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position array)
        // Update inherited members
        ViewBuilders.UpdateMapElement (prevOpt, curr, target)
        // Update properties
        match prevFillColorOpt, currFillColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FillColor <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Polygon.FillColorProperty
        | ValueNone, ValueNone -> ()
        ViewUpdaters.updatePolygonGeopath prevGeopathOpt currGeopathOpt target
            (fun _ _ _ -> ())

    static member inline ConstructPolygon(?fillColor: Xamarin.Forms.Color,
                                          ?geopath: Xamarin.Forms.Maps.Position list,
                                          ?strokeColor: Xamarin.Forms.Color,
                                          ?strokeWidth: single,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?effects: ViewElement list,
                                          ?menu: ViewElement,
                                          ?styleId: string,
                                          ?ref: ViewRef<Xamarin.Forms.Maps.Polygon>,
                                          ?tag: obj,
                                          ?created: (Xamarin.Forms.Maps.Polygon -> unit)) = 

        let attribBuilder = ViewBuilders.BuildPolygon(0,
                               ?fillColor=fillColor,
                               ?geopath=geopath,
                               ?strokeColor=strokeColor,
                               ?strokeWidth=strokeWidth,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?effects=effects,
                               ?menu=menu,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Maps.Polygon>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Maps.Polygon> target))))

        ViewElement.Create<Xamarin.Forms.Maps.Polygon>(ViewBuilders.CreatePolygon, (fun prevOpt curr target -> ViewBuilders.UpdatePolygon(prevOpt, curr, target)), attribBuilder)

    /// Builds the attributes for a Polyline in the view
    static member inline BuildPolyline(attribCount: int,
                                       ?geopath: Xamarin.Forms.Maps.Position list,
                                       ?strokeColor: Xamarin.Forms.Color,
                                       ?strokeWidth: single,
                                       ?automationId: string,
                                       ?classId: string,
                                       ?effects: ViewElement list,
                                       ?menu: ViewElement,
                                       ?styleId: string,
                                       ?ref: ViewRef,
                                       ?tag: obj,
                                       ?created: obj -> unit) = 

        let attribCount = match geopath with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildMapElement(attribCount, ?strokeColor=strokeColor, ?strokeWidth=strokeWidth, ?automationId=automationId, ?classId=classId, ?effects=effects, 
                                                         ?menu=menu, ?styleId=styleId, ?ref=ref, ?tag=tag, ?created=created)
        match geopath with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GeopathAttribKey, Array.ofList(v)) 
        attribBuilder

    static member CreatePolyline () : Xamarin.Forms.Maps.Polyline =
        Xamarin.Forms.Maps.Polyline()

    static member UpdatePolyline (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Maps.Polyline) = 
        let mutable prevGeopathOpt = ValueNone
        let mutable currGeopathOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.GeopathAttribKey.KeyValue then 
                currGeopathOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position array)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.GeopathAttribKey.KeyValue then 
                    prevGeopathOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position array)
        // Update inherited members
        ViewBuilders.UpdateMapElement (prevOpt, curr, target)
        // Update properties
        ViewUpdaters.updatePolylineGeopath prevGeopathOpt currGeopathOpt target
            (fun _ _ _ -> ())

    static member inline ConstructPolyline(?geopath: Xamarin.Forms.Maps.Position list,
                                           ?strokeColor: Xamarin.Forms.Color,
                                           ?strokeWidth: single,
                                           ?automationId: string,
                                           ?classId: string,
                                           ?effects: ViewElement list,
                                           ?menu: ViewElement,
                                           ?styleId: string,
                                           ?ref: ViewRef<Xamarin.Forms.Maps.Polyline>,
                                           ?tag: obj,
                                           ?created: (Xamarin.Forms.Maps.Polyline -> unit)) = 

        let attribBuilder = ViewBuilders.BuildPolyline(0,
                               ?geopath=geopath,
                               ?strokeColor=strokeColor,
                               ?strokeWidth=strokeWidth,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?effects=effects,
                               ?menu=menu,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Maps.Polyline>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Maps.Polyline> target))))

        ViewElement.Create<Xamarin.Forms.Maps.Polyline>(ViewBuilders.CreatePolyline, (fun prevOpt curr target -> ViewBuilders.UpdatePolyline(prevOpt, curr, target)), attribBuilder)

    /// Builds the attributes for a Pin in the view
    static member inline BuildPin(attribCount: int,
                                  ?address: string,
                                  ?label: string,
                                  ?position: Xamarin.Forms.Maps.Position,
                                  ?pinType: Xamarin.Forms.Maps.PinType,
                                  ?automationId: string,
                                  ?classId: string,
                                  ?effects: ViewElement list,
                                  ?menu: ViewElement,
                                  ?styleId: string,
                                  ?ref: ViewRef,
                                  ?tag: obj,
                                  ?clicked: unit -> unit,
                                  ?markerClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                                  ?infoWindowClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                                  ?created: obj -> unit) = 

        let attribCount = match address with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match label with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match position with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pinType with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match clicked with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match markerClicked with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match infoWindowClicked with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId=automationId, ?classId=classId, ?effects=effects, ?menu=menu, ?styleId=styleId, 
                                                      ?ref=ref, ?tag=tag, ?created=created)
        match address with None -> () | Some v -> attribBuilder.Add(ViewAttributes.AddressAttribKey, (v)) 
        match label with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LabelAttribKey, (v)) 
        match position with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinPositionAttribKey, (v)) 
        match pinType with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinTypeAttribKey, (v)) 
        match clicked with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f()))(v)) 
        match markerClicked with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MarkerClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>(fun _sender _args -> f _args))(v)) 
        match infoWindowClicked with None -> () | Some v -> attribBuilder.Add(ViewAttributes.InfoWindowClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>(fun _sender _args -> f _args))(v)) 
        attribBuilder

    static member CreatePin () : Xamarin.Forms.Maps.Pin =
        Xamarin.Forms.Maps.Pin()

    static member UpdatePin (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Maps.Pin) = 
        let mutable prevClickedOpt = ValueNone
        let mutable currClickedOpt = ValueNone
        let mutable prevMarkerClickedOpt = ValueNone
        let mutable currMarkerClickedOpt = ValueNone
        let mutable prevInfoWindowClickedOpt = ValueNone
        let mutable currInfoWindowClickedOpt = ValueNone
        let mutable prevAddressOpt = ValueNone
        let mutable currAddressOpt = ValueNone
        let mutable prevLabelOpt = ValueNone
        let mutable currLabelOpt = ValueNone
        let mutable prevPinPositionOpt = ValueNone
        let mutable currPinPositionOpt = ValueNone
        let mutable prevPinTypeOpt = ValueNone
        let mutable currPinTypeOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ClickedAttribKey.KeyValue then 
                currClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = ViewAttributes.MarkerClickedAttribKey.KeyValue then 
                currMarkerClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>)
            if kvp.Key = ViewAttributes.InfoWindowClickedAttribKey.KeyValue then 
                currInfoWindowClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>)
            if kvp.Key = ViewAttributes.AddressAttribKey.KeyValue then 
                currAddressOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.LabelAttribKey.KeyValue then 
                currLabelOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.PinPositionAttribKey.KeyValue then 
                currPinPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position)
            if kvp.Key = ViewAttributes.PinTypeAttribKey.KeyValue then 
                currPinTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.PinType)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ClickedAttribKey.KeyValue then 
                    prevClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = ViewAttributes.MarkerClickedAttribKey.KeyValue then 
                    prevMarkerClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>)
                if kvp.Key = ViewAttributes.InfoWindowClickedAttribKey.KeyValue then 
                    prevInfoWindowClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>)
                if kvp.Key = ViewAttributes.AddressAttribKey.KeyValue then 
                    prevAddressOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.LabelAttribKey.KeyValue then 
                    prevLabelOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.PinPositionAttribKey.KeyValue then 
                    prevPinPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.Position)
                if kvp.Key = ViewAttributes.PinTypeAttribKey.KeyValue then 
                    prevPinTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Maps.PinType)
        // Unsubscribe previous event handlers
        let shouldUpdateClicked = not ((identical prevClickedOpt currClickedOpt))
        if shouldUpdateClicked then
            match prevClickedOpt with
            | ValueSome prevValue -> target.Clicked.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateMarkerClicked = not ((identical prevMarkerClickedOpt currMarkerClickedOpt))
        if shouldUpdateMarkerClicked then
            match prevMarkerClickedOpt with
            | ValueSome prevValue -> target.MarkerClicked.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateInfoWindowClicked = not ((identical prevInfoWindowClickedOpt currInfoWindowClickedOpt))
        if shouldUpdateInfoWindowClicked then
            match prevInfoWindowClickedOpt with
            | ValueSome prevValue -> target.InfoWindowClicked.RemoveHandler(prevValue)
            | ValueNone -> ()
        // Update inherited members
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        // Update properties
        match prevAddressOpt, currAddressOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Address <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Pin.AddressProperty
        | ValueNone, ValueNone -> ()
        match prevLabelOpt, currLabelOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Label <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Pin.LabelProperty
        | ValueNone, ValueNone -> ()
        match prevPinPositionOpt, currPinPositionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Position <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Pin.PositionProperty
        | ValueNone, ValueNone -> ()
        match prevPinTypeOpt, currPinTypeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Type <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue Xamarin.Forms.Maps.Pin.TypeProperty
        | ValueNone, ValueNone -> ()
        // Subscribe new event handlers
        if shouldUpdateClicked then
            match currClickedOpt with
            | ValueSome currValue -> target.Clicked.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateMarkerClicked then
            match currMarkerClickedOpt with
            | ValueSome currValue -> target.MarkerClicked.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateInfoWindowClicked then
            match currInfoWindowClickedOpt with
            | ValueSome currValue -> target.InfoWindowClicked.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructPin(?address: string,
                                      ?label: string,
                                      ?position: Xamarin.Forms.Maps.Position,
                                      ?pinType: Xamarin.Forms.Maps.PinType,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?effects: ViewElement list,
                                      ?menu: ViewElement,
                                      ?styleId: string,
                                      ?ref: ViewRef<Xamarin.Forms.Maps.Pin>,
                                      ?tag: obj,
                                      ?clicked: unit -> unit,
                                      ?markerClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                                      ?infoWindowClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                                      ?created: (Xamarin.Forms.Maps.Pin -> unit)) = 

        let attribBuilder = ViewBuilders.BuildPin(0,
                               ?address=address,
                               ?label=label,
                               ?position=position,
                               ?pinType=pinType,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?effects=effects,
                               ?menu=menu,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Maps.Pin>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?clicked=clicked,
                               ?markerClicked=markerClicked,
                               ?infoWindowClicked=infoWindowClicked,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Maps.Pin> target))))

        ViewElement.Create<Xamarin.Forms.Maps.Pin>(ViewBuilders.CreatePin, (fun prevOpt curr target -> ViewBuilders.UpdatePin(prevOpt, curr, target)), attribBuilder)

/// Viewer that allows to read the properties of a ViewElement representing a Map
type MapViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Maps.Map>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Maps.Map' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the HasScrollEnabled member
    member this.HasScrollEnabled = element.GetAttributeKeyed(ViewAttributes.HasScrollEnabledAttribKey)
    /// Get the value of the HasZoomEnabled member
    member this.HasZoomEnabled = element.GetAttributeKeyed(ViewAttributes.HasZoomEnabledAttribKey)
    /// Get the value of the IsShowingUser member
    member this.IsShowingUser = element.GetAttributeKeyed(ViewAttributes.IsShowingUserAttribKey)
    /// Get the value of the MapType member
    member this.MapType = element.GetAttributeKeyed(ViewAttributes.MapTypeAttribKey)
    /// Get the value of the MoveToLastRegionOnLayoutChange member
    member this.MoveToLastRegionOnLayoutChange = element.GetAttributeKeyed(ViewAttributes.MoveToLastRegionOnLayoutChangeAttribKey)
    /// Get the value of the Pins member
    member this.Pins = element.GetAttributeKeyed(ViewAttributes.PinsAttribKey)
    /// Get the value of the MapElements member
    member this.MapElements = element.GetAttributeKeyed(ViewAttributes.MapElementsAttribKey)
    /// Get the value of the RequestedRegion member
    member this.RequestedRegion = element.GetAttributeKeyed(ViewAttributes.RequestedRegionAttribKey)
    /// Get the value of the MapClicked member
    member this.MapClicked = element.GetAttributeKeyed(ViewAttributes.MapClickedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a MapElement
type MapElementViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Maps.MapElement>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Maps.MapElement' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the StrokeColor member
    member this.StrokeColor = element.GetAttributeKeyed(ViewAttributes.StrokeColorAttribKey)
    /// Get the value of the StrokeWidth member
    member this.StrokeWidth = element.GetAttributeKeyed(ViewAttributes.StrokeWidthAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Polygon
type PolygonViewer(element: ViewElement) =
    inherit MapElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Maps.Polygon>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Maps.Polygon' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the FillColor member
    member this.FillColor = element.GetAttributeKeyed(ViewAttributes.FillColorAttribKey)
    /// Get the value of the Geopath member
    member this.Geopath = element.GetAttributeKeyed(ViewAttributes.GeopathAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Polyline
type PolylineViewer(element: ViewElement) =
    inherit MapElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Maps.Polyline>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Maps.Polyline' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Geopath member
    member this.Geopath = element.GetAttributeKeyed(ViewAttributes.GeopathAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Pin
type PinViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Maps.Pin>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Maps.Pin' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Address member
    member this.Address = element.GetAttributeKeyed(ViewAttributes.AddressAttribKey)
    /// Get the value of the Label member
    member this.Label = element.GetAttributeKeyed(ViewAttributes.LabelAttribKey)
    /// Get the value of the Position member
    member this.Position = element.GetAttributeKeyed(ViewAttributes.PinPositionAttribKey)
    /// Get the value of the Type member
    member this.Type = element.GetAttributeKeyed(ViewAttributes.PinTypeAttribKey)
    /// Get the value of the Clicked member
    member this.Clicked = element.GetAttributeKeyed(ViewAttributes.ClickedAttribKey)
    /// Get the value of the MarkerClicked member
    member this.MarkerClicked = element.GetAttributeKeyed(ViewAttributes.MarkerClickedAttribKey)
    /// Get the value of the InfoWindowClicked member
    member this.InfoWindowClicked = element.GetAttributeKeyed(ViewAttributes.InfoWindowClickedAttribKey)

[<AbstractClass; Sealed>]
type View private () =
    /// Describes a Map in the view
    static member inline Map(?anchorX: float,
                             ?anchorY: float,
                             ?automationId: string,
                             ?backgroundColor: Xamarin.Forms.Color,
                             ?behaviors: ViewElement list,
                             ?classId: string,
                             ?created: (Xamarin.Forms.Maps.Map -> unit),
                             ?effects: ViewElement list,
                             ?flowDirection: Xamarin.Forms.FlowDirection,
                             ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                             ?gestureRecognizers: ViewElement list,
                             ?hasScrollEnabled: bool,
                             ?hasZoomEnabled: bool,
                             ?height: float,
                             ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                             ?inputTransparent: bool,
                             ?isEnabled: bool,
                             ?isShowingUser: bool,
                             ?isTabStop: bool,
                             ?isVisible: bool,
                             ?mapClicked: Xamarin.Forms.Maps.MapClickedEventArgs -> unit,
                             ?mapElements: ViewElement list,
                             ?mapType: Xamarin.Forms.Maps.MapType,
                             ?margin: Xamarin.Forms.Thickness,
                             ?menu: ViewElement,
                             ?minimumHeight: float,
                             ?minimumWidth: float,
                             ?moveToLastRegionOnLayoutChange: bool,
                             ?opacity: float,
                             ?pins: ViewElement list,
                             ?ref: ViewRef<Xamarin.Forms.Maps.Map>,
                             ?requestedRegion: Xamarin.Forms.Maps.MapSpan,
                             ?resources: (string * obj) list,
                             ?rotation: float,
                             ?rotationX: float,
                             ?rotationY: float,
                             ?scale: float,
                             ?scaleX: float,
                             ?scaleY: float,
                             ?shellBackButtonBehavior: ViewElement,
                             ?shellBackgroundColor: Xamarin.Forms.Color,
                             ?shellDisabledColor: Xamarin.Forms.Color,
                             ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                             ?shellForegroundColor: Xamarin.Forms.Color,
                             ?shellNavBarHasShadow: bool,
                             ?shellNavBarIsVisible: bool,
                             ?shellSearchHandler: ViewElement,
                             ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                             ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                             ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                             ?shellTabBarIsVisible: bool,
                             ?shellTabBarTitleColor: Xamarin.Forms.Color,
                             ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                             ?shellTitleColor: Xamarin.Forms.Color,
                             ?shellTitleView: ViewElement,
                             ?shellUnselectedColor: Xamarin.Forms.Color,
                             ?style: Xamarin.Forms.Style,
                             ?styleClasses: string list,
                             ?styleId: string,
                             ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                             ?styles: Xamarin.Forms.Style list,
                             ?tabIndex: int,
                             ?tag: obj,
                             ?translationX: float,
                             ?translationY: float,
                             ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                             ?verticalOptions: Xamarin.Forms.LayoutOptions,
                             ?visual: Xamarin.Forms.IVisual,
                             ?width: float) =

        ViewBuilders.ConstructMap(?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?automationId=automationId,
                               ?backgroundColor=backgroundColor,
                               ?behaviors=behaviors,
                               ?classId=classId,
                               ?created=created,
                               ?effects=effects,
                               ?flowDirection=flowDirection,
                               ?focused=focused,
                               ?gestureRecognizers=gestureRecognizers,
                               ?hasScrollEnabled=hasScrollEnabled,
                               ?hasZoomEnabled=hasZoomEnabled,
                               ?height=height,
                               ?horizontalOptions=horizontalOptions,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isShowingUser=isShowingUser,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?mapClicked=mapClicked,
                               ?mapElements=mapElements,
                               ?mapType=mapType,
                               ?margin=margin,
                               ?menu=menu,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?moveToLastRegionOnLayoutChange=moveToLastRegionOnLayoutChange,
                               ?opacity=opacity,
                               ?pins=pins,
                               ?ref=ref,
                               ?requestedRegion=requestedRegion,
                               ?resources=resources,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?shellBackButtonBehavior=shellBackButtonBehavior,
                               ?shellBackgroundColor=shellBackgroundColor,
                               ?shellDisabledColor=shellDisabledColor,
                               ?shellFlyoutBehavior=shellFlyoutBehavior,
                               ?shellForegroundColor=shellForegroundColor,
                               ?shellNavBarHasShadow=shellNavBarHasShadow,
                               ?shellNavBarIsVisible=shellNavBarIsVisible,
                               ?shellSearchHandler=shellSearchHandler,
                               ?shellTabBarBackgroundColor=shellTabBarBackgroundColor,
                               ?shellTabBarDisabledColor=shellTabBarDisabledColor,
                               ?shellTabBarForegroundColor=shellTabBarForegroundColor,
                               ?shellTabBarIsVisible=shellTabBarIsVisible,
                               ?shellTabBarTitleColor=shellTabBarTitleColor,
                               ?shellTabBarUnselectedColor=shellTabBarUnselectedColor,
                               ?shellTitleColor=shellTitleColor,
                               ?shellTitleView=shellTitleView,
                               ?shellUnselectedColor=shellUnselectedColor,
                               ?style=style,
                               ?styleClasses=styleClasses,
                               ?styleId=styleId,
                               ?styleSheets=styleSheets,
                               ?styles=styles,
                               ?tabIndex=tabIndex,
                               ?tag=tag,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?unfocused=unfocused,
                               ?verticalOptions=verticalOptions,
                               ?visual=visual,
                               ?width=width)

    /// Describes a Polygon in the view
    static member inline Polygon(?automationId: string,
                                 ?classId: string,
                                 ?created: (Xamarin.Forms.Maps.Polygon -> unit),
                                 ?effects: ViewElement list,
                                 ?fillColor: Xamarin.Forms.Color,
                                 ?geopath: Xamarin.Forms.Maps.Position list,
                                 ?menu: ViewElement,
                                 ?ref: ViewRef<Xamarin.Forms.Maps.Polygon>,
                                 ?strokeColor: Xamarin.Forms.Color,
                                 ?strokeWidth: single,
                                 ?styleId: string,
                                 ?tag: obj) =

        ViewBuilders.ConstructPolygon(?automationId=automationId,
                               ?classId=classId,
                               ?created=created,
                               ?effects=effects,
                               ?fillColor=fillColor,
                               ?geopath=geopath,
                               ?menu=menu,
                               ?ref=ref,
                               ?strokeColor=strokeColor,
                               ?strokeWidth=strokeWidth,
                               ?styleId=styleId,
                               ?tag=tag)

    /// Describes a Polyline in the view
    static member inline Polyline(?automationId: string,
                                  ?classId: string,
                                  ?created: (Xamarin.Forms.Maps.Polyline -> unit),
                                  ?effects: ViewElement list,
                                  ?geopath: Xamarin.Forms.Maps.Position list,
                                  ?menu: ViewElement,
                                  ?ref: ViewRef<Xamarin.Forms.Maps.Polyline>,
                                  ?strokeColor: Xamarin.Forms.Color,
                                  ?strokeWidth: single,
                                  ?styleId: string,
                                  ?tag: obj) =

        ViewBuilders.ConstructPolyline(?automationId=automationId,
                               ?classId=classId,
                               ?created=created,
                               ?effects=effects,
                               ?geopath=geopath,
                               ?menu=menu,
                               ?ref=ref,
                               ?strokeColor=strokeColor,
                               ?strokeWidth=strokeWidth,
                               ?styleId=styleId,
                               ?tag=tag)

    /// Describes a Pin in the view
    static member inline Pin(?address: string,
                             ?automationId: string,
                             ?classId: string,
                             ?clicked: unit -> unit,
                             ?created: (Xamarin.Forms.Maps.Pin -> unit),
                             ?effects: ViewElement list,
                             ?infoWindowClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                             ?label: string,
                             ?markerClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit,
                             ?menu: ViewElement,
                             ?pinType: Xamarin.Forms.Maps.PinType,
                             ?position: Xamarin.Forms.Maps.Position,
                             ?ref: ViewRef<Xamarin.Forms.Maps.Pin>,
                             ?styleId: string,
                             ?tag: obj) =

        ViewBuilders.ConstructPin(?address=address,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?clicked=clicked,
                               ?created=created,
                               ?effects=effects,
                               ?infoWindowClicked=infoWindowClicked,
                               ?label=label,
                               ?markerClicked=markerClicked,
                               ?menu=menu,
                               ?pinType=pinType,
                               ?position=position,
                               ?ref=ref,
                               ?styleId=styleId,
                               ?tag=tag)


[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the MapClicked property in the visual element
        member x.MapClicked(value: Xamarin.Forms.Maps.MapClickedEventArgs -> unit) = x.WithAttribute(ViewAttributes.MapClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the HasScrollEnabled property in the visual element
        member x.HasScrollEnabled(value: bool) = x.WithAttribute(ViewAttributes.HasScrollEnabledAttribKey, (value))

        /// Adjusts the HasZoomEnabled property in the visual element
        member x.HasZoomEnabled(value: bool) = x.WithAttribute(ViewAttributes.HasZoomEnabledAttribKey, (value))

        /// Adjusts the IsShowingUser property in the visual element
        member x.IsShowingUser(value: bool) = x.WithAttribute(ViewAttributes.IsShowingUserAttribKey, (value))

        /// Adjusts the MapType property in the visual element
        member x.MapType(value: Xamarin.Forms.Maps.MapType) = x.WithAttribute(ViewAttributes.MapTypeAttribKey, (value))

        /// Adjusts the MoveToLastRegionOnLayoutChange property in the visual element
        member x.MoveToLastRegionOnLayoutChange(value: bool) = x.WithAttribute(ViewAttributes.MoveToLastRegionOnLayoutChangeAttribKey, (value))

        /// Adjusts the Pins property in the visual element
        member x.Pins(value: ViewElement list) = x.WithAttribute(ViewAttributes.PinsAttribKey, Array.ofList(value))

        /// Adjusts the MapElements property in the visual element
        member x.MapElements(value: ViewElement list) = x.WithAttribute(ViewAttributes.MapElementsAttribKey, Array.ofList(value))

        /// Adjusts the RequestedRegion property in the visual element
        member x.RequestedRegion(value: Xamarin.Forms.Maps.MapSpan) = x.WithAttribute(ViewAttributes.RequestedRegionAttribKey, (value))

        /// Adjusts the StrokeColor property in the visual element
        member x.StrokeColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.StrokeColorAttribKey, (value))

        /// Adjusts the StrokeWidth property in the visual element
        member x.StrokeWidth(value: single) = x.WithAttribute(ViewAttributes.StrokeWidthAttribKey, (value))

        /// Adjusts the FillColor property in the visual element
        member x.FillColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.FillColorAttribKey, (value))

        /// Adjusts the Geopath property in the visual element
        member x.Geopath(value: Xamarin.Forms.Maps.Position list) = x.WithAttribute(ViewAttributes.GeopathAttribKey, Array.ofList(value))

        /// Adjusts the Clicked property in the visual element
        member x.Clicked(value: unit -> unit) = x.WithAttribute(ViewAttributes.ClickedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f()))(value))

        /// Adjusts the MarkerClicked property in the visual element
        member x.MarkerClicked(value: Xamarin.Forms.Maps.PinClickedEventArgs -> unit) = x.WithAttribute(ViewAttributes.MarkerClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the InfoWindowClicked property in the visual element
        member x.InfoWindowClicked(value: Xamarin.Forms.Maps.PinClickedEventArgs -> unit) = x.WithAttribute(ViewAttributes.InfoWindowClickedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the Address property in the visual element
        member x.Address(value: string) = x.WithAttribute(ViewAttributes.AddressAttribKey, (value))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttribute(ViewAttributes.LabelAttribKey, (value))

        /// Adjusts the PinPosition property in the visual element
        member x.PinPosition(value: Xamarin.Forms.Maps.Position) = x.WithAttribute(ViewAttributes.PinPositionAttribKey, (value))

        /// Adjusts the PinType property in the visual element
        member x.PinType(value: Xamarin.Forms.Maps.PinType) = x.WithAttribute(ViewAttributes.PinTypeAttribKey, (value))

        member inline x.With(?mapClicked: Xamarin.Forms.Maps.MapClickedEventArgs -> unit, ?hasScrollEnabled: bool, ?hasZoomEnabled: bool, ?isShowingUser: bool, ?mapType: Xamarin.Forms.Maps.MapType, 
                             ?moveToLastRegionOnLayoutChange: bool, ?pins: ViewElement list, ?mapElements: ViewElement list, ?requestedRegion: Xamarin.Forms.Maps.MapSpan, ?strokeColor: Xamarin.Forms.Color, 
                             ?strokeWidth: single, ?fillColor: Xamarin.Forms.Color, ?geopath: Xamarin.Forms.Maps.Position list, ?clicked: unit -> unit, ?markerClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit, 
                             ?infoWindowClicked: Xamarin.Forms.Maps.PinClickedEventArgs -> unit, ?address: string, ?label: string, ?pinPosition: Xamarin.Forms.Maps.Position, ?pinType: Xamarin.Forms.Maps.PinType) =
            let x = match mapClicked with None -> x | Some opt -> x.MapClicked(opt)
            let x = match hasScrollEnabled with None -> x | Some opt -> x.HasScrollEnabled(opt)
            let x = match hasZoomEnabled with None -> x | Some opt -> x.HasZoomEnabled(opt)
            let x = match isShowingUser with None -> x | Some opt -> x.IsShowingUser(opt)
            let x = match mapType with None -> x | Some opt -> x.MapType(opt)
            let x = match moveToLastRegionOnLayoutChange with None -> x | Some opt -> x.MoveToLastRegionOnLayoutChange(opt)
            let x = match pins with None -> x | Some opt -> x.Pins(opt)
            let x = match mapElements with None -> x | Some opt -> x.MapElements(opt)
            let x = match requestedRegion with None -> x | Some opt -> x.RequestedRegion(opt)
            let x = match strokeColor with None -> x | Some opt -> x.StrokeColor(opt)
            let x = match strokeWidth with None -> x | Some opt -> x.StrokeWidth(opt)
            let x = match fillColor with None -> x | Some opt -> x.FillColor(opt)
            let x = match geopath with None -> x | Some opt -> x.Geopath(opt)
            let x = match clicked with None -> x | Some opt -> x.Clicked(opt)
            let x = match markerClicked with None -> x | Some opt -> x.MarkerClicked(opt)
            let x = match infoWindowClicked with None -> x | Some opt -> x.InfoWindowClicked(opt)
            let x = match address with None -> x | Some opt -> x.Address(opt)
            let x = match label with None -> x | Some opt -> x.Label(opt)
            let x = match pinPosition with None -> x | Some opt -> x.PinPosition(opt)
            let x = match pinType with None -> x | Some opt -> x.PinType(opt)
            x

    /// Adjusts the MapClicked property in the visual element
    let mapClicked (value: Xamarin.Forms.Maps.MapClickedEventArgs -> unit) (x: ViewElement) = x.MapClicked(value)
    /// Adjusts the HasScrollEnabled property in the visual element
    let hasScrollEnabled (value: bool) (x: ViewElement) = x.HasScrollEnabled(value)
    /// Adjusts the HasZoomEnabled property in the visual element
    let hasZoomEnabled (value: bool) (x: ViewElement) = x.HasZoomEnabled(value)
    /// Adjusts the IsShowingUser property in the visual element
    let isShowingUser (value: bool) (x: ViewElement) = x.IsShowingUser(value)
    /// Adjusts the MapType property in the visual element
    let mapType (value: Xamarin.Forms.Maps.MapType) (x: ViewElement) = x.MapType(value)
    /// Adjusts the MoveToLastRegionOnLayoutChange property in the visual element
    let moveToLastRegionOnLayoutChange (value: bool) (x: ViewElement) = x.MoveToLastRegionOnLayoutChange(value)
    /// Adjusts the Pins property in the visual element
    let pins (value: ViewElement list) (x: ViewElement) = x.Pins(value)
    /// Adjusts the MapElements property in the visual element
    let mapElements (value: ViewElement list) (x: ViewElement) = x.MapElements(value)
    /// Adjusts the RequestedRegion property in the visual element
    let requestedRegion (value: Xamarin.Forms.Maps.MapSpan) (x: ViewElement) = x.RequestedRegion(value)
    /// Adjusts the StrokeColor property in the visual element
    let strokeColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.StrokeColor(value)
    /// Adjusts the StrokeWidth property in the visual element
    let strokeWidth (value: single) (x: ViewElement) = x.StrokeWidth(value)
    /// Adjusts the FillColor property in the visual element
    let fillColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.FillColor(value)
    /// Adjusts the Geopath property in the visual element
    let geopath (value: Xamarin.Forms.Maps.Position list) (x: ViewElement) = x.Geopath(value)
    /// Adjusts the Clicked property in the visual element
    let clicked (value: unit -> unit) (x: ViewElement) = x.Clicked(value)
    /// Adjusts the MarkerClicked property in the visual element
    let markerClicked (value: Xamarin.Forms.Maps.PinClickedEventArgs -> unit) (x: ViewElement) = x.MarkerClicked(value)
    /// Adjusts the InfoWindowClicked property in the visual element
    let infoWindowClicked (value: Xamarin.Forms.Maps.PinClickedEventArgs -> unit) (x: ViewElement) = x.InfoWindowClicked(value)
    /// Adjusts the Address property in the visual element
    let address (value: string) (x: ViewElement) = x.Address(value)
    /// Adjusts the Label property in the visual element
    let label (value: string) (x: ViewElement) = x.Label(value)
    /// Adjusts the PinPosition property in the visual element
    let pinPosition (value: Xamarin.Forms.Maps.Position) (x: ViewElement) = x.PinPosition(value)
    /// Adjusts the PinType property in the visual element
    let pinType (value: Xamarin.Forms.Maps.PinType) (x: ViewElement) = x.PinType(value)
