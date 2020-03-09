namespace AllControls.Samples.UseCases

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module InfiniteScrollList =
    type Msg =
        | SetInfiniteScrollMaxIndex of int
        
    type CmdMsg = Nothing
    
    type Model =
        { InfiniteScrollMaxRequested: int }
        
    let mapToCmd _ = Cmd.none
        
    let init () =
        { InfiniteScrollMaxRequested = 10 }
        
    let update msg model =
        match msg with
        | SetInfiniteScrollMaxIndex n ->
            if n >= max n model.InfiniteScrollMaxRequested then
                { model with InfiniteScrollMaxRequested = (n + 10) }, []
            else
                model, []
    
    let view model dispatch =
        dependsOn (model.InfiniteScrollMaxRequested) (fun model max -> 
            View.ScrollingContentPage(
                title = "ListView (InfiniteScrollList)",
                content = View.StackLayout([
                    View.Label(text="InfiniteScrollList:")
                    View.ListView(
                        horizontalOptions = LayoutOptions.CenterAndExpand,
                        
                        // Every time the last element is needed, grow the set of data to be at least 10 bigger then that index
                        itemAppearing = (fun idx ->
                            if idx >= max - 2 then
                                dispatch (SetInfiniteScrollMaxIndex (idx + 10))
                        ),
                        
                        items = [
                            for i in 1 .. max -> 
                                dependsOn i (fun _ i ->
                                    View.TextCell(
                                        text = "Item " + string i,
                                        textColor = randomColor()
                                    )
                                )
                        ]
                    )
                ])
            )
        )

