namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module AppLinkUpdaters =
    let applyDiffApplicationLinks (prev: ArraySlice<Widget>) (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
        let application = node.Target :?> CustomApplication
        let appLinks = application.AppLinks

        for diff in diffs do
            match diff with
            | WidgetCollectionItemChange.Insert (_, widget) ->
                let struct (_, appLink) = Helpers.createViewForWidget node widget
                let page = appLink :?> AppLinkEntry
                appLinks.RegisterLink(page)
            | WidgetCollectionItemChange.Update _ -> ()
            | WidgetCollectionItemChange.Replace (_, _, newWidget) ->
                let struct (_, appLink) =
                    Helpers.createViewForWidget node newWidget

                let link = appLink :?> AppLinkEntry
                appLinks.DeregisterLink(link)
            | WidgetCollectionItemChange.Remove (_, newWidget) ->
                let struct (_, appLink) =
                    Helpers.createViewForWidget node newWidget

                let link = appLink :?> AppLinkEntry
                appLinks.DeregisterLink(link)

    let updateAppLinks
        (oldValueOpt: ArraySlice<Widget> voption)
        (newValueOpt: ArraySlice<Widget> voption)
        (node: IViewNode)
        =
        let application = node.Target :?> CustomApplication

        match newValueOpt with
        | ValueNone -> failwith "Application AppLinks requires its AppLinks modifier to be set"

        | ValueSome widgets ->
            let span = ArraySlice.toSpan widgets

            for widget in span do
                let struct (_, appLink) = Helpers.createViewForWidget node widget
                let link = appLink :?> AppLinkEntry

                if application.AppLinks <> null then
                    application.AppLinks.RegisterLink(link)

            match oldValueOpt with
            | ValueNone -> ()
            | ValueSome oldWidgets ->
                let appLinks = application.AppLinks
                let span = ArraySlice.toSpan oldWidgets

                for i = 0 to span.Length - 1 do
                    let linkArr = span.ToArray()
                    let widget = linkArr.[i]
                    let struct (_, appLink) = Helpers.createViewForWidget node widget
                    appLinks.DeregisterLink(appLink :?> AppLinkEntry)

type IApplication =
    inherit IElement

module Application =
    let WidgetKey = Widgets.register<CustomApplication>()

    let MainPage =
        Attributes.definePropertyWidget
            "Application_MainPage"
            (fun target -> (target :?> Application).MainPage :> obj)
            (fun target value -> (target :?> Application).MainPage <- value)

    let Resources =
        Attributes.defineSimpleScalarWithEquality<ResourceDictionary>
            "Application_Resources"
            (fun _ newValueOpt node ->
                let application = node.Target :?> CustomApplication

                let value =
                    match newValueOpt with
                    | ValueNone -> application.Resources
                    | ValueSome v -> v

                application.Resources <- value)

    let UserAppTheme =
        Attributes.defineEnum<OSAppTheme>
            "Application_UserAppTheme"
            (fun _ newValueOpt node ->
                let application = node.Target :?> CustomApplication

                let value =
                    match newValueOpt with
                    | ValueNone -> OSAppTheme.Unspecified
                    | ValueSome v -> v

                application.UserAppTheme <- value)

    let RequestedThemeChanged =
        Attributes.defineEvent<AppThemeChangedEventArgs>
            "Application_RequestedThemeChanged"
            (fun target ->
                (target :?> CustomApplication)
                    .RequestedThemeChanged)

    let ModalPopped =
        Attributes.defineEvent<ModalPoppedEventArgs>
            "Application_ModalPopped"
            (fun target -> (target :?> CustomApplication).ModalPopped)

    let ModalPopping =
        Attributes.defineEvent<ModalPoppingEventArgs>
            "Application_ModalPopping"
            (fun target -> (target :?> CustomApplication).ModalPopping)

    let ModalPushed =
        Attributes.defineEvent<ModalPushedEventArgs>
            "Application_ModalPushed"
            (fun target -> (target :?> CustomApplication).ModalPushed)

    let ModalPushing =
        Attributes.defineEvent<ModalPushingEventArgs>
            "Application_ModalPushing"
            (fun target -> (target :?> CustomApplication).ModalPushing)

    let LinkRequestReceived =
        Attributes.defineEvent<LinkRequestReceivedEventArgs>
            "Application_LinkRequestReceived"
            (fun target -> (target :?> CustomApplication).LinkRequestReceived)

    let AppLinks =
        Attributes.defineWidgetCollection
            "Application_AppLinks"
            AppLinkUpdaters.applyDiffApplicationLinks
            AppLinkUpdaters.updateAppLinks

    let Start =
        Attributes.defineEventNoArg "Application_Start" (fun target -> (target :?> CustomApplication).Start)

    let Sleep =
        Attributes.defineEventNoArg "Application_Sleep" (fun target -> (target :?> CustomApplication).Sleep)

    let Resume =
        Attributes.defineEventNoArg "Application_Resume" (fun target -> (target :?> CustomApplication).Resume)

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Application<'msg, 'marker when 'marker :> IPage>(mainPage: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IApplication>
                Application.WidgetKey
                [| Application.MainPage.WithValue(mainPage.Compile()) |]

[<Extension>]
type ApplicationModifiers =
    [<Extension>]
    static member inline userAppTheme(this: WidgetBuilder<'msg, #IApplication>, value: OSAppTheme) =
        this.AddScalar(Application.UserAppTheme.WithValue(value))

    [<Extension>]
    static member inline resources(this: WidgetBuilder<'msg, #IApplication>, value: ResourceDictionary) =
        this.AddScalar(Application.Resources.WithValue(value))

    [<Extension>]
    static member inline onRequestedThemeChanged
        (
            this: WidgetBuilder<'msg, #IApplication>,
            onRequestedThemeChanged: OSAppTheme -> 'msg
        ) =
        this.AddScalar(
            Application.RequestedThemeChanged.WithValue(fun args -> onRequestedThemeChanged args.RequestedTheme |> box)
        )

    [<Extension>]
    static member inline onModalPopped
        (
            this: WidgetBuilder<'msg, #IApplication>,
            onModalPopped: ModalPoppedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPopped.WithValue(onModalPopped >> box))

    [<Extension>]
    static member inline onModalPopping
        (
            this: WidgetBuilder<'msg, #IApplication>,
            onModalPopping: ModalPoppingEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPopping.WithValue(onModalPopping >> box))

    [<Extension>]
    static member inline onModalPushed
        (
            this: WidgetBuilder<'msg, #IApplication>,
            onModalPushed: ModalPushedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPushed.WithValue(onModalPushed >> box))

    [<Extension>]
    static member inline onModalPushing
        (
            this: WidgetBuilder<'msg, #IApplication>,
            onModalPushing: ModalPushingEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPushing.WithValue(onModalPushing >> box))

    /// Dispatch a message when the application starts
    [<Extension>]
    static member inline onStart(this: WidgetBuilder<'msg, #IApplication>, onStart: 'msg) =
        this.AddScalar(Application.Start.WithValue(onStart))

    /// Dispatch a message when the application is paused by the OS
    [<Extension>]
    static member inline onSleep(this: WidgetBuilder<'msg, #IApplication>, onSleep: 'msg) =
        this.AddScalar(Application.Sleep.WithValue(onSleep))

    /// Dispatch a message when the application is resumed by the OS
    [<Extension>]
    static member inline onResume(this: WidgetBuilder<'msg, #IApplication>, onResume: 'msg) =
        this.AddScalar(Application.Resume.WithValue(onResume))

    /// <summary>Link a ViewRef to access the direct Application instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IApplication>, value: ViewRef<CustomApplication>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    [<Extension>]
    static member inline onLinkReceived
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: LinkRequestReceivedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.LinkRequestReceived.WithValue(fn >> box))

    [<Extension>]
    static member inline appLinks<'msg, 'marker when 'marker :> IApplication>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.XamarinForms.IAppLinkEntry>
            Application.AppLinks
            this
