namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabPathIcon =
    inherit IFabIconElement

module PathIcon =
    let WidgetKey = Widgets.register<PathIcon>()

    let DataWidget = Attributes.defineAvaloniaPropertyWidget PathIcon.DataProperty

    let DataString = Attributes.defineAvaloniaPropertyWithEquality PathIcon.DataProperty

[<AutoOpen>]
module PathIconBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="content">The content of the PathIcon.</param>
        static member PathIcon(content: WidgetBuilder<'msg, #IFabGeometry>) =
            WidgetBuilder<'msg, IFabPathIcon>(PathIcon.WidgetKey, PathIcon.DataWidget.WithValue(content.Compile()))

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="path">The path of the PathIcon.</param>
        static member PathIcon(path: string) =
            WidgetBuilder<'msg, IFabPathIcon>(PathIcon.WidgetKey, PathIcon.DataString.WithValue(Geometry.Parse(path)))

type PathIconModifiers =
    /// <summary>Link a ViewRef to access the direct PathIcon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathIcon>, value: ViewRef<PathIcon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
