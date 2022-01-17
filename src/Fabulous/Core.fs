namespace Fabulous

open System
open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous

/// Dev notes:
///
/// The types in this file will be the ones used the most internally by Fabulous.
///
/// To enable the best performance possible, we want to avoid allocating them on
/// the heap as must as possible (meaning they should be structs where possible)
/// Also we want to avoid cache line misses, in that end, we make sure each struct
/// can fit on a L1/L2 cache size by making those structs fit on 64 bits.
///
/// Having those performance constraints prevents us for using inheritance
/// or using interfaces on these structs

type AttributeKey = int
type WidgetKey = int
type StateKey = int
type ViewAdapterKey = int


/// Represents a value for a property of a widget.
/// Can map to a real property (such as Label.Text) or to a non-existent one.
/// It will be up to the AttributeDefinition to decide how to apply the value.
[<Struct>]
type ScalarAttribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: obj }


and [<Struct>] WidgetAttribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: Widget }

and [<Struct>] WidgetCollectionAttribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: ArraySlice<Widget> }

/// Represents a virtual UI element such as a Label, a Button, etc.
and [<Struct>] Widget =
    { Key: WidgetKey
#if DEBUG
      DebugName: string
#endif
      ScalarAttributes: ScalarAttribute [] voption
      WidgetAttributes: WidgetAttribute [] voption
      WidgetCollectionAttributes: WidgetCollectionAttribute [] voption }


[<Struct; RequireQualifiedAccess>]
type ScalarAttributeComparison =
    | Identical
    | Different


[<Struct; IsByRefLike; RequireQualifiedAccess; NoComparison; NoEquality>]
type EnumerationMode<'a> =
    | AllAddedOrRemoved of struct ('a [] * bool)
    | Empty
    | ActualDiff of prevNext: struct ('a [] * 'a [])


module EnumerationMode =
    let fromOptions prev next =
        match prev, next with
        | ValueNone, ValueNone -> EnumerationMode.Empty
        | ValueSome prev, ValueNone -> EnumerationMode.AllAddedOrRemoved(prev, false)
        | ValueNone, ValueSome next -> EnumerationMode.AllAddedOrRemoved(next, true)
        | ValueSome prev, ValueSome next -> EnumerationMode.ActualDiff(prev, next)

module AttributeDefinitionStore =
    let private _attributes = Dictionary<AttributeKey, obj>()

    let mutable private _nextKey = 0

    let get key = _attributes.[key]
    let set key value = _attributes.[key] <- value
    let remove key = _attributes.Remove(key) |> ignore

    let getNextKey () : AttributeKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key


[<Struct; RequireQualifiedAccess>]
type ScalarChange =
    | Added of added: ScalarAttribute
    | Removed of removed: ScalarAttribute
    | Updated of updated: ScalarAttribute

and [<Struct; RequireQualifiedAccess>] WidgetChange =
    | Added of added: WidgetAttribute
    | Removed of removed: WidgetAttribute
    | Updated of updated: struct (WidgetAttribute * WidgetDiff)
    | ReplacedBy of replacedBy: WidgetAttribute

and [<Struct; RequireQualifiedAccess>] WidgetCollectionChange =
    | Added of added: WidgetCollectionAttribute
    | Removed of removed: WidgetCollectionAttribute
    | Updated of updated: struct (WidgetCollectionAttribute * WidgetCollectionItemChanges)

and [<Struct; RequireQualifiedAccess>] WidgetCollectionItemChange =
    | Insert of widgetInserted: struct (int * Widget)
    | Replace of widgetReplaced: struct (int * Widget)
    | Update of widgetUpdated: struct (int * WidgetDiff)
    | Remove of removed: int

and [<Struct; NoComparison; NoEquality>] WidgetDiff =
    { ScalarChanges: ScalarChanges
      WidgetChanges: WidgetChanges
      WidgetCollectionChanges: WidgetCollectionChanges }

    static member inline create
        (
            prevOpt: Widget voption,
            next: Widget,
            canReuseView: Widget -> Widget -> bool
        ) : WidgetDiff =

        let prevScalarAttributes =
            match prevOpt with
            | ValueNone -> ValueNone
            | ValueSome widget -> widget.ScalarAttributes

        let prevWidgetAttributes =
            match prevOpt with
            | ValueNone -> ValueNone
            | ValueSome widget -> widget.WidgetAttributes

        let prevWidgetCollectionAttributes =
            match prevOpt with
            | ValueNone -> ValueNone
            | ValueSome widget -> widget.WidgetCollectionAttributes

        { ScalarChanges = ScalarChanges(prevScalarAttributes, next.ScalarAttributes)
          WidgetChanges = WidgetChanges(prevWidgetAttributes, next.WidgetAttributes, canReuseView)
          WidgetCollectionChanges =
              WidgetCollectionChanges(prevWidgetCollectionAttributes, next.WidgetCollectionAttributes, canReuseView) }

and IAttributeDefinition =
    abstract member Key : AttributeKey
    abstract member UpdateNode : newValueOpt: obj voption * node: IViewNode -> unit

and IScalarAttributeDefinition =
    inherit IAttributeDefinition
    abstract member CompareBoxed : a: obj * b: obj -> ScalarAttributeComparison

/// Context of the whole view tree

and [<Struct>] ViewTreeContext =
    { CanReuseView: Widget -> Widget -> bool
      GetViewNode: obj -> IViewNode
      Dispatch: obj -> unit }

and IViewNode =
    abstract member Target : obj
    abstract member Parent : IViewNode voption
    abstract member TreeContext : ViewTreeContext
    abstract member MapMsg : (obj -> obj) voption with get, set

    // note that Widget is struct type, thus we have boxing via option
    // we don't have MemoizedWidget set for 99.9% of the cases
    // thus makes sense to have overhead of boxing
    // in order to save space
    abstract member MemoizedWidget : Widget option with get, set
    abstract member TryGetHandler<'T> : AttributeKey -> 'T voption
    abstract member SetHandler<'T> : AttributeKey * 'T voption -> unit
    abstract member ApplyScalarDiffs : ScalarChanges inref -> unit
    abstract member ApplyWidgetDiffs : WidgetChanges inref -> unit
    abstract member ApplyWidgetCollectionDiffs : WidgetCollectionChanges inref -> unit



// TODO break and chain here
and [<Struct; NoComparison; NoEquality>] ScalarChanges
    (
        prev: ScalarAttribute [] voption,
        next: ScalarAttribute [] voption
    ) =
    member _.GetEnumerator() =
        ScalarChangesEnumerator(EnumerationMode.fromOptions prev next)

and [<Struct; NoComparison; NoEquality>] WidgetChanges
    (
        prev: WidgetAttribute [] voption,
        next: WidgetAttribute [] voption,
        canReuseView: Widget -> Widget -> bool
    ) =
    member _.GetEnumerator() =
        WidgetChangesEnumerator(EnumerationMode.fromOptions prev next, canReuseView)

and [<Struct; NoComparison; NoEquality>] WidgetCollectionChanges
    (
        prev: WidgetCollectionAttribute [] voption,
        next: WidgetCollectionAttribute [] voption,
        canReuseView: Widget -> Widget -> bool
    ) =
    member _.GetEnumerator() =
        WidgetCollectionChangesEnumerator(EnumerationMode.fromOptions prev next, canReuseView)


and [<Struct; NoComparison; NoEquality>] WidgetCollectionItemChanges
    (
        prev: ArraySlice<Widget>,
        next: ArraySlice<Widget>,
        canReuseView: Widget -> Widget -> bool
    ) =
    member _.GetEnumerator() =
        WidgetCollectionItemChangesEnumerator(ArraySlice.toSpan prev, ArraySlice.toSpan next, canReuseView)

// enumerators
and [<Struct; IsByRefLike>] ScalarChangesEnumerator(mode: EnumerationMode<ScalarAttribute>) =

    [<DefaultValue(false)>]
    val mutable private current: ScalarChange

    [<DefaultValue(false)>]
    val mutable private prevIndex: int

    [<DefaultValue(false)>]
    val mutable private nextIndex: int

    member e.Current = e.current

    member e.MoveNext() =
        match mode with
        | EnumerationMode.Empty -> false
        | EnumerationMode.AllAddedOrRemoved (struct (attributes, added)) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < attributes.Length then
                let attribute = attributes.[i]

                e.current <-
                    match added with
                    | false -> ScalarChange.Removed attribute
                    | true -> ScalarChange.Added attribute

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff (struct (prev, next)) ->
            let mutable prevIndex = e.prevIndex
            let mutable nextIndex = e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            let mutable res: bool voption = ValueNone
            // that needs to be in a loop until we have a change

            while ValueOption.isNone res do

                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- ScalarChange.Added next.[nextIndex]
                        res <- ValueSome true
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- ScalarChange.Removed prev.[prevIndex]
                        res <- ValueSome true
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
                            e.current <- ScalarChange.Removed prev.[prevIndex]
                            res <- ValueSome true
                            prevIndex <- prevIndex + 1

                        | c when c > 0 ->
                            // prev key is more than next -> add next item
                            e.current <- ScalarChange.Added prev.[nextIndex]
                            res <- ValueSome true
                            nextIndex <- nextIndex + 1

                        | _ ->
                            // means that we are targeting the same attribute
                            let definition =
                                AttributeDefinitionStore.get prevAttr.Key :?> IScalarAttributeDefinition

                            match definition.CompareBoxed(prevAttr.Value, nextAttr.Value) with
                            // Previous and next values are identical, we don't need to do anything
                            | ScalarAttributeComparison.Identical -> ()

                            // New value completely replaces the old value
                            | ScalarAttributeComparison.Different ->
                                e.current <- ScalarChange.Updated next.[nextIndex]
                                res <- ValueSome true

                            // move both pointers
                            prevIndex <- prevIndex + 1
                            nextIndex <- nextIndex + 1

                else
                    res <- ValueSome false

            e.prevIndex <- prevIndex
            e.nextIndex <- nextIndex

            match res with
            | ValueNone -> false
            | ValueSome res -> res

and [<Struct; IsByRefLike>] WidgetChangesEnumerator
    (
        mode: EnumerationMode<WidgetAttribute>,
        canReuseView: Widget -> Widget -> bool
    ) =

    [<DefaultValue(false)>]
    val mutable private current: WidgetChange

    [<DefaultValue(false)>]
    val mutable private prevIndex: int

    [<DefaultValue(false)>]
    val mutable private nextIndex: int

    member e.Current = e.current

    member e.MoveNext() =
        match mode with
        | EnumerationMode.Empty -> false
        | EnumerationMode.AllAddedOrRemoved (struct (values, added)) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < values.Length then
                let value = values.[i]

                e.current <-
                    match added with
                    | false -> WidgetChange.Removed value
                    | true -> WidgetChange.Added value

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff (struct (prev, next)) ->
            let mutable prevIndex = e.prevIndex
            let mutable nextIndex = e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            let mutable res: bool voption = ValueNone
            // that needs to be in a loop until we have a change

            while ValueOption.isNone res do
                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- WidgetChange.Added next.[nextIndex]
                        res <- ValueSome true
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- WidgetChange.Removed prev.[prevIndex]
                        res <- ValueSome true
                        prevIndex <- prevIndex + 1

                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev.[prevIndex]
                        let nextAttr = next.[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key
                        let prevWidget = prevAttr.Value
                        let nextWidget = nextAttr.Value

                        match prevKey.CompareTo nextKey with
                        | c when c < 0 ->
                            // prev key is less than next -> remove prev key
                            e.current <- WidgetChange.Removed prevAttr
                            res <- ValueSome true

                            prevIndex <- prevIndex + 1

                        | c when c > 0 ->
                            // prev key is more than next -> add next item
                            e.current <- WidgetChange.Added nextAttr
                            res <- ValueSome true
                            nextIndex <- nextIndex + 1

                        | _ ->
                            // means that we are targeting the same attribute

                            // move both pointers
                            prevIndex <- prevIndex + 1
                            nextIndex <- nextIndex + 1

                            if prevWidget <> nextWidget then

                                let change =
                                    if canReuseView prevWidget nextWidget then
                                        let diff =
                                            WidgetDiff.create((ValueSome prevWidget), nextWidget, canReuseView)

                                        WidgetChange.Updated struct (nextAttr, diff)
                                    else
                                        WidgetChange.ReplacedBy nextAttr

                                e.current <- change
                                res <- ValueSome true

                else
                    res <- ValueSome false

            e.prevIndex <- prevIndex
            e.nextIndex <- nextIndex

            match res with
            | ValueNone -> false
            | ValueSome res -> res

and [<Struct; IsByRefLike>] WidgetCollectionChangesEnumerator
    (
        mode: EnumerationMode<WidgetCollectionAttribute>,
        canReuseView: Widget -> Widget -> bool
    ) =

    [<DefaultValue(false)>]
    val mutable private current: WidgetCollectionChange

    [<DefaultValue(false)>]
    val mutable private prevIndex: int

    [<DefaultValue(false)>]
    val mutable private nextIndex: int

    member e.Current = e.current

    member e.MoveNext() =
        match mode with
        | EnumerationMode.Empty -> false
        | EnumerationMode.AllAddedOrRemoved (struct (values, added)) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < values.Length then
                let value = values.[i]

                e.current <-
                    match added with
                    | false -> WidgetCollectionChange.Removed value
                    | true -> WidgetCollectionChange.Added value

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff (struct (prev, next)) ->
            let mutable prevIndex = e.prevIndex
            let mutable nextIndex = e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            // that needs to be in a loop until we have a change

            let res =
                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- WidgetCollectionChange.Added next.[nextIndex]
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- WidgetCollectionChange.Removed prev.[prevIndex]
                        prevIndex <- prevIndex + 1
                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev.[prevIndex]
                        let nextAttr = next.[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key
                        let prevWidgetColl = prevAttr.Value
                        let nextWidgetColl = nextAttr.Value

                        match prevKey.CompareTo nextKey with
                        | c when c < 0 ->
                            // prev key is less than next -> remove prev key
                            e.current <- WidgetCollectionChange.Removed prevAttr
                            prevIndex <- prevIndex + 1

                        | c when c > 0 ->
                            // prev key is more than next -> add next item
                            e.current <- WidgetCollectionChange.Added nextAttr
                            nextIndex <- nextIndex + 1

                        | _ ->
                            // means that we are targeting the same attribute

                            // move both pointers
                            prevIndex <- prevIndex + 1
                            nextIndex <- nextIndex + 1

                            let diff =
                                WidgetCollectionItemChanges(prevWidgetColl, nextWidgetColl, canReuseView)

                            e.current <- WidgetCollectionChange.Updated struct (nextAttr, diff)

                    true
                else
                    false

            e.prevIndex <- prevIndex
            e.nextIndex <- nextIndex

            res

and [<Struct; IsByRefLike>] WidgetCollectionItemChangesEnumerator
    (
        prev: Span<Widget>,
        next: Span<Widget>,
        canReuseView: Widget -> Widget -> bool
    ) =
    [<DefaultValue(false)>]
    val mutable private current: WidgetCollectionItemChange

    [<DefaultValue(false)>]
    val mutable private index: int

    [<DefaultValue(false)>]
    val mutable private tailIndex: int

    member e.Current = e.current

    member e.MoveNext() =
        let tailIndex = e.tailIndex
        let i = e.index

        if prev.Length > next.Length
           && tailIndex < prev.Length - next.Length then

            e.current <- WidgetCollectionItemChange.Remove(next.Length - tailIndex)
            e.tailIndex <- tailIndex + 1

            true

        elif i < next.Length then
            let currItem = next.[i]

            let prevItemOpt =
                if (i >= prev.Length) then
                    ValueNone
                else
                    ValueSome prev.[i]

            match prevItemOpt with
            | ValueNone -> e.current <- WidgetCollectionItemChange.Insert struct (i, currItem)

            | ValueSome prevItem when canReuseView prevItem currItem ->

                e.current <-
                    WidgetCollectionItemChange.Update
                        struct (i, WidgetDiff.create(ValueSome prevItem, currItem, canReuseView))

            | ValueSome _ -> e.current <- WidgetCollectionItemChange.Replace struct (i, currItem)

            e.index <- i + 1
            true

        else
            // means that we are done iterating
            false
