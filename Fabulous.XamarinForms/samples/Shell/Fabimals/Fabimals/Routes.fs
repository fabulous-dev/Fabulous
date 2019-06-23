// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Routes

open Fabulous
open Xamarin.Forms
open Fabimals.Models
open Fabimals.Data
open Fabimals.Views

// Xamarin.Forms doesn't currently expose the Routing mecanism in a way for Fabulous to plug into it seamlessly
// For now, we need to follow the convention of inheriting from ContentPage so that we can later register with
// Routing.RegisterRoute("SomePath", typeof<MyPage>)

[<QueryProperty("Name", "name")>]
type RoutingPage(animals, view: Animal -> ViewElement) =
    inherit ContentPage()
    
    let mutable _name = ""
    let mutable _prevViewElement = None
    
    let findAnimalByName (name: string) =
        animals |> List.find (fun a -> a.Name.ToLower() = name.ToLower())
    
    member this.Name
        with get() = _name
        and set(value: string) =
            _name <- value.Replace("%20", " ")
            this.Refresh()
        
    member this.Refresh() =
        let animal = findAnimalByName _name
        let viewElement = view animal
        match _prevViewElement with
        | None ->
            this.Content <- viewElement.Create() :?> View
        | Some prevViewElement ->
            viewElement.UpdateIncremental(prevViewElement, this.Content)
            
type CatRoutingPage() =
    inherit RoutingPage(Cats.data, (CatDetails.init >> CatDetails.view))
type DogRoutingPage() =
    inherit RoutingPage(Dogs.data, (DogDetails.init >> DogDetails.view))
type MonkeyRoutingPage() =
    inherit RoutingPage(Monkeys.data, (MonkeyDetails.init >> MonkeyDetails.view))
type ElephantRoutingPage() =
    inherit RoutingPage(Elephants.data, (ElephantDetails.init >> ElephantDetails.view))
type BearRoutingPage() =
    inherit RoutingPage(Bears.data, (BearDetails.init >> BearDetails.view))

