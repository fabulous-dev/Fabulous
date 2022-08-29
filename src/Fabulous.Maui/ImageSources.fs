namespace Fabulous.Maui

open System.IO
open System.Threading
open System.Threading.Tasks
open Microsoft.Maui

module ImageSources =
    [<Struct>]
    type FabulousFileImageSource(file: string) =
        interface IFileImageSource with
            member this.File = file
            member this.IsEmpty = false
            
    [<Struct>]
    type FabulousStreamImageSource(stream: Stream) =
        interface IStreamImageSource with
            member this.GetStreamAsync(cancellationToken: CancellationToken) = Task.FromResult(stream)
            member this.IsEmpty = false