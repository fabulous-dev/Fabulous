// Copyright 2018 Elmish and Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Core

/// Helpers for the type Async
module internal AsyncHelpers =

    /// Elevates a value to Async
    let returnAsync x = async {
        return x
    }

    /// Elevates a function to Async
    let applyAsync f =
        fun g -> async { let! aVal = g in return (f aVal) }
                
/// Helpers for the types Option and ValueOption
module internal OptionHelpers =

    /// Map an Option to a ValueOption
    let convertToValueOption =
        function
        | None -> ValueNone
        | Some x -> ValueSome x

    /// Elevates the output of function to ValueOption
    let mapValueOption f =
        function
        | ValueNone -> ValueNone
        | ValueSome value -> ValueSome (f value)