// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open System
open Fabulous
open System.Collections.ObjectModel
open System.Collections.Generic
open Xamarin.Forms
open Xamarin.Forms.Shapes
open Xamarin.Forms.StyleSheets
open System.Windows.Input
open System.Diagnostics

/// This module contains custom update logic for all kind of properties
module ViewUpdaters =
    // Update a DataTemplate property taking a direct ViewElement
    let private updateDirectViewElementDataTemplate setValue clearValue getTarget prevValueOpt currValueOpt =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when identical prevValue currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueNone, ValueSome currValue) ->
            setValue (DirectViewElementDataTemplate(currValue))
        | struct (ValueSome prevValue, ValueSome currValue) ->
            setValue (DirectViewElementDataTemplate(currValue))
            let target = getTarget ()
            if target <> null then currValue.UpdateIncremental(prevValue, target)
        | struct (ValueSome _, ValueNone) ->
            clearValue ()

    /// Update the ShowJumpList property of a GroupedListView control, given previous and current view elements
    let updateListViewGroupedShowJumpList (prevOpt: bool voption) (currOpt: bool voption) (target: Xamarin.Forms.ListView) =
        let updateTarget enableJumpList =
            target.GroupShortNameBinding <- (if enableJumpList then Binding("ShortName") else null)

        match struct (prevOpt, currOpt) with
        | struct (ValueNone, ValueSome curr) -> updateTarget curr
        | struct (ValueSome prev, ValueSome curr) when prev <> curr -> updateTarget curr
        | struct (ValueSome _, ValueNone) -> target.GroupShortNameBinding <- null
        | _ -> ()

    /// Update the resources of a control, given previous and current view elements describing the resources
    let updateResources (prevCollOpt: (string * obj) array voption) (collOpt: (string * obj) array voption) (target: Xamarin.Forms.VisualElement) =
        match struct (prevCollOpt, collOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevColl, ValueSome newColl) when identical prevColl newColl -> ()
        | struct (_, ValueNone) -> target.Resources.Clear()
        | struct (_, ValueSome coll) ->
            let targetColl = target.Resources
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for (key, newChild) in coll do
                    if targetColl.ContainsKey(key) then
                        let prevChildOpt =
                            match prevCollOpt with
                            | ValueNone -> ValueNone
                            | ValueSome prevColl ->
                                match prevColl |> Array.tryFind(fun (prevKey, _) -> key = prevKey) with
                                | Some (_, prevChild) -> ValueSome prevChild
                                | None -> ValueNone
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            targetColl.Add(key, newChild)
                        else
                            targetColl.[key] <- newChild
                    else
                        targetColl.Remove(key) |> ignore
                for (KeyValue(key, _newChild)) in targetColl do
                   if not (coll |> Array.exists(fun (key2, _v2) -> key = key2)) then
                       targetColl.Remove(key) |> ignore

    /// Update the style sheets of a control, given previous and current view elements describing them
    // Note, style sheets can't be removed
    // Note, style sheets are compared by object identity
    let updateStyleSheets (prevCollOpt: StyleSheet array voption) (collOpt: StyleSheet array voption) (target: Xamarin.Forms.VisualElement) =
        match struct (prevCollOpt, collOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevColl, ValueSome newColl) when identical prevColl newColl -> ()
        | struct (_, ValueNone) -> target.Resources.Clear()
        | struct (_, ValueSome coll) ->
            let targetColl = target.Resources
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for styleSheet in coll do
                    let prevChildOpt =
                        match prevCollOpt with
                        | ValueNone -> None
                        | ValueSome prevColl -> prevColl |> Array.tryFind(fun prevStyleSheet -> identical styleSheet prevStyleSheet)
                    match prevChildOpt with
                    | None -> targetColl.Add(styleSheet)
                    | Some _ -> ()
                match prevCollOpt with
                | ValueNone -> ()
                | ValueSome prevColl ->
                    for prevStyleSheet in prevColl do
                        let childOpt =
                            match prevCollOpt with
                            | ValueNone -> None
                            | ValueSome prevColl -> prevColl |> Array.tryFind(fun styleSheet -> identical styleSheet prevStyleSheet)
                        match childOpt with
                        | None ->
                            eprintfn "**** WARNING: style sheets may not be removed, and are compared by object identity, so should be created independently of your update or view functions ****"
                        | Some _ -> ()

    /// Update the styles of a control, given previous and current view elements describing them
    // Note, styles can't be removed
    // Note, styles are compared by object identity
    let updateStyles (prevCollOpt: Style array voption) (collOpt: Style array voption) (target: Xamarin.Forms.VisualElement) =
        match struct (prevCollOpt, collOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevColl, ValueSome newColl) when identical prevColl newColl -> ()
        | struct (_, ValueNone) -> target.Resources.Clear()
        | struct (_, ValueSome coll) ->
            let targetColl = target.Resources
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for styleSheet in coll do
                    let prevChildOpt =
                        match prevCollOpt with
                        | ValueNone -> None
                        | ValueSome prevColl -> prevColl |> Array.tryFind(fun prevStyleSheet -> identical styleSheet prevStyleSheet)
                    match prevChildOpt with
                    | None -> targetColl.Add(styleSheet)
                    | Some _ -> ()
                match prevCollOpt with
                | ValueNone -> ()
                | ValueSome prevColl ->
                    for prevStyle in prevColl do
                        let childOpt =
                            match prevCollOpt with
                            | ValueNone -> None
                            | ValueSome prevColl -> prevColl |> Array.tryFind(fun style-> identical style prevStyle)
                        match childOpt with
                        | None ->
                            eprintfn "**** WARNING: styles may not be removed, and are compared by object identity. They should be created independently of your update or view functions ****"
                        | Some _ -> ()

    /// Incremental NavigationPage maintenance: push/pop the right pages
    let updateNavigationPages (prevCollOpt: ViewElement[] voption)  (collOpt: ViewElement[] voption) (target: NavigationPage) attach =
        match struct (prevCollOpt, collOpt) with
        | struct (ValueSome prevColl, ValueSome newColl) when identical prevColl newColl -> ()
        | struct (_, ValueNone) -> failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
        | struct (_, ValueSome coll) ->
            let create (desc: ViewElement) = (desc.Create() :?> Page)
            if (coll = null || coll.Length = 0) then
                failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
            else
                // Count the existing pages
                let prevCount = target.Pages |> Seq.length
                let newCount = coll.Length
                Debug.WriteLine(sprintf "Updating NavigationPage, prevCount = %d, newCount = %d" prevCount newCount)

                // Remove the excess pages
                if newCount = 1 && prevCount > 1 then
                    Debug.WriteLine(sprintf "Updating NavigationPage --> PopToRootAsync")
                    target.PopToRootAsync() |> ignore
                elif prevCount > newCount then
                    for i in prevCount - 1 .. -1 .. newCount do
                        Debug.WriteLine(sprintf "PopAsync, page number %d" i)
                        target.PopAsync () |> ignore

                let n = min prevCount newCount
                // Push and/or adjust pages
                for i in 0 .. newCount-1 do
                    let newChild = coll.[i]
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < coll.Length && i < n -> ValueSome coll.[i] | _ -> ValueNone
                    let struct (prevChildOpt, targetChild) =
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            let mustCreate = (i >= n || match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (ViewHelpers.canReuseView prevChild newChild))
                            if mustCreate then
                                Debug.WriteLine(sprintf "Creating child %d, prevChildOpt = %A, newChild = %A" i prevChildOpt newChild)
                                let targetChild = create newChild
                                if i >= n then
                                    Debug.WriteLine(sprintf "PushAsync, page number %d" i)
                                    target.PushAsync(targetChild) |> ignore
                                else
                                    failwith "Error while updating NavigationPage pages: can't change type of one of the pages in the navigation chain during navigation"
                                struct (ValueNone, targetChild)
                            else
                                Debug.WriteLine(sprintf "Adjust page number %d" i)
                                let targetChild = target.Pages |> Seq.item i
                                newChild.UpdateIncremental(prevChildOpt.Value, targetChild)
                                struct (prevChildOpt, targetChild)
                        else
                            Debug.WriteLine(sprintf "Skipping child %d" i)
                            let targetChild = target.Pages |> Seq.item i
                            struct (prevChildOpt, targetChild)
                    attach prevChildOpt newChild targetChild

    /// Update the OnSizeAllocated callback of a control, given previous and current values
    let updateOnSizeAllocated prevValueOpt valueOpt (target: obj) =
        let target = (target :?> CustomContentPage)
        match prevValueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.RemoveHandler(f)
        match valueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.AddHandler(f)

    /// Converts an F# function to a Xamarin.Forms ICommand
    let makeCommand f =
        let ev = Event<_,_>()
        { new ICommand with
            member __.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member __.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member __.CanExecute _ = true
            member __.Execute _ = f() }

    /// Converts an F# function to a Xamarin.Forms ICommand, with a CanExecute value
    let makeCommandCanExecute f canExecute =
        let ev = Event<_,_>()
        { new ICommand with
            member __.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member __.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member __.CanExecute _ = canExecute
            member __.Execute _ = f() }

    /// Update the Command and CanExecute properties of a control, given previous and current values
    let inline updateCommand prevCommandValueOpt commandValueOpt argTransform setter  prevCanExecuteValueOpt canExecuteValueOpt target =
        match struct (prevCommandValueOpt, prevCanExecuteValueOpt, commandValueOpt, canExecuteValueOpt) with
        | struct (ValueNone, ValueNone, ValueNone, ValueNone) -> ()
        | struct (ValueSome prevf, ValueNone, ValueSome f, ValueNone) when identical prevf f -> ()
        | struct (ValueSome prevf, ValueSome prevx, ValueSome f, ValueSome x) when identical prevf f && prevx = x -> ()
        | struct (_, _, ValueNone, _) -> setter target null
        | struct (_, _, ValueSome f, ValueNone) -> setter target (makeCommand (fun () -> f (argTransform target)))
        | struct (_, _, ValueSome f, ValueSome k) -> setter target (makeCommandCanExecute (fun () -> f (argTransform target)) k)

    /// Update the CurrentPage of a control, given previous and current values
    let updateMultiPageOfTCurrentPage<'a when 'a :> Xamarin.Forms.Page> prevValueOpt valueOpt (target: Xamarin.Forms.MultiPage<'a>) =
        match struct (prevValueOpt, valueOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prev, ValueSome curr) when prev = curr -> ()
        | struct (ValueSome _, ValueNone) -> target.CurrentPage <- Unchecked.defaultof<'a>
        | struct (_, ValueSome curr) -> target.CurrentPage <- target.Children.[curr]

    /// Update the Minimum and Maximum values of a slider, given previous and current values
    let updateSliderMinimumMaximum prevValueOpt valueOpt (target: Xamarin.Forms.Slider) =
        let updateFunc (_, prevMaximum) (newMinimum, newMaximum) =
            if newMinimum >= prevMaximum then
                target.Maximum <- newMaximum
                target.Minimum <- newMinimum
            else
                target.Minimum <- newMinimum
                target.Maximum <- newMaximum

        let clearValues () =
            target.ClearValue Slider.MaximumProperty
            target.ClearValue Slider.MinimumProperty

        match struct (prevValueOpt, valueOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prev, ValueSome curr) when prev = curr -> ()
        | struct (ValueSome prev, ValueSome curr) -> updateFunc prev curr
        | struct (ValueSome _, ValueNone) -> clearValues ()
        | struct (ValueNone, ValueSome curr) -> updateFunc (0.0, 1.0) curr

    /// Update the Minimum and Maximum values of a stepper, given previous and current values
    let updateStepperMinimumMaximum prevValueOpt valueOpt (target: Xamarin.Forms.Stepper) =
        let updateFunc (_, prevMaximum) (newMinimum, newMaximum) =
            if newMinimum >= prevMaximum then
                target.Maximum <- newMaximum
                target.Minimum <- newMinimum
            else
                target.Minimum <- newMinimum
                target.Maximum <- newMaximum

        let clearValues () =
            target.ClearValue Stepper.MaximumProperty
            target.ClearValue Stepper.MinimumProperty

        match struct (prevValueOpt, valueOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prev, ValueSome curr) when prev = curr -> ()
        | struct (ValueSome prev, ValueSome curr) -> updateFunc prev curr
        | struct (ValueSome _, ValueNone) -> clearValues ()
        | struct (ValueNone, ValueSome curr) -> updateFunc (0.0, 1.0) curr

    /// Update the AcceleratorProperty of a MenuItem, given previous and current Accelerator
    let updateMenuItemAccelerator prevValue currValue (target: Xamarin.Forms.MenuItem) =
        match struct (prevValue, currValue) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevVal, ValueSome newVal) when prevVal = newVal -> ()
        | struct (_, ValueNone) -> target.ClearValue Xamarin.Forms.MenuItem.AcceleratorProperty
        | struct (_, ValueSome newVal) -> Xamarin.Forms.MenuItem.SetAccelerator(target, Xamarin.Forms.Accelerator.FromString newVal)

    /// Trigger ScrollView.ScrollToAsync if needed, given the current values
    let triggerScrollToAsync _ (currValue: (float * float * AnimationKind) voption) (target: Xamarin.Forms.ScrollView) =
        match currValue with
        | ValueSome (x, y, animationKind) when x <> target.ScrollX || y <> target.ScrollY ->
            let animated =
                match animationKind with
                | Animated -> true
                | NotAnimated -> false
            target.ScrollToAsync(x, y, animated) |> ignore
        | _ -> ()

    /// Trigger ItemsView.ScrollTo if needed, given the current values
    let triggerItemsViewScrollTo _ (currValue: ScrollToItem voption) (target: Xamarin.Forms.ItemsView) =
        match currValue with
        | ValueSome scrollToItem ->
            let animate =
                match scrollToItem.Animate with
                | Animated -> true
                | NotAnimated -> false

            target.ScrollTo(scrollToItem.Index, position = scrollToItem.Position, animate = animate)
        | _ -> ()

    /// Trigger ListView.ScrollTo if needed, given the current values
    let triggerListViewScrollTo _ (currValue: ScrollToItem voption) (target: Xamarin.Forms.ListView) =
        match currValue with
        | ValueSome scrollToItem ->
            let animate =
                match scrollToItem.Animate with
                | Animated -> true
                | NotAnimated -> false

            let itemOpt = (target.ItemsSource :?> ObservableCollection<ViewElementHolder>) |> Seq.tryItem scrollToItem.Index
            match itemOpt with
            | None -> ()
            | Some item -> target.ScrollTo(item, scrollToItem.Position, animate)
        | _ -> ()

    /// Trigger ListViewGrouped.ScrollTo if needed, given the current values
    let triggerListViewGroupedScrollTo _ (currValue: ScrollToGroupedItem voption) (target: Xamarin.Forms.ListView) =
        match currValue with
        | ValueSome scrollToGroupedItem ->
            let animate =
                match scrollToGroupedItem.Animate with
                | Animated -> true
                | NotAnimated -> false

            let groupOpt = (target.ItemsSource :?> ObservableCollection<ViewElementHolderGroup>) |> Seq.tryItem scrollToGroupedItem.GroupIndex
            match groupOpt with
            | None -> ()
            | Some group ->
                let itemOpt = (group :> ObservableCollection<ViewElementHolder>) |> Seq.tryItem scrollToGroupedItem.ItemIndex
                match itemOpt with
                | None -> ()
                | Some item ->
                    target.ScrollTo(item, group, scrollToGroupedItem.Position, animate)
        | _ -> ()

    /// Trigger Shell.GoToAsync if needed, given the current values
    let triggerShellGoToAsync _ (currValue: (ShellNavigationState * AnimationKind) voption) (target: Xamarin.Forms.Shell) =
        match currValue with
        | ValueSome (navigationState, animationKind) ->
            let animated =
                match animationKind with
                | Animated -> true
                | NotAnimated -> false
            target.GoToAsync(navigationState, animated) |> ignore
        | _ -> ()

    let updatePageShellSearchHandler prevValueOpt (currValueOpt: ViewElement voption) target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueSome prevValue, ValueSome currValue) ->
            let searchHandler = Shell.GetSearchHandler(target)
            currValue.UpdateIncremental(prevValue, searchHandler)
        | struct (ValueNone, ValueSome currValue) -> Shell.SetSearchHandler(target, currValue.Create() :?> Xamarin.Forms.SearchHandler)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.SearchHandlerProperty

    let updateShellBackgroundColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetBackgroundColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.BackgroundColorProperty

    let updateShellForegroundColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetForegroundColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.ForegroundColorProperty

    let updateShellTitleColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTitleColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TitleColorProperty

    let updateShellDisabledColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetDisabledColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.DisabledColorProperty

    let updateShellUnselectedColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetUnselectedColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.UnselectedColorProperty

    let updateShellTabBarBackgroundColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarBackgroundColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarBackgroundColorProperty

    let updateShellTabBarForegroundColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarForegroundColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarForegroundColorProperty

    let updateShellBackButtonBehavior prevValueOpt (currValueOpt: ViewElement voption) target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetBackButtonBehavior(target, currValue.Create() :?> BackButtonBehavior)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.BackButtonBehaviorProperty

    let updateShellTitleView prevValueOpt (currValueOpt: ViewElement voption) target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTitleView(target, currValue.Create() :?> View)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TitleViewProperty

    let updateShellFlyoutBehavior prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetFlyoutBehavior(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.FlyoutBehaviorProperty

    let updateShellTabBarIsVisible prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarIsVisible(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarIsVisibleProperty

    let updateShellNavBarIsVisible prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetNavBarIsVisible(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.NavBarIsVisibleProperty

    let updateShellPresentationMode prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetPresentationMode(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.PresentationModeProperty

    let updateShellTabBarDisabledColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarDisabledColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarDisabledColorProperty

    let updateShellTabBarTitleColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarTitleColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarTitleColorProperty

    let updateShellTabBarUnselectedColor prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetTabBarUnselectedColor(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.TabBarUnselectedColorProperty

    let updateNavigationPageHasNavigationBar prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> NavigationPage.SetHasNavigationBar(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue NavigationPage.HasNavigationBarProperty

    let updateShellContentContentTemplate prevValueOpt currValueOpt (target : Xamarin.Forms.ShellContent) =
        updateDirectViewElementDataTemplate
            (fun v -> target.ContentTemplate <- v)
            (fun () -> target.ClearValue ShellContent.ContentTemplateProperty)
            (fun () -> (target :> Xamarin.Forms.IShellContentController).Page)
            prevValueOpt
            currValueOpt

    let updateShellNavBarHasShadow prevValueOpt currValueOpt target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Shell.SetNavBarHasShadow(target, currValue)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Shell.NavBarHasShadowProperty

    let updatePageUseSafeArea (prevValueOpt: bool voption) (currValueOpt: bool voption) (target: Xamarin.Forms.Page) =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(target, currValue)
        | struct (ValueSome _, ValueNone) -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(target, false)

    let triggerWebViewReload _ curr (target: Xamarin.Forms.WebView) =
        if curr = ValueSome true then target.Reload()

    let updateEntryCursorPosition prev curr (target: Xamarin.Forms.Entry) =
        match struct (prev, curr) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome value) -> target.CursorPosition <- value
        | struct (ValueSome _, ValueNone) -> target.ClearValue Entry.CursorPositionProperty

    let updateEntrySelectionLength prev curr (target: Xamarin.Forms.Entry) =
        match struct (prev, curr) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome value) -> target.SelectionLength <- value
        | struct (ValueSome _, ValueNone) -> target.ClearValue Entry.SelectionLengthProperty

    let updateElementMenu prevValueOpt (currValueOpt: ViewElement voption) target =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (_, ValueSome currValue) -> Element.SetMenu(target, currValue.Create() :?> Menu)
        | struct (ValueSome _, ValueNone) -> target.ClearValue Element.MenuProperty

    // The CarouselView/IndicatorView combo in Xamarin.Forms is special.
    // A CarouselView can be linked to an IndicatorView, we're using a ViewRef<IndicatorView> to handle that.
    //
    // But since the IndicatorView can be placed anywhere in the UI tree relatively to the CarouselView, and that ViewRef is late-bound (only resolved when actually instantiating the IndicatorView control),
    // there's no guarantee that when calling updateCarouselViewIndicatorView, the ViewRef will be bound.
    //
    // It means we need to create the link between the actual CarouselView and IndicatorView instances once ViewRef is bound.
    // For that, we have a ViewRef.Attached event we can listen to.
    //
    // But we need to store the handlers somewhere. Not on the ViewElements (they're supposed to be immutable and user-driven), not on the controls instances (we can't store arbitrary values on those).
    // This means, we need to store them here globally.
    //
    // To avoid cluttering memory with dead handlers, we try to remove them whenever possible (the link is no longer wanted, the CarouselView instance is no longer accessible)
    // But we aren't notified when a CarouselView instance is disposed, and so we can't clean up the associated handler in that case...
    let private carouselViewHandlers = Dictionary<int, Handler<Xamarin.Forms.IndicatorView>>()

    let private linkIndicatorViewToCarouselView (target: Xamarin.Forms.CarouselView) indicatorView =
        target.IndicatorView <- indicatorView

    let private tryLinkIndicatorViewToCarouselView (target: Xamarin.Forms.CarouselView) (indicatorViewRef: ViewRef<IndicatorView>) =
        match indicatorViewRef.TryValue with
        | None -> linkIndicatorViewToCarouselView target null
        | Some v -> linkIndicatorViewToCarouselView target v

    let private removeCarouselViewHandler (target: Xamarin.Forms.CarouselView) =
        let key = target.GetHashCode()
        carouselViewHandlers.Remove(key) |> ignore

    let updateCarouselViewIndicatorView (prevValueOpt: ViewRef<IndicatorView> voption) (currValueOpt: ViewRef<IndicatorView> voption) (target: Xamarin.Forms.CarouselView) =
        let getHandler() =
            match carouselViewHandlers.TryGetValue(target.GetHashCode()) with
            | true, handler -> handler
            | false, _ ->
                let key = target.GetHashCode()
                let weakRef = WeakReference<Xamarin.Forms.CarouselView>(target)
                let handler = Handler<Xamarin.Forms.IndicatorView>(fun _ indicatorView ->
                    match weakRef.TryGetTarget() with
                    | false, _ -> carouselViewHandlers.Remove(key) |> ignore
                    | true, target -> linkIndicatorViewToCarouselView target indicatorView
                )
                carouselViewHandlers.Add(key, handler)
                handler

        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prevValue, ValueNone) ->
            let handler = getHandler()
            prevValue.Attached.RemoveHandler(handler)
            removeCarouselViewHandler target
            linkIndicatorViewToCarouselView target null
        | struct (ValueNone, ValueSome currValue) ->
            let handler = getHandler()
            currValue.Attached.AddHandler(handler)
            tryLinkIndicatorViewToCarouselView target currValue
        | struct (ValueSome prevValue, ValueSome currValue) ->
            let handler = getHandler()
            prevValue.Attached.RemoveHandler(handler)
            currValue.Attached.AddHandler(handler)
            tryLinkIndicatorViewToCarouselView target currValue

    let updateIndicatorViewIndicatorProperty prevValueOpt currValueOpt (target: Xamarin.Forms.IndicatorView) =
        updateDirectViewElementDataTemplate
            (fun v -> target.IndicatorTemplate <- v)
            (fun () -> target.ClearValue IndicatorView.IndicatorTemplateProperty)
            (fun () -> target)
            prevValueOpt
            currValueOpt

    let updatePathData prevValueOpt (currValueOpt: InputTypes.Content.Value voption) (target: Xamarin.Forms.Shapes.Path) =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueSome currValue) ->
            match currValue with
            | Content.String str -> target.Data <- PathGeometryConverter().ConvertFromInvariantString(str) :?> Xamarin.Forms.Shapes.Geometry
            | Content.ViewElement ve -> target.Data <- (ve.Create() :?> Xamarin.Forms.Shapes.Geometry)

        | struct (ValueSome prevValue, ValueSome currValue) ->
            match struct (prevValue, currValue) with
            | struct (Content.String prevStr, Content.String currStr) when prevStr = currStr -> ()
            | struct (Content.ViewElement prevVe, Content.ViewElement currVe) when identical prevVe currVe -> ()
            | struct (Content.ViewElement prevVe, Content.ViewElement currVe) when canReuseView prevVe currVe -> currVe.UpdateIncremental(prevVe, target.Data)
            | struct (_, Content.String currStr) -> target.Data <- PathGeometryConverter().ConvertFromInvariantString(currStr) :?> Xamarin.Forms.Shapes.Geometry
            | struct (_, Content.ViewElement currVe) -> target.Data <- (currVe.Create() :?> Xamarin.Forms.Shapes.Geometry)

        | struct (ValueSome _, ValueNone) -> target.Data.ClearValue(Xamarin.Forms.Shapes.Path.DataProperty)
        | struct (ValueNone, ValueNone) -> ()

    let updatePathRenderTransform prevValueOpt (currValueOpt: InputTypes.Content.Value voption) (target: Xamarin.Forms.Shapes.Path) =
        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (ValueNone, ValueSome currValue) ->
            match currValue with
            | Content.String str -> target.RenderTransform <- TransformTypeConverter().ConvertFromInvariantString(str) :?> Xamarin.Forms.Shapes.Transform
            | Content.ViewElement ve -> target.RenderTransform <- (ve.Create() :?> Xamarin.Forms.Shapes.Transform)

        | struct (ValueSome prevValue, ValueSome currValue) ->
            match struct (prevValue, currValue) with
            | struct (Content.String prevStr, Content.String currStr) when prevStr = currStr -> ()
            | struct (Content.ViewElement prevVe, Content.ViewElement currVe) when identical prevVe currVe -> ()
            | struct (Content.ViewElement prevVe, Content.ViewElement currVe) when canReuseView prevVe currVe -> currVe.UpdateIncremental(prevVe, target.RenderTransform)
            | struct (_, Content.String currStr) -> target.RenderTransform <- TransformTypeConverter().ConvertFromInvariantString(currStr) :?> Xamarin.Forms.Shapes.Transform
            | struct (_, Content.ViewElement currVe) -> target.RenderTransform <- (currVe.Create() :?> Xamarin.Forms.Shapes.Transform)

        | struct (ValueSome _, ValueNone) -> target.Data.ClearValue(Xamarin.Forms.Shapes.Path.DataProperty)
        | struct (ValueNone, ValueNone) -> ()


    let inline updatePoints (target: Xamarin.Forms.BindableObject) (bindableProperty: Xamarin.Forms.BindableProperty) (prevOpt: Fabulous.XamarinForms.InputTypes.Points.Value voption) (currOpt: Fabulous.XamarinForms.InputTypes.Points.Value voption) =
        match struct (prevOpt, currOpt) with
        | struct (ValueNone, ValueNone) -> ()
        | struct (ValueSome prev, ValueSome curr) when prev = curr -> ()
        | struct (ValueSome _, ValueNone) -> target.ClearValue(bindableProperty)
        | struct (_, ValueSome curr) ->
                match curr with
                | Points.String str -> target.SetValue(bindableProperty, PointCollectionConverter().ConvertFromInvariantString(str))
                | Points.PointsList lst ->
                    let coll = PointCollection()
                    lst |> List.iter (fun p -> coll.Add(p))
                    target.SetValue(bindableProperty, coll)

    /// Update the points of a Polygon, given previous and current view elements
    let inline updatePolygonPoints prevOpt currOpt (target: Polygon) =
        updatePoints target Polygon.PointsProperty prevOpt currOpt

    /// Update the points of a Polyline, given previous and current view elements
    let inline updatePolylinePoints prevOpt currOpt (target: Polyline) =
        updatePoints target Polyline.PointsProperty prevOpt currOpt

    /// Update the points of a PolyBezierSegment, given previous and current view elements
    let inline updatePolyBezierSegmentPoints prevOpt currOpt (target: PolyBezierSegment) =
        updatePoints target PolyBezierSegment.PointsProperty prevOpt currOpt

    /// Update the points of a PolyLineSegment, given previous and current view elements
    let inline updatePolyLineSegmentPoints prevOpt currOpt (target: PolyLineSegment) =
        updatePoints target PolyLineSegment.PointsProperty prevOpt currOpt

    /// Update the points of a PolyQuadraticBezierSegment, given previous and current view elements
    let inline updatePolyQuadraticBezierSegmentPoints prevOpt currOpt (target: PolyQuadraticBezierSegment) =
        updatePoints target PolyQuadraticBezierSegment.PointsProperty prevOpt currOpt