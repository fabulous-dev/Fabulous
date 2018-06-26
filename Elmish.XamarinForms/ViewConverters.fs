namespace Elmish.XamarinForms.DynamicViews

open System
open System.Collections.Generic
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

module UOption = 
    let inline map f x = match x with ValueNone -> ValueNone | ValueSome v -> ValueSome (f v)

[<AllowNullLiteral>]
type IListElement = 
    abstract Key : obj

[<AllowNullLiteral>]
type ListElementData<'T>(key:'T) = 
    interface IListElement with member x.Key = box key
    member x.Key = key

[<AllowNullLiteral>]
type ListGroupData<'T>(key:'T, coll: 'T[]) = 
    inherit System.Collections.Generic.List<ListElementData<'T>>(Seq.map ListElementData coll)
    interface IListElement with member x.Key = box key
    member x.Key = key
    member x.Items = coll


type ViewElementCell() = 
    inherit ViewCell()

    let mutable modelOpt = None

    override x.OnBindingContextChanged () =
        base.OnBindingContextChanged ()
        match x.BindingContext with
        | :? IListElement as data -> 
            let newModel = data.Key
            match modelOpt with 
            | Some prev -> 
                let ty = newModel.GetType()
                let res = ty.InvokeMember("UpdateIncremental",(BindingFlags.InvokeMethod ||| BindingFlags.Public ||| BindingFlags.Instance), null, newModel, [| box prev; box x.View |] )
                modelOpt <- None
                ignore res
            | None -> 
                let ty = newModel.GetType()
                let res = ty.InvokeMember("Create",(BindingFlags.InvokeMethod ||| BindingFlags.Public ||| BindingFlags.Instance), null, newModel, [| |] )
                match res with 
                | :? View as v -> 
                    x.View <- v
                | _ -> 
                    failwithf "The cells of a ListView must each be some kind of 'View' and not a '%A'" (res.GetType())
                modelOpt <- Some newModel
        | _ -> 
            modelOpt <- None

type CustomListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<ViewElementCell>))

type CustomGroupListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<ViewElementCell>), GroupHeaderTemplate=DataTemplate(typeof<ViewElementCell>))

type CustomContentPage() as self = 
    inherit ContentPage()
    do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, true)
    let sizeAllocated: Event<double * double> = Event<_>() 

    member __.SizeAllocated = sizeAllocated.Publish

    override this.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(width, height)


[<AutoOpen>]
module Converters =
    open System.Collections.ObjectModel
    open Xamarin.Forms
    open Xamarin.Forms.StyleSheets

    let makeCommand f =
        let ev = Event<_,_>()
        { new ICommand with
            member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member x.CanExecute _ = true
            member x.Execute _ = f() }

    let makeCommandCanExecute f k =
        let ev = Event<_,_>()
        { new ICommand with
            member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member x.CanExecute _ = k
            member x.Execute _ = f() }

    let makeImageSource (image: string) = ImageSource.op_Implicit image

    let makeAccelerator (accelerator: string) = Accelerator.op_Implicit accelerator

    let makeFileImageSource (image: string) = FileImageSource.op_Implicit image

    let makeThickness (v: obj) = 
       match v with 
       | :? double as f -> Thickness.op_Implicit f
       | :? Thickness as v -> v
       | _ -> failwithf "makeThickness: invalid argument %O" v

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

    let makeFontSize (v: obj) = 
        match box v with 
        | :? string as s -> (FontSizeConverter().ConvertFromInvariantString(s) :?> double)
        | :? int as i -> double i
        | :? double as v -> v
        | _ -> System.Convert.ToDouble(v)

    let identical (x: 'T) (y:'T) = System.Object.ReferenceEquals(x, y)

    let canReuseChild (prevChild:ViewElement) (newChild:ViewElement) = 
        (prevChild.TargetType = newChild.TargetType)

    let updateChild (prevChild:ViewElement) (newChild:ViewElement) targetChild = 
        newChild.UpdateIncremental(prevChild, targetChild)

    type Chunks<'T> = 
        | Chunk of 'T[]
        | Chunks of Chunks<'T> * Chunks<'T>

    // Incremental list maintenance: given a collection, and a previous version of that collection, perform
    // a reduced number of clear/add/remove/insert operations
    let updateIList
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
                let n = targetColl.Count

                // Adjust the existing targetColl and create the new targetColl
                for i in 0 .. coll.Length-1 do
                    let newChild = coll.[i]
                    let prevChildOpt = match prevCollOpt with ValueNone -> ValueNone | ValueSome coll when i < coll.Length && i < n -> ValueSome coll.[i] | _ -> ValueNone
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


    let seqToArray (itemsSource:seq<'T>) =
        match itemsSource with 
        | :? ('T []) as arr -> arr 
        | es -> Array.ofSeq es 

    let seqToIList (itemsSource:seq<'T>) =
        match itemsSource with 
        | :? ('T []) as arr -> (arr :> System.Collections.IList) 
        | es -> (Array.ofSeq es :> System.Collections.IList)

    let updateListViewItems (prevCollOpt: seq<'T> voption) (collOpt: seq<'T> voption) (target: Xamarin.Forms.ListView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListElementData<'T>> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListElementData<'T>>()
                target.ItemsSource <- oc
                oc
        updateIList (UOption.map seqToArray prevCollOpt) (UOption.map seqToArray collOpt) targetColl ListElementData (fun _ _ _ -> ()) (fun _ _ -> false) (fun _ _ _ -> failwith "no element reuse") 

    let updateListViewGroupedItems (prevCollOpt: ('T * 'T[])[] voption) (collOpt: ('T * 'T[])[] voption) (target: Xamarin.Forms.ListView) = 
        let targetColl = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListGroupData<'T>> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListGroupData<'T>>()
                target.ItemsSource <- oc
                oc
        updateIList prevCollOpt collOpt targetColl ListGroupData (fun _ _ _ -> ()) (fun _ _ -> false) (fun _ _ _ -> failwith "no element reuse")

    let updateTableViewItems (prevCollOpt: (string * 'T[])[] voption) (collOpt: (string * 'T[])[] voption) (target: Xamarin.Forms.TableView) = 
        let create (desc: ViewElement) = (desc.Create() :?> Cell)
        let root = 
            match target.Root with 
            | null -> 
                let v = TableRoot()
                target.Root <- v
                v
            | v -> v
        updateIList prevCollOpt collOpt root 
            (fun (s, es) -> let section = TableSection(s) in section.Add(Seq.map create es); section) 
            (fun _ _ _ -> ()) // attach
            (fun _ _ -> true) // canReuse
            (fun (prevTitle,prevChild) (newTitle, newChild) target -> 
                updateIList (ValueSome prevChild) (ValueSome newChild) target create (fun _ _ _ -> ()) canReuseChild updateChild) 

    let updateResources (prevCollOpt: (string * obj) list voption) (collOpt: (string * obj) list voption) (target: Xamarin.Forms.VisualElement) = 
        let targetColl = target.Resources
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> targetColl.Clear()
        | _, ValueSome coll ->
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
                for (KeyValue(key, newChild)) in targetColl do 
                   if not (coll |> Array.exists(fun (key2, v2) -> key = key2)) then 
                       targetColl.Remove(key) |> ignore


    // Note, style sheets can't be removed
    // Note, style sheets are compared by object identity
    let updateStyleSheets (prevCollOpt: list<StyleSheet> voption) (collOpt: list<StyleSheet> voption) (target: Xamarin.Forms.VisualElement) = 
        let targetColl = target.Resources
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> targetColl.Clear()
        | _, ValueSome coll ->
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

    // Note, styles can't be removed
    // Note, styles are compared by object identity
    let updateStyles (prevCollOpt: Style list voption) (collOpt: Style list voption) (target: Xamarin.Forms.VisualElement) = 
        let targetColl = target.Resources
        match prevCollOpt, collOpt with 
        | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
        | _, ValueNone -> targetColl.Clear()
        | _, ValueSome coll ->
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

    /// Incremental NavigationPage maintenance: push/pop the right pages
    let updateNavigationPages (prevCollOpt: ViewElement[] voption)  (collOpt: ViewElement[] voption) (target: NavigationPage) attach =
          let create (desc: ViewElement) = (desc.Create() :?> Page)
          match prevCollOpt, collOpt with 
          | ValueSome prevColl, ValueSome newColl when identical prevColl newColl -> ()
          | _, ValueNone -> failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
          | _, ValueSome coll ->
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

    let updateOnSizeAllocated prevValueOpt valueOpt (target: obj) = 
        let target = (target :?> CustomContentPage)
        match prevValueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.RemoveHandler(f)
        match valueOpt with ValueNone -> () | ValueSome f -> target.SizeAllocated.AddHandler(f)

    /// This links the Command and CanExecute properties
    let inline updateCommand prevCommandValueOpt commandValueOpt argTransform setter  prevCanExecuteValueOpt canExecuteValueOpt target = 
        match prevCommandValueOpt, prevCanExecuteValueOpt, commandValueOpt, canExecuteValueOpt with 
        | ValueNone, ValueNone, ValueNone, ValueNone -> ()
        | ValueSome prevf, ValueNone, ValueSome f, ValueNone when identical prevf f -> ()
        | ValueSome prevf, ValueSome prevx, ValueSome f, ValueSome x when identical prevf f && prevx = x -> ()
        | _, _, ValueNone, _ -> setter target null
        | _, _, ValueSome f, ValueNone -> setter target (makeCommand (fun () -> f (argTransform target)))
        | _, _, ValueSome f, ValueSome k -> setter target (makeCommandCanExecute (fun () -> f (argTransform target)) k)

    let equalLayoutOptions (x:Xamarin.Forms.LayoutOptions) (y:Xamarin.Forms.LayoutOptions)  =
        x.Alignment = y.Alignment && x.Expands = y.Expands

    let equalThickness (x:Xamarin.Forms.Thickness) (y:Xamarin.Forms.Thickness)  =
        x.Bottom = y.Bottom && x.Top = y.Top && x.Left = y.Left && x.Right = y.Right


    let tryFindListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ListElementData<ViewElement> as item -> 
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListElementData<ViewElement>> 
            // TODO: this linear search is needs improvement
            items |> Seq.tryFindIndex (fun item2 -> identical item.Key item2.Key)
        | _ -> None

    let tryFindGroupedListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ListGroupData<ViewElement> as item ->
            let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData<ViewElement>> 
            // TODO: this linear search is needs improvement
            items 
            |> Seq.indexed 
            |> Seq.tryPick (fun (i,items2) -> 
                 // TODO: this linear search is needs improvement
                items2 
                |> Seq.indexed 
                |> Seq.tryPick (fun (j,item2) -> if identical item.Key item2.Key then Some (i,j) else None))
        | _ -> None
