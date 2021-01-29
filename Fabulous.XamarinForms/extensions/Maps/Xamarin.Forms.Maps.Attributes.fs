// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Maps

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let MapClickedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs>>("MapClicked")
    let HasScrollEnabledAttribKey : AttributeKey<_> = AttributeKey<bool>("HasScrollEnabled")
    let HasZoomEnabledAttribKey : AttributeKey<_> = AttributeKey<bool>("HasZoomEnabled")
    let IsShowingUserAttribKey : AttributeKey<_> = AttributeKey<bool>("IsShowingUser")
    let MapTypeAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Maps.MapType>("MapType")
    let MoveToLastRegionOnLayoutChangeAttribKey : AttributeKey<_> = AttributeKey<bool>("MoveToLastRegionOnLayoutChange")
    let PinsAttribKey : AttributeKey<_> = AttributeKey<ViewElement array>("Pins")
    let MapElementsAttribKey : AttributeKey<_> = AttributeKey<ViewElement array>("MapElements")
    let RequestedRegionAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Maps.MapSpan>("RequestedRegion")
    let StrokeColorAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Color>("StrokeColor")
    let StrokeWidthAttribKey : AttributeKey<_> = AttributeKey<single>("StrokeWidth")
    let FillColorAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Color>("FillColor")
    let GeopathAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Maps.Position array>("Geopath")
    let ClickedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler>("Clicked")
    let MarkerClickedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>>("MarkerClicked")
    let InfoWindowClickedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<Xamarin.Forms.Maps.PinClickedEventArgs>>("InfoWindowClicked")
    let AddressAttribKey : AttributeKey<_> = AttributeKey<string>("Address")
    let LabelAttribKey : AttributeKey<_> = AttributeKey<string>("Label")
    let PinPositionAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Maps.Position>("PinPosition")
    let PinTypeAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Maps.PinType>("PinType")

