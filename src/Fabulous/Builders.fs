namespace Fabulous

open System.ComponentModel
open Fabulous
open Microsoft.FSharp.Core

[<Struct>]
type WidgetBuilder<'msg, 'marker>
    (
        key: WidgetKey,
        attributes: struct (ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute [])
    ) =
    
    member _.Key = key
    member _.Attributes = attributes

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.Compile() : Widget =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes

        {
            Key = key
#if DEBUG
            DebugName = $"{typeof<'marker>.Name}<{typeof<'msg>.Name}>"
#endif
            ScalarAttributes = scalarAttributes
            WidgetAttributes = widgetAttributes
            WidgetCollectionAttributes = widgetCollectionAttributes
        }

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.AddScalar(attr: ScalarAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = scalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.AddWidget(attr: WidgetAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = widgetAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (scalarAttributes, attribs2, widgetCollectionAttributes))

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.AddWidgetCollection(attr: WidgetCollectionAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = widgetCollectionAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (scalarAttributes, widgetAttributes, attribs2))

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member x.AddScalars(attrs: ScalarAttribute []) =
        if attrs.Length = 0 then
            x
        else
            let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
            let attribs = scalarAttributes

            let attribs2 =
                Array.zeroCreate(attribs.Length + attrs.Length)

            Array.blit attribs 0 attribs2 0 attribs.Length
            Array.blit attrs 0 attribs2 attribs.Length attrs.Length

            WidgetBuilder<'msg, 'marker>(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))

[<Struct>]
type Content<'msg> = { Widgets: Widget list }

[<Struct>]
type CollectionBuilder<'msg, 'marker, 'itemMarker>
    (
        widgetKey: WidgetKey,
        scalars: ScalarAttribute [] voption,
        attr: WidgetCollectionAttributeDefinition
    ) =

    member _.Run(c: Content<'msg>) =
        WidgetBuilder<'msg, 'marker>(
            widgetKey,
            struct (match scalars with
                    | ValueNone -> [||]
                    | ValueSome s -> s
                    , [||]
                    , [|
                        attr.WithValue(List.toArray c.Widgets)
                    |])
        )

    member inline _.Combine(a: Content<'msg>, b: Content<'msg>) : Content<'msg> = { Widgets = a.Widgets @ b.Widgets }

    member inline _.Zero() : Content<'msg> = { Widgets = [] }

    member inline _.Delay([<InlineIfLambda>] f) : Content<'msg> = f()

    member inline x.For<'t>(sequence: 't seq, [<InlineIfLambda>] f: 't -> Content<'msg>) : Content<'msg> =
        let mutable res: Content<'msg> = x.Zero()

        // this is essentially Fold, not sure what is more optimal
        // handwritten version of via Seq.Fold
        for t in sequence do
            res <- x.Combine(res, f t)

        res
        
[<Struct>]
type AttributeCollectionBuilder<'msg, 'marker, 'itemMarker>
    (
        widget: WidgetBuilder<'msg, 'marker>,
        attr: WidgetCollectionAttributeDefinition
    ) =

    member _.Run(c: Content<'msg>) =
        widget.AddWidgetCollection(attr.WithValue(List.toArray c.Widgets))

    member inline _.Combine(a: Content<'msg>, b: Content<'msg>) : Content<'msg> = { Widgets = a.Widgets @ b.Widgets }

    member inline _.Zero() : Content<'msg> = { Widgets = [] }

    member inline _.Delay([<InlineIfLambda>] f) : Content<'msg> = f()

    member inline x.For<'t>(sequence: 't seq, [<InlineIfLambda>] f: 't -> Content<'msg>) : Content<'msg> =
        let mutable res: Content<'msg> = x.Zero()

        // this is essentially Fold, not sure what is more optimal
        // handwritten version of via Seq.Fold
        for t in sequence do
            res <- x.Combine(res, f t)

        res
