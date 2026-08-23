namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThumb =
    inherit IFabTemplatedControl

module Thumb =
    let WidgetKey = Widgets.register<Thumb>()

[<AutoOpen>]
module ThumbBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Thumb widget.</summary>
        static member Thumb() =
            WidgetBuilder<'msg, IFabThumb>(Thumb.WidgetKey)

        /// <summary>Creates a Thumb widget.</summary>
        /// <param name="template">The template to use for the Thumb.</param>
        static member Thumb(template: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabThumb>(Thumb.WidgetKey, TemplatedControl.Template.WithValue(template.Compile()))

type ThumbModifiers =

    /// <summary>Link a ViewRef to access the direct Thumb control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabThumb>, value: ViewRef<Thumb>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
