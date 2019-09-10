namespace AllControls.Droid

open System
open Xamarin.Forms
open Xamarin.Forms.Platform.Android

type FocusEffect() =
    inherit PlatformEffect()

    let originalBackgroundColor = Android.Graphics.Color(0, 0, 0, 0)
    let mutable backgroundColor = originalBackgroundColor;
    
    override this.OnAttached() =
        try
            backgroundColor <- Android.Graphics.Color.LightGreen
            this.Control.SetBackgroundColor(backgroundColor)
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)
            
    override this.OnDetached() = ()
            
    override this.OnElementPropertyChanged(args) =
        try
            if args.PropertyName = "IsFocused" then
                let colorDrawable = this.Control.Background :?> Android.Graphics.Drawables.ColorDrawable
                if (colorDrawable.Color = backgroundColor) then
                    this.Control.SetBackgroundColor(originalBackgroundColor)
                else
                    this.Control.SetBackgroundColor(backgroundColor)
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)