namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabCombinedGeometry =
    inherit IFabGeometry

module CombinedGeometry =

    let WidgetKey = Widgets.register<CombinedGeometry>()

    let Geometry1 =
        Attributes.defineAvaloniaPropertyWidget CombinedGeometry.Geometry1Property

    let Geometry2 =
        Attributes.defineAvaloniaPropertyWidget CombinedGeometry.Geometry2Property

    let GeometryCombineMode =
        Attributes.defineAvaloniaPropertyWithEquality CombinedGeometry.GeometryCombineModeProperty

[<AutoOpen>]
module CombinedGeometryBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CombinedGeometry widget.</summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        static member CombinedGeometry(geometry1: WidgetBuilder<'msg, #IFabGeometry>, geometry2: WidgetBuilder<'msg, #IFabGeometry>) =
            WidgetBuilder<'msg, IFabCombinedGeometry>(
                CombinedGeometry.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    [| CombinedGeometry.Geometry1.WithValue(geometry1.Compile())
                       CombinedGeometry.Geometry2.WithValue(geometry2.Compile()) |],
                    [||],
                    [||]
                )
            )


type CombinedGeometryModifiers =
    /// <summary>Sets the GeometryCombineMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The GeometryCombineMode value.</param>
    [<Extension>]
    static member inline geometryCombineMode(this: WidgetBuilder<'msg, #IFabCombinedGeometry>, value: GeometryCombineMode) =
        this.AddScalar(CombinedGeometry.GeometryCombineMode.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CombinedGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCombinedGeometry>, value: ViewRef<CombinedGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
