namespace Fabulous

open Fabulous

// module Reconciler =
//    let diff (previousOpt: Widget voption) (current: Widget) =
//        WidgetDiff.Identical


//-----Update sketch------
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
    let compareAttributes (prev: Attribute []) (next: Attribute []) : AttributeChange list =
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
                let prevItem = prev.[prevIndex]
                let nextItem = next.[nextIndex]

                let prevKey = prevItem.Key
                let nextKey = nextItem.Key

                match prevKey.CompareTo nextKey with
                | c when c < 0 ->
                    // prev key is less than next -> remove prev key
                    result <- AttributeChange.Removed prevItem :: result
                    prevIndex <- prevIndex + 1

                | c when c > 0 ->
                    // prev key is more than next -> add next item
                    result <- AttributeChange.Added nextItem :: result
                    nextIndex <- nextIndex + 1

                | _ ->
                    // means that we are targeting the same attribute

                    // move both pointers
                    prevIndex <- prevIndex + 1
                    nextIndex <- nextIndex + 1

                    let attribute =
                        AttributeDefinitionStore.get prevItem.Key

                    match attribute.CompareBoxed(prevItem.Value, nextItem.Value) with
                    | AttributeComparison.Identical -> ()
                    | AttributeComparison.Different diff ->
                        result <-
                            AttributeChange.Updated(prevItem, nextItem, diff)
                            :: result

        result

    // https://medium.com/@deathmood/how-to-write-your-own-virtual-dom-ee74acc13060
//    function updateElement($parent, newNode, oldNode, index = 0) {
//  if (!oldNode) {
//    $parent.appendChild(
//      createElement(newNode)
//    );
//  } else if (!newNode) {
//    $parent.removeChild(
//      $parent.childNodes[index]
//    );
//  } else if (changed(newNode, oldNode)) {
//    $parent.replaceChild(
//      createElement(newNode),
//      $parent.childNodes[index]
//    );
//  } else if (newNode.type) {
//    const newLength = newNode.children.length;
//    const oldLength = oldNode.children.length;
//    for (let i = 0; i < newLength || i < oldLength; i++) {
//      updateElement(
//        $parent.childNodes[index],
//        newNode.children[i],
//        oldNode.children[i],
//        i
//      );
//    }
//  }
//}

    let inline private createViewFromWidget (widget: Widget) (ctx: ViewTreeContext): IViewNode =
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        let viewNode = widgetDefinition.CreateView (widget, ctx)
        viewNode

    let inline private addItem item maybeList =
        match maybeList with
        | ValueSome l -> ValueSome(item :: l)
        | ValueNone -> ValueSome [ item ]

    let rec update (node: IViewNode) (attributes: Attribute []) : unit =

        let prevAttributes = node.Attributes

        let diff =
            compareAttributes prevAttributes attributes

        if List.isEmpty diff then
            ()
        else
            match node.ApplyDiff
                      {
                          // TODO return Array from comparison
                          Changes = diff |> List.toArray
                          NewAttributes = attributes
                      } with
            | UpdateResult.Done -> ()
            | UpdateResult.UpdateChildren struct (container, widgets, ctx) ->
                let children = container.Children

                // if the size is the same we can just reuse the same array to avoid allocations
                // it is safe to do so because diffing goes only forward, thus safe to do it in place
                let target: IViewNode [] =
                    if widgets.Length = children.Length then
                        children
                    else
                        Array.zeroCreate(widgets.Length)

                let mutable added: IViewNode list voption = ValueNone

                let mutable removed: IViewNode list voption =
                    // if we are downsizing then the tail needs to be added to removed
                    if children.Length > widgets.Length then
                        children
                        |> Array.skip widgets.Length
                        |> Array.toList
                        |> ValueSome
                    else
                        ValueNone

                for i = 0 to widgets.Length - 1 do
                    let widget = widgets.[i]
                    let prev = Array.tryItem i children

                    match (prev, widget) with
                    | None, widget ->
                        // view doesn't exist yet
                        let viewNode = createViewFromWidget widget ctx
                        target.[i] <- viewNode
                        added <- addItem viewNode added

                    | Some p, widget when widget.Key = p.Origin ->
                        // same type, just update
                        target.[i] <- p
                        update p widget.Attributes

                    | Some p, widget ->
                        // different type, thus replacement is needed
                        let viewNode = createViewFromWidget widget ctx
                        target.[i] <- viewNode
                        added <- addItem viewNode added
                        removed <- addItem p removed

                container.UpdateChildren
                    {
                        ChildrenAfterUpdate = target
                        Added = added
                        Removed = removed
                    }

                ()



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
module Runtime =
    let MapMsg =
        Attributes.defineWithComparer<obj -> obj>
            "MapMsg"
            (fun () -> id )
            // TODO should this be a type check? E.g. what "dependsOn" uses internally?
            Attributes.AttributeComparers.alwaysDifferent

    let MapMsgKey = MapMsg.Key

    let inline dispatchOnNode (node: IViewNode) (ctx: ViewTreeContext) (ev: obj): unit =
        let inline mapEv (e: obj) (attributes: Attribute[]) =
            match (Array.tryFind (fun (a: Attribute) -> a.Key = MapMsgKey) attributes) with
            | Some attr -> unbox<obj -> obj>attr.Value e
            | None -> e
        
        let mutable ev = mapEv ev node.Attributes
        for ancestor in ctx.Ancestors do
            ev <- mapEv ev ancestor.Attributes
        
        ctx.Dispatch ev
            
