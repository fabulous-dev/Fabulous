namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IEllipse =
    inherit IShape


module Ellipse =

    let WidgetKey = Widgets.register<Ellipse> ()

[<AutoOpen>]
module EllipseBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Ellipse<'msg>() =
            WidgetBuilder<'msg, IEllipse>(
                Ellipse.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| |],
                    ValueNone
                ))
