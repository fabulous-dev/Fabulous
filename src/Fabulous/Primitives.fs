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


[<Measure>]
type attributeKey

[<Measure>]
type attributeWidgetKey

[<Measure>]
type attributeWidgetCollectionKey

type ScalarAttributeKey = int<attributeKey>
type WidgetAttributeKey = int<attributeWidgetKey>
type WidgetCollectionAttributeKey = int<attributeWidgetCollectionKey>

module ScalarAttributeKey =
    [<Struct>]
    type Kind =
        | Boxed // 1
        | Inline // 2

    module Code =
        [<Literal>]
        // 1 <<< 30
        let Boxed = 1073741824

        [<Literal>]
        // 2 <<< 30
        let Inline = -2147483648

        [<Literal>]
        // 3 <<< 30
        let CodeMask = -1073741824

        [<Literal>]
        // System.Int32.MaxValue >>> 2
        let KeyMask = 536870911

    let inline getKind (key: ScalarAttributeKey) : Kind =
        match (int key) &&& Code.Inline with
        | Code.Inline -> Inline
        | _ -> Boxed

    let inline getKeyValue (key: ScalarAttributeKey) : int = int((int key) &&& Code.KeyMask)


    let inline compare (a: ScalarAttributeKey) (b: ScalarAttributeKey) =
        let a = int a
        let b = int b
        a.CompareTo b


module WidgetAttributeKey =
    let inline compare (a: WidgetAttributeKey) (b: WidgetAttributeKey) =
        let a = int a
        let b = int b
        a.CompareTo b

module WidgetCollectionAttributeKey =
    let inline compare (a: WidgetCollectionAttributeKey) (b: WidgetCollectionAttributeKey) =
        let a = int a
        let b = int b
        a.CompareTo b

type WidgetKey = int
type StateKey = int
type ViewAdapterKey = int

/// Represents a value for a property of a widget.
/// Can map to a real property (such as Label.Text) or to a non-existent one.
/// It will be up to the AttributeDefinition to decide how to apply the value.
[<Struct>]
type ScalarAttribute =
    { Key: ScalarAttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: obj

      NumericValue: uint64 }


and [<Struct>] WidgetAttribute =
    { Key: WidgetAttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: Widget }

and [<Struct>] WidgetCollectionAttribute =
    { Key: WidgetCollectionAttributeKey
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
