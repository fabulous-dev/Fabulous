namespace Fabulous

open Fabulous

module Reconciler =
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
//    let rec diffScalarAttributes
//        (prev: ScalarAttribute [] voption)
//        (next: ScalarAttribute [] voption)
//        : ScalarChange [] voption =
//        match (prev, next) with
//        | ValueNone, ValueNone -> ValueNone
//
//        // all were deleted
//        | ValueSome prev, ValueNone ->
//            prev
//            |> Array.map ScalarChange.Removed
//            |> ValueSome
//        | ValueNone, ValueSome next -> next |> Array.map ScalarChange.Added |> ValueSome
//        | ValueSome prev, ValueSome next ->
//
//            let mutable result = DiffBuilder.create ()
//
//            let mutable prevIndex = 0
//            let mutable nextIndex = 0
//
//            let prevLength = prev.Length
//            let nextLength = next.Length
//
//            while not (prevIndex >= prevLength && nextIndex >= nextLength) do
//                if prevIndex = prevLength then
//                    // that means we are done with the prev and only need to add next's tail to added
//                    //result <- StackArray3.add(&result, (ScalarChange.Added next.[nextIndex]))
//                    DiffBuilder.addOpMut &result DiffBuilder.Add (uint16 nextIndex)
//                    nextIndex <- nextIndex + 1
//
//                elif nextIndex = nextLength then
//                    // that means that we are done with new items and only need prev's tail to removed
//                    // result <- StackArray3.add(&result, ScalarChange.Removed prev.[prevIndex])
//                    DiffBuilder.addOpMut &result DiffBuilder.Remove (uint16 prevIndex)
//                    prevIndex <- prevIndex + 1
//
//                else
//                    // we haven't reached either of the ends
//                    let prevAttr = prev.[prevIndex]
//                    let nextAttr = next.[nextIndex]
//
//                    let prevKey = prevAttr.Key
//                    let nextKey = nextAttr.Key
//
//                    match prevKey.CompareTo nextKey with
//                    | c when c < 0 ->
//                        // prev key is less than next -> remove prev key
//                        DiffBuilder.addOpMut &result DiffBuilder.Remove (uint16 prevIndex)
//                        //                        result <- StackArray3.add(&result, ScalarChange.Removed prevAttr)
//                        prevIndex <- prevIndex + 1
//
//                    | c when c > 0 ->
//                        // prev key is more than next -> add next item
//                        // result <- StackArray3.add(&result, ScalarChange.Added nextAttr)
//                        DiffBuilder.addOpMut &result DiffBuilder.Add (uint16 nextIndex)
//                        nextIndex <- nextIndex + 1
//
//                    | _ ->
//                        // means that we are targeting the same attribute
//
//                        let definition =
//                            AttributeDefinitionStore.get prevAttr.Key :?> IScalarAttributeDefinition
//
//                        match definition.CompareBoxed(prevAttr.Value, nextAttr.Value) with
//                        // Previous and next values are identical, we don't need to do anything
//                        | ScalarAttributeComparison.Identical -> ()
//
//                        // New value completely replaces the old value
//                        | ScalarAttributeComparison.Different ->
//                            DiffBuilder.addOpMut &result DiffBuilder.Change (uint16 nextIndex)
//
//                        // move both pointers
//                        prevIndex <- prevIndex + 1
//                        nextIndex <- nextIndex + 1
//
//
//            match DiffBuilder.lenght &result with
//            | 0 -> ValueNone
//            | _ ->
//                ValueSome(
//                    DiffBuilder.toArray
//                        &result
//                        (fun op ->
//                            match op with
//                            | DiffBuilder.Added i -> ScalarChange.Added next.[int i]
//                            | DiffBuilder.Removed i -> ScalarChange.Removed prev.[int i]
//                            | DiffBuilder.Changed i -> ScalarChange.Updated next.[int i])
//                )

    //    let rec diffWidgetAttributes
//        (canReuseView: Widget -> Widget -> bool)
//        (prev: WidgetAttribute [] voption)
//        (next: WidgetAttribute [] voption)
//        : ArraySlice<WidgetChange> voption =
//
//        match (prev, next) with
//        | ValueNone, ValueNone -> ValueNone
//
//        // all were deleted
//        | ValueSome prev, ValueNone ->
//            prev
//            |> Array.map WidgetChange.Removed
//            |> ArraySlice.fromArray
//
//        | ValueNone, ValueSome next ->
//            next
//            |> Array.map WidgetChange.Added
//            |> ArraySlice.fromArray
//
//        | ValueSome prev, ValueSome next ->
//
//            let mutable result = MutStackArray1.Empty
//
//            let mutable prevIndex = 0
//            let mutable nextIndex = 0
//
//            let prevLength = prev.Length
//            let nextLength = next.Length
//
//            while not(prevIndex >= prevLength && nextIndex >= nextLength) do
//                if prevIndex = prevLength then
//                    // that means we are done with the prev and only need to add next's tail to added
//                    result <- MutStackArray1.addMut(&result, WidgetChange.Added next.[nextIndex])
//                    nextIndex <- nextIndex + 1
//
//                elif nextIndex = nextLength then
//                    // that means that we are done with new items and only need prev's tail to removed
//                    result <- MutStackArray1.addMut(&result, WidgetChange.Removed prev.[prevIndex])
//                    prevIndex <- prevIndex + 1
//
//                else
//                    // we haven't reached either of the ends
//                    let prevAttr = prev.[prevIndex]
//                    let nextAttr = next.[nextIndex]
//
//                    let prevKey = prevAttr.Key
//                    let nextKey = nextAttr.Key
//                    let prevWidget = prevAttr.Value
//                    let nextWidget = nextAttr.Value
//
//                    match prevKey.CompareTo nextKey with
//                    | c when c < 0 ->
//                        // prev key is less than next -> remove prev key
//                        result <- MutStackArray1.addMut(&result, WidgetChange.Removed prevAttr)
//                        prevIndex <- prevIndex + 1
//
//                    | c when c > 0 ->
//                        // prev key is more than next -> add next item
//                        result <- MutStackArray1.addMut(&result, WidgetChange.Added nextAttr)
//                        nextIndex <- nextIndex + 1
//
//                    | _ ->
//                        // means that we are targeting the same attribute
//
//                        // move both pointers
//                        prevIndex <- prevIndex + 1
//                        nextIndex <- nextIndex + 1
//
//                        let changeOpt =
//                            if prevWidget = nextWidget then
//                                ValueNone
//                            elif canReuseView prevWidget nextWidget then
//                                match diffWidget canReuseView (ValueSome prevWidget) nextWidget with
//                                | ValueNone -> ValueNone
//                                | ValueSome diffs -> ValueSome(WidgetChange.Updated struct (nextAttr, diffs))
//                            else
//                                ValueSome(WidgetChange.ReplacedBy nextAttr)
//
//                        match changeOpt with
//                        | ValueNone -> ()
//                        | ValueSome change -> result <- MutStackArray1.addMut(&result, change)
//
//            MutStackArray1.toArraySlice &result
//
//
//    and diffWidgetCollectionAttributes
//        (canReuseView: Widget -> Widget -> bool)
//        (prev: WidgetCollectionAttribute [] voption)
//        (next: WidgetCollectionAttribute [] voption)
//        : ArraySlice<WidgetCollectionChange> voption =
//
//        match (prev, next) with
//        | ValueNone, ValueNone -> ValueNone
//
//        // all were deleted
//        | ValueSome prev, ValueNone ->
//            prev
//            |> Array.map WidgetCollectionChange.Removed
//            |> ArraySlice.fromArray
//
//        | ValueNone, ValueSome next ->
//            next
//            |> Array.map WidgetCollectionChange.Added
//            |> ArraySlice.fromArray
//
//        | ValueSome prev, ValueSome next ->
//
//            let mutable result = MutStackArray1.Empty
//
//
//            let mutable prevIndex = 0
//            let mutable nextIndex = 0
//
//            let prevLength = prev.Length
//            let nextLength = next.Length
//
//            while not(prevIndex >= prevLength && nextIndex >= nextLength) do
//                if prevIndex = prevLength then
//                    // that means we are done with the prev and only need to add next's tail to added
//                    // DiffBuilder.addOpMut &result DiffBuilder.Add (uint16 nextIndex)
//                    result <- MutStackArray1.addMut(&result, WidgetCollectionChange.Added next.[nextIndex])
//
//
//                    nextIndex <- nextIndex + 1
//
//                elif nextIndex = nextLength then
//                    // that means that we are done with new items and only need prev's tail to removed
//                    // DiffBuilder.addOpMut &result DiffBuilder.Remove (uint16 prevIndex)
//                    result <- MutStackArray1.addMut(&result, WidgetCollectionChange.Removed prev.[prevIndex])
//
//
//                    prevIndex <- prevIndex + 1
//
//                else
//                    // we haven't reached either of the ends
//                    let prevAttr = prev.[prevIndex]
//                    let nextAttr = next.[nextIndex]
//
//                    let prevKey = prevAttr.Key
//                    let nextKey = nextAttr.Key
//                    let prevWidgetColl = prevAttr.Value
//                    let nextWidgetColl = nextAttr.Value
//
//                    match prevKey.CompareTo nextKey with
//                    | c when c < 0 ->
//                        // prev key is less than next -> remove prev key
//
//                        result <- MutStackArray1.addMut(&result, WidgetCollectionChange.Removed prevAttr)
//                        prevIndex <- prevIndex + 1
//
//                    | c when c > 0 ->
//                        // prev key is more than next -> add next item
//                        result <- MutStackArray1.addMut(&result, WidgetCollectionChange.Added nextAttr)
//                        nextIndex <- nextIndex + 1
//
//                    | _ ->
//                        // means that we are targeting the same attribute
//
//                        // move both pointers
//                        prevIndex <- prevIndex + 1
//                        nextIndex <- nextIndex + 1
//
//                        let diff =
//                            diffWidgetCollections canReuseView prevWidgetColl nextWidgetColl
//
//                        match diff with
//                        | ValueNone -> ()
//                        | ValueSome slice ->
//                            let change =
//                                WidgetCollectionChange.Updated struct (nextAttr, slice)
//
//                            result <- MutStackArray1.addMut(&result, change)
//
//            MutStackArray1.toArraySlice &result
//
//    and diffWidgetCollections
//        (canReuseView: Widget -> Widget -> bool)
//        (prev: ArraySlice<Widget>)
//        (next: ArraySlice<Widget>)
//        : ArraySlice<WidgetCollectionItemChange> voption =
//        let mutable result = MutStackArray1.Empty
//
//        let prev = ArraySlice.toSpan prev
//        let next = ArraySlice.toSpan next
//
//        if prev.Length > next.Length then
//            for i = next.Length to prev.Length - 1 do
//                result <- MutStackArray1.addMut(&result, WidgetCollectionItemChange.Remove i)
//
//        for i = 0 to next.Length - 1 do
//            let currItem = next.[i]
//            //            index < 0 || index >= array.Length ? (FSharpOption<T>) null : FSharpOption<T>.Some(array[index]);
//            let prevItemOpt =
//                if (i >= prev.Length) then
//                    ValueNone
//                else
//                    ValueSome prev.[i]
//
//            let changeOpt =
//                match prevItemOpt with
//                | ValueNone -> ValueSome(WidgetCollectionItemChange.Insert struct (i, currItem))
//
//                | ValueSome prevItem when canReuseView prevItem currItem ->
//
//                    match diffWidget canReuseView (ValueSome prevItem) currItem with
//                    | ValueNone -> ValueNone
//                    | ValueSome diffs -> ValueSome(WidgetCollectionItemChange.Update struct (i, diffs))
//
//                | ValueSome _ -> ValueSome(WidgetCollectionItemChange.Replace struct (i, currItem))
//
//            match changeOpt with
//            | ValueNone -> ()
//            | ValueSome change -> result <- MutStackArray1.addMut(&result, change)
//
//        MutStackArray1.toArraySlice &result
//
//    and diffWidget
//        (canReuseView: Widget -> Widget -> bool)
//        (prevOpt: Widget voption)
//        (next: Widget)
//        : WidgetDiff voption =
//        let prevScalarAttributes =
//            match prevOpt with
//            | ValueNone -> ValueNone
//            | ValueSome widget -> widget.ScalarAttributes
//
//        let prevWidgetAttributes =
//            match prevOpt with
//            | ValueNone -> ValueNone
//            | ValueSome widget -> widget.WidgetAttributes
//
//        let prevWidgetCollectionAttributes =
//            match prevOpt with
//            | ValueNone -> ValueNone
//            | ValueSome widget -> widget.WidgetCollectionAttributes
//
//        let scalarDiffs =
//            ScalarChanges(prevScalarAttributes, next.ScalarAttributes)
//
//        let widgetDiffs =
//            diffWidgetAttributes canReuseView prevWidgetAttributes next.WidgetAttributes
//
//        let collectionDiffs =
//            diffWidgetCollectionAttributes canReuseView prevWidgetCollectionAttributes next.WidgetCollectionAttributes
//
//
//        ValueSome
//            { ScalarChanges = scalarDiffs
//              WidgetChanges = widgetDiffs
//              WidgetCollectionChanges = collectionDiffs }

    // TODO convert to Enumerator all diffs
//        match (scalarDiffs, widgetDiffs, collectionDiffs) with
//        | ValueNone, ValueNone, ValueNone -> ValueNone
//        | _ ->
//            ValueSome
//                { ScalarChanges = scalarDiffs
//                  WidgetChanges = widgetDiffs
//                  WidgetCollectionChanges = collectionDiffs }

    /// Diffs changes and applies them on the target
    let update
        (canReuseView: Widget -> Widget -> bool)
        (prevOpt: Widget voption)
        (next: Widget)
        (node: IViewNode)
        : unit =

        let diff =
            WidgetDiff.create(prevOpt, next, canReuseView)

        node.ApplyScalarDiffs(&diff.ScalarChanges)
        node.ApplyWidgetDiffs(&diff.WidgetChanges)
        node.ApplyWidgetCollectionDiffs(&diff.WidgetCollectionChanges)
