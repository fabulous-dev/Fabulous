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
    let makeAccelerator (accelerator: string) = Accelerator.op_Implicit accelerator

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
        
    let convertFabulousRowToXamarinFormsRowDefinition (v: InputTypes.Row array) =
        let rows =
            Array.map (fun vi ->
                match vi with
                | Row.Auto -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength.Auto; rd
                | Row.Star value -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength(value, GridUnitType.Star); rd
                | Row.Absolute value -> let rd = Xamarin.Forms.RowDefinition() in rd.Height <- GridLength(value, GridUnitType.Absolute); rd
            ) v
        
        let collection = Xamarin.Forms.RowDefinitionCollection()
        rows |> Array.iter collection.Add
        collection
        
    let convertFabulousColumnToXamarinFormsColumnDefinition (v: InputTypes.Column array) =
        let columns =
            Array.map (fun vi ->
                match vi with
                | Column.Auto -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength.Auto; rd
                | Column.Star value -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength(value, GridUnitType.Star); rd
                | Column.Absolute value -> let rd = Xamarin.Forms.ColumnDefinition() in rd.Width <- GridLength(value, GridUnitType.Absolute); rd
            ) v
        
        let collection = Xamarin.Forms.ColumnDefinitionCollection()
        columns |> Array.iter collection.Add
        collection
            