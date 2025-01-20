namespace Fabulous

open System
open System.Runtime.CompilerServices
open Fabulous

[<Struct; RequireQualifiedAccess>]
type ScalarAttributeComparison =
    | Identical
    | Different

[<Struct; IsByRefLike; RequireQualifiedAccess; NoComparison; NoEquality>]
type EnumerationMode<'a> =
    | AllAddedOrRemoved of prev: 'a[] * bool // the first element is either prev or next depending on the bool, but using prev as the label allows the compiler to reuse struct fields between cases
    | Empty
    | ActualDiff of prev: 'a[] * next: 'a[]

module EnumerationMode =
    let fromOptions prev next =
        match prev, next with
        | [||], [||] -> EnumerationMode.Empty
        | prev, [||] -> EnumerationMode.AllAddedOrRemoved(prev, false)
        | [||], next -> EnumerationMode.AllAddedOrRemoved(next, true)
        | prev, next -> EnumerationMode.ActualDiff(prev, next)

module private SkipRepeatingScalars =
    /// Context:
    /// In WidgetBuilders we can easily have duplicate attributes
    /// like Label("aha!").color("red").color("blue")
    /// Diffing algorithm already uses stable sort for diffing attributes
    /// Thus we need to leverage that fact
    ///
    /// In particular we might have a bug in this context
    /// prev:  Label("aha!").color("red").color("blue")
    /// next:  Label("aha!").color("red")
    ///
    /// After the diffing the resulting color should be "red", but previously
    /// it was interpreted as "removed color property" instead
    ///
    /// This functions skips "color("red")" from "color("red").color("blue")"
    /// Effectively taking only the latest attribute for a particular property
    ///
    /// TODO: is there a more optimal way to write it? This is a part of the hot path
    /// I couldn't detect perf differences with and without this function
    /// but still might be interesting to tinker about it more
    let inline skip (scalars: ScalarAttribute array) (pos: int) =
        let length = scalars.Length
        // either the last element or out of bounds
        if pos >= length - 1 then
            pos
        else
            // that means that there is at least one more element ahead
            let key = scalars[pos].Key
            let mutable resultingIndex = pos

            while (length - 1 > resultingIndex) && (scalars[resultingIndex + 1].Key = key) do
                resultingIndex <- resultingIndex + 1

            resultingIndex

    let inline skipEnv (scalars: EnvironmentAttribute array) (pos: int) =
        let length = scalars.Length
        // either the last element or out of bounds
        if pos >= length - 1 then
            pos
        else
            // that means that there is at least one more element ahead
            let key = scalars[pos].Key
            let mutable resultingIndex = pos

            while (length - 1 > resultingIndex) && (scalars[resultingIndex + 1].Key = key) do
                resultingIndex <- resultingIndex + 1

            resultingIndex

[<Struct; IsByRefLike; RequireQualifiedAccess>]
type ScalarChange =
    | Added of attr: ScalarAttribute
    | Removed of attr: ScalarAttribute
    | Updated of attr: ScalarAttribute * updated: ScalarAttribute // old * updated

and [<Struct; RequireQualifiedAccess>] WidgetChange =
    | Added of widget: WidgetAttribute
    | Removed of widget: WidgetAttribute
    | Updated of widget: WidgetAttribute * diff: WidgetDiff // updated * diff
    | ReplacedBy of widget: WidgetAttribute

and [<Struct; RequireQualifiedAccess>] WidgetCollectionChange =
    | Added of attr: WidgetCollectionAttribute
    | Removed of attr: WidgetCollectionAttribute
    | Updated of attr: WidgetCollectionAttribute * updated: WidgetCollectionAttribute * diff: WidgetCollectionItemChanges // old * updated * diff

and [<Struct; IsByRefLike; RequireQualifiedAccess>] WidgetCollectionItemChange =
    | Insert of index: int * widget: Widget
    | Replace of index: int * widget: Widget * replacedBy: Widget // index * old * replacedBy
    | Update of index: int * diff: WidgetDiff
    | Remove of index: int * widget: Widget

and [<Struct; IsByRefLike; RequireQualifiedAccess>] EnvironmentChange =
    | Added of attr: EnvironmentAttribute
    | Removed of attr: EnvironmentAttribute
    | Updated of attr: EnvironmentAttribute * updated: EnvironmentAttribute // old * updated

and [<Struct; NoComparison; NoEquality>] WidgetDiff =
    { ScalarChanges: ScalarChanges
      WidgetChanges: WidgetChanges
      WidgetCollectionChanges: WidgetCollectionChanges
      EnvironmentChanges: EnvironmentChanges }

    static member inline create
        (
            prevOpt: Widget voption,
            next: Widget,
            canReuseView: Widget -> Widget -> bool,
            compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
        ) : WidgetDiff =

        let prevScalarAttributes =
            match prevOpt with
            | ValueNone -> [||]
            | ValueSome widget -> widget.ScalarAttributes

        let prevWidgetAttributes =
            match prevOpt with
            | ValueNone -> [||]
            | ValueSome widget -> widget.WidgetAttributes

        let prevWidgetCollectionAttributes =
            match prevOpt with
            | ValueNone -> [||]
            | ValueSome widget -> widget.WidgetCollectionAttributes

        let prevEnvironmentAttributes =
            match prevOpt with
            | ValueNone -> [||]
            | ValueSome widget -> widget.EnvironmentAttributes

        { ScalarChanges = ScalarChanges(prevScalarAttributes, next.ScalarAttributes, compareScalars)
          WidgetChanges = WidgetChanges(prevWidgetAttributes, next.WidgetAttributes, canReuseView, compareScalars)
          WidgetCollectionChanges = WidgetCollectionChanges(prevWidgetCollectionAttributes, next.WidgetCollectionAttributes, canReuseView, compareScalars)
          EnvironmentChanges = EnvironmentChanges(prevEnvironmentAttributes, next.EnvironmentAttributes) }

and [<Struct; NoComparison; NoEquality>] ScalarChanges
    (prev: ScalarAttribute[], next: ScalarAttribute[], compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison) =
    member _.GetEnumerator() =
        ScalarChangesEnumerator(EnumerationMode.fromOptions prev next, compareScalars)

and [<Struct; NoComparison; NoEquality>] WidgetChanges
    (
        prev: WidgetAttribute[],
        next: WidgetAttribute[],
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
    ) =
    member _.GetEnumerator() =
        WidgetChangesEnumerator(EnumerationMode.fromOptions prev next, canReuseView, compareScalars)

and [<Struct; NoComparison; NoEquality>] WidgetCollectionChanges
    (
        prev: WidgetCollectionAttribute[],
        next: WidgetCollectionAttribute[],
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
    ) =
    member _.GetEnumerator() =
        WidgetCollectionChangesEnumerator(EnumerationMode.fromOptions prev next, canReuseView, compareScalars)


and [<Struct; NoComparison; NoEquality>] WidgetCollectionItemChanges
    (
        prev: ArraySlice<Widget>,
        next: ArraySlice<Widget>,
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
    ) =
    member _.GetEnumerator() =
        WidgetCollectionItemChangesEnumerator(ArraySlice.toSpan prev, ArraySlice.toSpan next, canReuseView, compareScalars)

and [<Struct; NoComparison; NoEquality>] EnvironmentChanges(prev: EnvironmentAttribute[], next: EnvironmentAttribute[]) =
    member _.GetEnumerator() =
        EnvironmentChangesEnumerator(EnumerationMode.fromOptions prev next)

// enumerators
and [<Struct; IsByRefLike>] ScalarChangesEnumerator
    (mode: EnumerationMode<ScalarAttribute>, compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison) =

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
        | EnumerationMode.AllAddedOrRemoved(attributes, added) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < attributes.Length then
                let attribute = attributes[i]

                e.current <-
                    match added with
                    | false -> ScalarChange.Removed attribute
                    | true -> ScalarChange.Added attribute

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff(prev, next) ->
            let mutable prevIndex = SkipRepeatingScalars.skip prev e.prevIndex

            let mutable nextIndex = SkipRepeatingScalars.skip next e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            let mutable res: bool voption = ValueNone
            // that needs to be in a loop until we have a change

            while ValueOption.isNone res do
                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- ScalarChange.Added next[nextIndex]
                        res <- ValueSome true
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- ScalarChange.Removed prev[prevIndex]
                        res <- ValueSome true
                        prevIndex <- prevIndex + 1

                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev[prevIndex]
                        let nextAttr = next[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key

                        match ScalarAttributeKey.compare prevKey nextKey with
                        | c when c < 0 ->
                            // prev key is less than next -> remove prev key
                            e.current <- ScalarChange.Removed prev[prevIndex]
                            res <- ValueSome true
                            prevIndex <- prevIndex + 1

                        | c when c > 0 ->
                            // prev key is more than next -> add next item
                            e.current <- ScalarChange.Added next[nextIndex]
                            res <- ValueSome true
                            nextIndex <- nextIndex + 1

                        | _ ->
                            // means that we are targeting the same attribute
                            match ScalarAttributeKey.getKind prevKey with
                            | ScalarAttributeKey.Kind.Inline ->
                                if prevAttr.NumericValue <> nextAttr.NumericValue then
                                    e.current <- ScalarChange.Updated(prev[prevIndex], next[nextIndex])
                                    res <- ValueSome true

                            | ScalarAttributeKey.Kind.Boxed ->
                                match compareScalars prevKey prevAttr.Value nextAttr.Value with
                                // Previous and next values are identical, we don't need to do anything
                                | ScalarAttributeComparison.Identical -> ()

                                // New value completely replaces the old value
                                | ScalarAttributeComparison.Different ->
                                    e.current <- ScalarChange.Updated(prev[prevIndex], next[nextIndex])
                                    res <- ValueSome true

                            // move both pointers
                            prevIndex <- SkipRepeatingScalars.skip prev (prevIndex + 1)
                            nextIndex <- SkipRepeatingScalars.skip next (nextIndex + 1)

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
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
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
        | EnumerationMode.AllAddedOrRemoved(values, added) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < values.Length then
                let value = values[i]

                e.current <-
                    match added with
                    | false -> WidgetChange.Removed value
                    | true -> WidgetChange.Added value

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff(prev, next) ->
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
                        e.current <- WidgetChange.Added next[nextIndex]
                        res <- ValueSome true
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- WidgetChange.Removed prev[prevIndex]
                        res <- ValueSome true
                        prevIndex <- prevIndex + 1

                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev[prevIndex]
                        let nextAttr = next[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key
                        let prevWidget = prevAttr.Value
                        let nextWidget = nextAttr.Value

                        match WidgetAttributeKey.compare prevKey nextKey with
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
                                            WidgetDiff.create((ValueSome prevWidget), nextWidget, canReuseView, compareScalars)

                                        WidgetChange.Updated(nextAttr, diff)
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
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
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
        | EnumerationMode.AllAddedOrRemoved(values, added) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < values.Length then
                let value = values[i]

                e.current <-
                    match added with
                    | false -> WidgetCollectionChange.Removed value
                    | true -> WidgetCollectionChange.Added value

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff(prev, next) ->
            let mutable prevIndex = e.prevIndex
            let mutable nextIndex = e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            // that needs to be in a loop until we have a change

            let res =
                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- WidgetCollectionChange.Added next[nextIndex]
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- WidgetCollectionChange.Removed prev[prevIndex]
                        prevIndex <- prevIndex + 1
                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev[prevIndex]
                        let nextAttr = next[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key
                        let prevWidgetColl = prevAttr.Value
                        let nextWidgetColl = nextAttr.Value

                        match WidgetCollectionAttributeKey.compare prevKey nextKey with
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
                                WidgetCollectionItemChanges(prevWidgetColl, nextWidgetColl, canReuseView, compareScalars)

                            e.current <- WidgetCollectionChange.Updated(prevAttr, nextAttr, diff)

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
        canReuseView: Widget -> Widget -> bool,
        compareScalars: ScalarAttributeKey -> obj -> obj -> ScalarAttributeComparison
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

        if prev.Length > next.Length && tailIndex < prev.Length - next.Length then

            let index = prev.Length - tailIndex - 1
            e.current <- WidgetCollectionItemChange.Remove(index, prev[index])
            e.tailIndex <- tailIndex + 1

            true

        elif i < next.Length then
            let currItem = next[i]

            let prevItemOpt = if (i >= prev.Length) then ValueNone else ValueSome prev[i]

            match prevItemOpt with
            | ValueNone -> e.current <- WidgetCollectionItemChange.Insert(i, currItem)

            | ValueSome prevItem when canReuseView prevItem currItem ->

                let diff =
                    WidgetDiff.create(ValueSome prevItem, currItem, canReuseView, compareScalars)

                e.current <- WidgetCollectionItemChange.Update(i, diff)

            | ValueSome prevItem -> e.current <- WidgetCollectionItemChange.Replace(i, prevItem, currItem)

            e.index <- i + 1
            true

        else
            // means that we are done iterating
            false

and [<Struct; IsByRefLike>] EnvironmentChangesEnumerator(mode: EnumerationMode<EnvironmentAttribute>) =

    [<DefaultValue(false)>]
    val mutable private current: EnvironmentChange

    [<DefaultValue(false)>]
    val mutable private prevIndex: int

    [<DefaultValue(false)>]
    val mutable private nextIndex: int

    member e.Current = e.current

    member e.MoveNext() =
        match mode with
        | EnumerationMode.Empty -> false
        | EnumerationMode.AllAddedOrRemoved(attributes, added) ->
            // use prevIndex regardless if it is for adding or removal
            let i = e.prevIndex

            if i < attributes.Length then
                let attribute = attributes[i]

                e.current <-
                    match added with
                    | false -> EnvironmentChange.Removed attribute
                    | true -> EnvironmentChange.Added attribute

                e.prevIndex <- i + 1
                true
            else
                false

        | EnumerationMode.ActualDiff(prev, next) ->
            let mutable prevIndex = SkipRepeatingScalars.skipEnv prev e.prevIndex

            let mutable nextIndex = SkipRepeatingScalars.skipEnv next e.nextIndex

            let prevLength = prev.Length
            let nextLength = next.Length

            let mutable res: bool voption = ValueNone
            // that needs to be in a loop until we have a change

            while ValueOption.isNone res do
                if not(prevIndex >= prevLength && nextIndex >= nextLength) then
                    if prevIndex = prevLength then
                        // that means we are done with the prev and only need to add next's tail to added
                        e.current <- EnvironmentChange.Added next[nextIndex]
                        res <- ValueSome true
                        nextIndex <- nextIndex + 1

                    elif nextIndex = nextLength then
                        // that means that we are done with new items and only need prev's tail to removed
                        e.current <- EnvironmentChange.Removed prev[prevIndex]
                        res <- ValueSome true
                        prevIndex <- prevIndex + 1

                    else
                        // we haven't reached either of the ends
                        let prevAttr = prev[prevIndex]
                        let nextAttr = next[nextIndex]

                        let prevKey = prevAttr.Key
                        let nextKey = nextAttr.Key

                        match EnvironmentAttributeKey.compare prevKey nextKey with
                        | c when c < 0 ->
                            // prev key is less than next -> remove prev key
                            e.current <- EnvironmentChange.Removed prev[prevIndex]
                            res <- ValueSome true
                            prevIndex <- prevIndex + 1

                        | c when c > 0 ->
                            // prev key is more than next -> add next item
                            e.current <- EnvironmentChange.Added next[nextIndex]
                            res <- ValueSome true
                            nextIndex <- nextIndex + 1

                        | _ ->
                            // means that we are targeting the same attribute
                            if prevAttr.Value = nextAttr.Value then
                                // Previous and next values are identical, we don't need to do anything
                                ()
                            else
                                // New value completely replaces the old value
                                e.current <- EnvironmentChange.Updated(prev[prevIndex], next[nextIndex])
                                res <- ValueSome true

                            // move both pointers
                            prevIndex <- SkipRepeatingScalars.skipEnv prev (prevIndex + 1)
                            nextIndex <- SkipRepeatingScalars.skipEnv next (nextIndex + 1)

                else
                    res <- ValueSome false

            e.prevIndex <- prevIndex
            e.nextIndex <- nextIndex

            match res with
            | ValueNone -> false
            | ValueSome res -> res
