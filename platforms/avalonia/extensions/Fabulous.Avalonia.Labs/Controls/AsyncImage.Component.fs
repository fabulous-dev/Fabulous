namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Interactivity
open Avalonia.Labs.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentAsyncImage =

    let Opened =
        Attributes.Component.defineEvent "AsyncImage_Opened" (fun target -> (target :?> AsyncImage).Opened)

    let Failed =
        Attributes.Component.defineEvent "AsyncImage_Failed" (fun target -> (target :?> AsyncImage).Failed)

type ComponentAsyncImageModifiers =
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentAsyncImage.Opened.WithValue(value))

    [<Extension>]
    static member inline onFailed(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: AsyncImage.AsyncImageFailedEventArgs -> unit) =
        this.AddScalar(ComponentAsyncImage.Failed.WithValue(value))
