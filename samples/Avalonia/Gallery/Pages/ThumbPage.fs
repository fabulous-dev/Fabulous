namespace Gallery

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Shapes
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Input
open Fabulous.Avalonia

open Fabulous

open type Fabulous.Avalonia.View

module ThumbPage =
    type Model = { LeftOffset: float; TopOffset: float }

    type Msg =
        | OnLoaded of RoutedEventArgs
        | OnDragDeltaDrag of VectorEventArgs
        | OnDragDeltaTop of VectorEventArgs
        | OnDragDeltaBottom of VectorEventArgs
        | OnDragDeltaLeft of VectorEventArgs
        | OnDragDeltaRight of VectorEventArgs
        | OnDragDeltaTopLeft of VectorEventArgs
        | OnDragDeltaTopRight of VectorEventArgs
        | OnDragDeltaBottomLeft of VectorEventArgs
        | OnDragDeltaBottomRight of VectorEventArgs

    let init () = { LeftOffset = 0.; TopOffset = 0. }

    let canvas = ViewRef<Canvas>()
    let controlRef = ViewRef<Rectangle>()
    let partDragRef = ViewRef<Thumb>()
    let partTopRef = ViewRef<Thumb>()
    let partBottomRef = ViewRef<Thumb>()
    let partLeftRef = ViewRef<Thumb>()
    let partRightRef = ViewRef<Thumb>()
    let partTopLeftRef = ViewRef<Thumb>()
    let partTopRightRef = ViewRef<Thumb>()
    let partBottomLeftRef = ViewRef<Thumb>()
    let partBottomRightRef = ViewRef<Thumb>()

    let getRect () =
        let topLeft =
            Point(Canvas.GetLeft(partTopLeftRef.Value), Canvas.GetTop(partTopLeftRef.Value))

        let topRight =
            Point(Canvas.GetLeft(partTopRightRef.Value), Canvas.GetTop(partTopRightRef.Value))

        let bottomLeft =
            Point(Canvas.GetLeft(partBottomLeftRef.Value), Canvas.GetTop(partBottomLeftRef.Value))

        let bottomRight =
            Point(Canvas.GetLeft(partBottomRightRef.Value), Canvas.GetTop(partBottomRightRef.Value))

        let left =
            Math.Min(Math.Min(topLeft.X, topRight.X), Math.Min(bottomLeft.X, bottomRight.X))

        let top =
            Math.Min(Math.Min(topLeft.Y, topRight.Y), Math.Min(bottomLeft.Y, bottomRight.Y))

        let right =
            Math.Max(Math.Max(topLeft.X, topRight.X), Math.Max(bottomLeft.X, bottomRight.X))

        let bottom =
            Math.Max(Math.Max(topLeft.Y, topRight.Y), Math.Max(bottomLeft.Y, bottomRight.Y))

        let width = Math.Abs(right - left)
        let height = Math.Abs(bottom - top)
        Rect(left, top, width, height)

    let updateThumbs (rect: Rect) =
        Canvas.SetLeft(partTopRef.Value, rect.Center.X)
        Canvas.SetTop(partTopRef.Value, rect.Top)

        Canvas.SetLeft(partBottomRef.Value, rect.Center.X)
        Canvas.SetTop(partBottomRef.Value, rect.Bottom)

        Canvas.SetLeft(partLeftRef.Value, rect.Left)
        Canvas.SetTop(partLeftRef.Value, rect.Center.Y)

        Canvas.SetLeft(partRightRef.Value, rect.Right)
        Canvas.SetTop(partRightRef.Value, rect.Center.Y)

        Canvas.SetLeft(partTopLeftRef.Value, rect.Left)
        Canvas.SetTop(partTopLeftRef.Value, rect.Top)

        Canvas.SetLeft(partTopRightRef.Value, rect.Right)
        Canvas.SetTop(partTopRightRef.Value, rect.Top)

        Canvas.SetLeft(partBottomLeftRef.Value, rect.Left)
        Canvas.SetTop(partBottomLeftRef.Value, rect.Bottom)

        Canvas.SetLeft(partBottomRightRef.Value, rect.Right)
        Canvas.SetTop(partBottomRightRef.Value, rect.Bottom)

    let updateDrag (rect: Rect) =
        Canvas.SetLeft(partDragRef.Value, rect.Left)
        Canvas.SetTop(partDragRef.Value, rect.Top)
        partDragRef.Value.Width <- rect.Width
        partDragRef.Value.Height <- rect.Height

    let updateControl (control: Control, rect: Rect) =
        Canvas.SetLeft(control, rect.Left)
        Canvas.SetTop(control, rect.Top)
        control.Width <- rect.Width
        control.Height <- rect.Height

    let update msg model =
        match msg with
        | OnLoaded args ->
            let rect = Rect(0, 0, controlRef.Value.Width, controlRef.Value.Height)
            updateThumbs(rect)
            updateDrag(rect)

            Canvas.SetLeft(canvas.Value, rect.Left)
            Canvas.SetTop(canvas.Value, rect.Top)
            canvas.Value.Width <- rect.Width
            canvas.Value.Height <- rect.Height

            { LeftOffset = Canvas.GetLeft(controlRef.Value)
              TopOffset = Canvas.GetTop(controlRef.Value) }

        | OnDragDeltaTop e ->
            Canvas.SetTop(partTopRef.Value, Canvas.GetTop(partTopRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopLeftRef.Value, Canvas.GetTop(partTopLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopRightRef.Value, Canvas.GetTop(partTopRightRef.Value) + e.Vector.Y)

            let rect = getRect()

            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaDrag e ->
            Canvas.SetLeft(partTopRef.Value, Canvas.GetLeft(partTopRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomRef.Value, Canvas.GetLeft(partBottomRef.Value) + e.Vector.X)

            Canvas.SetLeft(partLeftRef.Value, Canvas.GetLeft(partLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partRightRef.Value, Canvas.GetLeft(partRightRef.Value) + e.Vector.X)

            Canvas.SetLeft(partTopLeftRef.Value, Canvas.GetLeft(partTopLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomLeftRef.Value, Canvas.GetLeft(partBottomLeftRef.Value) + e.Vector.X)

            Canvas.SetLeft(partTopRightRef.Value, Canvas.GetLeft(partTopRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomRightRef.Value, Canvas.GetLeft(partBottomRightRef.Value) + e.Vector.X)

            Canvas.SetTop(partTopRef.Value, Canvas.GetTop(partTopRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomRef.Value, Canvas.GetTop(partBottomRef.Value) + e.Vector.Y)

            Canvas.SetTop(partLeftRef.Value, Canvas.GetTop(partLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partRightRef.Value, Canvas.GetTop(partRightRef.Value) + e.Vector.Y)

            Canvas.SetTop(partTopLeftRef.Value, Canvas.GetTop(partTopLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopRightRef.Value, Canvas.GetTop(partTopRightRef.Value) + e.Vector.Y)

            Canvas.SetTop(partBottomLeftRef.Value, Canvas.GetTop(partBottomLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomRightRef.Value, Canvas.GetTop(partBottomRightRef.Value) + e.Vector.Y)

            let rect = getRect()
            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model
        | OnDragDeltaBottom e ->
            Canvas.SetTop(partBottomRef.Value, Canvas.GetTop(partBottomRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomLeftRef.Value, Canvas.GetTop(partBottomLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomRightRef.Value, Canvas.GetTop(partBottomRightRef.Value) + e.Vector.Y)

            let rect = getRect()
            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaLeft e ->
            Canvas.SetLeft(partLeftRef.Value, Canvas.GetLeft(partLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopLeftRef.Value, Canvas.GetLeft(partTopLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomLeftRef.Value, Canvas.GetLeft(partBottomLeftRef.Value) + e.Vector.X)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaRight e ->
            Canvas.SetLeft(partRightRef.Value, Canvas.GetLeft(partRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopRightRef.Value, Canvas.GetLeft(partTopRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomRightRef.Value, Canvas.GetLeft(partBottomRightRef.Value) + e.Vector.X)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaTopLeft e ->
            Canvas.SetLeft(partLeftRef.Value, Canvas.GetLeft(partLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopLeftRef.Value, Canvas.GetLeft(partTopLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomLeftRef.Value, Canvas.GetLeft(partBottomLeftRef.Value) + e.Vector.X)

            Canvas.SetTop(partTopRef.Value, Canvas.GetTop(partTopRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopLeftRef.Value, Canvas.GetTop(partTopLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopRightRef.Value, Canvas.GetTop(partTopRightRef.Value) + e.Vector.Y)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaTopRight e ->
            Canvas.SetLeft(partRightRef.Value, Canvas.GetLeft(partRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopRightRef.Value, Canvas.GetLeft(partTopRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomRightRef.Value, Canvas.GetLeft(partBottomRightRef.Value) + e.Vector.X)

            Canvas.SetTop(partTopRef.Value, Canvas.GetTop(partTopRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopLeftRef.Value, Canvas.GetTop(partTopLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partTopRightRef.Value, Canvas.GetTop(partTopRightRef.Value) + e.Vector.Y)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaBottomLeft e ->
            Canvas.SetLeft(partLeftRef.Value, Canvas.GetLeft(partLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopLeftRef.Value, Canvas.GetLeft(partTopLeftRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomLeftRef.Value, Canvas.GetLeft(partBottomLeftRef.Value) + e.Vector.X)

            Canvas.SetTop(partBottomRef.Value, Canvas.GetTop(partBottomRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomLeftRef.Value, Canvas.GetTop(partBottomLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomRightRef.Value, Canvas.GetTop(partBottomRightRef.Value) + e.Vector.Y)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

        | OnDragDeltaBottomRight e ->
            Canvas.SetLeft(partRightRef.Value, Canvas.GetLeft(partRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partTopRightRef.Value, Canvas.GetLeft(partTopRightRef.Value) + e.Vector.X)
            Canvas.SetLeft(partBottomRightRef.Value, Canvas.GetLeft(partBottomRightRef.Value) + e.Vector.X)

            Canvas.SetTop(partBottomRef.Value, Canvas.GetTop(partBottomRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomLeftRef.Value, Canvas.GetTop(partBottomLeftRef.Value) + e.Vector.Y)
            Canvas.SetTop(partBottomRightRef.Value, Canvas.GetTop(partBottomRightRef.Value) + e.Vector.Y)

            let rect = getRect()

            Canvas.SetLeft(partTopRef.Value, rect.Center.X)
            Canvas.SetLeft(partBottomRef.Value, rect.Center.X)

            Canvas.SetTop(partLeftRef.Value, rect.Center.Y)
            Canvas.SetTop(partRightRef.Value, rect.Center.Y)

            updateDrag(rect)

            updateControl(controlRef.Value, rect.Inflate(Thickness(-model.LeftOffset, -model.TopOffset, model.LeftOffset, model.TopOffset)))

            model

    let program = Program.stateful init update

    let view () =
        Component("ThumbPage") {
            let! model = Context.Mvu program

            Panel() {
                (Canvas() {
                    Rectangle()
                        .fill(Colors.Blue)
                        .canvasLeft(30.)
                        .canvasTop(30.)
                        .width(240.)
                        .height(240.)
                        .reference(controlRef)

                    Thumb()
                        .reference(partDragRef)
                        .classes([ "drag"; "sizeAll" ])
                        .onDragDelta(OnDragDeltaDrag)

                    Thumb()
                        .reference(partTopRef)
                        .classes([ "resize"; "topSide" ])
                        .onDragDelta(OnDragDeltaTop)

                    Thumb()
                        .reference(partBottomRef)
                        .classes([ "resize"; "bottomSide" ])
                        .onDragDelta(OnDragDeltaBottom)

                    Thumb()
                        .reference(partLeftRef)
                        .classes([ "resize"; "leftSide" ])
                        .onDragDelta(OnDragDeltaLeft)

                    Thumb()
                        .reference(partRightRef)
                        .classes([ "resize"; "rightSide" ])
                        .onDragDelta(OnDragDeltaRight)

                    Thumb()
                        .reference(partTopLeftRef)
                        .classes([ "resize"; "topLeftCorner" ])
                        .onDragDelta(OnDragDeltaTopLeft)

                    Thumb()
                        .reference(partTopRightRef)
                        .classes([ "resize"; "topRightCorner" ])
                        .onDragDelta(OnDragDeltaTopRight)

                    Thumb(
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png")
                            .size(20., 20.)
                    )
                        .reference(partBottomLeftRef)
                        .classes([ "resize"; "bottomLeftCorner" ])
                        .onDragDelta(OnDragDeltaBottomLeft)

                    Thumb()
                        .reference(partBottomRightRef)
                        .classes([ "resize"; "bottomRightCorner" ])
                        .onDragDelta(OnDragDeltaBottomRight)
                })
                    .width(300.)
                    .height(300.)
                    .clipToBounds(false)
                    .background(Brushes.LightGray)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
                    .reference(canvas)

            }
            |> _.onLoaded(OnLoaded)
        }
