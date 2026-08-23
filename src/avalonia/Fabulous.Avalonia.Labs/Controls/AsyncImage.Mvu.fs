namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Interactivity
open Avalonia.Labs.Controls
open Fabulous
open Fabulous.Avalonia

module MvuAsyncImage =

    let Opened =
        Attributes.Mvu.defineEvent "AsyncImage_Opened" (fun target -> (target :?> AsyncImage).Opened)

    let Failed =
        Attributes.Mvu.defineEvent "AsyncImage_Failed" (fun target -> (target :?> AsyncImage).Failed)

type MvuAsyncImageModifiers =
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuAsyncImage.Opened.WithValue(value))

    [<Extension>]
    static member inline onFailed(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: AsyncImage.AsyncImageFailedEventArgs -> 'msg) =
        this.AddScalar(MvuAsyncImage.Failed.WithValue(value))
