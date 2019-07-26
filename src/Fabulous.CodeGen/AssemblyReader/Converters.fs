// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.AssemblyReader

open System

module Converters =
    let convertTypeName typeName =
        match typeName with
        | "System.Boolean" -> "bool"
        | "System.SByte" -> "sbyte"
        | "System.Byte" -> "byte"
        | "System.Int16" -> "int16"
        | "System.UInt16" -> "uint16"
        | "System.Int32" -> "int"
        | "System.UInt32" -> "uint32"
        | "System.Int64" -> "int64"
        | "System.UInt64" -> "uint64"
        | "System.BigInteger" -> "bigint"
        | "System.Double" -> "float"
        | "System.Single" -> "single"
        | "System.Decimal" -> "decimal"
        | "System.String" -> "string"
        | "System.Object" -> "object"
        | "System.Collections.Generic.IList`1[[System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]" -> "obj list"
        | "System.Collections.IList" -> "obj list"
        | _ -> typeName.Replace("+", ".")
        
    let getStringRepresentationOfDefaultValue (defaultValue: obj) =
        match defaultValue with
        | null -> "null"
        | :? bool as b when b = true -> "true"
        | :? bool as b when b = false -> "false"
        | :? sbyte as sbyte -> sbyte.ToString() + "y"
        | :? byte as byte -> byte.ToString() + "uy"
        | :? int16 as int16 -> int16.ToString() + "s"
        | :? uint16 as uint16 -> uint16.ToString() + "us"
        | :? int as int -> int.ToString()
        | :? uint32 as uint32 -> uint32.ToString() + "u"
        | :? int64 as int64 -> int64.ToString() + "L"
        | :? uint64 as uint64 -> uint64.ToString() + "UL"
        | :? bigint as bigint -> bigint.ToString() + "I"
        | :? float as float -> float.ToString()
        | :? double as double -> double.ToString()
        | :? float32 as float32 -> float32.ToString() + "f"
        | :? single as single -> single.ToString() + "m"
        | :? decimal as decimal -> decimal.ToString() + "m"
        | :? DateTime as dateTime when dateTime = DateTime.MinValue -> "System.DateTime.MinValue"
        | :? DateTime as dateTime when dateTime = DateTime.MaxValue -> "System.DateTime.MaxValue"
        | :? DateTime as dateTime -> sprintf "System.DateTime(%i, %i, %i)" dateTime.Year dateTime.Month dateTime.Day
        | :? string as string when string = "" -> "System.String.Empty"
        | _ ->
            let typ = defaultValue.GetType()
            if typ.IsEnum then
                let valueName = Enum.GetName(typ, defaultValue)
                match valueName with
                | null -> sprintf "Unchecked.defaultof<%s>" typ.FullName
                | _ -> sprintf "%s.%s" (typ.FullName.Replace("+", ".")) valueName
            else
                defaultValue.ToString().Replace("+", ".")