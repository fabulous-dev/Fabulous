namespace Fabulous.XamarinForms.Core

module InputTypes =
    type StyleClass =
        | ClassName of string
        | Classes of string list

    type Thickness =
        | Uniform of double
        | Mirror of leftRight: double * upDown: double
        | AllSides of left: double * up: double * right: double * bottom: double
        | Value of Xamarin.Forms.Thickness