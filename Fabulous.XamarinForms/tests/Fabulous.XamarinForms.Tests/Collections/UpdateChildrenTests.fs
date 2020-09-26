namespace Fabulous.XamarinForms.Tests.Collections

open System.Collections.ObjectModel
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Collections
open NUnit.Framework
open FsUnit

module UpdateChildrenTests =
    [<Test>]
    let ``Test UpdateChildren``() =
        let previous =
            [ View.Button(key = "Button0_0")
              View.Button(key = "Button0_1")
              View.Button(key = "Button0_2")
              View.Button(key = "Button1_0")
              View.Image(key = "Image1_1") ]
            
        let current =
            [ View.Label(key = "Button0_0")
              View.Button(key = "Button0_1")
              View.Image(key = "Button0_2") ]
        
        let collection = ObservableCollection<Xamarin.Forms.Element>()
        collection.Add(Xamarin.Forms.Button())
        collection.Add(Xamarin.Forms.Button())
        collection.Add(Xamarin.Forms.Button())
        collection.Add(Xamarin.Forms.Button())
        collection.Add(Xamarin.Forms.Image())
        
        Collections.updateChildren
            (ValueSome (Array.ofList previous))
            (ValueSome (Array.ofList current))
            collection
            (fun x -> x.Create() :?> Xamarin.Forms.Element)
            (fun _ _ _ -> ())
            -1 ignore
            
        let x = collection
        ()

