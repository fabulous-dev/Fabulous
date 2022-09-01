namespace HelloWorld

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type Model =
        { Count: int
          EnteredText: string }

    type Msg =
        | Clicked
        | UserWroteSomething of string

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
        { Count = 0; EnteredText = "" }, []

    let update msg model =
        match msg with
        | Clicked ->
            { model with Count = model.Count + 1 }, [ SemanticAnnounce $"Clicked {model.Count} times" ]
            
        | UserWroteSomething text ->
            { model with EnteredText = text }, []
    
    let view model =
        Application(
            ContentPage(
                "HelloWorld",
                ScrollView(
                    (VStack(spacing = 25.) {
                        Image(Aspect.AspectFit, "dotnet_bot.png")
                            .semantics(description = "Cute dotnet bot waving hi to you!")
                            .height(200.)
                            .centerHorizontal()
                            
                        Label("Hello, World!")
                            .semantics(SemanticHeadingLevel.Level1)
                            .font(size = 32.)
                            .centerTextHorizontal()
                            
                        Label("Welcome to .NET Multi-platform App UI powered by Fabulous")
                            .semantics(SemanticHeadingLevel.Level2, "Welcome to dot net Multi platform App U I powered by Fabulous")
                            .font(size = 18.)
                            .centerTextHorizontal()
                            
                        let text =
                            if model.Count = 0 then
                                "Click me"
                            else
                                $"Clicked {model.Count} times"
                            
                        Button(text, Clicked)
                            .semantics(hint = "Counts the number of times you click")
                            .centerHorizontal()
                            
                        Entry(model.EnteredText, UserWroteSomething)
                            .semantics(hint = "Type something here")
                            
                        let userText =
                            if model.EnteredText = "" then
                                "You wrote nothing"
                            else
                                $"You wrote '{model.EnteredText}'"
                            
                        Label(userText)
                            .semantics(description = userText)
                            .centerHorizontal()
                    })
                        .padding(Thickness(30., 0., 30., 0.))
                        .centerVertical()
                )
            )
        )

    let program =
        Program.statefulWithCmdMsg init update view mapCmd
