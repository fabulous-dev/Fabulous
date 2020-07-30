// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace ShapesDemo

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App = 

    // Note, this declaration is needed if you enable LiveUpdate
    let program = XamarinFormsProgram.mkProgram AnalogClockDemoPage.init AnalogClockDemoPage.update AnalogClockDemoPage.view

type App () as app = 
    inherit Application ()
    
    do Device.SetFlags([| "Shapes_Experimental"; "AppTheme_Experimental" |]);

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app
