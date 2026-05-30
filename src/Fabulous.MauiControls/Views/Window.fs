namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.Maui

type IFabWindow =
    inherit IFabNavigableElement

module Window =
    let WidgetKey = Widgets.register<Window>()

    let Page = Attributes.defineBindableWidget Window.PageProperty

    let FlowDirection =
        Attributes.defineBindableWithEquality Window.FlowDirectionProperty

    let Height = Attributes.defineBindableWithEquality Window.HeightProperty

    let MaximumHeight =
        Attributes.defineBindableWithEquality Window.MaximumHeightProperty

    let MaximumWidth = Attributes.defineBindableWithEquality Window.MaximumWidthProperty

    let MinimumHeight =
        Attributes.defineBindableWithEquality Window.MinimumHeightProperty

    let MinimumWidth = Attributes.defineBindableWithEquality Window.MinimumWidthProperty

    let Activated =
        Attributes.Mvu.defineEventNoArg "Window_Activated" (fun target -> (target :?> Window).Activated)

    let Backgrounding =
        Attributes.Mvu.defineEvent "Window_Backgrounding" (fun target -> (target :?> Window).Backgrounding)

    let Created =
        Attributes.Mvu.defineEventNoArg "Window_Created" (fun target -> (target :?> Window).Created)

    let Deactivated =
        Attributes.Mvu.defineEventNoArg "Window_Deactivated" (fun target -> (target :?> Window).Deactivated)

    let Destroying =
        Attributes.Mvu.defineEventNoArg "Window_Destroying" (fun target -> (target :?> Window).Destroying)

    let DisplayDensityChanged =
        Attributes.Mvu.defineEvent "Window_DisplayDensityChanged" (fun target -> (target :?> Window).DisplayDensityChanged)

    let SizeChanged =
        Attributes.Mvu.defineEventNoArg "Window_SizeChanged" (fun target -> (target :?> Window).SizeChanged)

    let Resumed =
        Attributes.Mvu.defineEventNoArg "Window_Resumed" (fun target -> (target :?> Window).Resumed)

    let Stopped =
        Attributes.Mvu.defineEventNoArg "Window_Stopped" (fun target -> (target :?> Window).Stopped)

    let Title = Attributes.defineBindableWithEquality Window.TitleProperty

    let Width = Attributes.defineBindableWithEquality Window.WidthProperty

    let X = Attributes.defineBindableWithEquality Window.XProperty

    let Y = Attributes.defineBindableWithEquality Window.YProperty

[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Maui.View with

        static member inline Window(content: WidgetBuilder<'msg, #IFabPage>) =
            WidgetBuilder<'msg, IFabWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), [| Window.Page.WithValue(content.Compile()) |], [||], [||])
            )

[<Extension>]
type WindowModifiers =
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabWindow>, value: FlowDirection) =
        this.AddScalar(Window.FlowDirection.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Height.WithValue(value))

    [<Extension>]
    static member inline maximumHeight(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MaximumHeight.WithValue(value))

    [<Extension>]
    static member inline maximumWidth(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MaximumWidth.WithValue(value))

    [<Extension>]
    static member inline minimumHeight(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MinimumHeight.WithValue(value))

    [<Extension>]
    static member inline minimumWidth(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MinimumWidth.WithValue(value))

    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Activated.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onBackgrounding(this: WidgetBuilder<'msg, #IFabWindow>, fn: BackgroundingEventArgs -> 'msg) =
        this.AddScalar(Window.Backgrounding.WithValue(fn))

    [<Extension>]
    static member inline onCreated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Created.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Deactivated.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onDestroying(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Destroying.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onDisplayDensityChanged(this: WidgetBuilder<'msg, #IFabWindow>, fn: DisplayDensityChangedEventArgs -> 'msg) =
        this.AddScalar(Window.DisplayDensityChanged.WithValue(fn))

    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.SizeChanged.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onResumed(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Resumed.WithValue(MsgValue msg))

    [<Extension>]
    static member inline onStopped(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.Stopped.WithValue(MsgValue msg))

    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IFabWindow>, value: string) =
        this.AddScalar(Window.Title.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Width.WithValue(value))

    [<Extension>]
    static member inline x(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.X.WithValue(value))

    [<Extension>]
    static member inline y(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Y.WithValue(value))
