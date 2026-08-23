namespace Gallery

open System.Collections.Generic
open System.ComponentModel
open System.Collections.ObjectModel
open System.IO
open System
open Avalonia.Data.Converters
open Avalonia.Media.Imaging
open Avalonia.Platform
open Avalonia.Threading

type IconConverter(file: Bitmap, folderExpanded: Bitmap, folderCollapsed: Bitmap) =
    interface IMultiValueConverter with
        member this.Convert(values: IList<obj>, targetType: Type, _, _) =
            let isDirectory =
                match values.[0] with
                | :? bool as b -> b
                | _ -> false

            let isExpanded =
                match values.[1] with
                | :? bool as b -> b
                | _ -> false

            if (values.Count = 2 && isDirectory && isExpanded) then
                if (not isDirectory) then file
                else if isExpanded then folderExpanded
                else folderCollapsed
            else
                null

type FileTreeNodeModel(path, isDirectory, ?isRoot) =
    let mutable _path = ""
    let mutable _name = ""
    let mutable _size = 0L
    let mutable _modified = DateTimeOffset.MinValue
    let mutable _hasChildren = true
    let mutable _isExpanded = false
    let mutable _isChecked = false
    let mutable _isDirectory = false
    let mutable _watcher = null

    static let mutable _iconConverter: IconConverter = Unchecked.defaultof<_>
    let mutable _undoName = ""

    let _children: ObservableCollection<FileTreeNodeModel> option = None

    do
        let isRoot = defaultArg isRoot false
        _path <- path
        _name <- if isRoot then path else Path.GetFileName(path)
        _isExpanded <- isRoot
        _isDirectory <- isDirectory
        _hasChildren <- isDirectory

        if (not isDirectory) then
            let info = FileInfo(path)
            _size <- info.Length
            _modified <- DateTimeOffset.op_Implicit(info.LastWriteTimeUtc)

    static member FileIconConverter
        with get () =
            if (_iconConverter = Unchecked.defaultof<_>) then
                use fileStream = AssetLoader.Open(Uri("avares://Gallery/Assets/file.png"))
                use folderStream = AssetLoader.Open(Uri("avares://Gallery/Assets/folder.png"))

                using (AssetLoader.Open(Uri("avares://Gallery/Assets/folder-open.png"))) (fun folderOpenStream ->
                    let fileIcon = new Bitmap(fileStream)
                    let folderIcon = new Bitmap(folderStream)
                    let folderOpenIcon = new Bitmap(folderOpenStream)

                    _iconConverter <- IconConverter(fileIcon, folderOpenIcon, folderIcon))

            _iconConverter
        and set v = _iconConverter <- v

    member this.Path
        with get () = _path
        and private set value = _path <- value

    member this.Name
        with get () = _name
        and private set value = _name <- value

    member this.Size
        with get () = _size
        and private set value = _size <- value

    member this.Modified
        with get () = _modified
        and private set value = _modified <- value

    member this.HasChildren
        with get () = _hasChildren
        and private set value = _hasChildren <- value

    member this.IsExpanded
        with get () = _isExpanded
        and set value = _isExpanded <- value

    member this.IsChecked
        with get () = _isChecked
        and set value = _isChecked <- value

    member this.IsDirectory = isDirectory

    member this.Children =
        if _children.IsNone then
            this.LoadChildren()
        else
            _children.Value

    member this.OnChanged(e: FileSystemEventArgs) =
        if e.ChangeType = WatcherChangeTypes.Changed && File.Exists(e.FullPath) then
            Dispatcher.UIThread.Post(fun _ ->
                for child in this.Children do
                    if child.Path = e.FullPath then
                        if not child.IsDirectory then
                            let info = FileInfo(e.FullPath)
                            child.Size <- info.Length
                            child.Modified <- DateTimeOffset.op_Implicit(info.LastWriteTimeUtc))

    member this.OnCreated(e: FileSystemEventArgs) =
        Dispatcher.UIThread.Post(fun _ ->
            let node =
                FileTreeNodeModel(
                    e.FullPath,
                    File
                        .GetAttributes(e.FullPath)
                        .HasFlag(FileAttributes.Directory)
                )

            this.Children.Add(node))

    member this.OnDeleted(e: FileSystemEventArgs) =
        Dispatcher.UIThread.Post(fun _ ->
            for i in 0 .. this.Children.Count - 1 do
                if this.Children[i].Path = e.FullPath then
                    this.Children.RemoveAt(i))

    member this.OnRenamed(e: RenamedEventArgs) =
        Dispatcher.UIThread.Post(fun _ ->
            for child in this.Children do
                if child.Path = e.OldFullPath then
                    child.Path <- e.FullPath
                    child.Name <- e.Name)

    member this.LoadChildren() =
        if not isDirectory then
            failwith "Not supported"
        else
            let options = EnumerationOptions(IgnoreInaccessible = true)
            let result = ObservableCollection<FileTreeNodeModel>()

            for d in Directory.EnumerateDirectories(path, "*", options) do
                result.Add(FileTreeNodeModel(d, true))

            for f in Directory.EnumerateFiles(path, "*", options) do
                result.Add(FileTreeNodeModel(f, false))

            _watcher <- new FileSystemWatcher(Path = this.Path, NotifyFilter = (NotifyFilters.FileName ||| NotifyFilters.Size ||| NotifyFilters.LastWrite))
            _watcher.Changed.Add(this.OnChanged)
            _watcher.Created.Add(this.OnCreated)
            _watcher.Deleted.Add(this.OnDeleted)
            _watcher.Renamed.Add(this.OnRenamed)

            if (result.Count = 0) then
                this.HasChildren <- false

            result

    interface IEditableObject with
        member this.BeginEdit() = _undoName <- _name
        member this.CancelEdit() = _name <- _undoName
        member this.EndEdit() = _undoName <- null

    static member SortAscending(selector: Func<FileTreeNodeModel, 'T>) =
        fun (x: FileTreeNodeModel) (y: FileTreeNodeModel) ->
            if (x = Unchecked.defaultof<_> && y = Unchecked.defaultof<_>) then
                0
            elif (x = Unchecked.defaultof<_>) then
                -1
            elif (y = Unchecked.defaultof<_>) then
                1
            elif (x.IsDirectory = y.IsDirectory) then
                Comparer<'T>.Default
                    .Compare(selector.Invoke x, selector.Invoke y)
            elif x.IsDirectory then
                -1
            else
                1

    static member SortDescending(selector: Func<FileTreeNodeModel, 'T>) =
        fun (x: FileTreeNodeModel) (y: FileTreeNodeModel) ->
            if (x = Unchecked.defaultof<_> && y = Unchecked.defaultof<_>) then
                0
            elif (x = Unchecked.defaultof<_>) then
                1
            elif (y = Unchecked.defaultof<_>) then
                -1
            elif (x.IsDirectory = y.IsDirectory) then
                Comparer<'T>.Default
                    .Compare(selector.Invoke y, selector.Invoke x)
            elif x.IsDirectory then
                -1
            else
                1
