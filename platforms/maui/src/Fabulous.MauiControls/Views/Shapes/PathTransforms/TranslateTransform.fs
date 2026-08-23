namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabTranslateTransform =
    inherit IFabTransform

module TranslateTransform =
    let WidgetKey = Widgets.register<TranslateTransform>()

    let X = Attributes.defineBindableFloat TranslateTransform.XProperty

    let Y = Attributes.defineBindableFloat TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a TranslateTransform widget with translation value</summary>
        /// <param name="x">The X component of the translation</param>
        /// <param name="y">The Y component of the translation</param>
        static member inline TranslateTransform<'msg when 'msg: equality>(x: float, y: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x), TranslateTransform.Y.WithValue(y))

[<Extension>]
type TranslateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct TranslateTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTranslateTransform>, value: ViewRef<TranslateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
