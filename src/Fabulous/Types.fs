namespace Fabulous

open System
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
        ScalarAttributes: ScalarAttribute []
        WidgetAttributes: WidgetAttribute []
        WidgetCollectionAttributes: WidgetCollectionAttribute []
    }

    member x.GetScalarOrDefault<'T>(key: AttributeKey, defaultValue: 'T) =
        match x.ScalarAttributes
              |> Array.tryFind(fun attr -> attr.Key = key) with
        | None -> defaultValue
        | Some attr -> unbox<'T> attr.Value

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
        ScalarChanges: ScalarChange []
        WidgetChanges: WidgetChange []
        WidgetCollectionChanges: WidgetCollectionChange []
    }

[<Struct; RequireQualifiedAccess>]
type ScalarAttributeComparison =
    | Identical
    | Different of newData: obj

/// DEV NOTES: This interface can be removed by reorganizing the types of this file
type IViewNode =
    abstract Context : ViewNodeContext
    abstract MapMsg : obj -> obj
    abstract SetMapMsg : (obj -> obj) -> unit
    abstract TryGetHandler<'T> : AttributeKey -> 'T voption
    abstract SetHandler : AttributeKey * 'T voption -> unit
    abstract ApplyScalarDiff : ScalarChange [] -> unit
    abstract ApplyWidgetDiff : WidgetChange [] -> unit
    abstract ApplyWidgetCollectionDiff : WidgetCollectionChange [] -> unit
    
/// Context of the whole view tree
and [<Struct>] ViewTreeContext =
    { CanReuseView: Widget -> Widget -> bool
      GetViewNode: obj -> IViewNode
      Dispatch: obj -> unit }

/// Context for a specific view node
and [<Struct>] ViewNodeContext =
    { Key: WidgetKey
      ViewTreeContext: ViewTreeContext
      Ancestors: IViewNode list }
    
type Program<'arg, 'model, 'msg> =
    {
        Init: 'arg -> 'model * Cmd<'msg>
        Update: 'msg * 'model -> 'model * Cmd<'msg>
        View: 'model -> Widget
        CanReuseView: Widget -> Widget -> bool
        GetViewNode: obj -> IViewNode
    }
    
type IRunner =
    interface
    end

type IViewAdapter =
    inherit IDisposable
    abstract CreateView : unit -> obj
    abstract Attach : obj -> unit
    abstract Detach : bool -> unit
