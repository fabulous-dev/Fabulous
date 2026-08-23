namespace Fabulous.Maui.Maps

open System.Runtime.CompilerServices
open Microsoft.Maui.Hosting
open Microsoft.Maui.Controls.Hosting

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member UseFabulousMaps(this: MauiAppBuilder) = this.UseMauiMaps()
