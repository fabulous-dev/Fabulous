namespace FabulousContacts

open System.IO
open Fabulous
// open Plugin.Media
// open Plugin.Media.Abstractions
// open Plugin.Permissions
// open Plugin.Permissions.Abstractions
open Microsoft.Maui
open Fabulous.Maui

open type Fabulous.Maui.View

module Helpers =
    let displayAlert (title, message, cancel) =
        // Application.Current.MainPage.DisplayAlert(title, message, cancel)
        // |> Async.AwaitTask
        async { return () }

    let displayAlertWithConfirm (title, message, accept, cancel) =
        // Application.Current.MainPage.DisplayAlert(title = title, message = message, accept = accept, cancel = cancel)
        // |> Async.AwaitTask
        async { return () }

    let displayActionSheet (title, cancel, destruction, buttons) =
        let title = Option.toObj title
        let cancel = Option.toObj cancel
        let destruction = Option.toObj destruction
        let buttons = Option.toObj buttons

        // Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons)
        // |> Async.AwaitTask
        async { return () }

    let requestPermissionAsync<'a when 'a: (new: unit -> 'a) (*and 'a :> BasePermission*)> () =
        async {
            // try
            //     let! status =
            //         CrossPermissions.Current.RequestPermissionAsync<'a>()
            //         |> Async.AwaitTask
            //
            //     return
            //         status = PermissionStatus.Granted
            //         || status = PermissionStatus.Unknown
            // with
            // | _ -> return false
            return false
        }

    let askPermissionAsync<'a when 'a: (new: unit -> 'a) (*and 'a :> BasePermission*)> () =
        async {
            // try
            //     let! status =
            //         CrossPermissions.Current.CheckPermissionStatusAsync<'a>()
            //         |> Async.AwaitTask
            //
            //     if status = PermissionStatus.Granted then
            //         return true
            //     else
            //         return! requestPermissionAsync<'a>()
            // with
            // | _ -> return false
            return false
        }

    let takePictureAsync () =
        async {
            // let options =
            //     StoreCameraMediaOptions(PhotoSize = PhotoSize.Small)
            //
            // let! picture =
            //     CrossMedia.Current.TakePhotoAsync(options)
            //     |> Async.AwaitTask
            //
            // return picture |> Option.ofObj
            return None
        }

    let pickPictureAsync () =
        async {
            // let options =
            //     PickMediaOptions(PhotoSize = PhotoSize.Small)
            //
            // let! picture =
            //     CrossMedia.Current.PickPhotoAsync(options)
            //     |> Async.AwaitTask
            //
            // return picture |> Option.ofObj
            return None
        }

    let readBytesAsync (file: obj (*MediaFile*)) =
        async {
            // use stream = file.GetStream()
            // use memoryStream = new MemoryStream()
            //
            // do!
            //     stream.CopyToAsync(memoryStream)
            //     |> Async.AwaitTask
            //
            // return memoryStream.ToArray()
            return [| 0uy |]
        }

    let getImageValueOrDefault (defaultValue: string) aspect (value: byte [] option) =
        match value with
        | None -> Image(aspect, defaultValue)
        | Some bytes -> Image(aspect, defaultValue (*new MemoryStream(bytes)*))

module Cmd =
    let performAsync asyncUnit =
        Cmd.ofMsgOption(
            Async.Start asyncUnit
            None
        )