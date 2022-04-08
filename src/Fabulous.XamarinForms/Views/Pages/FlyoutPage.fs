namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IFlyoutPage =
    inherit IPage

module FlyoutPage =
    let WidgetKey = Widgets.register<FlyoutPage>()

    let CanChangeIsPresented =
        Attributes.define<bool>
            "FlyoutPage_CanChangeIsPresented"
            (fun _ newValueOpt node ->
                let flyoutPage = node.Target :?> FlyoutPage

                let value =
                    match newValueOpt with
                    | ValueNone -> flyoutPage.CanChangeIsPresented
                    | ValueSome v -> v

                flyoutPage.CanChangeIsPresented <- value)

    let IsGestureEnabled =
        Attributes.defineBindable<bool> FlyoutPage.IsGestureEnabledProperty

    let IsPresented =
        Attributes.defineBindable<bool> FlyoutPage.IsPresentedProperty

    let Flyout =
        Attributes.defineWidget
            "FlyoutPage_Flyout"
            (fun target -> ViewNode.get (target :?> FlyoutPage).Flyout)
            (fun target value -> (target :?> FlyoutPage).Flyout <- value)

    let FlyoutBounds =
        Attributes.define<Rectangle>
            "FlyoutPage_FlyoutBounds"
            (fun _ newValueOpt node ->
                let flyoutPage = node.Target :?> FlyoutPage

                let value =
                    match newValueOpt with
                    | ValueNone -> flyoutPage.FlyoutBounds
                    | ValueSome v -> v

                flyoutPage.FlyoutBounds <- value)

    let FlyoutLayoutBehavior =
        Attributes.defineBindable<FlyoutLayoutBehavior> FlyoutPage.FlyoutLayoutBehaviorProperty

    let Detail =
        Attributes.defineWidget
            "FlyoutPage_Detail"
            (fun target -> ViewNode.get (target :?> FlyoutPage).Detail)
            (fun target value -> (target :?> FlyoutPage).Detail <- value)

    let DetailBounds =
        Attributes.define<Rectangle>
            "FlyoutPage_DetailBounds"
            (fun _ newValueOpt node ->
                let flyoutPage = node.Target :?> FlyoutPage

                let value =
                    match newValueOpt with
                    | ValueNone -> flyoutPage.DetailBounds
                    | ValueSome v -> v

                flyoutPage.DetailBounds <- value)

    let BackButtonPressed =
        Attributes.defineEvent<BackButtonPressedEventArgs>
            "FlyoutPage_BackButtonPressed"
            (fun target -> (target :?> FlyoutPage).BackButtonPressed)

    let IsPresentedChanged =
        Attributes.defineEventNoArg
            "FlyoutPage_PresentedChanged"
            (fun target -> (target :?> FlyoutPage).IsPresentedChanged)

[<AutoOpen>]
module FlyoutPageBuilders =
    type Fabulous.XamarinForms.View with

        static member inline FlyoutPage<'msg, 'marker when 'marker :> IPage>
            (
                flyout: WidgetBuilder<'msg, 'marker>,
                detail: WidgetBuilder<'msg, 'marker>
            ) =
            WidgetHelpers.buildWidgets<'msg, IFlyoutPage>
                FlyoutPage.WidgetKey
                [| FlyoutPage.Flyout.WithValue(flyout.Compile())
                   FlyoutPage.Detail.WithValue(detail.Compile()) |]

        static member inline FlyoutPage<'msg, 'flyout, 'detail when 'flyout :> IPage and 'detail :> IPage>
            (
                flyout: WidgetBuilder<'msg, 'flyout>,
                detail: WidgetBuilder<'msg, 'detail>
            ) =
            WidgetHelpers.buildWidgets<'msg, IFlyoutPage>
                FlyoutPage.WidgetKey
                [| FlyoutPage.Flyout.WithValue(flyout.Compile())
                   FlyoutPage.Detail.WithValue(detail.Compile()) |]

[<Extension>]
type FlyoutPageModifiers =

    [<Extension>]
    static member inline canChangeIsPresented(this: WidgetBuilder<'msg, #IFlyoutPage>, value: bool) =
        this.AddScalar(FlyoutPage.CanChangeIsPresented.WithValue(value))

    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFlyoutPage>, value: bool) =
        this.AddScalar(FlyoutPage.IsPresented.WithValue(value))

    [<Extension>]
    static member inline isGestureEnabled(this: WidgetBuilder<'msg, #IFlyoutPage>, value: bool) =
        this.AddScalar(FlyoutPage.IsGestureEnabled.WithValue(value))

    [<Extension>]
    static member inline flyoutLayoutBehavior(this: WidgetBuilder<'msg, #IFlyoutPage>, value: FlyoutLayoutBehavior) =
        this.AddScalar(FlyoutPage.FlyoutLayoutBehavior.WithValue(value))

    [<Extension>]
    static member inline flyoutBounds(this: WidgetBuilder<'msg, #IFlyoutPage>, value: Rectangle) =
        this.AddScalar(FlyoutPage.FlyoutBounds.WithValue(value))

    [<Extension>]
    static member inline detailBounds(this: WidgetBuilder<'msg, #IFlyoutPage>, value: Rectangle) =
        this.AddScalar(FlyoutPage.DetailBounds.WithValue(value))

    [<Extension>]
    static member inline onBackButtonPressed
        (
            this: WidgetBuilder<'msg, #IFlyoutPage>,
            onBackButtonPressed: bool -> 'msg
        ) =
        this.AddScalar(FlyoutPage.BackButtonPressed.WithValue(fun args -> onBackButtonPressed args.Handled |> box))

    [<Extension>]
    static member inline onPresentedChanged(this: WidgetBuilder<'msg, #IFlyoutPage>, onPresentedChanged: 'msg) =
        this.AddScalar(FlyoutPage.IsPresentedChanged.WithValue(onPresentedChanged))

    /// <summary>Link a ViewRef to access the direct ContentPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFlyoutPage>, value: ViewRef<FlyoutPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
