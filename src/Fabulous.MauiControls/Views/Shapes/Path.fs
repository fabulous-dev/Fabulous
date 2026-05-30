namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

open Fabulous.Maui

type IFabPath =
    inherit IFabShape

module Path =
    let WidgetKey = Widgets.register<Path>()

    let DataString =
        Attributes.defineSimpleScalarWithEquality<string> "Path_DataString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Path.DataProperty)
            | ValueSome value -> target.SetValue(Path.DataProperty, PathGeometryConverter().ConvertFromInvariantString(value)))

    let DataWidget = Attributes.defineBindableWidget Path.DataProperty

    let RenderTransformString =
        Attributes.defineSimpleScalarWithEquality<string> "Path_RenderTransformString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Path.RenderTransformProperty)
            | ValueSome value -> target.SetValue(Path.RenderTransformProperty, TransformTypeConverter().ConvertFromInvariantString(value)))

    let RenderTransformWidget =
        Attributes.defineBindableWidget Path.RenderTransformProperty

[<AutoOpen>]
module PathBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Path widget with a data path string</summary>
        /// <param name="data">The data path</param>
        static member inline Path<'msg when 'msg: equality>(data: string) =
            WidgetBuilder<'msg, IFabPath>(Path.WidgetKey, Path.DataString.WithValue(data))

        /// <summary>Create a Path widget with a Geometry widget</summary>
        /// <param name="content">The Geometry widget</param>
        static member inline Path(content: WidgetBuilder<'msg, #IFabGeometry>) =
            WidgetHelpers.buildWidgets<'msg, IFabPath> Path.WidgetKey [| Path.DataWidget.WithValue(content.Compile()) |]

[<Extension>]
type PathModifiers =
    /// <summary>Set the render transform</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The render transform path</param>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabPath>, value: string) =
        this.AddScalar(Path.RenderTransformString.WithValue(value))

    /// <summary>Set the render transform</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The render transform widget</param>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabPath>, content: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Path.RenderTransformWidget.WithValue(content.Compile()))

    /// <summary>Link a ViewRef to access the direct Path control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
