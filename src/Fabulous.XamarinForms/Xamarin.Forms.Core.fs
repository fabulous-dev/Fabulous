namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms.Attributes
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices

module Helpers =
    let inline compileSeq (items: seq<#IWidgetBuilder<'msg>>) =
        items
        |> Seq.map (fun item -> item.Compile())

type [<Struct>] ApplicationWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Application>()

    static member inline Create(mainPage: #IPageWidgetBuilder<'msg>) =
        ApplicationWidgetBuilder<'msg>([|
            Application.MainPage.WithValue(mainPage.Compile())
        |])

    interface IApplicationWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] ContentPageWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<Xamarin.Forms.ContentPage>()

    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentPageWidgetBuilder<'msg>([|
            ContentPage.Content.WithValue(content.Compile())
        |])

    interface IPageWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] StackLayoutWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<Xamarin.Forms.StackLayout>()

    static member inline Create(orientation: Xamarin.Forms.StackOrientation, children: seq<#IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayoutWidgetBuilder<'msg>([|
            StackLayout.Orientation.WithValue(orientation)
            LayoutOfView.Children.WithValue(Helpers.compileSeq children)
            match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v)
        |])

    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] LabelWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Label>()

    static member inline Create(text: string) =
        LabelWidgetBuilder<'msg>([|
            Label.Text.WithValue(text)
        |])

    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

[<Extension>]
type ViewExtensions () =
    [<Extension>]
    static member inline horizontalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddAttribute(View.HorizontalOptions.WithValue(value))
    [<Extension>]
    static member inline verticalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddAttribute(View.VerticalOptions.WithValue(value))

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(mainPage) = ApplicationWidgetBuilder<'msg>.Create(mainPage)
    static member inline ContentPage<'msg>(content) = ContentPageWidgetBuilder<'msg>.Create(content)
    static member inline VerticalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children)
    static member inline VerticalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children, spacing = spacing)
    static member inline HorizontalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children)
    static member inline HorizontalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children, spacing = spacing)
    static member inline Label<'msg>(text) = LabelWidgetBuilder<'msg>.Create(text)
