namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTranslateTransform =
    inherit IFabTransform

module TranslateTransform =

    let WidgetKey = Widgets.register<TranslateTransform>()

    let X = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.XProperty

    let Y = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        /// <param name="y">The Y offset.</param>
        static member TranslateTransform(x: float, y: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x), TranslateTransform.Y.WithValue(y))

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        static member TranslateTransform(x: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x))

        /// <summary>Creates a TranslateTransform widget.</summary>
        static member TranslateTransform() =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey)

type TranslateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct TranslateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTranslateTransform>, value: ViewRef<TranslateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
