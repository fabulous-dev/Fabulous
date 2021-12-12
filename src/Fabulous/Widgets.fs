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

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.Compile() : Widget =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes

        {
            Key = key
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
    member _.AddScalars(attrs: ScalarAttribute []) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = scalarAttributes

        let attribs2 =
            Array.zeroCreate(attribs.Length + attrs.Length)

        Array.blit attribs 0 attribs2 0 attribs.Length
        Array.blit attrs 0 attribs2 (attribs.Length - 1) attrs.Length

        WidgetBuilder<'msg, 'marker>(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))

    member private _.Attrs = attributes

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member x.MapMsg(fn: 'msg -> 'newMsg) =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'msg> |> fn |> box

        let builder =
            x.AddScalar(Attributes.MapMsg.WithValue fnWithBoxing)

        WidgetBuilder<'newMsg, 'marker>(key, builder.Attrs)

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
                    | ValueSome s -> s // add spacing attribute here
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

module View =
    let inline map (fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        x.MapMsg fn
