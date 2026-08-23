namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabPen =
    inherit IFabElement

module Pen =
    let WidgetKey = Widgets.register<Pen>()

    let BrushWidget = Attributes.defineAvaloniaPropertyWidget Pen.BrushProperty

    let Brush = Attributes.defineAvaloniaPropertyWithEquality Pen.BrushProperty

    let Thickness = Attributes.defineAvaloniaPropertyWithEquality Pen.ThicknessProperty

    let DashStyle = Attributes.defineAvaloniaPropertyWidget Pen.DashStyleProperty

    let LineCap = Attributes.defineAvaloniaPropertyWithEquality Pen.LineCapProperty

    let LineJoin = Attributes.defineAvaloniaPropertyWithEquality Pen.LineJoinProperty

    let MiterLimit =
        Attributes.defineAvaloniaPropertyWithEquality Pen.MiterLimitProperty

[<AutoOpen>]
module PenBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: WidgetBuilder<'msg, #IFabBrush>, thickness: float) =
            WidgetBuilder<'msg, IFabPen>(
                Pen.WidgetKey,
                AttributesBundle(StackList.one(Pen.Thickness.WithValue(thickness)), [| Pen.BrushWidget.WithValue(brush.Compile()) |], [||], [||])
            )

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: IBrush, thickness: float) =
            WidgetBuilder<'msg, IFabPen>(Pen.WidgetKey, Pen.Thickness.WithValue(thickness), Pen.Brush.WithValue(brush))

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: Color, thickness: float) =
            View.Pen(View.SolidColorBrush(brush), thickness)

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: string, thickness: float) =
            View.Pen(View.SolidColorBrush(brush), thickness)

type PenModifiers =
    /// <summary>Sets the DashStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DashStyle value.</param>
    [<Extension>]
    static member inline dashStyle(this: WidgetBuilder<'msg, #IFabPen>, value: WidgetBuilder<'msg, IFaDashStyle>) =
        this.AddWidget(Pen.DashStyle.WithValue(value.Compile()))

    /// <summary>Sets the LineCap property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineCap value.</param>
    [<Extension>]
    static member inline lineCap(this: WidgetBuilder<'msg, #IFabPen>, value: PenLineCap) =
        this.AddScalar(Pen.LineCap.WithValue(value))

    /// <summary>Sets the LineJoin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineJoin value.</param>
    [<Extension>]
    static member inline lineJoin(this: WidgetBuilder<'msg, #IFabPen>, value: PenLineJoin) =
        this.AddScalar(Pen.LineJoin.WithValue(value))

    /// <summary>Sets the MiterLimit property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MiterLimit value.</param>
    [<Extension>]
    static member inline miterLimit(this: WidgetBuilder<'msg, #IFabPen>, value: float) =
        this.AddScalar(Pen.MiterLimit.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Pen control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPen>, value: ViewRef<Pen>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
