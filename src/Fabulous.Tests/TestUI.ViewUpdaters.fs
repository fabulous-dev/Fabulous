module Tests.TestUI_ViewUpdaters

open Fabulous
open Tests.Platform

let updateText _ (newValueOpt: string voption) (node: IViewNode) =
    let textElement = node.Target :?> IText
    textElement.Text <- ValueOption.defaultValue "" newValueOpt

let updateRecord _ (newValueOpt: bool voption) (node: IViewNode) =
    let textElement = node.Target :?> TestLabel
    textElement.record <- ValueOption.defaultValue false newValueOpt

let updateTextColor _ (newValueOpt: string voption) (node: IViewNode) =
    let textElement = node.Target :?> IText
    textElement.TextColor <- ValueOption.defaultValue "" newValueOpt

let updateAutomationId _ (newValueOpt: string voption) (node: IViewNode) =
    let el = node.Target :?> TestViewElement
    el.AutomationId <- ValueOption.defaultValue "" newValueOpt
    
    
let updateNumericValueOne _ (newValueOpt: uint64 voption) (node: IViewNode) =
    let el = node.Target :?> TestNumericBag
    el.valueOne <- ValueOption.defaultValue 0UL newValueOpt
    
let updateNumericValueTwo _ (newValueOpt: uint64 voption) (node: IViewNode) =
    let el = node.Target :?> TestNumericBag
    el.valueTwo <- ValueOption.defaultValue 0UL newValueOpt
    
let updateNumericValueThree _ (newValueOpt: float voption) (node: IViewNode) =
    let el = node.Target :?> TestNumericBag
    el.valueThree <- ValueOption.defaultValue 0. newValueOpt
    

