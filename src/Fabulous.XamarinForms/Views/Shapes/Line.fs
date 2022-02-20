namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type ILine =
    inherit IShape

module Line =

    let WidgetKey = Widgets.register<Line> ()

    let Point1 =
        Attributes.define<struct (float * float)>
            "Line_Point1"
            (fun newValueOpt node ->
                let line = node.Target :?> Line
                match newValueOpt with
                | ValueNone ->
                    line.X1 <- 0
                    line.Y1 <- 0
                | ValueSome (x1, y1) ->
                    line.X1 <- x1
                    line.Y1 <- y1)

    let Point2 =
        Attributes.define<struct (float * float)>
            "Line_Point2"
            (fun newValueOpt node ->
                let line = node.Target :?> Line

                match newValueOpt with
                | ValueNone ->
                    line.X2 <- 0
                    line.Y2 <- 0
                | ValueSome (x2, y2) ->
                    line.X2 <- x2
                    line.Y2 <- y2)

[<AutoOpen>]
module LineBuilders =

    type Fabulous.XamarinForms.View with
        static member inline Line<'msg>(point1: struct (float * float), point2: struct (float * float)) =
            WidgetBuilder<'msg, ILine>(Line.WidgetKey, Line.Point1.WithValue(point1), Line.Point2.WithValue(point2))
