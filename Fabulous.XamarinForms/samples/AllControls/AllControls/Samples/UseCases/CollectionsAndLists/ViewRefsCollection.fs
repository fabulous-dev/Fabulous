namespace AllControls.Samples.UseCases

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

open AllControls.Helpers

module ViewRefsCollection =
    type Msg =
        | CheckItem75
        
    type CmdMsg = Nothing
    
    type Model =
        { Item75SizeOpt: (int * int) option }
        
    let viewRef = ViewRef<Label>()
        
    let mapToCmd _ = Cmd.none
        
    let init () =
        { Item75SizeOpt = None }
        
    let update msg model =
        match msg with
        | CheckItem75 ->
            let size =
                match viewRef.TryValue with
                | None -> None
                | Some ref -> Some ((int ref.Width), (int ref.Height))
            { model with Item75SizeOpt = size }, []
    
    let view model dispatch =
        dependsOn (model.Item75SizeOpt) (fun model (item75SizeOpt) -> 
            View.ContentPage(
                title = "ViewRefsCollection",
                content = View.StackLayout([
                    View.Label(text="ViewRefsCollection:")
                    View.Button(
                        text = "Check if Item 75 is alive",
                        horizontalOptions = LayoutOptions.Center,
                        command = fun () -> dispatch CheckItem75
                    )
                    View.Label(
                        horizontalOptions = LayoutOptions.Center,
                        text =
                            match item75SizeOpt with
                            | None -> "Item 75 is not alive"
                            | Some (w, h) -> sprintf "Item 75 is alive. Size: Width = %i; Height = %i" w h
                    )
                    View.CollectionView(
                        horizontalOptions = LayoutOptions.CenterAndExpand,                        
                        items = [
                            for i in 1 .. 100 -> 
                                dependsOn i (fun _ i ->
                                    View.Label(
                                        ?ref = (if i = 75 then Some viewRef else None),
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

