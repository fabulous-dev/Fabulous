namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration
open Microsoft.Maui.Graphics

type IFabTabbedPage =
    inherit IFabMultiPageOfPage

module TabbedPage =
    let WidgetKey = Widgets.register<TabbedPage>()

    let BarBackgroundColor =
        Attributes.defineBindableColor TabbedPage.BarBackgroundColorProperty

    let BarTextColor = Attributes.defineBindableColor TabbedPage.BarTextColorProperty

    let SelectedTabColor =
        Attributes.defineBindableColor TabbedPage.SelectedTabColorProperty

    let ToolbarPlacement =
        Attributes.defineSimpleScalarWithEquality<AndroidSpecific.ToolbarPlacement> "TabbedPage_ToolbarPlacement" (fun _ newValueOpt node ->
            let tabbedPage = node.Target :?> TabbedPage

            let value =
                match newValueOpt with
                | ValueNone -> AndroidSpecific.ToolbarPlacement.Default
                | ValueSome v -> v

            AndroidSpecific.TabbedPage.SetToolbarPlacement(tabbedPage, value))

    let UnselectedTabColor =
        Attributes.defineBindableColor TabbedPage.UnselectedTabColorProperty

[<AutoOpen>]
module TabbedPageBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a TabbedPage widget</summary>
        static member inline TabbedPage<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabTabbedPage, IFabPage>(TabbedPage.WidgetKey, MultiPageOfPage.Children)

[<Extension>]
type TabbedPageModifiers =
    /// <summary>Set the background color of the bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The background color of the bar</param>
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #IFabTabbedPage>, value: Color) =
        this.AddScalar(TabbedPage.BarBackgroundColor.WithValue(value))

    /// <summary>Set the text color of the bar</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The text color of the bar</param>
    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #IFabTabbedPage>, value: Color) =
        this.AddScalar(TabbedPage.BarTextColor.WithValue(value))

    /// <summary>Set the color of the selected tab</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the selected tab</param>
    [<Extension>]
    static member inline selectedTabColor(this: WidgetBuilder<'msg, #IFabTabbedPage>, value: Color) =
        this.AddScalar(TabbedPage.SelectedTabColor.WithValue(value))

    /// <summary>Set the color of the unselected tab</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the unselected tab</param>
    [<Extension>]
    static member inline unselectedTabColor(this: WidgetBuilder<'msg, #IFabTabbedPage>, value: Color) =
        this.AddScalar(TabbedPage.UnselectedTabColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TabbedPage control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTabbedPage>, value: ViewRef<TabbedPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type TabbedPagePlatformModifiers =
    /// <summary>Android platform specific. Set the toolbar placement</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "value">The toolbar placement value</param>
    [<Extension>]
    static member inline toolbarPlacement(this: WidgetBuilder<'msg, #IFabTabbedPage>, value: AndroidSpecific.ToolbarPlacement) =
        this.AddScalar(TabbedPage.ToolbarPlacement.WithValue(value))

[<Extension>]
type TabbedPageYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabTabbedPage, IFabPage>, x: WidgetBuilder<'msg, #IFabPage>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabTabbedPage, IFabPage>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabPage>>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
