// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Helpers =
    let removeText textToRemove (originalStr: string) =
        originalStr.Replace(textToRemove, "")

    let toOption value =
        match value with
        | null -> None
        | _ -> Some value