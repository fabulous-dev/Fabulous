// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open System
open Fabulous
open System.Collections.ObjectModel
open System.Collections.Generic
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open System.Windows.Input

[<AutoOpen>]
module ViewUpdaters =
    /// Update a control given the previous and new view elements
    let inline updateChild (prevChild:ViewElement) (newChild:ViewElement) targetChild = 
        newChild.UpdateIncremental(prevChild, targetChild)
        
    // Update a DataTemplate property taking a direct ViewElement
    let private updateDirectViewElementDataTemplate setValue clearValue getTarget prevValueOpt currValueOpt =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueNone, ValueNone -> ()
        | ValueNone, ValueSome currValue ->
            setValue (DirectViewElementDataTemplate(currValue))
        | ValueSome prevValue, ValueSome currValue ->
            setValue (DirectViewElementDataTemplate(currValue))
            let target = getTarget ()
            if target <> null then currValue.UpdateIncremental(prevValue, target)            
        | ValueSome _, ValueNone ->
            clearValue ()

    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/add/remove/insert operations
    let updateCollectionGeneric
           (prevCollOpt: 'T[] voption) 
           (collOpt: 'T[] voption) 
           (targetColl: IList<'TargetT>) 
           (create: 'T -> 'TargetT)
           (attach: 'T voption -> 'T -> 'TargetT -> unit) // adjust attached properties
           (canReuse : 'T -> 'T -> bool) // Used to check if reuse is possible
           (getKey:'T->string option)
           (update: 'T -> 'T -> 'TargetT -> unit) // Incremental element-wise update, only if element reuse is allowed
        =
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> targetColl.Clear()
        | _, ValueSome coll ->
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else

                let prevColl =
                    match prevCollOpt with
                    | ValueSome x -> x
                    | _ -> [||]
    
                // Remove the excess targetColl


                // Count the existing targetColl
                // Unused variable n' introduced as a temporary workaround for https://github.com/fsprojects/Fabulous/issues/343
                let _ = targetColl.Count
                let n = targetColl.Count
                let targetControls = Dictionary<string,'TargetT>()
                for i in 0..prevColl.Length-1 do
                        let key = getKey prevColl.[i]
                        key|> Option.iter (fun key -> targetControls.[key]<-targetColl.[i])
                        
                         
                while (targetColl.Count > coll.Length) do
                  targetColl.RemoveAt (targetColl.Count - 1)
               // targetColl.Clear()                    
                
                let contains key =
                    key
                    |> Option.map(fun key -> targetControls.ContainsKey key)
                    |> Option.defaultValue false
                    
                let add targetChild i =
                     if i >= n
                     then
                       targetColl.Insert(i, targetChild)
                     else
                      targetColl.[i] <- targetChild
      
                // Adjust the existing targetColl and create the new targetColl
                for i in 0 .. coll.Length-1 do
                    let newChild = coll.[i]
                    let key = getKey newChild
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < n -> ValueSome coll.[i] | _ -> ValueNone
                    let prevChildOpt, targetChild =
                        
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                                if (contains key)
                                then
                                    let targetChild = targetControls.[key.Value] // We should be safe here                                        
                                    add targetChild i 
                                    if(prevChildOpt.IsSome) then 
                                     update prevChildOpt.Value newChild targetChild
                                    prevChildOpt, targetChild
                                else 
                                    let mustCreate = ((i>=n)|| match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (canReuse prevChild newChild))
                                    if mustCreate then
                                        let targetChild = create newChild
                                        add targetChild i 
                                        ValueNone, targetChild
                                    else
                                        let targetChild = targetColl.[i]
                                        update prevChildOpt.Value newChild targetChild
                                        prevChildOpt, targetChild
                        else
                            prevChildOpt, targetColl.[i]
                    attach prevChildOpt newChild targetChild
                    
    /// Update the attached properties for each item in an already updated collection
    let updateAttachedPropertiesForCollection
           (prevCollOpt: 'T[] voption)
           (collOpt: 'T[] voption)
           (targetColl: IList<'TargetT>)
           (attach: 'T voption -> 'T -> 'TargetT -> unit)
           (canReuse : 'T -> 'T -> bool) =
        match collOpt with
        | ValueNone -> ()
        | ValueSome coll when coll = null || coll.Length = 0 -> ()
        | ValueSome coll ->
            for i in 0 .. coll.Length-1 do
                let targetChild = targetColl.[i]
                let newChild = coll.[i]
                let prevChildOpt =
                    match prevCollOpt with
                    | ValueSome coll when i < coll.Length ->
                        let child = coll.[i]
                        if not (identical child newChild) && canReuseView child newChild then
                            ValueSome child
                        else
                            ValueNone
                    | _ -> ValueNone
                attach prevChildOpt newChild targetChild
                
    /// Update the attached properties for each item in Layout<T>.Children
    let updateAttachedPropertiesForLayoutOfT prevCollOpt collOpt (target: Xamarin.Forms.Layout<'T>) attach =
        updateAttachedPropertiesForCollection prevCollOpt collOpt target.Children attach canReuseView
                    
    /// Update the items in a ItemsView control, given previous and current view elements
    let updateItemsViewItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.ItemsView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ViewElementHolder> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ViewElementHolder>()
                target.ItemsSource <- oc
                oc
        updateCollectionGeneric prevCollOpt collOpt targetColl ViewElementHolder (fun _ _ _ -> ()) ViewHelpers.canReuseView (ViewHelpers.getKey)  (fun _ curr holder -> holder.ViewElement <- curr)
                    
    /// Update the items in a ItemsView<'T> control, given previous and current view elements
    let updateItemsViewOfTItems<'T when 'T :> Xamarin.Forms.BindableObject> (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.ItemsView<'T>) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ViewElementHolder> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ViewElementHolder>()
                target.ItemsSource <- oc
                oc
        updateCollectionGeneric prevCollOpt collOpt targetColl ViewElementHolder (fun _ _ _ -> ()) ViewHelpers.canReuseView ViewHelpers.getKey (fun _ curr holder -> holder.ViewElement <- curr)
                    
    /// Update the selected items in a SelectableItemsView control, given previous and current indexes
    let updateSelectableItemsViewSelectedItems (prevCollOptOpt: int array option voption) (collOptOpt: int array option voption) (target: Xamarin.Forms.SelectableItemsView) = 
        let targetColl = 
            match target.SelectedItems with 
            | :? ObservableCollection<obj> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<obj>()
                target.SelectedItems <- oc
                oc
                
        let convert = ValueOption.bind (function None -> ValueNone | Some x -> ValueSome x)
        let prevCollOpt = convert prevCollOptOpt
        let collOpt = convert collOptOpt
        
        let findItem idx =
            let itemsSource = target.ItemsSource :?> System.Collections.Generic.IList<ViewElementHolder>
            itemsSource.[idx] :> obj
        
        updateCollectionGeneric prevCollOpt collOpt targetColl findItem (fun _ _ _ -> ()) (fun x y -> x = y) (fun _ ->None) (fun _ _ _ -> ())
        
    /// Update the items in a SearchHandler control, given previous and current view elements
    let updateSearchHandlerItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.SearchHandler) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ViewElementHolder> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ViewElementHolder>()
                target.ItemsSource <- oc
                oc
        updateCollectionGeneric prevCollOpt collOpt targetColl ViewElementHolder (fun _ _ _ -> ()) ViewHelpers.canReuseView ViewHelpers.getKey (fun _ curr holder -> holder.ViewElement <- curr)
        
    let private updateViewElementHolderGroup (_prevShortName: string, _prevKey, prevColl: ViewElement[]) (currShortName: string, currKey, currColl: ViewElement[]) (target: ViewElementHolderGroup) =
        target.ShortName <- currShortName
        target.ViewElement <- currKey
        updateCollectionGeneric (ValueSome prevColl) (ValueSome currColl) target ViewElementHolder (fun _ _ _ -> ()) ViewHelpers.canReuseView  ViewHelpers.getKey (fun _ curr target -> target.ViewElement <- curr) 

    /// Update the items in a GroupedListView control, given previous and current view elements
    let updateListViewGroupedItems (prevCollOpt: (string * ViewElement * ViewElement[])[] voption) (collOpt: (string * ViewElement * ViewElement[])[] voption) (target: Xamarin.Forms.ListView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ViewElementHolderGroup> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ViewElementHolderGroup>()
                target.ItemsSource <- oc
                oc
                
        updateCollectionGeneric prevCollOpt collOpt targetColl ViewElementHolderGroup (fun _ _ _ -> ()) (fun (_, prevKey, _) (_, currKey, _) -> ViewHelpers.canReuseView prevKey currKey) (fun _-> None) updateViewElementHolderGroup

    /// Update the ShowJumpList property of a GroupedListView control, given previous and current view elements
    let updateListViewGroupedShowJumpList (prevOpt: bool voption) (currOpt: bool voption) (target: Xamarin.Forms.ListView) =
        let updateTarget enableJumpList =
            target.GroupShortNameBinding <- (if enableJumpList then Binding("ShortName") else null)

        match (prevOpt, currOpt) with
        | ValueNone, ValueSome curr -> updateTarget curr
        | ValueSome prev, ValueSome curr when prev <> curr -> updateTarget curr
        | ValueSome _, ValueNone -> target.GroupShortNameBinding <- null
        | _, _ -> ()

    /// Update the items of a TableSectionBase<'T> control, given previous and current view elements
    let updateTableSectionBaseOfTItems<'T when 'T :> Xamarin.Forms.BindableObject> (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.TableSectionBase<'T>) _ =
        let create (desc: ViewElement) =
            desc.Create() :?> 'T
        
        updateCollectionGeneric prevCollOpt collOpt target create (fun _ _ _ -> ()) ViewHelpers.canReuseView ViewHelpers.getKey updateChild

    /// Update the resources of a control, given previous and current view elements describing the resources
    let updateResources (prevCollOpt: (string * obj) array voption) (collOpt: (string * obj) array voption) (target: Xamarin.Forms.VisualElement) = 
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
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
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
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
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
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
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
        | _, ValueSome coll ->
            let create (desc: ViewElement) = (desc.Create() :?> Page)
            if (coll = null || coll.Length = 0) then
                failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
            else
                // Count the existing pages
                let prevCount = target.Pages |> Seq.length
                let newCount = coll.Length
                printfn "Updating NavigationPage, prevCount = %d, newCount = %d" prevCount newCount

                // Remove the excess pages
                if newCount = 1 && prevCount > 1 then 
                    printfn "Updating NavigationPage --> PopToRootAsync" 
                    target.PopToRootAsync() |> ignore
                elif prevCount > newCount then
                    for i in prevCount - 1 .. -1 .. newCount do 
                        printfn "PopAsync, page number %d" i
                        target.PopAsync () |> ignore
                
                let n = min prevCount newCount
                // Push and/or adjust pages
                for i in 0 .. newCount-1 do
                    let newChild = coll.[i]
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < coll.Length && i < n -> ValueSome coll.[i] | _ -> ValueNone
                    let prevChildOpt, targetChild = 
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            let mustCreate = (i >= n || match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (ViewHelpers.canReuseView prevChild newChild))
                            if mustCreate then
                                //printfn "Creating child %d, prevChildOpt = %A, newChild = %A" i prevChildOpt newChild
                                let targetChild = create newChild
                                if i >= n then
                                    printfn "PushAsync, page number %d" i
                                    target.PushAsync(targetChild) |> ignore
                                else
                                    failwith "Error while updating NavigationPage pages: can't change type of one of the pages in the navigation chain during navigation"
                                ValueNone, targetChild
                            else
                                printfn "Adjust page number %d" i
                                let targetChild = target.Pages |> Seq.item i
                                updateChild prevChildOpt.Value newChild targetChild
                                prevChildOpt, targetChild
                        else
                            //printfn "Skipping child %d" i
                            let targetChild = target.Pages |> Seq.item i
                            prevChildOpt, targetChild
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
        match prevCommandValueOpt, prevCanExecuteValueOpt, commandValueOpt, canExecuteValueOpt with 
        | ValueNone, ValueNone, ValueNone, ValueNone -> ()
        | ValueSome prevf, ValueNone, ValueSome f, ValueNone when identical prevf f -> ()
        | ValueSome prevf, ValueSome prevx, ValueSome f, ValueSome x when identical prevf f && prevx = x -> ()
        | _, _, ValueNone, _ -> setter target null
        | _, _, ValueSome f, ValueNone -> setter target (makeCommand (fun () -> f (argTransform target)))
        | _, _, ValueSome f, ValueSome k -> setter target (makeCommandCanExecute (fun () -> f (argTransform target)) k)

    /// Update the CurrentPage of a control, given previous and current values
    let updateMultiPageOfTCurrentPage<'a when 'a :> Xamarin.Forms.Page> prevValueOpt valueOpt (target: Xamarin.Forms.MultiPage<'a>) =
        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome _, ValueNone -> target.CurrentPage <- Unchecked.defaultof<'a>
        | _, ValueSome curr -> target.CurrentPage <- target.Children.[curr]

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

        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome prev, ValueSome curr -> updateFunc prev curr
        | ValueSome _, ValueNone -> clearValues ()
        | ValueNone, ValueSome curr -> updateFunc (0.0, 1.0) curr

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

        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome prev, ValueSome curr -> updateFunc prev curr
        | ValueSome _, ValueNone -> clearValues ()
        | ValueNone, ValueSome curr -> updateFunc (0.0, 1.0) curr

    /// Update the AcceleratorProperty of a MenuItem, given previous and current Accelerator
    let updateMenuItemAccelerator prevValue currValue (target: Xamarin.Forms.MenuItem) =
        match prevValue, currValue with
        | ValueNone, ValueNone -> ()
        | ValueSome prevVal, ValueSome newVal when prevVal = newVal -> ()
        | _, ValueNone -> target.ClearValue Xamarin.Forms.MenuItem.AcceleratorProperty
        | _, ValueSome newVal -> Xamarin.Forms.MenuItem.SetAccelerator(target, Xamarin.Forms.Accelerator.FromString newVal)

    /// Update the items of a Shell, given previous and current view elements
    let updateShellItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.Shell) _ =
        let create (desc: ViewElement) =
            match desc.Create() with
            | :? ShellContent as shellContent -> ShellItem.op_Implicit shellContent
            | :? TemplatedPage as templatedPage -> ShellItem.op_Implicit templatedPage
            | :? ShellSection as shellSection -> ShellItem.op_Implicit shellSection
            | :? MenuItem as menuItem -> ShellItem.op_Implicit menuItem
            | :? ShellItem as shellItem -> shellItem
            | child -> failwithf "%s is not compatible with the type ShellItem" (child.GetType().Name)

        let update prevViewElement (currViewElement: ViewElement) (target: ShellItem) =
            let realTarget =
                match currViewElement.TargetType with
                | t when t = typeof<ShellContent> -> target.Items.[0].Items.[0] :> Element
                | t when t = typeof<TemplatedPage> -> target.Items.[0].Items.[0] :> Element
                | t when t = typeof<ShellSection> -> target.Items.[0] :> Element
                | t when t = typeof<MenuItem> -> target.GetType().GetProperty("MenuItem").GetValue(target) :?> Element // MenuShellItem is marked as internal
                | _ -> target :> Element
            updateChild prevViewElement currViewElement realTarget

        updateCollectionGeneric prevCollOpt collOpt target.Items create (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey update
        
    /// Update the menu items of a ShellContent, given previous and current view elements
    let updateShellContentMenuItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.ShellContent) =
        let create (desc: ViewElement) =
            desc.Create() :?> Xamarin.Forms.MenuItem

        updateCollectionGeneric prevCollOpt collOpt target.MenuItems create (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey updateChild

    /// Update the items of a ShellItem, given previous and current view elements
    let updateShellItemItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.ShellItem) _ =
        let create (desc: ViewElement) =
            match desc.Create() with
            | :? ShellContent as shellContent -> ShellSection.op_Implicit shellContent
            | :? TemplatedPage as templatedPage -> ShellSection.op_Implicit templatedPage
            | :? ShellSection as shellSection -> shellSection
            | child -> failwithf "%s is not compatible with the type ShellSection" (child.GetType().Name)

        let update prevViewElement (currViewElement: ViewElement) (target: ShellSection) =
            let realTarget =
                match currViewElement.TargetType with
                | t when t = typeof<ShellContent> -> target.Items.[0] :> BaseShellItem
                | t when t = typeof<TemplatedPage> -> target.Items.[0] :> BaseShellItem
                | _ -> target :> BaseShellItem
            updateChild prevViewElement currViewElement realTarget

        updateCollectionGeneric prevCollOpt collOpt target.Items create (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey update

    /// Update the items of a ShellSection, given previous and current view elements
    let updateShellSectionItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.ShellSection) _ =
        let create (desc: ViewElement) =
            desc.Create() :?> Xamarin.Forms.ShellContent

        updateCollectionGeneric prevCollOpt collOpt target.Items create (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey updateChild

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
        match prevValueOpt, currValueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueSome prevValue, ValueSome currValue ->
            let searchHandler = Shell.GetSearchHandler(target)
            currValue.UpdateIncremental(prevValue, searchHandler)
        | ValueNone, ValueSome currValue -> Shell.SetSearchHandler(target, currValue.Create() :?> Xamarin.Forms.SearchHandler)
        | ValueSome _, ValueNone -> target.ClearValue Shell.SearchHandlerProperty

    let updateShellBackgroundColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetBackgroundColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.BackgroundColorProperty

    let updateShellForegroundColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetForegroundColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.ForegroundColorProperty

    let updateShellTitleColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTitleColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TitleColorProperty

    let updateShellDisabledColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetDisabledColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.DisabledColorProperty

    let updateShellUnselectedColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetUnselectedColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.UnselectedColorProperty

    let updateShellTabBarBackgroundColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarBackgroundColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarBackgroundColorProperty

    let updateShellTabBarForegroundColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarForegroundColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarForegroundColorProperty

    let updateShellBackButtonBehavior prevValueOpt (currValueOpt: ViewElement voption) target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetBackButtonBehavior(target, currValue.Create() :?> BackButtonBehavior)
        | ValueSome _, ValueNone -> target.ClearValue Shell.BackButtonBehaviorProperty

    let updateShellTitleView prevValueOpt (currValueOpt: ViewElement voption) target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTitleView(target, currValue.Create() :?> View)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TitleViewProperty

    let updateShellFlyoutBehavior prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetFlyoutBehavior(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.FlyoutBehaviorProperty

    let updateShellTabBarIsVisible prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarIsVisible(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarIsVisibleProperty

    let updateShellNavBarIsVisible prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetNavBarIsVisible(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.NavBarIsVisibleProperty

    let updateShellPresentationMode prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetPresentationMode(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.PresentationModeProperty

    let updateShellTabBarDisabledColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarDisabledColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarDisabledColorProperty

    let updateShellTabBarTitleColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarTitleColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarTitleColorProperty

    let updateShellTabBarUnselectedColor prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetTabBarUnselectedColor(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.TabBarUnselectedColorProperty

    let updateNavigationPageHasNavigationBar prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> NavigationPage.SetHasNavigationBar(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue NavigationPage.HasNavigationBarProperty
        
    let updateShellContentContentTemplate prevValueOpt currValueOpt (target : Xamarin.Forms.ShellContent) =
        updateDirectViewElementDataTemplate
            (fun v -> target.ContentTemplate <- v)
            (fun () -> target.ClearValue ShellContent.ContentTemplateProperty)
            (fun () -> (target :> Xamarin.Forms.IShellContentController).Page)
            prevValueOpt
            currValueOpt

    let updateShellNavBarHasShadow prevValueOpt currValueOpt target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Shell.SetNavBarHasShadow(target, currValue)
        | ValueSome _, ValueNone -> target.ClearValue Shell.NavBarHasShadowProperty
        
    let updatePageUseSafeArea (prevValueOpt: bool voption) (currValueOpt: bool voption) (target: Xamarin.Forms.Page) =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(target, currValue)
        | ValueSome _, ValueNone -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(target, false)

    let triggerWebViewReload _ curr (target: Xamarin.Forms.WebView) =
        if curr = ValueSome true then target.Reload()
    
    let updateEntryCursorPosition prev curr (target: Xamarin.Forms.Entry) =
        match prev, curr with
        | ValueNone, ValueNone -> ()
        | _, ValueSome value -> target.CursorPosition <- value
        | ValueSome _, ValueNone -> target.ClearValue Entry.CursorPositionProperty
    
    let updateEntrySelectionLength prev curr (target: Xamarin.Forms.Entry) =
        match prev, curr with
        | ValueNone, ValueNone -> ()
        | _, ValueSome value -> target.SelectionLength <- value
        | ValueSome _, ValueNone -> target.ClearValue Entry.SelectionLengthProperty
        
    let updateMenuChildren (prevCollOpt: ViewElement array voption) (currCollOpt: ViewElement array voption) (target: Xamarin.Forms.Menu) _ =
        updateCollectionGeneric prevCollOpt currCollOpt target (fun _ -> target) (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey updateChild
        
    let updateElementEffects (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.Element) _ =
        let create (viewElement: ViewElement) =
            match viewElement.Create() with
            | :? CustomEffect as customEffect -> Effect.Resolve(customEffect.Name)
            | effect -> effect :?> Xamarin.Forms.Effect
        updateCollectionGeneric prevCollOpt collOpt target.Effects create (fun _ _ _ -> ()) ViewHelpers.canReuseView ViewHelpers.getKey updateChild
        
    let updatePageToolbarItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.Page) _ =
        let create (viewElement: ViewElement) =
            viewElement.Create() :?> Xamarin.Forms.ToolbarItem
        
        updateCollectionGeneric prevCollOpt collOpt target.ToolbarItems create (fun _ _ _ -> ()) ViewHelpers.canReuseView ViewHelpers.getKey updateChild

    let updateElementMenu prevValueOpt (currValueOpt: ViewElement voption) target =
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | _, ValueSome currValue -> Element.SetMenu(target, currValue.Create() :?> Menu)
        | ValueSome _, ValueNone -> target.ClearValue Element.MenuProperty
        
    // The CarouselView/IndicatorView combo in Xamarin.Forms is special.
    // A CarouselView can be linked to an IndicatorView, we're using a ViewRef<IndicatorView> to handle that.
    //
    // But since the IndicatorView can be placed anywhere in the UI tree relatively to the CarouselView, and that ViewRef is late-bound (only resolved when actually instantiating the IndicatorView control),
    // there's no guarantee that when calling updateCarouselViewIndicatorView, the ViewRef will be bound.
    //
    // It means we need to create the link between the actual CarouselView and IndicatorView instances once ViewRef is bound.
    // For that, we have a ViewRef.ValueChanged event we can listen to.
    //
    // But we need to store the handlers somewhere. Not on the ViewElements (they're supposed to be immutable and user-driven), not on the controls instances (we can't store arbitrary values on those).
    // This means, we need to store them here, globally.
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
        
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | ValueNone, ValueNone -> ()
        | ValueSome prevValue, ValueNone ->
            let handler = getHandler()
            prevValue.ValueChanged.RemoveHandler(handler)
            removeCarouselViewHandler target
            linkIndicatorViewToCarouselView target null
        | ValueNone, ValueSome currValue ->
            let handler = getHandler()
            currValue.ValueChanged.AddHandler(handler)
            tryLinkIndicatorViewToCarouselView target currValue
        | ValueSome prevValue, ValueSome currValue ->
            let handler = getHandler()
            prevValue.ValueChanged.RemoveHandler(handler)
            currValue.ValueChanged.AddHandler(handler)
            tryLinkIndicatorViewToCarouselView target currValue            

    let updateSwipeItems (prevCollOpt: ViewElement array voption) (collOpt: ViewElement array voption) (target: Xamarin.Forms.SwipeItems) =
        let create (desc: ViewElement) =
            desc.Create() :?> Xamarin.Forms.ISwipeItem

        updateCollectionGeneric prevCollOpt collOpt target create (fun _ _ _ -> ()) (fun _ _ -> true) ViewHelpers.getKey updateChild

    // This function could be automatically generated by CodeGen, but the BindingProperty field StepperPositionProperty is currently marked private, preventing that.
    // See https://github.com/xamarin/Xamarin.Forms/issues/10148
    let updateStepperPosition prevStepperPositionOpt currStepperPositionOpt (target: Xamarin.Forms.Stepper) =
        match prevStepperPositionOpt, currStepperPositionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StepperPosition <-  currValue
        | ValueSome _, ValueNone -> target.StepperPosition <- 0
        | ValueNone, ValueNone -> ()
        
    let updateIndicatorViewIndicatorProperty prevValueOpt currValueOpt (target: Xamarin.Forms.IndicatorView) =
        updateDirectViewElementDataTemplate
            (fun v -> target.IndicatorTemplate <- v)
            (fun () -> target.ClearValue IndicatorView.IndicatorTemplateProperty)
            (fun () -> target)
            prevValueOpt
            currValueOpt