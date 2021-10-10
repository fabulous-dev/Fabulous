namespace Fabulous.Maui

open Fabulous 
open Microsoft.Maui
open MauiAttributes

type ViewNode(handler) =
    let mutable _attributes: Attribute[] = [||]
    let mutable _context = Unchecked.defaultof<_>
    let mutable _handler : IElementHandler = handler

    member _.Attributes = _attributes
    member _.Context = _context

    member _.Handler
        with get() = _handler
        and set(v) = _handler <- v

    member _.ViewHandler
        with get() = _handler :?> IViewHandler
        and set(v: IViewHandler) = _handler <- v

    member inline private _.UpdateMaui(key: AttributeKey) =
        if _handler <> null then
            match AttributeDefinitionStore.get key with
            | :? IMauiAttributeDefinition as definition -> _handler.UpdateValue(definition.MauiPropertyName)
            | _ -> ()

    interface IViewNode with
        member _.SetContext(context) =
            _context <- context

        member this.ApplyDiff(diff) =
            match diff with
            | WidgetDiff.Identical -> ()
            | WidgetDiff.Updated diffs ->
                for diff in diffs do
                    match diff.Diff with
                    | AttributeDiff.Identical -> ()

                    | AttributeDiff.Added value ->
                        ()
                        this.UpdateMaui(diff.Key)

                    | AttributeDiff.ScalarUpdated value ->
                        ()
                        this.UpdateMaui(diff.Key)

                    | AttributeDiff.ScalarWidgetUpdated widgetDiff ->
                        ()
                        this.UpdateMaui(diff.Key)

                    | AttributeDiff.CollectionUpdated collDiffs ->
                        ()
                        this.UpdateMaui(diff.Key)

                    | AttributeDiff.Removed ->
                        ()
                        this.UpdateMaui(diff.Key)