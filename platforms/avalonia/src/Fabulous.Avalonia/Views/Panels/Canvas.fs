namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabCanvas =
    inherit IFabPanel

module Canvas =

    let WidgetKey = Widgets.register<Canvas>()

    let Left = Attributes.defineAvaloniaPropertyWithEquality Canvas.LeftProperty

    let Top = Attributes.defineAvaloniaPropertyWithEquality Canvas.TopProperty

    let Right = Attributes.defineAvaloniaPropertyWithEquality Canvas.RightProperty

    let Bottom = Attributes.defineAvaloniaPropertyWithEquality Canvas.BottomProperty

[<AutoOpen>]
module CanvasBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Canvas widget.</summary>
        static member Canvas() =
            CollectionBuilder<'msg, IFabCanvas, IFabControl>(Canvas.WidgetKey, Panel.Children)

        /// <summary>Creates a Canvas widget.</summary>
        /// <param name="viewRef">The ViewRef instance that will receive access to the underlying control.</param>
        static member Canvas(viewRef: ViewRef<Canvas>) =
            WidgetBuilder<'msg, IFabCanvas>(Canvas.WidgetKey, ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox))

type CanvasModifiers =
    /// <summary>Sets the Left property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Left value.</param>
    [<Extension>]
    static member inline canvasLeft(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Left.WithValue(value))

    /// <summary>Sets the Top property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Top value.</param>
    [<Extension>]
    static member inline canvasTop(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Top.WithValue(value))

    /// <summary>Sets the Right property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Right value.</param>
    [<Extension>]
    static member inline canvasRight(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Right.WithValue(value))

    /// <summary>Sets the Bottom property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Bottom value.</param>
    [<Extension>]
    static member inline canvasBottom(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Bottom.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Canvas control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCanvas>, value: ViewRef<Canvas>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
