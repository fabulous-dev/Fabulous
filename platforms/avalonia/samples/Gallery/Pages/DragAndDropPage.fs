namespace Gallery

open System
open System.Buffers
open System.Diagnostics
open System.Reflection
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Platform.Storage
open Fabulous.Avalonia
open Avalonia.Controls
open Fabulous
open Avalonia.Threading

open type Fabulous.Avalonia.View

module Validation =
    type System.Collections.Generic.IAsyncEnumerable<'T> with

        member this.AsTask() =
            task {
                let mutable nxt = true
                let output = ResizeArray()
                let enumerator = this.GetAsyncEnumerator()

                while nxt do
                    let! next = enumerator.MoveNextAsync()
                    nxt <- next

                    if nxt then
                        output.Add enumerator.Current

                return output.ToArray()
            }

    let ReadTextFromFile (file: IStorageFile, length: int) =
        task {
            use! stream = file.OpenReadAsync()

            use reader = new System.IO.StreamReader(stream)

            // 4GB file test, shouldn't load more than 10000 chars into a memory.
            let buffer = ArrayPool<char>.Shared.Rent(length)

            try
                let! charsRead = reader.ReadAsync(buffer, 0, length)
                return new string(buffer, 0, charsRead)
            finally
                ArrayPool<char>.Shared.Return(buffer)
        }

    let getFiles () =
        async {
            let storageProvider = FabApplication.Current.StorageProvider

            let modules =
                Assembly.GetEntryAssembly().GetModules()
                |> Seq.tryHead
                |> Option.map(fun m -> m.FullyQualifiedName)
                |> Option.defaultValue ""

            let! res = storageProvider.TryGetFileFromPathAsync(modules) |> Async.AwaitTask
            return res
        }

open Validation

module DragAndDropPage =
    type Model =
        { DragStateTex: string
          DragStateFilesText: string
          DragStateCustomText: string
          DraggedCount: int
          DropStateText: string }

    type BorderPointerPressed =
        | First
        | Second
        | Third

    type Msg =
        | OnPointPressed1 of PointerPressedEventArgs
        | OnPointPressed2 of PointerPressedEventArgs
        | OnPointPressed3 of PointerPressedEventArgs
        | Dragged1 of string
        | Dragged2 of string
        | Dragged3 of string
        | Dropped of string
        | DraggedOver of DragEventArgs
        | Drop of DragEventArgs

    let customFormat = "application/xxx-avalonia-galleryapp-custom"

    let doDrop (e: DragEventArgs) =
        async {
            let source = e.Source :?> Control

            if (source <> null && source.Name = "MoveTarget") then
                e.DragEffects <- e.DragEffects &&& DragDropEffects.Move
            else
                e.DragEffects <- e.DragEffects &&& DragDropEffects.Copy

            if e.Data.Contains(DataFormats.Text) then
                return Dropped(e.Data.GetText())

            elif e.Data.Contains(DataFormats.Files) then
                let files = e.Data.GetFiles()

                let files =
                    if files = null then
                        Array.empty<IStorageItem>
                    else
                        files |> Seq.toArray

                let mutable contentStr = ""

                for item in files do
                    match item with
                    | :? IStorageFile as file ->
                        let! content = ReadTextFromFile(file, 500) |> Async.AwaitTask

                        contentStr <-
                            contentStr
                            + $"File {item.Name}:{Environment.NewLine}{content}{Environment.NewLine}{Environment.NewLine}"


                    | :? IStorageFolder as folder ->
                        let mutable childrenCount = 0
                        let! items = folder.GetItemsAsync().AsTask() |> Async.AwaitTask

                        for _ in items do
                            childrenCount <- childrenCount + 1

                        contentStr <-
                            contentStr
                            + $"Folder {item.Name}: items {childrenCount}{Environment.NewLine}{Environment.NewLine}"

                    | _ -> failwithf $"Unknown item type: {item.GetType()}"

                return Dropped(contentStr)

            elif e.Data.Contains(customFormat) then
                let res = "Custom: " + $"{e.Data.Get(customFormat)}"
                return Dropped(res)
            else
                return Dropped("Unknown data")
        }

    let doDrag args effects (factory: Action<DataObject>) borderDragged =
        async {
            let dragData = DataObject()
            factory.Invoke(dragData)

            let! result =
                Dispatcher.UIThread.InvokeAsync<DragDropEffects>(fun _ -> DragDrop.DoDragDrop(args, dragData, effects))
                |> Async.AwaitTask

            let res =
                match result with
                | DragDropEffects.Move -> "The text was moved"
                | DragDropEffects.Copy -> "The text was copied"
                | DragDropEffects.Link -> "The text was linked"
                | DragDropEffects.None -> "The drag operation was canceled"
                | _ -> "Unknown result"

            return
                match borderDragged with
                | First -> Dragged1(res)
                | Second -> Dragged2(res)
                | Third -> Dragged3(res)
        }

    let DragOver (e: DragEventArgs) =
        let source = e.Source :?> Control

        if (source <> null && source.Name = "MoveTarget") then
            e.DragEffects <- e.DragEffects &&& DragDropEffects.Move
        else
            e.DragEffects <- e.DragEffects &&& DragDropEffects.Copy

        // Only allow if the dragged data contains text or filenames.
        if
            (not(e.Data.Contains(DataFormats.Text))
             && not(e.Data.Contains(DataFormats.Files))
             && not(e.Data.Contains(customFormat)))
        then
            e.DragEffects <- DragDropEffects.None

    let init () =
        { DragStateTex = "Drag Me (text)"
          DragStateFilesText = "Drag Me (files)"
          DragStateCustomText = "Drag Me (custom)"
          DropStateText = ""
          DraggedCount = 0 },
        Cmd.none

    let update msg model =
        match msg with
        | OnPointPressed1 args ->
            args.Handled <- true
            let effects = DragDropEffects.Copy ||| DragDropEffects.Move ||| DragDropEffects.Link

            let factory =
                System.Action<DataObject>(fun d -> d.Set(DataFormats.Text, $"Text was dragged {model.DraggedCount} times"))

            model, Cmd.OfAsync.msg(doDrag args effects factory BorderPointerPressed.First)

        | OnPointPressed2 args ->
            args.Handled <- true
            let effects = DragDropEffects.Move
            let factory = System.Action<DataObject>(fun d -> d.Set(customFormat, "Test123"))
            model, Cmd.OfAsync.msg(doDrag args effects factory BorderPointerPressed.Second)

        | OnPointPressed3 args ->
            args.Handled <- true
            let effects = DragDropEffects.Copy
            let files = getFiles() |> Async.RunSynchronously

            let factory = System.Action<DataObject>(_.Set(DataFormats.Files, value = files))

            model, Cmd.OfAsync.msg(doDrag args effects factory BorderPointerPressed.Third)

        | Dragged1 s ->
            let dragCount = model.DraggedCount + 1

            { model with
                DragStateTex = s
                DraggedCount = dragCount },
            Cmd.none
        | Dragged2 s ->
            let dragCount = model.DraggedCount + 1

            { model with
                DragStateFilesText = s
                DraggedCount = dragCount },
            Cmd.none
        | Dragged3 s ->
            let dragCount = model.DraggedCount + 1

            { model with
                DragStateCustomText = s
                DraggedCount = dragCount },
            Cmd.none

        | Dropped s -> { model with DropStateText = s }, Cmd.none
        | Drop args ->
            args.Handled <- true
            model, Cmd.OfAsync.msg(doDrop args)

        | DraggedOver args ->
            DragOver args
            model, Cmd.none

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
        Component("DragAndDropPage") {
            let! model = Context.Mvu program

            VStack(4.) {
                TextBlock("Example of Drag+Drop capabilities")

                (VWrap() {
                    (VStack() {
                        Border(
                            TextBlock(model.DragStateTex)
                                .textWrapping(TextWrapping.Wrap)
                        )
                            .padding(16.)
                            .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                            .borderThickness(2.)
                            .onPointerPressed(OnPointPressed1)

                        Border(
                            TextBlock(model.DragStateFilesText)
                                .textWrapping(TextWrapping.Wrap)
                        )
                            .padding(16.)
                            .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                            .borderThickness(2.)
                            .onPointerPressed(OnPointPressed2)

                        Border(
                            TextBlock(model.DragStateCustomText)
                                .textWrapping(TextWrapping.Wrap)
                        )
                            .padding(16.)
                            .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                            .borderThickness(2.)
                            .onPointerPressed(OnPointPressed3)
                    })
                        .horizontalAlignment(HorizontalAlignment.Center)

                    (HStack(8.) {
                        Border(
                            TextBlock("Drop some text or files here (Copy)")
                                .textWrapping(TextWrapping.Wrap)
                                .allowDrop(true)
                                .onDrop(Drop)
                                .onDragOver(DraggedOver)
                        )
                            .name("CopyTarget")
                            .padding(16.)
                            .maxWidth(260.)
                            .background(SolidColorBrush(Color.Parse("#aaa")))

                        Border(
                            TextBlock("Drop some text or files here (Move)")
                                .textWrapping(TextWrapping.Wrap)
                        )
                            .name("MoveTarget")
                            .allowDrop(true)
                            .onDrop(Drop)
                            .onDragOver(DraggedOver)
                            .padding(16.)
                            .maxWidth(260.)
                            .background(SolidColorBrush(Color.Parse("#aaa")))
                    })
                        .horizontalAlignment(HorizontalAlignment.Center)
                })
                    .margin(8.)
                    .maxWidth(160.)

                TextBlock(model.DropStateText)
                    .textWrapping(TextWrapping.Wrap)

            }
        }
