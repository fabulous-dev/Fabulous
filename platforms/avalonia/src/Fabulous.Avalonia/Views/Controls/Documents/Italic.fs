namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabItalic =
    inherit IFabSpan

module Italic =
    let WidgetKey = Widgets.register<Italic>()

[<AutoOpen>]
module ItalicBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Italic widget.</summary>
        static member private Italic() =
            CollectionBuilder<'msg, IFabItalic, IFabInline>(Italic.WidgetKey, Span.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) = View.Italic() { View.Run(text) }


type ItalicModifiers =
    /// <summary>Link a ViewRef to access the direct Italic control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabItalic>, value: ViewRef<Italic>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
