namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module CollectionView =
    let collectionViewView() =
        View.NonScrollingContentPage(
            title = "CollectionView sample",
            content =
                View.CollectionView [
                    View.Label(text = "Person 1", height = 25.) 
                    View.Label(text = "Person 2", height = 25.)
                    View.Label(text = "Person 3", height = 25.)
                    View.Label(text = "Person 4", height = 25.)
                    View.Label(text = "Person 5", height = 25.)
                    View.Label(text = "Person 6", height = 25.)
                    View.Label(text = "Person 7", height = 25.)
                    View.Label(text = "Person 8", height = 25.)
                    View.Label(text = "Person 9", height = 25.)
                    View.Label(text = "Person 11", height = 25.)
                    View.Label(text = "Person 12", height = 25.)
                    View.Label(text = "Person 13", height = 25.)
                    View.Label(text = "Person 14", height = 25.)
                ]
        )
    
    let view() =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 
            collectionViewView()
        | _ ->
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support CollectionView")
                ]
            )
