module Tests.TestUI_Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Tests
open Tests.Platform
open TestUI_Attributes
open Tests.TestUI_ViewNode





type IBuilder<'msg> =
    abstract BoxedCompile : unit -> Widget

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

    member _.AddScalarAttribute(attr: ScalarAttribute) : WidgetBuilder<'msg, 'output> =
        let struct (scalarAttributes, widgetAttributes, widgetCollectionAttributes) = attributes
        let attribs = scalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        WidgetBuilder(key, struct (attribs2, widgetAttributes, widgetCollectionAttributes))

    member private x.Attr = attributes

    member x.MapMsg(fn: 'msg -> 'newMsg) =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'msg> |> fn |> box

        let builder =
            x.AddScalarAttribute(Fabulous.Attributes.MapMsg.WithValue fnWithBoxing)

        WidgetBuilder<'newMsg, 'marker>(key, builder.Attr)

    interface IBuilder<'msg> with
        member x.BoxedCompile() = x.Compile()







//-------Widgets



module Widgets =
    let register<'T when 'T :> TestViewElement and 'T: (new : unit -> 'T)> () =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            {
                Key = key
                Name = typeof<'T>.Name
                CreateView =
                    fun (widget, context) ->
                        let name = typeof<'T>.Name
                        printfn $"Creating view for {name}"

                        let view = new 'T()
                        let weakReference = WeakReference(view)

                        let viewNodeData =
                            ViewNodeData(ViewNode(key, context, weakReference))

                        view.PropertyBag.Add(ViewNode.ViewNodeProperty, viewNodeData)

                        Reconciler.update ViewNode.getViewNode context.CanReuseView ValueNone widget view

                        box view
            }

        WidgetDefinitionStore.set key definition
        key




///----Stack----

module ViewHelpers =
    let inline compileSeq (items: seq<#IBuilder<'msg>>) =
        items
        |> Seq.map(fun item -> item.BoxedCompile())
        |> Seq.toArray


//-----MARKERS-----------
type TestLabelMarker =
    class
    end

type TestButtonMarker =
    class
    end

type TestStackMarker =
    class
    end
//----------------

/// ------------ Extenstions
[<Extension>]
type WidgetExtensions() =
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, 'marker>, value: string) =
        this.AddScalarAttribute(Attributes.Automation.AutomationId.WithValue(value))

    //    [<Extension>]
//    static member inline cast<'msg>(this: IWidgetBuilder<'msg>) = this

    [<Extension>]
    static member inline textColor<'msg>(this: WidgetBuilder<'msg, TestLabelMarker>, value: string) =
        this.AddScalarAttribute(Attributes.TextStyle.TextColor.WithValue(value))

    [<Extension>]
    static member inline textColor<'msg>(this: WidgetBuilder<'msg, TestButtonMarker>, value: string) =
        this.AddScalarAttribute(Attributes.TextStyle.TextColor.WithValue(value))


let inline private scalars
    (value: ScalarAttribute [])
    : struct (ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute []) =
    struct (value, [||], [||])

///----------------
[<AbstractClass; Sealed>]
type View private () =
    static let TestLabelKey = Widgets.register<TestLabel>()
    static let TestButtonKey = Widgets.register<TestButton>()
    static let TestStackKey = Widgets.register<TestStack>()

    static member Label<'msg>(text: string) =
        WidgetBuilder<'msg, TestLabelMarker>(TestLabelKey, scalars [| Attributes.Text.Text.WithValue(text) |])


    static member Button<'msg>(text: string, onClicked: 'msg) =
        WidgetBuilder<'msg, TestButtonMarker>(
            TestButtonKey,
            scalars [| Attributes.Text.Text.WithValue(text)
                       Attributes.Button.Pressed.WithValue(onClicked) |]
        )


    static member Stack<'msg, 'a when 'a :> seq<IBuilder<'msg>>>(children: 'a) =
        WidgetBuilder<'msg, TestStackMarker>(
            TestStackKey,
            struct ([||],
                    [||],
                    [|
                        Attributes.Container.Children.WithValue(ViewHelpers.compileSeq children)
                    |])
        )


///------------------
type StatefulView<'arg, 'model, 'msg, 'marker> =
    {
        Init: 'arg -> 'model
        Update: 'msg -> 'model -> 'model
        View: 'model -> WidgetBuilder<'msg, 'marker>
    }

module StatefulWidget =
    let mkSimpleView init update view : StatefulView<_, _, _, _> =
        {
            Init = init
            Update = update
            View = view
        }


module Run =
    type Instance<'arg, 'model, 'msg, 'marker>(program: StatefulView<'arg, 'model, 'msg, 'marker>) =
        let mutable state: ('model * obj * Widget) option = None

        member private x.viewContext: ViewTreeContext =
            {
                CanReuseView = fun a b -> a.Key = b.Key
                Dispatch = fun msg -> unbox<'msg> msg |> x.ProcessMessage
                Ancestors = []
            }

        member x.ProcessMessage(msg: 'msg) =
            match state with
            | None -> ()
            | Some (m, target, oldWidget) ->
                let newModel = program.Update msg m
                let newWidget = program.View(newModel).Compile()

                // is it better to have a Kind prop instead
                // basically we care if it is exactly the same widget type as it was before
                // TODO support mount + unmount
                // TODO possibly introduce some notion of a platform/runtime context
                // that can mount and unmount nodes

                let viewNode = ViewNode.getViewNode target

                if newWidget.Key <> viewNode.Origin then
                    failwith "type mismatch!"

                state <- Some(newModel, target, newWidget)

                Reconciler.update ViewNode.getViewNode x.viewContext.CanReuseView (ValueSome oldWidget) newWidget target
                ()

        member x.Start(arg: 'arg) =
            let model = (program.Init(arg))
            let widget = program.View(model).Compile()
            let widgetDef = WidgetDefinitionStore.get widget.Key

            let view =
                widgetDef.CreateView(widget, x.viewContext)

            state <- Some(model, view, widget)

            view :?> TestViewElement

module View =
    let inline map (fn: 'oldMsg -> 'newMsg) (this: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        this.MapMsg fn
