namespace Fabulous.Tests.APISketchTests

module TestUI_Widgets =

    open System
    open System.Runtime.CompilerServices
    open Fabulous
    open Fabulous.StackAllocatedCollections
    open Fabulous.StackAllocatedCollections.StackList
    open Platform
    open TestUI_Attributes
    open TestUI_ViewNode
    open TestUI_Component


    //----WidgetsBuilderCE---




    //-------Widgets

    module Widgets =
        let register<'T when 'T :> TestViewElement and 'T: (new: unit -> 'T)> () =
            let key = WidgetDefinitionStore.getNextKey()

            let definition =
                { Key = key
                  Name = typeof<'T>.Name
                  TargetType = typeof<'T>
                  CreateView =
                    fun (widget, envContext, treeContext, parentNode) ->
                        // let name = typeof<'T>.Name
                        //                      printfn $"Creating view for {name}"

                        let view = new 'T()
                        let weakReference = WeakReference(view)

                        let parentNode =
                            match parentNode with
                            | ValueNone -> None
                            | ValueSome parent -> Some parent

                        let viewNode = new ViewNode(parentNode, envContext, treeContext, weakReference)

                        view.PropertyBag.Add(ViewNode.ViewNodeProperty, viewNode)

                        let oldWidget: Widget voption = ValueNone

                        Reconciler.update treeContext.CanReuseView oldWidget widget viewNode
                        struct (viewNode :> IViewNode, box view)
                  AttachView = fun (_widget, _envContext, _treeContext, _parentNode, _view) -> failwith "not implemented" }

            WidgetDefinitionStore.set key definition
            key





    //-----MARKERS-----------
    type IMarker = interface end

    type TextMarker =
        inherit IMarker

    type TestLabelMarker =
        inherit TextMarker

    type TestButtonMarker =
        inherit TextMarker

    type TestStackMarker =
        inherit IMarker

    type TestNumericBagMarker =
        inherit IMarker

    //----------------

    /// ------------ Extensions
    [<Extension>]
    type WidgetExtensions() =
        [<Extension>]
        static member inline automationId<'msg, 'marker when 'msg: equality and 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attributes.Automation.AutomationId.WithValue(value))

        [<Extension>]
        static member inline automationId<'msg, 'marker, 'itemMarker when 'msg: equality and 'marker :> IMarker>
            (this: CollectionBuilder<'msg, 'marker, 'itemMarker>, value: string)
            =
            this.AddScalar(Attributes.Automation.AutomationId.WithValue(value))

        [<Extension>]
        static member inline textColor<'msg, 'marker when 'msg: equality and 'marker :> TextMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attributes.TextStyle.TextColor.WithValue(value))


        [<Extension>]
        static member inline record<'msg, 'marker when 'msg: equality and 'marker :> TestLabelMarker>(this: WidgetBuilder<'msg, 'marker>, value: bool) =
            this.AddScalar(Attributes.Text.Record.WithValue(value))


        [<Extension>]
        static member inline tap<'msg, 'marker when 'msg: equality and 'marker :> TestButtonMarker>(this: WidgetBuilder<'msg, 'marker>, value: 'msg) =
            this.AddScalar(Attributes.Button.Tap.WithValue(value))


        [<Extension>]
        static member inline tap2<'msg, 'marker when 'msg: equality and 'marker :> TestButtonMarker>(this: WidgetBuilder<'msg, 'marker>, value: 'msg) =
            this.AddScalar(Attributes.Button.Tap2.WithValue(value))


        [<Extension>]
        static member inline tapContainer<'msg, 'marker when 'msg: equality and 'marker :> TestStackMarker>(this: WidgetBuilder<'msg, 'marker>, value: 'msg) =
            this.AddScalar(Attributes.Container.Tap.WithValue(value))

    ///----------------
    ///----------------

    [<AbstractClass; Sealed>]
    type View private () =
        static let TestLabelKey = Widgets.register<TestLabel>()
        static let TestButtonKey = Widgets.register<TestButton>()
        static let TestStackKey = Widgets.register<TestStack>()
        static let TestNumericBagKey = Widgets.register<TestNumericBag>()

        static member Label(text: string) =
            WidgetBuilder<'msg, TestLabelMarker>(TestLabelKey, Attributes.Text.Text.WithValue(text))


        static member Button(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, TestButtonMarker>(TestButtonKey, Attributes.Text.Text.WithValue(text), Attributes.Button.Pressed.WithValue(onClicked))

        static member BoxedNumericBag(one, two, three) =
            WidgetBuilder<'msg, TestNumericBagMarker>(
                TestNumericBagKey,
                Attributes.NumericBag.BoxedValueOne.WithValue(one),
                Attributes.NumericBag.BoxedValueTwo.WithValue(two),
                Attributes.NumericBag.BoxedValueThree.WithValue(three)
            )

        static member InlineNumericBag(one, two, three) =
            WidgetBuilder<'msg, TestNumericBagMarker>(
                TestNumericBagKey,
                Attributes.NumericBag.InlineValueOne.WithValue(one, (fun x -> x)),
                Attributes.NumericBag.InlineValueTwo.WithValue(two, (fun x -> x)),
                //            Attributes.NumericBag.InlineValueOne.WithValue(one, Attributes.func),
                //            Attributes.NumericBag.InlineValueTwo.WithValue(two, Attributes.func),
                Attributes.NumericBag.InlineValueThree.WithValue(three, BitConverter.DoubleToUInt64Bits)
            )

        static member Stack<'msg, 'marker when 'msg: equality and 'marker :> IMarker>() =
            CollectionBuilder<'msg, TestStackMarker, 'marker>(TestStackKey, StackList.empty(), Attributes.Container.Children)

    [<Extension>]
    type CollectionBuilderExtensions =
        [<Extension>]
        static member inline Yield<'msg, 'marker, 'itemMarker when 'msg: equality and 'itemMarker :> IMarker>
            (_: CollectionBuilder<'msg, 'marker, IMarker>, x: WidgetBuilder<'msg, 'itemMarker>)
            : Content<'msg> =
            CollectionBuilder.yieldImpl x

        [<Extension>]
        static member inline Yield<'msg, 'marker, 'itemMarker when 'msg: equality and 'itemMarker :> IMarker>
            (_: CollectionBuilder<'msg, 'marker, IMarker>, x: WidgetBuilder<'msg, Memo.Memoized<'itemMarker>>)
            : Content<'msg> =
            CollectionBuilder.yieldImpl x

        [<Extension>]
        static member inline YieldFrom<'msg, 'marker, 'itemMarker when 'msg: equality and 'itemMarker :> IMarker>
            (_: CollectionBuilder<'msg, 'marker, IMarker>, x: WidgetBuilder<'msg, 'itemMarker> seq)
            : Content<'msg> =
            // TODO optimize this one with addMut
            { Widgets = x |> Seq.map(fun wb -> wb.Compile()) |> Seq.toArray |> MutStackArray1.fromArray }




    ///------------------
    type StatefulView<'arg, 'model, 'msg, 'marker when 'msg: equality> =
        { Init: 'arg -> 'model
          Update: 'msg -> 'model -> 'model
          View: 'model -> WidgetBuilder<'msg, 'marker> }

    module StatefulWidget =
        let mkSimpleView init update view : StatefulView<_, _, _, _> =
            { Init = init
              Update = update
              View = view }


    module Run =
        type Instance<'arg, 'model, 'msg, 'marker when 'msg: equality>(program: StatefulView<'arg, 'model, 'msg, 'marker>) =
            let mutable state: ('model * obj * Widget) option = None

            let logger = 
                { Log = fun _ -> ()
                  MinLogLevel = LogLevel.Fatal }

            member private x.envContext = new EnvironmentContext(logger)

            member private x.treeContext: ViewTreeContext =
                { CanReuseView = ViewHelpers.canReuseView
                  GetViewNode = ViewNode.getViewNode
                  Logger = logger
                  Dispatch = fun msg -> unbox<'msg> msg |> x.ProcessMessage
                  GetComponent = Component.getComponent
                  SetComponent = Component.setComponent
                  SyncAction = fun fn -> fn() }

            member x.ProcessMessage(msg: 'msg) =
                match state with
                | None -> ()
                | Some(m, target, oldWidget) ->
                    let newModel = program.Update msg m
                    let newWidget = program.View(newModel).Compile()

                    // is it better to have a Kind prop instead
                    // basically we care if it is exactly the same widget type as it was before
                    // TODO support mount + unmount
                    // TODO possibly introduce some notion of a platform/runtime context
                    // that can mount and unmount nodes

                    let viewNode = ViewNode.getViewNode target

                    if newWidget.Key <> oldWidget.Key then
                        failwith "type mismatch!"

                    state <- Some(newModel, target, newWidget)

                    Reconciler.update x.treeContext.CanReuseView (ValueSome oldWidget) newWidget viewNode
                    ()

            member x.Start(arg: 'arg) =
                let model = program.Init(arg)
                let widget = program.View(model).Compile()
                let widgetDef = WidgetDefinitionStore.get widget.Key

                let struct (_node, view) =
                    widgetDef.CreateView(widget, x.envContext, x.treeContext, ValueNone)

                state <- Some(model, view, widget)

                view :?> TestViewElement

//module View =
//    let inline map (fn: 'oldMsg -> 'newMsg) (this: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
//        this.MapMsg fn
