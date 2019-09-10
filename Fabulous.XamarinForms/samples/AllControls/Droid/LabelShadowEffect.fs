namespace AllControls.Droid

open System
open System.Linq
open AllControls.Effects
open Xamarin.Forms
open Xamarin.Forms.Platform.Android

type LabelShadowEffect() =
    inherit PlatformEffect()
    
    override this.OnAttached() =
        try
            let control = this.Control :?> Android.Widget.TextView
            let effect = this.Element.Effects.FirstOrDefault(fun e -> e :? ShadowEffect) :?> ShadowEffect
            control.SetShadowLayer(float32 effect.Radius, float32 effect.DistanceX, float32 effect.DistanceY, effect.Color.ToAndroid())
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)

    override this.OnDetached() = ()