namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous

type IFabDecorator =
    inherit IFabControl

module Decorator =
    let ChildWidget = Attributes.defineAvaloniaPropertyWidget Decorator.ChildProperty

    let Child = Attributes.defineAvaloniaPropertyWithEquality Decorator.ChildProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality Decorator.PaddingProperty

type DecoratorModifiers =
    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: Thickness) =
        this.AddScalar(Decorator.Padding.WithValue(value))

    /// <summary>Sets the Child property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Child value.</param>
    [<Extension>]
    static member inline child(this: WidgetBuilder<'msg, #IFabDecorator>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(Decorator.ChildWidget.WithValue(value.Compile()))

type DecoratorExtraModifiers =
    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: float) =
        DecoratorModifiers.padding(this, Thickness(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left value.</param>
    /// <param name="top">The top value.</param>
    /// <param name="right">The right value.</param>
    /// <param name="bottom">The bottom value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, left: float, top: float, right: float, bottom: float) =
        DecoratorModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal value.</param>
    /// <param name="vertical">The vertical value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, horizontal: float, vertical) =
        DecoratorModifiers.padding(this, Thickness(horizontal, vertical))
