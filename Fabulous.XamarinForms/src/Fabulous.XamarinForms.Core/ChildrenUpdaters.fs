namespace Fabulous.XamarinForms

open Fabulous
open System.Collections.Generic
open Xamarin.Forms

module ChildrenUpdaters =    
    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/move/create/update/remove operations
    ///
    /// The algorithm will try in priority to update elements sharing the same instance (usually achieved with dependsOn)
    /// or sharing the same key. All other elements will try to reuse previous elements where possible.
    /// If no reuse is possible, the element will create a new control.
    let updateChildrenInternal
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
            
            // Separate the previous elements into 3 lists
            // The ones whose instances have been reused (dependsOn)
            // The ones whose keys have been reused
            // The rest which can be reused by any other element
            let identicalElements = HashSet<'T>()
            let keyedElements = Dictionary<string, 'T>()
            let reusableElements = ResizeArray<'T>()
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
                        | _ ->
                            reusableElements.Add(prevChild)
            
            // Reuse the first element from reusableElements that returns true to canReuse
            // Otherwise create a new element
            let reuseOrCreate newIndex newChild =
                match reusableElements |> Seq.tryFind(fun c -> canReuse c newChild) with
                | Some prevChild ->
                    reusableElements.Remove prevChild |> ignore
                    
                    let prevIndex = currentState.IndexOf(prevChild)
                    update prevIndex prevChild newChild
                            
                    if prevIndex <> newIndex then
                        move prevIndex newIndex
                        
                | None ->
                    create newIndex newChild
            
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
            
            // If we still have old elements that were not reused, delete them
            if reusableElements.Count > 0 then
                for remainingElement in reusableElements do
                    let prevIndex = currentState.IndexOf(remainingElement)
                    remove prevIndex

    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/add/remove/insert operations
    let updateChildren
           (prevCollOpt: ViewElement[] voption) 
           (collOpt: ViewElement[] voption) 
           (targetColl: IList<'TargetT>) 
           (create: ViewElement -> 'TargetT)
           (update: ViewElement -> ViewElement -> 'TargetT -> unit) // Incremental element-wise update, only if element reuse is allowed
           (attach: ViewElement voption -> ViewElement -> 'TargetT -> unit) // adjust attached properties
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
        
        updateChildrenInternal
            prevCollOpt collOpt ViewHelpers.tryGetKey ViewHelpers.canReuseView
            (fun () -> targetColl.Clear())
            create update move
            (fun index -> targetColl.RemoveAt(index))

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

