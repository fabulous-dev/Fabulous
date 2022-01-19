module Tests.TestUI_ViewUpdaters

open Fabulous
open Tests.Platform


//let applyDiffNavigationPagePages (diffs: WidgetCollectionItemChange[], target: obj) =
//        let viewNode = ViewNode.getViewNode target :?> ViewNode
//        let navigationPage = target :?> NavigationPage
//        let pages = List.ofSeq navigationPage.Pages
//
//        for diff in diffs do
//            match diff with
//            | WidgetCollectionItemChange.Insert (index, widget) -> failwith "not implemented"
//
//            | WidgetCollectionItemChange.Update (index, diff) ->
//                let targetItem = pages.[index]
//                let viewNode = ViewNode.getViewNode targetItem
//                if diff.ScalarChanges.Length > 0 then viewNode.ApplyScalarDiff(diff.ScalarChanges)
//                if diff.WidgetChanges.Length > 0 then viewNode.ApplyWidgetDiff(diff.WidgetChanges)
//                if diff.WidgetCollectionChanges.Length > 0 then viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)
//
//            | WidgetCollectionItemChange.Replace (index, widget) -> failwith "not implemented"
//
//            | _ -> ()
//
//let updateNavigationPagePages (newValueOpt: Widget[] voption, target: obj) =
//    let navigationPage = target :?> NavigationPage
//    navigationPage.PopToRootAsync(false) |> ignore
//
//    match newValueOpt with
//    | ValueNone -> ()
//    | ValueSome widgets ->
//        let viewNode = ViewNode.getViewNode target :?> ViewNode
//        for widget in widgets do
//            let page = Helpers.createViewForWidget viewNode.Context widget :?> Page
//            navigationPage.PushAsync(page) |> ignore


let updateText (newValueOpt: string voption) (node: IViewNode) =
    let textElement = node.Target :?> IText
    textElement.Text <- ValueOption.defaultValue "" newValueOpt

let updateRecord (newValueOpt: bool voption) (node: IViewNode) =
    let textElement = node.Target :?> TestLabel
    textElement.record <- ValueOption.defaultValue false newValueOpt

let updateTextColor (newValueOpt: string voption) (node: IViewNode) =
    let textElement = node.Target :?> IText
    textElement.TextColor <- ValueOption.defaultValue "" newValueOpt

let updateAutomationId (newValueOpt: string voption) (node: IViewNode) =
    let el = node.Target :?> TestViewElement
    el.AutomationId <- ValueOption.defaultValue "" newValueOpt


//let applyDiffContainerChildren (diffs: WidgetCollectionItemChange [], target: obj) =
//    // let el = target :?> TestViewElement
//    let container = target :?> IContainer
//    let children = List.ofSeq container.Children
//
//    for diff in diffs do
//        match diff with
//        | WidgetCollectionItemChange.Insert (index, widget) -> failwith "not implemented"
//
//        | WidgetCollectionItemChange.Update (index, diff) ->
//            let targetItem = children.[index]
//
//            let viewNode =
//                context.ViewTreeContext.GetViewNode(box targetItem)
//
//            if diff.ScalarChanges.Length > 0 then
//                viewNode.ApplyScalarDiff(diff.ScalarChanges)
//
//            if diff.WidgetChanges.Length > 0 then
//                viewNode.ApplyWidgetDiff(diff.WidgetChanges)
//
//            if diff.WidgetCollectionChanges.Length > 0 then
//                viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)
//
//        | WidgetCollectionItemChange.Replace (index, widget) -> failwith "not implemented"
//
//        | _ -> ()

//let updateContainerChildren (newValueOpt: Widget [] voption, target: obj) =
//    let container = target :?> IContainer
//
//    match newValueOpt with
//    | ValueNone -> container.Children.Clear()
//    | ValueSome widgets ->
//        for widget in widgets do
//            container.Children.Add(
//                Helpers.createViewForWidget(context.ViewTreeContext.GetViewNode target) widget :?> TestViewElement
//            )
