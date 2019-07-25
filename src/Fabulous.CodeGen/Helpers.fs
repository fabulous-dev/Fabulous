// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Helpers =
    let removeText textToRemove (originalStr: string) =
        originalStr.Replace(textToRemove, "")

    let toOption value =
        match value with
        | null -> None
        | _ -> Some value
        
    let trimNonSignificantZeros (str: string) =
        str.TrimEnd('0')
        
    type MaybeBuilder() =
        member this.Bind(x, f) = 
            match x with
            | None -> None
            | Some a -> f a

        member this.Return(x) = 
            Some x
       
    let maybe = new MaybeBuilder()

