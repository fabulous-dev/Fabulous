namespace AllControls.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module ScrollView =
    type Msg =
        | ScrollFabulous of float * float * AnimationKind
        | ScrollXamarinForms of float * float * AnimationKind
        | Scrolled of float * float
        
    type CmdMsg =
        | ScrollWithXFTo of float * float * AnimationKind
        
    type Model =
        { ScrollPosition: float * float
          AnimatedScroll: AnimationKind
          IsScrollingWithFabulous: bool
          IsScrolling: bool}
    
    let scrollViewRef = ViewRef<ScrollView>()

    let scrollWithXFAsync (x: float, y: float, animated: AnimationKind) =
        async {
            match scrollViewRef.TryValue with
            | None -> return None
            | Some scrollView ->
                let animationEnabled =
                    match animated with
                    | Animated -> true
                    | NotAnimated -> false
                do! scrollView.ScrollToAsync(x, y, animationEnabled) |> Async.AwaitTask |> Async.Ignore
                return Some (Scrolled (x, y))
        } |> Cmd.ofAsyncMsgOption
        
    let scrollToValue (x, y) animated =
        (x, y, animated)
        
    let mapToCmd cmdMsg =
        match cmdMsg with
        | ScrollWithXFTo (x, y, animated) ->
            scrollWithXFAsync (x, y, animated)
        
    let init () =
        { ScrollPosition = 0.0, 0.0
          AnimatedScroll = Animated
          IsScrollingWithFabulous = false
          IsScrolling = false }
        
    let update msg model =
        match msg with
        | ScrollFabulous (x, y, animated) ->
            { model with IsScrolling = true; IsScrollingWithFabulous = true; ScrollPosition = (x, y); AnimatedScroll = animated }, []
        | ScrollXamarinForms (x, y, animated) ->
            { model with IsScrolling = true; IsScrollingWithFabulous = false; ScrollPosition = (x, y); AnimatedScroll = animated }, [ScrollWithXFTo (x, y, animated)]
        | Scrolled (x, y) ->
            { model with ScrollPosition = (x, y); IsScrolling = false; IsScrollingWithFabulous = false }, []
        
    let view model dispatch =
        View.NonScrollingContentPage(
            title = "ScrollView sample",
            content = View.StackLayout(
                children = [
                    View.Label(text = (sprintf "Is scrolling: %b" model.IsScrolling))
                    View.Button(
                        text = "Scroll to top",
                        command = fun() -> dispatch (ScrollFabulous (0.0, 0.0, Animated))
                    )
                    View.ScrollView(
                        ref = scrollViewRef,
                        ?scrollTo = (if model.IsScrollingWithFabulous then Some (scrollToValue model.ScrollPosition model.AnimatedScroll) else None),
                        scrolled = (fun args -> dispatch (Scrolled (args.ScrollX, args.ScrollY))),
                        content = View.StackLayout(
                            children = [
                                yield View.Button(
                                    text = "Scroll animated with Fabulous",
                                    command = fun() -> dispatch (ScrollFabulous (0.0, 750.0, Animated))
                                )
                                yield View.Button(
                                    text = "Scroll not animated with Fabulous",
                                    command = fun() -> dispatch (ScrollFabulous (0.0, 750.0, NotAnimated))
                                )
                                yield View.Button(
                                    text = "Scroll animated with Xamarin.Forms",
                                    command = fun() -> dispatch (ScrollXamarinForms (0.0, 750.0, Animated))
                                )
                                yield View.Button(
                                    text = "Scroll not animated with Xamarin.Forms",
                                    command = fun() -> dispatch (ScrollXamarinForms (0.0, 750.0, NotAnimated))
                                )

                                for i = 0 to 75 do
                                    yield View.Label(text = sprintf "Item %i" i)
                            ]
                        )
                    )
                ]
            ) 
        )

