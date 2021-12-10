namespace Fabulous

[<Struct>]
type WidgetBuilder<'msg, 'marker>
    (
        key: WidgetKey,
        attributes: struct (ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute [])
    ) =

    member _.Compile() : Widget =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes

        {
            Key = key
            ScalarAttributes = scalarAttributes
            WidgetAttributes = widgetAttributes
            WidgetCollectionAttributes = widgetCollectionAttributes
        }

    member _.AddScalar(attr: ScalarAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = scalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))

    member _.AddWidget(attr: WidgetAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = widgetAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (scalarAttributes, attribs2, widgetCollectionAttributes))

    member _.AddWidgetCollection(attr: WidgetCollectionAttribute) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = widgetCollectionAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder<'msg, 'marker>(key, struct (scalarAttributes, widgetAttributes, attribs2))
        
    member _.AddScalars(attrs: ScalarAttribute[]) =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = scalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + attrs.Length)
        Array.blit attribs 0 attribs2 0 attribs.Length
        Array.blit attrs 0 attribs2 (attribs.Length - 1) attrs.Length

        WidgetBuilder<'msg, 'marker>(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))
        
    member private _.Attrs = attributes

    member x.MapMsg(fn: 'msg -> 'newMsg) =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'msg> |> fn |> box

        let builder = x.AddScalar(Attributes.MapMsg.WithValue fnWithBoxing)
        WidgetBuilder<'newMsg, 'marker>(key, builder.Attrs)