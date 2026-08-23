namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabRefreshView =
    inherit IFabContentView

module RefreshView =
    let WidgetKey = Widgets.register<RefreshView>()

    let IsRefreshing = Attributes.defineBindableBool RefreshView.IsRefreshingProperty

    let RefreshColor = Attributes.defineBindableColor RefreshView.RefreshColorProperty

    let Refreshing =
        Attributes.Mvu.defineEventNoArg "RefreshView_Refreshing" (fun target -> (target :?> RefreshView).Refreshing)

[<AutoOpen>]
module RefreshViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RefreshView widget with content</summary>
        /// <param name="isRefreshing">The refresh state</param>
        /// <param name="onRefreshing">Message to dispatch when refresh state changes</param>
        /// <param name="content">The content widget</param>
        static member inline RefreshView(isRefreshing: bool, onRefreshing: 'msg, content: WidgetBuilder<'msg, #IFabView>) =
            WidgetBuilder<'msg, IFabRefreshView>(
                RefreshView.WidgetKey,
                AttributesBundle(
                    StackList.two(RefreshView.IsRefreshing.WithValue(isRefreshing), RefreshView.Refreshing.WithValue(MsgValue(onRefreshing))),
                    [| ContentView.Content.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

[<Extension>]
type RefreshViewModifiers =
    /// <summary>Set the color of the refresh indicator</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the refresh indicator</param>
    [<Extension>]
    static member inline refreshColor(this: WidgetBuilder<'msg, #IFabRefreshView>, value: Color) =
        this.AddScalar(RefreshView.RefreshColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RefreshView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRefreshView>, value: ViewRef<RefreshView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
