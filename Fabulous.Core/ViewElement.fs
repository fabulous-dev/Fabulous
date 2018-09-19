// Copyright 2018 Fabulous contributors. See LICENSE.md for license.

namespace Fabulous.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Diagnostics

[<AutoOpen>]
module internal AttributeKeys = 
    let attribKeys = Dictionary<string,int>()
    let attribNames = Dictionary<int,string>()

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
type ViewElement internal (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribs: KeyValuePair<int,obj>[]) = 
    
    new (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribsBuilder: AttributesBuilder) =
        ViewElement(targetType, create, update, attribsBuilder.Close())

    static member Create (create: (unit -> 'T), update: (ViewElement voption -> ViewElement -> 'T -> unit), attribsBuilder: AttributesBuilder) =
        ViewElement(typeof<'T>, (create >> box), (fun prev curr target -> update prev curr (unbox target)), attribsBuilder.Close())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CreatedAttribKey : AttributeKey<obj -> unit> = AttributeKey<_>("ElementCreated")

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.AttributesKeyed = attribs

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribs |> Array.map (fun kvp -> KeyValuePair(AttributeKey<int>.GetName kvp.Key, kvp.Value))

    /// Get an attribute of the visual element
    member x.TryGetAttributeKeyed<'T>(key: AttributeKey<'T>) = 
        match attribs |> Array.tryFind (fun kvp -> kvp.Key = key.KeyValue) with 
        | Some kvp -> ValueSome(unbox<'T>(kvp.Value)) 
        | None -> ValueNone

    /// Get an attribute of the visual element
    member x.TryGetAttribute<'T>(name: string) = 
        x.TryGetAttributeKeyed<'T>(AttributeKey<'T> name)
 
    /// Apply initial settings to a freshly created visual element
    member x.Update (target: obj) = update ValueNone x target

    /// Differentially update a visual element given the previous settings
    member x.UpdateIncremental(prev: ViewElement, target: obj) = update (ValueSome prev) x target

    /// Differentially update the inherited attributes of a visual element given the previous settings
    member x.UpdateInherited(prevOpt: ViewElement voption, curr: ViewElement, target: obj) = update prevOpt curr target

    /// Create the UI element from the view description
    member x.Create() : obj =
        Debug.WriteLine (sprintf "Create %O" x.TargetType)
        let target = create()
        x.Update(target)
        match x.TryGetAttributeKeyed(ViewElement._CreatedAttribKey) with
        | ValueSome f -> f target
        | ValueNone -> ()
        target

    /// Produce a new visual element with an adjusted attribute
    member __.WithAttribute(key: AttributeKey<'T>, value: 'T) = 
        let n = attribs.Length
        let attribs2 = Array.zeroCreate (n + 1)
        Array.blit attribs 0 attribs2 0 n
        attribs2.[n] <- KeyValuePair(key.KeyValue, box value)
        ViewElement(targetType, create, update, attribs2)

    override x.ToString() = sprintf "%s(...)@%d" x.TargetType.Name (x.GetHashCode())

/// A description of a visual element
and AttributesBuilder (attribCount: int) = 

    let mutable count = 0
    let mutable attribs = Array.zeroCreate<KeyValuePair<int, obj>>(attribCount)    

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member __.Attributes = 
        if isNull attribs then [| |] 
        else attribs |> Array.map (fun kvp -> KeyValuePair(AttributeKey<int>.GetName kvp.Key, kvp.Value))

    /// Get the attributes of the visual element
    member __.Close() : _[] = 
        let res = attribs 
        attribs <- null
        res

    /// Produce a new visual element with an adjusted attribute
    member __.Add(key: AttributeKey<'T>, value: 'T) = 
        if isNull attribs then failwithf "The attribute builder has already been closed"
        if count >= attribs.Length then failwithf "The attribute builder was not large enough for the added attributes, it was given size %d. Did you get the attribute count right?" attribs.Length
        attribs.[count] <- KeyValuePair(key.KeyValue, box value)
        count <- count + 1


