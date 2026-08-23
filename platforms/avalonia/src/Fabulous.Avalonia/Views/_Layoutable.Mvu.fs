namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Layout
open Fabulous

module MvuLayoutable =
    let EffectiveViewportChanged =
        Attributes.Mvu.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        Attributes.Mvu.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

type MvuLayoutableModifiers =
    /// <summary>Listens to the Layoutable EffectiveViewportChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's effective viewport changes.</param>
    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<'msg, #IFabLayoutable>, fn: EffectiveViewportChangedEventArgs -> 'msg) =
        this.AddScalar(MvuLayoutable.EffectiveViewportChanged.WithValue(fn))

    /// <summary>Listens to the Layoutable LayoutUpdated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's layout is updated.</param>
    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<'msg, #IFabLayoutable>, fn: 'msg) =
        this.AddScalar(MvuLayoutable.LayoutUpdated.WithValue(MsgValue fn))
