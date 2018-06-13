namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms

[<Struct>]
type ValueOption<'T> = 
    | ValueSome of 'T | ValueNone
    member x.Value = match x with ValueSome v -> v | ValueNone -> failwith "ValueNone has no value"

type voption<'T> = ValueOption<'T>

/// A description of a visual element
[<AllowNullLiteral>]
type XamlElement internal (targetType: Type, create: (unit -> obj), update: (XamlElement voption -> XamlElement -> obj -> unit), attribsMap: Map<string, obj>, attribs: (string * obj)[] ) = 
    
    let mutable attribsArray = attribs

    /// Create a new XamlElement
    new (targetType: Type, create: (unit -> obj), update: (XamlElement voption -> XamlElement -> obj -> unit), attribs: (string * obj)[]) =
        XamlElement(targetType, create, update, Map.ofArray attribs, attribs)

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribsMap

    /// Get an attribute of the visual element
    member inline x.TryGetAttribute<'T>(name: string) = match x.Attributes.TryFind(name) with Some v -> ValueSome(unbox<'T>(v)) | None -> ValueNone

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.AttributesArray = (match attribsArray with null -> Map.toArray attribsMap | arr -> arr)

    /// Apply initial settings to a freshly created visual element
    member x.Update (target: obj) = update ValueNone x target

    /// The differential update method implementation
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.UpdateMethod = update

    /// Differentially update a visual element given the previous settings
    member x.UpdateIncremental(prev: XamlElement, target: obj) = update (ValueSome prev) x target

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
    member x.WithAttribute(name: string, value: obj) = XamlElement(targetType, create, update, attribsMap.Add(name, value), null)

    /// Produce a visual element from a visual element for a different type
    //member x.Inherit(newTargetType, newCreate, newApply, newAttribs) = 
    //    let combinedAttribs = Array.append (Map.toArray attribsMap) newAttribs
    //    XamlElement(newTargetType, newCreate, (fun prevOpt source target -> update prevOpt source target; newApply prevOpt source target), combinedAttribs)

    override x.ToString() = sprintf "%s(...)@%d" x.TargetType.Name (x.GetHashCode())
