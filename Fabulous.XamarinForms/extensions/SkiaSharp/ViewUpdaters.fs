namespace Fabulous.XamarinForms.SkiaSharp

[<AutoOpen>]
module ViewUpdaters =
    let updateSKCanvasViewInvalidate _ _ (currOpt: bool voption) (target: SkiaSharp.Views.Forms.SKCanvasView) =
        match currOpt with
        | ValueSome true -> target.InvalidateSurface()
        | _ -> ()

