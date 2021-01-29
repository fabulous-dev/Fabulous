// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.SkiaSharp

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let PaintSurfaceAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs>>("PaintSurface")
    let TouchAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<SkiaSharp.Views.Forms.SKTouchEventArgs>>("Touch")
    let IgnorePixelScalingAttribKey : AttributeKey<_> = AttributeKey<bool>("IgnorePixelScaling")
    let EnableTouchEventsAttribKey : AttributeKey<_> = AttributeKey<bool>("EnableTouchEvents")
    let InvalidateAttribKey : AttributeKey<_> = AttributeKey<bool>("Invalidate")

