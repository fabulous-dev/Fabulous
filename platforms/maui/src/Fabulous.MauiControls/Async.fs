namespace Fabulous.Maui

open Microsoft.Maui.ApplicationModel

module Async =
    /// Execute the async computation on the device main thread
    let executeOnMainThread (action: Async<'T>) : Async<'T> =
        async {
            return!
                MainThread.InvokeOnMainThreadAsync(funcTask = fun () -> Async.StartImmediateAsTask action)
                |> Async.AwaitTask
        }
