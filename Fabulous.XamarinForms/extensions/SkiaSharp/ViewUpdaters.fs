namespace Fabulous.XamarinForms.SkiaSharp

[<AutoOpen>]
module ViewUpdaters =
    let updateSKCanvasViewInvalidate _ (currOpt: bool voption) (target: SkiaSharp.Views.Forms.SKCanvasView) =
        match currOpt with
        | ValueSome true -> target.InvalidateSurface()
        | _ -> ()
    let updateSKGLViewInvalidate _ (currOpt: bool voption) (target: SkiaSharp.Views.Forms.SKGLView) =
        match currOpt with
        | ValueSome true -> target.InvalidateSurface()
        | _ -> ()
