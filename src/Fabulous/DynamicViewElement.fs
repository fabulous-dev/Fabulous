// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System
open System.Collections.Generic

[<AutoOpen>]
module internal AttributeKeys =
    let attribKeys = Dictionary<string,int>()
    let attribNames = Dictionary<int,string>()

/// Represent an attribute key.
/// Instead of referring to a property/event of a control by its name (string), we refer to it by a key (int)
/// This reduces the memory footprint
[<Struct>]
type AttributeKey<'T> internal (keyv: int) =

    static let getAttribKeyValue (attribName: string) : int =
        match attribKeys.TryGetValue(attribName) with
        | true, keyv -> keyv
        | false, _ ->
            let keyv = attribKeys.Count + 1
            attribKeys.[attribName] <- keyv
            attribNames.[keyv] <- attribName
            keyv

    new (keyName: string) = AttributeKey<'T>(getAttribKeyValue keyName)

    member __.KeyValue = keyv

    member __.Name = AttributeKey<'T>.GetName(keyv)

    static member GetName(keyv: int) =
        match attribNames.TryGetValue(keyv) with
        | true, keyv -> keyv
        | false, _ -> failwithf "unregistered attribute key %d" keyv

/// A description of a visual element
type AttributesBuilder () =
    let mutable attribs : KeyValuePair<int, obj> list = []

    /// Get the attributes of the visual element
    member __.Close() =
        let res = attribs
        attribs <- []
        res

    /// Produce a new visual element with an adjusted attribute
    member __.Add(key: AttributeKey<'T>, value: 'T) =
        attribs <- KeyValuePair(key.KeyValue, box value) :: attribs

/// Hold the registration of all DynamicViewElement handlers
[<Sealed; AbstractClass>]
type Registrar private () =
    static let handlers = Dictionary<int, DynamicViewElementHandler>()
    static let keys = Dictionary<string, int>()

    static let getKeyValue (name: string) : int =
        match keys.TryGetValue(name) with
        | true, keyv -> keyv
        | false, _ ->
            let keyv = keys.Count + 1
            keys.[name] <- keyv
            keyv

    static member GetHandler(keyv: int) =
        handlers.[keyv]

    static member Register
        (
            name: string,
            create: DynamicViewElement -> obj voption -> 'T,
            update: ProgramDefinition -> DynamicViewElement voption -> DynamicViewElement -> 'T -> unit,
            updateAttachedProperties: int -> ProgramDefinition -> IViewElement voption -> IViewElement -> obj -> unit,
            unmount: DynamicViewElement -> 'T -> unit
        ) =
        let key = getKeyValue name
        if handlers.ContainsKey(key) then
            handlers.[key]
        else
            let handler =
                DynamicViewElementHandler(
                    key,
                    typeof<'T>,
                    (fun curr parentOpt -> create curr parentOpt |> box),
                    (fun def prevOpt curr target -> update def prevOpt curr (unbox target)),
                    updateAttachedProperties,
                    (fun curr target -> unmount curr (unbox target))
                )

            handlers.[key] <- handler
            handler

    static member Unregister(keyv: int) =
        if handlers.ContainsKey(keyv) then
            handlers.Remove(keyv) |> ignore

/// Represent an handler for one type of ViewElement
/// An handler has a reference to the TargetType, the Create and Update functions
/// The handler is identified by its key once registered in the Registrar
/// The ViewElement only needs to store that key to access those functions
and [<Struct>] DynamicViewElementHandler
    internal
        (
            key: int,
            targetType: Type,
            create: DynamicViewElement -> obj voption -> obj,
            update: ProgramDefinition -> DynamicViewElement voption -> DynamicViewElement -> obj -> unit,
            updateAttachedProperties: int -> ProgramDefinition -> IViewElement voption -> IViewElement -> obj -> unit,
            unmount: DynamicViewElement -> obj -> unit
        ) =

    member x.Key = key
    member x.TargetType = targetType
    member x.Create(curr, parentOpt) = create curr parentOpt
    member x.Update(definition, prevOpt, curr, target) = update definition prevOpt curr target
    member x.UpdateAttachedProperties(attrKey, definition, prevOpt, curr, target) = updateAttachedProperties attrKey definition prevOpt curr target
    member x.Unmount(curr, target) = unmount curr target

and DynamicViewElement internal (handlerKey: int, attribs: KeyValuePair<int, obj> list) =

    // Recursive search of an attribute by its key.
    // Perf note: This is preferred to Array.tryFind because it avoids capturing the context with a lambda
    let tryFindAttrib key =
        let rec tryFindAttribRec key i =
            if i >= attribs.Length then
                ValueNone
            else
                let kvp = attribs.[i]
                if kvp.Key = key then
                    ValueSome (attribs.[i])
                else
                    tryFindAttribRec key (i + 1)
        tryFindAttribRec key 0

    let tryGetAttributeKeyed (key: AttributeKey<'T>) =
        match tryFindAttrib key.KeyValue with
        | ValueSome kvp -> ValueSome(unbox<'T>(kvp.Value))
        | ValueNone -> ValueNone

    static member val CreatedAttribKey : AttributeKey<obj -> unit> = AttributeKey<_>("Created")
    static member val RefAttribKey : AttributeKey<ViewRef> = AttributeKey<_>("Ref")
    static member val KeyAttribKey : AttributeKey<string> = AttributeKey<_>("Key")

    static member Create(handler: DynamicViewElementHandler, attributesBuilder: AttributesBuilder) =
        DynamicViewElement(handler.Key, attributesBuilder.Close())

    member x.Attributes = attribs
    member x.Handler = Registrar.GetHandler(handlerKey)
    member x.TryKey with get () = tryGetAttributeKeyed DynamicViewElement.KeyAttribKey
    member x.TargetType = x.Handler.TargetType

    /// Get an attribute of the visual element
    member x.TryGetAttributeKeyed<'T>(key: AttributeKey<'T>) =
        tryGetAttributeKeyed key

    /// Get an attribute of the visual element
    member x.TryGetAttribute<'T>(name: string) =
        tryGetAttributeKeyed (AttributeKey<'T> name)

    /// Get an attribute of the visual element
    member x.GetAttributeKeyed<'T>(key: AttributeKey<'T>) =
        match tryFindAttrib key.KeyValue with
        | ValueSome kvp -> unbox<'T>(kvp.Value)
        | ValueNone -> failwithf "Property '%s' does not exist on %s" key.Name x.Handler.TargetType.Name

    member x.Create(definition: ProgramDefinition, parentOpt: obj voption) =
        ProgramTracing.traceDebug definition (sprintf "Create %O" x.Handler.TargetType)

        let target = x.Handler.Create(x, parentOpt)
        x.Update(definition, ValueNone, target)

        match x.TryGetAttributeKeyed(DynamicViewElement.CreatedAttribKey) with
        | ValueSome created -> created target
        | ValueNone -> ()

        target

    member x.Update(definition, prevOpt: DynamicViewElement voption, target) =
        ProgramTracing.traceDebug definition (sprintf "Update %A" x)

        let prevViewRefOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed(DynamicViewElement.RefAttribKey)
        let currViewRefOpt = x.TryGetAttributeKeyed(DynamicViewElement.RefAttribKey)

        // To avoid triggering unwanted events, don't unset if prevOpt = None or ViewRef is the same instance for prev and curr
        match struct (prevViewRefOpt, currViewRefOpt) with
        | struct (ValueSome prevViewRef, ValueSome currViewRef) when Object.ReferenceEquals(prevViewRef, currViewRef) -> ()
        | struct (ValueSome prevViewRef, _) -> prevViewRef.Unset()
        | _ -> ()

        x.Handler.Update(definition, prevOpt, x, target)

        match currViewRefOpt with
        | ValueNone -> ()
        | ValueSome currViewRef -> currViewRef.Set(target)

    member x.UpdateAttachedPropertiesForAttribute<'T>(attributeKey: AttributeKey<'T>, definition, prevOpt, curr, target) =
        ProgramTracing.traceDebug definition (sprintf "Update attached properties of %A.%s" x attributeKey.Name)
        x.Handler.UpdateAttachedProperties(attributeKey.KeyValue, definition, prevOpt, curr, target)

    /// Produce a new visual element with an adjusted attribute
    member __.WithAttribute(key: AttributeKey<'T>, value: 'T) =
        let newAttrib = KeyValuePair(key.KeyValue, box value)
        let attribs = attribs |> List.filter (fun kvp -> kvp.Key <> key.KeyValue)
        DynamicViewElement(handlerKey, newAttrib :: attribs)

    interface IViewElement with
        member x.Create(definition, parentOpt) = x.Create(definition, parentOpt)
        member x.Update(definition, prevOpt, target) =
            let prevOpt =
                match prevOpt with
                | ValueNone -> ValueNone
                | ValueSome prev -> ValueSome (prev :?> DynamicViewElement)
            x.Update(definition, prevOpt, target)
            
        member x.Unmount(target) =
            // Unset the ViewRef if defined
            match x.TryGetAttributeKeyed(DynamicViewElement.RefAttribKey) with
            | ValueNone -> ()
            | ValueSome viewRef -> viewRef.Unset()
            
            // Unmount the handler
            x.Handler.Unmount(x, target)
            
        member x.TryKey with get () = x.TryKey
        member x.TargetType with get () = x.Handler.TargetType

    override x.ToString() = sprintf "%s(...)@%d" x.Handler.TargetType.Name (x.GetHashCode())
