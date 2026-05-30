namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IGraphicsView =
    inherit IFabView

module GraphicsView =
    let WidgetKey = Widgets.register<GraphicsView>()

    let CancelInteraction =
        Attributes.Mvu.defineEventNoArg "GraphicsView_CancelInteraction" (fun target -> (target :?> GraphicsView).CancelInteraction)

    let DragInteraction =
        Attributes.Mvu.defineEvent<TouchEventArgs> "GraphicsView_DragInteraction" (fun target -> (target :?> GraphicsView).DragInteraction)

    let Drawable =
        Attributes.defineBindableWithEquality<IDrawable> GraphicsView.DrawableProperty

    let EndHoverInteraction =
        Attributes.Mvu.defineEventNoArg "GraphicsView_EndHoverInteraction" (fun target -> (target :?> GraphicsView).EndHoverInteraction)

    let EndInteraction =
        Attributes.Mvu.defineEvent<TouchEventArgs> "GraphicsView_EndInteraction" (fun target -> (target :?> GraphicsView).EndInteraction)

    let MoveHoverInteraction =
        Attributes.Mvu.defineEvent<TouchEventArgs> "GraphicsView_MoveHoverInteraction" (fun target -> (target :?> GraphicsView).MoveHoverInteraction)

    let StartHoverInteraction =
        Attributes.Mvu.defineEvent<TouchEventArgs> "GraphicsView_StartHoverInteraction" (fun target -> (target :?> GraphicsView).StartHoverInteraction)

    let StartInteraction =
        Attributes.Mvu.defineEvent<TouchEventArgs> "GraphicsView_StartInteraction" (fun target -> (target :?> GraphicsView).StartInteraction)

[<AutoOpen>]
module GraphicsViewBuilders =
    /// <summary>GraphicsView defines the Drawable property, of type IDrawable, which specifies the content that will be drawn.</summary>
    type Fabulous.Maui.View with

        /// <summary>Create a GraphicsView widget with a drawable content</summary>
        /// <param name="drawable">The drawable content</param>
        static member inline GraphicsView<'msg when 'msg: equality>(drawable: IDrawable) =
            WidgetBuilder<'msg, IGraphicsView>(GraphicsView.WidgetKey, GraphicsView.Drawable.WithValue(drawable))

[<Extension>]
type GraphicsViewModifiers =
    /// <summary>Listen for the CancelInteraction event, which is raised when the press that made contact with the GraphicsView loses contact</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onCancelInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, msg: 'msg) =
        this.AddScalar(GraphicsView.CancelInteraction.WithValue(MsgValue(msg)))

    /// <summary>Listen for the DragInteraction event, with TouchEventArgs, which is raised when the GraphicsView is dragged</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onDragInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, fn: TouchEventArgs -> 'msg) =
        this.AddScalar(GraphicsView.DragInteraction.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the EndHoverInteraction event, which is raised when a pointer leaves the hit test area of the GraphicsView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onEndHoverInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, msg: 'msg) =
        this.AddScalar(GraphicsView.EndHoverInteraction.WithValue(MsgValue(msg)))

    /// <summary>Listen for the EndInteraction event, with TouchEventArgs, which is raised when the press that raised the StartInteraction event is released</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onEndInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, fn: TouchEventArgs -> 'msg) =
        this.AddScalar(GraphicsView.EndInteraction.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the MoveHoverInteraction event, with TouchEventArgs, which is raised when a pointer moves while the pointer remains within the hit test area of the GraphicsView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onMoveHoverInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, fn: TouchEventArgs -> 'msg) =
        this.AddScalar(GraphicsView.MoveHoverInteraction.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the StartHoverInteraction event, with TouchEventArgs, which is raised when a pointer enters the hit test area of the GraphicsView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onStartHoverInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, fn: TouchEventArgs -> 'msg) =
        this.AddScalar(GraphicsView.StartHoverInteraction.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the StartInteraction event, with TouchEventArgs, which is raised when the GraphicsView is pressed</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onStartInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, fn: TouchEventArgs -> 'msg) =
        this.AddScalar(GraphicsView.StartInteraction.WithValue(fun args -> fn args |> box))
