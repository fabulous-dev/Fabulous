namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms.Shapes

type IRectangle =
    inherit IShape

module Rectangle =

    let WidgetKey = Widgets.register<Rectangle> ()

    let RadiusX =
        Attributes.defineBindable<float> Rectangle.RadiusXProperty

    let RadiusY =
        Attributes.defineBindable<float> Rectangle.RadiusYProperty

[<AutoOpen>]
module RectangleBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Rectangle<'msg>(?radiusX: float, ?radiusY: float) =
            match radiusX, radiusY with
            | Some x, Some y ->
                WidgetBuilder<'msg, IRectangle>(
                    Rectangle.WidgetKey,
                    Rectangle.RadiusX.WithValue(x),
                    Rectangle.RadiusY.WithValue(y)
                )
            | _ ->
                WidgetBuilder<'msg, IRectangle>(
                    Rectangle.WidgetKey,
                    AttributesBundle(StackList.empty (), ValueSome [||], ValueNone)
                )
