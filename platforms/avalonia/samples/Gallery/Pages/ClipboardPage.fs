namespace Gallery

open System
open System.Collections.Generic
open System.Diagnostics
open Avalonia.Controls.Notifications
open Avalonia.Input
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
            let! text = clipboard.GetTextAsync()
            return PastedText text
        }

    let copyTextDataObject (clipboardText: string) =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let dataObject = DataObject()
            let text = if clipboardText = null then "" else clipboardText
            dataObject.Set(DataFormats.Text, text)
            do! clipboard.SetDataObjectAsync(dataObject)
            return CopiedText
        }

    let pasteTextDataObject () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! dataObject = clipboard.GetDataAsync(DataFormats.Text)
            let res = (dataObject :?> string)
            let text = if res = null then "" else res
            return PastedText text
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
                    let dataObject = DataObject()
                    dataObject.Set(DataFormats.Files, files)
                    do! clipboard.SetDataObjectAsync(dataObject)
                    notificationManager.Show(Notification("Success", "Copy completed.", NotificationType.Success))
                    return CopiedText
                else
                    notificationManager.Show(Notification("Warning", "Any files to copy in Clipboard.", NotificationType.Warning))
                    return CopiedText
        }

    let pasteFilesDataObject () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! files = clipboard.GetDataAsync(DataFormats.Files)
            let files = (files :?> IEnumerable<IStorageItem>)

            let files =
                files
                |> Seq.map(fun f ->
                    let tryGetLocalPath = f.TryGetLocalPath()
                    if tryGetLocalPath = null then f.Name else tryGetLocalPath)

            let text =
                if files = null then
                    ""
                else
                    files |> Seq.reduce(fun acc f -> acc + Environment.NewLine + f)

            return PastedText text
        }

    let getFormats () =
        task {
            let clipboard = FabApplication.Current.Clipboard
            let! formats = clipboard.GetFormatsAsync()

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
        | CopyTextDataObject -> model, Cmd.OfTask.msg(pasteTextDataObject())
        | PasteTextDataObject -> model, Cmd.OfTask.msg(pasteFilesDataObject())
        | CopyFilesDataObject -> model, Cmd.none
        | PasteFilesDataObject -> model, Cmd.none
        | GetFormats -> model, Cmd.none
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
                    .watermark("Text to copy of file names per line")
                    .minHeight(100.)
                    .acceptsReturn(true)
            }
        }
