module Tests.TestUI_Widgets

open System
open System.Runtime.CompilerServices
open Fabulous
open Tests
open Tests.Platform
open TestUI_Attributes
open Tests.TestUI_ViewNode


//----WidgetsBuilderCE---


[<Struct>]
type Content<'msg> = { Widgets: Widget list }

[<Struct>]
type CollectionBuilder<'msg, 'output>
    (
        widgetKey: WidgetKey,
        scalars: ScalarAttribute [] voption,
        attr: WidgetCollectionAttributeDefinition
    ) =

    member _.Run(c: Content<'msg>) =
        WidgetBuilder<'msg, 'output>(
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
    member inline _.Yield(x: WidgetBuilder<'msg, _>) : Content<'msg> = { Widgets = [ x.Compile() ] }

    member inline _.YieldFrom(x: WidgetBuilder<'msg, _> seq) : Content<'msg> =
        {
            Widgets = x |> Seq.map(fun wb -> wb.Compile()) |> Seq.toList
        }

    member inline _.Delay([<InlineIfLambda>] f) : Content<'msg> = f()

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

                        let viewNode = ViewNode(context, weakReference)

                        view.PropertyBag.Add(ViewNode.ViewNodeProperty, viewNode)

                        Reconciler.update
                            context.ViewTreeContext.GetViewNode
                            context.ViewTreeContext.CanReuseView
                            ValueNone
                            widget
                            view

                        box view
            }

        WidgetDefinitionStore.set key definition
        key





//-----MARKERS-----------
type IMarker =
    interface
    end

type TextMarker =
    inherit IMarker

type TestLabelMarker =
    inherit TextMarker

type TestButtonMarker =
    inherit TextMarker

type TestStackMarker =
    inherit IMarker
//----------------

/// ------------ Extenstions
[<Extension>]
type WidgetExtensions() =
    [<Extension>]
    static member inline automationId<'msg, 'marker when 'marker :> IMarker>
        (
            this: WidgetBuilder<'msg, 'marker>,
            value: string
        ) =
        this.AddScalar(Attributes.Automation.AutomationId.WithValue(value))

    [<Extension>]
    static member inline textColor<'msg, 'marker when 'marker :> TextMarker>
        (
            this: WidgetBuilder<'msg, 'marker>,
            value: string
        ) =
        this.AddScalar(Attributes.TextStyle.TextColor.WithValue(value))


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

    static member Stack<'msg, 'marker when 'marker :> IMarker>() =
        CollectionBuilder<'msg, TestStackMarker>(TestStackKey, ValueNone, Attributes.Container.Children)



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
                GetViewNode = ViewNode.getViewNode
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

                if newWidget.Key <> viewNode.Context.Key then
                    failwith "type mismatch!"

                state <- Some(newModel, target, newWidget)

                Reconciler.update ViewNode.getViewNode x.viewContext.CanReuseView (ValueSome oldWidget) newWidget target
                ()

        member x.Start(arg: 'arg) =
            let model = (program.Init(arg))
            let widget = program.View(model).Compile()
            let widgetDef = WidgetDefinitionStore.get widget.Key

            let context =
                {
                    Key = widget.Key
                    ViewTreeContext = x.viewContext
                    Ancestors = []
                    MapMsg = id
                }

            let view = widgetDef.CreateView(widget, context)

            state <- Some(model, view, widget)

            view :?> TestViewElement

module View =
    let inline map (fn: 'oldMsg -> 'newMsg) (this: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        this.MapMsg fn
