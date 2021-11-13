namespace Fabulous

open Fabulous

module Reconciler =
    /// This is insertion sort that is O(n*n) but it performs better
    /// 1. if the array is partially sorted (second sort is cheap)
    /// 2. there are few elements, we expect to have only a handful of them per widget
    /// 3. stable, which is handy for duplicate attributes, e.g. we can choose which one to pick
    /// https://en.wikipedia.org/wiki/Insertion_sort
    let inline private sortAttributesInPlace (attrs: Attribute []) : Attribute [] =
        let N = attrs.GetLength(0)

        for i in [ 1 .. N - 1 ] do
            for j = i downto 1 do
                if attrs.[j].Key < attrs.[j - 1].Key then
                    let temp = attrs.[j]
                    attrs.[j] <- attrs.[j - 1]
                    attrs.[j - 1] <- temp

        attrs

    /// Let's imagine that we have the following situation
    /// prev = [|1,2,6,7|] note that it is sorted
    /// next = [|8,5,6,2|] unsorted
    /// In reality we have Key and Value, but let's pretend that we only care about keys for now
    ///
    /// then the desired outcome is this
    /// added = [5, 8]
    /// removed = [1, 7]
    ///
    /// Approach
    /// 1. we sort both arrays
    /// prev = [|1,2,6,7|]
    /// next = [|2,5,6,8|]
    ///
    /// 2. Starting from index 0 for both of the arrays
    ///     if prevItem < nextItem then
    ///         inc prevIndex, add prevItem to removed, goto 2
    ///     if prevItem > nextItem
    ///         inc nextIndex, add nextItem to added, goto 2
    ///     else (meaning equals)
    ///         compare values
    ///
    /// break when we reached both ends of the arrays
    let diffAttributes (prev: Attribute []) (next: Attribute []) : AttributeChange[] =
        // the order of attributes doesn't matter, thus it is safe to mutate array in place
        prev |> sortAttributesInPlace |> ignore
        next |> sortAttributesInPlace |> ignore

        let mutable result: AttributeChange list = []

        let mutable prevIndex = 0
        let mutable nextIndex = 0

        let prevLength = prev.Length
        let nextLength = next.Length

        while not(prevIndex >= prevLength && nextIndex >= nextLength) do
            if prevIndex = prevLength then
                // that means we are done with the prev and only need to add next's tail to added
                result <- AttributeChange.Added next.[nextIndex] :: result
                nextIndex <- nextIndex + 1

            elif nextIndex = nextLength then
                // that means that we are done with new items and only need prev's tail to removed
                result <- AttributeChange.Removed prev.[prevIndex] :: result
                prevIndex <- prevIndex + 1

            else
                // we haven't reached either of the ends
                let prevAttr = prev.[prevIndex]
                let nextAttr = next.[nextIndex]

                let prevKey = prevAttr.Key
                let nextKey = nextAttr.Key

                match prevKey.CompareTo nextKey with
                | c when c < 0 ->
                    // prev key is less than next -> remove prev key
                    result <- AttributeChange.Removed prevAttr :: result
                    prevIndex <- prevIndex + 1

                | c when c > 0 ->
                    // prev key is more than next -> add next item
                    result <- AttributeChange.Added nextAttr :: result
                    nextIndex <- nextIndex + 1

                | _ ->
                    // means that we are targeting the same attribute

                    // move both pointers
                    prevIndex <- prevIndex + 1
                    nextIndex <- nextIndex + 1

                    let definition =
                        AttributeDefinitionStore.get prevAttr.Key

                    let changeOpt =
                        match definition.CompareBoxed(prevAttr.Value, nextAttr.Value) with

                        // Previous and next values are identical, we don't need to do anything
                        | AttributeComparison.Identical -> ValueNone

                        // New value completely replaces the old value
                        | AttributeComparison.ReplacedBy value ->
                            ValueSome (AttributeChange.ScalarUpdated(nextAttr))

                        // Values are widgets and are different, we have the list of attribute changes between the 2 widgets 
                        | AttributeComparison.WidgetDifferent changes ->
                            ValueSome (AttributeChange.WidgetUpdated(nextAttr, changes))

                        | AttributeComparison.WidgetCollectionDifferent changes ->
                            ValueSome (AttributeChange.WidgetCollectionUpdated(nextAttr, changes))

                    match changeOpt with
                    | ValueNone -> ()
                    | ValueSome change -> result <- change :: result

        List.rev result |> List.toArray

    let diffCollections (canReuse: Widget -> Widget -> bool) (prev: Widget array) (next: Widget array) : WidgetCollectionChange[] =
        let mutable target = []

        if prev.Length > next.Length then
            for i = next.Length to prev.Length - 1 do
                target <- (WidgetCollectionChange.Remove i) :: target

        for i = 0 to next.Length - 1 do
            let currItem = next.[i]
            let prevItemOpt = Array.tryItem i prev

            let changeOpt =
                match prevItemOpt with
                | None -> ValueSome (WidgetCollectionChange.Insert struct (i, currItem))

                | Some prevItem when canReuse prevItem currItem ->
                    match diffAttributes prevItem.Attributes currItem.Attributes with
                    | [||] -> ValueNone
                    | diffs -> ValueSome (WidgetCollectionChange.Update struct (i, diffs))

                | Some prevItem -> ValueSome (WidgetCollectionChange.Replace struct (i, currItem))

            match changeOpt with
            | ValueNone -> ()
            | ValueSome change -> target <- change :: target

        List.rev target |> List.toArray

    /// Diffs changes and applies them on the target
    let rec update (getViewNode: obj -> IViewNode) (target: obj) (attributes: Attribute []) : unit =
        let viewNode = getViewNode target
        let prevAttributes = viewNode.Attributes

        match diffAttributes prevAttributes attributes with
        | [||] -> ()
        | diffs -> viewNode.ApplyDiff(diffs)

// 1. compare attributes for control and widget
// 2. apply diff (should be a method on control). e.g control.ApplyDiff(diff)
// 3. apply returns UpdateResult
// 4. if we have 'Done' then exit
// 5. if we have 'UpdateNext' go through the list and recursively call update on each element

// Questions
// 1. should adding/removing children should be done here as well?
// 2. Should 'mounting' views done by core framework or should be part of MAUI? I think the latter is fine
// 3. Should widgets have 1st class parent -> child relationships like in react?
// Meaning that we can fully control creations of new controls via core

// TODO find a better file/home for this logic
//module Runtime =
//    let MapMsg =
//        Attributes.defineWithComparer<obj -> obj>
//            "MapMsg"
//            (fun () -> id )
//            // TODO should this be a type check? E.g. what "dependsOn" uses internally?
//            Attributes.AttributeComparers.noCompare

//    let MapMsgKey = MapMsg.Key

//    let inline dispatchOnNode (node: IViewNode) (ctx: ViewTreeContext) (ev: obj): unit =
//        let inline mapEv (e: obj) (attributes: Attribute[]) =
//            match (Array.tryFind (fun (a: Attribute) -> a.Key = MapMsgKey) attributes) with
//            | Some attr -> unbox<obj -> obj>attr.Value e
//            | None -> e
        
//        let mutable ev = mapEv ev node.Attributes
//        for ancestor in ctx.Ancestors do
//            ev <- mapEv ev ancestor.Attributes
        
//        ctx.Dispatch ev
            
module AttributeComparers =
    let noCompare struct (a, b) = AttributeComparison.ReplacedBy b

    let equalityCompare struct (a, b) =
        if a = b then
            AttributeComparison.Identical
        else
            AttributeComparison.ReplacedBy b

    /// Determine the differences between 2 widgets
    /// Check also for reusability of the target control
    let compareWidgets (canReuse: Widget -> Widget -> bool) struct (prevWidget: Widget, currWidget: Widget) =
        if not (canReuse prevWidget currWidget) then
            AttributeComparison.ReplacedBy currWidget
        elif prevWidget = currWidget then
            AttributeComparison.Identical
        else
            let diffs = Reconciler.diffAttributes prevWidget.Attributes currWidget.Attributes
            AttributeComparison.WidgetDifferent diffs

    /// Determine the differences between 2 collections
    let compareWidgetCollections (canReuse: Widget -> Widget -> bool) struct (prevColl: Widget array, currColl: Widget array) =
        let diffs = Reconciler.diffCollections canReuse prevColl currColl
        AttributeComparison.WidgetCollectionDifferent diffs
