namespace Fabulous.Avalonia

open Avalonia.Threading

[<RequireQualifiedAccess>]
module Async =
    /// Execute the async computation on the device main thread
    let executeOnMainThread (action: Async<'T>) : Async<'T> =
        async {
            return!
                Dispatcher.UIThread.InvokeAsync(action = fun () -> Async.StartImmediateAsTask action)
                |> Async.AwaitTask
        }
