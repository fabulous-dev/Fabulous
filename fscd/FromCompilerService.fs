// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
module FSharp.Compiler.PortaCode.FromCompilerService

open FSharp.Compiler.PortaCode.CodeModel
open System.Collections.Generic
open Microsoft.FSharp.Compiler.SourceCodeServices

let map2 f g (a,b) = (f a, g b)

module List = 
    let mapToArray f arr = arr |> Array.ofList |> Array.map f

module Seq = 
    let mapToArray f arr = arr |> Array.ofSeq |> Array.map f

let rec convExpr (e:FSharpExpr) : DExpr = 
    match e with 
    | BasicPatterns.AddressOf(lvalueExpr) -> DExpr.AddressOf(convExpr lvalueExpr)
    | BasicPatterns.AddressSet(lvalueExpr, rvalueExpr) -> DExpr.AddressSet(convExpr lvalueExpr, convExpr rvalueExpr)
    // FCS TODO: fix FCS quirk with IsNone and IsSome on the option type
    | BasicPatterns.Application( BasicPatterns.Call(Some obj, memberOrFunc, tyargs1, tyargs2, [ ]), typeArgs, [ arg ]) when memberOrFunc.CompiledName = "get_IsNone" || memberOrFunc.CompiledName = "get_IsSome"  -> 
        let objExprR = convExpr obj
        let mrefR = convMemberRef memberOrFunc
        let typeArgs1R = convTypes tyargs1
        let typeArgs2R = convTypes tyargs2
        DExpr.Call(None, mrefR, typeArgs1R, typeArgs2R, [| objExprR |])
    | BasicPatterns.Application(funcExpr, typeArgs, argExprs) -> DExpr.Application(convExpr funcExpr, convTypes typeArgs, convExprs argExprs)
    | BasicPatterns.Call(objExprOpt, memberOrFunc, typeArgs1, typeArgs2, argExprs) -> 
        let objExprOptR = convExprOpt objExprOpt
        let mrefR = convMemberRef memberOrFunc
        let typeArgs1R = convTypes typeArgs1
        let typeArgs2R = convTypes typeArgs2
        let argExprsR = convExprs argExprs
        match objExprOptR with 
        // FCS TODO: Fix quirk with extension members so this isn't needed
        | Some objExprR when memberOrFunc.IsExtensionMember || not memberOrFunc.IsInstanceMemberInCompiledCode  -> 
            DExpr.Call(None, mrefR, typeArgs1R, typeArgs2R, Array.append [| objExprR |] argExprsR)
        | _ -> 
            DExpr.Call(objExprOptR, mrefR, typeArgs1R, typeArgs2R, argExprsR)
    | BasicPatterns.Coerce(targetType, inpExpr) -> DExpr.Coerce(convType targetType, convExpr inpExpr)
    | BasicPatterns.FastIntegerForLoop(startExpr, limitExpr, consumeExpr, isUp) -> DExpr.FastIntegerForLoop(convExpr startExpr, convExpr limitExpr, convExpr consumeExpr, isUp)
    | BasicPatterns.ILAsm(asmCode, typeArgs, argExprs) -> DExpr.ILAsm(asmCode, convTypes typeArgs, convExprs argExprs)
    | BasicPatterns.ILFieldGet (objExprOpt, fieldType, fieldName) -> DExpr.ILFieldGet(convExprOpt objExprOpt, convType fieldType, fieldName)
    | BasicPatterns.ILFieldSet (objExprOpt, fieldType, fieldName, valueExpr) -> DExpr.ILFieldSet (convExprOpt objExprOpt, convType fieldType, fieldName, convExpr valueExpr)
    | BasicPatterns.IfThenElse (guardExpr, thenExpr, elseExpr) -> DExpr.IfThenElse (convExpr guardExpr, convExpr thenExpr, convExpr elseExpr)
    | BasicPatterns.Lambda(lambdaVar, bodyExpr) -> DExpr.Lambda(convType lambdaVar.FullType, convType bodyExpr.Type, convLocalDef lambdaVar, convExpr bodyExpr)
    | BasicPatterns.Let((bindingVar, bindingExpr), bodyExpr) -> DExpr.Let((convLocalDef bindingVar, convExpr bindingExpr), convExpr bodyExpr)
    | BasicPatterns.LetRec(recursiveBindings, bodyExpr) -> DExpr.LetRec(List.mapToArray (map2 convLocalDef convExpr) recursiveBindings, convExpr bodyExpr)
    | BasicPatterns.NewArray(arrayType, argExprs) -> DExpr.NewArray(convType arrayType, convExprs argExprs)
    | BasicPatterns.NewDelegate(delegateType, delegateBodyExpr) -> DExpr.NewDelegate(convType delegateType, convExpr delegateBodyExpr)
    | BasicPatterns.NewObject(objCtor, typeArgs, argExprs) -> DExpr.NewObject(convMemberRef objCtor, convTypes typeArgs, convExprs argExprs)
    | BasicPatterns.NewRecord(recordType, argExprs) ->  DExpr.NewRecord(convType recordType, convExprs argExprs)
    | BasicPatterns.NewTuple(tupleType, argExprs) -> DExpr.NewTuple(convType tupleType, convExprs argExprs)
    | BasicPatterns.NewUnionCase(unionType, unionCase, argExprs) -> DExpr.NewUnionCase(convType unionType, convUnionCase unionCase, convExprs argExprs)
    | BasicPatterns.Quote(quotedExpr) -> DExpr.Quote(convExpr quotedExpr)
    | BasicPatterns.FSharpFieldGet(objExprOpt, recordOrClassType, fieldInfo) -> DExpr.FSharpFieldGet(convExprOpt objExprOpt, convType recordOrClassType, convFieldRef fieldInfo)
    | BasicPatterns.FSharpFieldSet(objExprOpt, recordOrClassType, fieldInfo, argExpr) -> DExpr.FSharpFieldSet(convExprOpt objExprOpt, convType recordOrClassType, convFieldRef fieldInfo, convExpr argExpr)
    | BasicPatterns.Sequential(firstExpr, secondExpr) -> DExpr.Sequential(convExpr firstExpr, convExpr secondExpr)
    | BasicPatterns.TryFinally(bodyExpr, finalizeExpr) -> DExpr.TryFinally(convExpr bodyExpr, convExpr finalizeExpr)
    | BasicPatterns.TryWith(bodyExpr, filterVar, filterExpr, catchVar, catchExpr) -> DExpr.TryWith(convExpr bodyExpr, convLocalDef filterVar, convExpr filterExpr, convLocalDef catchVar, convExpr catchExpr)
    | BasicPatterns.TupleGet(tupleType, tupleElemIndex, tupleExpr) -> DExpr.TupleGet(convType tupleType, tupleElemIndex, convExpr tupleExpr)
    | BasicPatterns.DecisionTree(decisionExpr, decisionTargets) -> DExpr.DecisionTree(convExpr decisionExpr, List.mapToArray (map2 (List.mapToArray convLocalDef) convExpr) decisionTargets)
    | BasicPatterns.DecisionTreeSuccess (decisionTargetIdx, decisionTargetExprs) -> DExpr.DecisionTreeSuccess (decisionTargetIdx, convExprs decisionTargetExprs)
    | BasicPatterns.TypeLambda(genericParams, bodyExpr) -> DExpr.TypeLambda(Array.map convGenericParamDef (Array.ofList genericParams), convExpr bodyExpr)
    | BasicPatterns.TypeTest(ty, inpExpr) -> DExpr.TypeTest(convType ty, convExpr inpExpr)
    | BasicPatterns.UnionCaseSet(unionExpr, unionType, unionCase, unionCaseField, valueExpr) -> DExpr.UnionCaseSet(convExpr unionExpr, convType unionType, convUnionCase unionCase, convUnionCaseField unionCase unionCaseField, convExpr valueExpr)
    | BasicPatterns.UnionCaseGet(unionExpr, unionType, unionCase, unionCaseField) -> DExpr.UnionCaseGet(convExpr unionExpr, convType unionType, convUnionCase unionCase, convUnionCaseField unionCase unionCaseField)
    | BasicPatterns.UnionCaseTest(unionExpr, unionType, unionCase) -> DExpr.UnionCaseTest(convExpr unionExpr, convType unionType, convUnionCase unionCase)
    | BasicPatterns.UnionCaseTag(unionExpr, unionType) -> DExpr.UnionCaseTag(convExpr unionExpr, convType unionType)
    | BasicPatterns.ObjectExpr(objType, baseCallExpr, overrides, interfaceImplementations) -> DExpr.ObjectExpr(convType objType, convExpr baseCallExpr, Array.map convObjMemberDef (Array.ofList overrides), Array.map (map2 convType (Array.ofList >> Array.map convObjMemberDef)) (Array.ofList interfaceImplementations))
    //| BasicPatterns.TraitCall(sourceTypes, traitName, typeArgs, typeInstantiation, argTypes, argExprs) -> DExpr.TraitCall(sourceTypes, traitName, typeArgs, typeInstantiation, argTypes, argExprs)
    | BasicPatterns.ValueSet(valToSet, valueExpr) -> DExpr.ValueSet(convLocalRef valToSet, convExpr valueExpr)
    | BasicPatterns.WhileLoop(guardExpr, bodyExpr) -> DExpr.WhileLoop(convExpr guardExpr, convExpr bodyExpr)
    | BasicPatterns.BaseValue baseType -> DExpr.BaseValue (convType baseType)
    | BasicPatterns.DefaultValue defaultType -> DExpr.DefaultValue (convType defaultType)
    | BasicPatterns.ThisValue thisType -> DExpr.ThisValue (convType thisType)
    | BasicPatterns.Const(constValueObj, constType) -> DExpr.Const (constValueObj, convType constType) 
    | BasicPatterns.Value(valueToGet) ->  DExpr.Value(convLocalRef valueToGet)
    | _ -> failwith (sprintf "unrecognized %+A" e)

and convExprs exprs = 
    Array.map convExpr (Array.ofList exprs)

and convExprOpt exprs = 
    Option.map convExpr exprs

and convObjArg f objOpt = 
    Option.map convExpr objOpt

and convObjMemberDef (memb: FSharpObjectExprOverride) : DObjectExprOverrideDef = 
    { //Signature: DAbstractSignature
      GenericParameters = convGenericParamDefs memb.GenericParameters
      Name = memb.Signature.Name
      Parameters = memb.CurriedParameterGroups |> convParamDefs2
      Body = convExpr memb.Body }

and convFieldRef (field: FSharpField) : DFieldRef = 
    match field.DeclaringEntity.FSharpFields |> Seq.tryFindIndex (fun field2 -> field2.Name = field.Name) with
    | Some index -> DFieldRef (index, field.Name)
    | None -> failwithf "couldn't find field %s in type %A" field.Name field.DeclaringEntity

and convUnionCase (ucase: FSharpUnionCase) : DUnionCaseRef = 
    DUnionCaseRef (ucase.CompiledName)

and convUnionCaseField (ucase: FSharpUnionCase) (field: FSharpField) : DFieldRef = 
    match ucase.UnionCaseFields |> Seq.tryFindIndex (fun field2 -> field2.Name = field.Name) with
    | Some index -> DFieldRef (index, field.Name)
    | None -> failwithf "couldn't find field %s in type %A" field.Name field.DeclaringEntity

and convLocalDef (memb: FSharpMemberOrFunctionOrValue) : DLocalDef = 
    { Name = memb.CompiledName; IsMutable = memb.IsMutable; Type = convType memb.FullType }

and convLocalRef (value: FSharpMemberOrFunctionOrValue) : DLocalRef = 
    DLocalRef (value.CompiledName, (value.IsMemberThisValue || value.IsConstructorThisValue || value.IsBaseValue), value.IsMutable)

and convMemberDef (memb: FSharpMemberOrFunctionOrValue) : DMemberDef = 
    assert (memb.IsMember || memb.IsModuleValueOrMember)
    { EnclosingEntity = convEntityRef memb.DeclaringEntity.Value
      Name = memb.CompiledName
      GenericParameters = convGenericParamDefs memb.GenericParameters
      Parameters = convParamDefs memb.CurriedParameterGroups
      ReturnType = convReturnType memb
      IsInstance = memb.IsInstanceMemberInCompiledCode }

and convMemberRef (memb: FSharpMemberOrFunctionOrValue) = 
    if not (memb.IsMember || memb.IsModuleValueOrMember) then failwith "can't convert non-member ref"
    let paramTypesR = convParamTypes memb.CurriedParameterGroups
    if memb.IsExtensionMember && memb.ApparentEnclosingEntity.GenericParameters.Count > 0 then failwithf "NYI: extension of generic type, needs FCS support: %A" memb
    let paramTypesR = if memb.IsExtensionMember then Array.append [| DNamedType (convEntityRef memb.ApparentEnclosingEntity, [| |]) |] paramTypesR else paramTypesR
    DMemberRef (convEntityRef memb.DeclaringEntity.Value, memb.CompiledName, memb.GenericParameters.Count, paramTypesR, convReturnType memb)

and convParamTypes (parameters: IList<IList<FSharpParameter>>) = 
    parameters |> Seq.concat |> Array.ofSeq |> Array.map (fun p -> p.Type) |> convTypes 

and convParamDefs (parameters: IList<IList<FSharpParameter>>) = 
    parameters |> Seq.concat |> Array.ofSeq |> Array.map (fun p -> { Name = p.DisplayName; IsMutable = false; Type = convType p.Type })

and convParamDefs2 (parameters: FSharpMemberOrFunctionOrValue list list) = 
    parameters |> Seq.concat |> Array.ofSeq |> Array.map (fun p -> { Name = p.DisplayName; IsMutable = false; Type = convType p.FullType })

and convReturnType (memb: FSharpMemberOrFunctionOrValue) = 
    convType memb.ReturnParameter.Type

and convEntityDef (entity: FSharpEntity) : DEntityDef = 
    if entity.IsNamespace then failwith "convEntityDef: can't convert a namespace"
    if entity.IsArrayType then failwith "convEntityDef: can't convert an array"
    if entity.IsFSharpAbbreviation then failwith "convEntityDef: can't convert a type abbreviation"
    { Name = entity.QualifiedName
      GenericParameters = convGenericParamDefs entity.GenericParameters 
      UnionCases = entity.UnionCases |> Seq.mapToArray  (fun uc -> uc.Name) }

and convEntityRef (entity: FSharpEntity) : DEntityRef = 
    if entity.IsNamespace then failwith "convEntityRef: can't convert a namespace"
    if entity.IsArrayType then failwith "convEntityRef: can't convert an array"
    if entity.IsFSharpAbbreviation then failwith "convEntityRef: can't convert a type abbreviation"
    DEntityRef entity.QualifiedName

and convType (typ: FSharpType) = 
    if typ.IsAbbreviation then convType typ.AbbreviatedType 
    elif typ.IsFunctionType then DFunctionType (convType typ.GenericArguments.[0], convType typ.GenericArguments.[1])
    elif typ.IsTupleType then DTupleType (false, convTypes typ.GenericArguments)
    elif typ.IsStructTupleType then DTupleType (true, convTypes typ.GenericArguments)
    elif typ.IsGenericParameter then DVariableType typ.GenericParameter.Name
    elif typ.TypeDefinition.IsArrayType then DArrayType (typ.TypeDefinition.ArrayRank, convType typ.GenericArguments.[0])
    else DNamedType (convEntityRef typ.TypeDefinition, convTypes typ.GenericArguments)
and convTypes (typs: seq<FSharpType>) = typs |> Seq.toArray |> Array.map convType 
and convGenericParamDef (gp: FSharpGenericParameter) : DGenericParameterDef = { Name = gp.Name }
and convGenericParamDefs (gps: seq<FSharpGenericParameter>) = gps |> Seq.toArray |> Array.map convGenericParamDef

let rec convDecl d = 
    [| match d with 
       | FSharpImplementationFileDeclaration.Entity (e, subDecls) -> 
           if e.IsFSharpAbbreviation then ()
           elif e.IsNamespace then yield! convDecls subDecls
           elif e.IsArrayType then ()
           else yield DDeclEntity (convEntityDef e, convDecls subDecls) 
       | FSharpImplementationFileDeclaration.MemberOrFunctionOrValue(v, vs, e) -> 
           yield DDeclMember (convMemberDef v, convExpr e)
       | FSharpImplementationFileDeclaration.InitAction(e) -> 
           yield DDecl.InitAction (convExpr e) |]
and convDecls decls = 
    decls |> Array.ofList |> Array.collect convDecl 

