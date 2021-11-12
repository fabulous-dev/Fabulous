namespace Fabulous

open System

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
type Attribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: obj }

/// Represents a virtual UI element such as a Label, a Button, etc.
[<Struct>]
type Widget =
    { Key: WidgetKey
      Attributes: Attribute [] }

[<Struct; RequireQualifiedAccess>]
type AttributeChange =
    | Added of added: Attribute
    | Removed of removed: Attribute
    | ScalarUpdated of scalarData: Attribute
    | WidgetUpdated of widgetData: struct (Attribute * AttributeChange[])
    | CollectionUpdated of collectionData: struct (Attribute * CollectionChange[])

and [<Struct; RequireQualifiedAccess>] CollectionChange =
    | Insert of inserted: struct(int * obj)
    | Replace of replaced: struct(int * obj)
    | Update of updated: struct(int * obj)
    | Remove of removed: int
    | InsertWidget of widgetInserted: struct (int * Widget)
    | ReplaceWidget of widgetReplaced: struct (int * Widget)
    | UpdateWidget of widgetUpdated: struct (int * AttributeChange[])

/// Represents a UI element created from a widget
type IViewNode =
    abstract ApplyDiff : AttributeChange[] -> unit
    abstract Attributes : Attribute[]
    abstract Origin: WidgetKey

and [<Struct>] ViewTreeContext =
    { Dispatch: obj -> unit
      Ancestors: IViewNode list }

and [<Struct>] ChildUpdate =
    { ChildAfterUpdate: obj }

and [<Struct>] ChildrenUpdate =
    { ChildrenAfterUpdate: obj []
      Added: obj list voption
      Removed: obj list voption }

type Program<'arg, 'model, 'msg> =
    { Init : 'arg -> 'model * Cmd<'msg>
      Update : 'msg * 'model -> 'model * Cmd<'msg>
      View : 'model -> Widget }

[<Struct; RequireQualifiedAccess>]
type AttributeComparison =
    | Identical
    | ReplacedBy of newData: obj
    | WidgetDifferent of attributeChanges: AttributeChange[]
    | CollectionDifferent of collectionChanges: CollectionChange[]

type IAttributeDefinition =
    abstract Key: AttributeKey
    abstract CompareBoxed : obj * obj -> AttributeComparison

type IAttributeDefinition<'inputType, 'modelType> =
    inherit IAttributeDefinition
    abstract DefaultWith : unit -> 'modelType

type IWidgetDefinition =
    abstract CreateView : Widget * ViewTreeContext -> obj

type IRunner =
    interface
    end

type IViewAdapter =
    inherit IDisposable
    abstract CreateView : unit -> obj
    abstract Attach : obj -> unit
    abstract Detach : bool -> unit
