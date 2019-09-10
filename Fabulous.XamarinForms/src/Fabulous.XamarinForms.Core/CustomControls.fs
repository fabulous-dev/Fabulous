// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System
open System.ComponentModel

/// A custom control used to implement the 'textChanged' attribute on the EntryCell view element 
type CustomEntryCell() as self =
    inherit EntryCell()

    let mutable oldValue = ""
    let textChanged = Event<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>()

    do self.PropertyChanging.Add(
        fun args ->
            if args.PropertyName = "Text" then
                oldValue <- self.Text)

    do self.PropertyChanged.Add(
        fun args ->
            if args.PropertyName = "Text" then
                textChanged.Trigger(self, TextChangedEventArgs(oldValue, self.Text)))

    [<CLIEvent>] member __.TextChanged = textChanged.Publish

/// EventArgs for the SizeChanged event
type SizeChangedEventArgs(width: float, height: float) =
    inherit EventArgs()

    member __.Width = width
    member __.Height = height

/// Defines if the action should be animated or not
type AnimationKind =
    | Animated
    | NotAnimated

/// A custom data element for the ListView view element
[<AllowNullLiteral>]
type IListElement = 
    inherit INotifyPropertyChanged
    abstract Key : ViewElement

[<AllowNullLiteral>]
type IItemListElement = 
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

[<AllowNullLiteral>]
type ItemListElementData(key) = 
    let ev = new Event<_,_>()
    let mutable data = key
    
    interface IItemListElement with
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

type ContentViewElement() = 
    inherit ContentView()

    let mutable listElementOpt : IItemListElement option = None
    let mutable modelOpt : ViewElement option = None
    
    let createView (newModel: ViewElement) =
        match newModel.Create () with 
        | :? View as v -> v
        | x -> failwithf "The cells of a CollectionView must each be some kind of 'View' and not a '%A'" (x.GetType())

    member x.OnDataPropertyChanged = PropertyChangedEventHandler(fun _ args ->
        match args.PropertyName, listElementOpt, modelOpt with
        | "Key", Some curr, Some prevModel ->
            curr.Key.UpdateIncremental (prevModel, x.Content)
            modelOpt <- Some curr.Key
        | _ -> ()
    )

    override x.OnBindingContextChanged () =
        base.OnBindingContextChanged ()
        match x.BindingContext with
        | :? IItemListElement as curr -> 
            let newModel = curr.Key
            match listElementOpt with 
            | Some prev ->
                prev.PropertyChanged.RemoveHandler x.OnDataPropertyChanged
                curr.PropertyChanged.AddHandler x.OnDataPropertyChanged
                newModel.UpdateIncremental (prev.Key, x.Content)
            | None -> 
                curr.PropertyChanged.AddHandler x.OnDataPropertyChanged
                x.Content <- createView newModel

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

type CustomCollectionListView() = 
    inherit CollectionView(ItemTemplate=DataTemplate(typeof<ContentViewElement>))

type CustomCarouselView() = 
    inherit CarouselView(ItemTemplate=DataTemplate(typeof<ContentViewElement>))

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

/// DataTemplate that can inflate a View from a ViewElement instead of a Type
type ViewElementDataTemplate(viewElement: ViewElement) =
    inherit DataTemplate(Func<obj>(viewElement.Create))

/// A custom SearchHandler which exposes the overridable methods OnQueryChanged, OnQueryConfirmed and OnItemSelected as events
type CustomSearchHandler() =
    inherit SearchHandler(ItemTemplate=DataTemplate(typeof<ContentViewElement>))

    member val QueryChanged = ignore with get, set
    member val QueryConfirmed = ignore with get, set
    member val ItemSelected: obj -> unit = ignore with get, set

    override this.OnQueryChanged(oldValue, newValue) = this.QueryChanged (oldValue, newValue)
    override this.OnQueryConfirmed() = this.QueryConfirmed ()
    override this.OnItemSelected(item) = this.ItemSelected item

type CustomEffect() =
    member val Name = "" with get, set