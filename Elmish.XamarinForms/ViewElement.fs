namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Diagnostics

/// A description of a visual element
[<AllowNullLiteral>]
type ViewElement (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribs: KeyValuePair<int, obj>[] ) = 
    
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

    /// Create a new ViewElement
    new (targetType: Type, create: (unit -> obj), update: (ViewElement voption -> ViewElement -> obj -> unit), attribs: KeyValuePair<string, obj>[]) =
        let attribs = attribs |> Array.map (fun (KeyValue(attribName, v)) -> KeyValuePair(getAttribKey attribName, v))
        ViewElement(targetType, create, update, attribs)

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.AttributesKeyed = attribs

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = 
        attribs |> Array.map (fun (KeyValue(key, v)) -> (getAttribName key, v))

    /// Get an attribute of the visual element
    member x.TryGetAttributeKeyed<'T>(key: int) = 
        match attribs |> Array.tryFind (fun (KeyValue(key2, v)) -> key2 = key) with 
        | Some v -> ValueSome(unbox<'T>(v)) 
        | None -> ValueNone

    /// Get an attribute of the visual element
    member x.TryGetAttribute<'T>(name: string) = 
        x.TryGetAttributeKeyed (getAttribKey name)
 
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
