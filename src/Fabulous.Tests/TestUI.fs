module TestUI

open System.Runtime.CompilerServices
open Fabulous

let justValue value = fun () -> value


type IWidget =
    abstract Attributes : Attribute []
    abstract Compile : unit -> Widget

type IWidget<'msg> =
    inherit IWidget

[<Extension>]
type IWidgetExtensions() =
    [<Extension>]
    static member inline AddAttribute(this: ^T :> IWidget, attr: Attribute) =
        let attribs = this.Attributes
        let attribs2 = Array.zeroCreate(attribs.Length + 1)
        Array.blit attribs 0 attribs2 0 attribs.Length
        attribs2.[attribs.Length] <- attr

        let result =
            (^T: (new : Attribute [] -> ^T) attribs2)

        result

type ViewNodeForTests(widget: Widget) =
    member val attributes: Attribute [] = widget.Attributes with get, set
    member val ctx: ViewTreeContext = Unchecked.defaultof<ViewTreeContext> with get, set

    interface IViewNode with
        member x.SetContext c = x.ctx <- c

        member x.ApplyDiff diff =
            x.attributes <- diff.NewAttributes
            UpdateResult.Done

        member x.Attributes = x.attributes
        member x.Origin = widget.Key



module A =
    //    open Fabulous.Attributes

    module Text =
        let Text =
            Attributes.define<string> "Text" (justValue "")

    module TextStyle =
        let TextColor =
            Attributes.define<string> "TextColor" (justValue "")

    module Container =
        let Children =
            Attributes.defineWithComparer<Widget []>
                "Children"
                (justValue [||])
                //                (Seq.map(fun w -> w.Compile()) >> Seq.toArray)
                Attributes.AttributeComparers.alwaysDifferent

    module Button =
        let Clicked =
            // TODO what is the proper way to represent that?
            Attributes.define<obj option> "_Clicked" (justValue None) // TODO fix option


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" (justValue "")

//    module Runtime =
//        let MapMsgFn =
//            Attributes.createDefinition<obj option>
//                "MapMsgFn"
//                None // TODO fix option
//                (fun a b -> Attributes.AttributeComparison.Different None)

//-------Widgets

open Attributes

type TestLabel(widget) =
    inherit ViewNodeForTests(widget)

    member x.Color =
        A.TextStyle.TextColor.GetValue x.attributes

    member x.Text = A.Text.Text.GetValue x.attributes


[<Struct>]
type LabelWidget<'msg>(attributes: Attribute []) =
    static let key = Widgets.register TestLabel

    static member inline Create(text: string) =
        LabelWidget<'msg>([| A.Text.Text.WithValue(text) |])

    interface IWidget<'msg> with
        member x.Compile() = { Key = key; Attributes = attributes }
        member this.Attributes = attributes

[<Extension>]
type LabelWidgetExtensions() =
    [<Extension>]
    static member inline textColor<'msg>(this: LabelWidget<'msg>, value: string) =
        this.AddAttribute(A.TextStyle.TextColor.WithValue(value))

///----------------

type TestButton(widget) =

    inherit ViewNodeForTests(widget)

    member x.Text = A.Text.Text.GetValue x.attributes

    member x.Press() =
        match A.Button.Clicked.GetValue x.attributes with
        | Some msg -> x.ctx.Dispatch msg
        | _ -> ()



[<Struct>]
type ButtonWidget<'msg>(attributes: Attribute []) =
    static let key = Widgets.register TestButton

    interface IWidget<'msg> with
        member x.Compile() = { Key = key; Attributes = attributes }
        member this.Attributes = attributes

    static member inline Create(text: string, clicked: 'msg) =
        ButtonWidget<'msg>
            [|
                A.Text.Text.WithValue(text)
                A.Button.Clicked.WithValue(Some(box clicked))
            |]


[<Extension>]
type ButtonWidgetExtensions() =
    [<Extension>]
    static member inline textColor<'msg>(this: ButtonWidget<'msg>, value: string) =
        this.AddAttribute(A.TextStyle.TextColor.WithValue(value))

///----Stack----
type TestStack(widget) as x =
    inherit ViewNodeForTests(widget)

    let mutable children: IViewNode [] =
        A.Container.Children.GetValue x.attributes
        |> Array.map(fun w -> (WidgetDefinitionStore.get w.Key).CreateView(w))

    interface IViewContainer with
        member this.Children = children
        member this.UpdateChildren(upd) = children <- upd.ChildrenAfterUpdate

    interface IViewNode with
        member this.ApplyDiff(diff) =
            x.attributes <- diff.NewAttributes

            let childrenWidgets =
                A.Container.Children.GetValue x.attributes

            UpdateResult.UpdateChildren struct (this :> IViewContainer, childrenWidgets, x.ctx)

        member x.SetContext ctx =
            x.ctx <- ctx

            for child in children do
                child.SetContext ctx




[<Struct>]
type StackLayoutWidget<'msg>(attributes: Attribute []) =
    static let key = Widgets.register TestStack

    interface IWidget<'msg> with
        member x.Compile() = { Key = key; Attributes = attributes }
        member this.Attributes = attributes

    static member inline Create<'m, 'a when 'a :> seq<IWidget<'m>>>(children: 'a) =
        StackLayoutWidget<'m>(
            [|
                // TODO what is the right type conversion here? Is there one needed at all?
                A.Container.Children.WithValue(
                    children
                    |> Seq.map(fun w -> w.Compile())
                    |> Seq.toArray
                )
            |]
        )

//--------

// TODO handle message mapping

//
//// Note that it is ok it to be not a [<Struct>] because it is not intended to be copied
//type MapDispatchWidget<'msg, 'childMsg>(mapFn: 'childMsg -> 'msg, child: ITypedWidget<'childMsg>) =
//    interface IWidget with
//        member this.Attributes = child.Attributes
//
//        member this.CreateView(ctx) =
//            let dispatch (msg: obj) =
//                ctx.Dispatch(unbox<'childMsg> msg |> mapFn |> box)
//
//            child.CreateView({ ctx with Dispatch = dispatch })
//
//        member this.Source = child.Source
//
//    interface ITypedWidget<'msg>
//
//module Widget =
//    let inline map (fn: 'a -> 'b) (widget: ITypedWidget<'a>) : ITypedWidget<'b> =
//        MapDispatchWidget(fn, widget) :> ITypedWidget<'b>


//----------

[<Extension>]
type SharedExtensions() =
    [<Extension>]
    static member inline automationId(this: #IWidget, value: string) =
        this.AddAttribute(A.Automation.AutomationId.WithValue(value))

    [<Extension>]
    static member inline cast<'msg>(this: IWidget<'msg>) = this


///----------------
[<AbstractClass; Sealed>]
type View private () =
    static member inline Label<'msg>(text) = LabelWidget<'msg>.Create text
    static member inline Button<'msg>(text, msg) = ButtonWidget<'msg>.Create (text, msg)

    static member inline Stack<'m, 'a when 'a :> seq<IWidget<'m>>>(children: 'a) =
        StackLayoutWidget<_>.Create<'m, 'a>(children)

///------------------
type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IWidget> =
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

    let rec traverse (viewNode: IViewNode) test =
        let inline testToOption node = if test node then Some node else None

        // TODO refactor using only containers as special cases
        match viewNode with
        | :? TestButton
        | :? TestLabel -> testToOption viewNode
        | :? TestStack as stack ->
            let children = (stack :> IViewContainer).Children

            let initial = testToOption viewNode

            children
            |> Array.fold(fun res child -> res |> Option.orElse(testToOption child)) initial
        | _ -> None

    type ViewTree =
        {
            FindByAutomationId: string -> IViewNode option
        }

    type Instance<'arg, 'model, 'msg, 'widget when 'widget :> IWidget>
        (
            program: StatefulView<'arg, 'model, 'msg, 'widget>
        ) =
        let mutable state: ('model * IViewNode) option = None

        member private x.viewContext: ViewTreeContext =
            {
                Dispatch = fun msg -> unbox<'msg> msg |> x.ProcessMessage
            }

        member x.ProcessMessage(msg: 'msg) =
            match state with
            | None -> ()
            | Some (m, viewNode) ->
                let newModel = program.Update msg m
                let newWidget = program.View(newModel).Compile()

                // is it better to have a Kind prop instead
                // basically we care if it is exactly the same widget type as it was before
                // TODO support mount + unmount
                // TODO possibly introduce some notion of a platform/runtime context
                // that can mount and unmount nodes
                if newWidget.Key <> viewNode.Origin then
                    failwith "type mismatch!"

                state <- Some(newModel, viewNode)

                Reconciler.update viewNode newWidget.Attributes

                ()

        member x.Start(arg: 'arg) =
            let model = (program.Init(arg))
            let widget = program.View(model).Compile()
            let widgetDef = WidgetDefinitionStore.get widget.Key
            
            let view = widgetDef.CreateView(widget)
            view.SetContext x.viewContext
            state <- Some(model, view)

            {
                FindByAutomationId =
                    (fun id ->
                        traverse
                            view
                            (fun node ->
                                let maybeId =
                                    A.Automation.AutomationId.TryGetValue node.Attributes

                                match maybeId with
                                | Some automationId -> automationId = id
                                | None -> false))
            }
