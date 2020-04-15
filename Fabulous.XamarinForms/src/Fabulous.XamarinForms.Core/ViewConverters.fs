// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Xamarin.Forms
open System
open System.Collections
open System.IO
open System.Collections.ObjectModel

module CollectionHelpers =
    /// Try and find a specific ListView item
    let tryFindListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ViewElementHolder as item ->
            let itemsView = sender :?> Xamarin.Forms.ListView
            let items = itemsView.ItemsSource :?> ObservableCollection<ViewElementHolder> 
            // POSSIBLE IMPROVEMENT: don't use a linear search
            items |> Seq.tryFindIndex (fun item2 -> identical item item2)
        | _ -> None

    /// Try and find a specific grouped ListView item
    let tryFindGroupedListViewItem (sender: obj) (item: obj) =
        match item with 
        | null -> None
        | :? ViewElementHolder as item ->
            let itemsView = sender :?> Xamarin.Forms.ListView
            let items = itemsView.ItemsSource :?> ObservableCollection<ViewElementHolderGroup>
            // POSSIBLE IMPROVEMENT: don't use a linear search
            items 
            |> Seq.indexed 
            |> Seq.tryPick (fun (i, items2) -> 
                // POSSIBLE IMPROVEMENT: don't use a linear search
                items2
                |> Seq.indexed
                |> Seq.tryPick (fun (j, item2) -> if identical item item2 then Some (i,j) else None))
        | _ -> None

[<AutoOpen>]
module ViewConverters =        
    /// Converts a string, byte array or ImageSource to a Xamarin.Forms ImageSource
    let convertFabulousImageToXamarinFormsImageSource (v: InputTypes.Image) =
        match v with
        | ImagePath path -> ImageSource.op_Implicit path
        | ImageBytes bytes -> ImageSource.FromStream(fun () -> new MemoryStream(bytes) :> Stream)
        | ImageStream stream -> ImageSource.FromStream(fun () -> stream)
        | ImageFont fontImageSource -> fontImageSource :> ImageSource
        | ImageSrc imageSource -> imageSource

    let convertFabulousMediaToXamarinFormsMediaSource (v: InputTypes.Media) =
        match v with
        | MediaPath path -> MediaSource.op_Implicit path
        | MediaSrc mediaSource -> mediaSource
                
    let convertFabulousDimensionToXamarinFormsRowDefinition (v: InputTypes.Dimension array) =
        let rows =
            Array.map (fun vi ->
                match vi with
                | Auto -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength.Auto; rd
                | Star -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength.Star; rd
                | Stars value -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength(value, GridUnitType.Star); rd
                | Absolute value -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength(value, GridUnitType.Absolute); rd
            ) v
        
        let collection = Xamarin.Forms.RowDefinitionCollection()
        rows |> Array.iter collection.Add
        collection
        
    let convertFabulousDimensionToXamarinFormsColumnDefinition (v: InputTypes.Dimension array) =
        let columns =
            Array.map (fun vi ->
                match vi with
                | Auto -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength.Auto; rd
                | Star -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength.Star; rd
                | Stars value -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength(value, GridUnitType.Star); rd
                | Absolute value -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength(value, GridUnitType.Absolute); rd
            ) v
        
        let collection = Xamarin.Forms.ColumnDefinitionCollection()
        columns |> Array.iter collection.Add
        collection
        
    let convertFabulousFontSizeToXamarinFormsDouble (targetType: Type) (v: InputTypes.FontSize) =
        match v with
        | Named namedSize -> Device.GetNamedSize(namedSize, targetType)
        | FontSize value -> value
            
    let inline convertItemsViewSelectedItemIndexToObj (target: ^T) (v: int option) =
        match v with
        | None -> null
        | Some i ->
            let items = (^T: (member ItemsSource: IEnumerable) target) :?> System.Collections.Generic.IList<ViewElementHolder>
            if i >= 0 && i < items.Count then
                items.[i] :> obj
            else
                null
                
        
    /////////////////
    /// Event Handlers
    /////////////////
        
    let makeCurrentPageChanged<'a when 'a :> Xamarin.Forms.Page and 'a : null> f =
        System.EventHandler(fun sender _args ->
            let control = sender :?> Xamarin.Forms.MultiPage<'a>
            let index =
                match control.CurrentPage with
                | null -> None
                | page -> Some (Xamarin.Forms.MultiPage<'a>.GetIndex(page))
            f index
        )
        
    let makeEntryCellCompletedEventHandler (f: string -> unit) =
        System.EventHandler(fun sender _args ->
            let entryCell = sender :?> Xamarin.Forms.EntryCell
            f entryCell.Text
        )
        
    let makeEntryCompletedEventHandler (f: string -> unit) =
        System.EventHandler(fun sender _args ->
            let entry = sender :?> Xamarin.Forms.Entry
            f entry.Text
        )
        
    let makeEditorCompletedEventHandler (f: string -> unit) =
        System.EventHandler(fun sender _args ->
            let editor = sender :?> Xamarin.Forms.Editor
            f editor.Text
        )
                
    let makePickerSelectedIndexChangedEventHandler f =
        System.EventHandler(fun sender args ->
            let picker = sender :?> Xamarin.Forms.Picker
            let selectedItem = (picker.SelectedItem |> Option.ofObj |> Option.map string)
            f (picker.SelectedIndex, selectedItem)
        )
        
    let makeListViewItemAppearingEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args ->
            CollectionHelpers.tryFindListViewItem sender args.Item |> Option.iter f
        )
        
    let makeListViewItemDisappearingEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args ->
            CollectionHelpers.tryFindListViewItem sender args.Item |> Option.iter f
        )
        
    let makeListViewItemSelectedEventHandler f =
        System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args ->
            CollectionHelpers.tryFindListViewItem sender args.SelectedItem |> f
        )
        
    let makeListViewItemTappedEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args ->
            CollectionHelpers.tryFindListViewItem sender args.Item |> Option.iter f
        )
    
    let makeListViewGroupedItemSelectedEventHandler f =
        System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args ->
            CollectionHelpers.tryFindGroupedListViewItem sender args.SelectedItem |> f
        )
        
    let makeListViewGroupedItemTappedEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args ->
            CollectionHelpers.tryFindGroupedListViewItem sender args.Item |> Option.iter f
        )
        
    let makeMasterDetailPageIsPresentedChangedEventHandler f =
        System.EventHandler(fun sender args ->
            let masterDetailPage = sender :?> Xamarin.Forms.MasterDetailPage
            f masterDetailPage.IsPresented
        )
        
    let makeCustomTimePickerTimeChangedEventHandler f =
        System.EventHandler<System.TimeSpan>(fun sender args ->
            f args    
        )    

    let makeSwipeItemsChangedEventHandler f =
        System.Collections.Specialized.NotifyCollectionChangedEventHandler(fun sender args ->
            f args
        )
        
    let makeCarouselViewCurrentItemChangedEventHandler f =
        System.EventHandler<Xamarin.Forms.CurrentItemChangedEventArgs>(fun sender args ->
            let previousViewElement = match args.PreviousItem :?> ViewElementHolder with null -> None | item -> Some item.ViewElement
            let currentViewElement = match args.CurrentItem :?> ViewElementHolder with null -> None | item -> Some item.ViewElement
            f (previousViewElement, currentViewElement)
        )