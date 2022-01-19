namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module ViewUpdaters =
    let updateSliderMinMax (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let slider = node.Target :?> Slider

        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(Slider.MinimumProperty)
            slider.ClearValue(Slider.MaximumProperty)
        | ValueSome (min, max) ->
            let currMax =
                slider.GetValue(Slider.MaximumProperty) :?> float

            if min > currMax then
                slider.SetValue(Slider.MaximumProperty, max)
                slider.SetValue(Slider.MinimumProperty, min)
            else
                slider.SetValue(Slider.MinimumProperty, min)
                slider.SetValue(Slider.MaximumProperty, max)

    let updateStepperMinMax (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let stepper = node.Target :?> Stepper

        match newValueOpt with
        | ValueNone ->
            stepper.ClearValue(Stepper.MinimumProperty)
            stepper.ClearValue(Stepper.MaximumProperty)
        | ValueSome (min, max) ->
            let currMax =
                stepper.GetValue(Stepper.MaximumProperty) :?> float

            if min > currMax then
                stepper.SetValue(Stepper.MaximumProperty, max)
                stepper.SetValue(Stepper.MinimumProperty, min)
            else
                stepper.SetValue(Stepper.MinimumProperty, min)
                stepper.SetValue(Stepper.MaximumProperty, max)

    let updateGridColumnDefinitions (newValueOpt: Dimension [] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

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

    let updateGridRowDefinitions (newValueOpt: Dimension [] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

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
    let applyDiffNavigationPagePages (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
        let navigationPage = node.Target :?> NavigationPage
        let pages = List.ofSeq navigationPage.Pages

        for diff in diffs do
            match diff with
            | WidgetCollectionItemChange.Insert (index, widget) ->
                if index >= pages.Length then
                    let page =
                        Helpers.createViewForWidget node widget :?> Page

                    navigationPage.PushAsync(page) |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Page>()

                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore

                    let page =
                        Helpers.createViewForWidget node widget :?> Page

                    navigationPage.PushAsync(page, false) |> ignore

                    while temp.Count > 0 do
                        navigationPage.PushAsync(temp.Pop(), false)
                        |> ignore

            | WidgetCollectionItemChange.Update (index, diff) ->
                let childNode =
                    node.TreeContext.GetViewNode(box pages.[index])

                childNode.ApplyDiff(&diff)


            | WidgetCollectionItemChange.Replace (index, widget) ->
                if index = pages.Length - 1 then
                    navigationPage.PopAsync() |> ignore

                    let page =
                        Helpers.createViewForWidget node widget :?> Page

                    navigationPage.PushAsync(page) |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Page>()

                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore

                    let page =
                        Helpers.createViewForWidget node widget :?> Page

                    navigationPage.PushAsync(page, false) |> ignore

                    while temp.Count > 1 do
                        navigationPage.PushAsync(temp.Pop(), false)
                        |> ignore

            | WidgetCollectionItemChange.Remove index ->
                if index > pages.Length - 1 then
                    () // Do nothing, page has already been popped
                elif index = pages.Length - 1 then
                    navigationPage.PopAsync() |> ignore
                else
                    let temp = System.Collections.Generic.Stack<Page>()

                    for i = pages.Length - 1 to index do
                        temp.Push(pages.[i])
                        navigationPage.PopAsync() |> ignore

                    while temp.Count > 1 do
                        navigationPage.PushAsync(temp.Pop(), false)
                        |> ignore

    let updateNavigationPagePages (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
        let navigationPage = node.Target :?> NavigationPage
        navigationPage.PopToRootAsync(false) |> ignore

        match newValueOpt with
        | ValueNone -> ()
        | ValueSome widgets ->
            for widget in ArraySlice.toSpan widgets do
                let page =
                    Helpers.createViewForWidget node widget :?> Page

                navigationPage.PushAsync(page) |> ignore
