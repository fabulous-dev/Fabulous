[<AutoOpen>]
module Fable
    [<AutoOpen>]
    module PowerPack = ()
    [<AutoOpen>]
    module Core = 
        [<AutoOpen>] 
        module JsInterop = ()
    [<AutoOpen>]
    module Import =
        [<AutoOpen>] 
        module Browser =
            [<AutoOpen>]
            type console =

                [<System.Diagnostics.Conditional("DEBUG")>]
                static member error (str, ex) = sprintf "%s: %O" str ex |> System.Console.WriteLine

                [<System.Diagnostics.Conditional("DEBUG")>]
                static member log (o: string) = sprintf "%s -- %A" (System.DateTime.Now.ToString("o")) o |> System.Console.WriteLine

                [<System.Diagnostics.Conditional("DEBUG")>]
                static member log (o: string, v:obj) = sprintf "%s -- %s %A" (System.DateTime.Now.ToString("o")) o v |> System.Console.WriteLine

            let toJson o = o

        [<AutoOpen>] 
        module JS =
            [<AutoOpen>]

            module JSON =
                let parse str = str
            type Promise() = class end
            type Promise<'T>() = 
                inherit Promise()
                with
                    static member map _ = failwith "Promise not supported"
                    static member catch _ = failwith "Promise not supported"