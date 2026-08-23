namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingImage =
    inherit IFabDrawing

module DrawingImage =
    let WidgetKey = Widgets.register<DrawingImage>()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingImage.DrawingProperty

[<AutoOpen>]
module DrawingImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DrawingImage widget.</summary>
        /// <param name="source">The source of the drawing.</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingImage>(DrawingImage.WidgetKey, DrawingImage.Drawing.WithValue(source.Compile()))

type DrawingImageModifiers =
    /// <summary>Link a ViewRef to access the direct DrawingImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDrawingImage>, value: ViewRef<DrawingImage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
