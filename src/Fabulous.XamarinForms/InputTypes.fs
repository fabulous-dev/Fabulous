namespace Fabulous.XamarinForms

[<AutoOpen>]
module InputTypes =

    module Points =
        type Value =
            | String of string
            | PointsList of Xamarin.Forms.Point list

        let fromString str = String str
        let fromList points = PointsList points
