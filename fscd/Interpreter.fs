// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
module FSharp.Compiler.PortaCode.Interpreter

open System
open System.Reflection
open System.Collections.Concurrent
open FSharp.Compiler.PortaCode.CodeModel
open FSharp.Reflection

type ResolvedEntity = 
    | REntity of Type 
    | UEntity of DEntityDef

and ResolvedType = 
    | RType of Type 
    | UNamedType of DEntityDef * Type[]

and ResolvedTypes = 
    | RTypes of Type[]
    | UTypes of ResolvedType[]

and ResolvedMember = 
    | RPrim_float
    | RPrim_float32
    | RPrim_double
    | RPrim_single
    | RPrim_int32
    | RPrim_int16 
    | RPrim_int64 
    | RPrim_byte
    | RPrim_uint16
    | RPrim_uint32
    | RPrim_uint64
    | RPrim_decimal
    | RPrim_unativeint
    | RPrim_nativeint
    | RPrim_char
    | RPrim_neg
    | RPrim_pos
    | RPrim_minus
    | RPrim_divide
    | RPrim_mod
    | RPrim_shiftleft
    | RPrim_shiftright
    | RPrim_land
    | RPrim_lor
    | RPrim_lxor
    | RPrim_lneg
    | RPrim_checked_int32
    | RPrim_checked_int
    | RPrim_checked_int16
    | RPrim_checked_int64
    | RPrim_checked_byte
    | RPrim_checked_uint16
    | RPrim_checked_uint32
    | RPrim_checked_uint64
    | RPrim_checked_unativeint
    | RPrim_checked_nativeint
    | RPrim_checked_char
    | RPrim_checked_minus
    | RPrim_checked_mul
    | RMethod of System.Reflection.MemberInfo
    | UMember of Value

and ResolvedUnionCase = 
    | RUnionCase of FSharp.Reflection.UnionCaseInfo * (obj -> int) * (obj[] -> obj) * (obj -> obj[])
    | UUnionCase of int * string

and ResolvedField = 
    | RField of MemberInfo
    | UField of int * ResolvedType * string

and Value = 
   { mutable Value: obj }

// TODO: intercept ToString, comparison
and RecordValue = RecordValue of obj[]
and UnionValue = UnionValue of int * string * obj[]
and MethodLambdaValue = MethodLambdaValue of (Type[] * obj[] -> obj)
and ObjectValue = ObjectValue of Map<string,obj> ref

let (|Value|) (v: Value) = v.Value
let Value (v: obj) = { Value = v }
let getVal (Value v) = v
let bindAll = BindingFlags.Public ||| BindingFlags.NonPublic ||| BindingFlags.Instance ||| BindingFlags.Static
let (|RTypeOrObj|) xR = match xR with RType xV -> xV | _ -> typeof<obj>
let (|RTypesOrObj|) xR = match xR with RTypes xV -> xV | UTypes us -> Array.map (|RTypeOrObj|) us

type Env = 
   { Vals: Map<string, Value>
     Types: Map<string,Type>
     Targets: (DLocalDef[] * DExpr)[]}

let envEmpty = 
    { Vals = Map.empty; Types = Map.empty; Targets = Array.empty }

let bindByName (env: Env) varName value = 
    { env with Vals = env.Vals.Add(varName, value) }

let bind (env: Env) (var: DLocalDef) value = bindByName env var.Name value

let bindMany env vars values  = (env, vars, values) |||> Array.fold2 bind

let bindty (env: Env) (var : DGenericParameterDef) value = 
    { env with Types = env.Types.Add(var.Name, value) }

let inline binOp (argsV: obj[]) i8 i16 i32 i64 u8 u16 u32 u64 f32 f64 d = 
    match argsV.[0] with 
    | (:? int32 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? double as v1) -> match argsV.[1] with (:? double as v2) -> Value (box (f64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? single as v1) -> match argsV.[1] with (:? single as v2) -> Value (box (f32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int64 as v1) -> match argsV.[1] with (:? int64 as v2) -> Value (box (i64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int16 as v1) -> match argsV.[1] with (:? int16 as v2) -> Value (box (i16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? sbyte as v1) -> match argsV.[1] with (:? sbyte as v2) -> Value (box (i8 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint32 as v1) -> match argsV.[1] with (:? uint32 as v2) -> Value (box (u32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint64 as v1) -> match argsV.[1] with (:? uint64 as v2) -> Value (box (u64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint16 as v1) -> match argsV.[1] with (:? uint16 as v2) -> Value (box (u16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? byte as v1) -> match argsV.[1] with (:? byte as v2) -> Value (box (u8 v1 v2)) | _ -> failwith "type match: operator"
    | (:? decimal as v1) -> match argsV.[1] with (:? decimal as v2) -> Value (box (d v1 v2)) | _ -> failwith "type match: operator"
    | _ -> failwith "a construct used a type instantiation of an F# operator that is not yet supported in intepreted F# code"

let inline shiftOp (argsV: obj[]) i8 i16 i32 i64 u8 u16 u32 u64 = 
    match argsV.[0] with 
    | (:? int32 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int64 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int16 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? sbyte as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i8 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint32 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (u32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint64 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (u64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint16 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (u16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? byte as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (u8 v1 v2)) | _ -> failwith "type match: operator"
    | _ -> failwith "a construct used a type instantiation of an F# operator that is not yet supported in intepreted F# code"

let inline logicBinOp (argsV: obj[]) i8 i16 i32 i64 u8 u16 u32 u64 = 
    match argsV.[0] with 
    | (:? int32 as v1) -> match argsV.[1] with (:? int32 as v2) -> Value (box (i32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int64 as v1) -> match argsV.[1] with (:? int64 as v2) -> Value (box (i64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? int16 as v1) -> match argsV.[1] with (:? int16 as v2) -> Value (box (i16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? sbyte as v1) -> match argsV.[1] with (:? sbyte as v2) -> Value (box (i8 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint32 as v1) -> match argsV.[1] with (:? uint32 as v2) -> Value (box (u32 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint64 as v1) -> match argsV.[1] with (:? uint64 as v2) -> Value (box (u64 v1 v2)) | _ -> failwith "type match: operator"
    | (:? uint16 as v1) -> match argsV.[1] with (:? uint16 as v2) -> Value (box (u16 v1 v2)) | _ -> failwith "type match: operator"
    | (:? byte as v1) -> match argsV.[1] with (:? byte as v2) -> Value (box (u8 v1 v2)) | _ -> failwith "type match: operator"
    | _ -> failwith "a construct used a type instantiation of an F# operator that is not yet supported in intepreted F# code"

let inline logicUnOp (argsV: obj[]) i8 i16 i32 i64 u8 u16 u32 u64 = 
    match argsV.[0] with 
    | (:? int32 as v1) -> Value (box (i32 v1))
    | (:? int64 as v1) -> Value (box (i64 v1))
    | (:? int16 as v1) -> Value (box (i16 v1))
    | (:? sbyte as v1) -> Value (box (i8 v1))
    | (:? uint32 as v1) -> Value (box (u32 v1))
    | (:? uint64 as v1) -> Value (box (u64 v1))
    | (:? uint16 as v1) -> Value (box (u16 v1))
    | (:? byte as v1) -> Value (box (u8 v1))
    | _ -> failwith "a construct used a type instantiation of an F# operator that is not yet supported in intepreted F# code"

type EvalContext ()  =
    let members = ConcurrentDictionary<(ResolvedEntity * string * ResolvedTypes),Value>(HashIdentity.Structural)
    let entityResolutions = ConcurrentDictionary<DEntityRef,ResolvedEntity>(HashIdentity.Structural)
    //let unionCaseResolutions = ConcurrentDictionary<(DType * DUnionCaseRef),ResolvedUnionCase>(HashIdentity.Structural)
    //let fieldResolutions = ConcurrentDictionary<(DType * DFieldRef),ResolvedField>(HashIdentity.Structural)
    //let methodResolutions = ConcurrentDictionary<DMemberRef,ResolvedMember>(HashIdentity.Structural)
    let methinfoof q = match q with Quotations.DerivedPatterns.Lambdas(_, Quotations.Patterns.Call(_,minfo,_)) -> minfo.GetGenericMethodDefinition() | _ -> failwith "unexpected"
    let op_double = methinfoof <@ double @> 
    let op_single = methinfoof <@ single @> 
    let op_float = methinfoof <@ float @> 
    let op_float32 = methinfoof <@ float32 @> 
    let op_int32 = methinfoof <@ int32 @> 
    let op_int = methinfoof <@ int @> 
    let op_int16 = methinfoof <@ int16 @> 
    let op_int64 = methinfoof <@ int64 @> 
    let op_byte = methinfoof <@ byte @> 
    let op_uint16 = methinfoof <@ uint16 @> 
    let op_uint32 = methinfoof <@ uint32 @> 
    let op_uint64 = methinfoof <@ uint64 @> 
    let op_decimal = methinfoof <@ decimal @> 
    let op_unativeint = methinfoof <@ unativeint @> 
    let op_nativeint = methinfoof <@ nativeint @> 
    let op_char = methinfoof <@ char @> 
    let op_neg = methinfoof <@ (~-) @> 
    let op_pos = methinfoof <@ (~+) @> 
    let op_minus = methinfoof <@ (-) @> 
    let op_divide = methinfoof <@ (/) @> 
    let op_mod = methinfoof <@ (%) @> 
    let op_shiftleft = methinfoof <@ (<<<) @> 
    let op_shiftright = methinfoof <@ (>>>) @> 
    let op_land = methinfoof <@ (&&&) @> 
    let op_lor = methinfoof <@ (|||) @> 
    let op_lxor = methinfoof <@ (^^^) @> 
    let op_lneg = methinfoof <@ (~~~) @> 

    let op_checked_int32 = methinfoof <@ Operators.Checked.int32 @> 
    let op_checked_int = methinfoof <@ Operators.Checked.int @> 
    let op_checked_int16 = methinfoof <@ Operators.Checked.int16 @> 
    let op_checked_int64 = methinfoof <@ Operators.Checked.int64 @> 
    let op_checked_byte = methinfoof <@ Operators.Checked.byte @> 
    let op_checked_uint16 = methinfoof <@ Operators.Checked.uint16 @> 
    let op_checked_uint32 = methinfoof <@ Operators.Checked.uint32 @> 
    let op_checked_uint64 = methinfoof <@ Operators.Checked.uint64 @> 
    let op_checked_unativeint = methinfoof <@ Operators.Checked.unativeint @> 
    let op_checked_nativeint = methinfoof <@ Operators.Checked.nativeint @> 
    let op_checked_char = methinfoof <@ Operators.Checked.char @> 
    let op_checked_minus = methinfoof <@ Operators.Checked.(-) @> 
    let op_checked_mul = methinfoof <@ Operators.Checked.(*) @> 
(*
 TODO:
            let inline absImpl (x: ^T) : ^T = 
            let inline  acosImpl(x: ^T) : ^T = 
            let inline  asinImpl(x: ^T) : ^T = 
            let inline  atanImpl(x: ^T) : ^T = 
            let inline  atan2Impl(x: ^T) (y: ^T) : 'U = 
            let inline  ceilImpl(x: ^T) : ^T = 
            let inline  expImpl(x: ^T) : ^T = 
            let inline floorImpl (x: ^T) : ^T = 
            let inline truncateImpl (x: ^T) : ^T = 
            let inline roundImpl (x: ^T) : ^T = 
            let inline signImpl (x: ^T) : int = 
            let inline  logImpl(x: ^T) : ^T = 
            let inline  log10Impl(x: ^T) : ^T = 
            let inline  sqrtImpl(x: ^T) : ^U = 
            let inline  cosImpl(x: ^T) : ^T = 
            let inline  coshImpl(x: ^T) : ^T = 
            let inline  sinImpl(x: ^T) : ^T = 
            let inline  sinhImpl(x: ^T) : ^T = 
            let inline  tanImpl(x: ^T) : ^T = 
            let inline  tanhImpl(x: ^T) : ^T = 
            let inline  powImpl (x: ^T) (y: ^U) : ^T = 
*)

    member ctxt.ResolveEntity(entityRef) = 
        match entityResolutions.TryGetValue(entityRef) with 
        | true, v -> v
        | _ -> 
            let (DEntityRef typeName) = entityRef
            let res = 
                match System.Type.GetType(typeName) with 
                | null -> failwithf "couldn't resolve type %A" typeName
                | t -> REntity t
            entityResolutions.[entityRef] <- res
            res

    member ctxt.ResolveTypes(env, tys: DType[]) = 
        let res = tys |> Array.map (fun ty -> ctxt.ResolveType (env, ty))
        if res |> Array.forall (function RType _ -> true | _ -> false) then 
            RTypes (res |> Array.map (function RType x -> x | _ -> failwith "unreachable"))
        else 
            UTypes res

    member ctxt.ResolveType(env, ty: DType) = 
        match ty with 
        | DArrayType(1, elemType) -> 
            match ctxt.ResolveType (env, elemType) with 
            | RTypeOrObj t -> RType (t.MakeArrayType())
        | DArrayType(n, elemType) -> 
            match ctxt.ResolveType (env, elemType) with 
            | RTypeOrObj t -> RType (t.MakeArrayType(n))
        | DNamedType((DEntityRef nm as n), argTypes) -> 
            // FCS TODO: FCS quirk this is a hack to do with the fact that float<1> is being reported as a type by FCS and PortaCode
            if nm.StartsWith "Microsoft.FSharp.Core.float`1" then 
                RType typeof<float>
            elif nm.StartsWith "Microsoft.FSharp.Core.decimal`1" then 
                RType typeof<decimal>
            elif nm.StartsWith "Microsoft.FSharp.Core.float32`1" then 
                RType typeof<float32>
            elif nm.StartsWith "Microsoft.FSharp.Core.int32`1" then 
                RType typeof<int32>
            else 
                let (RTypesOrObj argTypesR) = ctxt.ResolveTypes (env, argTypes)
                match ctxt.ResolveEntity n, argTypesR with 
                | REntity e, [| |] -> RType e
                | REntity e, tys -> RType (e.MakeGenericType(tys))
                | UEntity u1, u2 -> UNamedType (u1, u2)
        | DFunctionType (t1, t2) -> 
            let (RTypeOrObj t1R) = ctxt.ResolveType (env, t1)
            let (RTypeOrObj t2R) = ctxt.ResolveType (env, t2)
            RType (typedefof<int -> int>.MakeGenericType(t1R, t2R))
        | DTupleType(isStruct, argTypes) -> 
            let (RTypesOrObj tys) = ctxt.ResolveTypes (env, argTypes)
            RType (if isStruct then failwith "struct tuple NYI" (* FSharp.Reflection.FSharpType.MakeStructTupleType(Array.ofList tys) *) else FSharp.Reflection.FSharpType.MakeTupleType(tys))
        | DVariableType v -> 
            match env.Types.TryGetValue v with 
            | true, res -> RType res
            | _ -> 
                printfn "variable type %s not found" v
                RType typeof<obj>
        
    member ctxt.ResolveUnionCase(env, unionType, unionCaseRef) = 
        let (DUnionCaseRef unionCaseName) = unionCaseRef
        let unionTypeR = ctxt.ResolveType (env, unionType)

        match unionTypeR with 
        | RType unionTypeV -> 
            let ucases = Reflection.FSharpType.GetUnionCases(unionTypeV, bindAll) 
            let ucase = ucases |> Array.find (fun uc -> uc.Name = unionCaseName)
            let make = FSharpValue.PreComputeUnionConstructor(ucase, bindAll)
            let tag = FSharpValue.PreComputeUnionTagReader(unionTypeV, bindAll)
            let get = FSharpValue.PreComputeUnionReader(ucase, bindAll)
            RUnionCase (ucase, tag, make, get)
        | UNamedType (unionTypeDef, _) -> 
            let tag = unionTypeDef.UnionCases |> Array.findIndex (fun x -> x = unionCaseName)
            UUnionCase (tag, unionCaseName)

    member ctxt.ResolveField(env, classOrRecordType,fieldRef) = 
        let (DFieldRef (index, fieldName)) = fieldRef
        let classOrRecordTypeR = ctxt.ResolveType(env, classOrRecordType)

        match classOrRecordTypeR with 
        | RType classOrRecordTypeV -> 
            match classOrRecordTypeV.GetField(fieldName, bindAll) with 
            | null -> 
                match classOrRecordTypeV.GetProperty(fieldName, bindAll) with 
                | null -> failwithf "couldn't find field %s in type %A" fieldName classOrRecordType
                | pinfo -> RField pinfo
            | finfo -> RField finfo
        | ty -> 
            UField (index, ty, fieldName)

    member ctxt.ResolveILField(env, fieldType, fieldName) =
        let fieldTypeR = ctxt.ResolveType (env, fieldType)

        match fieldTypeR with 
        | RType classOrRecordTypeV -> 
            let field = classOrRecordTypeV.GetField(fieldName, bindAll)
            RField field
        | _ty -> 
            failwithf "unexpected resolve of ILField %s in interpreted type %A" fieldName fieldType

    member ctxt.MakeRMethod(m: MethodInfo) = 
        if m = op_float then RPrim_float
        elif m = op_float32 then RPrim_float32
        elif m = op_double then RPrim_double
        elif m = op_single then RPrim_single
        elif m = op_int32 then RPrim_int32
        elif m = op_int then RPrim_int32
        elif m = op_byte then RPrim_byte
        elif m = op_int16 then RPrim_int16
        elif m = op_int64 then RPrim_int64
        elif m = op_uint16 then RPrim_uint16
        elif m = op_uint32 then RPrim_uint32
        elif m = op_uint64 then RPrim_uint64
        elif m = op_decimal then RPrim_decimal
        elif m = op_unativeint then RPrim_unativeint
        elif m = op_nativeint then RPrim_nativeint
        elif m = op_char then RPrim_char
        elif m = op_neg then RPrim_neg
        elif m = op_pos then RPrim_pos
        elif m = op_minus then RPrim_minus
        elif m = op_divide then RPrim_divide
        elif m = op_mod then RPrim_mod
        elif m = op_shiftleft then RPrim_shiftleft
        elif m = op_shiftright then RPrim_shiftright
        elif m = op_land then RPrim_land
        elif m = op_lor then RPrim_lor
        elif m = op_lxor then RPrim_lxor
        elif m = op_lneg then RPrim_lneg
        elif m = op_checked_int32 then RPrim_checked_int32
        elif m = op_checked_int then RPrim_checked_int
        elif m = op_checked_int16 then RPrim_checked_int16
        elif m = op_checked_int64 then RPrim_checked_int64
        elif m = op_checked_byte then RPrim_checked_byte
        elif m = op_checked_uint16 then RPrim_checked_uint16
        elif m = op_checked_uint32 then RPrim_checked_uint32
        elif m = op_checked_uint64 then RPrim_checked_uint64
        elif m = op_checked_unativeint then RPrim_checked_unativeint
        elif m = op_checked_nativeint then RPrim_checked_nativeint
        elif m = op_checked_char then RPrim_checked_char
        elif m = op_checked_minus then RPrim_checked_minus
        elif m = op_checked_mul then RPrim_checked_mul
        else RMethod m

    member ctxt.InterpMethod(formalEnv, eR, nm, paramTys) = 
        let paramTysR = ctxt.ResolveTypes (formalEnv, paramTys)
        let key = (eR, nm, paramTysR)
        if not (members.ContainsKey(key)) then failwithf "No member found for key %A" key
        let minfo = members.[key]
        UMember minfo

    member ctxt.ResolveMethod(v: DMemberRef) = 
        let (DMemberRef(entity, nm, genericParams, paramTys, _retTy)) = v
        // TODO: create formal type environment to help resolve overloading by type
        let formalEnv = envEmpty 
        match ctxt.ResolveEntity entity with 
        | REntity entityType as eR -> 
            let n = paramTys.Length
            if nm = ".ctor" || nm = ".cctor" then 
                match entityType.GetConstructors(bindAll) |> Array.filter (fun m -> m.Name = nm && m.GetParameters().Length = n) with 
                | [| cinfo |] -> RMethod cinfo
                | _res -> 
                    let (RTypesOrObj paramTysV) = ctxt.ResolveTypes (formalEnv, paramTys)
                    match entityType.GetConstructor(bindAll, null, paramTysV, null) with 
                    | null -> ctxt.InterpMethod(formalEnv, eR, nm, paramTys)
                    | cinfo -> RMethod cinfo
            else
                match entityType.GetMethods(bindAll) |> Array.filter (fun m -> m.Name = nm && m.GetParameters().Length = n) with 
                | [| minfo |] -> ctxt.MakeRMethod minfo
                | [| |] when n = 0 && genericParams = 0 -> 
                    // FCS QUIRK TODO: cleanup FCS and portacode so names of properties are never used
                    match entityType.GetProperty(nm, bindAll) with 
                    | null -> ctxt.InterpMethod(formalEnv, eR, nm, paramTys)
                    | pinfo  -> ctxt.MakeRMethod pinfo.GetMethod
                | _res -> 
                    let (RTypesOrObj paramTysV) = ctxt.ResolveTypes (formalEnv, paramTys)
                    match entityType.GetMethod(nm, bindAll, null, paramTysV, null) with 
                    | null -> ctxt.InterpMethod(formalEnv, eR, nm, paramTys)
                    | minfo -> RMethod minfo
        | eR -> 
            ctxt.InterpMethod(formalEnv, eR, nm, paramTys)
        
    member ctxt.AddDecls(decls: DDecl[]) = 
        
        let env = envEmpty
        for decl in decls do
            match decl with 
            | DDeclEntity (entityDef, subDecls) -> 
                let entityName = entityDef.Name
                // Override any existing resolution
                entityResolutions.[DEntityRef entityName] <- UEntity entityDef
                ctxt.AddDecls(subDecls)
            | DDeclMember (membDef, _body) when membDef.Parameters.Length = 0 && membDef.GenericParameters.Length = 0 -> ()
            | DDeclMember (membDef, body) -> 
                let ty = ctxt.ResolveEntity(membDef.EnclosingEntity)
                let paramTypes = membDef.Parameters |> Array.map (fun p -> p.Type)
                let paramTypesR = ctxt.ResolveTypes(env, paramTypes)
                let thunk = ctxt.EvalMethodLambda (envEmpty, (membDef.Name = ".ctor"), membDef.IsInstance, membDef.GenericParameters, membDef.Parameters, body)
                members.[(ty, membDef.Name, paramTypesR)] <-  Value thunk
            | _ -> ()

    member ctxt.EvalMethodLambda(env, isCtor, isInstance, typeParameters, parameters: DLocalDef[], body) = 
        MethodLambdaValue
          (FuncConvert.FromFunc<Type[] * obj[],obj>(fun (tyargs, args) -> 
            if parameters.Length + (if isInstance then 1 else 0) <> args.Length then failwithf "arg/parameter mismatch for method with arguments %A" parameters
            let env = if isInstance then bindByName env "$this" (Value args.[0]) else env
            let env = (env, parameters, (if isInstance then args.[1..] else args)) |||> Array.fold2 (fun env p a -> bind env p (Value a))
            let env = (env, typeParameters, tyargs) |||> Array.fold2 (fun env p a -> bindty env p a)
            if isCtor then 
                let objV = ObjectValue (ref Map.empty)
                let env = bindByName env "$this" (Value objV) 
                ctxt.EvalExpr(env, body) |> ignore
                box objV
            else  
                let retV = ctxt.EvalExpr(env, body) |> getVal
                box retV))

    member ctxt.EvalDecls(env, decls: DDecl[]) = 
        for d in decls do
            match d with 
            | DDeclEntity (_e, subDecls) -> ctxt.EvalDecls(env, subDecls)
            | DDeclMember (membDef, body) when membDef.Parameters.Length = 0 && membDef.GenericParameters.Length = 0 -> 
                let ty = ctxt.ResolveEntity(membDef.EnclosingEntity)
                let res = ctxt.EvalExpr (env, body)
                members.[(ty, membDef.Name, RTypes [| |])] <- res
            | DDeclMember _-> 
                ()
            | DDecl.InitAction expr -> 
                ctxt.EvalExpr (env, expr) |> ignore

    member ctxt.GetExprDeclResult(ty, memberName) = 
        members.[(ty, memberName, RTypes [| |])]

    member ctxt.EvalExpr(env, expr: DExpr) : Value = 
        match expr with 
        | DExpr.Application(funcExpr, typeArgs, argExprs) -> ctxt.EvalApplication(env, funcExpr, typeArgs, argExprs)
        | DExpr.Call(objExprOpt, memberOrFunc, typeArgs1, typeArgs2, argExprs) -> ctxt.EvalCall(env, objExprOpt, memberOrFunc, typeArgs1, typeArgs2, argExprs)
        | DExpr.Coerce(_targetType, inpExpr) -> ctxt.EvalExpr(env, inpExpr)
        | DExpr.Lambda(domainTy, rangeTy, lambdaVar, bodyExpr) -> ctxt.EvalLambda(env, domainTy, rangeTy, lambdaVar, bodyExpr)
        | DExpr.TypeLambda(genericParams, bodyExpr) -> ctxt.EvalTypeLambda(env, genericParams, bodyExpr)
        | DExpr.Let((bindingVar, bindingExpr), bodyExpr) -> ctxt.EvalLet(env, (bindingVar, bindingExpr), bodyExpr)
        | DExpr.LetRec(recursiveBindings, bodyExpr) -> ctxt.EvalLetRec(env, recursiveBindings, bodyExpr)
        | DExpr.NewObject(objCtor, typeArgs, argExprs) -> ctxt.EvalNewObject(env, objCtor, typeArgs, argExprs)
        | DExpr.NewRecord(recordType, argExprs) ->  ctxt.EvalNewRecord(env, recordType, argExprs)
        | DExpr.NewUnionCase(unionType, unionCase, argExprs) -> ctxt.EvalNewUnionCase(env, unionType, unionCase, argExprs)
        | DExpr.FSharpFieldGet(objExprOpt, recordOrClassType, fieldInfo) -> ctxt.EvalFieldGet(env, objExprOpt, recordOrClassType, fieldInfo)
        | DExpr.FSharpFieldSet(objExprOpt, recordOrClassType, fieldInfo, argExpr) -> ctxt.EvalFieldSet(env, objExprOpt, recordOrClassType, fieldInfo, argExpr)
        | DExpr.ILFieldGet(objExprOpt, fieldType, fieldName) -> ctxt.EvalILFieldGet(env, objExprOpt, fieldType, fieldName)
        | DExpr.NewTuple(tupleType, argExprs) -> ctxt.EvalNewTuple(env, tupleType, argExprs)
        | DExpr.DecisionTree(decisionExpr, decisionTargets) -> ctxt.EvalDecisionTree(env, decisionExpr, decisionTargets) 
        | DExpr.DecisionTreeSuccess(decisionTargetIdx, decisionTargetExprs) -> ctxt.EvalDecisionTreeSuccess(env, decisionTargetIdx, decisionTargetExprs) 
        | DExpr.Sequential(firstExpr, secondExpr) -> ctxt.EvalSequential(env, firstExpr, secondExpr)
        | DExpr.NewArray(arrayType, argExprs) -> ctxt.EvalNewArray(env, arrayType, argExprs)
        | DExpr.IfThenElse (guardExpr, thenExpr, elseExpr) -> ctxt.EvalIfThenElse (env, guardExpr, thenExpr, elseExpr)
        | DExpr.TryFinally(bodyExpr, finallyExpr) -> ctxt.EvalTryFinally(env, bodyExpr, finallyExpr)
        | DExpr.TupleGet(_tupleType, tupleElemIndex, tupleExpr) -> ctxt.EvalTupleGet(env, tupleElemIndex, tupleExpr)
        | DExpr.TryWith(bodyExpr, filterVar, filterExpr, catchVar, catchExpr) -> ctxt.EvalTryWith(env, bodyExpr, filterVar, filterExpr, catchVar, catchExpr)
        | DExpr.WhileLoop(guardExpr, bodyExpr) -> ctxt.EvalWhileLoop(env, guardExpr, bodyExpr)
        | DExpr.UnionCaseTest(unionExpr, unionType, unionCase) -> ctxt.EvalUnionCaseTest(env, unionExpr, unionType, unionCase)
        | DExpr.UnionCaseGet(unionExpr, unionType, unionCase, unionCaseField) -> ctxt.EvalUnionCaseGet(env, unionExpr, unionType, unionCase, unionCaseField)
        | DExpr.UnionCaseTag(unionExpr, unionType) -> ctxt.EvalUnionCaseTag(env, unionExpr, unionType)
        | DExpr.TypeTest(ty, inpExpr) -> ctxt.EvalTypeTest(env, ty, inpExpr)
        //| DExpr.FastIntegerForLoop(startExpr, limitExpr, consumeExpr, isUp) -> ctxt.EvalFastIntegerForLoop(env, startExpr, limitExpr, consumeExpr, isUp)
(*
// TODO:
        | DExpr.AddressOf(lvalueExpr) -> ctxt.EvalAddressOf(convExpr lvalueExpr)
        | DExpr.AddressSet(lvalueExpr, rvalueExpr) -> ctxt.EvalAddressSet(convExpr lvalueExpr, convExpr rvalueExpr)
        | DExpr.NewDelegate(delegateType, delegateBodyExpr) -> ctxt.EvalNewDelegate(convType delegateType, convExpr delegateBodyExpr)
        | DExpr.Quote(quotedExpr) -> ctxt.EvalQuote(convExpr quotedExpr)
        | DExpr.DefaultValue defaultType -> ctxt.EvalDefaultValue (convType defaultType)

        // Not really possible:
        | DExpr.ObjectExpr(objType, baseCallExpr, overrides, interfaceImplementations) -> ctxt.EvalObjectExpr(convType objType, convExpr baseCallExpr, List.map convObjMember overrides, List.map (map2 convType (List.map convObjMember)) interfaceImplementations)

        // Not needed:
        | DExpr.TraitCall(sourceTypes, traitName, typeArgs, typeInstantiation, argTypes, argExprs) -> ctxt.EvalTraitCall(sourceTypes, traitName, typeArgs, typeInstantiation, argTypes, argExprs)
        | DExpr.UnionCaseSet(unionExpr, unionType, unionCase, unionCaseField, valueExpr) -> ctxt.EvalUnionCaseSet(convExpr unionExpr, convType unionType, convUnionCase unionCase, convField unionCaseField, convExpr valueExpr)
        | DExpr.ILAsm(asmCode, typeArgs, argExprs) -> ctxt.EvalILAsm(asmCode, convTypes typeArgs, convExprs argExprs)
        | DExpr.ILFieldSet (objExprOpt, fieldType, fieldName, valueExpr) -> ctxt.EvalILFieldSet (convExprOpt objExprOpt, convType fieldType, fieldName, convExpr valueExpr)
*)
        | DExpr.BaseValue _thisType 
        | DExpr.ThisValue _thisType -> 
            match env.Vals.TryGetValue "$this" with 
            | true, res -> res
            | _ -> failwithf "didn't find this value in the environment" 

        | DExpr.Value(DLocalRef (v, isThisValue, isMutable)) ->
            if isThisValue then 
                match env.Vals.TryGetValue "$this" with 
                | true, res -> res
                | _ -> failwithf "didn't find this value in the environment" 
            elif isMutable then 
                match env.Vals.TryGetValue v with 
                | true, rv -> Value rv.Value
                | _ -> failwithf "didn't find mutable value in the environment" 
            else
                match env.Vals.TryGetValue v with 
                | true, res -> res
                | _ -> failwithf "didn't find value '%s' in the environment" v

        | DExpr.ValueSet(DLocalRef (valToSet, _, _), valueExpr) -> 
            let valueExprV : obj = ctxt.EvalExpr(env, valueExpr) |> getVal
            match env.Vals.TryGetValue valToSet with 
            | true, Value (:? ref<obj> as rv) -> 
                rv := valueExprV
                Value null
            | _ -> failwithf "didn't find mutable value in the environment" 

        | DExpr.Const(constValueObj, _constType) -> 
            Value constValueObj
        | _ -> failwithf "unrecognized %+A" expr

    member ctxt.EvalExprs(env, argExprs) =
        let argsV =  argExprs |> Array.map (fun argExpr -> ctxt.EvalExpr(env, argExpr))
        argsV |> Array.map getVal

    member ctxt.EvalExprOpt(env, objExprOpt) =
        let objValOpt = objExprOpt |> Option.map (fun objExpr -> ctxt.EvalExpr(env, objExpr))
        objValOpt |> Option.map getVal |> Option.toObj

    member ctxt.EvalNewObject(env, objCtor, typeArgs, argExprs) =
        let argsV = ctxt.EvalExprs(env, argExprs)
        let typeArgsR = ctxt.ResolveTypes (env, typeArgs)
        let methR = ctxt.ResolveMethod (objCtor)

        match methR, typeArgsR with 
        | RMethod (:? ConstructorInfo as cinfo), RTypesOrObj typeArgsV -> 
            let icinfo = 
                if cinfo.DeclaringType.IsGenericType then 
                    let tinfo = cinfo.DeclaringType.MakeGenericType(typeArgsV)
                    tinfo.GetConstructors(bindAll) |> Array.find (fun cinfo2 -> cinfo2.MetadataToken = cinfo.MetadataToken)
                else cinfo
            try icinfo.Invoke(argsV) |> Value
            with :? TargetInvocationException as e -> 
                raise e.InnerException

        | UMember (Value (:? MethodLambdaValue as fM )), RTypesOrObj typeArgsV -> 
            let (MethodLambdaValue f) = fM
            f (typeArgsV, argsV) |> Value
        | _ -> 
            failwithf "unexpected constructor %A at types %A" methR typeArgsR

    member ctxt.EvalApplication(env, funcExpr, typeArgs, argExprs) =
        let funcV =  ctxt.EvalExpr(env, funcExpr)
        let funcV = 
            if typeArgs.Length > 0 then 
               let (RTypesOrObj typeArgsR) = ctxt.ResolveTypes (env, typeArgs)
               match getVal funcV with   
               | :? (Type[] -> obj) as f ->  Value (f typeArgsR)
               | t -> failwithf "unexpected value '%A' of type '%A' when evaluating type application" t (t.GetType())
            else
                funcV
        if argExprs.Length = 0 then 
            funcV
        else
            let argsV = ctxt.EvalExprs(env, argExprs)
            ctxt.EvalApplicationOfArg(env, funcV, argsV)

    member ctxt.EvalApplicationOfArg(env, funcV, argsV) =
        match getVal funcV, argsV with 
        | :? (obj -> obj) as f, [| obj |] -> f obj |> Value
        | f, _ -> 
            if argsV.Length = 0 then 
                failwithf "unexpected empty arguments in application of %A"  f 
            else
                let t = f.GetType()
                let i = 
                    match t.GetMethods(bindAll) |> Array.tryFind (fun m -> m.Name = "Invoke" && m.GetParameters().Length = 1) with 
                    | None -> failwithf "failed to find 'Invoke' method taking one argument on type %A" t
                    | Some res -> res
                let res = 
                    try i.Invoke(f, [| argsV.[0] |]) |> Value
                    with :? TargetInvocationException as e -> 
                        raise e.InnerException
                if argsV.Length > 1 then 
                    ctxt.EvalApplicationOfArg(env, res, argsV.[1..])
                else
                    res

    member ctxt.EvalLet(env, (bindingVar, bindingExpr), bodyExpr) =
        let bindingExprV = ctxt.EvalExpr(env, bindingExpr)
        let env = bind env bindingVar bindingExprV
        ctxt.EvalExpr (env, bodyExpr)

    member ctxt.EvalLetRec(env, recursiveBindings, bodyExpr) =
        let valueThunks = recursiveBindings |> Array.map (fun _ -> { Value = null })
        let envInner = bindMany env (Array.map fst recursiveBindings) valueThunks
        (valueThunks, recursiveBindings) ||> Array.iter2 (fun valueThunk (_,recursiveBindingExpr) -> 
            let v = ctxt.EvalExpr(env, recursiveBindingExpr) |> getVal 
            valueThunk.Value <- v)
        ctxt.EvalExpr (envInner, bodyExpr)

    member ctxt.EvalCall(env, objExprOpt, memberOrFunc, typeArgs1, typeArgs2, argExprs) =
        let objOptV = ctxt.EvalExprOpt (env, objExprOpt)
        let argsV = ctxt.EvalExprs (env, argExprs)
        let methR = ctxt.ResolveMethod (memberOrFunc)

        // These primitives don't have dynamic invocation implementations
        match methR with 
        | RPrim_float -> Value (Convert.ToDouble argsV.[0])
        | RPrim_double -> Value (Convert.ToDouble argsV.[0])
        | RPrim_single -> Value (Convert.ToSingle argsV.[0])
        | RPrim_int32 -> Value (Convert.ToInt32 argsV.[0])
        | RPrim_int16 -> Value (Convert.ToInt16 argsV.[0])
        | RPrim_int64 -> Value (Convert.ToInt64 argsV.[0])
        | RPrim_byte -> Value (Convert.ToByte argsV.[0])
        | RPrim_uint16 -> Value (Convert.ToUInt16 argsV.[0])
        | RPrim_uint32 -> Value (Convert.ToUInt32 argsV.[0])
        | RPrim_uint64 -> Value (Convert.ToUInt64 argsV.[0])
        | RPrim_decimal -> Value (Convert.ToDecimal argsV.[0])
        //| RPrim_unativeint -> Value (Convert.ToUIntPtr argsV.[0])
        //| RPrim_nativeint -> Value (Convert.ToIntPtr argsV.[0])
        | RPrim_char -> Value (Convert.ToChar argsV.[0])
        | RPrim_neg -> Value (match argsV.[0] with :? int32 as v -> -v | _ -> failwith "nyi:neg")
        | RPrim_pos -> Value argsV.[0]
        | RPrim_minus -> binOp argsV (-) (-) (-) (-) (-) (-) (-) (-) (-) (-) (-)
        | RPrim_divide -> binOp argsV (/) (/) (/) (/) (/) (/) (/) (/) (/) (/) (/)
        | RPrim_mod -> binOp argsV (%) (%) (%) (%) (%) (%) (%) (%) (%) (%) (%)
        | RPrim_shiftleft -> shiftOp argsV (<<<) (<<<) (<<<) (<<<) (<<<) (<<<) (<<<) (<<<)
        | RPrim_shiftright -> shiftOp argsV (>>>) (>>>) (>>>) (>>>) (>>>) (>>>) (>>>) (>>>)
        | RPrim_land -> logicBinOp argsV (&&&) (&&&) (&&&) (&&&) (&&&) (&&&) (&&&) (&&&)
        | RPrim_lor -> logicBinOp argsV (|||) (|||) (|||) (|||) (|||) (|||) (|||) (|||)
        | RPrim_lxor -> logicBinOp argsV (^^^) (^^^) (^^^) (^^^) (^^^) (^^^) (^^^) (^^^)
        | RPrim_lneg -> logicUnOp argsV (~~~) (~~~) (~~~) (~~~) (~~~) (~~~) (~~~) (~~~)
        | RPrim_checked_int32 -> Value (Convert.ToInt32 argsV.[0])
        | RPrim_checked_int -> Value (Convert.ToInt32 argsV.[0])
        | RPrim_checked_int16 -> Value (Convert.ToInt16 argsV.[0])
        | RPrim_checked_int64 -> Value (Convert.ToInt64 argsV.[0])
        | RPrim_checked_byte -> Value (Convert.ToByte argsV.[0])
        | RPrim_checked_uint16 -> Value (Convert.ToUInt16 argsV.[0])
        | RPrim_checked_uint32 -> Value (Convert.ToUInt32 argsV.[0])
        | RPrim_checked_uint64 -> Value (Convert.ToUInt64 argsV.[0])
        //| RPrim_checked_unativeint -> Value (Convert.ToUIntPtr argsV.[0])
        //| RPrim_checked_nativeint -> Value (Convert.ToIntPtr argsV.[0])
        | RPrim_checked_char -> Value (Convert.ToChar argsV.[0])
        | RPrim_checked_minus -> binOp argsV Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-) Checked.(-)
        | RPrim_checked_mul -> binOp argsV Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*) Checked.(*)
        | _ ->

        let typeArgs1R = ctxt.ResolveTypes (env, typeArgs1)
        let typeArgs2R = ctxt.ResolveTypes (env, typeArgs2)

        match methR, typeArgs1R, typeArgs2R with 
        | RMethod (:? MethodInfo as minfo), RTypesOrObj typeArgs1V, RTypesOrObj typeArgs2V -> 
            let iminfo = 
                if minfo.DeclaringType.IsGenericType then 
                    let cinfo = minfo.DeclaringType.MakeGenericType(typeArgs1V)
                    match cinfo.GetMethods(bindAll) |> Array.tryFind (fun m -> m.MetadataToken = minfo.MetadataToken) with 
                    | Some minfo2 -> 
                        if minfo.IsGenericMethod then 
                            minfo2.MakeGenericMethod (typeArgs2V)
                        else 
                            minfo2
                    | None -> 
                        failwithf "didn't find a matching method for %A with the right token" minfo
                elif minfo.IsGenericMethod then 
                    minfo.MakeGenericMethod(typeArgs2V) 
                else minfo
            try iminfo.Invoke(objOptV, argsV) |> Value
            with :? TargetInvocationException as e -> 
                raise e.InnerException

        | RMethod (:? ConstructorInfo as cinfo), RTypesOrObj _typeArgs1V, RTypesOrObj _typeArgs2V -> 
            try cinfo.Invoke(argsV) |> Value
            with :? TargetInvocationException as e -> 
                raise e.InnerException

        | UMember (Value (:? MethodLambdaValue as fM )), RTypesOrObj typeArgs1V, RTypesOrObj typeArgs2V -> 
            let (MethodLambdaValue f) = fM
            let callArgsV = (match objOptV with null -> argsV | objV -> Array.append [| objV |] argsV)
            let callTypeArgsV = Array.append typeArgs1V typeArgs2V
            f (callTypeArgsV, callArgsV) |> Value

        | UMember (Value v), RTypes [| |], RTypes [| |] when argExprs.Length = 0 -> 
            v |> Value

        | _ -> 
            failwithf "unexpected member %A at types %A %A" methR typeArgs1R typeArgs2R

    member ctxt.EvalFieldGet(env, objExprOpt, recordOrClassType, fieldInfo) =
        let objOptV = ctxt.EvalExprOpt(env, objExprOpt)
        let fieldR = ctxt.ResolveField (env, recordOrClassType, fieldInfo)

        match fieldR with 
        | RField (:? FieldInfo as finfo) -> finfo.GetValue(objOptV) |> Value
        | RField (:? PropertyInfo as pinfo) -> pinfo.GetValue(objOptV) |> Value
        | RField _ -> failwith "unexpected field resolution"
        | UField (i, _ty, nm) ->
            match objOptV with 
            | :? RecordValue as recdV -> 
                let (RecordValue argsV) = recdV 
                argsV.[i] |> Value

            | :? ObjectValue as objV -> 
                let (ObjectValue argsV) = objV
                match argsV.Value.TryGetValue nm with
                | true, v -> v |> Value
                | _ -> failwithf "field not found: %s" nm

            | _ -> 
                failwithf "unexpected kind of interpreted value %A while getting field %s"  objOptV nm 

    // Note: FieldSet is used even for immutable fields in the case of the compiled form of F# constructors
    member ctxt.EvalFieldSet(env, objExprOpt, recordOrClassType, fieldInfo, argExpr) =
        let objOptV = ctxt.EvalExprOpt(env, objExprOpt)
        let fieldR = ctxt.ResolveField (env, recordOrClassType, fieldInfo)
        let argExprV = ctxt.EvalExpr(env, argExpr) |> getVal

        match fieldR with 
        | RField (:? FieldInfo as finfo) -> finfo.SetValue(objOptV, argExprV)
        | RField (:? PropertyInfo as pinfo) -> pinfo.SetValue(objOptV, argExprV)
        | RField _ -> failwith "unexpected field resolution"
        | UField (i, _ty, nm) ->
            match objOptV with 
            | :? RecordValue as recdV -> 
                let (RecordValue argsV) = recdV 
                argsV.[i] <- argExprV

            | :? ObjectValue as objV -> 
                let (ObjectValue argsV) = objV
                let newArgsV = argsV.Value.Add(nm, argExprV)
                argsV.Value <- newArgsV

            | _ -> failwithf "unexpected kind of interpreted value %A while setting field %s"  objOptV nm 

        Value null

    member ctxt.EvalILFieldGet(env, objExprOpt, recordOrClassType, fieldInfo) =
        let objOptV = ctxt.EvalExprOpt(env, objExprOpt)
        let fieldR = ctxt.ResolveILField (env, recordOrClassType, fieldInfo)

        match fieldR with 
        | RField (:? FieldInfo as finfo) -> finfo.GetValue(objOptV) |> Value
        | RField (:? PropertyInfo as pinfo) -> pinfo.GetValue(objOptV) |> Value
        | RField _ -> failwith "unexpected field resolution"
        | UField (_i, _ty, nm) -> failwithf "unexpected ILFieldGet %s in interpreted type %A" nm recordOrClassType

    member ctxt.EvalLambda(env, domainType, rangeType, lambdaVar, bodyExpr) =
        let domainTypeR = ctxt.ResolveType (env, domainType)
        let rangeTypeR = ctxt.ResolveType (env, rangeType)
        match domainTypeR, rangeTypeR with 
        | RTypeOrObj domainTypeV, RTypeOrObj rangeTypeV -> 
            let funcTypeV = typedefof<int -> int>.MakeGenericType(domainTypeV, rangeTypeV)
            FSharp.Reflection.FSharpValue.MakeFunction(funcTypeV, (fun (arg: obj) -> 
                let env = bind env lambdaVar (Value arg)
                ctxt.EvalExpr(env, bodyExpr) |> getVal)) |> box |> Value

    member ctxt.EvalTypeLambda(env, genericParams, bodyExpr) =
        (fun (typeArgs: Type[]) -> 
            let env = (env, genericParams, typeArgs) |||> Array.fold2 (fun env p a -> bindty env p a)
            ctxt.EvalExpr(env, bodyExpr) |> getVal) 
        |> box |> Value

    member ctxt.EvalNewArray(env, arrayType, argExprs) =
        let arrayTypeR = ctxt.ResolveType (env, arrayType)
        let argsV = ctxt.EvalExprs(env, argExprs)

        match arrayTypeR with 
        | RType arrayTypeV -> 
            let arr = Array.CreateInstance(arrayTypeV, argsV.Length)
            argsV |> Array.iteri (fun i argV -> arr.SetValue(argV, i))
            Value arr
        | _ -> 
            failwithf "unexpected failure to resolve array type %A" arrayType

    member ctxt.EvalNewRecord(env, recordType, argExprs) =
        let recordTypeR = ctxt.ResolveType (env, recordType)
        let argsV = ctxt.EvalExprs(env, argExprs)

        match recordTypeR with 
        | RType recordTypeV -> 
            Reflection.FSharpValue.MakeRecord(recordTypeV, argsV, bindAll) |> Value
        | _ -> 
            let recdV = RecordValue argsV
            Value recdV

    member ctxt.EvalNewUnionCase(env, unionType, unionCase, argExprs) =
        let unionCaseR = ctxt.ResolveUnionCase (env, unionType, unionCase)
        let argsV = ctxt.EvalExprs (env, argExprs)

        match unionCaseR with 
        | RUnionCase (_ucase, _tag, make, _get) -> make argsV |> Value
        | UUnionCase (tag, unionCaseName) -> 
            let unionV = UnionValue(tag, unionCaseName, argsV)
            unionV |> box |> Value

    member ctxt.EvalNewTuple(env, tupleType, argExprs) =
        let tupleTypeR = ctxt.ResolveType (env, tupleType)
        let argsV = ctxt.EvalExprs (env, argExprs)

        match tupleTypeR with 
        | RType t -> Reflection.FSharpValue.MakeTuple(argsV, t) |> Value
        | _ -> failwith "unresolve tuple type"

    member ctxt.EvalDecisionTree(env, decisionExpr, decisionTargets) =
        let env = { env with Targets = decisionTargets }
        ctxt.EvalExpr (env, decisionExpr)
        
    member ctxt.EvalDecisionTreeSuccess(env, decisionTargetIdx, decisionTargetExprs) =
        let (locals, expr) = env.Targets.[decisionTargetIdx]
        let env = (env, locals, decisionTargetExprs) |||> Array.fold2 (fun env p a -> bind env p (Value a))
        ctxt.EvalExpr (env, expr)

    member ctxt.EvalSequential(env, firstExpr, secondExpr) =
        let _ = ctxt.EvalExpr (env, firstExpr)
        ctxt.EvalExpr (env, secondExpr)

    member ctxt.EvalIfThenElse(env, guardExpr, thenExpr, elseExpr) =
        if ctxt.EvalBool(env, guardExpr) then 
            ctxt.EvalExpr (env, thenExpr) 
        else 
            ctxt.EvalExpr (env, elseExpr)

    member ctxt.EvalBool(env, expr) =
        match ctxt.EvalExpr (env, expr) |> getVal with 
        | :? bool as v -> v
        | :? int as v -> (v <> 0) // these are returned by filterExpr in EvalTryWith
        | t -> failwithf "unexpected result '%A' of type '%A' from bool expr" t (t.GetType())

    member ctxt.EvalTryFinally(env, bodyExpr, finallyExpr) =
        try 
            ctxt.EvalExpr (env, bodyExpr)
        finally 
            ctxt.EvalExpr (env, finallyExpr) |> ignore

    member ctxt.EvalTryWith(env, bodyExpr, filterVar, filterExpr, catchVar, catchExpr) =
        try 
            ctxt.EvalExpr (env, bodyExpr)
        with e when ctxt.EvalBool (bind env filterVar (Value e), filterExpr) ->
            ctxt.EvalExpr (bind env catchVar (Value e), catchExpr)

    member ctxt.EvalTupleGet(env, tupleElemIndex, tupleExpr) =
        let tupleExprV = ctxt.EvalExpr(env, tupleExpr) |> getVal
        Reflection.FSharpValue.GetTupleField(tupleExprV, tupleElemIndex) |> Value

    member ctxt.EvalWhileLoop(env, guardExpr, bodyExpr) =
        if ctxt.EvalBool(env, guardExpr) then 
            ctxt.EvalExpr (env, bodyExpr)  |> ignore
            ctxt.EvalWhileLoop(env, guardExpr, bodyExpr)
        else 
            Value (box ())

(*
    member ctxt.EvalFastIntegerForLoop(env, startExpr, limitExpr, consumeExpr, isUp) =
        let startV = ctxt.EvalExpr(env, startExpr) |> getVal |> unbox<int>
        let limitV = ctxt.EvalExpr(env, limitExpr) |> getVal |> unbox<int>
        // FCS TODO: the loop variable is not being specified by FCS!
        failwith "intepreted integer for-loops NYI"
       if isUp then 
             for i = startV to limitV do 
             ctxt.EvalExpr(env, limitExpr) |> getVal |> unbox<int>

        else
             for i = startV to limitV do 
                 
        if ctxt.EvalBool(env, guardExpr) then 
            ctxt.EvalExpr (env, bodyExpr)  |> ignore
            ctxt.EvalWhileLoop(env, guardExpr, bodyExpr)
        else 
            Value (box ())
*)

    member ctxt.EvalUnionCaseTest(env, unionExpr, unionType, unionCase) =
        let unionCaseR = ctxt.ResolveUnionCase (env, unionType, unionCase)
        let unionV : obj = ctxt.EvalExpr (env, unionExpr) |> getVal

        let res = 
            match unionCaseR with 
            | RUnionCase (ucase, tag, _make, _get) -> (tag unionV = ucase.Tag)
            | UUnionCase (tag, _unionCaseName) -> 
                match unionV with 
                | :? UnionValue as p -> 
                    let (UnionValue(tag2, _nm, _fields)) = p 
                    tag = tag2
                | _ -> failwithf "unexpected value '%A' in EvalUnionCaseTest" unionV
        Value (box res)

    member ctxt.EvalUnionCaseGet(env, unionExpr, unionType, unionCase, unionCaseField) =
        let unionCaseR = ctxt.ResolveUnionCase (env, unionType, unionCase)
        let unionCaseFieldR = ctxt.ResolveField (env, unionType, unionCaseField)
        let unionV : obj = ctxt.EvalExpr (env, unionExpr) |> getVal

        let res = 
            match unionCaseR with 
            | RUnionCase _ -> 
                match unionCaseFieldR with 
                | RField (:? FieldInfo as finfo) -> finfo.GetValue(unionV)
                | RField (:? PropertyInfo as pinfo) -> pinfo.GetValue(unionV)
                | _ -> failwithf "unexpected field resolution %A in EvalUnionCaseGet" unionCaseFieldR
            | UUnionCase (_tag, _unionCaseName) -> 
                match unionV with 
                | :? UnionValue as unionV -> 
                    let (UnionValue(_tag, _unionCaseName, fields)) = unionV
                    match unionCaseFieldR with 
                    | UField (index, _, _) -> 
                        fields.[index]
                    | RField _ -> 
                        failwithf "unexpected field resolution %A in EvalUnionCaseGet" unionCaseFieldR
                | _ -> failwithf "unexpected value '%A' in EvalUnionCaseGet" unionV
        Value (box res)

    member ctxt.EvalUnionCaseTag(env, unionExpr, unionType) =
        let unionTypeR = ctxt.ResolveType (env, unionType)
        let unionV : obj = ctxt.EvalExpr (env, unionExpr) |> getVal

        let res = 
            match unionTypeR with 
            | RType unionTypeV -> 
                let tag = Reflection.FSharpValue.PreComputeUnionTagReader(unionTypeV, bindAll)
                tag unionV 
            | _ -> 
                match unionV with 
                | :? (int * string * obj[]) as p -> 
                    let (tag, _nm, _fields) = p 
                    tag
                | _ -> failwithf "unexpected value '%A' in EvalUnionCaseTag" unionV
        Value (box res)

    member ctxt.EvalTypeTest(env, ty, inpExpr) =
        let tyR = ctxt.ResolveType (env, ty)
        let inpExprV = ctxt.EvalExpr (env, inpExpr) |> getVal
        let res = 
            match inpExprV with 
            | null -> false
            | obj -> 
                match tyR with 
                | RType tyT -> tyT.IsAssignableFrom(obj.GetType())
                | _ -> failwith "can't do type tests on intepreted types"
        Value res
