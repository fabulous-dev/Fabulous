namespace AllControls.Samples.Effects

open Xamarin.Forms

type ShadowEffect() =
    inherit RoutingEffect("FabulousXamarinForms.ShadowEffect")

    member val Radius = 0. with get, set
    member val Color = Color.Default with get, set
    member val DistanceX = 0. with get, set
    member val DistanceY = 0. with get, set
    
[<AutoOpen>]
module ShadowEffectViewExtension =
    open Fabulous
    open Fabulous.XamarinForms
    
    let RadiusAttribKey = AttributeKey "ShadowEffectRadius"
    let ColorAttribKey = AttributeKey "ShadowEffectColor"
    let DistanceXAttribKey = AttributeKey "ShadowEffectDistanceX"
    let DistanceYAttribKey = AttributeKey "ShadowEffectDistanceY"
    
    type Fabulous.XamarinForms.View with
        static member inline ShadowEffect(?radius, ?color, ?distanceX, ?distanceY) =
            let attribCount = 0
            let attribCount = match radius with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match distanceX with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match distanceY with Some _ -> attribCount + 1 | None -> attribCount
            
            let attribs = AttributesBuilder(attribCount)
                
            match radius with None -> () | Some v -> attribs.Add(RadiusAttribKey, v)
            match color with None -> () | Some v -> attribs.Add(ColorAttribKey, v)
            match distanceX with None -> () | Some v -> attribs.Add(DistanceXAttribKey, v)
            match distanceY with None -> () | Some v -> attribs.Add(DistanceYAttribKey, v)
            
            let create () = ShadowEffect()
            
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: ShadowEffect) =
                source.UpdatePrimitive(prevOpt, target, RadiusAttribKey, (fun target v -> target.Radius <- v))
                source.UpdatePrimitive(prevOpt, target, ColorAttribKey, (fun target v -> target.Color <- v))
                source.UpdatePrimitive(prevOpt, target, DistanceXAttribKey, (fun target v -> target.DistanceX <- v))
                source.UpdatePrimitive(prevOpt, target, DistanceYAttribKey, (fun target v -> target.DistanceY <- v))
                
            ViewElement.Create(create, update, attribs)
                