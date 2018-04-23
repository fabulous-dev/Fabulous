namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Reflection
open System.Diagnostics
open System.Windows.Input
open Xamarin.Forms

[<AutoOpen>]
module Converters =
    let makeCommand f =
        let ev = Event<_,_>()
        { new ICommand with
            member x.add_CanExecuteChanged h = ev.Publish.AddHandler h
            member x.remove_CanExecuteChanged h = ev.Publish.RemoveHandler h
            member x.CanExecute _ = true
            member x.Execute _ = f() }

    let makeImageSource (image: string) = ImageSource.op_Implicit image

    let makeFileImageSource (image: string) = FileImageSource.op_Implicit image

    let makeThickness (v: double) = Thickness.op_Implicit v

    let makeGridLength (v: obj) = 
       match v with 
       | :? string as s when s = "*" -> GridLength.Star
       | :? string as s when s = "auto" -> GridLength.Auto
       | :? float as f -> GridLength.op_Implicit f
       | :? GridLength as v -> v
       | _ -> failwithf "gridLength: invalid argument %O" v

    let makeFontSize (v: obj) = 
        match box v with 
        | :? string as s -> (FontSizeConverter().ConvertFromInvariantString(s) :?> double)
        | :? int as i -> double i
        | :? double as v -> v
        | _ -> System.Convert.ToDouble(v)

[<AllowNullLiteral>]
type IListGroupData = 
    abstract Key : obj

[<AllowNullLiteral>]
type ListElementData<'T>(key:'T) = 
    interface IListGroupData with member x.Key = box key
    member x.Key = key

[<AllowNullLiteral>]
type ListGroupData<'T>(key:'T, items: seq<'T>) = 
    inherit System.Collections.Generic.List<ListElementData<'T>>(Seq.map ListElementData items)
    interface IListGroupData with member x.Key = box key
    member x.Key = key
    member x.Items = items

type CustomViewCell() = 
    inherit ViewCell()

    let mutable modelOpt = None

    override x.OnBindingContextChanged () =
        base.OnBindingContextChanged ()
        match x.BindingContext with
        | :? IListGroupData as data -> 
            let newModel = data.Key
            match modelOpt with 
            | Some prev -> 
                let ty = newModel.GetType()
                let res = ty.InvokeMember("ApplyIncremental",(BindingFlags.InvokeMethod ||| BindingFlags.Public ||| BindingFlags.Instance), null, newModel, [| box prev; box x.View |] )
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
    inherit ListView(ItemTemplate=DataTemplate(typeof<CustomViewCell>))

type CustomGroupListView() = 
    inherit ListView(ItemTemplate=DataTemplate(typeof<CustomViewCell>), GroupHeaderTemplate=DataTemplate(typeof<CustomViewCell>))

