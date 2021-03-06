// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System
open System.Collections.Concurrent
open System.Threading

[<AutoOpen>]
module DynamicViewHelpers =
    /// Checks whether two objects are reference-equal
    let identical (x: 'T) (y:'T) = System.Object.ReferenceEquals(x, y)

    let identicalVOption (x: 'T voption) (y: 'T voption) =
        match struct (x, y) with
        | struct (ValueNone, ValueNone) -> true
        | struct (ValueSome x1, ValueSome y1) when identical x1 y1 -> true
        | _ -> false

    /// Checks whether an underlying control can be reused given the previous and new view elements
    let rec canReuseView (canReuseView: IViewElement -> IViewElement -> bool) (prevChild: DynamicViewElement) (newChild: DynamicViewElement) =
        if prevChild.TargetType = newChild.TargetType && canReuseAutomationId prevChild newChild then
            if newChild.TargetType.IsAssignableFrom(typeof<NavigationPage>) then
                canReuseNavigationPage canReuseView prevChild newChild
            elif newChild.TargetType.IsAssignableFrom(typeof<CustomEffect>) then
                canReuseCustomEffect prevChild newChild
            else
                true
        else
            false

    /// Checks whether an underlying NavigationPage control can be reused given the previous and new view elements
    //
    // NavigationPage can be reused only if the pages don't change their type (added/removed pages don't prevent reuse)
    // E.g. If the first page switch from ContentPage to TabbedPage, the NavigationPage can't be reused.
    and internal canReuseNavigationPage (canReuseView: IViewElement -> IViewElement -> bool) (prevChild:DynamicViewElement) (newChild:DynamicViewElement) =
        let prevPages = prevChild.TryGetAttributeKeyed(ViewAttributes.PagesAttribKey)
        let newPages = newChild.TryGetAttributeKeyed(ViewAttributes.PagesAttribKey)

        match prevPages, newPages with
        | ValueSome prevPages, ValueSome newPages -> (prevPages, newPages) ||> Seq.forall2 canReuseView
        | _, _ -> true

    /// Checks whether the control can be reused given the previous and the new AutomationId.
    /// Xamarin.Forms can't change an already set AutomationId
    and internal canReuseAutomationId (prevChild: DynamicViewElement) (newChild: DynamicViewElement) =
        let prevAutomationId = prevChild.TryGetAttributeKeyed(ViewAttributes.AutomationIdAttribKey)
        let newAutomationId = newChild.TryGetAttributeKeyed(ViewAttributes.AutomationIdAttribKey)

        match prevAutomationId with
        | ValueSome _ when prevAutomationId <> newAutomationId -> false
        | _ -> true

    /// Checks whether the CustomEffect can be reused given the previous and the new Effect name
    /// The effect is instantiated by Effect.Resolve and can't be reused when asking for a new effect
    and internal canReuseCustomEffect (prevChild: DynamicViewElement) (newChild: DynamicViewElement) =
        let prevName = prevChild.TryGetAttributeKeyed(ViewAttributes.NameAttribKey)
        let newName = newChild.TryGetAttributeKeyed(ViewAttributes.NameAttribKey)

        match prevName with
        | ValueSome _ when prevName <> newName -> false
        | _ -> true

    /// Debounce multiple calls to a single function
    let debounce<'T> =
        let memoization = ConcurrentDictionary<obj, CancellationTokenSource>(HashIdentity.Structural)
        fun (timeout: int) (fn: 'T -> unit) value ->
            let key = fn.GetType()
            match memoization.TryGetValue(key) with
            | true, previousCts -> previousCts.Cancel()
            | _ -> ()

            let cts = new CancellationTokenSource()
            memoization.[key] <- cts

            Device.StartTimer(TimeSpan.FromMilliseconds(float timeout), (fun () ->
                match cts.IsCancellationRequested with
                | true -> ()
                | false ->
                    memoization.TryRemove(key) |> ignore
                    fn value
                false // Do not let the timer trigger a second time
            ))

    /// Looks for a view element with the given Automation ID in the view hierarchy.
    /// This function is not optimized for efficiency and may execute slowly.
    let rec tryFindViewElement automationId (element: DynamicViewElement) =
        let elementAutomationId = element.TryGetAttributeKeyed(ViewAttributes.AutomationIdAttribKey)
        match elementAutomationId with
        | ValueSome automationIdValue when automationIdValue = automationId -> Some element
        | _ ->
            let childElements =
                match element.TryGetAttributeKeyed(ViewAttributes.ContentAttribKey) with
                | ValueSome content -> [| content |]
                | ValueNone ->
                    match element.TryGetAttributeKeyed(ViewAttributes.PagesAttribKey) with
                    | ValueSome pages -> pages
                    | ValueNone ->
                        match element.TryGetAttributeKeyed(ViewAttributes.ChildrenAttribKey) with
                        | ValueSome children -> children
                        | ValueNone -> [| |]

            childElements
            |> Seq.choose (fun ve -> match ve with :? DynamicViewElement as dve -> Some dve | _ -> None)
            |> Seq.choose (tryFindViewElement automationId)
            |> Seq.tryHead

    /// Looks for a view element with the given Automation ID in the view hierarchy
    /// Throws an exception if no element is found
    let findViewElement automationId element =
        match tryFindViewElement automationId element with
        | None -> failwithf "No element with automation id '%s' found" automationId
        | Some viewElement -> viewElement