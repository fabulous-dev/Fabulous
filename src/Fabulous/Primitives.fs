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

type AttributeKey = uint32<attributeKey>

module AttributeKey =
    [<Struct>]
    type Kind =
        | Boxed // 1
        | Inline // 2

    module Code =
        [<Literal>]
        // 1u <<< 30
        let Boxed = 1073741824u

        [<Literal>]
        // 2u <<< 30
        let Inline = 2147483648u

        [<Literal>]
        // 3u <<< 30
        let CodeMask = 3221225472u

        [<Literal>]
        // System.UInt32.MaxValue >>> 2
        let KeyMask = 1073741823u

    let inline getKind (key: AttributeKey) : Kind =
        match (uint32 key) &&& Code.Inline with
        | Code.Inline -> Inline
        | _ -> Boxed

    let inline getKeyValue (key: AttributeKey) : int = int ((uint32 key) &&& Code.KeyMask)


    let inline compare (a: AttributeKey) (b: AttributeKey) =
        let a = uint32 a
        let b = uint32 b
        a.CompareTo b

type WidgetKey = int
type StateKey = int
type ViewAdapterKey = int

/// Represents a value for a property of a widget.
/// Can map to a real property (such as Label.Text) or to a non-existent one.
/// It will be up to the AttributeDefinition to decide how to apply the value.
[<Struct>]
type ScalarAttribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: obj

      NumericValue: uint64 }


and [<Struct>] WidgetAttribute =
    { Key: AttributeKey
#if DEBUG
      DebugName: string
#endif
      Value: Widget }

and [<Struct>] WidgetCollectionAttribute =
    { Key: AttributeKey
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
