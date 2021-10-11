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
    {
        Key: AttributeKey
#if DEBUG
        DebugName: string
#endif
        Value: obj
    }

/// Represents a virtual UI element such as a Label, a Button, etc.
[<Struct>]
type Widget =
    {
        Key: WidgetKey
        Attributes: Attribute []
    }

[<Struct; RequireQualifiedAccess>]
type AttributeChange =
    | Added of added: Attribute
    | Removed of removed: Attribute
    | Updated of struct (Attribute * Attribute * obj voption)

//
//    | Identical
//    | ScalarUpdated of updatedValue: obj
//    | ScalarWidgetUpdated of updatedWidget: WidgetDiff
//    | CollectionUpdated of collectionDiffs: CollectionDiff []
//[<RequireQualifiedAccess>]
//    type AttributeDiff =
//        | Different of struct (Attribute * Attribute * obj option)
//        | Added of Attribute
//        | Removed of Attribute

//and [<Struct; RequireQualifiedAccess>] AttributeDiffWithKey =
//    {
//        Key: AttributeKey
//        Diff: AttributeChange
//    }

type [<Struct; RequireQualifiedAccess>] WidgetDiff =
   {
       Changes: AttributeChange[]
       NewAttributes: Attribute[]
   }

type ViewTreeContext = { Dispatch: obj -> unit }

/// Represents a UI element created from a widget
type IViewNode =
    abstract SetContext : ViewTreeContext -> unit
    abstract ApplyDiff : WidgetDiff -> UpdateResult
    abstract Attributes : Attribute[]
    abstract Origin: WidgetKey
    
and [<Struct>] ChildrenUpdate =
    {
        ChildrenAfterUpdate: IViewNode []
        Added: IViewNode list voption
        Removed: IViewNode list voption
    }

// TODO should it be IList? or a simpler custom interface will do?
and IViewContainer =
    abstract Children : IViewNode []
    abstract UpdateChildren : ChildrenUpdate -> unit

and [<RequireQualifiedAccess; Struct>] UpdateResult =
    | Done
    | UpdateChildren of struct (IViewContainer * Widget [] * ViewTreeContext)    


type IComponent =
    interface
    end

type IStatefulComponent<'arg, 'model, 'msg> =
    inherit IComponent
    abstract Init : 'arg -> 'model
    abstract Update : 'msg * 'model -> 'model
    abstract View : 'model -> Widget

type IStatelessComponent =
    inherit IComponent
    abstract View : unit -> Widget

[<Struct>]
[<RequireQualifiedAccess>]
type AttributeComparison =
    | Identical
    | Different of data: obj voption

type IAttributeDefinition =
    abstract CompareBoxed : obj * obj -> AttributeComparison

type IAttributeDefinition<'inputType, 'modelType> =
    inherit IAttributeDefinition
    abstract Key : AttributeKey
    abstract DefaultWith : unit -> 'modelType

type IWidgetDefinition =
    abstract CreateView : Widget -> IViewNode

type IRunner =
    interface
    end

type IViewAdapter =
    inherit IDisposable
    abstract CreateView : unit -> IViewNode
    abstract Attach : IViewNode -> unit
    abstract Detach : bool -> unit
