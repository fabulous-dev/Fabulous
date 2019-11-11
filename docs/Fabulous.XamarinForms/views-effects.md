
Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Views: Effects
-------
Xamarin.Forms user interfaces are rendered using the native controls of the target platform, allowing Xamarin.Forms applications to retain the appropriate look and feel for each platform. Effects allow the native controls on each platform to be customized without having to resort to a custom renderer implementation.

### Using Effects in Fabulous.XamarinForms

The recommended way to use an effect in Fabulous is by using the dedicated `View.Effect`.  
This control accepts the effect's exported full name (`"SomeResolutionGroup.SomeEffectName"`) and it can be attached to any control with the `effects` properties.

```fsharp
View.Button(effects = [
    View.Effect(name = "SomeResolutionGroup.SomeEffectName")
])
```

This way is only suitable if your effect doesn't need any external values.

### Create wrapper for custom effects with properties

If you want to use your own effects with properties in Fabulous.XamarinForms, you will need to write an extension.  
For more information, please read about [View Extensions](views-extending.md)

Let's take this ShadowEffect for example:

```fsharp
open Xamarin.Forms

type ShadowEffect() =
    inherit RoutingEffect("FabulousXamarinForms.ShadowEffect")

    member val Radius = 0. with get, set
    member val Color = Color.Default with get, set
    member val DistanceX = 0. with get, set
    member val DistanceY = 0. with get, set
```

If we want to use it in our views, we will need to write the following extension:

```fsharp
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
```

This then enables us to use it like this:

```fsharp
View.Label(effects = [
    View.ShadowEffect(color = Color.Black, radius = 5.)
])
```

Alternatively you can do it without an extension, and use both the `created` event and the `Effects` collection of the Xamarin.Forms control.
```fsharp
View.Label(created = fun e ->
    let effect = new ShadowEffect()
    effect.Color <- Color.Black
    effect.Radius <- 5.
    e.Effects.Add effect
)
```

This way is not recommended because it can't make use of the incremental update mecanism.


See also:
* [Xamarin.Forms - Effects](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/)
* [Xamarin.Forms - Creating an Effect](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/creating)
* [Xamarin.Forms - Introduction to Effects](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/introduction)

