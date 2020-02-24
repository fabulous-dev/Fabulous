namespace AllControls.Samples.UseCases

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module Animations =
    type Msg =
        | AnimationPoked
        | AnimationPoked2
        | AnimationPoked3
        
    type CmdMsg = Nothing
    type Model = Nothing
    
    let animatedLabelRef = ViewRef<Label>()
    
    let mapToCmd _ = Cmd.none
    
    let init () = Nothing
    
    let update msg model =
        match msg with
        | AnimationPoked -> 
            match animatedLabelRef.TryValue with
            | Some _ ->
                animatedLabelRef.Value.Rotation <- 0.0
                animatedLabelRef.Value.RotateTo (360.0, 2000u) |> ignore
            | None -> ()
            model, Cmd.none
        | AnimationPoked2 -> 
            ViewExtensions.CancelAnimations (animatedLabelRef.Value)
            animatedLabelRef.Value.Rotation <- 0.0
            animatedLabelRef.Value.RotateTo (360.0, 2000u) |> ignore
            model, Cmd.none
        | AnimationPoked3 -> 
            ViewExtensions.CancelAnimations (animatedLabelRef.Value)
            animatedLabelRef.Value.Rotation <- 0.0
            animatedLabelRef.Value.RotateTo (360.0, 2000u) |> ignore
            model, Cmd.none
    
    let view _ dispatch =
        View.ScrollingContentPage(
            title = "Animations",
            content = View.StackLayout([
                View.Label(text="Rotate", created=(fun l -> l.RotateTo (360.0, 2000u) |> ignore)) 
                View.Label(text="Hello!", ref=animatedLabelRef) 
                View.Button(text="Poke", command=(fun () -> dispatch AnimationPoked))
                View.Button(text="Poke2", command=(fun () -> dispatch AnimationPoked2))
                View.Button(text="Poke3", command=(fun () -> dispatch AnimationPoked3))
            ])
        )

