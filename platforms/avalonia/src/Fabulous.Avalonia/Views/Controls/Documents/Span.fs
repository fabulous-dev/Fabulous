namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabSpan =
    inherit IFabInline

module Span =
    let WidgetKey = Widgets.register<Span>()

    let Inlines =
        Attributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)


[<AutoOpen>]
module SpanBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<'msg, IFabSpan, IFabInline>(Span.WidgetKey, Span.Inlines)

type SpanModifiers =
    /// <summary>Link a ViewRef to access the direct Span control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type SpanCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: CollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: CollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
