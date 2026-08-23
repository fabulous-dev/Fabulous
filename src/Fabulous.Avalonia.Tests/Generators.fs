namespace Fabulous.Avalonia.Tests

open FsCheck

module Generators =
    let nonNullString = Arb.generate<string> |> Gen.where(fun v -> v <> null)
