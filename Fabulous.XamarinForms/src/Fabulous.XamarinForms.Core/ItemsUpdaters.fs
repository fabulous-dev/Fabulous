namespace Fabulous.XamarinForms

open Fabulous
open System.Collections
open System.Collections.Generic
open System.Collections.ObjectModel
open Xamarin.Forms

module ItemsUpdaters =    
    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/move/create/update/remove operations
    ///
    /// The algorithm will try in priority to update elements sharing the same instance (usually achieved with dependsOn)
    /// or sharing the same key. All other elements will try to reuse previous elements where possible.
    /// If no reuse is possible, the element will create a new control.
    let updateItemsInternal
            (prevCollOpt: 'T[] voption)
            (collOpt: 'T[] voption)
            (keyOf: 'T -> string voption)
            (canReuse: 'T -> 'T -> bool)
            (clear: unit -> unit)
            (create: int -> 'T -> unit)
            (update: int -> 'T -> 'T -> unit)
            (move: int -> int -> unit)
            (remove: int -> unit)
        =
        
        match prevCollOpt, collOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | ValueSome prevColl, ValueSome newColl when prevColl <> null && newColl <> null && prevColl.Length = 0 && newColl.Length = 0 -> ()
        | ValueSome _, ValueNone -> clear ()
        | ValueSome _, ValueSome coll when (coll = null || coll.Length = 0) -> clear ()
        | _, ValueSome coll ->
            let currentState = match prevCollOpt with ValueSome x -> List(x) | _ -> List()
                
            let create newIndex newChild =
                currentState.Insert(newIndex, newChild)
                create newIndex newChild
                
            let move prevIndex newIndex =
                let child = currentState.[prevIndex]
                currentState.RemoveAt(prevIndex)
                currentState.Insert(newIndex, child)
                move prevIndex newIndex
                
            let remove index =
                currentState.RemoveAt(index)
                remove index
            
            // Separate the previous elements into 2 lists
            // The ones whose instances have been reused (dependsOn)
            // The ones whose keys have been reused
            let identicalElements = HashSet<'T>()
            let keyedElements = Dictionary<string, 'T>()
            if prevCollOpt.IsSome then
                for prevChild in prevCollOpt.Value do
                    if coll |> Array.exists (identical prevChild) then
                        identicalElements.Add(prevChild) |> ignore
                    else
                        let canReuseChildOf key =
                            coll
                            |> Array.exists (fun newChild ->
                                keyOf newChild = ValueSome key
                                && canReuse prevChild newChild
                            )
                        
                        match keyOf prevChild with
                        | ValueSome key when canReuseChildOf key ->
                            keyedElements.Add(key, prevChild)
                        | _ -> ()
            
            // Reuse the element from the same index if possible (not already reused and reusable)
            // Otherwise create a new element
            let reuseOrCreate index newChild =
                if prevCollOpt.IsSome && prevCollOpt.Value.Length > index then
                    let prevChild = prevCollOpt.Value.[index]
                    let key = keyOf prevChild
                    
                    if not (identicalElements.Contains(prevChild))
                       && (key.IsNone || not (keyedElements.ContainsKey(key.Value)))
                       && (canReuse prevChild newChild) then
                           update index prevChild newChild
                        
                    else
                        create index newChild
                else
                    create index newChild
            
            for i in 0 .. coll.Length - 1 do
                let newChild = coll.[i]
                
                // Check if the same instance was reused (dependsOn), if so just move the element to the correct index
                if identicalElements.Contains(newChild) then
                    let prevIndex = currentState.IndexOf(newChild)
                    if prevIndex <> i then
                        move prevIndex i
                else
                    // If the key existed previously, reuse the previous element
                    match keyOf newChild with
                    | ValueSome key when keyedElements.ContainsKey(key) ->
                        let prevChild = keyedElements.[key]
                        let prevIndex = currentState.IndexOf(prevChild)
                        update prevIndex prevChild newChild
                        
                        if prevIndex <> i then
                            move prevIndex i
                    
                    // Otherwise, reuse an old element if possible or create a new one
                    | _ ->
                        reuseOrCreate i newChild
            
            // Remove all the excess elements
            if prevCollOpt.IsSome && prevCollOpt.Value.Length > coll.Length then
                while currentState.Count > coll.Length do
                    remove (currentState.Count - 1)
                    
    let updateItems
           (prevCollOpt: 'T[] voption)
           (collOpt: 'T[] voption)
           (targetColl: IList<'TargetT>)
           (keyOf: 'T -> string voption)
           (canReuse: 'T -> 'T -> bool)
           (create: 'T -> 'TargetT)
           (update: 'T -> 'T -> 'TargetT -> unit)
           (attach: 'T voption -> 'T -> 'TargetT -> unit) // adjust attached properties
        =
        
        let create index child =
            let targetChild = create child
            attach ValueNone child targetChild
            targetColl.Insert(index, targetChild)
            
        let update index prevChild newChild =
            let targetChild = targetColl.[index]
            update prevChild newChild targetChild
            attach (ValueSome prevChild) newChild targetChild
            
        let move prevIndex newIndex =
            let targetChild = targetColl.[prevIndex]
            targetColl.RemoveAt(prevIndex)
            targetColl.Insert(newIndex, targetChild)
        
        updateItemsInternal
            prevCollOpt collOpt keyOf canReuse
            (fun () -> targetColl.Clear())
            create update move
            (fun index -> targetColl.RemoveAt(index))
    
    let inline updateViewElementHolderItems (prevCollOpt: ViewElement[] voption) (collOpt: ViewElement[] voption) (targetColl: ObservableCollection<ViewElementHolder>) =
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
    let inline updateSearchHandlerItems prevCollOpt collOpt (target: SearchHandler) = 
        let targetColl = getCollection<ViewElementHolder> target.ItemsSource (fun oc -> target.ItemsSource <- oc)
        updateViewElementHolderItems prevCollOpt collOpt targetColl (fun _ _ _ -> ())

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
