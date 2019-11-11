namespace AllControls.iOS

open System
open System.Linq
open AllControls.Effects
open CoreGraphics
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

type LabelShadowEffect() =
    inherit PlatformEffect()
    
    override this.OnAttached() =
        try
            let effect = this.Element.Effects.FirstOrDefault(fun e -> e :? ShadowEffect) :?> ShadowEffect
            this.Control.Layer.CornerRadius <- nfloat effect.Radius
            this.Control.Layer.ShadowColor <- effect.Color.ToCGColor()
            this.Control.Layer.ShadowOffset <- new CGSize(effect.DistanceX, effect.DistanceY)
            this.Control.Layer.ShadowOpacity <- 1.f
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)

    override this.OnDetached() = ()