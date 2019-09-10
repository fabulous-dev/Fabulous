namespace AllControls.Droid

open Xamarin.Forms

module RegisterEffects =
    [<assembly: ResolutionGroupName("FabulousXamarinForms")>]
    [<assembly: ExportEffect(typeof<FocusEffect>, "FocusEffect")>]
    [<assembly: ExportEffect(typeof<LabelShadowEffect>, "ShadowEffect")>]
    do ()

