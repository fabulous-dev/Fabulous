namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTransitioningContentControl =
    inherit IFabContentControl

module TransitioningContentControl =
    let WidgetKey = Widgets.register<TransitioningContentControl>()

    let PageTransition =
        Attributes.defineAvaloniaPropertyWithEquality TransitioningContentControl.PageTransitionProperty

    let IsTransitionReversed =
        Attributes.defineAvaloniaPropertyWithEquality TransitioningContentControl.IsTransitionReversedProperty


[<AutoOpen>]
module TransitioningContentControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TransitioningContentControl widget.</summary>
        static member TransitioningContentControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTransitioningContentControl>(
                TransitioningContentControl.WidgetKey,
                ContentControl.ContentWidget.WithValue(content.Compile())
            )

type TransitioningContentControlModifiers =
    /// <summary>Link a ViewRef to access the direct TransitioningContentControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTransitioningContentControl>, value: ViewRef<TransitioningContentControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the PageTransition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PageTransition value.</param>
    [<Extension>]
    static member inline pageTransition(this: WidgetBuilder<'msg, #IFabTransitioningContentControl>, value: #IPageTransition) =
        this.AddScalar(TransitioningContentControl.PageTransition.WithValue(value))

    /// <summary>Sets the IsTransitionReversed property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTransitionReversed value.</param>
    [<Extension>]
    static member inline isTransitionReversed(this: WidgetBuilder<'msg, #IFabTransitioningContentControl>, value: bool) =
        this.AddScalar(TransitioningContentControl.IsTransitionReversed.WithValue(value))
