namespace FabulousContacts

open System.IO
open Fabulous
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Media
open Microsoft.Maui.Storage
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

    let requestPermissionAsync<'a when 'a: (new: unit -> 'a) and 'a :> Permissions.BasePermission> () =
        async {
            try
                let! status = Permissions.RequestAsync<'a>() |> Async.AwaitTask

                return
                    status = PermissionStatus.Granted
                    || status = PermissionStatus.Unknown
            with
            | _ -> return false
        }

    let askPermissionAsync<'a when 'a: (new: unit -> 'a) and 'a :> Permissions.BasePermission> () =
        async {
            try
                let! status =
                    Permissions.CheckStatusAsync<'a>()
                    |> Async.AwaitTask

                if status = PermissionStatus.Granted then
                    return true
                else
                    return! requestPermissionAsync<'a>()
            with
            | _ -> return false
        }

    let takePictureAsync () =
        async {
            let! picture = MediaPicker.CapturePhotoAsync() |> Async.AwaitTask

            return picture |> Option.ofObj
        }

    let pickPictureAsync () =
        async {
            let! picture = MediaPicker.PickPhotoAsync() |> Async.AwaitTask

            return picture |> Option.ofObj
        }

    let readBytesAsync (file: FileResult) =
        async {
            use! stream = file.OpenReadAsync() |> Async.AwaitTask
            use memoryStream = new MemoryStream()

            do!
                stream.CopyToAsync(memoryStream)
                |> Async.AwaitTask

            return memoryStream.ToArray()
        }

    let getImageValueOrDefault (defaultValue: string) aspect (value: byte [] option) =
        match value with
        | None -> Image(aspect, defaultValue)
        | Some bytes -> Image(aspect, new MemoryStream(bytes))

module Cmd =
    let performAsync asyncUnit =
        Cmd.ofMsgOption(
            Async.Start asyncUnit
            None
        )
