// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews 

open Fabulous.DynamicViews
open System
open System.Collections.Generic
open System.Threading
open Xamarin.Forms

[<System.Obsolete("Please change 'Xaml.XYZ' to 'View.XYZ'", error=false)>]
type Xaml = Fabulous.DynamicViews.View 

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
        
    /// Dispatch a message via the currently running Elmish program
    [<System.Obsolete("The global dispatch routine should no longer be used as it is not type safe, please use the dispatch routine passed to the 'view' function", error=true)>]
    let dispatch _msg : unit = failwith "??"

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

    /// Debounce multiple calls to a single function
    let debounce<'T> =
        let memoizations = Dictionary<obj, CancellationTokenSource>(HashIdentity.Structural)
        fun (timeout: int) (fn: 'T -> unit) value ->
            let key = fn.GetType()
            match memoizations.TryGetValue(key) with
            | true, previousCts -> previousCts.Cancel()
            | _ -> ()

            let cts = new CancellationTokenSource()
            memoizations.[key] <- cts

            Device.StartTimer(TimeSpan.FromMilliseconds(float timeout), (fun () ->
                match cts.IsCancellationRequested with
                | false ->
                    memoizations.Remove(key) |> ignore
                    fn value
                | _ -> ()
                false // Do not let the timer trigger a second time
            ))

    type ViewElement with 
        member x.With(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, 
                      ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, 
                      ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, 
                      ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, 
                      ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, 
                      ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 
            let x = match horizontalOptions with None -> x | Some opt -> x.HorizontalOptions(opt)
            let x = match verticalOptions with None -> x | Some opt -> x.VerticalOptions(opt)
            let x = match margin with None -> x | Some opt -> x.Margin(opt)
            let x = match gestureRecognizers with None -> x | Some opt -> x.GestureRecognizers(opt)
            let x = match anchorX with None -> x | Some opt -> x.AnchorX(opt)
            let x = match anchorY with None -> x | Some opt -> x.AnchorY(opt)
            let x = match backgroundColor with None -> x | Some opt -> x.BackgroundColor(opt)
            let x = match heightRequest with None -> x | Some opt -> x.HeightRequest(opt)
            let x = match inputTransparent with None -> x | Some opt -> x.InputTransparent(opt)
            let x = match isEnabled with None -> x | Some opt -> x.IsEnabled(opt)
            let x = match isVisible with None -> x | Some opt -> x.IsVisible(opt)
            let x = match minimumHeightRequest with None -> x | Some opt -> x.MinimumHeightRequest(opt)
            let x = match minimumWidthRequest with None -> x | Some opt -> x.MinimumWidthRequest(opt)
            let x = match opacity with None -> x | Some opt -> x.Opacity(opt)
            let x = match rotation with None -> x | Some opt -> x.Rotation(opt)
            let x = match rotationX with None -> x | Some opt -> x.RotationX(opt)
            let x = match rotationY with None -> x | Some opt -> x.RotationY(opt)
            let x = match scale with None -> x | Some opt -> x.Scale(opt)
            let x = match style with None -> x | Some opt -> x.Style(opt)
            let x = match translationX with None -> x | Some opt -> x.TranslationX(opt)
            let x = match translationY with None -> x | Some opt -> x.TranslationY(opt)
            let x = match widthRequest with None -> x | Some opt -> x.WidthRequest(opt)
            let x = match resources with None -> x | Some opt -> x.Resources(opt)
            let x = match styles with None -> x | Some opt -> x.Styles(opt)
            let x = match styleSheets with None -> x | Some opt -> x.StyleSheets(opt)
            let x = match styleSheets with None -> x | Some opt -> x.StyleSheets(opt)
            let x = match classId with None -> x | Some opt -> x.ClassId(opt)
            let x = match styleId with None -> x | Some opt -> x.StyleId(opt)
            x

    let ContentsAttribKey = AttributeKey<(obj -> ViewElement)> "Stateful_Contents"

    let localStateTable = System.Runtime.CompilerServices.ConditionalWeakTable<obj, obj option>()

    type View with

        /// Describes an element in the view which uses localized mutable state unrelated to the model
        /// (and hence un-persisted), and can optionally access the underlying control. The 'init'
        /// function is called only when the underlying control is created (and each time it is re-created,
        /// if ever). The generated state object is associated with the underlying control.
        static member Stateful (init: (unit -> 'State), contents: 'State -> ViewElement, ?onCreate: ('State -> obj -> unit), ?onUpdate: ('State -> obj -> unit)) : _ when 'State : not struct =

            let attribs = AttributesBuilder(1)
            attribs.Add(ContentsAttribKey, (fun stateObj -> contents (unbox (stateObj))))

            // The create method
            let create () = 
                let state = init()
                let desc = contents state
                let item = desc.Create()
                localStateTable.Add(item, Some (box state))
                match onCreate with None -> () | Some f -> f state item
                item

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: obj) = 
                let state = unbox<'State> ((snd (localStateTable.TryGetValue(target))).Value)
                let contents = source.TryGetAttributeKeyed(ContentsAttribKey).Value
                let realSource = contents state
                realSource.Update(prevOpt, source, target)
                match onUpdate with None -> () | Some f -> f state target

            // The element
            ViewElement.Create(create, update, attribs)

        static member OnCreate (contents : ViewElement, onCreate: (obj -> unit)) =
            View.Stateful (init = (fun () -> ()), contents = (fun _ -> contents), onCreate = (fun _ obj -> onCreate obj))

        static member WithInternalModel(init: (unit -> 'InternalModel), 
                                        update: ('InternalMessage -> 'InternalModel -> 'InternalModel), 
                                        view : ('InternalModel -> ('InternalMessage -> unit) -> ViewElement)) =
            let internalDispatch (state: 'InternalModel ref) msg = state.Value <- update msg state.Value
            View.Stateful (init = (fun () -> ref (init ())), contents = (fun state -> view state.Value (internalDispatch state)))

    // Keep a table to make sure we create a unique ViewElement for each external object
    let externalsTable = System.Runtime.CompilerServices.ConditionalWeakTable<obj, obj>()
    type View with

        /// Describes an element in the view implemented by an external object, e.g. an external
        /// Xamarin.Forms Page or View. The element must have a type appropriate for the place in
        /// the view where the object occurs.
        static member External (externalObj: 'T) : _ when 'T : not struct =

            match externalsTable.TryGetValue(externalObj) with 
            | true, v -> (v :?> ViewElement)
            | _ -> 
                let attribs = AttributesBuilder(0)
                let create () = box externalObj 
                let update (_prevOpt: ViewElement voption) (_source: ViewElement) (_target: obj) = ()
                let res = ViewElement(externalObj.GetType(), create, update, attribs)
                externalsTable.Add(externalObj, res)
                res

