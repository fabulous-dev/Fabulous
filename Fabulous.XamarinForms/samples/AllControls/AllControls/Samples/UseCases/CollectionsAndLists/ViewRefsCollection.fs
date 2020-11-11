namespace AllControls.Samples.UseCases

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

open AllControls.Helpers

module ViewRefsCollection =
    type Msg =
        | CheckItem75
        | Item75Attached
        | Item75Detached

    type CmdMsg = Nothing

    type Model =
        { Item75SizeOpt: (int * int) option
          IsItem75Attached: bool }

    let viewRef = ViewRef<Label>()

    let mapToCmd _ = Cmd.none

    let init () =
        let cmd =
            Cmd.ofSub (fun dispatch ->
                // TODO: Events are triggering inside ViewRef, but don't trigger here
                viewRef.Attached.Add(fun _ -> dispatch Item75Attached)
                viewRef.Detached.Add(fun _ -> dispatch Item75Attached)
            )
        { Item75SizeOpt = None; IsItem75Attached = false }, cmd

    let update msg model =
        match msg with
        | CheckItem75 ->
            let size =
                match viewRef.TryValue with
                | None -> None
                | Some ref -> Some ((int ref.Width), (int ref.Height))
            { model with Item75SizeOpt = size }, []

        | Item75Attached ->
            { model with IsItem75Attached = true }, []
        | Item75Detached ->
            { model with IsItem75Attached = false }, []

    let view model dispatch =
        dependsOn (model.Item75SizeOpt, model.IsItem75Attached) (fun model (item75SizeOpt, isItem75Attached) ->
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
                    View.Label(
                        horizontalOptions = LayoutOptions.Center,
                        text = if isItem75Attached then "Item 75 is attached" else "Item 75 is detached"
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

