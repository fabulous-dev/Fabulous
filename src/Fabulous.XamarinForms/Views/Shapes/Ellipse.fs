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
        static member inline Ellipse<'msg>(strokeThickness: float, strokeLight: Brush, ?strokeDark: Brush) =
            WidgetBuilder<'msg, IEllipse>(
                Ellipse.WidgetKey,
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )
