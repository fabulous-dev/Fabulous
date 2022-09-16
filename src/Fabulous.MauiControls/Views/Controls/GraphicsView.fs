namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IGraphicsView =
    inherit Fabulous.Maui.IView

module GraphicsView =
    let WidgetKey = Widgets.register<GraphicsView>()

    let Drawable =
        Attributes.defineBindableWithEquality<IDrawable> GraphicsView.DrawableProperty

    let StartHoverInteraction =
        Attributes.defineEvent<TouchEventArgs>
            "GraphicsView_StartHoverInteraction"
            (fun target -> (target :?> GraphicsView).StartHoverInteraction)

    let MoveHoverInteraction =
        Attributes.defineEvent<TouchEventArgs>
            "GraphicsView_MoveHoverInteraction"
            (fun target -> (target :?> GraphicsView).MoveHoverInteraction)

    let EndHoverInteraction =
        Attributes.defineEventNoArg
            "GraphicsView_EndHoverInteraction"
            (fun target -> (target :?> GraphicsView).EndHoverInteraction)

    let StartInteraction =
        Attributes.defineEvent<TouchEventArgs>
            "GraphicsView_StartInteraction"
            (fun target -> (target :?> GraphicsView).StartInteraction)

    let DragInteraction =
        Attributes.defineEvent<TouchEventArgs>
            "GraphicsView_DragInteraction"
            (fun target -> (target :?> GraphicsView).DragInteraction)


    let EndInteraction =
        Attributes.defineEvent<TouchEventArgs>
            "GraphicsView_EndInteraction"
            (fun target -> (target :?> GraphicsView).EndInteraction)

    let CancelInteraction =
        Attributes.defineEventNoArg
            "GraphicsView_CancelInteraction"
            (fun target -> (target :?> GraphicsView).CancelInteraction)


[<AutoOpen>]
module GraphicsViewBuilders =
    /// <summary>GraphicsView defines the Drawable property, of type IDrawable, which specifies the content that will be drawn.</summary>
    type Fabulous.Maui.View with
        static member inline GraphicsView<'msg>(drawable: IDrawable) =
            WidgetBuilder<'msg, IGraphicsView>(GraphicsView.WidgetKey, GraphicsView.Drawable.WithValue(drawable))

[<Extension>]
type GraphicsViewModifiers =
    /// <summary>StartHoverInteraction, with TouchEventArgs, which is raised when a pointer enters the hit test area of the GraphicsView.</summary>
    [<Extension>]
    static member inline onStartHoverInteraction
        (
            this: WidgetBuilder<'msg, #IGraphicsView>,
            onStartHoverInteraction: TouchEventArgs -> 'msg
        ) =
        this.AddScalar(GraphicsView.StartHoverInteraction.WithValue(fun args -> onStartHoverInteraction args |> box))

    /// <summary>MoveHoverInteraction, with TouchEventArgs, which is raised when a pointer moves while the pointer remains within the hit test area of the GraphicsView.</summary>
    [<Extension>]
    static member inline onMoveHoverInteraction
        (
            this: WidgetBuilder<'msg, #IGraphicsView>,
            onMoveHoverInteraction: TouchEventArgs -> 'msg
        ) =
        this.AddScalar(GraphicsView.MoveHoverInteraction.WithValue(fun args -> onMoveHoverInteraction args |> box))

    /// <summary>EndHoverInteraction, which is raised when a pointer leaves the hit test area of the GraphicsView.</summary>
    [<Extension>]
    static member inline onEndHoverInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, onEndHoverInteraction: 'msg) =
        this.AddScalar(GraphicsView.EndHoverInteraction.WithValue(onEndHoverInteraction))

    /// <summary>StartInteraction, with TouchEventArgs, which is raised when the GraphicsView is pressed.</summary>
    [<Extension>]
    static member inline onStartInteraction
        (
            this: WidgetBuilder<'msg, #IGraphicsView>,
            onStartInteraction: TouchEventArgs -> 'msg
        ) =
        this.AddScalar(GraphicsView.StartInteraction.WithValue(fun args -> onStartInteraction args |> box))


    /// <summary>DragInteraction, with TouchEventArgs, which is raised when the GraphicsView is dragged.</summary>
    [<Extension>]
    static member inline onDragInteraction
        (
            this: WidgetBuilder<'msg, #IGraphicsView>,
            onDragInteraction: TouchEventArgs -> 'msg
        ) =
        this.AddScalar(GraphicsView.DragInteraction.WithValue(fun args -> onDragInteraction args |> box))

    /// <summary>EndInteraction, with TouchEventArgs, which is raised when the press that raised the StartInteraction event is released.</summary>
    [<Extension>]
    static member inline onEndInteraction
        (
            this: WidgetBuilder<'msg, #IGraphicsView>,
            onEndInteraction: TouchEventArgs -> 'msg
        ) =
        this.AddScalar(GraphicsView.EndInteraction.WithValue(fun args -> onEndInteraction args |> box))

    /// <summary>CancelInteraction, which is raised when the press that made contact with the GraphicsView loses contact.</summary>
    [<Extension>]
    static member inline onCancelInteraction(this: WidgetBuilder<'msg, #IGraphicsView>, onCancelInteraction: 'msg) =
        this.AddScalar(GraphicsView.CancelInteraction.WithValue(onCancelInteraction))
