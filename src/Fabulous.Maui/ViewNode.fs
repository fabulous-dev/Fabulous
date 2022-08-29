namespace Fabulous.Maui

open System.Collections.Generic
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Microsoft.Maui

type NodeAttributes() =
    let _widgets = Dictionary<string, obj>()
    let _widgetCollections = Dictionary<string, List<obj>>()
    member val ScalarAttributes: ScalarAttribute [] = [||] with get, set
    member this.Widgets = _widgets
    member this.WidgetCollections = _widgetCollections

type Node() =
    let attributes = NodeAttributes()
    member this.Attributes = attributes
    member val ViewNode: IViewNode = Unchecked.defaultof<IViewNode> with get, set
    member val Parent: IElement = null with get, set
    
    member inline this.TryFindScalar (key: int<scalarAttributeKey>) =
        this.Attributes.ScalarAttributes
        |> Array.tryFind (fun s -> s.Key = key)
    
    member inline this.GetScalar<'T>(def: SmallScalarAttributeDefinition<'T>, [<InlineIfLambda>] decode: uint64 -> 'T, defaultValue: 'T) =
        match this.TryFindScalar(def.Key) with
        | None -> defaultValue
        | Some s -> decode s.NumericValue
        
    member inline this.GetScalar<'T>(def: SimpleScalarAttributeDefinition<'T>, defaultValue: 'T) =
        match this.TryFindScalar(def.Key) with
        | None -> defaultValue
        | Some s -> unbox<'T> s.Value
        
    member inline this.GetScalar<'modelType, 'valueType>(def: ScalarAttributeDefinition<'modelType, 'valueType>, [<InlineIfLambda>] convertValue: 'modelType -> 'valueType, defaultValue: 'valueType) =
        match this.TryFindScalar(def.Key) with
        | None -> defaultValue
        | Some s -> convertValue(unbox<'modelType> s.Value)
        
    member this.GetWidget<'T when 'T: null>(def: WidgetAttributeDefinition) =
        if this.Attributes.Widgets.ContainsKey(def.Name) then
            unbox<'T> this.Attributes.Widgets[def.Name]
        else
            null
            
    member inline this.GetWidgetCollection<'T when 'T: null>(def: WidgetCollectionAttributeDefinition) =
        if this.Attributes.WidgetCollections.ContainsKey(def.Name) then
            this.Attributes.WidgetCollections[def.Name]
        else
            let newList = List<obj>()
            this.Attributes.WidgetCollections[def.Name] <- newList
            newList
        
    member inline this.InvokeEvent(def: SimpleScalarAttributeDefinition<unit -> obj>) =
        match this.TryFindScalar(def.Key) with
        | None -> ()
        | Some s ->
            let fn = unbox<unit -> obj> s.Value
            let msg = fn ()
            Dispatcher.dispatch this.ViewNode msg
        
    member this.InvokeEvent<'args>(def: SimpleScalarAttributeDefinition<'args -> obj>, args: 'args) =
        match this.TryFindScalar(def.Key) with
        | None -> ()
        | Some s ->
            let fn = unbox<'args -> obj> s.Value
            let msg = fn args
            Dispatcher.dispatch this.ViewNode msg

type NodeWithHandler(handler: IElementHandler) =
    inherit Node()
    member val Handler = handler with get, set

module ViewNode =
    let get (target: obj) = (target :?> Node).ViewNode
    let set (value: IViewNode) (target: Node) = target.ViewNode <- value