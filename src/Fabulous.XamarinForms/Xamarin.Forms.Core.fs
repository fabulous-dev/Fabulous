namespace Fabulous.XamarinForms

open System

open Fabulous
open Xamarin.Forms
open System.Runtime.CompilerServices

[<AbstractClass>]
type ViewBuilder<'T when 'T :> ViewBuilder<'T>>(attrs) =
    abstract CreateNewBuilder : Attribute list -> 'T
    member x.Add(attr) = x.CreateNewBuilder(attr :: attrs)

    interface IWidget with
        member x.Key = None

type ButtonBuilder private (attrs) =
    inherit ViewBuilder<ButtonBuilder>(attrs)
    new () = ButtonBuilder([])
    override _.CreateNewBuilder(attrs) = ButtonBuilder(attrs)

type LabelBuilder private (attrs) =
    inherit ViewBuilder<LabelBuilder>(attrs)
    new (text: string) = LabelBuilder([])
    override _.CreateNewBuilder(attrs) = LabelBuilder(attrs)

    /// Example of using attribute directly inside the builder
    /// Also example of obsoleting it
    [<Obsolete("FontSize is obsolete")>]
    member x.FontSize(value: int) = x.Add({ Name = "FontSize"; Value = box value })

type StackLayoutBuilder private (attrs) =
    inherit ViewBuilder<StackLayoutBuilder>(attrs)

    /// Example of using custom constructor
    new (children: IWidget list) = StackLayoutBuilder([] : Attribute list)
    
    override _.CreateNewBuilder(attrs) = StackLayoutBuilder(attrs)

module x = 
    /// Example of using Extension method to append new attribute to existing builders (supports inheritance)
    [<Extension>]
    type IViewBuilderExts = 
       [<Extension>] static member inline Horizontal(x: ViewBuilder<'T>, value: LayoutOptions) = x.Add({ Name = "Horizontal"; Value = box value })

[<AbstractClass; Sealed>]
type Fab private () =
    static member inline Label(text) = LabelBuilder(text)
    static member inline Button() = ButtonBuilder()
    static member inline StackLayout(children) = StackLayoutBuilder(children)

module StatelessPanel =
    open type Fab

    let view extendedAttributes : IWidget =
        StackLayout([
            Label("Hello")
            Label("world")
        ]) :> IWidget

    type Fab with
        static member inline StatelessPanel(extendedAttributes) = { Key = None; View = view; ExtendedAttributes = ValueSome extendedAttributes }

module StatefulPanel =
    open type Fab

    type Model = { Text: string }

    let init () = { Text = "" }
    let update msg model = model
    let view model extendedAttributes =
        StackLayout([
            Label(model.Text)
        ])

    type Fab with
        static member inline StatefulPanel(extendedAttributes) =
            { Key = None; State = None; Init = (fun _ -> box (init ())); Update = (fun (msg, model) -> box (update (unbox msg) (unbox model))); View = (fun (model, extendedAttributes) -> (view (unbox model) extendedAttributes) :> IWidget) }
    


module Test =
    open x
    open type Fab
    open StatelessPanel
    open StatefulPanel

    let test2() =
        Label("World")
            .Horizontal(LayoutOptions.Center)
            .FontSize(11)

    let test () =
        Button()
            .Horizontal(LayoutOptions.End)

    let test3 () =
        StackLayout([
            Label("Hello world")
            Button()
        ])
            .Horizontal(LayoutOptions.Fill)

    let test4 () =
        Fab.StatelessPanel([| |])

    let test5 () =
        StackLayout([
            Button()
            Fab.StatelessPanel([| |])
            Fab.StatefulPanel([| |])
        ])