namespace Gallery

open System
open System.Collections.Generic
open System.Diagnostics
open Avalonia.Controls.Notifications
open Avalonia.Input
open Avalonia.Input.Platform
open Avalonia.Platform.Storage
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ClipboardPage =
    type Model = { ClipboardContentText: string }

    type Msg =
        | CopyText
        | CopiedText
        | PasteText
        | PastedText of string
        | CopyTextDataObject
        | PasteTextDataObject
        | CopyFilesDataObject
        | PasteFilesDataObject
        | GetFormats
        | Clear
        | Cleared
        | ClipboardContentChanged of string

    let copyText (clipboardText: string) =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let text = if clipboardText = null then "" else clipboardText
            do! clipboard.SetTextAsync(text)
            return CopiedText
        }

    let pasteText () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! text = clipboard.TryGetTextAsync()
            return PastedText(if text = null then "" else text)
        }

    let copyTextDataObject (clipboardText: string) =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let dataTransfer = new DataTransfer()
            let text = if clipboardText = null then "" else clipboardText
            dataTransfer.Add(DataTransferItem.CreateText(text))
            do! clipboard.SetDataAsync(dataTransfer)
            return CopiedText
        }

    let pasteTextDataObject () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            use! dataTransfer = clipboard.TryGetDataAsync()

            if dataTransfer = null then
                return PastedText ""
            else
                let! text = dataTransfer.TryGetTextAsync()
                return PastedText(if text = null then "" else text)
        }

    let copyFilesDataObject (clipboardText: string) =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let storageProvider = FabApplication.Current.StorageProvider
            let notificationManager = FabApplication.Current.WindowNotificationManager

            let filesPath = if clipboardText = null then "" else clipboardText

            let filesPath =
                filesPath.Split([| Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)

            if filesPath.Length = 0 then
                return CopiedText
            else
                let invalidFile = List<string>(filesPath.Length)
                let files = List<IStorageFile>(filesPath.Length)

                for i in 0 .. filesPath.Length - 1 do
                    let! file = storageProvider.TryGetFileFromPathAsync(filesPath[i])

                    if file = null then
                        invalidFile.Add(filesPath[i])
                    else
                        files.Add(file)

                if invalidFile.Count > 0 then
                    notificationManager.Show(Notification("Warning", "There is one o more invalid path.", NotificationType.Warning))

                if files.Count > 0 then
                    let dataTransfer = new DataTransfer()

                    for file in files do
                        dataTransfer.Add(DataTransferItem.CreateFile(file))

                    do! clipboard.SetDataAsync(dataTransfer)
                    notificationManager.Show(Notification("Success", "Copy completed.", NotificationType.Success))
                    return CopiedText
                else
                    notificationManager.Show(Notification("Warning", "Any files to copy in Clipboard.", NotificationType.Warning))
                    return CopiedText
        }

    let pasteFilesDataObject () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! files = clipboard.TryGetFilesAsync()

            let text =
                if files = null then
                    ""
                else
                    files
                    |> Seq.map(fun f ->
                        let tryGetLocalPath = f.TryGetLocalPath()
                        if tryGetLocalPath = null then f.Name else tryGetLocalPath)
                    |> String.concat Environment.NewLine

            return PastedText text
        }

    let getFormats () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! formats = clipboard.GetDataFormatsAsync()

            let text =
                if formats = null then
                    ""
                else
                    String.Join(Environment.NewLine, formats)

            return PastedText text
        }

    let clear () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            do! clipboard.ClearAsync()
            return Cleared
        }

    let init () = { ClipboardContentText = "" }, Cmd.none

    let update msg model =
        match msg with
        | CopyText -> model, Cmd.OfTask.msg(copyText(model.ClipboardContentText))
        | CopiedText -> model, Cmd.none
        | PasteText -> model, Cmd.OfTask.msg(pasteText())
        | PastedText s -> { ClipboardContentText = s }, Cmd.none
        | CopyTextDataObject -> model, Cmd.OfTask.msg(copyTextDataObject(model.ClipboardContentText))
        | PasteTextDataObject -> model, Cmd.OfTask.msg(pasteTextDataObject())
        | CopyFilesDataObject -> model, Cmd.OfTask.msg(copyFilesDataObject(model.ClipboardContentText))
        | PasteFilesDataObject -> model, Cmd.OfTask.msg(pasteFilesDataObject())
        | GetFormats -> model, Cmd.OfTask.msg(getFormats())
        | Clear -> model, Cmd.OfTask.msg(clear())
        | ClipboardContentChanged text -> { ClipboardContentText = text }, Cmd.none
        | Cleared -> model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("ClipboardPage") {
            let! model = Context.Mvu program

            VStack(spacing = 4.) {
                TextBlock("Example of ClipboardPage capabilities")

                Button("Copy text to clipboard", CopyText)

                Button("Paste text from clipboard", PasteText)

                Button("Copy text to clipboard (data object)", CopyTextDataObject)

                Button("Paste text from clipboard (data object)", PasteTextDataObject)

                Button("Copy files to clipboard (data object)", CopyFilesDataObject)

                Button("Paste files from clipboard (data object)", PasteFilesDataObject)

                Button("Get clipboard formats", GetFormats)

                Button("Clear clipboard", Clear)

                TextBox(model.ClipboardContentText, ClipboardContentChanged)
                    .placeholderText("Text to copy of file names per line")
                    .minHeight(100.)
                    .acceptsReturn(true)
            }
        }
