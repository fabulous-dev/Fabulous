namespace Fabulous.XamarinForms

[<AutoOpen>]
module InputTypes =
    type Image =
        | Path of string
        | Bytes of byte[]
        | Source of Xamarin.Forms.ImageSource
        
    type Dimension =
        | Auto
        | Star
        | Stars of float
        | Absolute of float
        
    type FontSize =
        | Named of Xamarin.Forms.NamedSize
        | FontSize of float