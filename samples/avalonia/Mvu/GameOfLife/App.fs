namespace GameOfLife

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

// Credits to https://github.com/fsprojects/Avalonia.FuncUI GameOfLife sample

module Array2D =
    let set (array: 't[,]) (x: int) (y: int) (value: 't) : 't[,] =
        let copy = Array2D.copy array
        Array2D.set copy x y value
        copy

    let flati (arr: 'a[,]) : (int * int * 'a)[] =
        [| for x in [ 0 .. (Array2D.length1 arr) - 1 ] do
               for y in [ 0 .. (Array2D.length2 arr) - 1 ] do
                   (x, y, arr.[x, y]) |]

type BoardPosition = { x: int; y: int }

module BoardPosition =

    let create (x: int, y: int) : BoardPosition = { x = x; y = y }

    let leftOf (pos: BoardPosition) : BoardPosition = { pos with x = pos.x - 1 }

    let rightOf (pos: BoardPosition) : BoardPosition = { pos with x = pos.x + 1 }

    // Match the typical UI coordinate system: y+1 is down (below), y-1 is up (above)
    let above (pos: BoardPosition) : BoardPosition = { pos with y = pos.y - 1 }

    let below (pos: BoardPosition) : BoardPosition = { pos with y = pos.y + 1 }

type Cell =
    | Alive
    | Dead

type BoardMatrix =
    { width: int
      height: int
      cells: Cell[,] }

module BoardMatrix =

    let private setCell (pos: BoardPosition, cell: Cell) (board: BoardMatrix) : BoardMatrix =
        { board with
            cells = Array2D.set board.cells pos.x pos.y cell }

    let private getCell (pos: BoardPosition) (board: BoardMatrix) : Cell = Array2D.get board.cells pos.x pos.y

    let private tryGetCell (board: BoardMatrix, pos: BoardPosition) : Cell option =
        let xInRange = pos.x >= 0 && pos.x < board.width
        let yInRange = pos.y >= 0 && pos.y < board.height

        if (xInRange && yInRange) then
            Some(Array2D.get board.cells pos.x pos.y)
        else
            None

    let constructBlank (width: int, height: int) : BoardMatrix =
        { width = width
          height = height
          cells = Array2D.create width height Dead }

    let constructBasic (width: int, height: int) : BoardMatrix =
        constructBlank(width, height)
        |> setCell(BoardPosition.create(2, 1), Alive)
        |> setCell(BoardPosition.create(3, 2), Alive)
        |> setCell(BoardPosition.create(1, 3), Alive)
        |> setCell(BoardPosition.create(2, 3), Alive)
        |> setCell(BoardPosition.create(3, 3), Alive)

    let private getNeighbors (board: BoardMatrix, pos: BoardPosition) : Cell list =
        let neighborPositions =
            [ pos |> BoardPosition.above
              pos |> BoardPosition.above |> BoardPosition.leftOf
              pos |> BoardPosition.above |> BoardPosition.rightOf
              pos |> BoardPosition.leftOf
              pos |> BoardPosition.rightOf
              pos |> BoardPosition.below
              pos |> BoardPosition.below |> BoardPosition.leftOf
              pos |> BoardPosition.below |> BoardPosition.rightOf ]

        neighborPositions
        |> List.map(fun pos -> tryGetCell(board, pos))
        |> List.map (function
            | None -> Dead
            | Some cell -> cell)

    let placeAliveCell (board: BoardMatrix, pos: BoardPosition) : BoardMatrix = board |> setCell(pos, Alive)

    let placeDeadCell (board: BoardMatrix, pos: BoardPosition) : BoardMatrix = board |> setCell(pos, Dead)

    // Helpers for checking cell state were unused; remove to reduce noise

    let evolveCellDead (neighbors: Cell list) : Cell =
        let aliveNeighbors =
            neighbors |> List.filter(fun cell -> cell = Alive) |> List.length

        match aliveNeighbors with
        | 3 -> Alive
        | _ -> Dead

    let evolveCellAlive (neighbors: Cell list) : Cell =
        let aliveNeighbors =
            neighbors |> List.filter(fun cell -> cell = Alive) |> List.length

        match aliveNeighbors with
        | 0
        | 1 -> Dead
        | 2
        | 3 -> Alive
        | _ -> Dead

    let evolveCell (board: BoardMatrix, pos: BoardPosition, self: Cell) : Cell =
        let neighbors = getNeighbors(board, pos)

        match self with
        | Dead -> evolveCellDead neighbors
        | Alive -> evolveCellAlive neighbors

    let evolve (board: BoardMatrix) : BoardMatrix =
        let apply x y cell =
            evolveCell(board, { x = x; y = y }, cell)

        { board with
            cells = board.cells |> Array2D.mapi apply }

module Board =

    type Msg =
        | Evolve
        | KillCell of BoardPosition
        | ReviveCell of BoardPosition

    let update (msg: Msg) (board: BoardMatrix) : BoardMatrix =
        match msg with
        | Evolve -> BoardMatrix.evolve board
        | KillCell pos -> BoardMatrix.placeDeadCell(board, pos)
        | ReviveCell pos -> BoardMatrix.placeAliveCell(board, pos)

    let view (board: BoardMatrix) =
        UniformGrid(board.width, board.height) {
            for x, y, cell in Array2D.flati board.cells do
                let cellPosition = { x = x; y = y }

                match cell with
                | Alive ->
                    Rectangle()
                        .fill(SolidColorBrush(Colors.Green))
                        .onTapped(fun _ -> KillCell cellPosition)
                | Dead ->
                    Rectangle()
                        .fill(SolidColorBrush(Colors.Gray))
                        .onTapped(fun _ -> ReviveCell cellPosition)
        }

module App =

    type Model =
        { board: BoardMatrix
          evolutionRunning: bool }

    let init () =
        { board = BoardMatrix.constructBasic(50, 50)
          evolutionRunning = false },
        Cmd.none

    type Msg =
        | BoardMsg of Board.Msg
        | StartEvolution
        | StopEvolution

    let subscription (model: Model) =
        let key = "evolutionTimer"

        if model.evolutionRunning then
            let timeSub dispatch =
                DispatcherTimer.Run(
                    Func<bool>(fun _ ->
                        dispatch(BoardMsg(Board.Evolve))
                        true),
                    TimeSpan.FromMilliseconds 100.0
                )

            [ [ key ], timeSub ]
        else
            []

    let update msg model =
        match msg with
        | StartEvolution -> { model with evolutionRunning = true }, Cmd.none
        | StopEvolution -> { model with evolutionRunning = false }, Cmd.none
        | BoardMsg msg ->
            match msg with
            | Board.Evolve ->
                if model.evolutionRunning then
                    { model with
                        board = Board.update msg model.board },
                    Cmd.none
                else
                    model, Cmd.none
            | _ ->
                { model with
                    board = Board.update msg model.board },
                Cmd.none

    let content (model: Model) =
        (Dock() {
            Button("Start", StartEvolution)
                .horizontalAlignment(HorizontalAlignment.Stretch)
                .horizontalContentAlignment(HorizontalAlignment.Center)
                .dock(Dock.Bottom)
                .isVisible(not model.evolutionRunning)
                .background("#16a085")

            Button("Stop", StopEvolution)
                .horizontalAlignment(HorizontalAlignment.Stretch)
                .horizontalContentAlignment(HorizontalAlignment.Center)
                .dock(Dock.Bottom)
                .isVisible(model.evolutionRunning)
                .background("#d35400")

            View.map BoardMsg (Board.view model.board)
        })
            .margin(0., 50., 0., 50.)

    let view model =
#if MOBILE
        SingleViewApplication(content model)
#else
        DesktopApplication() { Window(content model) }
#endif
    let create () =
        let theme () = FluentTheme()

        let program =
            Program.statefulWithCmd init update
            |> Program.withSubscription subscription
            |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, args))
            |> Program.withExceptionHandler(fun ex ->
#if DEBUG
                printfn $"Exception: %s{ex.ToString()}"
                false
#else
                true
#endif
            )
            |> Program.withView view

        FabulousAppBuilder.Configure(theme, program)
