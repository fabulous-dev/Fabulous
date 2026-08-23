namespace TicTacToe.WinUI

open System

module Program =
    [<EntryPoint; STAThread>]
    let main args =
        do FSharp.Maui.WinUICompat.Program.Main(args, typeof<TicTacToe.WinUI.App>)
        0
