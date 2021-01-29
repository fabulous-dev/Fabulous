// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.OxyPlot

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let ModelAttribKey : AttributeKey<_> = AttributeKey<OxyPlot.PlotModel>("Model")
    let ControllerAttribKey : AttributeKey<_> = AttributeKey<OxyPlot.PlotController>("Controller")

