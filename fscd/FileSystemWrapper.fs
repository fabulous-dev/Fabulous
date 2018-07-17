module FSharp.FSW

open System
open System.IO

type FileSystemWrapper =
    //member this.watcher = new FileSystemWatcher(path, filter)
    val watcher : FileSystemWatcher
    val mutable changeHandlers : (FileSystemEventArgs -> unit) list
    val mutable deleteHandlers : (FileSystemEventArgs -> unit) list
    val mutable renameHandlers : (RenamedEventArgs -> unit) list
    val mutable createHandlers : (FileSystemEventArgs -> unit) list
    val mutable errorHandlers : (ErrorEventArgs -> unit) list

    member private this.OnFileChanged (fse:FileSystemEventArgs) =
        List.iter (fun x -> x fse) this.changeHandlers

    member private this.OnFileDeleted(fse:FileSystemEventArgs) =
        if (File.Exists fse.FullPath |> not) then 
            List.iter (fun f -> f fse) this.deleteHandlers 

    member private this.OnFileRenamed(re:RenamedEventArgs) =
        this.OnFileChanged re

        if (File.Exists re.OldFullPath) then 
            FileSystemEventArgs(WatcherChangeTypes.Changed, Path.GetDirectoryName re.OldFullPath, Path.GetFileName re.OldFullPath)
            |> this.OnFileChanged
        else
            FileSystemEventArgs(WatcherChangeTypes.Deleted, Path.GetDirectoryName re.OldFullPath, Path.GetFileName re.OldFullPath)
            |> this.OnFileDeleted

    member private this.OnFileCreated(fse:FileSystemEventArgs) =
        List.iter (fun f -> f fse) this.createHandlers

    member private this.OnFileWatcherError(ee:ErrorEventArgs) =
        List.iter (fun f -> f ee) this.errorHandlers

    new(path, filter) as this = 
        {
            watcher = new FileSystemWatcher(path, filter)
            changeHandlers = []
            deleteHandlers = []
            renameHandlers = []
            createHandlers = []
            errorHandlers = []
        }
        then
            this.watcher.Changed.Add this.OnFileChanged
            this.watcher.Deleted.Add this.OnFileDeleted
            this.watcher.Renamed.Add this.OnFileRenamed
            this.watcher.Created.Add this.OnFileCreated
            this.watcher.Error.Add this.OnFileWatcherError
    
    member this.AddChangedHandler(handler) =
        this.changeHandlers <- handler :: this.changeHandlers
        
    member this.AddDeletedHandler(handler) = 
        this.deleteHandlers <- handler :: this.deleteHandlers

    member this.AddRenamedHandler(handler) = 
        this.renameHandlers <- handler :: this.renameHandlers

    member this.AddCreatedHandler(handler) = 
        this.createHandlers <- handler :: this.createHandlers

    member this.AddErrorHandler(handler) = 
        this.errorHandlers <- handler :: this.errorHandlers

    member this.EnableRaisingEvents() = this.watcher.EnableRaisingEvents
    member this.EnableRaisingEvents ere = this.watcher.EnableRaisingEvents <- ere

    member this.NotifyFilter() = this.watcher.NotifyFilter
    member this.NotifyFilter nf = this.watcher.NotifyFilter <- nf

    interface IDisposable with
        member this.Dispose() = this.watcher.Dispose()
    end



