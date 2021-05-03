// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System.Collections.Generic

[<AutoOpen>]
module SimplerHelpers =
    type internal Memoizations() =
         static let t = Dictionary<obj,System.WeakReference<obj>>(HashIdentity.Structural)
         static member T = t
         static member Add(key: obj, res: obj) =
             if Memoizations.T.Count > 50000 then
                 System.Diagnostics.Trace.WriteLine("Clearing 'dependsOn' and 'fix' memoizations...")
                 Memoizations.T.Clear()
             Memoizations.T.[key] <- System.WeakReference<obj>(box res)

    /// Because ViewElement stores its values as KeyValuePair<AttributeKey, obj>,
    /// Structs like Xamarin.Forms.Color/Thickness will be boxed each time we use them
    /// To prevent that, we memoize the boxed value for the recently used structs
    type StructMemoizations<'T when 'T : struct and 'T : equality>() =
        static let t = Dictionary<int, obj>()
        static member T = t
        static member Add(res: 'T) =
            if StructMemoizations<'T>.T.Count > 100 then
                System.Diagnostics.Trace.WriteLine("Clearing {0} memoizations...", typeof<'T>.FullName)
                StructMemoizations<'T>.T.Clear()
            let key = res.GetHashCode()
            let value = box res
            StructMemoizations<'T>.T.[key] <- value
            value
        static member TryGetValue(res: 'T) =
            match StructMemoizations<'T>.T.TryGetValue(res.GetHashCode()) with
            | false, _ -> ValueNone
            | true, value -> ValueSome value

    type DoNotUseModelInsideDependsOn = | DoNotUseModelInsideDependsOn

    /// Memoize part of a view model computation. Also prevent the use of the model inside
    /// the computation except where explicitly de-referenced.
    ///
    /// Usage: "dependsOn model.Count (fun model count -> ...)"
    ///
    /// Note, this function uses "f.GetType()" to get a unique code location.
    let dependsOn key (f: DoNotUseModelInsideDependsOn -> 'Key -> 'Value) : 'Value =
        let bkey = (key, f.GetType())
        let mutable res = null
        match Memoizations.T.TryGetValue(bkey) with
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             let res = f DoNotUseModelInsideDependsOn key
             Memoizations.Add(bkey, box res)
             res

    /// Memoize a callback that has no interesting dependencies.
    /// NOTE: use with caution. The function must not capture any values besides "dispatch"
    let fix (f: unit -> 'Value) =
        let key = f.GetType()
        let mutable res = null
        match Memoizations.T.TryGetValue(key) with
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f()
             Memoizations.Add(key, box res)
             res

    /// Memoize a callback that has explicit dependencies.
    /// NOTE: use with caution. The function must not capture any values besides "dispatch"
    let fixf (f: 'Args -> 'Value) =
        let key = f.GetType()
        let mutable res = null
        match Memoizations.T.TryGetValue(key) with
        | true, weak when weak.TryGetTarget(&res) -> unbox res
        | _ ->
             // Note: we do this check once only per syntactic closure occurrence that is passed to 'fix'
             let flds = key.GetFields(System.Reflection.BindingFlags.NonPublic) |> Array.filter (fun fld -> fld.Name <> "dispatch")
             if flds.Length > 0 then failwithf "the closure '%s' has a dependency '%s', you can't use 'fix' with such a closure" key.Name flds.[0].Name
             let res = f
             Memoizations.Add(key, box res)
             res