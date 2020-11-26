// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open System.Collections.Generic

[<AutoOpen>]
module ViewExtensions =
    /// Allows to store any arbitrary value (useful for collection controls returning the ViewElement instead of the selected index)
    let TagAttribKey : AttributeKey<obj> = AttributeKey<_>("Tag")

    // The public API for extensions to define their incremental update logic
    type DynamicViewElement with

        /// Try getting the value stored as a Tag
        member x.TryGetTag<'T>() =
            match x.TryGetAttributeKeyed(TagAttribKey) with
            | ValueNone -> None
            | ValueSome tag -> Some (tag :?> 'T)

        /// Update an event handler on a target control, given a previous and current view element description
        member inline source.UpdateEvent(prevOpt: DynamicViewElement voption, attribKey: AttributeKey<'T>, targetEvent: IEvent<'T,'Args>) =
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<'T>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<'T>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> targetEvent.RemoveHandler(prevValue); targetEvent.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> targetEvent.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> targetEvent.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        /// Update a primitive value on a target control, given a previous and current view element description
        member inline source.UpdatePrimitive(definition: ProgramDefinition, prevOpt: DynamicViewElement voption, target: 'Target, attribKey: AttributeKey<'T>, setter: 'Target -> 'T -> unit, ?defaultValue: 'T) =
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<'T>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<'T>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome newValue when prevValue = newValue -> ()
            | _, ValueSome newValue -> setter target newValue
            | ValueSome _, ValueNone -> setter target (defaultArg defaultValue Unchecked.defaultof<_>)
            | ValueNone, ValueNone -> ()

        /// Recursively update a nested view element on a target control, given a previous and current view element description
        member inline source.UpdateElement(definition: ProgramDefinition, prevOpt: DynamicViewElement voption, target: 'Target, attribKey: AttributeKey<DynamicViewElement>, getter: 'Target -> 'T, setter: 'Target -> 'T -> unit) =
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<DynamicViewElement>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<DynamicViewElement>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when ViewHelpers.canReuseView prevChild newChild ->
                newChild.Update(definition, ValueSome prevChild, getter target)
            | _, ValueSome newChild -> setter target (newChild.Create(definition) :?> 'T)
            | ValueSome _, ValueNone -> setter target null
            | ValueNone, ValueNone -> ()

        /// Recursively update a collection of nested view element on a target control, given a previous and current view element description
        member inline source.UpdateElementCollection(definition: ProgramDefinition, prevOpt: DynamicViewElement voption, attribKey: AttributeKey<seq<DynamicViewElement>>, targetCollection: IList<'T>)  =
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<_>(attribKey)
            let collOpt = source.TryGetAttributeKeyed<_>(attribKey)

            let seqToArray (x: seq<DynamicViewElement> voption) =
                match x with
                | ValueNone -> ValueNone
                | ValueSome xs ->
                    xs
                    |> Seq.map (fun x -> x :> IViewElement)
                    |> Seq.toArray
                    |> ValueSome

            Collections.updateChildren
                definition (seqToArray prevCollOpt) (seqToArray collOpt) targetCollection
                (fun def x -> x.Create(def) :?> 'T) Collections.updateChild (fun _ _ _ _ -> ())
