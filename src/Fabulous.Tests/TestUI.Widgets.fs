module Tests.TestUI_Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Tests
open Tests.Platform
open TestUI_Attributes
open Tests.TestUI_ViewNode



type IWidgetBuilder =
    abstract ScalarAttributes : ScalarAttribute []
    abstract WidgetAttributes : WidgetAttribute []
    abstract WidgetCollectionAttributes : WidgetCollectionAttribute []
    abstract Compile : unit -> Widget

type IWidgetBuilder<'msg> =
    inherit IWidgetBuilder


[<Extension>]
type IWidgetExtensions() =
    [<Extension>]
    static member inline AddScalarAttribute(this: ^T :> IWidgetBuilder, attr: ScalarAttribute) =
        let attribs = this.ScalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        let result =
            (^T: (new : ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute [] -> ^T) (attribs2,
                                                                                                       this.WidgetAttributes,
                                                                                                       this.WidgetCollectionAttributes))

        result


    [<Extension>]
    static member inline AddScalar_(this: ^T :> IWidgetBuilder, attr: ScalarAttribute) =
        let attribs = this.ScalarAttributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        let result =
            (^T: (new : ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute [] -> ^T) (attribs2,
                                                                                                       this.WidgetAttributes,
                                                                                                       this.WidgetCollectionAttributes))

        result

    [<Extension>]
    static member inline AddScalarAttributes(this: ^T :> IWidgetBuilder, attrs: ScalarAttribute []) =
        match attrs with
        | [||] -> this
        | attributes ->
            let attribs2 =
                Array.append this.ScalarAttributes attributes

            let result =
                (^T: (new : ScalarAttribute [] * WidgetAttribute [] * WidgetCollectionAttribute [] -> ^T) (attribs2,
                                                                                                           this.WidgetAttributes,
                                                                                                           this.WidgetCollectionAttributes))

            result



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



[<Struct>]
type LabelWidgetBuilder<'msg>
    (
        scalarAttributes: ScalarAttribute [],
        widgetAttributes: WidgetAttribute [],
        widgetCollectionAttributes: WidgetCollectionAttribute []
    ) =
    static let key = Widgets.register<TestLabel>()

    static member inline Create(text: string) =
        LabelWidgetBuilder<'msg>(
            [|
                Attributes.Text.Text.WithValue(text)
            |],
            [||],
            [||]
        )

    interface IWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes

        member _.Compile() =
            {
                Key = key
                ScalarAttributes = scalarAttributes
                WidgetAttributes = widgetAttributes
                WidgetCollectionAttributes = widgetCollectionAttributes
            }

[<Struct>]
type ButtonWidgetBuilder<'msg>
    (
        scalarAttributes: ScalarAttribute [],
        widgetAttributes: WidgetAttribute [],
        widgetCollectionAttributes: WidgetCollectionAttribute []
    ) =
    static let key = Widgets.register<TestButton>()

    static member inline Create(text: string, onClicked: 'msg) =
        ButtonWidgetBuilder<'msg>(
            [|
                Attributes.Text.Text.WithValue(text)
                Attributes.Button.Pressed.WithValue(onClicked)
            |],
            [||],
            [||]
        )

    interface IWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes

        member _.Compile() =
            {
                Key = key
                ScalarAttributes = scalarAttributes
                WidgetAttributes = widgetAttributes
                WidgetCollectionAttributes = widgetCollectionAttributes
            }


///----Stack----

module ViewHelpers =
    let inline compileSeq (items: seq<#IWidgetBuilder<'msg>>) =
        items
        |> Seq.map(fun item -> item.Compile())
        |> Seq.toArray


[<Struct>]
type StackWidgetBuilder<'msg>
    (
        scalarAttributes: ScalarAttribute [],
        widgetAttributes: WidgetAttribute [],
        widgetCollectionAttributes: WidgetCollectionAttribute []
    ) =
    static let key = Widgets.register<TestStack>()

    static member inline Create(children: seq<#IWidgetBuilder<'msg>>) =
        StackWidgetBuilder<'msg>(
            [||],
            [||],
            [|
                Attributes.Container.Children.WithValue(ViewHelpers.compileSeq children)
            |]
        )

    interface IWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes

        member _.Compile() =
            {
                Key = key
                ScalarAttributes = scalarAttributes
                WidgetAttributes = widgetAttributes
                WidgetCollectionAttributes = widgetCollectionAttributes
            }



//[<Struct>]
//type WrappedWidget<'msg>(childWidget: Widget) =
//    interface IWidget<'msg> with
//        member x.Compile() = childWidget
//        member this.Attributes = childWidget.Attributes
//


/// ------------ Extenstions
[<Extension>]
type WidgetExtensions() =
    [<Extension>]
    static member inline automationId(this: #IWidgetBuilder, value: string) =
        this.AddScalarAttribute(Attributes.Automation.AutomationId.WithValue(value))

    [<Extension>]
    static member inline cast<'msg>(this: IWidgetBuilder<'msg>) = this

    [<Extension>]
    static member inline textColor<'msg>(this: LabelWidgetBuilder<'msg>, value: string) =
        this.AddScalarAttribute(Attributes.TextStyle.TextColor.WithValue(value))

    [<Extension>]
    static member inline textColor<'msg>(this: ButtonWidgetBuilder<'msg>, value: string) =
        this.AddScalarAttribute(Attributes.TextStyle.TextColor.WithValue(value))


///----------------


///----------------
[<AbstractClass; Sealed>]
type View private () =
    static member inline Label<'msg>(text) = LabelWidgetBuilder<'msg>.Create text

    static member inline Button<'msg>(text, msg) =
        ButtonWidgetBuilder<'msg>.Create (text, msg)

    //    static member inline Stack children = StackWidgetBuilder.Create children

    static member inline Stack<'msg, 'a when 'a :> seq<IWidgetBuilder<'msg>>>(children: 'a) =
        StackWidgetBuilder.Create children



//    static member inline map (mapFn: 'childMsg -> 'msg) (widget: IWidget<'childMsg>) : IWidget<'msg> =
//        let compiled = widget.Compile()
//
//        let attributes =
//            Array.append
//                // TODO make it efficient
//                [|
//                    Runtime.MapMsg.WithValue(fun m -> unbox<'childMsg> m |> mapFn |> box)
//                |]
//                compiled.Attributes
//
//        WrappedWidget<'msg>(
//            {
//                Key = compiled.Key
//                Attributes = attributes
//            }
//        )
//        :> IWidget<'msg>




///------------------
type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IWidgetBuilder> =
    {
        Init: 'arg -> 'model
        Update: 'msg -> 'model -> 'model
        View: 'model -> 'view
    }

module StatefulWidget =
    let mkSimpleView init update view : StatefulView<_, _, _, _> =
        {
            Init = init
            Update = update
            View = view
        }


module Run =
    type Instance<'arg, 'model, 'msg, 'widget when 'widget :> IWidgetBuilder>
        (
            program: StatefulView<'arg, 'model, 'msg, 'widget>
        ) =
        let mutable state: ('model * obj) option = None

        member private x.viewContext: ViewTreeContext =
            {
                CanReuseView = fun a b -> a.Key = b.Key
                Dispatch = fun msg -> unbox<'msg> msg |> x.ProcessMessage
                Ancestors = []
            }

        member x.ProcessMessage(msg: 'msg) =
            match state with
            | None -> ()
            | Some (m, target) ->
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

                state <- Some(newModel, target)

                Reconciler.update ViewNode.getViewNode x.viewContext.CanReuseView ValueNone newWidget target
                ()

        member x.Start(arg: 'arg) =
            let model = (program.Init(arg))
            let widget = program.View(model).Compile()
            let widgetDef = WidgetDefinitionStore.get widget.Key

            let view =
                widgetDef.CreateView(widget, x.viewContext)

            state <- Some(model, view)

            view :?> TestViewElement

module View =
    let inline map (fn: 'oldMsg -> 'newMsg) (this: ^T :> IWidgetBuilder<'oldMsg>) : ^U :> IWidgetBuilder<'newMsg> =
        (^T: (member MapMsg : ('oldMsg -> 'newMsg) -> 'U) (this, fn))
