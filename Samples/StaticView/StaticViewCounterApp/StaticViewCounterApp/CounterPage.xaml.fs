// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace StaticViewCounterApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type CounterPage() = 
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<CounterPage>)
