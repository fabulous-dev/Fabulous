namespace Gallery

open System
open System.Numerics
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous
open Fabulous.Avalonia


open type Fabulous.Avalonia.View

module ViewExtensions =
    let Apply (visual: Visual, offsetX: float, offsetY: float, duration: TimeSpan) =

        let compositionVisual = ElementComposition.GetElementVisual(visual)

        if (compositionVisual <> null) then
            let compositor = compositionVisual.Compositor

            let offsetAnimation = compositor.CreateVector3KeyFrameAnimation()
            offsetAnimation.InsertKeyFrame(0.0f, Vector3(float32 offsetX, float32 offsetY, float32 0.))
            offsetAnimation.InsertKeyFrame(1.0f, Vector3(float32 0., float32 0., float32 0.))
            offsetAnimation.Direction <- PlaybackDirection.Normal
            offsetAnimation.Duration <- duration
            offsetAnimation.IterationBehavior <- AnimationIterationBehavior.Count
            offsetAnimation.IterationCount <- 1

            compositionVisual.StartAnimation("Offset", offsetAnimation)


    let SetLeft (element: Control, milliseconds: float) =
        element.Loaded.AddHandler(fun _ _ -> Apply(element, -element.Bounds.Width, 0, TimeSpan.FromMilliseconds(milliseconds)))

    let SetRight (element: Control, milliseconds: float) =
        element.Loaded.AddHandler(fun _ _ -> Apply(element, 2. * element.Bounds.Width, 0, TimeSpan.FromMilliseconds(milliseconds)))

    let SetTop (element: Control, milliseconds: float) =
        element.Loaded.AddHandler(fun _ _ -> Apply(element, 0, -element.Bounds.Height, TimeSpan.FromMilliseconds(milliseconds)))

    let SetBottom (element: Control, milliseconds: float) =
        element.Loaded.AddHandler(fun _ _ -> Apply(element, 0, 2. * element.Bounds.Height, TimeSpan.FromMilliseconds(milliseconds)))

    let SlideLeft =
        Attributes.defineFloat "Control_SlideLeft" (fun _ newValueOpt node ->
            let target = node.Target :?> Control

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome v -> SetLeft(target, v))

    let SlideRight =
        Attributes.defineFloat "Control_SlideRight" (fun _ newValueOpt node ->
            let target = node.Target :?> Control

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome v -> SetRight(target, v))

    let SlideTop =
        Attributes.defineFloat "Control_SlideTop" (fun _ newValueOpt node ->
            let target = node.Target :?> Control

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome v -> SetTop(target, v))

    let SlideBottom =
        Attributes.defineFloat "Control_SlideBottom" (fun _ newValueOpt node ->
            let target = node.Target :?> Control

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome v -> SetBottom(target, v))

type AnimatedControlModifiers =
    [<Extension>]
    static member inline slideLeft(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(ViewExtensions.SlideLeft.WithValue(value))

    [<Extension>]
    static member inline slideTop(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(ViewExtensions.SlideTop.WithValue(value))

    [<Extension>]
    static member inline slideRight(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(ViewExtensions.SlideRight.WithValue(value))

    [<Extension>]
    static member inline slideBottom(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(ViewExtensions.SlideBottom.WithValue(value))

module SlidingAnimation =
    let view () =
        TabControl() {
            TabItem(
                "Left",
                (Panel() {
                    Border(
                        (VStack(6.) {
                            TextBlock("TextBlock1")
                            TextBlock("TextBlock2")
                            TextBlock("TextBlock3")
                        })
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)
                    )
                        .background(Brushes.Transparent)
                        .slideLeft(500.)
                })
                    .clipToBounds(true)

            )

            TabItem(
                "Right",
                (Panel() {
                    Border(
                        (VStack(6.) {
                            TextBlock("TextBlock1")
                            TextBlock("TextBlock2")
                            TextBlock("TextBlock3")
                        })
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)
                    )
                        .background(Brushes.Transparent)
                        .slideRight(500.)

                })
                    .clipToBounds(true)
            )

            TabItem(
                "Top",
                (Panel() {
                    Border(
                        (VStack(6.) {
                            TextBlock("TextBlock1")
                            TextBlock("TextBlock2")
                            TextBlock("TextBlock3")
                        })
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)
                    )
                        .background(Brushes.Transparent)
                        .slideTop(500.)
                })
                    .clipToBounds(true)
            )

            TabItem(
                "Bottom",
                (Panel() {
                    Border(
                        (VStack(6.) {
                            TextBlock("TextBlock1")
                            TextBlock("TextBlock2")
                            TextBlock("TextBlock3")
                        })
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)
                    )
                        .background(Brushes.Transparent)
                        .slideBottom(500.)
                })
                    .clipToBounds(true)
            )
        }
