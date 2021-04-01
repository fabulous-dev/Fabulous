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

            let attribs = AttributesBuilder()
            match radius with None -> () | Some v -> attribs.Add(RadiusAttribKey, v)
            match color with None -> () | Some v -> attribs.Add(ColorAttribKey, v)
            match distanceX with None -> () | Some v -> attribs.Add(DistanceXAttribKey, v)
            match distanceY with None -> () | Some v -> attribs.Add(DistanceYAttribKey, v)

            let create _ _ = ShadowEffect()

            let update (definition: ProgramDefinition) (prevOpt: DynamicViewElement voption) (source: DynamicViewElement) (target: ShadowEffect) =
                source.UpdatePrimitive(definition, prevOpt, target, RadiusAttribKey, (fun target v -> target.Radius <- v))
                source.UpdatePrimitive(definition, prevOpt, target, ColorAttribKey, (fun target v -> target.Color <- v))
                source.UpdatePrimitive(definition, prevOpt, target, DistanceXAttribKey, (fun target v -> target.DistanceX <- v))
                source.UpdatePrimitive(definition, prevOpt, target, DistanceYAttribKey, (fun target v -> target.DistanceY <- v))

            let updateAttachedProperties _ _ _ _ _ = ()
            
            let unmount _ _ = ()

            let handler =
                Registrar.Register(typeof<ShadowEffect>.FullName, create, update, updateAttachedProperties, unmount)

            DynamicViewElement.Create(handler, attribs)
