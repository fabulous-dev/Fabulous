// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System
open System.IO
open System.Windows.Input

[<AutoOpen>]
module ViewConverters =
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
    let makeAccelerator (accelerator: InputTypes.Accelerator) =
        match accelerator with
        | String value -> Accelerator.op_Implicit value
        | Value value -> value

    /// Converts a string to a Xamarin.Forms FileImageSource
    let makeFileImageSource (image: string) = FileImageSource.op_Implicit image

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

    /// Converts a datatemplate to a Xamarin.Forms TemplatedPage
    let makeTemplate (v: obj) =
        match v with
        | :? TemplatedPage as p -> ShellContent.op_Implicit p
        | _ -> failwithf "makeTemplate: invalid argument %O" v

    /// Converts a ViewElement to a View, or other types to string
    let makeViewOrString (v: obj) : obj =
        match v with
        | null -> null
        | :? View as view -> view :> obj
        | :? ViewElement as viewElement -> viewElement.Create()
        | :? string as str -> str :> obj
        | _ -> v.ToString() :> obj

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

    /// Converts a string or collection of strings to a Xamarin.Forms StyleClass specification
    let convertStyleClassToStringList (v: InputTypes.StyleClass) = 
       match v with
       | ClassName className -> [| className |]
       | Classes classNames -> classNames |> Array.ofList
       
    let convertFabulousThicknessToXamarinFormsThickness (v: InputTypes.Thickness) =
        match v with
        | Uniform value -> Thickness(value)
        | Mirror (leftRight, topBottom) -> Thickness(leftRight, topBottom)
        | AllSides (left, top, right, bottom) -> Thickness(left, top, right, bottom)
        | InputTypes.Thickness.Value thickness -> thickness
        
    /// Converts a string, byte array or ImageSource to a Xamarin.Forms ImageSource
    let convertFabulousImageToXamarinFormsImageSource (v: InputTypes.Image) =
        match v with
        | Path path -> ImageSource.op_Implicit path
        | Bytes bytes -> ImageSource.FromStream(fun () -> new MemoryStream(bytes) :> Stream)
        | InputTypes.Image.Value imageSource -> imageSource
        
    let convertCompletedFuncToEventHandler (v: string -> unit) =
        System.EventHandler(fun _sender _args -> v (_sender :?> Xamarin.Forms.EntryCell).Text)
        
    let convertTableViewRoot (v: (string * ViewElement list) list) =
        v
        |> Array.ofList
        |> Array.map (fun (title, es) -> (title, Array.ofList es))
                
    let convertFabulousRowOrColumnToXamarinFormsRowDefinition (v: InputTypes.RowOrColumn array) =
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
        
    let convertFabulousRowOrColumnToXamarinFormsColumnDefinition (v: InputTypes.RowOrColumn array) =
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
        | InputTypes.FontSize.Named namedSize -> Device.GetNamedSize(namedSize, targetType)
        | InputTypes.FontSize.Value value -> value
            
    let convertFabulousViewOrTextToObject (v: InputTypes.ViewOrText) =
        match v with
        | InputTypes.ViewOrText.Text text -> text :> obj
        | InputTypes.ViewOrText.ViewElement viewElement -> viewElement.Create()
        | InputTypes.ViewOrText.View view -> view :> obj
            
    let convertListViewSelectedItemIndexToObj (target: Xamarin.Forms.ListView) (v: int option) =
        match v with
        | None -> null
        | Some i ->
            let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData>
            if i >= 0 && i < items.Count then
                items.[i]
            else
                null
                
    let convertSelectableItemsViewSelectedItemIndexToObj (target: Xamarin.Forms.SelectableItemsView) (v: int option) =
        match v with
        | None -> null
        | Some i ->
            let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData>
            if i >= 0 && i < items.Count then
                items.[i]
            else
                null
                
    let makePickerSelectedIndexChangedEventHandler f =
        System.EventHandler(fun sender args ->
            let picker = (sender :?> Xamarin.Forms.Picker)
            let selectedItem = (picker.SelectedItem |> Option.ofObj |> Option.map string)
            f (picker.SelectedIndex, selectedItem)
        )

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
        
    let makeListViewItemAppearingEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args ->
            f (tryFindListViewItem sender args.Item).Value
        )
        
    let makeListViewItemDisappearingEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args ->
            f (tryFindListViewItem sender args.Item).Value
        )
        
    let makeListViewItemSelectedEventHandler f =
        System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args ->
            f (tryFindListViewItem sender args.SelectedItem)
        )
        
    let makeListViewItemTappedEventHandler f =
        System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args ->
            f (tryFindListViewItem sender args.Item).Value
        )
    
    let makeListViewGroupedItemSelectedEventHandler f =
        System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args ->
            f (tryFindGroupedListViewItem sender args.SelectedItem)
        )
        
    let makeMasterDetailPageIsPresentedChangedEventHandler f =
        System.EventHandler(fun sender args ->
            f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented
        )
        
    let makeCustomTimePickerTimeChangedEventHandler f =
        System.EventHandler<System.TimeSpan>(fun sender args ->
            f args    
        )