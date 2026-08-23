namespace Tetris

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

// Credits to https://github.com/RyushiAok/Tetris for the original code

module Paths =
    [<Literal>]
    let Left =
        "M11.4939 20.5644C11.1821 20.8372 10.7083 20.8056 10.4356 20.4939L3.43557 12.4939C3.18814 12.2111 3.18814 11.7889 3.43557 11.5061L10.4356 3.50613C10.7083 3.1944 11.1822 3.16281 11.4939 3.43557C11.8056 3.70834 11.8372 4.18216 11.5644 4.49388L5.65283 11.25L20 11.25C20.4142 11.25 20.75 11.5858 20.75 12C20.75 12.4142 20.4142 12.75 20 12.75L5.65283 12.75L11.5644 19.5061C11.8372 19.8179 11.8056 20.2917 11.4939 20.5644Z"

    [<Literal>]
    let Right =
        "M12.5061 3.43557C12.8178 3.16281 13.2917 3.19439 13.5644 3.50612L20.5644 11.5061C20.8119 11.7889 20.8119 12.2111 20.5644 12.4939L13.5644 20.4939C13.2917 20.8056 12.8178 20.8372 12.5061 20.5644C12.1944 20.2917 12.1628 19.8178 12.4356 19.5061L18.3472 12.75H4C3.58579 12.75 3.25 12.4142 3.25 12C3.25 11.5858 3.58579 11.25 4 11.25H18.3472L12.4356 4.49388C12.1628 4.18215 12.1944 3.70833 12.5061 3.43557Z"

    [<Literal>]
    let Down =
        "M20.5644 12.5061C20.8372 12.8178 20.8056 13.2917 20.4939 13.5644L12.4939 20.5644C12.2111 20.8119 11.7889 20.8119 11.5061 20.5644L3.50611 13.5644C3.19439 13.2917 3.1628 12.8178 3.43556 12.5061C3.70832 12.1944 4.18214 12.1628 4.49387 12.4356L11.25 18.3472L11.25 4C11.25 3.58579 11.5858 3.25 12 3.25C12.4142 3.25 12.75 3.58579 12.75 4L12.75 18.3472L19.5061 12.4356C19.8178 12.1628 20.2917 12.1944 20.5644 12.5061Z"

    [<Literal>]
    let Hold =
        "M17.8 21H22v1h-6v-6h1v4.508a9.861 9.861 0 1 0-5 1.373v.837A10.748 10.748 0 1 1 17.8 21zM11 11v2h2v-2z"

    [<Literal>]
    let RotateLeft =
        "M13,3A9,9,0,0,0,4.91,8.08l-1-2.45a1,1,0,0,0-1.86.74l2,5A1,1,0,0,0,5,12a1,1,0,0,0,.37-.07l5-2a1,1,0,0,0-.74-1.86L6.54,9.31a7,7,0,1,1,1.21,7.32,1,1,0,0,0-1.41-.09A1,1,0,0,0,6.25,18,9,9,0,1,0,13,3Z"

    [<Literal>]
    let RotateRight =
        "M21.37,5.07a1,1,0,0,0-1.3.56l-1,2.45A9,9,0,1,0,17.75,18a1,1,0,0,0-.09-1.41,1,1,0,0,0-1.41.09,7,7,0,1,1,1.2-7.33L14.37,8.07a1,1,0,1,0-.74,1.86l5,2A1,1,0,0,0,19,12a1,1,0,0,0,.93-.63l2-5A1,1,0,0,0,21.37,5.07Z"

type Board =
    { width: int
      height: int
      board: TetrisBoard }

module App =
    type Model =
        { Tetrimino: Tetrimino
          hold: Tetrimino option
          grid: Board
          lastUpdated: DateTime
          isOver: bool
          score: int }

    type Msg =
        | Empty
        | Update
        | NewGame
        | Left
        | Right
        | Down
        | RotL
        | RotR
        | Hold

    let init () =
        { Tetrimino = Tetrimino.generate true
          hold = None
          grid =
            { width = 16
              height = 24
              board = TetrisBoard.init }
          lastUpdated = DateTime.Now
          isOver = false
          score = 0 },
        Cmd.none


    let update msg model =
        match msg with
        | Update ->
            if model.isOver || (DateTime.Now - model.lastUpdated).TotalMilliseconds < 500.0 then
                model, Cmd.none
            else
                let nxt = model.Tetrimino |> Tetrimino.moveDown model.grid.board

                if model.Tetrimino <> nxt then
                    { model with
                        Tetrimino = nxt
                        lastUpdated = DateTime.Now },
                    Cmd.none
                else
                    nxt
                    |> Tetrimino.isHighLimitOver
                    |> function
                        | true ->
                            let existsOtherBlock = nxt |> Tetrimino.existsOtherBlock model.grid.board

                            let res = model.grid.board |> TetrisBoard.setTetrimino nxt

                            { model with
                                isOver = true
                                grid.board = if existsOtherBlock then model.grid.board else res.newBoard },
                            Cmd.none
                        | false ->
                            let newMino = Tetrimino.generate false

                            let res = model.grid.board |> TetrisBoard.setTetrimino nxt

                            { model with
                                grid.board = res.newBoard
                                Tetrimino = newMino
                                lastUpdated = DateTime.Now
                                isOver = newMino |> Tetrimino.existsOtherBlock res.newBoard
                                score = model.score + res.eraced },
                            Cmd.none
        | RotL ->
            { model with
                Tetrimino = model.Tetrimino |> Tetrimino.rotateLeft model.grid.board
                lastUpdated =
                    if
                        model.Tetrimino.shape = Shape.O
                        || model.Tetrimino |> Tetrimino.rotateLeft model.grid.board = model.Tetrimino
                        || model.Tetrimino
                           |> Tetrimino.rotateLeft model.grid.board
                           |> fun mino -> { mino with y = mino.y + 1 }
                           |> Tetrimino.existsOtherBlock model.grid.board
                           |> not
                    then
                        model.lastUpdated
                    else
                        DateTime.Now },
            Cmd.none
        | RotR ->
            { model with
                Tetrimino = model.Tetrimino |> Tetrimino.rotateRight model.grid.board
                lastUpdated =
                    if
                        model.Tetrimino.shape = Shape.O
                        || model.Tetrimino |> Tetrimino.rotateRight model.grid.board = model.Tetrimino
                        || model.Tetrimino
                           |> Tetrimino.rotateRight model.grid.board
                           |> fun mino -> { mino with y = mino.y + 1 }
                           |> Tetrimino.existsOtherBlock model.grid.board
                           |> not
                    then
                        model.lastUpdated
                    else
                        DateTime.Now },
            Cmd.none
        | Left ->
            { model with
                Tetrimino = model.Tetrimino |> Tetrimino.moveLeft model.grid.board
                lastUpdated =
                    if
                        model.Tetrimino.shape = Shape.O
                        || model.Tetrimino |> Tetrimino.moveDown model.grid.board <> model.Tetrimino
                        || model.Tetrimino |> Tetrimino.moveLeft model.grid.board = model.Tetrimino
                    then
                        model.lastUpdated
                    else
                        DateTime.Now },
            Cmd.none
        | Right ->
            { model with
                Tetrimino = model.Tetrimino |> Tetrimino.moveRight model.grid.board
                lastUpdated =
                    if
                        model.Tetrimino.shape = Shape.O
                        || model.Tetrimino |> Tetrimino.moveDown model.grid.board <> model.Tetrimino
                        || model.Tetrimino |> Tetrimino.moveRight model.grid.board = model.Tetrimino
                    then
                        model.lastUpdated
                    else
                        DateTime.Now },
            Cmd.none
        | Down ->
            { model with
                Tetrimino = model.Tetrimino |> Tetrimino.moveDown model.grid.board },
            Cmd.none
        | Hold ->
            if model.hold.IsSome then
                { model with
                    Tetrimino = model.hold.Value
                    hold = Some(Tetrimino.initMino model.Tetrimino.shape) },
                Cmd.none
            else
                { model with
                    Tetrimino = Tetrimino.generate false
                    hold = Some(Tetrimino.initMino model.Tetrimino.shape) },
                Cmd.none
        | NewGame -> init()
        | _ -> model, Cmd.none

    let shapeToColor shape =
        match shape with
        | Shape.I -> "#00ffff"
        | Shape.O -> "#ffd700"
        | Shape.J -> "#1e90ff"
        | Shape.L -> "#ffa500"
        | Shape.S -> "#00FF00"
        | Shape.Z -> "#ff0000"
        | Shape.T -> "#800080"

    let boardView state =
        let w, h = state.grid.width, state.grid.height

        let toColor state =
            let cells = state.grid.board

            let minoPos =
                state.Tetrimino.pos
                |> Array.map(fun (x, y) -> (x + state.Tetrimino.x, y + state.Tetrimino.y))

            let minoShape = state.Tetrimino.shape

            [| for y in 3 .. (Array2D.length1 cells) - 1 - 1 do
                   for x in 2 .. (Array2D.length2 cells) - 1 - 2 do
                       if not state.isOver && minoPos |> Array.contains(x, y) then
                           yield shapeToColor minoShape
                       else
                           match cells[y, x] with
                           | Cell.Empty -> yield "#222222"
                           | Cell.Guard -> yield "#AAAAAA"
                           | Cell.Mino shape -> yield shapeToColor shape |]

        (UniformGrid(cols = (w - 4), rows = (h - 4)) {
            let colors = toColor state

            for color in colors do
                AnyView(Border(Border().background(color)).padding(0.8))
        })
            .width(280.)
            .height(480.)

    let holdView (state: Model) =
        (HStack() {
            (UniformGrid(cols = 4, rows = 4) {
                let state =
                    state.hold
                    |> Option.map(fun mino ->
                        { mino with
                            pos = mino.pos |> Array.map(fun (a, b) -> (a + 1, b + 1)) })
                    |> Option.map(fun mino ->
                        [| for y in 0..3 do
                               for x in 0..3 do
                                   if not state.isOver && mino.pos |> Array.contains(x, y) then
                                       yield shapeToColor mino.shape
                                   else
                                       yield "#222222" |])

                match state with
                | None -> ()
                | Some colors ->
                    for color in colors do
                        Border(Border().background(color)).padding(1.5)
            })
                .height(70.0)
                .width(70.0)
                //.canvasLeft(360.0)
                //.canvasTop(0.0)
                .background("#222222")

        })
            .dock(Dock.Top)
    //.canvasTop(0.0)

    let howToPlayDesktop () =
        (HStack() {
            TextBlock("[A] LEFT \n[D] RIGHT \n[SHIFT] ROT L \n[SPACE] ROT R \n[E] HOLD")
                .fontSize(12.0)
                .horizontalAlignment(HorizontalAlignment.Center)
                .width(350.0)
        })
            .dock(Dock.Bottom)

    let howToPlayMobile model =
        (Dock() {

            Border(holdView model).dock(Dock.Top).centerHorizontal()

            Button(
                Hold,
                PathIcon(Paths.Hold)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Top)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Center)


            Button(
                Down,
                PathIcon(Paths.Down)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Bottom)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Center)
                .borderThickness(1.)

            Button(
                Right,
                PathIcon(Paths.Right)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Right)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Right)
                .verticalAlignment(VerticalAlignment.Stretch)

            Button(
                Left,
                PathIcon(Paths.Left)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Left)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Left)

            Button(
                RotL,
                PathIcon(Paths.RotateLeft)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Left)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Left)

            Button(
                RotR,
                PathIcon(Paths.RotateRight)
                    .width(32)
                    .height(32)
                    .foreground(Colors.Green)
            )
                .dock(Dock.Right)
                .margin(2.)
                .background(SolidColorBrush(Colors.Transparent))
                .horizontalAlignment(HorizontalAlignment.Right)
        })
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .gridRow(1)
            .margin(16.)

    let gameOverView () =
        Grid(rowdefs = [ Star; Auto ], coldefs = [ Star ]) {
            TextBlock("Game Over").fontSize(16.0).margin(4.0)

            Button("New Game", NewGame)
                .fontSize(16.0)
                .margin(4.0)
                .gridRow(1)
        }

    let subscription (_model: Model) =
        let timeSub dispatch =
            DispatcherTimer.Run(
                Func<bool>(fun _ ->
                    dispatch(Msg.Update)
                    true),
                TimeSpan.FromMilliseconds 10.0
            )

        [ [ nameof timeSub ], timeSub ]

    let mainWindow model =
        Window(
            if model.isOver then
                AnyView(gameOverView())
            else
                AnyView(
                    (Dock(lastChildFill = true) {
                        TextBlock($"Score: {model.score}")
                            .fontSize(16.0)
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .dock(Dock.Top)

                        Border(boardView model)
                            .dock(Dock.Left)
                            .borderThickness(20.0, 0.0, 0.0, 0.0)

                        Border(howToPlayDesktop())
                            .dock(Dock.Right)
                            .borderThickness(30.0, 0.0, 0.0, 0.0)

                        Border(holdView model)
                            .dock(Dock.Right)
                            .borderThickness(20.0, 0.0, 0.0, 250.0)
                    })
                        .background("#222222")
                )
        )
            .title("Tetris")
            .onKeyDown(fun e ->
                match e.Key with
                | Key.RightShift
                | Key.LeftShift -> RotL
                | Key.Space -> RotR
                | Key.S -> Down
                | Key.A -> Left
                | Key.D -> Right
                | Key.E -> Hold
                | _ -> Empty)

    let mainView model =
        Grid() {
            if model.isOver then
                gameOverView().center()
            else
                Grid(rowdefs = [ Star; Auto ], coldefs = [ Star ]) {
                    Grid(rowdefs = [ Auto; Star ], coldefs = [ Star ]) {
                        TextBlock($"Score: {model.score}")
                            .fontSize(28.0)
                            .fontWeight(FontWeight.Bold)
                            .foreground(ThemeAware.With(Colors.White, Colors.Black))
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .margin(Thickness(0.0, 56.0, 0.0, 0.0))

                        Border(boardView model).gridRow(1)
                    }

                    (howToPlayMobile model).gridRow(1)
                }
            |> _.background(Colors.Transparent)
        }
        |> _.background("#222222")


    let program =
        Program.statefulWithCmd init update
        |> Program.withSubscription subscription
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("TetrisPage") {
            let! model = Context.Mvu program
#if MOBILE
            SingleViewApplication(mainView model)
#else
            DesktopApplication() { mainWindow model }
#endif
        }

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
