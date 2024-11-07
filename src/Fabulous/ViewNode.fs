namespace Fabulous

open System
open System.Collections.Generic
open Fabulous

/// Define the logic to apply diffs and store event handlers of its target control
[<Sealed>]
type ViewNode =
    val mutable parent: IViewNode option
    val mutable envContext: EnvironmentContext
    val mutable treeContext: ViewTreeContext
    val mutable targetRef: WeakReference
    val mutable isDisposed: bool
    val mutable memoizedWidget: Widget option
    val mutable mapMsg: (obj -> obj) option

    // TODO consider combine handlers mapMsg and property bag
    // also we can probably use just Dictionary instead of Map because
    // ViewNode is supposed to be mutable, stateful and persistent object
    val handlers: Dictionary<string, IDisposable>

    new(parent: IViewNode option, envContext: EnvironmentContext, treeContext: ViewTreeContext, target: WeakReference) =
        { parent = parent
          envContext = envContext
          treeContext = treeContext
          targetRef = target
          handlers = Dictionary<string, IDisposable>()
          isDisposed = false
          memoizedWidget = None
          mapMsg = None }

    member inline private this.ApplyScalarDiffs(diffs: ScalarChanges inref) : unit =
        let node = this :> IViewNode

        for diff in diffs do
            match diff with
            | ScalarChange.Added added ->
                let key = added.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar = (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode ValueNone (ValueSome added.NumericValue) node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode ValueNone (ValueSome added.Value) node

            | ScalarChange.Removed removed ->

                let key = removed.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar = (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode (ValueSome removed.NumericValue) ValueNone node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode (ValueSome removed.Value) ValueNone node

            | ScalarChange.Updated(oldAttr, newAttr) ->
                let key = oldAttr.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar = (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode (ValueSome oldAttr.NumericValue) (ValueSome newAttr.NumericValue) node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode (ValueSome oldAttr.Value) (ValueSome newAttr.Value) node

    member inline private this.ApplyWidgetDiffs(diffs: WidgetChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetChange.Added newWidget
            | WidgetChange.ReplacedBy newWidget ->
                let definition = (AttributeDefinitionStore.getWidget newWidget.Key)

                definition.UpdateNode ValueNone (ValueSome newWidget.Value) (this :> IViewNode)

            | WidgetChange.Removed removed ->
                let definition = (AttributeDefinitionStore.getWidget removed.Key)

                definition.UpdateNode (ValueSome removed.Value) ValueNone (this :> IViewNode)

            | WidgetChange.Updated struct (newAttr, diffs) ->
                let definition = (AttributeDefinitionStore.getWidget newAttr.Key)

                definition.ApplyDiff diffs (this :> IViewNode)

    member inline private this.ApplyWidgetCollectionDiffs(diffs: WidgetCollectionChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetCollectionChange.Added added ->
                let definition = (AttributeDefinitionStore.getWidgetCollection added.Key)

                definition.UpdateNode ValueNone (ValueSome added.Value) (this :> IViewNode)

            | WidgetCollectionChange.Removed removed ->
                let definition = (AttributeDefinitionStore.getWidgetCollection removed.Key)

                definition.UpdateNode (ValueSome removed.Value) ValueNone (this :> IViewNode)

            | WidgetCollectionChange.Updated struct (oldAttr, newAttr, diffs) ->
                let definition = (AttributeDefinitionStore.getWidgetCollection newAttr.Key)

                definition.ApplyDiff oldAttr.Value diffs (this :> IViewNode)

    interface IViewNode with
        member this.Target = this.targetRef.Target
        member this.TreeContext = this.treeContext
        member this.EnvironmentContext = this.envContext

        member this.MemoizedWidget
            with get () = this.memoizedWidget
            and set value = this.memoizedWidget <- value

        member this.Parent = this.parent

        member this.MapMsg
            with get () = this.mapMsg
            and set value = this.mapMsg <- value

        member this.IsDisconnected = this.isDisposed

        member this.TryGetHandler(key: string) =
            match this.handlers.TryGetValue(key) with
            | false, _ -> ValueNone
            | true, handler -> ValueSome(handler)

        member this.SetHandler(key: string, handler: IDisposable) = this.handlers[key] <- handler

        member this.RemoveHandler(key: string) =
            if this.handlers.ContainsKey(key) then
                let handler = this.handlers[key]
                this.handlers.Remove(key) |> ignore
                handler.Dispose()

        member this.Dispose() =
            this.isDisposed <- true

            // Dispose all the event handlers of this node
            for kvp in this.handlers do
                kvp.Value.Dispose()

            this.handlers.Clear()

            // Dispose the attached Component if any
            if this.targetRef.IsAlive then
                let comp = this.treeContext.GetComponent(this.targetRef.Target) :?> IDisposable

                if not(isNull comp) then
                    comp.Dispose()
                    this.treeContext.SetComponent null this.targetRef.Target

            this.parent <- None
            this.treeContext <- Unchecked.defaultof<_>
            this.targetRef <- null

        member this.ApplyDiff(diff) =
            if not this.targetRef.IsAlive then
                ()
            else
                this.ApplyScalarDiffs(&diff.ScalarChanges)
                this.ApplyWidgetDiffs(&diff.WidgetChanges)
                this.ApplyWidgetCollectionDiffs(&diff.WidgetCollectionChanges)
