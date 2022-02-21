namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

open Fabulous.XamarinForms

type IPath =
    inherit IShape

module Path =
    let WidgetKey = Widgets.register<Path> ()

    // FIXME Data can be also used as a string using PathGeometryConverter.
    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/path-markup-syntax
    // Should be just use Geometry Widgets ?
    let Data =
        Attributes.defineBindableWidget Path.DataProperty

    let RenderTransform =
        Attributes.defineBindableWidget Path.RenderTransformProperty

[<AutoOpen>]
module PathBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Path<'msg, 'marker when 'marker :> IGeometry>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IPath> Path.WidgetKey [| Path.Data.WithValue(content.Compile()) |]

[<Extension>]
type PathModifiers =
    // FIXME RenderTransform can be also used as a string using TransformTypeConverter.
    // Should be just use Transform Widgets ?
    [<Extension>]
    static member inline renderTransform<'msg, 'marker, 'contentMarker when 'marker :> IPath and 'contentMarker :> ITransform>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(Path.RenderTransform.WithValue(content.Compile()))
