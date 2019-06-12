// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabimals.Views

open Fabimals.Data
open Fabimals.Components

module Dogs =
    let init () =
        AnimalList.init "Dogs" true Dogs.data

    let update msg model =
        AnimalList.update msg model

    let view model dispatch =
        AnimalList.view model dispatch
        
module DogDetails =
    let init dog =
        AnimalDetails.init dog
    
    let view model =
        AnimalDetails.view model