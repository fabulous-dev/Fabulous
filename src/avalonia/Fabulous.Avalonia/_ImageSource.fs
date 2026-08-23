namespace Fabulous.Avalonia

open System
open System.IO
open Avalonia.Media.Imaging
open Avalonia.Platform

module ImageSource =
    let fromString (source: string) =
        let uri =
            if source.StartsWith("/") then
                Uri(source, UriKind.Relative)
            else
                Uri(source, UriKind.RelativeOrAbsolute)

        if uri.IsAbsoluteUri && uri.IsFile then
            new Bitmap(uri.LocalPath)
        else
            new Bitmap(AssetLoader.Open(uri))

    let fromUri (source: Uri) =
        let uri =
            if source.IsAbsoluteUri && source.IsFile then
                Uri(source.LocalPath, UriKind.Relative)
            else
                source

        if uri.IsAbsoluteUri && uri.IsFile then
            new Bitmap(uri.LocalPath)
        else
            new Bitmap(AssetLoader.Open(uri))

    let fromStream (source: Stream) = new Bitmap(source)
