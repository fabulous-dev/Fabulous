namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
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

    let PickerUpdateMode =
        Attributes.define<UpdateMode>
            "Picker_UpdateMode"
            (fun newValueOpt node ->
                let picker = node.Target :?> Xamarin.Forms.Picker

                let value =
                    match newValueOpt with
                    | ValueNone -> UpdateMode.Immediately
                    | ValueSome v -> v

                picker.On<iOS>().SetUpdateMode(value) |> ignore)

    let DatePickerUpdateMode =
        Attributes.define<UpdateMode>
            "DatePicker_UpdateMode"
            (fun newValueOpt node ->
                let datePicker = node.Target :?> Xamarin.Forms.DatePicker

                let value =
                    match newValueOpt with
                    | ValueNone -> UpdateMode.Immediately
                    | ValueSome v -> v

                datePicker.On<iOS>().SetUpdateMode(value)
                |> ignore)

    let TimePickerUpdateMode =
        Attributes.define<UpdateMode>
            "TimePicker_UpdateMode"
            (fun newValueOpt node ->
                let timePicker = node.Target :?> Xamarin.Forms.TimePicker

                let value =
                    match newValueOpt with
                    | ValueNone -> UpdateMode.Immediately
                    | ValueSome v -> v

                timePicker.On<iOS>().SetUpdateMode(value)
                |> ignore)

    let HideNavigationBarSeparator =
        Attributes.define<bool>
            "NavigationPage_HideNavigationBarSeparator"
            (fun newValueOpt node ->
                let page =
                    node.Target :?> Xamarin.Forms.NavigationPage

                let value =
                    match newValueOpt with
                    | ValueNone -> false
                    | ValueSome v -> v

                page
                    .On<iOS>()
                    .SetHideNavigationBarSeparator(value)
                |> ignore)

    let CursorColor =
        Attributes.define<Color>
            "Entry_CursorColor"
            (fun newValueOpt node ->
                let entry = node.Target :?> Xamarin.Forms.Entry

                let value =
                    match newValueOpt with
                    | ValueNone -> Xamarin.Forms.Color.Default
                    | ValueSome x -> x

                entry.On<iOS>().SetCursorColor(value) |> ignore)

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
    /// <summary>iOS platform specific. Sets a value that controls whether padding values are overridden with the safe area insets.</summary>
    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<'msg, #IPage>) =
        this.AddScalar(iOS.UseSafeArea.WithValue(false))

    /// <summary>iOS platform specific. Sets a value that controls whether elements in the picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline pickerUpdateMode(this: WidgetBuilder<'msg, #IPicker>, mode: UpdateMode) =
        this.AddScalar(iOS.PickerUpdateMode.WithValue(mode))

    /// <summary>iOS platform specific. Sets a value that controls whether elements in the date picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline datePickerUpdateMode(this: WidgetBuilder<'msg, #IDatePicker>, mode: UpdateMode) =
        this.AddScalar(iOS.DatePickerUpdateMode.WithValue(mode))

    /// <summary>iOS platform specific. Sets a value that controls whether elements in the time picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline timePickerUpdateMode(this: WidgetBuilder<'msg, #ITimePicker>, mode: UpdateMode) =
        this.AddScalar(iOS.TimePickerUpdateMode.WithValue(mode))

    /// <summary>iOS platform specific. Sets a value that hides the navigation bar separator.</summary>
    /// <param name="value">true to hide the separator. Otherwise, false.</param>
    [<Extension>]
    static member inline hideNavigationBarSeparator(this: WidgetBuilder<'msg, #INavigationPage>, value: bool) =
        this.AddScalar(iOS.HideNavigationBarSeparator.WithValue(value))

    /// <summary>iOS platform specific. Sets the entry color of the cursor</summary>
    /// <param name="value">The new cursor color.</param>
    [<Extension>]
    static member inline cursorColor(this: WidgetBuilder<'msg, #IEntry>, value: Color) =
        this.AddScalar(iOS.CursorColor.WithValue(value))

    /// <summary>Android platform specific. Sets the toolbar placement.</summary>
    /// <param name= "value">The new toolbar placement value.</param>
    [<Extension>]
    static member inline toolbarPlacement(this: WidgetBuilder<'msg, #ITabbedPage>, value: ToolbarPlacement) =
        this.AddScalar(Android.ToolbarPlacement.WithValue(value))
