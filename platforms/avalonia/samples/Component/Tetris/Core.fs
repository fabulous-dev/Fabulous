namespace Tetris

type Shape =
    | I
    | O
    | S
    | Z
    | J
    | L
    | T

type Cell =
    | Empty
    | Guard
    | Mino of Shape

type TetrisBoard = Cell[,]

type Tetrimino =
    { x: int
      y: int
      pos: (int * int)[]
      shape: Shape }

    static member init =
        { x = 0
          y = 0
          pos = [||]
          shape = Shape.I }

module TetrisBoard =

    let init =
        Array2D.init 24 16 (fun y x ->
            if (3 <= x && x <= 12 && 0 <= y && y <= 21) then
                Cell.Empty
            else
                Cell.Guard)

    let isFilled x y (board: TetrisBoard) =
        board[y, x]
        |> function
            | Empty -> false
            | _ -> true

    let setTetrimino mino board =
        let nxt = board |> Array2D.copy

        mino.pos
        |> Array.iter(fun (dx, dy) -> nxt[mino.y + dy, mino.x + dx] <- Mino mino.shape)

        let mutable dy = 0

        let dif =
            List.rev
                [ yield 23
                  yield 22
                  for y in 21..-1..2 do
                      let isLineFilled = [ 3..12 ] |> List.forall(fun x -> isFilled x y nxt)

                      if isLineFilled then
                          for x in 3..12 do
                              nxt[y, x] <- Empty

                          yield y
                          dy <- dy + 1
                      else
                          yield y + dy
                  yield 1
                  yield 0 ]

        for y in 21..-1..0 do
            for x in 3..12 do
                nxt[dif[y], x] <- nxt[y, x]

        {| newBoard = nxt; eraced = dy |}


module Tetrimino =

    let private highLimit = 3

    let initMino =
        function
        | I ->
            { x = 7
              y = 2
              shape = Shape.I
              pos = [| (0, 0); (-1, 0); (1, 0); (2, 0) |] }
        | O ->
            { x = 7
              y = 2
              shape = Shape.O
              pos = [| (0, 0); (1, 0); (0, -1); (1, -1) |] }
        | S ->
            { x = 7
              y = 2
              shape = Shape.S
              pos = [| (0, 0); (-1, 0); (0, -1); (1, -1) |] }
        | Z ->
            { x = 7
              y = 2
              shape = Shape.Z
              pos = [| (0, 0); (-1, -1); (0, -1); (1, 0) |] }
        | J ->
            { x = 7
              y = 2
              shape = Shape.J
              pos = [| (0, 0); (1, 0); (-1, 0); (-1, -1) |] }
        | L ->
            { x = 7
              y = 2
              shape = Shape.L
              pos = [| (0, 0); (1, 0); (-1, 0); (1, -1) |] }
        | T ->
            { x = 7
              y = 2
              shape = Shape.T
              pos = [| (0, 0); (-1, 0); (1, 0); (0, 1) |] }

    let isHighLimitOver mino =
        mino.pos |> Array.exists(fun (_, y) -> mino.y + y <= highLimit)

    let existsOtherBlock board mino =
        mino.pos
        |> Array.exists(fun (dx, dy) -> board |> TetrisBoard.isFilled (mino.x + dx) (mino.y + dy))

    let moveDown board mino =
        let nxt = { mino with y = mino.y + 1 }

        nxt
        |> existsOtherBlock board
        |> function
            | false -> nxt
            | true -> mino

    let moveRight board mino =
        let nxt = { mino with x = mino.x + 1 }

        nxt
        |> existsOtherBlock board
        |> function
            | false -> nxt
            | true -> mino

    let moveLeft board mino =
        let nxt = { mino with x = mino.x - 1 }

        nxt
        |> existsOtherBlock board
        |> function
            | false -> nxt
            | true -> mino


    let rotateRight board mino = // https://tetrisch.github.io/main/spins.html
        if mino.shape = Shape.O then
            mino
        else
            let pos =
                [| for dx, dy in mino.pos do
                       (-dy, dx) |]

            let r_asixs =
                match mino.shape with
                | Shape.T ->
                    match mino.pos[3] with
                    | 0, 1 -> [ mino.pos[0]; mino.pos[3]; (-1, 1); (-1, 2) ]
                    | -1, 0 -> [ mino.pos[0]; mino.pos[3] ]
                    | 0, -1 -> [ mino.pos[0]; mino.pos[2] ]
                    | _ -> [ mino.pos[0]; mino.pos[3] ]
                | Shape.S ->
                    match mino.pos[1] with
                    | 0, -1 -> [ mino.pos[0]; (0, 1) ]
                    | _ -> [ (0, 0) ]
                | Shape.Z ->
                    match mino.pos[3] with
                    | 1, 0 -> [ mino.pos[0]; (-1, -1) ]
                    | _ -> [ (0, 0) ]
                | Shape.L ->
                    match mino.pos[2] with
                    | 0, 1 -> [ mino.pos[0]; (-1, 0) ]
                    | 0, -1 -> [ mino.pos[0]; mino.pos[1] ]
                    | 1, 0 -> [ mino.pos[0]; mino.pos[2]; (-1, 1) ] // before: | (-1,0)
                    | _ -> [ (0, 0) ]
                | Shape.J ->
                    match mino.pos[1] with
                    | 0, 1 -> [ mino.pos[0]; mino.pos[1] ]
                    | _ -> [ (0, 0) ]
                | Shape.I ->
                    match mino.pos[1] with
                    | -1, 0 -> [ mino.pos[0]; mino.pos[1] ]
                    | 0, 1 -> [ mino.pos[0]; mino.pos[1] ]
                    | _ -> [ (0, 0) ]
                | _ -> [ (0, 0) ]

            let rec loop =
                function
                | [] -> mino
                | (mx, my) :: t ->
                    let rec loop2 =
                        function
                        | [] -> loop t
                        | (hx, hy) :: t2 ->
                            let cx, cy = mino.x + hx + hy, mino.y + hy - hx
                            let nx, ny = cx + mx, cy + my

                            pos
                            |> Array.exists(fun (dx, dy) -> board |> TetrisBoard.isFilled (nx + dx) (ny + dy))
                            |> function
                                | true -> loop2 t2
                                | false -> { mino with x = nx; y = ny; pos = pos }

                    loop2 r_asixs

            let moved =
                loop [ (0, 0); (0, 1); (-1, 0); (1, 0); (0, -1); (2, 0); (0, -2); (-2, 0); (0, 2) ]

            let modify = // 高さの調整
                if moved.y < mino.y then { moved with y = moved.y + 1 }
                elif moved.y > mino.y then { moved with y = moved.y - 1 }
                else moved

            modify
            |> existsOtherBlock board
            |> function
                | false -> modify
                | true -> moved

    let rotateLeft board mino =
        if mino.shape = Shape.O then
            mino
        else
            let pos =
                [| for dx, dy in mino.pos do
                       (dy, -dx) |]

            let r_asixs =
                match mino.shape with
                | Shape.T ->
                    match mino.pos[3] with
                    | 0, 1 -> [ mino.pos[0]; mino.pos[3]; (1, 1); (1, 2) ]
                    | -1, 0 -> [ mino.pos[0]; mino.pos[3] ]
                    | 0, -1 -> [ mino.pos[0]; mino.pos[1] ]
                    | _ -> [ mino.pos[0]; mino.pos[3] ] // (1,0)
                | Shape.S ->
                    match mino.pos[1] with
                    | -1, 0 -> [ mino.pos[0]; (1, 1) ]
                    | _ -> [ (0, 0) ]
                | Shape.Z ->
                    match mino.pos[3] with
                    | 0, 1 -> [ mino.pos[0]; (1, 1) ]
                    | _ -> [ (0, 0) ]
                | Shape.L ->
                    match mino.pos[2] with
                    | 0, 1 -> [ mino.pos[0]; mino.pos[2] ]
                    | _ -> [ (0, 0) ]
                | Shape.J ->
                    match mino.pos[1] with
                    | 0, 1 -> [ mino.pos[0]; (1, 0) ]
                    | 0, -1 -> [ mino.pos[0]; mino.pos[2] ]
                    | -1, 0 -> [ mino.pos[0]; mino.pos[1]; (1, 1) ]
                    | _ -> [ (0, 0) ]
                | Shape.I ->
                    match mino.pos[1] with
                    | 1, 0 -> [ mino.pos[0]; mino.pos[1] ]
                    | 0, 1 -> [ mino.pos[0]; mino.pos[1] ]
                    | _ -> [ (0, 0) ]
                | _ -> [ (0, 0) ]

            let rec loop =
                function
                | [] -> mino
                | (mx, my) :: t ->
                    let rec loop2 =
                        function
                        | [] -> loop t
                        | (hx, hy) :: t2 ->
                            let cx, cy = mino.x + hx - hy, mino.y + hy + hx
                            let nx, ny = cx + mx, cy + my

                            pos
                            |> Array.exists(fun (dx, dy) -> board |> TetrisBoard.isFilled (nx + dx) (ny + dy))
                            |> function
                                | false -> { mino with x = nx; y = ny; pos = pos }
                                | true -> loop2 t2

                    loop2 r_asixs

            let moved =
                loop [ (0, 0); (0, 1); (-1, 0); (1, 0); (0, -1); (2, 0); (0, -2); (-2, 0); (0, 2) ]

            let modified =
                if moved.y < mino.y then { moved with y = moved.y + 1 }
                elif moved.y > mino.y then { moved with y = moved.y - 1 }
                else moved

            modified
            |> existsOtherBlock board
            |> function
                | false -> modified
                | true -> moved

    let generate =
        let mutable queue = []
        let random = System.Random()

        let blocks =
            [| initMino Shape.I
               initMino Shape.O
               initMino Shape.S
               initMino Shape.Z
               initMino Shape.J
               initMino Shape.L
               initMino Shape.T |]

        fun reset ->
            if reset then
                queue <- []

            match queue with
            | [] ->
                let b = blocks

                for i in 0 .. blocks.Length - 1 do
                    let r = random.Next(0, blocks.Length)
                    let tmp = b[i]
                    b[i] <- b[r]
                    b[r] <- tmp

                queue <- Array.toList b[1 .. b.Length - 1]
                b[0]
            | h :: t ->
                queue <- t
                h

type Board =
    { width: int
      height: int
      board: TetrisBoard }

module Board =
    let init =
        { width = 16
          height = 24
          board = TetrisBoard.init }
