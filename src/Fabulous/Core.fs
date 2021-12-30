namespace Fabulous

open System.Collections.Generic

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
    {
        Key: AttributeKey
#if DEBUG
        DebugName: string
#endif
        Value: obj
    }

and [<Struct>] WidgetAttribute =
    {
        Key: AttributeKey
#if DEBUG
        DebugName: string
#endif
        Value: Widget
    }

and [<Struct>] WidgetCollectionAttribute =
    {
        Key: AttributeKey
#if DEBUG
        DebugName: string
#endif
        Value: Widget []
    }

/// Represents a virtual UI element such as a Label, a Button, etc.
and [<Struct>] Widget =
    {
        Key: WidgetKey
#if DEBUG
        DebugName: string
#endif
        ScalarAttributes: ScalarAttribute [] option
        WidgetAttributes: WidgetAttribute [] option
        WidgetCollectionAttributes: WidgetCollectionAttribute [] option
    }

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
    | Updated of updated: struct (WidgetCollectionAttribute * WidgetCollectionItemChange [])

and [<Struct; RequireQualifiedAccess>] WidgetCollectionItemChange =
    | Insert of widgetInserted: struct (int * Widget)
    | Replace of widgetReplaced: struct (int * Widget)
    | Update of widgetUpdated: struct (int * WidgetDiff)
    | Remove of removed: int

and [<Struct>] WidgetDiff =
    {
        ScalarChanges: ScalarChange [] option
        WidgetChanges: WidgetChange [] option
        WidgetCollectionChanges: WidgetCollectionChange [] option
    }

/// Context of the whole view tree
[<Struct>]
type ViewTreeContext =
    {
        CanReuseView: Widget -> Widget -> bool
        GetViewNode: obj -> IViewNode
        Dispatch: obj -> unit
    }

and IViewNode =
    abstract member Target : obj
    abstract member Parent : IViewNode voption
    abstract member TreeContext : ViewTreeContext
    abstract member MapMsg : (obj -> obj) voption with get, set

    // whatever we need to attach to ViewNode in Core
    // TODO if it is for internal use only it is possible that we should strongly type
    // values we can expect in here
    abstract member PropertyBag : Dictionary<int, obj>
    abstract member GetViewNodeForChild : obj -> IViewNode
    abstract member TryGetHandler<'T> : AttributeKey -> 'T voption
    abstract member SetHandler<'T> : AttributeKey * 'T voption -> unit
    abstract member ApplyScalarDiffs : ScalarChange [] -> unit
    abstract member ApplyWidgetDiffs : WidgetChange [] -> unit
    abstract member ApplyWidgetCollectionDiffs : WidgetCollectionChange [] -> unit
