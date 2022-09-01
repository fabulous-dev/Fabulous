namespace Fabulous.Maui

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IMenuItem =
    inherit Fabulous.Maui.IElement

module MenuItem =
    let WidgetKey = Widgets.register<MenuItem>()

    let Accelerator =
        Attributes.defineBindableWithEquality<Accelerator> MenuItem.AcceleratorProperty

    let IconImageSource =
        Attributes.defineBindableAppTheme<ImageSource> MenuItem.IconImageSourceProperty

    let IsDestructive =
        Attributes.defineBindableBool MenuItem.IsDestructiveProperty

    let IsEnabled =
        Attributes.defineBindableBool MenuItem.IsEnabledProperty

    let Text =
        Attributes.defineBindableWithEquality<string> MenuItem.TextProperty

    let Clicked =
        Attributes.defineEventNoArg "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Clicked)

[<AutoOpen>]
module MenuItemBuilders =
    type Fabulous.Maui.View with
        static member inline MenuItem<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IMenuItem>(
                MenuItem.WidgetKey,
                MenuItem.Text.WithValue(text),
                MenuItem.Clicked.WithValue(onClicked)
            )

[<Extension>]
type MenuItemModifiers =
    [<Extension>]
    static member inline accelerator(this: WidgetBuilder<'msg, #IMenuItem>, value: Accelerator) =
        this.AddScalar(MenuItem.Accelerator.WithValue(value))

    /// <summary>Set the source of the icon image.</summary>
    /// <param name="light">The source of the icon image in the light theme.</param>
    /// <param name="dark">The source of the icon image in the dark theme.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IMenuItem>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(MenuItem.IconImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the icon image.</summary>
    /// <param name="light">The source of the icon image in the light theme.</param>
    /// <param name="dark">The source of the icon image in the dark theme.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IMenuItem>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        MenuItemModifiers.icon(this, light, ?dark = dark)

    /// <summary>Set the source of the icon image.</summary>
    /// <param name="light">The source of the icon image in the light theme.</param>
    /// <param name="dark">The source of the icon image in the dark theme.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IMenuItem>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        MenuItemModifiers.icon(this, light, ?dark = dark)

    /// <summary>Set the source of the icon image.</summary>
    /// <param name="light">The source of the icon image in the light theme.</param>
    /// <param name="dark">The source of the icon image in the dark theme.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IMenuItem>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        MenuItemModifiers.icon(this, light, ?dark = dark)

    [<Extension>]
    static member inline isDestructive(this: WidgetBuilder<'msg, #IMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsDestructive.WithValue(value))

    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsEnabled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct MenuItem control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IMenuItem>, value: ViewRef<MenuItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
