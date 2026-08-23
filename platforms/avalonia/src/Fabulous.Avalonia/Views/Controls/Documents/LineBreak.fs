namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabLineBreak =
    inherit IFabInline

module LineBreak =
    let WidgetKey = Widgets.register<LineBreak>()

[<AutoOpen>]
module LineBreakBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a LineBreak widget.</summary>
        static member LineBreak() =
            WidgetBuilder<'msg, IFabLineBreak>(LineBreak.WidgetKey)

type LineBreakModifiers =
    /// <summary>Link a ViewRef to access the direct LineBreak control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLineBreak>, value: ViewRef<LineBreak>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
