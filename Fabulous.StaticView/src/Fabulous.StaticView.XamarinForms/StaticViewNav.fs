// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.StaticView

open Fabulous.Core
open Xamarin.Forms

[<RequireQualifiedAccess>]
/// For navigation in the half-elmish model
module Nav =

    // TODO: modify the Elmish framework we use to remove this global state and pass it into all commands??
    let mutable globalNavMap : Map<System.IComparable, Page> = Map.empty

    /// Push new location into history and navigate there
    let push (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let toPage = globalNavMap.[toPageTag]
            let nav = fromPage.Navigation
            nav.PushAsync toPage |> ignore ]

    /// Push new location into history and navigate there
    let pushModal (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let toPage = globalNavMap.[toPageTag]
            let nav = fromPage.Navigation
            nav.PushModalAsync toPage |> ignore ]

    let popToRoot (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopToRootAsync() |> ignore ]

    let popModal (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopModalAsync() |> ignore ]

    let pop (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopAsync() |> ignore ]

