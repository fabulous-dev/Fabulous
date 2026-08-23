namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

module DragDrop =
    let AllowDrop =
        Attributes.defineAvaloniaPropertyWithEquality DragDrop.AllowDropProperty

type DragDropModifiers =
    /// <summary>Sets the AllowDrop property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowDrop value.</param>
    [<Extension>]
    static member inline allowDrop(this: WidgetBuilder<'msg, #IFabInteractive>, value: bool) =
        this.AddScalar(DragDrop.AllowDrop.WithValue(value))
