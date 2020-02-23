namespace AllControls.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module RefreshView =
    type Msg =
        | Refresh
        | RefreshDone
        
    type CmdMsg =
        | StartLongTask
        
    type Model =
        { IsRefreshing: bool }
    
    let mapToCmd (cmdMsg: CmdMsg) =
        match cmdMsg with
        | StartLongTask ->
            Cmd.ofAsyncMsg (async {
                do! Async.Sleep 3000
                return RefreshDone
            })
    
    let init () =
        { IsRefreshing = false }
    
    let update msg model =
        match msg with
        | Refresh -> { model with IsRefreshing = true }, [ StartLongTask ]
        | RefreshDone -> { model with IsRefreshing = false }, []
    
    let view model dispatch =
        View.NonScrollingContentPage(
            title = "RefreshView sample",
            content = View.StackLayout(
                children = [
                    View.RefreshView(
                        View.ScrollView(
                            View.BoxView(
                                height = 150.,
                                width = 150.,
                                color = if model.IsRefreshing then Color.Red else Color.Blue
                            )
                        ),
                        isRefreshing = model.IsRefreshing,
                        refreshing = (fun () -> dispatch Refresh)
                    )
                ]
            )
        )

