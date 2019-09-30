namespace AllControls.iOS

open System
open UIKit
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

type FocusEffect() =
    inherit PlatformEffect()

    let originalBackgroundColor = UIColor.White
    let mutable backgroundColor = originalBackgroundColor;
    
    override this.OnAttached() =
        try
            backgroundColor <- UIColor.FromRGB(204, 153, 255)
            this.Control.BackgroundColor <- backgroundColor
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)
            
    override this.OnDetached() = ()
            
    override this.OnElementPropertyChanged(args) =
        try
            if args.PropertyName = "IsFocused" then
                if (this.Control.BackgroundColor = backgroundColor) then
                    this.Control.BackgroundColor <- originalBackgroundColor
                else
                    this.Control.BackgroundColor <- backgroundColor
        with
        | ex ->
            Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message)
            
