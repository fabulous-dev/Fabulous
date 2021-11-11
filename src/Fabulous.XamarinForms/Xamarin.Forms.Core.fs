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
    static let key = Widgets.registerNoChildren<Xamarin.Forms.Application>()

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
    static let key = Widgets.registerNoChildren<Xamarin.Forms.ContentPage>()

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
    static let key = Widgets.register<Xamarin.Forms.StackLayout> (fun ref -> Some (LayoutOfViewViewContainer(ref) :> IXamarinFormsViewContainer))

    static member inline Create(orientation: Xamarin.Forms.StackOrientation, children: seq<#IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayoutWidgetBuilder<'msg>([|
            StackLayout.Orientation.WithValue(orientation)
            LayoutOfView.Children.WithValue(Helpers.compileSeq children)
            match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v)
        |])

    interface ILayoutWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] LabelWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.registerNoChildren<Xamarin.Forms.Label>()

    static member inline Create(text: string) =
        LabelWidgetBuilder<'msg>([|
            Label.Text.WithValue(text)
        |])

    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] ButtonWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.registerNoChildren<Xamarin.Forms.Button>()

    static member inline Create(text: string, onClicked: 'msg) =
        ButtonWidgetBuilder<'msg>([|
            Button.Text.WithValue(text)
            Button.Clicked.WithValue(onClicked)
        |])

    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

type [<Struct>] SwitchWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.registerNoChildren<Xamarin.Forms.Switch>()

    static member inline Create(isToggled: bool, onToggled: bool -> 'msg) =
        SwitchWidgetBuilder<'msg>([|
            Switch.IsToggled.WithValue(isToggled)
            Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
        |])
        
    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }
              
type [<Struct>] SliderWidgetBuilder<'msg> (attributes: Attribute[]) =
    static let key = Widgets.registerNoChildren<Xamarin.Forms.Slider>()
              
    static member inline Create(value: float, onValueChanged: float -> 'msg, ?min: float, ?max: float) =
        SliderWidgetBuilder<'msg>([|
            Slider.Value.WithValue(value)
            Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)
            match struct (min, max) with
            | (None, None) -> ()
            | (Some minV, Some maxV) -> Slider.MinimumMaximum.WithValue(minV, maxV)
            | _ -> failwith "invalid use"
        |])
                      
    interface IViewWidgetBuilder<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }

[<Extension>]
type ViewExtensions () =
    [<Extension>]
    static member inline automationId(this: #IViewWidgetBuilder<_>, value: string) =
        this.AddAttribute(Element.AutomationId.WithValue(value))
    [<Extension>]
    static member inline isEnabled(this: #IViewWidgetBuilder<_>, value: bool) =
        this.AddAttribute(VisualElement.IsEnabled.WithValue(value))
    [<Extension>]
    static member inline horizontalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddAttribute(View.HorizontalOptions.WithValue(value))
    [<Extension>]
    static member inline verticalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddAttribute(View.VerticalOptions.WithValue(value))
    [<Extension>]
    static member inline horizontalTextAlignment(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddAttribute(Label.HorizontalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalTextAlignment(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddAttribute(Label.VerticalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline padding(this: #ILayoutWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddAttribute(Layout.Padding.WithValue(value))


[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(mainPage) = ApplicationWidgetBuilder<'msg>.Create(mainPage)
    static member inline ContentPage<'msg>(content) = ContentPageWidgetBuilder<'msg>.Create(content)
    static member inline VerticalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children)
    static member inline VerticalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children, spacing = spacing)
    static member inline HorizontalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children)
    static member inline HorizontalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children, spacing = spacing)
    static member inline Label<'msg>(text) = LabelWidgetBuilder<'msg>.Create(text)
    static member inline Button<'msg>(text, onClicked) = ButtonWidgetBuilder<'msg>.Create(text, onClicked)
    static member inline Switch<'msg>(isToggled, onToggled) = SwitchWidgetBuilder<'msg>.Create(isToggled, onToggled)
    static member inline Slider<'msg>(value, onValueChanged) = SliderWidgetBuilder<'msg>.Create(value, onValueChanged)
    static member inline Slider<'msg>(min, max, value, onValueChanged) = SliderWidgetBuilder<'msg>.Create(value, onValueChanged, min = min, max = max)

