namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabGeometry =
    inherit IFabElement

module Geometry =

    let Transform = Attributes.defineAvaloniaPropertyWidget Geometry.TransformProperty


type GeometryModifiers =
    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TileMode value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabGeometry>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Geometry.Transform.WithValue(value.Compile()))

type GeometryAttachedModifiers =
    /// <summary>Sets the Clip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Clip value.</param>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(Visual.ClipWidget.WithValue(value.Compile()))
