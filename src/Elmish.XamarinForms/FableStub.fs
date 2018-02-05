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
            module console =
                let error (str,ex) = printfn "%s: %O" str ex
                let log o = printfn "%s -- %A" (System.DateTime.Now.ToString("o")) o
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