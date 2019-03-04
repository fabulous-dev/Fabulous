// Copyright 2018 Fabulous contributors. See LICENSE.md for license.

namespace Fabulous.DynamicViews

open System
open System.Collections.Generic
open System.ComponentModel
open System.IO
open System.Windows.Input
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

module ValueOption = 
    let inline map f x = match x with ValueNone -> ValueNone | ValueSome v -> ValueSome (f v)

/// Defines if the action should be animated or not
type AnimationKind =
    | Animated
    | NotAnimated

/// A custom data element for the ListView view element
[<AllowNullLiteral>]
type IListElement = 
    inherit INotifyPropertyChanged
    abstract Key : ViewElement

/// A custom data element for the ListView view element
[<AllowNullLiteral>]
type ListElementData(key) = 
    let ev = new Event<_,_>()
    let mutable data = key
    
    interface IListElement with
        member x.Key = data
        [<CLIEvent>] member x.PropertyChanged = ev.Publish
        
    member x.Key
        with get() = data
        and set(value) =
            data <- value
            ev.Trigger(x, PropertyChangedEventArgs "Key")

/// A custom data element for the GroupedListView view element
[<AllowNullLiteral>]
type ListGroupData(shortName: string, key, coll: ViewElement[]) = 
    inherit System.Collections.ObjectModel.ObservableCollection<ListElementData>(Seq.map ListElementData coll)
    
    let ev = new Event<_,_>()
    let mutable shortNameData = shortName
    let mutable keyData = key
    
    interface IListElement with
        member x.Key = keyData
        [<CLIEvent>] member x.PropertyChanged = ev.Publish
        
    member x.Key
        with get() = keyData
        and set(value) =
            keyData <- value
            ev.Trigger(x, PropertyChangedEventArgs "Key")
            
    member x.ShortName
        with get() = shortName
        and set(value) =
            shortNameData <- value
            ev.Trigger(x, PropertyChangedEventArgs "ShortName")
            
    member __.Items = coll

/// A custom control for cells in the ListView view element
type ViewElementCell() = 
    inherit ViewCell()

    let mutable listElementOpt : IListElement option = None
    let mutable modelOpt : ViewElement option = None
    
    let createView (newModel: ViewElement) =
        match newModel.Create () with 
        | :? View as v -> v
        | x -> failwithf "The cells of a ListView must each be some kind of 'View' and not a '%A'" (x.GetType())

    member x.OnDataPropertyChanged = PropertyChangedEventHandler(fun _ args ->
        match args.PropertyName, listElementOpt, modelOpt with
        | "Key", Some curr, Some prevModel ->
            curr.Key.UpdateIncremental (prevModel, x.View)
            modelOpt <- Some curr.Key
        | _ -> ()
    )

    override x.OnBindingContextChanged () =
        base.OnBindingContextChanged ()
        match x.BindingContext with
        | :? IListElement as curr -> 
            let newModel = curr.Key
            match listElementOpt with 
            | Some prev ->
                prev.PropertyChanged.RemoveHandler x.OnDataPropertyChanged
                curr.PropertyChanged.AddHandler x.OnDataPropertyChanged
                newModel.UpdateIncremental (prev.Key, x.View)
            | None -> 
                curr.PropertyChanged.AddHandler x.OnDataPropertyChanged
                x.View <- createView newModel

            listElementOpt <- Some curr
            modelOpt <- Some curr.Key
        | _ ->
            match listElementOpt with
            | Some prev -> 
                prev.PropertyChanged.RemoveHandler x.OnDataPropertyChanged
                listElementOpt <- None
                modelOpt <- None
            | None -> ()

/// A custom control for the ListView view element
type CustomListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<ViewElementCell>))

/// A custom control for the ListViewGrouped view element
type CustomGroupListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<ViewElementCell>), GroupHeaderTemplate=DataTemplate(typeof<ViewElementCell>), IsGroupingEnabled=true)

/// The underlying page type for the ContentPage view element
type CustomContentPage() as self = 
    inherit ContentPage()
    do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, true)
    let sizeAllocated: Event<double * double> = Event<_>() 

    member __.SizeAllocated = sizeAllocated.Publish

    override __.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(width, height)

[<AutoOpen>]
module Converters =
    open System.Collections.ObjectModel

    /// Converts an F# function to a Xamarin.Forms ICommand
    let makeCommand f =
        let ev = Event<_,_>()
        { new ICommand with
            member __.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member __.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member __.CanExecute _ = true
            member __.Execute _ = f() }

    /// Converts an F# function to a Xamarin.Forms ICommand, with a CanExecute value
    let makeCommandCanExecute f canExecute =
        let ev = Event<_,_>()
        { new ICommand with
            member __.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member __.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member __.CanExecute _ = canExecute
            member __.Execute _ = f() }

    /// Converts a string, byte array or ImageSource to a Xamarin.Forms ImageSource
    let makeImageSource (v: obj) =
        match v with
        | :? string as path -> ImageSource.op_Implicit path
        | :? (byte[]) as bytes -> ImageSource.FromStream(fun () -> new MemoryStream(bytes) :> Stream)
        | :? ImageSource as imageSource -> imageSource
        | _ -> failwithf "makeImageSource: invalid argument %O" v

    /// Converts a string to a Xamarin.Forms Accelerator
    let makeAccelerator (accelerator: string) = Accelerator.op_Implicit accelerator

    /// Converts a string to a Xamarin.Forms FileImageSource
    let makeFileImageSource (image: string) = FileImageSource.op_Implicit image

    /// Converts a double or Thickness to a Xamarin.Forms Thickness
    let makeThickness (v: obj) = 
       match v with 
       | :? double as f -> Thickness.op_Implicit f
       | :? Thickness as v -> v
       | _ -> failwithf "makeThickness: invalid argument %O" v

    /// Converts a string or collection of strings to a Xamarin.Forms StyleClass specification
    let makeStyleClass (v:obj) = 
       match v with
       | :? string as s        -> [| s |]
       | :? (string list) as s -> s |> Array.ofList
       | :? (string[])   as s -> s
       | :? (seq<string>)  as s -> s |> Array.ofSeq
       | _ -> failwithf "makeStyleClass: invalid argument %O" v

    /// Converts a string, double or GridLength to a Xamarin.Forms GridLength
    let makeGridLength (v: obj) = 
        match v with 
        | :? string as s when s = "*" -> GridLength.Star
        | :? string as s when s.EndsWith "*" && fst (Double.TryParse(s.[0..s.Length-2]))  -> 
            let sz = snd (Double.TryParse(s.[0..s.Length-2]))
            GridLength(sz, GridUnitType.Star)
        | :? string as s when s = "auto" -> GridLength.Auto
        | :? double as f -> GridLength.op_Implicit f
        | :? GridLength as v -> v
        | _ -> failwithf "makeGridLength: invalid argument %O" v

    /// Converts a string, int or double to a Xamarin.Forms font size
    let makeFontSize (v: obj) = 
        match box v with 
        | :? string as s -> (FontSizeConverter().ConvertFromInvariantString(s) :?> double)
        | :? int as i -> double i
        | :? double as v -> v
        | _ -> System.Convert.ToDouble(v)

    /// Converts an F# function to an event handler for a page change
    let makeCurrentPageChanged<'a when 'a :> Xamarin.Forms.Page and 'a : null> f =
        System.EventHandler(fun sender _args ->
            let control = sender :?> Xamarin.Forms.MultiPage<'a>
            let index =
                match control.CurrentPage with
                | null -> None
                | page -> Some (Xamarin.Forms.MultiPage<'a>.GetIndex(page))
            f index
        )

    /// Converts a string or uri to a Xamarin.Forms ShellNavigation
    let makeUri (v: obj) =
        match v with
        | :? string as path -> ShellNavigationState.op_Implicit path
        | :? Uri as uri -> ShellNavigationState.op_Implicit uri
        | _ -> failwithf "makeUri: invalid argument %O" v

    /// Checks whether two objects are reference-equal
    let identical (x: 'T) (y:'T) = System.Object.ReferenceEquals(x, y)

    /// Checks whether an underlying control can be reused given the previous and new view elements
    let rec canReuseChild (prevChild:ViewElement) (newChild:ViewElement) =
        if prevChild.TargetType = newChild.TargetType then
            if newChild.TargetType.IsAssignableFrom(typeof<NavigationPage>) then
                canReuseNavigationPage prevChild newChild
            else
                true
        else
            false

    /// Checks whether an underlying NavigationPage control can be reused given the previous and new view elements
    //
    // NavigationPage can be reused only if the pages don't change their type (added/removed pages don't prevent reuse)
    // E.g. If the first page switch from ContentPage to TabbedPage, the NavigationPage can't be reused.
    and internal canReuseNavigationPage (prevChild:ViewElement) (newChild:ViewElement) =
        let prevPages = prevChild.TryGetAttribute<ViewElement[]>("Pages")
        let newPages = newChild.TryGetAttribute<ViewElement[]>("Pages")

        match prevPages, newPages with
        | ValueSome prevPages, ValueSome newPages -> (prevPages, newPages) ||> Seq.forall2 canReuseChild
        | _, _ -> true

    /// Update a control given the previous and new view elements
    let inline updateChild (prevChild:ViewElement) (newChild:ViewElement) targetChild = 
        newChild.UpdateIncremental(prevChild, targetChild)

    /// Convert a sequence to an array, maintaining the object identity of arrays
    let seqToArray (itemsSource:seq<'T>) =
        match itemsSource with 
        | :? ('T []) as arr -> arr 
        | es -> Array.ofSeq es 

    /// Convert a sequence to an IList, maintaining the object identity of any IList
    let seqToIListUntyped (itemsSource:seq<'T>) =
        match itemsSource with 
        | :? System.Collections.IList as arr -> arr
        | es -> (Array.ofSeq es :> System.Collections.IList)

    /// Incremental list maintenance: given a collection, and a previous version of that collection, perform
    /// a reduced number of clear/add/remove/insert operations
    let updateCollectionGeneric
           (prevCollOpt: 'T[] voption) 
           (collOpt: 'T[] voption) 
           (targetColl: IList<'TargetT>) 
           (create: 'T -> 'TargetT)
           (attach: 'T voption -> 'T -> 'TargetT -> unit) // adjust attached properties
           (canReuse : 'T -> 'T -> bool) // Used to check if reuse is possible
           (update: 'T -> 'T -> 'TargetT -> unit) // Incremental element-wise update, only if element reuse is allowed
        =
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> targetColl.Clear()
        | _, ValueSome coll ->
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                // Remove the excess targetColl
                while (targetColl.Count > coll.Length) do
                    targetColl.RemoveAt (targetColl.Count - 1)

                // Count the existing targetColl
                // Unused variable n' introduced as a temporary workaround for https://github.com/fsprojects/Fabulous/issues/343
                let n' = targetColl.Count
                let n = targetColl.Count

                // Adjust the existing targetColl and create the new targetColl
                for i in 0 .. coll.Length-1 do
                    let newChild = coll.[i]
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < n -> ValueSome coll.[i] | _ -> ValueNone
                    let prevChildOpt, targetChild = 
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            let mustCreate = (i >= n || match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (canReuse prevChild newChild))
                            if mustCreate then
                                let targetChild = create newChild
                                if i >= n then
                                    targetColl.Insert(i, targetChild)
                                else
                                    targetColl.[i] <- targetChild
                                ValueNone, targetChild
                            else
                                let targetChild = targetColl.[i]
                                update prevChildOpt.Value newChild targetChild
                                prevChildOpt, targetChild
                        else
                            prevChildOpt, targetColl.[i]
                    attach prevChildOpt newChild targetChild


    // The public API for extensions to define their incremental update logic
    type ViewElement with

        /// Update an event handler on a target control, given a previous and current view element description
        member inline source.UpdateEvent(prevOpt: ViewElement voption, attribKey: AttributeKey<'T>, targetEvent: IEvent<'T,'Args>) = 
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<'T>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<'T>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> targetEvent.RemoveHandler(prevValue); targetEvent.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> targetEvent.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> targetEvent.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        /// Update a primitive value on a target control, given a previous and current view element description
        member inline source.UpdatePrimitive(prevOpt: ViewElement voption, target: 'Target, attribKey: AttributeKey<'T>, setter: 'Target -> 'T -> unit, ?defaultValue: 'T) = 
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<'T>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<'T>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome newValue when prevValue = newValue -> ()
            | _, ValueSome newValue -> setter target newValue
            | ValueSome _, ValueNone -> setter target (defaultArg defaultValue Unchecked.defaultof<_>)
            | ValueNone, ValueNone -> ()

        /// Recursively update a nested view element on a target control, given a previous and current view element description
        member inline source.UpdateElement(prevOpt: ViewElement voption, target: 'Target, attribKey: AttributeKey<ViewElement>, getter: 'Target -> 'T, setter: 'Target -> 'T -> unit) = 
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<ViewElement>(attribKey)
            let valueOpt = source.TryGetAttributeKeyed<ViewElement>(attribKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, getter target)
            | _, ValueSome newChild -> setter target (newChild.Create() :?> 'T)
            | ValueSome _, ValueNone -> setter target null
            | ValueNone, ValueNone -> ()

        /// Recursively update a collection of nested view element on a target control, given a previous and current view element description
        member inline source.UpdateElementCollection(prevOpt: ViewElement voption, attribKey: AttributeKey<seq<ViewElement>>, targetCollection: IList<'T>)  =
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<_>(attribKey)
            let collOpt = source.TryGetAttributeKeyed<_>(attribKey)
            updateCollectionGeneric (ValueOption.map seqToArray prevCollOpt) (ValueOption.map seqToArray collOpt) targetCollection (fun x -> x.Create() :?> 'T) (fun _ _ _ -> ()) canReuseChild updateChild

    /// Update the items in a ListView control, given previous and current view elements
    let internal updateListViewItems (prevCollOpt: seq<'T> voption) (collOpt: seq<'T> voption) (target: Xamarin.Forms.ListView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListElementData> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListElementData>()
                target.ItemsSource <- oc
                oc
        updateCollectionGeneric (ValueOption.map seqToArray prevCollOpt) (ValueOption.map seqToArray collOpt) targetColl ListElementData (fun _ _ _ -> ()) canReuseChild (fun _ curr target -> target.Key <- curr) 

    let private updateListGroupData (_prevShortName: string, _prevKey, prevColl: ViewElement[]) (currShortName: string, currKey, currColl: ViewElement[]) (target: ListGroupData) =
        target.ShortName <- currShortName
        target.Key <- currKey
        updateCollectionGeneric (ValueSome prevColl) (ValueSome currColl) target ListElementData (fun _ _ _ -> ()) canReuseChild (fun _ curr target -> target.Key <- curr) 

    /// Update the items in a GroupedListView control, given previous and current view elements
    let internal updateListViewGroupedItems (prevCollOpt: (string * ViewElement * ViewElement[])[] voption) (collOpt: (string * ViewElement * ViewElement[])[] voption) (target: Xamarin.Forms.ListView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListGroupData> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListGroupData>()
                target.ItemsSource <- oc
                oc
        updateCollectionGeneric prevCollOpt collOpt targetColl ListGroupData (fun _ _ _ -> ()) (fun (_, prevKey, _) (_, currKey, _) -> canReuseChild prevKey currKey) updateListGroupData

    /// Update the ShowJumpList property of a GroupedListView control, given previous and current view elements
    let internal updateListViewGroupedShowJumpList (prevOpt: bool voption) (currOpt: bool voption) (target: Xamarin.Forms.ListView) =
        let updateTarget enableJumpList = target.GroupShortNameBinding <- (if enableJumpList then new Binding("ShortName") else null)

        match (prevOpt, currOpt) with
        | ValueNone, ValueSome curr -> updateTarget curr
        | ValueSome prev, ValueSome curr when prev <> curr -> updateTarget curr
        | ValueSome _, ValueNone -> target.GroupShortNameBinding <- null
        | _, _ -> ()

    /// Update the items of a TableView control, given previous and current view elements
    let internal updateTableViewItems (prevCollOpt: (string * 'T[])[] voption) (collOpt: (string * 'T[])[] voption) (target: Xamarin.Forms.TableView) = 
        let create (desc: ViewElement) = (desc.Create() :?> Cell)

        match prevCollOpt with
        | ValueNone -> ()
        | ValueSome _ -> target.Root <- TableRoot()

        updateCollectionGeneric prevCollOpt collOpt target.Root 
            (fun (s, es) -> let section = TableSection(s) in section.Add(Seq.map create es); section) 
            (fun _ _ _ -> ()) // attach
            (fun _ _ -> true) // canReuse
            (fun (_prevTitle,prevChild) (newTitle, newChild) target ->
                target.Title <- newTitle
                updateCollectionGeneric (ValueSome prevChild) (ValueSome newChild) target create (fun _ _ _ -> ()) canReuseChild updateChild) 

    /// Update the resources of a control, given previous and current view elements describing the resources
    let internal updateResources (prevCollOpt: (string * obj) list voption) (collOpt: (string * obj) list voption) (target: Xamarin.Forms.VisualElement) = 
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
            let targetColl = target.Resources
            let coll = Array.ofSeq coll
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for (key, newChild) in coll do 
                    if targetColl.ContainsKey(key) then 
                        let prevChildOpt = 
                            match prevCollOpt with 
                            | ValueNone -> ValueNone 
                            | ValueSome prevColl -> 
                                match prevColl |> List.tryFind(fun (prevKey, _) -> key = prevKey) with 
                                | Some (_, prevChild) -> ValueSome prevChild
                                | None -> ValueNone
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            targetColl.Add(key, newChild)                            
                        else
                            targetColl.[key] <- newChild
                    else
                        targetColl.Remove(key) |> ignore
                for (KeyValue(key, _newChild)) in targetColl do 
                   if not (coll |> Array.exists(fun (key2, _v2) -> key = key2)) then 
                       targetColl.Remove(key) |> ignore

    /// Update the style sheets of a control, given previous and current view elements describing them
    // Note, style sheets can't be removed
    // Note, style sheets are compared by object identity
    let internal updateStyleSheets (prevCollOpt: list<StyleSheet> voption) (collOpt: list<StyleSheet> voption) (target: Xamarin.Forms.VisualElement) = 
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
            let targetColl = target.Resources
            let coll = Array.ofSeq coll
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for styleSheet in coll do 
                    let prevChildOpt = 
                        match prevCollOpt with 
                        | ValueNone -> None 
                        | ValueSome prevColl -> prevColl |> List.tryFind(fun prevStyleSheet -> identical styleSheet prevStyleSheet)
                    match prevChildOpt with 
                    | None -> targetColl.Add(styleSheet)                            
                    | Some _ -> ()
                match prevCollOpt with 
                | ValueNone -> ()
                | ValueSome prevColl -> 
                    for prevStyleSheet in prevColl do 
                        let childOpt = 
                            match prevCollOpt with 
                            | ValueNone -> None 
                            | ValueSome prevColl -> prevColl |> List.tryFind(fun styleSheet -> identical styleSheet prevStyleSheet)
                        match childOpt with 
                        | None -> 
                            eprintfn "**** WARNING: style sheets may not be removed, and are compared by object identity, so should be created independently of your update or view functions ****"
                        | Some _ -> ()

    /// Update the styles of a control, given previous and current view elements describing them
    // Note, styles can't be removed
    // Note, styles are compared by object identity
    let internal updateStyles (prevCollOpt: Style list voption) (collOpt: Style list voption) (target: Xamarin.Forms.VisualElement) = 
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> target.Resources.Clear()
        | _, ValueSome coll ->
            let targetColl = target.Resources
            let coll = Array.ofSeq coll
            if (coll = null || coll.Length = 0) then
                targetColl.Clear()
            else
                for styleSheet in coll do 
                    let prevChildOpt = 
                        match prevCollOpt with 
                        | ValueNone -> None 
                        | ValueSome prevColl -> prevColl |> Seq.tryFind(fun prevStyleSheet -> identical styleSheet prevStyleSheet)
                    match prevChildOpt with 
                    | None -> targetColl.Add(styleSheet)                            
                    | Some _ -> ()
                match prevCollOpt with 
                | ValueNone -> ()
                | ValueSome prevColl -> 
                    for prevStyle in prevColl do 
                        let childOpt = 
                            match prevCollOpt with 
                            | ValueNone -> None 
                            | ValueSome prevColl -> prevColl |> Seq.tryFind(fun style-> identical style prevStyle)
                        match childOpt with 
                        | None -> 
                            eprintfn "**** WARNING: styles may not be removed, and are compared by object identity. They should be created independently of your update or view functions ****"
                        | Some _ -> ()

    /// Update the style class of a control, given previous and current view elements 
    let internal updateStyleClass (prevCollOpt: IList<string> voption) (collOpt: IList<string> voption) (target: Xamarin.Forms.VisualElement) =
        match prevCollOpt, collOpt with 
        | ValueNone, ValueNone -> ()
        | ValueSome prevColl, ValueSome newColl when prevColl = newColl -> ()
        | _, ValueNone -> target.StyleClass <- null
        | _, ValueSome coll -> target.StyleClass <- coll

    /// Incremental NavigationPage maintenance: push/pop the right pages
    let internal updateNavigationPages (prevCollOpt: ViewElement[] voption)  (collOpt: ViewElement[] voption) (target: NavigationPage) attach =
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
        | _, ValueSome coll ->
            let create (desc: ViewElement) = (desc.Create() :?> Page)
            if (coll = null || coll.Length = 0) then
                failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
            else
                // Count the existing pages
                let prevCount = target.Pages |> Seq.length
                let newCount = coll.Length
                printfn "Updating NavigationPage, prevCount = %d, newCount = %d" prevCount newCount

                // Remove the excess pages
                if newCount = 1 && prevCount > 1 then 
                    printfn "Updating NavigationPage --> PopToRootAsync" 
                    target.PopToRootAsync() |> ignore
                elif prevCount > newCount then
                    for i in prevCount - 1 .. -1 .. newCount do 
                        printfn "PopAsync, page number %d" i
                        target.PopAsync () |> ignore
                
                let n = min prevCount newCount
                // Push and/or adjust pages
                for i in 0 .. newCount-1 do
                    let newChild = coll.[i]
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < coll.Length && i < n -> ValueSome coll.[i] | _ -> ValueNone
                    let prevChildOpt, targetChild = 
                        if (match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (identical prevChild newChild)) then
                            let mustCreate = (i >= n || match prevChildOpt with ValueNone -> true | ValueSome prevChild -> not (canReuseChild prevChild newChild))
                            if mustCreate then
                                //printfn "Creating child %d, prevChildOpt = %A, newChild = %A" i prevChildOpt newChild
                                let targetChild = create newChild
                                if i >= n then
                                    printfn "PushAsync, page number %d" i
                                    target.PushAsync(targetChild) |> ignore
                                else
                                    failwith "Error while updating NavigationPage pages: can't change type of one of the pages in the navigation chain during navigation"
                                ValueNone, targetChild
                            else
                                printfn "Adjust page number %d" i
                                let targetChild = target.Pages |> Seq.item i
                                updateChild prevChildOpt.Value newChild targetChild
                                prevChildOpt, targetChild
                        else
                            //printfn "Skipping child %d" i
                            let targetChild = target.Pages |> Seq.item i
                            prevChildOpt, targetChild
                    attach prevChildOpt newChild targetChild

    /// Update the OnSizeAllocated callback of a control, given previous and current values
    let internal updateOnSizeAllocated prevValueOpt valueOpt (target: obj) = 
        let target = (target :?> CustomContentPage)
        match prevValueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.RemoveHandler(f)
        match valueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.AddHandler(f)

    /// Update the Command and CanExecute properties of a control, given previous and current values
    let inline internal updateCommand prevCommandValueOpt commandValueOpt argTransform setter  prevCanExecuteValueOpt canExecuteValueOpt target = 
        match prevCommandValueOpt, prevCanExecuteValueOpt, commandValueOpt, canExecuteValueOpt with 
        | ValueNone, ValueNone, ValueNone, ValueNone -> ()
        | ValueSome prevf, ValueNone, ValueSome f, ValueNone when identical prevf f -> ()
        | ValueSome prevf, ValueSome prevx, ValueSome f, ValueSome x when identical prevf f && prevx = x -> ()
        | _, _, ValueNone, _ -> setter target null
        | _, _, ValueSome f, ValueNone -> setter target (makeCommand (fun () -> f (argTransform target)))
        | _, _, ValueSome f, ValueSome k -> setter target (makeCommandCanExecute (fun () -> f (argTransform target)) k)

    /// Update the CurrentPage of a control, given previous and current values
    let internal updateCurrentPage<'a when 'a :> Xamarin.Forms.Page and 'a : null> prevValueOpt valueOpt (target: obj) =
        let control = target :?> Xamarin.Forms.MultiPage<'a>
        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome _, ValueNone -> control.CurrentPage <- null
        | _, ValueSome curr -> control.CurrentPage <- control.Children.[curr]

    /// Update the Minium and Maximum values of a slider, given previous and current values
    let internal updateSliderMinimumMaximum prevValueOpt valueOpt (target: obj) =
        let control = target :?> Xamarin.Forms.Slider
        let defaultValue = (0.0, 1.0)
        let updateFunc (prevMinimum, prevMaximum) (newMinimum, newMaximum) =
            if newMinimum > prevMaximum then
                control.Maximum <- newMaximum
                control.Minimum <- newMinimum
            else
                control.Minimum <- newMinimum
                control.Maximum <- newMaximum

        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome prev, ValueSome curr -> updateFunc prev curr
        | ValueSome prev, ValueNone -> updateFunc prev defaultValue
        | ValueNone, ValueSome curr -> updateFunc defaultValue curr

    /// Update the Minium and Maximum values of a stepper, given previous and current values
    let internal updateStepperMinimumMaximum prevValueOpt valueOpt (target: obj) =
        let control = target :?> Xamarin.Forms.Stepper
        let defaultValue = (0.0, 1.0)
        let updateFunc (prevMinimum, prevMaximum) (newMinimum, newMaximum) =
            if newMinimum > prevMaximum then
                control.Maximum <- newMaximum
                control.Minimum <- newMinimum
            else
                control.Minimum <- newMinimum
                control.Maximum <- newMaximum

        match prevValueOpt, valueOpt with
        | ValueNone, ValueNone -> ()
        | ValueSome prev, ValueSome curr when prev = curr -> ()
        | ValueSome prev, ValueSome curr -> updateFunc prev curr
        | ValueSome prev, ValueNone -> updateFunc prev defaultValue
        | ValueNone, ValueSome curr -> updateFunc defaultValue curr

    /// Update the attached NavigationPage.TitleView property of a Page, given previous and current values
    let internal updatePageTitleView (prevOpt: ViewElement voption) (currOpt: ViewElement voption) (target: Page) =
        match prevOpt, currOpt with
        | ValueSome prev, ValueSome curr when identical prev curr -> ()
        | ValueSome prev, ValueSome curr when canReuseChild prev curr ->
            updateChild prev curr (NavigationPage.GetTitleView(target))
        | _, ValueSome curr ->
            NavigationPage.SetTitleView(target, (curr.Create() :?> Xamarin.Forms.View))
        | ValueSome _, ValueNone ->
            NavigationPage.SetTitleView(target, null)
        | _, _ -> ()

    /// Update the AcceleratorProperty of a MenuItem, given previous and current Accelerator
    let internal updateAccelerator prevValue currValue (target: Xamarin.Forms.MenuItem) =
        match prevValue, currValue with
        | ValueNone, ValueNone -> ()
        | ValueSome prevVal, ValueSome newVal when prevVal = newVal -> ()
        | _, ValueNone -> Xamarin.Forms.MenuItem.SetAccelerator(target, null)
        | _, ValueSome newVal -> Xamarin.Forms.MenuItem.SetAccelerator(target, makeAccelerator newVal)

    /// Trigger ScrollView.ScrollToAsync if needed, given the current values
    let internal triggerScrollToAsync (currValue: (float * float * AnimationKind) voption) (target: Xamarin.Forms.ScrollView) =
        match currValue with
        | ValueSome (x, y, animationKind) when x <> target.ScrollX || y <> target.ScrollY ->
            let animated =
                match animationKind with
                | Animated -> true
                | NotAnimated -> false
            target.ScrollToAsync(x, y, animated) |> ignore
        | _ -> ()

    /// Check if two LayoutOptions are equal
    let internal equalLayoutOptions (x:Xamarin.Forms.LayoutOptions) (y:Xamarin.Forms.LayoutOptions)  =
        x.Alignment = y.Alignment && x.Expands = y.Expands

    /// Check if two Thickness values are equal
    let internal equalThickness (x:Xamarin.Forms.Thickness) (y:Xamarin.Forms.Thickness)  =
        x.Bottom = y.Bottom && x.Top = y.Top && x.Left = y.Left && x.Right = y.Right

    /// Try and find a specific ListView item
    let tryFindListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ListElementData as item -> 
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListElementData> 
            // POSSIBLE IMPROVEMENT: don't use a linear search
            items |> Seq.tryFindIndex (fun item2 -> identical item.Key item2.Key)
        | _ -> None

    let private tryFindGroupedListViewItemIndex (items: System.Collections.Generic.IList<ListGroupData>) (item: ListElementData) =
        // POSSIBLE IMPROVEMENT: don't use a linear search
        items 
        |> Seq.indexed 
        |> Seq.tryPick (fun (i,items2) -> 
            // POSSIBLE IMPROVEMENT: don't use a linear search
            items2 
            |> Seq.indexed 
            |> Seq.tryPick (fun (j,item2) -> if identical item.Key item2.Key then Some (i,j) else None))

    /// Try and find a specific item in a GroupedListView 
    let tryFindGroupedListViewItemOrGroupItem (sender: obj) (item: obj) = 
        match item with 
        | null -> None
        | :? ListGroupData as item ->
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData> 
            // POSSIBLE IMPROVEMENT: don't use a linear search
            items 
            |> Seq.indexed 
            |> Seq.tryPick (fun (i, item2) -> if identical item.Key item2.Key then Some (i, None) else None)
        | :? ListElementData as item ->
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData> 
            tryFindGroupedListViewItemIndex items item
            |> (function
                | None -> None
                | Some (i, j) -> Some (i, Some j))
        | _ -> None

    /// Try and find a specific GroupedListView item
    let tryFindGroupedListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ListElementData as item ->
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData> 
            tryFindGroupedListViewItemIndex items item
        | _ -> None
