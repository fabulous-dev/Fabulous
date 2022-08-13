namespace CounterApp

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type Model = { Count: int }

    type Msg =
        | Clicked

    type CmdMsg =
        | SemanticAnnounce of string
        
    let semanticAnnounce text =
        Cmd.ofSub (fun _ ->
            SemanticScreenReader.Announce(text)    
        )
    
    let mapCmd cmdMsg =
        match cmdMsg with
        | SemanticAnnounce text -> semanticAnnounce text
    
    let init () =
        { Count = 0 }, []

    let update msg model =
        match msg with
        | Clicked ->
            { model with Count = model.Count + 1 }, [ SemanticAnnounce $"Clicked {model.Count} times" ]

    let view model =
        Application() {
            Window(
                // (VStack() {
                    // Label("Hello, World!")
                    //     .textColor(Colors.Blue)
                    //     .verticalTextAlignment(TextAlignment.Center)
                    //     .horizontalTextAlignment(TextAlignment.Center)
                        
                let text =
                    if model.Count = 0 then
                        "Click me!"
                    else
                        $"Clicked {model.Count} times"
                        
                TextButton(text, Clicked)
                    .background(SolidPaint(Color.FromArgb("#817DC0")))
                    .textColor(Colors.White)
                // })
                //     .verticalLayoutAlignment(LayoutAlignment.Center)
                //     .horizontalLayoutAlignment(LayoutAlignment.Center)
            )
        }
    
    // let view model =
    //     Application() {
    //         Window(
    //             ScrollView(
    //                 (VStack(spacing = 25.) {
    //                     Image(Aspect.AspectFit, "dotnet_bot.png")
    //                         .semanticDescription("Cute dotnet bot waving hi to you!")
    //                         .height(200.)
    //                         .centerHorizontal()
    //                         
    //                     Label("Hello, World!")
    //                         .semanticHeadingLevel("Level1")
    //                         .font(size = 32.)
    //                         .centerHorizontal()
    //                         
    //                     Label("Welcome to .NET Multi-platform App UI powered by Fabulous")
    //                         .semanticHeadingLevel("Level2")
    //                         .semanticDescription("Welcome to dot net Multi platform App U I")
    //                         .font(size = 18.)
    //                         .centerHorizontal()
    //                         
    //                     Button("Click me", Clicked)
    //                         .semanticHint("Counts the number of times you click")
    //                         .centerHorizontal()
    //                 })
    //                     .padding(30., 0., 30., 0.)
    //                     .centerVertical()
    //             )
    //         )
    //     }

    let program =
        Program.statefulWithCmdMsg init update view mapCmd
