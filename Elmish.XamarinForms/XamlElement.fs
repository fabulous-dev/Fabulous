namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms

[<Struct>]
type StructOption<'T> = 
    | USome of 'T | UNone
    member x.Value = match x with USome v -> v | UNone -> failwith "UNone has no value"

type uoption<'T> = StructOption<'T>

/// A description of a visual element
[<AllowNullLiteral>]
type XamlElement(targetType: Type, create: (unit -> obj), update: (XamlElement uoption -> XamlElement -> obj -> unit), attribs: Map<string, obj>) = 

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribs

    /// Apply initial settings to a freshly created visual element
    member x.Update (target: obj) = update UNone x target

    /// The differential update method implementation
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.UpdateMethod = update

    /// Differrentially update a visual element given the previous settings
    member x.UpdateIncremental(prev: XamlElement, target: obj) = 
        //Debug.WriteLine (sprintf "Update %O" x.TargetType)
        update (USome prev) x target

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
    member x.WithAttribute(name: string, value: obj) = XamlElement(targetType, create, update, x.Attributes.Add(name, value))

    /// Produce a visual element from a visual element for a different type
    member x.Inherit(newTargetType, newCreate, newApply, newAttribs) = 
        let combinedAttribs = Map.ofArray(Array.append(Map.toArray attribs) newAttribs)
        XamlElement(newTargetType, newCreate, (fun prevOpt source target -> update prevOpt source target; newApply prevOpt source target), combinedAttribs)

    override x.ToString() = sprintf "%s(...)@%d" x.TargetType.Name (x.GetHashCode())
