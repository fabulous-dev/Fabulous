namespace Fabulous

open System.ComponentModel
open Fabulous.WidgetCollectionAttributeDefinitions
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.FSharp.Core

type AttributesBundle =
    (struct (StackList<ScalarAttribute> * WidgetAttribute [] voption * WidgetCollectionAttribute [] voption))

[<Struct; NoComparison; NoEquality>]
type WidgetBuilder<'msg, 'marker> =
    struct
        val Key: WidgetKey
        val Attributes: AttributesBundle

        new(key: WidgetKey, attributes: AttributesBundle) = { Key = key; Attributes = attributes }

        new(key: WidgetKey, scalar: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.one scalar, ValueNone, ValueNone) }

        new(key: WidgetKey, scalarA: ScalarAttribute, scalarB: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.two(scalarA, scalarB), ValueNone, ValueNone) }

        new(key: WidgetKey, scalar1: ScalarAttribute, scalar2: ScalarAttribute, scalar3: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.three(scalar1, scalar2, scalar3), ValueNone, ValueNone) }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.Compile() : Widget =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes

            { Key = x.Key
#if DEBUG
              DebugName = $"{typeof<'marker>.Name}<{typeof<'msg>.Name}>"
#endif
              ScalarAttributes =
                  match StackList.length &scalarAttributes with
                  | 0us -> ValueNone
                  | _ -> ValueSome(Array.sortInPlace(fun a -> a.Key) (StackList.toArray &scalarAttributes))

              WidgetAttributes = ValueOption.map(Array.sortInPlace(fun a -> a.Key)) widgetAttributes


              WidgetCollectionAttributes =
                  widgetCollectionAttributes
                  |> ValueOption.map(Array.sortInPlace(fun a -> a.Key)) }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddScalar(attr: ScalarAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes

            WidgetBuilder<'msg, 'marker>(
                x.Key,
                struct (StackList.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes)
            )

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.TryAddOrReplace
            (
                attrKey: ScalarAttributeKey,
                [<InlineIfLambda>] replaceWith: ScalarAttribute -> ScalarAttribute,
                [<InlineIfLambda>] defaultWith: unit -> ScalarAttribute
            ) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes

            match StackList.tryFind(&scalarAttributes, (fun attr -> attr.Key = attrKey)) with
            | ValueNone ->
                let attr = defaultWith()

                WidgetBuilder<'msg, 'marker>(
                    x.Key,
                    struct (StackList.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes)
                )

            | ValueSome attr ->
                let newAttr = replaceWith attr

                let newAttrs =
                    StackList.replace(&scalarAttributes, (fun attr -> attr.Key = attrKey), newAttr)

                WidgetBuilder<'msg, 'marker>(x.Key, struct (newAttrs, widgetAttributes, widgetCollectionAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidget(attr: WidgetAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            let attribs = widgetAttributes

            let res =
                match attribs with
                | ValueNone -> [| attr |]
                | ValueSome attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2.[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, ValueSome res, widgetCollectionAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidgetCollection(attr: WidgetCollectionAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            let attribs = widgetCollectionAttributes

            let res =
                match attribs with
                | ValueNone -> [| attr |]
                | ValueSome attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2.[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, widgetAttributes, ValueSome res))
    end



[<Struct>]
type Content<'msg> = { Widgets: MutStackArray1.T<Widget> }

[<Struct; NoComparison; NoEquality>]
type CollectionBuilder<'msg, 'marker, 'itemMarker> =
    struct
        val WidgetKey: WidgetKey
        val Scalars: StackList<ScalarAttribute>
        val Attr: WidgetCollectionAttributeDefinition

        new(widgetKey: WidgetKey, scalars: StackList<ScalarAttribute>, attr: WidgetCollectionAttributeDefinition) =
            { WidgetKey = widgetKey
              Scalars = scalars
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition) =
            { WidgetKey = widgetKey
              Scalars = StackList.empty()
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition, scalar: ScalarAttribute) =
            { WidgetKey = widgetKey
              Scalars = StackList.one scalar
              Attr = attr }

        new(widgetKey: WidgetKey,
            attr: WidgetCollectionAttributeDefinition,
            scalarA: ScalarAttribute,
            scalarB: ScalarAttribute) =
            { WidgetKey = widgetKey
              Scalars = StackList.two(scalarA, scalarB)
              Attr = attr }

        member inline x.Run(c: Content<'msg>) =
            let attrValue =
                match MutStackArray1.toArraySlice &c.Widgets with
                | ValueNone -> ArraySlice.emptyWithNull()
                | ValueSome slice -> slice

            WidgetBuilder<'msg, 'marker>(
                x.WidgetKey,
                AttributesBundle(x.Scalars, ValueNone, ValueSome [| x.Attr.WithValue(attrValue) |])
            )

        member inline _.Combine(a: Content<'msg>, b: Content<'msg>) : Content<'msg> =
            let res =
                MutStackArray1.combineMut(&a.Widgets, b.Widgets)

            { Widgets = res }

        member inline _.Zero() : Content<'msg> = { Widgets = MutStackArray1.Empty }

        member inline _.Delay([<InlineIfLambda>] f) : Content<'msg> = f()

        member inline x.For<'t>(sequence: 't seq, f: 't -> Content<'msg>) : Content<'msg> =
            let mutable res: Content<'msg> = x.Zero()

            // this is essentially Fold, not sure what is more optimal
            // handwritten version of via Seq.Fold
            for t in sequence do
                res <- x.Combine(res, f t)

            res
    end

[<Struct>]
type AttributeCollectionBuilder<'msg, 'marker, 'itemMarker> =
    struct
        val Widget: WidgetBuilder<'msg, 'marker>
        val Attr: WidgetCollectionAttributeDefinition

        new(widget: WidgetBuilder<'msg, 'marker>, attr: WidgetCollectionAttributeDefinition) =
            { Widget = widget; Attr = attr }

        member inline x.Run(c: Content<'msg>) =
            let attrValue =
                match MutStackArray1.toArraySlice &c.Widgets with
                | ValueNone -> ArraySlice.emptyWithNull()
                | ValueSome slice -> slice

            x.Widget.AddWidgetCollection(x.Attr.WithValue(attrValue))

        member inline _.Combine(a: Content<'msg>, b: Content<'msg>) : Content<'msg> =
            { Widgets = MutStackArray1.combineMut(&a.Widgets, b.Widgets) }

        member inline _.Zero() : Content<'msg> = { Widgets = MutStackArray1.Empty }

        member inline _.Delay([<InlineIfLambda>] f) : Content<'msg> = f()

        member inline x.For<'t>(sequence: 't seq, [<InlineIfLambda>] f: 't -> Content<'msg>) : Content<'msg> =
            let mutable res: Content<'msg> = x.Zero()

            // this is essentially Fold, not sure what is more optimal
            // handwritten version of via Seq.Fold
            for t in sequence do
                res <- x.Combine(res, f t)

            res
    end
