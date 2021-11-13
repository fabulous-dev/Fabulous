namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module ViewUpdaters =
    let updateSliderMinMax struct (newValueOpt: (float * float) voption, target: obj) =
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

    let updateGridColumnDefinitions struct (newValueOpt: Dimension[] voption, target: obj) =
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

    let updateGridRowDefinitions struct (newValueOpt: Dimension[] voption, target: obj) =
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
                    | Stars x -> GridLength(x, Xamarin.Forms.GridUnitType.Star)
                    | Absolute x -> GridLength(x, Xamarin.Forms.GridUnitType.Absolute)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

    let applyDiffNavigationPagePages struct (diffs: WidgetCollectionChange[], target: obj) =
        let viewNode = ViewNode.getViewNode target :?> ViewNode
        let navigationPage = target :?> NavigationPage
        let pages = List.ofSeq navigationPage.Pages

        for diff in diffs do
            match diff with
            | WidgetCollectionChange.Insert (index, widget) -> failwith "not implemented"

            | WidgetCollectionChange.Update (index, changes) ->
                let targetItem = pages.[index]
                let viewNode = ViewNode.getViewNode targetItem
                viewNode.ApplyDiff(changes)

            | WidgetCollectionChange.Replace (index, widget) -> failwith "not implemented"

            | _ -> ()

    let updateNavigationPagePages struct (newValueOpt: Widget[] voption, target: obj) =
        let navigationPage = target :?> NavigationPage
        navigationPage.PopToRootAsync(false) |> ignore

        match newValueOpt with
        | ValueNone -> ()
        | ValueSome widgets ->
            let viewNode = ViewNode.getViewNode target :?> ViewNode
            for widget in widgets do
                let page = Helpers.createViewForWidget viewNode.Context widget :?> Page
                navigationPage.PushAsync(page) |> ignore