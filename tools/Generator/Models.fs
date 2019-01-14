// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open System.Collections.Generic
open Helpers

module Models =
    type MemberBinding() =
        /// The name of the property in the target
        member val Name : string = null with get, set
        
        /// A unique name of the property in the model
        member val UniqueName : string = null with get, set

        /// Indicates if the "property" is actually passed as a fixed parameter to the constructor
        member val IsParam : bool = false with get, set

        /// The lowercase name used as a parameter in the API
        member val ShortName : string = null with get, set
        
        /// The input type type of the property as seen in the API
        member val InputType : string = null with get, set 

        /// The default value when applying to the target
        member val DefaultValue : string = null with get, set

        /// Converts the input type to the model type
        member val ConvToModel : string = null with get, set

        /// The expression to convert the model type to the value to be assigned to the property in the target
        member val ConvToValue : string = null with get, set

        /// The full code for incrementally assigning to the property in the target
        member val UpdateCode : string = null with get, set

        /// The type as stored in the model
        member val ModelType : string = null with get, set 

        /// The element type of the collection property
        member val ElementType : string = null with get, set

        /// The attached properties for items in the collection property
        member val Attached : List<MemberBinding> = null with get, set

        member this.BoundUniqueName : string = getValueOrDefault this.Name this.UniqueName

        member this.LowerBoundUniqueName : string = toLowerPascalCase this.BoundUniqueName

        member this.BoundShortName : string = getValueOrDefault this.Name this.ShortName

        member this.LowerBoundShortName : string = toLowerPascalCase this.BoundShortName

    type TypeBinding() = 

        member val Name : string = null with get, set

        member val ModelName : string = null with get, set

        member val CustomType : string = null with get, set

        member val Members: List<MemberBinding> = null with get, set

    type Bindings() = 

        member val Assemblies : List<string> = null with get, set 

        member val Types : List<TypeBinding> = null with get, set 

        member val OutputNamespace : string = null with get, set