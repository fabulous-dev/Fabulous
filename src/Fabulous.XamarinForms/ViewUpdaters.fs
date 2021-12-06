namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module ViewUpdaters =
    let updateSliderMinMax (newValueOpt: (float * float) voption, _viewNode, target: obj) =
        let slider = target :?> Slider
        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(Slider.MinimumProperty)
            slider.ClearValue(Slider.MaximumProperty)
        | ValueSome (min, max) ->
            let currMax = slider.GetValue(Slider.MaximumProperty) :?> float
            if min > currMax then
                slider.SetValue(Slider.MaximumProperty, max)
                slider.SetValue(Slider.MinimumProperty, min)
            else
                slider.SetValue(Slider.MinimumProperty, min)
                slider.SetValue(Slider.MaximumProperty, max)

    let updateGridColumnDefinitions (newValueOpt: Dimension[] voption, _viewNode, target: obj) =
        let grid = target :?> Grid
        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

    let updateGridRowDefinitions (newValueOpt: Dimension[] voption, _viewNode, target: obj) =
        let grid = target :?> Grid
        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

    /// NOTE: Would be better to have a custom diff logic for Navigation
    /// because it's a Stack and not a random access collection
    let applyDiffNavigationPagePages (diffs: WidgetCollectionItemChange[], target: obj) =
        let viewNode = ViewNode.getViewNode target
        let navigationPage = target :?> NavigationPage
        let pages = List.ofSeq navigationPage.Pages

        for diff in diffs do
            match diff with
            | WidgetCollectionItemChange.Insert (index, widget) ->
                if index >= pages.Length then
                    let page = Helpers.createViewForWidget viewNode widget :?> Page
                    navigationPage.PushAsync(page) |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Xamarin.Forms.Page>()
                    
                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore
                    
                    let page = Helpers.createViewForWidget viewNode widget :?> Page
                    navigationPage.PushAsync(page, false) |> ignore
                    
                    while temp.Count > 0  do
                        navigationPage.PushAsync(temp.Pop(), false) |> ignore
                        
            | WidgetCollectionItemChange.Update (index, diff) ->
                let targetItem = pages.[index]
                let viewNode = ViewNode.getViewNode targetItem
                if diff.ScalarChanges.Length > 0 then viewNode.ApplyScalarDiff(diff.ScalarChanges)
                if diff.WidgetChanges.Length > 0 then viewNode.ApplyWidgetDiff(diff.WidgetChanges)
                if diff.WidgetCollectionChanges.Length > 0 then viewNode.ApplyWidgetCollectionDiff(diff.WidgetCollectionChanges)

            | WidgetCollectionItemChange.Replace (index, widget) ->
                if index = pages.Length - 1 then
                    navigationPage.PopAsync() |> ignore
                    let page = Helpers.createViewForWidget viewNode widget :?> Page
                    navigationPage.PushAsync(page) |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Xamarin.Forms.Page>()
                    
                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore
                    
                    let page = Helpers.createViewForWidget viewNode widget :?> Page
                    navigationPage.PushAsync(page, false) |> ignore
                    
                    while temp.Count > 1 do
                        navigationPage.PushAsync(temp.Pop(), false) |> ignore
                        
            | WidgetCollectionItemChange.Remove index ->
                if index = pages.Length - 1 then
                   navigationPage.PopAsync() |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Xamarin.Forms.Page>()
                    
                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore
                    
                    while temp.Count > 1 do
                        navigationPage.PushAsync(temp.Pop(), false) |> ignore

    let updateNavigationPagePages (newValueOpt: Widget[] voption, _viewNode, target: obj) =
        let navigationPage = target :?> NavigationPage
        navigationPage.PopToRootAsync(false) |> ignore

        match newValueOpt with
        | ValueNone -> ()
        | ValueSome widgets ->
            let viewNode = ViewNode.getViewNode target
            for widget in widgets do
                let page = Helpers.createViewForWidget viewNode widget :?> Page
                navigationPage.PushAsync(page) |> ignore