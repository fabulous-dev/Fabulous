namespace Elmish.XamarinForms.DynamicViews

open System
open System.Collections.Generic
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms

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

type XamlElementCell() = 
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
    inherit ListView(ItemTemplate=DataTemplate(typeof<XamlElementCell>))

type CustomGroupListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<XamlElementCell>), GroupHeaderTemplate=DataTemplate(typeof<XamlElementCell>))

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

    let makeCommand f =
        let ev = Event<_,_>()
        { new ICommand with
            member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member x.CanExecute _ = true
            member x.Execute _ = f() }

    let makeImageSource (image: string) = ImageSource.op_Implicit image

    let makeFileImageSource (image: string) = FileImageSource.op_Implicit image

    let makeThickness (v: obj) = 
       match v with 
       | :? double as f -> Thickness.op_Implicit f
       | :? Thickness as v -> v
       | _ -> failwithf "makeThickness: invalid argument %O" v

    let makeGridLength (v: obj) = 
       match v with 
       | :? string as s when s = "*" -> GridLength.Star
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

    let canReuseDefault (prevChild:XamlElement) (newChild:XamlElement) = (prevChild.TargetType = newChild.TargetType)
    let updateDefault (prevChild:XamlElement) (newChild:XamlElement) targetChild = newChild.UpdateIncremental(prevChild, targetChild)

    // Incremental list maintenance: given a collection, and a previous version of that collection, perform
    // a reduced number of clear/add/remove/insert operations
    let updateIList
           (prevCollOpt: 'T[] uoption) 
           (collOpt: 'T[] uoption) 
           (targetColl: IList<'TargetT>) 
           (create: 'T -> 'TargetT)
           (attach: 'T uoption -> 'T -> 'TargetT -> unit) // adjust attached properties
           (canReuse : 'T -> 'T -> bool) // Used to check if reuse is possible
           (update: 'T -> 'T -> 'TargetT -> unit) // Incremental element-wise update, only if element reuse is allowed
        =
          match prevCollOpt, collOpt with 
          | USome prevColl, USome newColl when System.Object.ReferenceEquals(prevColl, newColl) -> ()
          | _, UNone -> targetColl.Clear()
          | _, USome coll ->
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
                    let prevChildOpt = match prevCollOpt with UNone -> UNone | USome coll when i < coll.Length && i < n -> USome coll.[i] | _ -> UNone
                    let prevChildOpt, targetChild = 
                        if (match prevChildOpt with UNone -> true | USome prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                            let mustCreate = (i >= n || match prevChildOpt with UNone -> true | USome prevChild -> not (canReuse prevChild newChild))
                            if mustCreate then
                                //printfn "Creating child %d, prevChildOpt = %A, newChild = %A" i prevChildOpt newChild
                                let targetChild = create newChild
                                if i >= n then
                                    targetColl.Insert(i, targetChild)
                                else
                                    targetColl.[i] <- targetChild
                                UNone, targetChild
                            else
                                //printfn "Applying child %d, prevChild = %A, newChild = %A, (prevChild == newChild) = %A" i prevChildOpt.Value newChild (obj.ReferenceEquals(prevChildOpt.Value, newChild))
                                let targetChild = targetColl.[i]
                                update prevChildOpt.Value newChild targetChild
                                prevChildOpt, targetChild
                        else
                            //printfn "Skipping child %d" i
                            prevChildOpt, targetColl.[i]
                    attach prevChildOpt newChild targetChild


    let updateListViewItems (prevCollOpt: 'T[] uoption) (coll: 'T[] uoption) (target: Xamarin.Forms.ListView) = 
        let oc = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListElementData<'T>> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListElementData<'T>>()
                target.ItemsSource <- oc
                oc
        updateIList prevCollOpt coll oc ListElementData (fun _ _ _ -> ()) (fun _ _ -> false) (fun _ _ _ -> failwith "no element reuse") 

    let updateListViewGroupedItems (prevCollOpt: ('T * 'T[])[] uoption) (coll: ('T * 'T[])[] uoption) (target: Xamarin.Forms.ListView) = 
        let oc = 
            match target.ItemsSource with 
            | :? ObservableCollection<ListGroupData<'T>> as oc -> oc
            | _ -> 
                let oc = ObservableCollection<ListGroupData<'T>>()
                target.ItemsSource <- oc
                oc
        updateIList prevCollOpt coll oc ListGroupData (fun _ _ _ -> ()) (fun _ _ -> false) (fun _ _ _ -> failwith "no element reuse")

    let updateTableViewItems (prevCollOpt: (string * 'T[])[] uoption) (coll: (string * 'T[])[] uoption) (target: Xamarin.Forms.TableView) = 
        let create (desc: XamlElement) = (desc.Create() :?> Cell)
        let root = 
            match target.Root with 
            | null -> 
                let v = TableRoot()
                target.Root <- v
                v
            | v -> v
        updateIList prevCollOpt coll root 
            (fun (s, es) -> let section = TableSection(s) in section.Add(Seq.map create es); section) 
            (fun _ _ _ -> ()) // attach
            (fun _ _ -> true) // canReuse
            (fun (prevTitle,prevChild) (newTitle, newChild) target -> 
                updateIList (USome prevChild) (USome newChild) target create (fun _ _ _ -> ()) canReuseDefault updateDefault) 


    /// Incremental NavigationPage maintenance: push/pop the right pages
    let updateNavigationPages (prevCollOpt: XamlElement[] uoption)  (collOpt: XamlElement[] uoption) (target: NavigationPage) attach =
          let create (desc: XamlElement) = (desc.Create() :?> Page)
          match prevCollOpt, collOpt with 
          | USome prevColl, USome newColl when System.Object.ReferenceEquals(prevColl, newColl) -> ()
          | _, UNone -> failwith "Error while updating NavigationPage pages: the pages collection should never be empty for a NavigationPage"
          | _, USome coll ->
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
                    let prevChildOpt = match prevCollOpt with UNone -> UNone | USome coll when i < coll.Length && i < n -> USome coll.[i] | _ -> UNone
                    let prevChildOpt, targetChild = 
                        if (match prevChildOpt with UNone -> true | USome prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                            let mustCreate = (i >= n || match prevChildOpt with UNone -> true | USome prevChild -> not (canReuseDefault prevChild newChild))
                            if mustCreate then
                                //printfn "Creating child %d, prevChildOpt = %A, newChild = %A" i prevChildOpt newChild
                                let targetChild = create newChild
                                if i >= n then
                                    printfn "PushAsync, page number %d" i
                                    target.PushAsync(targetChild) |> ignore
                                else
                                    failwith "Error while updating NavigationPage pages: can't change type of one of the pages in the navigation chain during navigation"
                                UNone, targetChild
                            else
                                printfn "Adjust page number %d" i
                                let targetChild = target.Pages |> Seq.item i
                                updateDefault prevChildOpt.Value newChild targetChild
                                prevChildOpt, targetChild
                        else
                            //printfn "Skipping child %d" i
                            let targetChild = target.Pages |> Seq.item i
                            prevChildOpt, targetChild
                    attach prevChildOpt newChild targetChild

    let updateOnSizeAllocated prevValueOpt valueOpt (target: obj) = 
        let target = (target :?> CustomContentPage)
        match prevValueOpt with UNone -> () | USome f -> target.SizeAllocated.RemoveHandler(f)
        match valueOpt with UNone -> () | USome f -> target.SizeAllocated.AddHandler(f)

    let equalLayoutOptions (x:Xamarin.Forms.LayoutOptions) (y:Xamarin.Forms.LayoutOptions)  =
        x.Alignment = y.Alignment && x.Expands = y.Expands

    let equalThickness (x:Xamarin.Forms.Thickness) (y:Xamarin.Forms.Thickness)  =
        x.Bottom = y.Bottom && x.Top = y.Top && x.Left = y.Left && x.Right = y.Right

