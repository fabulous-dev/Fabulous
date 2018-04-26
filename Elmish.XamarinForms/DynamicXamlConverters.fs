namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Collections.Generic
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms

[<Struct>]
type StructOption<'T> = 
    | USome of 'T | UNone
    member x.Value = match x with USome v -> v | UNone -> failwith "UNone has no value"

type uoption<'T> = StructOption<'T>

/// A description of a visual element
[<AllowNullLiteral>]
type XamlElement(targetType: Type, create: (unit -> obj), update: (XamlElement uoption -> XamlElement -> obj -> unit), attribs: Map<string, obj>) = 

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribs

    /// Apply initial settings to a freshly created visual element
    member x.Update (target: obj) = update UNone x target

    /// The differential update method implementation
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.UpdateMethod = update

    /// Differrentially update a visual element given the previous settings
    member x.UpdateIncremental(prev: XamlElement, target: obj) = 
        Debug.WriteLine (sprintf "Update %O" x.TargetType)
        update (USome prev) x target

    /// Update a different description to a similar visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.CreateMethod = create

    /// Create the UI element from the view description
    member x.Create() : obj =
        Debug.WriteLine (sprintf "Create %O" x.TargetType)
        let target = x.CreateMethod()
        x.Update(target)
        target

    /// Produce a new visual element with an adjusted attribute
    member x.WithAttribute(name: string, value: obj) = XamlElement(targetType, create, update, x.Attributes.Add(name, value))

    /// Produce a visual element from a visual element for a different type
    member x.Inherit(newTargetType, newCreate, newApply, newAttribs) = 
        let combinedAttribs = Map.ofArray(Array.append(Map.toArray attribs) newAttribs)
        XamlElement(newTargetType, newCreate, (fun prevOpt source target -> update prevOpt source target; newApply prevOpt source target), combinedAttribs)

    override x.ToString() = sprintf "%s(...)@%d" x.TargetType.Name (x.GetHashCode())


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

    let updateTableViewItems (prevCollOpt: (string * 'T[])[] uoption) (coll: (string * 'T[])[] uoption) (target: Xamarin.Forms.TableView) create canReuse update = 
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
                updateIList (USome prevChild) (USome newChild) target create (fun _ _ _ -> ()) canReuse update) 

    let equalLayoutOptions (x:Xamarin.Forms.LayoutOptions) (y:Xamarin.Forms.LayoutOptions)  =
        x.Alignment = y.Alignment && x.Expands = y.Expands

    let equalThickness (x:Xamarin.Forms.Thickness) (y:Xamarin.Forms.Thickness)  =
        x.Bottom = y.Bottom && x.Top = y.Top && x.Left = y.Left && x.Right = y.Right

