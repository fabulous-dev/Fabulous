// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Views

open Fabimals.Data
open Fabimals.Components

module Monkeys =
    let init () =
        AnimalList.init "Monkeys" false Monkeys.data

    let update msg model =
        AnimalList.update msg model

    let view model dispatch =
        AnimalList.view model dispatch
        
module MonkeyDetails =
    let init monkey =
        AnimalDetails.init monkey
    
    let view model =
        AnimalDetails.view model