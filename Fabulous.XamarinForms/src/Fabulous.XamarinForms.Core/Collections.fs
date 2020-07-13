namespace Fabulous.XamarinForms

open Fabulous
open System.Collections
open System.Collections.Generic
open System.Collections.ObjectModel
open Xamarin.Forms

/// This module contains the update logic for the controls with children
module Collections =
    type Operation<'T> =
        | Insert of index: int *  element: 'T
        | Move of oldIndex: int * newIndex: int
        | Update of index: int * prev: 'T * curr: 'T
        | MoveAndUpdate of oldIndex: int * prev: 'T * newIndex: int * curr: 'T
        | Delete of oldIndex: int
        
    type DiffResult<'T> =
        | NoChange
        | ClearCollection
        | Operations of Operation<'T> list
    
    /// Returns a list of operations to apply to go from the initial list to the new list
    ///
    /// The algorithm will try in priority to update elements sharing the same instance (usually achieved with dependsOn)
    /// or sharing the same key. All other elements will try to reuse previous elements where possible.
    /// If no reuse is possible, the element will create a new control.
    ///
    /// In aggressive reuse mode, the algorithm will try to reuse any reusable element.
    /// In the non-aggressive reuse mode, the algorithm will try to reuse a reusable element only if it is at the same index
    let diff<'T when 'T : equality>
            (aggressiveReuseMode: bool)
            (prevCollOpt: 'T[] voption)
            (collOpt: 'T[] voption)
            (keyOf: 'T -> string voption)
            (canReuse: 'T -> 'T -> bool)
        =
        
        match prevCollOpt, collOpt with
        | ValueNone, ValueNone -> NoChange
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> NoChange
        | ValueSome prevColl, ValueSome newColl when prevColl <> null && newColl <> null && prevColl.Length = 0 && newColl.Length = 0 -> NoChange
        | ValueSome _, ValueNone -> ClearCollection
        | ValueSome _, ValueSome coll when (coll = null || coll.Length = 0) -> ClearCollection
        | _, ValueSome coll ->
            // Separate the previous elements into 4 lists
            // The ones whose instances have been reused (dependsOn)
            // The ones whose keys have been reused and should be updated
            // The ones whose keys have not been reused and should be discarded
            // The rest which can be reused by any other element
            let identicalElements = Dictionary<'T, int>()
            let keyedElements = Dictionary<string, int * 'T>()
            let reusableElements = ResizeArray<int * 'T>()
            let discardedElements = ResizeArray<int>()
            if prevCollOpt.IsSome && prevCollOpt.Value.Length > 0 then
                for prevIndex in 0 .. prevCollOpt.Value.Length - 1 do
                    let prevChild = prevCollOpt.Value.[prevIndex]
                    if coll |> Array.exists (identical prevChild) then
                        identicalElements.Add(prevChild, prevIndex) |> ignore
                    else
                        let canReuseChildOf key =
                            coll
                            |> Array.exists (fun newChild ->
                                keyOf newChild = ValueSome key
                                && canReuse prevChild newChild
                            )
                        
                        match keyOf prevChild with
                        | ValueSome key when canReuseChildOf key ->
                            keyedElements.Add(key, (prevIndex, prevChild))
                        | ValueNone ->
                            reusableElements.Add((prevIndex, prevChild))
                        | ValueSome _ ->
                            discardedElements.Add(prevIndex)
            
            let operations =
                [ for i in 0 .. coll.Length - 1 do
                    let newChild = coll.[i]
                    
                    // Check if the same instance was reused (dependsOn), if so just move the element to the correct index
                    match identicalElements.TryGetValue(newChild) with
                    | (true, prevIndex) ->
                        if prevIndex <> i then yield Move (prevIndex, i)
                    | _ ->
                        // If the key existed previously, reuse the previous element
                        match keyOf newChild with
                        | ValueSome key when keyedElements.ContainsKey(key) -> 
                            let prevIndex, prevChild = keyedElements.[key]
                            if prevIndex <> i then
                                yield MoveAndUpdate (prevIndex, prevChild, i, newChild)
                            else
                                yield Update (i, prevChild, newChild)
                        
                        // Otherwise, reuse an old element if possible or create a new one
                        | _ ->
                            let isMatch (index, reusableChild) =
                                canReuse reusableChild newChild
                                && (aggressiveReuseMode || index = i)
                                
                            match reusableElements |> Seq.tryFind isMatch with
                            | Some ((prevIndex, prevChild) as item) ->
                                reusableElements.Remove item |> ignore
                                if prevIndex <> i then
                                    yield MoveAndUpdate (prevIndex, prevChild, i, newChild)
                                else
                                    yield Update (i, prevChild, newChild)
                                
                            | None ->
                                yield Insert (i, newChild)
                                
                  // If we have discarded elements, delete them
                  if discardedElements.Count > 0 then
                      for prevIndex in discardedElements do
                          yield Delete prevIndex
                
                  // If we still have old elements that were not reused, delete them
                  if reusableElements.Count > 0 then
                    for prevIndex, _ in reusableElements do
                        yield Delete prevIndex ]
            
            if operations.Length = 0 then
                NoChange
            else
                Operations operations
            
    /// Reduces the operations of the DiffResult to be applicable to an ObservableCollection.
    /// 
    /// diff returns all the operations to move from List A to List B.
    /// Except with ObservableCollection, we're forced to apply the changes one after the other, changing the indices
    /// So this algorithm compensates this offsetting
    let adaptDiffForObservableCollection (prevCollLength: int) (diffResult: DiffResult<'T>) : DiffResult<'T> =
        match diffResult with
        | NoChange -> NoChange
        | ClearCollection -> ClearCollection
        | Operations operations ->
            let prevIndices = Array.init prevCollLength id
            
            // Shift all old indices by 1 (down the list) on insert after the inserted position
            let shiftForInsert index =
                for i in 0 .. prevIndices.Length - 1 do
                    if prevIndices.[i] >= index then
                        prevIndices.[i] <- prevIndices.[i] + 1
            
            // Shift all old indices by -1 (up the list) on delete after the deleted position
            let shiftForDelete originalIndexInPrevColl prevIndex =
                for i in 0 .. prevIndices.Length - 1 do
                    if prevIndices.[i] > prevIndex then
                        prevIndices.[i] <- prevIndices.[i] - 1
                prevIndices.[originalIndexInPrevColl] <- -1 
            
            // Shift all old indices between the previous and new position on move
            let shiftForMove originalIndexInPrevColl prevIndex newIndex =
                for i in 0 .. prevIndices.Length - 1 do
                    if prevIndex < prevIndices.[i] && prevIndices.[i] <= newIndex then
                        prevIndices.[i] <- prevIndices.[i] - 1
                    else if newIndex <= prevIndices.[i] && prevIndices.[i] < prevIndex then
                        prevIndices.[i] <- prevIndices.[i] + 1
                prevIndices.[originalIndexInPrevColl] <- newIndex
                
            // Return an update operation preceded by a move only if actual indices don't match
            let moveAndUpdate oldIndex prev newIndex curr =
                let prevIndex = prevIndices.[oldIndex]
                if prevIndex = newIndex then
                    Update (newIndex, prev, curr)
                else
                    shiftForMove oldIndex prevIndex newIndex
                    MoveAndUpdate (prevIndex, prev, newIndex, curr)
                
            let operations =
                [ for op in operations do
                    match op with
                    | Insert (index, element) ->
                        yield Insert (index, element)
                        shiftForInsert index
                        
                    | Move (oldIndex, newIndex) ->
                        // Prevent a move if the actual indices match
                        let prevIndex = prevIndices.[oldIndex]
                        if prevIndex <> newIndex then
                            yield (Move (prevIndex, newIndex))
                            shiftForMove oldIndex prevIndex newIndex
                            
                    | Update (index, prev, curr) ->
                        yield moveAndUpdate index prev index curr
                        
                    | MoveAndUpdate (oldIndex, prev, newIndex, curr) ->
                        yield moveAndUpdate oldIndex prev newIndex curr
                        
                    | Delete oldIndex ->
                        let prevIndex = prevIndices.[oldIndex]
                        yield Delete prevIndex
                        shiftForDelete oldIndex prevIndex ]
            
            if operations.Length = 0 then
                NoChange
            else
                Operations operations

    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/add/remove/insert operations
    let updateCollection
           (aggressiveReuseMode: bool)
           (prevCollOpt: 'T[] voption) 
           (collOpt: 'T[] voption) 
           (targetColl: IList<'TargetT>) 
           (keyOf: 'T -> string voption)
           (canReuse: 'T -> 'T -> bool)
           (create: 'T -> 'TargetT)
           (update: 'T -> 'T -> 'TargetT -> unit) // Incremental element-wise update, only if element reuse is allowed
           (attach: 'T voption -> 'T -> 'TargetT -> unit) // adjust attached properties
        =
        
        let diffResult =
            diff aggressiveReuseMode prevCollOpt collOpt keyOf canReuse
            |> adaptDiffForObservableCollection (match prevCollOpt with ValueNone -> 0 | ValueSome c -> c.Length)
        
        match diffResult with
        | NoChange -> ()
        | ClearCollection -> targetColl.Clear()
        | Operations operations ->
            for op in operations do
                match op with
                | Insert (index, element) ->
                    let child = create element
                    attach ValueNone element child
                    targetColl.Insert(index, child)
                    
                | Move (prevIndex, newIndex) ->
                    let child = targetColl.[prevIndex]
                    targetColl.RemoveAt(prevIndex)
                    targetColl.Insert(newIndex, child)
                        
                | Update (index, prev, curr) ->
                    let child = targetColl.[index]
                    update prev curr child
                    attach (ValueSome prev) curr child
                    
                | MoveAndUpdate (prevIndex, prev, newIndex, curr) ->
                    let child = targetColl.[prevIndex]
                    targetColl.RemoveAt(prevIndex)
                    targetColl.Insert(newIndex, child)
                    update prev curr child
                    attach (ValueSome prev) curr child
                    
                | Delete index ->
                    targetColl.RemoveAt(index) |> ignore
                        
    let updateChildren prevCollOpt collOpt target create update attach =
        updateCollection true prevCollOpt collOpt target ViewHelpers.tryGetKey ViewHelpers.canReuseView create update attach
                        
    let updateItems prevCollOpt collOpt target keyOf canReuse create update attach =
        updateCollection false prevCollOpt collOpt target keyOf canReuse create update attach

    /// Update a control given the previous and new view elements
    let inline updateChild (prevChild: ViewElement) (newChild: ViewElement) targetChild = 
        newChild.UpdateIncremental(prevChild, targetChild)
        
    /// Update the items of a TableSectionBase<'T> control, given previous and current view elements
    let inline updateTableSectionBaseOfTItems<'T when 'T :> BindableObject> prevCollOpt collOpt (target: TableSectionBase<'T>) attach =
        updateChildren prevCollOpt collOpt target (fun c -> c.Create() :?> 'T) updateChild attach

    /// Update the items of a Shell, given previous and current view elements
    let inline updateShellItems prevCollOpt collOpt (target: Shell) attach =
        let createChild (desc: ViewElement) =
            match desc.Create() with
            | :? ShellContent as shellContent -> ShellItem.op_Implicit shellContent
            | :? TemplatedPage as templatedPage -> ShellItem.op_Implicit templatedPage
            | :? ShellSection as shellSection -> ShellItem.op_Implicit shellSection
            | :? MenuItem as menuItem -> ShellItem.op_Implicit menuItem
            | :? ShellItem as shellItem -> shellItem
            | child -> failwithf "%s is not compatible with the type ShellItem" (child.GetType().Name)

        let updateChild prevViewElement (currViewElement: ViewElement) (target: ShellItem) =
            let realTarget =
                match currViewElement.TargetType with
                | t when t = typeof<ShellContent> -> target.Items.[0].Items.[0] :> Element
                | t when t = typeof<TemplatedPage> -> target.Items.[0].Items.[0] :> Element
                | t when t = typeof<ShellSection> -> target.Items.[0] :> Element
                | t when t = typeof<MenuItem> -> target.GetType().GetProperty("MenuItem").GetValue(target) :?> Element // MenuShellItem is marked as internal
                | _ -> target :> Element
            updateChild prevViewElement currViewElement realTarget

        updateChildren prevCollOpt collOpt target.Items createChild updateChild attach
        
    /// Update the menu items of a ShellContent, given previous and current view elements
    let inline updateShellContentMenuItems prevCollOpt collOpt (target: ShellContent) =
        updateChildren prevCollOpt collOpt target.MenuItems (fun c -> c.Create() :?> MenuItem) updateChild (fun _ _ _ -> ())

    /// Update the items of a ShellItem, given previous and current view elements
    let inline updateShellItemItems prevCollOpt collOpt (target: ShellItem) attach =
        let createChild (desc: ViewElement) =
            match desc.Create() with
            | :? ShellContent as shellContent -> ShellSection.op_Implicit shellContent
            | :? TemplatedPage as templatedPage -> ShellSection.op_Implicit templatedPage
            | :? ShellSection as shellSection -> shellSection
            | child -> failwithf "%s is not compatible with the type ShellSection" (child.GetType().Name)

        let updateChild prevViewElement (currViewElement: ViewElement) (target: ShellSection) =
            let realTarget =
                match currViewElement.TargetType with
                | t when t = typeof<ShellContent> -> target.Items.[0] :> BaseShellItem
                | t when t = typeof<TemplatedPage> -> target.Items.[0] :> BaseShellItem
                | _ -> target :> BaseShellItem
            updateChild prevViewElement currViewElement realTarget

        updateChildren prevCollOpt collOpt target.Items createChild updateChild attach

    /// Update the items of a ShellSection, given previous and current view elements
    let inline updateShellSectionItems prevCollOpt collOpt (target: ShellSection) attach =
        updateChildren prevCollOpt collOpt target.Items (fun c -> c.Create() :?> ShellContent) updateChild attach

    /// Update the items of a SwipeItems, given previous and current view elements
    let inline updateSwipeItems prevCollOpt collOpt (target: SwipeItems) =
        updateChildren prevCollOpt collOpt target (fun c -> c.Create() :?> ISwipeItem) updateChild (fun _ _ _ -> ())
            
    /// Update the children of a Menu, given previous and current view elements
    let inline updateMenuChildren prevCollOpt collOpt (target: Menu) attach =
        updateChildren prevCollOpt collOpt target (fun c -> c.Create() :?> Menu) updateChild attach
        
    /// Update the effects of an Element, given previous and current view elements
    let inline updateElementEffects prevCollOpt collOpt (target: Element) attach =
        let createChild (desc: ViewElement) =
            match desc.Create() with
            | :? CustomEffect as customEffect -> Effect.Resolve(customEffect.Name)
            | effect -> effect :?> Effect
            
        updateChildren prevCollOpt collOpt target.Effects createChild updateChild attach
        
    /// Update the toolbar items of a Page, given previous and current view elements
    let inline updatePageToolbarItems prevCollOpt collOpt (target: Page) attach =
        updateChildren prevCollOpt collOpt target.ToolbarItems (fun c -> c.Create() :?> ToolbarItem) updateChild attach
    
    let inline updateViewElementHolderItems (prevCollOpt: ViewElement[] voption) (collOpt: ViewElement[] voption) (targetColl: IList<ViewElementHolder>) =
        updateItems prevCollOpt collOpt targetColl
            ViewHelpers.tryGetKey ViewHelpers.canReuseView
            ViewElementHolder (fun _ curr holder -> holder.ViewElement <- curr)
    
    let inline getCollection<'T> (coll: IEnumerable) (set: ObservableCollection<'T> -> unit) =
        match coll with 
        | :? ObservableCollection<'T> as oc -> oc
        | _ -> let oc = ObservableCollection<'T>() in set oc; oc
    
    /// Update the items in a ItemsView control, given previous and current view elements
    let inline updateItemsViewItems prevCollOpt collOpt (target: ItemsView) =
        let targetColl = getCollection<ViewElementHolder> target.ItemsSource (fun oc -> target.ItemsSource <- oc)
        updateViewElementHolderItems prevCollOpt collOpt targetColl (fun _ _ _ -> ())
                    
    /// Update the items in a ItemsView<'T> control, given previous and current view elements
    let inline updateItemsViewOfTItems<'T when 'T :> BindableObject> prevCollOpt collOpt (target: ItemsView<'T>) = 
        let targetColl = getCollection<ViewElementHolder> target.ItemsSource (fun oc -> target.ItemsSource <- oc)
        updateViewElementHolderItems prevCollOpt collOpt targetColl (fun _ _ _ -> ())
        
    /// Update the items in a SearchHandler control, given previous and current view elements
    let inline updateSearchHandlerItems _ collOpt (target: SearchHandler) = 
        let targetColl = List<ViewElementHolder>()
        updateViewElementHolderItems ValueNone collOpt targetColl (fun _ _ _ -> ())
        target.ItemsSource <- targetColl

    /// Update the items in a GroupedListView control, given previous and current view elements
    let inline updateListViewGroupedItems (prevCollOpt: (string * ViewElement * ViewElement[])[] voption) (collOpt: (string * ViewElement * ViewElement[])[] voption) (target: ListView) =
        let updateViewElementHolderGroup (_prevShortName: string, _prevKey, prevColl: ViewElement[]) (currShortName: string, currKey, currColl: ViewElement[]) (target: ViewElementHolderGroup) =
            target.ShortName <- currShortName
            target.ViewElement <- currKey
            updateViewElementHolderItems (ValueSome prevColl) (ValueSome currColl) target (fun _ _ _ -> ())
                
        let targetColl = getCollection<ViewElementHolderGroup> target.ItemsSource (fun oc -> target.ItemsSource <- oc)
        updateItems prevCollOpt collOpt targetColl
            (fun (key, _, _) -> ValueSome key)
            (fun (_, prevHeader, _) (_, currHeader, _) -> ViewHelpers.canReuseView prevHeader currHeader)
            ViewElementHolderGroup updateViewElementHolderGroup
            (fun _ _ _ -> ())
                    
    /// Update the selected items in a SelectableItemsView control, given previous and current indexes
    let inline updateSelectableItemsViewSelectedItems (prevCollOptOpt: int[] option voption) (collOptOpt: int[] option voption) (target: SelectableItemsView) = 
        let prevCollOpt = match prevCollOptOpt with ValueNone | ValueSome None -> ValueNone | ValueSome (Some x) -> ValueSome x
        let collOpt = match collOptOpt with ValueNone | ValueSome None -> ValueNone | ValueSome (Some x) -> ValueSome x
        let targetColl = getCollection<obj> target.SelectedItems (fun oc -> target.SelectedItems <- oc)
        
        let findItem idx =
            let itemsSource = target.ItemsSource :?> IList<ViewElementHolder>
            itemsSource.[idx] :> obj
        
        updateItems prevCollOpt collOpt targetColl (fun _ -> ValueNone) (fun x y -> x = y) findItem (fun _ _ _ -> ()) (fun _ _ _ -> ())