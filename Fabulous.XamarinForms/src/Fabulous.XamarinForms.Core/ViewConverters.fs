// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System
open System.Collections.Generic
open System.IO
open System.Windows.Input

[<AutoOpen>]
module Converters =
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
       | :? string as s -> [| s |]
       | :? (string list) as s -> s |> Array.ofList
       | :? (string[]) as s -> s
       | :? (seq<string>) as s -> s |> Array.ofSeq
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

    
        