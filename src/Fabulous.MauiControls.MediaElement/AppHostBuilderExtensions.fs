namespace Fabulous.Maui.MediaElement

open System.Runtime.CompilerServices
open Microsoft.Maui.Hosting
open CommunityToolkit.Maui

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member UseFabulousMediaElement(this: MauiAppBuilder) =
        this.UseMauiCommunityToolkitMediaElement()
