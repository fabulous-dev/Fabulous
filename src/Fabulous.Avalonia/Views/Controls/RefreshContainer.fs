namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabRefreshContainer =
    inherit IFabContentControl

module RefreshContainer =
    let WidgetKey = Widgets.register<RefreshContainer>()

    let Visualizer =
        Attributes.defineAvaloniaPropertyWidget RefreshContainer.VisualizerProperty

    let PullDirection =
        Attributes.defineAvaloniaPropertyWithEquality RefreshContainer.PullDirectionProperty

[<AutoOpen>]
module RefreshContainerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RefreshContainer widget.</summary>
        /// <param name="content">The content of the RefreshContainer.</param>
        static member RefreshContainer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRefreshContainer>(RefreshContainer.WidgetKey, ContentControl.ContentWidget.WithValue(content.Compile()))


type RefreshContainerModifiers =
    /// <summary>Sets the PullDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PullDirection value.</param>
    [<Extension>]
    static member inline pullDirection(this: WidgetBuilder<'msg, #IFabRefreshContainer>, value: PullDirection) =
        this.AddScalar(RefreshContainer.PullDirection.WithValue(value))

    /// <summary>Sets the Visualizer property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Visualizer value.</param>
    [<Extension>]
    static member inline visualizer(this: WidgetBuilder<'msg, #IFabRefreshContainer>, value: WidgetBuilder<'msg, IFabRefreshVisualizer>) =
        this.AddWidget(RefreshContainer.Visualizer.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct RefreshContainer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRefreshContainer>, value: ViewRef<RefreshContainer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
