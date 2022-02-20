namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms.Shapes

open Fabulous.XamarinForms

type IPath =
    inherit IShape

module Path =
    let WidgetKey = Widgets.register<Path> ()

    let Data = Attributes.defineBindableWidget Path.DataProperty

    let RenderTransform = Attributes.defineBindable<Transform> Path.RenderTransformProperty

[<AutoOpen>]
module PathBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Path<'msg, 'marker when 'marker :> IGeometry>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IPath>
                Path.WidgetKey
                [| Path.Data.WithValue(content.Compile()) |]
