namespace AllControls.Samples.UseCases

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module InfiniteScrollCollection =
    type Msg =
        | LoadMoreItems
        
    type CmdMsg = Nothing
    
    type Model =
        { ItemsCount: int }
        
    let mapToCmd _ = Cmd.none
        
    let init () =
        { ItemsCount = 100 }
        
    let update msg model =
        match msg with
        | LoadMoreItems ->
            { model with ItemsCount = model.ItemsCount + 20 }, []
    
    let view model dispatch =
        dependsOn (model.ItemsCount) (fun model max -> 
            View.ContentPage(
                title = "InfiniteScrollCollection",
                content = View.StackLayout([
                    View.Label(text="InfiniteScrollCollection:")
                    View.CollectionView(
                        horizontalOptions = LayoutOptions.CenterAndExpand,
                        
                        remainingItemsThreshold = 5,
                        remainingItemsThresholdReached = (fun () -> dispatch LoadMoreItems),
                        
                        items = [
                            for i in 1 .. max -> 
                                dependsOn i (fun _ i ->
                                    View.Label(
                                        text = "Item " + string i,
                                        textColor = randomColor(),
                                        height = 30.,
                                        verticalTextAlignment = TextAlignment.Center
                                    )
                                )
                        ]
                    )
                ])
            )
        )

