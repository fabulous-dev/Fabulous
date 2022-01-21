namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific
open Xamarin.Forms.PlatformConfiguration.AndroidSpecific

module iOS =
    let UseSafeArea =
        Attributes.define<bool>
            "Page_UseSafeArea"
            (fun newValueOpt node ->
                let page = node.Target :?> Xamarin.Forms.Page

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                page.On<iOS>().SetUseSafeArea(value) |> ignore)

module Android =
    let ToolbarPlacement =
        Attributes.define<ToolbarPlacement>
            "TabbedPage_ToolbarPlacement"
            (fun newValueOpt node ->
                let tabbedPage = node.Target :?> Xamarin.Forms.TabbedPage

                let value =
                    match newValueOpt with
                    | ValueNone -> ToolbarPlacement.Default
                    | ValueSome v -> v

                tabbedPage
                    .On<Android>()
                    .SetToolbarPlacement(value)
                |> ignore)

[<Extension>]
type PlatformModifiers =
    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<'msg, #IPage>) =
        this.AddScalar(iOS.UseSafeArea.WithValue(false))

    [<Extension>]
    static member inline androidToolbarPlacement(this: WidgetBuilder<'msg, #ITabbedPage>, value: ToolbarPlacement) =
        this.AddScalar(Android.ToolbarPlacement.WithValue(value))
