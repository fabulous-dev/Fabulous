namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder.Models

module Expander =
    let private tryFindTypeInBindings (types: TypeBinding[]) typeFullName =
        types |> Array.tryFind (fun t2 -> t2.Type = typeFullName)
        
    let private getMembers (types: TypeBinding[]) (getMemberBindings: TypeBinding -> 'a array) (setInherited: 'a -> 'a) (hierarchy: string[]) =
        [ for typ in hierarchy do
              match tryFindTypeInBindings types typ with
              | None -> ()
              | Some t ->
                  let members = getMemberBindings t |> Array.map setInherited
                  for m in members do
                      yield m ]
        |> List.toArray
    
    let expandType (readerDataTypes: TypeReaderData[]) (types: TypeBinding[]) (``type``: TypeBinding) =
        let readerDataType = readerDataTypes |> Array.find (fun t -> t.Name = ``type``.Type)
        let hierarchy = readerDataType.InheritanceHierarchy
        let allBaseAttachedProperties = hierarchy |> getMembers types (fun t -> t.AttachedProperties) (fun a -> { a with IsInherited = true })
        let allBaseEvents = hierarchy |> getMembers types (fun t -> t.Events) (fun e -> { e with IsInherited = true })
        let allBaseProperties = hierarchy |> getMembers types (fun t -> t.Properties) (fun p -> { p with IsInherited = true })
        
        { ``type`` with
            AttachedProperties = Array.concat [ ``type``.AttachedProperties; allBaseAttachedProperties ]
            Events = Array.concat [ ``type``.Events; allBaseEvents ]
            Properties = Array.concat [ ``type``.Properties; allBaseProperties ] }
    
    let expand (readerDataTypes: TypeReaderData[]) (bindings: Bindings): Bindings =
        { bindings with
            Types = bindings.Types |> Array.map (expandType readerDataTypes bindings.Types) }

