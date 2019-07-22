namespace Fabulous.CodeGen.AssemblyReader

module Converters =
    let convertTypeName typeName =
        match typeName with
        | "System.Int32" -> "int"
        | "System.Double" -> "float"
        | "System.String" -> "string"
        | "System.Boolean" -> "bool"
        | "System.UInt32" -> "uint32"
        | "System.Object" -> "object"
        | _ -> typeName
        
    let getStringRepresentationOfDefaultValue (defaultValue: obj) =
        defaultValue.ToString()