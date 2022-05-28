namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type ITabbedPage =
    inherit IMultiPageOfPage

module TabbedPage =
    let WidgetKey = Widgets.register<TabbedPage>()

    let BarBackgroundColor =
        Attributes.defineBindableAppThemeColor TabbedPage.BarBackgroundColorProperty

    let BarTextColor =
        Attributes.defineBindableAppThemeColor TabbedPage.BarTextColorProperty

    let SelectedTabColor =
        Attributes.defineBindableAppThemeColor TabbedPage.SelectedTabColorProperty

    let UnselectedTabColor =
        Attributes.defineBindableAppThemeColor TabbedPage.UnselectedTabColorProperty

    let ToolbarPlacement =
        Attributes.defineSimpleScalarWithEquality<AndroidSpecific.ToolbarPlacement>
            "TabbedPage_ToolbarPlacement"
            (fun _ newValueOpt node ->
                let tabbedPage = node.Target :?> TabbedPage

                let value =
                    match newValueOpt with
                    | ValueNone -> AndroidSpecific.ToolbarPlacement.Default
                    | ValueSome v -> v

                AndroidSpecific.TabbedPage.SetToolbarPlacement(tabbedPage, value))

[<AutoOpen>]
module TabbedPageBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TabbedPage<'msg>(title: string) =
            CollectionBuilder<'msg, ITabbedPage, IPage>(
                TabbedPage.WidgetKey,
                MultiPageOfPage.Children,
                Page.Title.WithValue(title)
            )

[<Extension>]
type TabbedPageModifiers =

    /// <summary>Set the color of the bar background</summary>
    /// <param name="light">The color of the bar background in the light theme.</param>
    /// <param name="dark">The color of the bar background in the dark theme.</param>
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #ITabbedPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TabbedPage.BarBackgroundColor.WithValue(ColorPair.create light dark))

    /// <summary>Set the color of the bar text</summary>
    /// <param name="light">The color of the bar text in the light theme.</param>
    /// <param name="dark">The color of the bar text in the dark theme.</param>
    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #ITabbedPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TabbedPage.BarTextColor.WithValue(ColorPair.create light dark))

    /// <summary>Set the color of the selected tab</summary>
    /// <param name="light">The color of the selected tab in the light theme.</param>
    /// <param name="dark">The color of the selected tab in the dark theme.</param>
    [<Extension>]
    static member inline selectedTabColor(this: WidgetBuilder<'msg, #ITabbedPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TabbedPage.SelectedTabColor.WithValue(ColorPair.create light dark))

    /// <summary>Set the color of the unselected tab</summary>
    /// <param name="light">The color of the unselected tab in the light theme.</param>
    /// <param name="dark">The color of the unselected tab in the dark theme.</param>
    [<Extension>]
    static member inline unselectedTabColor(this: WidgetBuilder<'msg, #ITabbedPage>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TabbedPage.UnselectedTabColor.WithValue(ColorPair.create light dark))

    /// <summary>Link a ViewRef to access the direct TabbedPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ITabbedPage>, value: ViewRef<TabbedPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

open Xamarin.Forms.PlatformConfiguration.AndroidSpecific

[<Extension>]
type TabbedPagePlatformModifiers =
    /// <summary>Android platform specific. Sets the toolbar placement.</summary>
    /// <param name= "value">The new toolbar placement value.</param>
    [<Extension>]
    static member inline toolbarPlacement(this: WidgetBuilder<'msg, #ITabbedPage>, value: ToolbarPlacement) =
        this.AddScalar(TabbedPage.ToolbarPlacement.WithValue(value))
