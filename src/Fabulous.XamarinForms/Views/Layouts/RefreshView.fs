namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms

type IRefreshView =
    inherit IContentView

module RefreshView =
    let WidgetKey = Widgets.register<RefreshView> ()

    let IsRefreshing =
        Attributes.defineBindable<bool> RefreshView.IsRefreshingProperty

    let Refreshing =
        Attributes.defineEventNoArg "RefreshView_Refreshing" (fun target -> (target :?> RefreshView).Refreshing)

[<AutoOpen>]
module RefreshViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline RefreshView<'msg, 'marker when 'marker :> IView>
            (
                isRefreshing: bool,
                onRefreshing: 'msg,
                content: WidgetBuilder<'msg, 'marker>
            ) =
            WidgetBuilder<'msg, IRefreshView>(
                RefreshView.WidgetKey,
                AttributesBundle(
                    StackList.two (
                        RefreshView.IsRefreshing.WithValue(isRefreshing),
                        RefreshView.Refreshing.WithValue(onRefreshing)
                    ),
                    ValueSome [| ContentView.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
