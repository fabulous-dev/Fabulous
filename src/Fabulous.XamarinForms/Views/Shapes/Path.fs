namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

open Fabulous.XamarinForms

type IPath =
    inherit IShape

module Path =
    let WidgetKey = Widgets.register<Path>()

    let DataWidget =
        Attributes.defineBindableWidget Path.DataProperty

    let DataString =
        Attributes.define<string>
            "Path_DataString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Path.DataProperty)
                | ValueSome value ->
                    target.SetValue(
                        Path.DataProperty,
                        PathGeometryConverter()
                            .ConvertFromInvariantString(value)
                    ))

    let RenderTransformWidget =
        Attributes.defineBindableWidget Path.RenderTransformProperty

    let RenderTransformString =
        Attributes.define<string>
            "Path_RenderTransformString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Path.RenderTransformProperty)
                | ValueSome value ->
                    target.SetValue(
                        Path.RenderTransformProperty,
                        TransformTypeConverter()
                            .ConvertFromInvariantString(value)
                    ))

[<AutoOpen>]
module PathBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Path<'msg, 'marker when 'marker :> IGeometry>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IPath> Path.WidgetKey [| Path.DataWidget.WithValue(content.Compile()) |]

        static member inline Path<'msg>(content: string) =
            WidgetBuilder<'msg, IPath>(Path.WidgetKey, Path.DataString.WithValue(content))

[<Extension>]
type PathModifiers =
    [<Extension>]
    static member inline renderTransform<'msg, 'marker, 'contentMarker when 'marker :> IPath and 'contentMarker :> ITransform>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(Path.RenderTransformWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IPath>, value: string) =
        this.AddScalar(Path.RenderTransformString.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Path control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
