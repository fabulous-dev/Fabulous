namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabBorder =
    inherit IFabDecorator

module Border =
    let WidgetKey = Widgets.register<Border>()

    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Border.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality Border.BackgroundProperty

    let BackgroundSizing =
        Attributes.defineAvaloniaPropertyWithEquality Border.BackgroundSizingProperty

    let BorderBrushWidget =
        Attributes.defineAvaloniaPropertyWidget Border.BorderBrushProperty

    let BorderBrush =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderBrushProperty

    let BorderThickness =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderThicknessProperty

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality Border.CornerRadiusProperty

    let BoxShadow =
        Attributes.defineAvaloniaPropertyWithEquality Border.BoxShadowProperty

[<AutoOpen>]
module BorderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Border widget.</summary>
        static member Border() =
            WidgetBuilder<'msg, IFabBorder>(Border.WidgetKey)

        /// <summary>Creates a Border widget.</summary>
        /// <param name="content">The content of the Border.</param>
        static member Border(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabBorder>(Border.WidgetKey, Decorator.ChildWidget.WithValue(content.Compile()))

type BorderModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Border.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: IBrush) =
        this.AddScalar(Border.Background.WithValue(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: Color) =
        BorderModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        BorderModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the BackgroundSizing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundSizing value.</param>
    [<Extension>]
    static member inline backgroundSizing(this: WidgetBuilder<'msg, #IFabBorder>, value: BackgroundSizing) =
        this.AddScalar(Border.BackgroundSizing.WithValue(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Border.BorderBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: IBrush) =
        this.AddScalar(Border.BorderBrush.WithValue(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: Color) =
        BorderModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        BorderModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: Thickness) =
        this.AddScalar(Border.BorderThickness.WithValue(value))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, value: CornerRadius) =
        this.AddScalar(Border.CornerRadius.WithValue(value))

    /// <summary>Sets the BoxShadow property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BoxShadow value.</param>
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, value: BoxShadows) =
        this.AddScalar(Border.BoxShadow.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Border control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBorder>, value: ViewRef<Border>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type BorderExtraModifiers =
    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(value))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="top">The top value.</param>
    /// <param name="bottom">The bottom value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, top: float, bottom: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(top, bottom))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="topLeft">The topLeft value.</param>
    /// <param name="topRight">The topRight value.</param>
    /// <param name="bottomRight">The bottomRight value.</param>
    /// <param name="bottomLeft">The bottomLeft value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, topLeft: float, topRight: float, bottomRight: float, bottomLeft: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(topLeft, topRight, bottomRight, bottomLeft))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        BorderModifiers.borderThickness(this, Thickness(value))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal value.</param>
    /// <param name="vertical">The vertical value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, horizontal: float, vertical: float) =
        BorderModifiers.borderThickness(this, Thickness(horizontal, vertical))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left value.</param>
    /// <param name="top">The top value.</param>
    /// <param name="right">The right value.</param>
    /// <param name="bottom">The bottom value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, left: float, top: float, right: float, bottom: float) =
        BorderModifiers.borderThickness(this, Thickness(left, top, right, bottom))

    /// <summary>Sets the BoxShadow property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BoxShadow value.</param>
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, value: BoxShadow) =
        BorderModifiers.boxShadow(this, BoxShadows(value))

    /// <summary>Sets the BoxShadow property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BoxShadow value.</param>
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        BorderModifiers.boxShadow(this, BoxShadows(BoxShadow.Parse(value)))

    /// <summary>Sets the BoxShadow property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="first">The first BoxShadow value.</param>
    /// <param name="rest">The rest of the BoxShadow values.</param>
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, first: BoxShadow, rest: BoxShadow list) =
        BorderModifiers.boxShadow(this, BoxShadows(first, rest |> List.toArray))

    /// <summary>Sets the BoxShadow property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="first">The first BoxShadow value.</param>
    /// <param name="rest">The rest of the BoxShadow values.</param>
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, first: string, rest: string list) =
        let rest = rest |> List.map BoxShadow.Parse |> List.toArray
        BorderModifiers.boxShadow(this, BoxShadows(BoxShadow.Parse(first), rest))
