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

/// Represents a property of a widget.
/// Can map to a real property (such as Label.Text) or to a fake one.
/// It will be up to the AttributeDefinition to decide how to apply
/// the value.
///
/// Payload can contains additional data provided by the implementing framework
/// For example, Maui needs to know
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
      Attributes: Attribute[] }

[<Struct; RequireQualifiedAccess>]
type CollectionDiff =
    | Identical

[<Struct; RequireQualifiedAccess>] 
type AttributeDiff =
    | Identical
    | Added of addedValue: obj
    | ScalarUpdated of updatedValue: obj
    | ScalarWidgetUpdated of updatedWidget: WidgetDiff
    | CollectionUpdated of collectionDiffs: CollectionDiff[]
    | Removed

and [<Struct; RequireQualifiedAccess>] AttributeDiffWithKey =
    { Key: AttributeKey
      Diff: AttributeDiff }

and [<Struct; RequireQualifiedAccess>] WidgetDiff =
    | Identical
    | Updated of updatedAttributes: AttributeDiffWithKey[]

type ViewTreeContext =
    { Dispatch: obj -> unit }

/// Represents a UI element created from a widget
type IViewNode =
    abstract SetContext: ViewTreeContext -> unit
    abstract ApplyDiff: WidgetDiff -> unit

type IComponent = interface end

type IStatefulComponent<'arg, 'model, 'msg> =
    inherit IComponent
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model -> Widget

type IStatelessComponent =
    inherit IComponent
    abstract View: unit -> Widget

type IAttributeDefinition = interface end
type IAttributeDefinition<'inputType, 'modelType> =
    inherit IAttributeDefinition
    abstract Key: AttributeKey
    abstract DefaultWith: unit -> 'modelType

type IWidgetDefinition =
    abstract CreateView: unit -> IViewNode

type IRunner = interface end

type IViewAdapter =
    inherit IDisposable
    abstract CreateView: unit -> IViewNode
    abstract Attach: IViewNode -> unit
    abstract Detach: bool -> unit