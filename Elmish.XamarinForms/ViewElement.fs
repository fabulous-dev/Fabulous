namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Diagnostics

/// A description of a visual element
type ViewElement (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribs: KeyValuePair<int,obj>[]) = 
    
    static let attribKeys = Dictionary<string,int>()
    static let attribNames = Dictionary<int,string>()

    static let getAttribKey (attribName: string) = 
        match attribKeys.TryGetValue(attribName) with 
        | true, keyv -> keyv
        | false, _ -> 
            let keyv = attribKeys.Count + 1
            attribKeys.[attribName] <- keyv
            attribNames.[keyv] <- attribName
            keyv

    static let getAttribName (key: int) = 
        match attribNames.TryGetValue(key) with 
        | true, keyv -> keyv
        | false, _ -> failwithf "invalid key %d" key

    new (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribsBuilder: AttributesBuilder) =
        ViewElement(targetType, create, update, attribsBuilder.Close())

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.AttributesKeyed = attribs

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribs |> Array.map (fun kvp -> KeyValuePair(getAttribName kvp.Key, kvp.Value))

    /// Get an attribute of the visual element
    member x.TryGetAttributeKeyed<'T>(key: int) = 
        match attribs |> Array.tryFind (fun kvp -> kvp.Key = key) with 
        | Some kvp -> ValueSome(unbox<'T>(kvp.Value)) 
        | None -> ValueNone

    /// Get an attribute of the visual element
    member x.TryGetAttribute<'T>(name: string) = 
        x.TryGetAttributeKeyed<'T>(getAttribKey name)
 
    /// Apply initial settings to a freshly created visual element
    member x.Update (target: obj) = update ValueNone x target

    /// The differential update method implementation
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.UpdateMethod = update

    /// Differentially update a visual element given the previous settings
    member x.UpdateIncremental(prev: ViewElement, target: obj) = update (ValueSome prev) x target

    /// Update a different description to a similar visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.CreateMethod = create

    /// Create the UI element from the view description
    member x.Create() : obj =
        Debug.WriteLine (sprintf "Create %O" x.TargetType)
        let target = x.CreateMethod()
        x.Update(target)
        target

    /// Produce a new visual element with an adjusted attribute
    member x.WithAttributeKeyed(key: int, value: obj) = 
        let n = attribs.Length
        let attribs2 = Array.zeroCreate (n + 1)
        Array.blit attribs 0 attribs2 0 n
        attribs2.[n] <- KeyValuePair(key, value)
        ViewElement(targetType, create, update, attribs2)

    /// Produce a new visual element with an adjusted attribute
    member x.WithAttribute(attribName: string, attribValue: obj) = 
        x.WithAttributeKeyed(getAttribKey attribName, attribValue)

    override x.ToString() = sprintf "%s(...)@%d" x.TargetType.Name (x.GetHashCode())

    static member GetKey (attribName: string) = getAttribKey attribName
    static member GetAttributeName (key: int) = getAttribName key

/// A description of a visual element
and AttributesBuilder (attribCount: int) = 

    let mutable count = 0
    let mutable attribs = Array.zeroCreate<KeyValuePair<int, obj>>(attribCount)    

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = 
        if isNull attribs then [| |] 
        else attribs |> Array.map (fun kvp -> KeyValuePair(ViewElement.GetAttributeName kvp.Key, kvp.Value))

    /// Get the attributes of the visual element
    member x.Close() : _[] = 
        let res = attribs 
        attribs <- null
        res

    /// Produce a new visual element with an adjusted attribute
    member x.AddKeyed(key: int, value: obj) = 
        if isNull attribs then failwithf "The attribute builder has already been closed"
        if count >= attribs.Length then failwithf "The attribute builder was not large enough for the added attributes, it was given size %d. Did you get the attribute count right?" attribs.Length
        attribs.[count] <- KeyValuePair(key, value)
        count <- count + 1

    /// Produce a new visual element with an adjusted attribute
    member x.Add(attribName: string, attribValue: obj) = 
        x.AddKeyed(ViewElement.GetKey attribName, attribValue)

