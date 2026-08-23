namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabLayoutTransformControl =
    inherit IFabDecorator

module LayoutTransformControl =
    let WidgetKey = Widgets.register<LayoutTransformControl>()

    let LayoutTransformWidget =
        Attributes.defineAvaloniaPropertyWidget LayoutTransformControl.LayoutTransformProperty

    let LayoutTransform =
        Attributes.defineAvaloniaPropertyWithEquality LayoutTransformControl.LayoutTransformProperty

    let UseRenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality LayoutTransformControl.UseRenderTransformProperty

[<AutoOpen>]
module LayoutTransformControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a LayoutTransformControl widget.</summary>
        /// <param name="content">The content of the LayoutTransformControl.</param>
        static member LayoutTransformControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabLayoutTransformControl>(LayoutTransformControl.WidgetKey, Decorator.ChildWidget.WithValue(content.Compile()))

type LayoutTransformControlModifiers =
    /// <summary>Sets the LayoutTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LayoutTransform value.</param>
    [<Extension>]
    static member inline layoutTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(LayoutTransformControl.LayoutTransformWidget.WithValue(value.Compile()))

    /// <summary>Sets the LayoutTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LayoutTransform value.</param>
    [<Extension>]
    static member inline layoutTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, value: ITransform) =
        this.AddScalar(LayoutTransformControl.LayoutTransform.WithValue(value))

    /// <summary>Sets the UseRenderTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseRenderTransform value.</param>
    [<Extension>]
    static member inline useRenderTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, value: bool) =
        this.AddScalar(LayoutTransformControl.UseRenderTransform.WithValue(value))

    /// <summary>Link a ViewRef to access the direct LayoutTransformControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLayoutTransformControl>, value: ViewRef<LayoutTransformControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
