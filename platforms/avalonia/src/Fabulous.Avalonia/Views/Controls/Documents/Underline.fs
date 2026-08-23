namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabUnderline =
    inherit IFabSpan

module Underline =
    let WidgetKey = Widgets.register<Underline>()

[<AutoOpen>]
module UnderlineBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Underline widget.</summary>
        static member private Underline() =
            CollectionBuilder<'msg, IFabUnderline, IFabInline>(Underline.WidgetKey, Span.Inlines)

        /// <summary>Creates a Underline widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Underline(text: string) = View.Underline() { View.Run(text) }


type UnderlineModifiers =
    /// <summary>Link a ViewRef to access the direct Underline control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabUnderline>, value: ViewRef<Underline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
