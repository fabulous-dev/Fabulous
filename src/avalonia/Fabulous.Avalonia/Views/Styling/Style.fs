namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyle =
    inherit IFabElement

module Style =

    let WidgetKey = Widgets.register<Style>()

    let Animations =
        Attributes.defineAvaloniaListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations)

[<AutoOpen>]
module StyleBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates an Animations widget.</summary>
        static member Animations() =
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations)


type StyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, #IFabStyle>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabStyle>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type StyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.StylesWidget) { value }
