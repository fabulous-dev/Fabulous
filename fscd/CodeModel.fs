// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.

module FSharp.Compiler.PortaCode.CodeModel


/// A representation of resolved F# expressions that can be serialized
type DExpr = 
    | Value  of DLocalRef
    | ThisValue  of DType 
    | BaseValue  of DType 
    | Application of DExpr * DType[] * DExpr[]  
    | Lambda of DType * DType * DLocalDef * DExpr  
    | TypeLambda of DGenericParameterDef[] * DExpr  
    | Quote  of DExpr  
    | IfThenElse   of DExpr * DExpr * DExpr  
    | DecisionTree   of DExpr * (DLocalDef[] * DExpr)[]
    | DecisionTreeSuccess of int * DExpr[]
    | Call of DExpr option * DMemberRef * DType[] * DType[] * DExpr[] 
    | NewObject of DMemberRef * DType[] * DExpr[] 
    | LetRec of ( DLocalDef * DExpr)[] * DExpr  
    | Let of (DLocalDef * DExpr) * DExpr 
    | NewRecord of DType * DExpr[] 
    | ObjectExpr of DType * DExpr * DObjectExprOverrideDef[] * (DType * DObjectExprOverrideDef[])[]
    | FSharpFieldGet of  DExpr option * DType * DFieldRef 
    | FSharpFieldSet of  DExpr option * DType * DFieldRef * DExpr 
    | NewUnionCase of DType * DUnionCaseRef * DExpr[]  
    | UnionCaseGet of DExpr * DType * DUnionCaseRef * DFieldRef 
    | UnionCaseSet of DExpr * DType * DUnionCaseRef * DFieldRef  * DExpr
    | UnionCaseTag of DExpr * DType 
    | UnionCaseTest of DExpr  * DType * DUnionCaseRef 
    //| TraitCall of DType[] * string * Ast.MemberFlags * DType[] * DType[] * DExpr[]
    | NewTuple of DType * DExpr[]  
    | TupleGet of DType * int * DExpr 
    | Coerce of DType * DExpr  
    | NewArray of DType * DExpr[]  
    | TypeTest of DType * DExpr  
    | AddressSet of DExpr * DExpr  
    | ValueSet of DLocalRef * DExpr  
    | Unused
    | DefaultValue of DType  
    | Const of obj * DType
    | AddressOf of DExpr 
    | Sequential of DExpr * DExpr  
    | FastIntegerForLoop of DExpr * DExpr * DExpr * bool
    | WhileLoop of DExpr * DExpr  
    | TryFinally of DExpr * DExpr  
    | TryWith of DExpr * DLocalDef * DExpr * DLocalDef * DExpr  
    | NewDelegate of DType * DExpr  
    | ILFieldGet of DExpr option * DType * string 
    | ILFieldSet of DExpr option * DType * string  * DExpr 
    | ILAsm of string * DType[] * DExpr[]
and DType = 
    | DNamedType of DEntityRef * DType[]
    | DFunctionType of DType * DType
    | DTupleType of bool * DType[]
    | DArrayType of int * DType
    | DVariableType of string
and DLocalDef = 
    { Name: string; IsMutable: bool; Type: DType }
and DMemberDef = 
    { EnclosingEntity: DEntityRef; Name: string; GenericParameters: DGenericParameterDef[]; IsInstance: bool; Parameters: DLocalDef[]; ReturnType: DType }
    member x.Ref = DMemberRef (x.EnclosingEntity, x.Name, x.GenericParameters.Length, (x.Parameters |> Array.map (fun p -> p.Type)), x.ReturnType)
and DGenericParameterDef = { Name: string }
and DEntityDef = { Name: string; GenericParameters: DGenericParameterDef[]; UnionCases: string[] }
and DEntityRef = DEntityRef of string 
and DMemberRef = DMemberRef of DEntityRef * string * int * DType[] * DType
and DLocalRef = DLocalRef of name: string * isThisValue: bool * isMutable: bool
and DFieldRef = DFieldRef of int * string
and DUnionCaseRef = DUnionCaseRef of string
and DObjectExprOverrideDef =  { Name: string; GenericParameters: DGenericParameterDef[]; Parameters: DLocalDef[]; Body: DExpr }

type DDecl = 
    | DDeclEntity of DEntityDef * DDecl[]
    | DDeclMember of DMemberDef * DExpr
    | InitAction of DExpr

type DFile = 
    { Code: DDecl[] }

