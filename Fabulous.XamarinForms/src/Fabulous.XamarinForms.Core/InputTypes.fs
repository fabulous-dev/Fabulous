namespace Fabulous.XamarinForms

[<AutoOpen>]
module InputTypes =
    type StyleClass =
        | ClassName of string
        | Classes of string list

    type Thickness =
        | Uniform of double
        | Mirror of leftRight: double * upDown: double
        | AllSides of left: double * up: double * right: double * bottom: double
        | Value of Xamarin.Forms.Thickness
        
    type Image =
        | Path of string
        | Bytes of byte[]
        | Value of Xamarin.Forms.ImageSource
        
    type RowOrColumn =
        | Auto
        | Star
        | Stars of float
        | Absolute of float
        
    type FontSize =
        | Named of Xamarin.Forms.NamedSize
        | Value of float
        
    type Accelerator =
        | String of string
        | Value of Xamarin.Forms.Accelerator