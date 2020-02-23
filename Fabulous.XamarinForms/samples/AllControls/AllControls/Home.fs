namespace AllControls

open Fabulous.XamarinForms

module Home =
    type Msg =
        | SelectSkiaSharp
        
    type ExternalMsg =
        | GoToPage
        
    type Model = None
        
    let init () =
        None
        
    let update msg model =
        match msg with
        | SelectSkiaSharp ->
            model, [], Some GoToPage
            
    let view model dispatch =
        View.ContentPage(
            title = "AllControls samples",
            content = View.StackLayout([
                View.Button(
                    text = "SkiaSharp",
                    command = fun () -> dispatch SelectSkiaSharp
                )
            ])
        )
