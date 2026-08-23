namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls

type IFabContentPage =
    inherit IFabPage

type SizeAllocatedEventArgs = { Width: float; Height: float }

/// Set UseSafeArea to true by default because View DSL only shows `ignoreSafeArea`
type FabContentPage() as this =
    inherit ContentPage()
    do Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true)

    let sizeAllocated = Event<EventHandler<SizeAllocatedEventArgs>, _>()

    [<CLIEvent>]
    member _.SizeAllocated = sizeAllocated.Publish

    override this.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(this, { Width = width; Height = height })

module ContentPage =
    let WidgetKey = Widgets.register<FabContentPage>()

    let Content = Attributes.defineBindableWidget ContentPage.ContentProperty

    let SizeAllocated =
        Attributes.Mvu.defineEvent<SizeAllocatedEventArgs> "ContentPage_SizeAllocated" (fun target -> (target :?> FabContentPage).SizeAllocated)

[<AutoOpen>]
module ContentPageBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ContentPage with a content widget</summary>
        /// <param name="content">The content widget</param>
        static member inline ContentPage<'msg, 'marker when 'msg: equality and 'marker :> IFabView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IFabContentPage>(
                ContentPage.WidgetKey,
                AttributesBundle(StackList.empty(), [| ContentPage.Content.WithValue(content.Compile()) |], [||], [||])
            )

[<Extension>]
type ContentPageModifiers =
    /// <summary>Listen for SizeAllocated event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onSizeAllocated(this: WidgetBuilder<'msg, #IFabContentPage>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalar(ContentPage.SizeAllocated.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct ContentPage control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabContentPage>, value: ViewRef<ContentPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
