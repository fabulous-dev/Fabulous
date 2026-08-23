namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open AvaloniaUI.DiagnosticsSupport
open Fabulous
open Fabulous.Avalonia

module DeveloperTools =
    let AttachDeveloperTools =
        Attributes.defineProperty
            "Application_AttachDeveloperTools"
            (ValueNone, ValueNone)
            (fun _ (value: Action<DeveloperToolsOptions> voption * Input.KeyGesture voption) ->
                match Application.Current with
                | null -> ()
                | app ->
                    let configure, gesture = value

                    if configure.IsSome then
                        app.AttachDeveloperTools(configure.Value) |> ignore
                    else if gesture.IsSome then
                        app.AttachDeveloperTools(Action<DeveloperToolsOptions>(fun options -> options.Gesture <- gesture.Value))
                        |> ignore
                    else
                        app.AttachDeveloperTools(Action<DeveloperToolsOptions>(ignore)) |> ignore)

type DevToolsModifiers =
    /// <summary>Attaches the Avalonia Developer Tools with the specified options.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    /// <param name="configure">The Developer Tools options configuration.</param>
    [<Extension>]
    static member inline attachDeveloperTools(this: WidgetBuilder<'msg, #IFabWindow>, configure: Action<DeveloperToolsOptions>) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueSome configure, ValueNone)))

    /// <summary>Attaches the Avalonia Developer Tools with the specified options.</summary>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabWindow>, configure: Action<DeveloperToolsOptions>) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueSome configure, ValueNone)))

    /// <summary>Attaches the Avalonia Developer Tools with the specified gesture.</summary>
    [<Extension>]
    static member inline attachDeveloperTools(this: WidgetBuilder<'msg, #IFabWindow>, value: Input.KeyGesture) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueNone, ValueSome value)))

    /// <summary>Attaches the Avalonia Developer Tools with the specified gesture.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    /// <param name="value">The key gesture.</param>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabWindow>, value: Input.KeyGesture) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueNone, ValueSome value)))

    /// <summary>Attaches the Avalonia Developer Tools opened using F12.</summary>
    [<Extension>]
    static member inline attachDeveloperTools(this: WidgetBuilder<'msg, #IFabWindow>) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueNone, ValueNone)))

    /// <summary>Attaches the Avalonia Developer Tools opened using F12.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabWindow>) =
        this.AddScalar(DeveloperTools.AttachDeveloperTools.WithValue((ValueNone, ValueNone)))
