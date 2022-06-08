namespace Fabulous.XamarinForms

open Xamarin.Forms

module Async =
    /// Execute the async computation on the device main thread
    let executeOnMainThread (action: Async<'T>) : Async<'T> =
        async {
            return!
                Device.InvokeOnMainThreadAsync(funcTask = fun () -> Async.StartImmediateAsTask action)
                |> Async.AwaitTask
        }
