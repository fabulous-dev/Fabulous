// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace AllControls.Droid

open Android.App
open Android.Content.PM
open Android.OS
open Xamarin.Forms.Platform.Android
open System

[<Activity (Label = "AllControls.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsApplicationActivity()

    let mutable _app: AllControls.App option = None

    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        global.Xamarin.Forms.Forms.SetFlags([|"Shell_Experimental"; "CollectionView_Experimental"; "Visual_Experimental"; 
                                                "IndicatorView_Experimental"; "SwipeView_Experimental"|])
        
        Xamarin.Forms.Forms.Init (this, bundle)
        Xamarin.FormsMaps.Init(this, bundle) 
        OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init()
        FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer=Nullable true)

        let app = AllControls.App()
        this.LoadApplication(app)
        _app <- Some app

    override this.OnTrimMemory(level) =
        match _app with
        | Some app -> app.Program.Dispatch(AllControls.App.Msg.LowMemoryWarningReceived)
        | None -> ()

