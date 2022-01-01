namespace Fabulous

open System.ComponentModel
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.FSharp.Core


type AttributesBundle =
    (struct (StackArray3<ScalarAttribute> * WidgetAttribute [] option * WidgetCollectionAttribute [] option))

[<Struct; NoComparison; NoEquality>]
type WidgetBuilder<'msg, 'marker> =
    struct
        val Key: WidgetKey
        val Attributes: AttributesBundle

        new(key: WidgetKey, attributes: AttributesBundle) = { Key = key; Attributes = attributes }

        new(key: WidgetKey, scalar: ScalarAttribute) =
            {
                Key = key
                Attributes = struct (StackArray3.one scalar, None, None)
            }

        new(key: WidgetKey, scalarA: ScalarAttribute, scalarB: ScalarAttribute) =
            {
                Key = key
                Attributes = struct (StackArray3.two(scalarA, scalarB), None, None)
            }

        new(key: WidgetKey, scalar1: ScalarAttribute, scalar2: ScalarAttribute, scalar3: ScalarAttribute) =
            {
                Key = key
                Attributes = struct (StackArray3.three(scalar1, scalar2, scalar3), None, None)
            }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.Compile() : Widget =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes

            {
                Key = x.Key
#if DEBUG
                DebugName = $"{typeof<'marker>.Name}<{typeof<'msg>.Name}>"
#endif
                ScalarAttributes =
                    match StackArray3.length &scalarAttributes with
                    | 0 -> None
                    | _ -> Some(Array.sortInPlace(fun a -> a.Key) (StackArray3.toArray &scalarAttributes))

                WidgetAttributes =
                    widgetAttributes
                    |> Option.map(Array.sortInPlace(fun a -> a.Key))


                WidgetCollectionAttributes =
                    widgetCollectionAttributes
                    |> Option.map(Array.sortInPlace(fun a -> a.Key))
            }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddScalar(attr: ScalarAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            //        let attribs = scalarAttributes
            //        let attribs2 = Array.zeroCreate(attribs.Length + 1)
            //        Array.blit attribs 0 attribs2 0 attribs.Length
            //        attribs2.[attribs.Length] <- attr

            WidgetBuilder<'msg, 'marker>(
                x.Key,
                struct (StackArray3.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes)
            )

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidget(attr: WidgetAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            let attribs = widgetAttributes

            let res =
                match attribs with
                | None -> [| attr |]
                | Some attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2.[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, Some res, widgetCollectionAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidgetCollection(attr: WidgetCollectionAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            let attribs = widgetCollectionAttributes

            let res =
                match attribs with
                | None -> [| attr |]
                | Some attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2.[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, widgetAttributes, Some res))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddScalars(attrs: ScalarAttribute []) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = x.Attributes
            //        if attrs.Length = 0 then
            //            x
            //        else
            //            let attribs = scalarAttributes
            //
            //            let attribs2 =
            //                Array.zeroCreate(attribs.Length + attrs.Length)
            //
            //            Array.blit attribs 0 attribs2 0 attribs.Length
            //            Array.blit attrs 0 attribs2 attribs.Length attrs.Length
            // TODO
            failwith "TODO"
    end

//        let t = (StackArray3.fromArray attrs)
//
//        let newScalars =
//            StackArray3.combine(&scalarAttributes, &t)
//
//        WidgetBuilder<'msg, 'marker>(key, struct (newScalars, widgetAttributes, widgetCollectionAttributes))

[<Struct>]
type Content<'msg> = { Widgets: MutStackArray1.T<Widget> }

[<Struct; NoComparison; NoEquality>]
type CollectionBuilder<'msg, 'marker, 'itemMarker> =
    struct
        val WidgetKey: WidgetKey
        val Scalars: StackArray3<ScalarAttribute>
        val Attr: WidgetCollectionAttributeDefinition

        new(widgetKey: WidgetKey, scalars: StackArray3<ScalarAttribute>, attr: WidgetCollectionAttributeDefinition) =
            {
                WidgetKey = widgetKey
                Scalars = scalars
                Attr = attr
            }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition) =
            {
                WidgetKey = widgetKey
                Scalars = StackArray3.empty()
                Attr = attr
            }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition, scalar: ScalarAttribute) =
            {
                WidgetKey = widgetKey
                Scalars = StackArray3.one scalar
                Attr = attr
            }

        new(widgetKey: WidgetKey,
            attr: WidgetCollectionAttributeDefinition,
            scalarA: ScalarAttribute,
            scalarB: ScalarAttribute) =
            {
                WidgetKey = widgetKey
                Scalars = StackArray3.two(scalarA, scalarB)
                Attr = attr
            }

        member inline x.Run(c: Content<'msg>) =
            let attrValue =
                match MutStackArray1.toArraySlice &c.Widgets with
                | ValueNone -> ArraySlice.emptyWithNull()
                | ValueSome slice -> slice

            WidgetBuilder<'msg, 'marker>(x.WidgetKey, struct (x.Scalars, None, Some [| x.Attr.WithValue(attrValue) |]))

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
            {
                Widgets = MutStackArray1.combineMut(&a.Widgets, b.Widgets)
            }

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
