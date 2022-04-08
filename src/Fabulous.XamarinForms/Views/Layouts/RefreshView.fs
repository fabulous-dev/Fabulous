namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms

type IRefreshView =
    inherit IContentView

module RefreshView =
    let WidgetKey = Widgets.register<RefreshView>()

    let IsRefreshing =
        Attributes.defineBindable<bool> RefreshView.IsRefreshingProperty

    let RefreshColor =
        Attributes.defineAppThemeBindable<Color> RefreshView.RefreshColorProperty

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
                    StackList.two(
                        RefreshView.IsRefreshing.WithValue(isRefreshing),
                        RefreshView.Refreshing.WithValue(onRefreshing)
                    ),
                    ValueSome [| ContentView.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type RefreshViewModifiers =
    /// <summary>Set the color of the refresh indicator</summary>
    /// <param name="light">The color of the refresh indicator in the light theme.</param>
    /// <param name="dark">The color of the refresh indicator in the dark theme.</param>
    [<Extension>]
    static member inline refreshColor(this: WidgetBuilder<'msg, IRefreshView>, light: Color, ?dark: Color) =
        this.AddScalar(RefreshView.RefreshColor.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct RefreshView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IRefreshView>, value: ViewRef<RefreshView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
