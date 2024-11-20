namespace Fabulous

open System.ComponentModel
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.FSharp.Core

type AttributesBundle = (struct (StackList<ScalarAttribute> * WidgetAttribute[] voption * WidgetCollectionAttribute[] voption * EnvironmentAttribute[] voption))

[<Struct; NoComparison; NoEquality>]
type WidgetBuilder<'msg, 'marker when 'msg: equality> =
    struct
        val Key: WidgetKey
        val Attributes: AttributesBundle

        new(key: WidgetKey) =
            { Key = key
              Attributes = AttributesBundle(StackList.empty(), ValueNone, ValueNone, ValueNone) }

        new(key: WidgetKey, attributes: AttributesBundle) = { Key = key; Attributes = attributes }

        new(key: WidgetKey, scalar: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.one scalar, ValueNone, ValueNone, ValueNone) }

        new(key: WidgetKey, scalarA: ScalarAttribute, scalarB: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.two(scalarA, scalarB), ValueNone, ValueNone, ValueNone) }

        new(key: WidgetKey, scalar1: ScalarAttribute, scalar2: ScalarAttribute, scalar3: ScalarAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.three(scalar1, scalar2, scalar3), ValueNone, ValueNone, ValueNone) }

        new(key: WidgetKey, widget: WidgetAttribute) =
            { Key = key
              Attributes = AttributesBundle(StackList.empty(), ValueSome [| widget |], ValueNone, ValueNone) }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.Compile() : Widget =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            { Key = x.Key
#if DEBUG
              DebugName = $"{typeof<'marker>.Name}<{typeof<'msg>.Name}>"
#endif
              ScalarAttributes =
                match StackList.length &scalarAttributes with
                | 0us -> ValueNone
                | _ -> ValueSome(Array.sortInPlace _.Key (StackList.toArray &scalarAttributes))

              WidgetAttributes = ValueOption.map (Array.sortInPlace(_.Key)) widgetAttributes

              WidgetCollectionAttributes = widgetCollectionAttributes |> ValueOption.map(Array.sortInPlace(_.Key))

              EnvironmentAttributes = environmentAttributes |> ValueOption.map(Array.sortInPlace(_.Key)) }

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddScalar(attr: ScalarAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            WidgetBuilder<'msg, 'marker>(
                x.Key,
                struct (StackList.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes, environmentAttributes)
            )

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddOrReplaceScalar
            (
                attrKey: ScalarAttributeKey,
                [<InlineIfLambda>] replaceWith: ScalarAttribute -> ScalarAttribute,
                [<InlineIfLambda>] defaultWith: unit -> ScalarAttribute
            ) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            match StackList.tryFind(&scalarAttributes, (fun attr -> attr.Key = attrKey)) with
            | ValueNone ->
                let attr = defaultWith()

                WidgetBuilder<'msg, 'marker>(
                    x.Key,
                    struct (StackList.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes, environmentAttributes)
                )

            | ValueSome attr ->
                let newAttr = replaceWith attr

                let newAttrs =
                    StackList.replace(&scalarAttributes, (fun attr -> attr.Key = attrKey), newAttr)

                WidgetBuilder<'msg, 'marker>(x.Key, struct (newAttrs, widgetAttributes, widgetCollectionAttributes, environmentAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidget(attr: WidgetAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            let attribs = widgetAttributes

            let res =
                match attribs with
                | ValueNone -> [| attr |]
                | ValueSome attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, ValueSome res, widgetCollectionAttributes, environmentAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member x.AddWidgetCollection(attr: WidgetCollectionAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            let attribs = widgetCollectionAttributes

            let res =
                match attribs with
                | ValueNone -> [| attr |]
                | ValueSome attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, widgetAttributes, ValueSome res, environmentAttributes))

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddEnvironment(key: EnvironmentAttributeKey, value: obj) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            let attr =
                { Key = key
#if DEBUG
                  DebugName = $"Environment.{key}"
#endif
                  Value = value }

            let attribs = environmentAttributes

            let res =
                match attribs with
                | ValueNone -> [| attr |]
                | ValueSome attribs ->
                    let attribs2 = Array.zeroCreate(attribs.Length + 1)
                    Array.blit attribs 0 attribs2 0 attribs.Length
                    attribs2[attribs.Length] <- attr
                    attribs2

            WidgetBuilder<'msg, 'marker>(x.Key, struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, ValueSome res))
    end



[<Struct>]
type Content<'msg> = { Widgets: MutStackArray1.T<Widget> }

[<Struct; NoComparison; NoEquality>]
type CollectionBuilder<'msg, 'marker, 'itemMarker when 'msg: equality> =
    struct
        val WidgetKey: WidgetKey
        val Attr: WidgetCollectionAttributeDefinition
        val Attributes: AttributesBundle

        new(widgetKey: WidgetKey, scalars: StackList<ScalarAttribute>, attr: WidgetCollectionAttributeDefinition) =
            { WidgetKey = widgetKey
              Attributes = AttributesBundle(scalars, ValueNone, ValueNone, ValueNone)
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition) =
            { WidgetKey = widgetKey
              Attributes = AttributesBundle(StackList.empty(), ValueNone, ValueNone, ValueNone)
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition, attributes: AttributesBundle) =
            { WidgetKey = widgetKey
              Attributes = attributes
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition, scalar: ScalarAttribute) =
            { WidgetKey = widgetKey
              Attributes = AttributesBundle(StackList.one scalar, ValueNone, ValueNone, ValueNone)
              Attr = attr }

        new(widgetKey: WidgetKey, attr: WidgetCollectionAttributeDefinition, scalarA: ScalarAttribute, scalarB: ScalarAttribute) =
            { WidgetKey = widgetKey
              Attributes = AttributesBundle(StackList.two(scalarA, scalarB), ValueNone, ValueNone, ValueNone)
              Attr = attr }

        member inline x.Run(c: Content<'msg>) =
            let struct (scalars, widgets, widgetCollections, environments) = x.Attributes

            let attrValue =
                match MutStackArray1.toArraySlice &c.Widgets with
                | ValueNone -> ArraySlice.emptyWithNull()
                | ValueSome slice -> slice

            let widgetCollAttr = x.Attr.WithValue(attrValue)

            let widgetCollections =
                match widgetCollections with
                | ValueNone -> ValueSome([| widgetCollAttr |])
                | ValueSome widgetCollectionAttributes -> ValueSome(Array.appendOne widgetCollAttr widgetCollectionAttributes)

            WidgetBuilder<'msg, 'marker>(x.WidgetKey, AttributesBundle(scalars, widgets, widgetCollections, environments))

        member inline _.Combine(a: Content<'msg>, b: Content<'msg>) : Content<'msg> =
            let res = MutStackArray1.combineMut(&a.Widgets, b.Widgets)

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

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member inline x.AddScalar(attr: ScalarAttribute) =
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes, environmentAttributes) =
                x.Attributes

            CollectionBuilder<'msg, 'marker, 'itemMarker>(
                x.WidgetKey,
                x.Attr,
                struct (StackList.add(&scalarAttributes, attr), widgetAttributes, widgetCollectionAttributes, environmentAttributes)
            )

    end

module CollectionBuilder =
    let inline yieldImpl (builder: WidgetBuilder<'msg, 'itemMarker>) : Content<'msg> =
        { Widgets = MutStackArray1.One(builder.Compile()) }

[<Struct>]
type AttributeCollectionBuilder<'msg, 'marker, 'itemMarker when 'msg: equality> =
    struct
        val Widget: WidgetBuilder<'msg, 'marker>
        val Attr: WidgetCollectionAttributeDefinition

        new(widget: WidgetBuilder<'msg, 'marker>, attr: WidgetCollectionAttributeDefinition) = { Widget = widget; Attr = attr }

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

type SingleChildBuilderStep<'msg, 'marker when 'msg: equality> = delegate of unit -> WidgetBuilder<'msg, 'marker>

[<Struct>]
type SingleChildBuilder<'msg, 'marker, 'childMarker when 'msg: equality> =
    val WidgetKey: WidgetKey
    val Attr: WidgetAttributeDefinition
    val AttributesBundle: AttributesBundle

    new(widgetKey: WidgetKey, attr: WidgetAttributeDefinition) =
        { WidgetKey = widgetKey
          Attr = attr
          AttributesBundle = AttributesBundle(StackList.empty(), ValueNone, ValueNone, ValueNone) }

    new(widgetKey: WidgetKey, attr: WidgetAttributeDefinition, attributesBundle: AttributesBundle) =
        { WidgetKey = widgetKey
          Attr = attr
          AttributesBundle = attributesBundle }

    member inline this.Yield(widget: WidgetBuilder<'msg, 'childMarker>) =
        SingleChildBuilderStep(fun () -> widget)

    member inline this.Combine
        ([<InlineIfLambda>] a: SingleChildBuilderStep<'msg, 'childMarker>, [<InlineIfLambda>] _b: SingleChildBuilderStep<'msg, 'childMarker>)
        =
        SingleChildBuilderStep(fun () ->
            // We only want one child, so we ignore the second one
            a.Invoke())

    member inline this.Delay([<InlineIfLambda>] fn: unit -> SingleChildBuilderStep<'msg, 'childMarker>) =
        SingleChildBuilderStep(fun () -> fn().Invoke())

    member inline this.Run([<InlineIfLambda>] result: SingleChildBuilderStep<'msg, 'childMarker>) =
        let childAttr = this.Attr.WithValue(result.Invoke().Compile())

        let struct (scalars, widgets, widgetCollections, environments) =
            this.AttributesBundle

        WidgetBuilder<'msg, 'marker>(
            this.WidgetKey,
            AttributesBundle(
                scalars,
                (match widgets with
                 | ValueNone -> ValueSome [| childAttr |]
                 | ValueSome widgets -> ValueSome(Array.appendOne childAttr widgets)),
                widgetCollections,
                environments
            )
        )
