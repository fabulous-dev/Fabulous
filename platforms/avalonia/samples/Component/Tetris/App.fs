namespace Tetris

open System
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent
open Avalonia.Media

open type Fabulous.Avalonia.View
open type Fabulous.Context

// Credits to https://github.com/RyushiAok/Tetris for the original code

module Helpers =
    // Theme helpers (use types that match existing modifiers to avoid overload ambiguity)
    let themeHex (light: string) (dark: string) = ThemeAware.With(light, dark)

// Centralized color palette to avoid duplication across the UI
module Palette =
    // Tetrimino colors (fixed, not theme-aware)
    [<Literal>]
    let colorI = "#00FFFF" // Cyan

    [<Literal>]
    let colorO = "#FFD700" // Gold

    [<Literal>]
    let colorJ = "#1E90FF" // DodgerBlue

    [<Literal>]
    let colorL = "#FFA500" // Orange

    [<Literal>]
    let colorS = "#00FF00" // Lime

    [<Literal>]
    let colorZ = "#FF0000" // Red

    [<Literal>]
    let colorT = "#800080" // Purple

    let shapeColor shape =
        match shape with
        | Shape.I -> colorI
        | Shape.O -> colorO
        | Shape.J -> colorJ
        | Shape.L -> colorL
        | Shape.S -> colorS
        | Shape.Z -> colorZ
        | Shape.T -> colorT

    // Theme-aware colors
    let cellEmpty = Helpers.themeHex "#E6E9F2" "#333333"
    let cellGuard = Helpers.themeHex "#CDD3E0" "#4A4F59"
    let holdBg = Helpers.themeHex "#E6E9F2" "#222222"

    let statTitleFg = Helpers.themeHex "#444444" "#DCDCDC"
    let statValueFg = Helpers.themeHex "#000000" "#FFFFFF"

    let sectionTitleFg = Helpers.themeHex "#333333" "#DCDCDC"
    let hintTextFg = Helpers.themeHex "#4A4A4A" "#C8C8C8"

    let buttonBg = Helpers.themeHex "#E6E9F2" "#3A3F4B"
    let buttonFg = Helpers.themeHex "#000000" "#FFFFFF"

    let cardBg = Helpers.themeHex "#FFFFFF" "#2C3440"
    let cardBorder = Helpers.themeHex "#E0E6F0" "#3A4552"

    let boardBg = Helpers.themeHex "#F5F7FA" "#0F1623"
    let pageBg = Helpers.themeHex "#FFFFFF" "#0A0E17"

    let overlayTitleFg = Helpers.themeHex "#000000" "#FFFFFF"

    // Ghost piece cell fill (semi-transparent). Light theme: translucent dark gray; Dark theme: translucent white
    let ghostCell = Helpers.themeHex "#40808080" "#60FFFFFF"


module App =

    // Active patterns and helper discriminated unions to reduce duplication
    type Action =
        | RotateLeft
        | RotateRight
        | Down
        | Left
        | Right
        | Hold
        | HardDrop
        | Other

    let (|KeyAction|) (key: Key) =
        match key with
        | Key.LeftShift
        | Key.RightShift -> RotateLeft
        | Key.Space -> RotateRight
        | Key.S -> Down
        | Key.A -> Left
        | Key.D -> Right
        | Key.E -> Hold
        | Key.LeftCtrl -> HardDrop
        | _ -> Other

    // Compute where a mino would land if dropped straight down without locking
    let rec dropToBottom (board: Cell[,]) (mino: Tetrimino) =
        let next = Tetrimino.moveDown board mino
        if next = mino then mino else dropToBottom board next

    let boardView grid tetrimino isOver =
        let w, h = grid.width, grid.height

        let toColors tetrimino isOver =
            let cells = grid.board

            let minoPos =
                tetrimino.pos |> Array.map(fun (x, y) -> (x + tetrimino.x, y + tetrimino.y))

            let minoShape = tetrimino.shape

            // Ghost projection positions (only used when not game over)
            let ghostPos: (int * int) array =
                if isOver then
                    [||]
                else
                    let g = dropToBottom cells tetrimino
                    g.pos |> Array.map(fun (x, y) -> (x + g.x, y + g.y))

            [| for y in 3 .. (Array2D.length1 cells) - 1 - 1 do
                   for x in 2 .. (Array2D.length2 cells) - 1 - 2 do
                       // Active falling mino has priority
                       if (not isOver) && (minoPos |> Array.contains(x, y)) then
                           yield Palette.shapeColor minoShape
                       else
                           match cells[y, x] with
                           | Cell.Mino shape ->
                               // Placed blocks take precedence over ghost
                               yield Palette.shapeColor shape
                           | Cell.Empty
                           | Cell.Guard as cell ->
                               // Show ghost only on empty/guard cells and only when not overlapping active mino
                               if (not isOver) && (ghostPos |> Array.contains(x, y)) then
                                   yield Palette.ghostCell
                               else
                                   match cell with
                                   | Cell.Empty -> yield Palette.cellEmpty
                                   | Cell.Guard -> yield Palette.cellGuard
                                   | _ -> yield Palette.cellEmpty |]

        (UniformGrid(cols = (w - 4), rows = (h - 4)) {
            let colors = toColors tetrimino isOver

            for c in colors do
                Border(Border().background(c)).padding(0.8)
        })
            .width(280.)
            .height(480.)

    let holdView hold isOver =
        (HStack() {
            (UniformGrid(cols = 4, rows = 4) {
                let state =
                    hold
                    |> Option.map(fun mino ->
                        { mino with
                            pos = mino.pos |> Array.map(fun (a, b) -> (a + 1, b + 1)) })
                    |> Option.map(fun mino ->
                        [| for y in 0..3 do
                               for x in 0..3 do
                                   if not isOver && mino.pos |> Array.contains(x, y) then
                                       yield Palette.shapeColor mino.shape
                                   else
                                       yield Palette.cellEmpty |])

                match state with
                | None -> ()
                | Some colors ->
                    for c in colors do
                        Border(Border().background(c)).padding(1.5)
            })
                .height(70.0)
                .width(70.0)
                .canvasLeft(360.0)
                .canvasTop(0.0)
                .background(Palette.holdBg)

        })
            .dock(Dock.Top)
            .canvasTop(0.0)

    // moved above boardView

    let applyControlActions
        (grid: StateValue<Board>)
        (tetrimino: StateValue<Tetrimino>)
        (hold: StateValue<Tetrimino option>)
        (next: StateValue<Tetrimino>)
        (lastUpdated: StateValue<DateTime>)
        (score: StateValue<int>)
        (lines: StateValue<int>)
        (isOver: StateValue<bool>)
        (key: Key)
        : unit =
        match key with
        | KeyAction Action.RotateLeft ->
            tetrimino.Set(tetrimino.Current |> Tetrimino.rotateLeft grid.Current.board)

            if
                tetrimino.Current.shape = Shape.O
                || tetrimino.Current |> Tetrimino.rotateLeft grid.Current.board = tetrimino.Current
                || tetrimino.Current
                   |> Tetrimino.rotateLeft grid.Current.board
                   |> fun mino -> { mino with y = mino.y + 1 }
                   |> Tetrimino.existsOtherBlock grid.Current.board
                   |> not
            then
                lastUpdated.Set(lastUpdated.Current)
            else
                lastUpdated.Set(DateTime.Now)

        | KeyAction Action.RotateRight ->
            tetrimino.Set(tetrimino.Current |> Tetrimino.rotateRight grid.Current.board)

            if
                tetrimino.Current.shape = Shape.O
                || tetrimino.Current |> Tetrimino.rotateRight grid.Current.board = tetrimino.Current
                || tetrimino.Current
                   |> Tetrimino.rotateRight grid.Current.board
                   |> fun mino -> { mino with y = mino.y + 1 }
                   |> Tetrimino.existsOtherBlock grid.Current.board
                   |> not
            then
                lastUpdated.Set(lastUpdated.Current)
            else
                lastUpdated.Set(DateTime.Now)

        | KeyAction Action.Down -> tetrimino.Set(tetrimino.Current |> Tetrimino.moveDown grid.Current.board)

        | KeyAction Action.Left ->
            tetrimino.Set(tetrimino.Current |> Tetrimino.moveLeft grid.Current.board)

            if
                tetrimino.Current.shape = Shape.O
                || tetrimino.Current |> Tetrimino.moveDown grid.Current.board <> tetrimino.Current
                || tetrimino.Current |> Tetrimino.moveLeft grid.Current.board = tetrimino.Current
            then
                lastUpdated.Set(lastUpdated.Current)
            else
                lastUpdated.Set(DateTime.Now)

        | KeyAction Action.Right ->
            tetrimino.Set(tetrimino.Current |> Tetrimino.moveRight grid.Current.board)

            if
                tetrimino.Current.shape = Shape.O
                || tetrimino.Current |> Tetrimino.moveDown grid.Current.board <> tetrimino.Current
                || tetrimino.Current |> Tetrimino.moveRight grid.Current.board = tetrimino.Current
            then
                lastUpdated.Set(lastUpdated.Current)
            else
                lastUpdated.Set(DateTime.Now)

        | KeyAction Action.Hold ->
            if hold.Current.IsSome then
                let cur = tetrimino.Current
                tetrimino.Set(hold.Current.Value)
                hold.Set(Some(Tetrimino.initMino cur.shape))
            else
                let cur = tetrimino.Current
                hold.Set(Some(Tetrimino.initMino cur.shape))
                tetrimino.Set(next.Current)
                next.Set(Tetrimino.generate false)

        | KeyAction Action.HardDrop ->
            let final = dropToBottom grid.Current.board tetrimino.Current
            let rowsBefore = lines.Current
            let res = grid.Current.board |> TetrisBoard.setTetrimino final

            grid.Set(
                { grid.Current with
                    board = res.newBoard }
            )
            // award drop distance * 2, then process eraced rows
            let dropDist = final.y - tetrimino.Current.y
            score.Set(score.Current + max 0 (dropDist * 2))
            tetrimino.Set(next.Current)
            next.Set(Tetrimino.generate false)
            lastUpdated.Set(DateTime.Now)
            isOver.Set(tetrimino.Current |> Tetrimino.existsOtherBlock res.newBoard)

            if res.eraced > 0 then
                // reuse your existing scoring for cleared rows
                lines.Set(lines.Current + res.eraced)
        | KeyAction Action.Other -> ()

    let private statCard (title: string) (value: string) =
        Border(
            (VStack(4.) {
                TextBlock(title)
                    .fontSize(12.)
                    .foreground(Palette.statTitleFg)

                TextBlock(value)
                    .fontSize(22.)
                    .fontWeight(FontWeight.Bold)
                    .foreground(Palette.statValueFg)
            })
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)

        )
            .padding(12.)
            .cornerRadius(8.)
            .background(Palette.cardBg)
            .borderBrush(Palette.cardBorder)
            .borderThickness(1.)

    let private nextPreview (hold: Tetrimino option) (isOver: bool) =
        Border(
            VStack(8.) {
                TextBlock("NEXT")
                    .fontSize(16.)
                    .fontWeight(FontWeight.Bold)
                    .foreground(Palette.sectionTitleFg)
                    .horizontalAlignment(HorizontalAlignment.Center)

                (holdView hold isOver)
                    .horizontalAlignment(HorizontalAlignment.Center)
            }
        )
            .padding(12.)
            .cornerRadius(10.)
            .background(Palette.cardBg)
            .borderBrush(Palette.cardBorder)
            .borderThickness(1.)

    let private howToPlayDesktopCard () =
        Border(
            VStack(8.) {
                TextBlock("HOW TO PLAY")
                    .fontSize(16.)
                    .fontWeight(FontWeight.Bold)
                    .foreground(Palette.sectionTitleFg)
                    .horizontalAlignment(HorizontalAlignment.Center)

                TextBlock("A: LEFT\nD: RIGHT\nS: DOWN\nSHIFT: ROTATE L\nSPACE: ROTATE R\nCTRL: HARD DROP\nE: HOLD")
                    .fontSize(12.)
                    .foreground(Palette.hintTextFg)
                    .textWrapping(TextWrapping.Wrap)
                    .horizontalAlignment(HorizontalAlignment.Center)
            }
        )
            .padding(12.)
            .cornerRadius(10.)
            .background(Palette.cardBg)
            .borderBrush(Palette.cardBorder)
            .borderThickness(1.)

    let private mobileControls (onAct: Key -> unit) =
        AnyView(
            HStack(10.) {
                HStack(12.) {
                    Button("←", (fun _ -> onAct Key.A))
                        .width(44.)
                        .height(44.)
                        .fontSize(24.)
                        .cornerRadius(22.)
                        .background(Palette.buttonBg)
                        .foreground(Palette.buttonFg)

                    Button("↻", (fun _ -> onAct Key.LeftShift))
                        .width(44.)
                        .height(44.)
                        .fontSize(24.)
                        .cornerRadius(22.)
                        .background(Palette.buttonBg)
                        .foreground(Palette.buttonFg)

                }

                HStack(12.) {
                    Button("↓", (fun _ -> onAct Key.S))
                        .width(44.)
                        .height(44.)
                        .cornerRadius(22.)
                        .fontSize(24.)
                        .background(Palette.buttonBg)
                        .foreground(Palette.buttonFg)

                    Button("→", (fun _ -> onAct Key.D))
                        .width(44.)
                        .height(44.)
                        .cornerRadius(22.)
                        .fontSize(24.)
                        .background(Palette.buttonBg)
                        .foreground(Palette.buttonFg)

                    Button("⇩", (fun _ -> onAct Key.LeftCtrl))
                        .width(44.)
                        .height(44.)
                        .cornerRadius(22.)
                        .fontSize(24.)
                        .background(Palette.buttonBg)
                        .foreground(Palette.buttonFg)
                }
            }
        )

    let mobileLayout (isOver: bool) (grid: Board) (tetrimino: Tetrimino) (next: Tetrimino) (score: int) (lines: int) (level: int) (onAct: Key -> unit) =

        Grid(rowdefs = [ Auto; Star; Auto; Auto ], coldefs = [ Star ]) {
            (HStack(12.) {
                statCard "SCORE" (string score)
                statCard "LEVEL" (string level)
                statCard "LINES" (string lines)
            })
                .margin(8., 54., 8., 0.)
                .centerHorizontal()
                .gridRow(0)

            Border(boardView grid tetrimino isOver)
                .padding(8.)
                .cornerRadius(8.)
                .background(Palette.boardBg)
                .margin(16., 4., 16., 0.)
                .horizontalAlignment(HorizontalAlignment.Center)
                .gridRow(1)

            (nextPreview (Some(Tetrimino.initMino next.shape)) isOver)
                .margin(16., 0., 16., 0.)
                .gridRow(2)

            (mobileControls onAct)
                .margin(0., 8., 0., 16.)
                .centerHorizontal()
                .gridRow(3)
        }
        |> _.background(Palette.pageBg)

    let desktopLayout (isOver: bool) (grid: Board) (tetrimino: Tetrimino) (next: Tetrimino) (score: int) (lines: int) (level: int) =

        Grid(rowdefs = [ Auto; Star ], coldefs = [ Star; Auto ]) {
            (HStack(12.) {
                statCard "SCORE" (string score)
                statCard "LEVEL" (string level)
                statCard "LINES" (string lines)
            })
                .margin(16., 12., 16., 0.)
                .gridRow(0)
                .gridColumnSpan(2)

            // Wrap the fixed-size board in a ViewBox so it scales as the window grows
            ViewBox(
                Border(boardView grid tetrimino isOver)
                    .padding(8.)
                    .cornerRadius(8.)
                    .background(Palette.boardBg)
            )
                .stretch(Stretch.Uniform)
                .margin(24.)
                .gridRow(1)
                .gridColumn(0)

            (VStack(12.) {
                AnyView(nextPreview (Some(Tetrimino.initMino next.shape)) isOver)
                AnyView(howToPlayDesktopCard())
            })
                .margin(8., 24., 24., 24.)
                .gridRow(1)
                .gridColumn(1)
        }
        |> _.background(Palette.pageBg)

    let levelResultsOverView
        (tetrimino: StateValue<Tetrimino>)
        (grid: StateValue<Board>)
        (lastUpdated: StateValue<DateTime>)
        (score: StateValue<int>)
        (lines: StateValue<int>)
        (next: StateValue<Tetrimino>)
        (isOver: StateValue<bool>)
        (level: StateValue<int>)
        (isLevelComplete: StateValue<bool>)
        =
        Component("GameOver") {
            let! tetrimino = Binding(tetrimino)
            let! grid = Binding(grid)
            let! lastUpdated = Binding(lastUpdated)
            let! score = Binding(score)
            let! lines = Binding(lines)
            let! next = Binding(next)
            let! isOver = Binding(isOver)
            let! level = Binding(level)
            let! isLevelComplete = Binding(isLevelComplete)

            Grid(rowdefs = [ Star ], coldefs = [ Star ]) {
                Border(
                    AnyView(
                        VStack(16.) {
                            TextBlock("GAME OVER")
                                .fontSize(24.)
                                .fontWeight(FontWeight.Bold)
                                .foreground(Palette.overlayTitleFg)
                                .horizontalAlignment(HorizontalAlignment.Center)

                            (HStack(12.) {
                                statCard "SCORE" (string score.Current)
                                statCard "LEVEL" (string level.Current)
                                statCard "LINES" (string lines.Current)
                            })
                                .horizontalAlignment(HorizontalAlignment.Center)

                            Button(
                                "New Game",
                                fun _ ->
                                    tetrimino.Set(Tetrimino.generate true)
                                    grid.Set(Board.init)
                                    lastUpdated.Set(DateTime.Now)
                                    score.Set(0)
                                    lines.Set(0)
                                    next.Set(Tetrimino.generate false)
                                    isOver.Set(false)
                                    level.Set(1)
                                    isLevelComplete.Set(false)
                            )
                                .fontSize(16.)
                                .padding(8.)
                                .horizontalAlignment(HorizontalAlignment.Center)
                        }
                    )
                )
                    .padding(16.)
                    .cornerRadius(12.)
                    .background(Palette.cardBg)
                    .borderBrush(Palette.cardBorder)
                    .borderThickness(1.)
                    .maxWidth(420.)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
            }
            |> _.background(Palette.pageBg)
        }

    let levelCompleteView
        (score: StateValue<int>)
        (lines: StateValue<int>)
        (level: StateValue<int>)
        (isLevelComplete: StateValue<bool>)
        (lastUpdated: StateValue<DateTime>)
        =
        Component("LevelComplete") {
            let! score = Binding(score)
            let! lines = Binding(lines)
            let! level = Binding(level)
            let! isLevelComplete = Binding(isLevelComplete)
            let! lastUpdated = Binding(lastUpdated)

            Grid(rowdefs = [ Star ], coldefs = [ Star ]) {
                Border(
                    AnyView(
                        VStack(16.) {
                            TextBlock("LEVEL COMPLETE")
                                .fontSize(24.)
                                .fontWeight(FontWeight.Bold)
                                .foreground(Palette.overlayTitleFg)
                                .horizontalAlignment(HorizontalAlignment.Center)

                            (HStack(12.) {
                                statCard "SCORE" (string score.Current)
                                statCard "LEVEL" (string level.Current)
                                statCard "LINES" (string lines.Current)
                            })
                                .horizontalAlignment(HorizontalAlignment.Center)

                            Button(
                                "Next Level",
                                fun _ ->
                                    isLevelComplete.Set(false)
                                    // restart drop timer reference
                                    lastUpdated.Set(DateTime.Now)
                            )
                                .fontSize(16.)
                                .padding(8.)
                                .horizontalAlignment(HorizontalAlignment.Center)
                        }
                    )
                )
                    .padding(16.)
                    .cornerRadius(12.)
                    .background(Palette.cardBg)
                    .borderBrush(Palette.cardBorder)
                    .borderThickness(1.)
                    .maxWidth(420.)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
            }
            |> _.background(Palette.pageBg)
        }

    let private dropIntervalMs (level: int) =
        // Base 500ms, speed up 50ms per level, floor at 100ms
        let baseMs = 500
        let sped = baseMs - (max 0 (level - 1)) * 50
        max 100 sped

    let handleOnTickReceived
        (isOver: StateValue<bool>)
        (isLevelComplete: StateValue<bool>)
        (lastUpdated: StateValue<DateTime>)
        (grid: StateValue<Board>)
        (tetrimino: StateValue<Tetrimino>)
        (next: StateValue<Tetrimino>)
        (score: StateValue<int>)
        (lines: StateValue<int>)
        (level: StateValue<int>)
        =
        if
            isOver.Current
            || isLevelComplete.Current
            || (DateTime.Now - lastUpdated.Current).TotalMilliseconds < float(dropIntervalMs level.Current)
        then
            ()
        else
            let nxt = tetrimino.Current |> Tetrimino.moveDown grid.Current.board

            if tetrimino.Current <> nxt then
                lastUpdated.Set(DateTime.Now)
                tetrimino.Set(nxt)
            else
                let isHighLimitOver = nxt |> Tetrimino.isHighLimitOver

                if isHighLimitOver then
                    let existsOtherBlock = nxt |> Tetrimino.existsOtherBlock grid.Current.board
                    let res = grid.Current.board |> TetrisBoard.setTetrimino nxt
                    isOver.Set(true)

                    grid.Set(
                        { grid.Current with
                            board =
                                if existsOtherBlock then
                                    grid.Current.board
                                else
                                    res.newBoard }
                    )
                else
                    let res = grid.Current.board |> TetrisBoard.setTetrimino nxt

                    grid.Set(
                        { grid.Current with
                            board = res.newBoard }
                    )

                    tetrimino.Set(next.Current)
                    next.Set(Tetrimino.generate false)
                    lastUpdated.Set(DateTime.Now)
                    isOver.Set(tetrimino.Current |> Tetrimino.existsOtherBlock res.newBoard)

                    if res.eraced > 0 then
                        let addedScore =
                            match res.eraced with
                            | 1 -> 100
                            | 2 -> 300
                            | 3 -> 500
                            | 4 -> 800
                            | n -> n * 200

                        score.Set(score.Current + addedScore)
                        lines.Set(lines.Current + res.eraced)

                        let newLevel = (lines.Current / 10) + 1

                        if newLevel > level.Current then
                            level.Set(newLevel)
                            isLevelComplete.Set(true)


    let mainView () =
        Component("Tetris") {
            let! isOver = State(false)
            let! score = State(0)
            let! lines = State(0)
            let! grid = State(Board.init)
            let! tetrimino = State(Tetrimino.generate true)
            let! hold = State(Some(Tetrimino.initMino tetrimino.Current.shape))
            let! next = State(Tetrimino.generate false)
            let! lastUpdated = State(DateTime.Now)
            let! level = State(1)
            let! isLevelComplete = State(false)

            let timer =
                DispatcherTimer(Interval = TimeSpan.FromMilliseconds(10.), IsEnabled = true)

            let content =
                Grid() {
                    mobileLayout
                        isOver.Current
                        grid.Current
                        tetrimino.Current
                        next.Current
                        score.Current
                        lines.Current
                        level.Current
                        (applyControlActions grid tetrimino hold next lastUpdated score lines isOver)

                    if isOver.Current then
                        levelResultsOverView tetrimino grid lastUpdated score lines next isOver level isLevelComplete

                    if isLevelComplete.Current then
                        levelCompleteView score lines level isLevelComplete lastUpdated
                }

            AnyView(content)
                .onReceive(timer.Tick, (fun _ -> handleOnTickReceived isOver isLevelComplete lastUpdated grid tetrimino next score lines level))
        }

    let mainWindow () =
        Component("MainWindow") {
            let! isOver = State(false)
            let! score = State(0)
            let! lines = State(0)
            let! grid = State(Board.init)
            let! tetrimino = State(Tetrimino.generate true)
            let! hold = State(Some(Tetrimino.initMino tetrimino.Current.shape))
            let! next = State(Tetrimino.generate false)
            let! lastUpdated = State(DateTime.Now)
            let! level = State(1)
            let! isLevelComplete = State(false)

            let timer =
                DispatcherTimer(Interval = TimeSpan.FromMilliseconds(10.), IsEnabled = true)

            let content =
                Grid() {
                    desktopLayout isOver.Current grid.Current tetrimino.Current next.Current score.Current lines.Current level.Current

                    if isOver.Current then
                        levelResultsOverView tetrimino grid lastUpdated score lines next isOver level isLevelComplete

                    if isLevelComplete.Current then
                        levelCompleteView score lines level isLevelComplete lastUpdated
                }

            Window(content)
                .onReceive(timer.Tick, (fun _ -> handleOnTickReceived isOver isLevelComplete lastUpdated grid tetrimino next score lines level))
                .onKeyDown(fun e -> applyControlActions grid tetrimino hold next lastUpdated score lines isOver e.Key)
        }


    let view () =
        Component("TetrisApp") {
#if MOBILE
            SingleViewApplication(mainView())
#else
            DesktopApplication() { mainWindow() }
#endif
        }

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
