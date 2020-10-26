// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Xamarin.Forms
open System
open System.Collections
open System.Collections.Generic
open System.IO
open System.Collections.ObjectModel
open Fabulous

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
    let convertFabulousImageToXamarinFormsImageSource (v: InputTypes.Image.Value) =
        match v with
        | Image.ImagePath path -> ImageSource.op_Implicit path
        | Image.ImageBytes bytes -> ImageSource.FromStream(fun () -> new MemoryStream(bytes) :> Stream)
        | Image.ImageStream stream -> ImageSource.FromStream(fun () -> stream)
        | Image.ImageFont fontImageSource -> fontImageSource :> ImageSource
        | Image.ImageSource imageSource -> imageSource

    let convertFabulousMediaToXamarinFormsMediaSource (v: InputTypes.Media.Value) =
        match v with
        | Media.MediaPath path -> MediaSource.op_Implicit path
        | Media.MediaSource mediaSource -> mediaSource

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

    let convertFabulousFontSizeToXamarinFormsDouble (targetType: Type) (v: InputTypes.FontSize.Value) =
        match v with
        | FontSize.NamedSize namedSize -> Device.GetNamedSize(namedSize, targetType)
        | FontSize.Size value -> value

    let inline convertItemsViewSelectedItemIndexToObj (target: ^T) (v: int option) =
        match v with
        | None -> null
        | Some i ->
            let items = (^T: (member ItemsSource: IEnumerable) target) :?> System.Collections.Generic.IList<ViewElementHolder>
            if i >= 0 && i < items.Count then
                items.[i] :> obj
            else
                null
                
//    let convertXamarinFormsColor (v: Xamarin.Forms.Color) =
//        match StructMemoizations.TryGetValue(v) with
//        | ValueSome value -> value
//        | ValueNone -> StructMemoizations.Add(v)
//
//    let convertXamarinFormsThickness (v: Xamarin.Forms.Thickness) =
//        match StructMemoizations.TryGetValue(v) with
//        | ValueSome value -> value
//        | ValueNone -> StructMemoizations.Add(v)
//        
//    let convertXamarinFormsLayoutOptions (v: Xamarin.Forms.LayoutOptions) =
//        match StructMemoizations.TryGetValue(v) with
//        | ValueSome value -> value
//        | ValueNone -> StructMemoizations.Add(v)


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

    let makeSearchHandlerItemSelectedEventHandler f =
        System.EventHandler<obj>(fun sender args ->
            let viewElement = match args :?> ViewElementHolder with null -> None | item -> Some item.ViewElement
            f viewElement
        )

    let makeSelectableItemsViewSelectionChangedEventHandler f =
        System.EventHandler<Xamarin.Forms.SelectionChangedEventArgs>(fun sender args ->
            let convert (selection: IReadOnlyList<obj>) =
                if selection = null then
                    None
                else
                    selection
                    |> Seq.map (fun i -> i :?> ViewElementHolder)
                    |> Seq.filter (fun i -> i <> null)
                    |> Seq.map (fun i -> i.ViewElement)
                    |> Seq.toList
                    |> Some

            let previousViewElements = convert args.PreviousSelection
            let currentViewElements = convert args.CurrentSelection
            f (previousViewElements, currentViewElements)
        )

    let makeCarouselViewCurrentItemChangedEventHandler f =
        System.EventHandler<Xamarin.Forms.CurrentItemChangedEventArgs>(fun sender args ->
            let previousViewElement = match args.PreviousItem :?> ViewElementHolder with null -> None | item -> Some item.ViewElement
            let currentViewElement = match args.CurrentItem :?> ViewElementHolder with null -> None | item -> Some item.ViewElement
            f (previousViewElement, currentViewElement)
        )

    let makeVisualElementSizeChangedEventHandler f =
        System.EventHandler(fun sender args ->
            let width = (sender :?> Xamarin.Forms.VisualElement).Width
            let height = (sender :?> Xamarin.Forms.VisualElement).Height
            f (width, height)
        )