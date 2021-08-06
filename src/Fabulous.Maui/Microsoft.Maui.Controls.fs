namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous.ControlWidget

// MAUI CONTROLS

type FabulousApplication () =
    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.Windows = failwith "todo"
        
type FabulousWindow () =
    interface IWindow with
        member this.Content = failwith "todo"
        member val Handler = failwith "todo" with get, set
        member this.Parent = failwith "todo"
        member this.Title = failwith "todo"
        
type FabulousStackLayout () =
    interface IStackLayout with
        member this.Add(child) = failwith "todo"
        member this.AnchorX = failwith "todo"
        member this.AnchorY = failwith "todo"
        member this.Arrange(bounds) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.Children = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member val Frame = failwith "todo" with get, set
        member val Handler : IViewHandler = failwith "todo" with get, set
        member this.get_Handler() = Unchecked.defaultof<IElementHandler>
        member this.set_Handler(value: IElementHandler) = ()
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.LayoutHandler = failwith "todo"
        member this.Margin = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Parent : IFrameworkElement = failwith "todo"
        member this.get_Parent() = Unchecked.defaultof<IElement>
        member this.Remove(child) = failwith "todo"
        member this.Rotation = failwith "todo"
        member this.RotationX = failwith "todo"
        member this.RotationY = failwith "todo"
        member this.Scale = failwith "todo"
        member this.ScaleX = failwith "todo"
        member this.ScaleY = failwith "todo"
        member this.Semantics = failwith "todo"
        member this.Spacing = failwith "todo"
        member this.TranslationX = failwith "todo"
        member this.TranslationY = failwith "todo"
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.Visibility = failwith "todo"
        member this.Width = failwith "todo"
        
type FabulousLabel () =
    interface ILabel with
        member this.AnchorX = failwith "todo"
        member this.AnchorY = failwith "todo"
        member this.Arrange(bounds) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.CharacterSpacing = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Font = failwith "todo"
        member val Frame = failwith "todo" with get, set
        member val Handler : IViewHandler = failwith "todo" with get, set
        member this.get_Handler() = Unchecked.defaultof<IElementHandler>
        member this.set_Handler(value: IElementHandler) = ()
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.HorizontalTextAlignment = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.LineBreakMode = failwith "todo"
        member this.LineHeight = failwith "todo"
        member this.Margin = failwith "todo"
        member this.MaxLines = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent : IFrameworkElement = failwith "todo"
        member this.get_Parent() = Unchecked.defaultof<IElement>
        member this.Rotation = failwith "todo"
        member this.RotationX = failwith "todo"
        member this.RotationY = failwith "todo"
        member this.Scale = failwith "todo"
        member this.ScaleX = failwith "todo"
        member this.ScaleY = failwith "todo"
        member this.Semantics = failwith "todo"
        member this.Text = failwith "todo"
        member this.TextColor = failwith "todo"
        member this.TextDecorations = failwith "todo"
        member this.TranslationX = failwith "todo"
        member this.TranslationY = failwith "todo"
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.VerticalTextAlignment = failwith "todo"
        member this.Visibility = failwith "todo"
        member this.Width = failwith "todo"

type FabulousButton () =
    interface IButton with
        member this.AnchorX = failwith "todo"
        member this.AnchorY = failwith "todo"
        member this.Arrange(bounds) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.CharacterSpacing = failwith "todo"
        member this.Clicked() = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Font = failwith "todo"
        member val Frame = failwith "todo" with get, set
        member val Handler : IViewHandler = failwith "todo" with get, set
        member this.get_Handler() = Unchecked.defaultof<IElementHandler>
        member this.set_Handler(value: IElementHandler) = ()
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.Margin = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent : IFrameworkElement = failwith "todo"
        member this.get_Parent() = Unchecked.defaultof<IElement>
        member this.Pressed() = failwith "todo"
        member this.Released() = failwith "todo"
        member this.Rotation = failwith "todo"
        member this.RotationX = failwith "todo"
        member this.RotationY = failwith "todo"
        member this.Scale = failwith "todo"
        member this.ScaleX = failwith "todo"
        member this.ScaleY = failwith "todo"
        member this.Semantics = failwith "todo"
        member this.Text = failwith "todo"
        member this.TextColor = failwith "todo"
        member this.TranslationX = failwith "todo"
        member this.TranslationY = failwith "todo"
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.Visibility = failwith "todo"
        member this.Width = failwith "todo"

// ATTRIBUTES

module Attributes =
    let IApplication_Windows = Attributes.createDefinitionWithConverter<_,_> Seq.toArray
    let IWindow_Title = Attributes.createDefinition<_>
    let IWindow_Content = Attributes.createDefinition<IViewWidget>
    let IContainer_Children = Attributes.createDefinitionWithConverter<_,_> Seq.toArray
    let IText_Text = Attributes.createDefinition<_>
    let ITextStyle_Font = Attributes.createDefinition<_>
    let ITextStyle_TextColor = Attributes.createDefinition<_>
    let IButton_Clicked = Attributes.createDefinition<_>
    let IStackLayout_Spacing = Attributes.createDefinition<_>

// WIDGETS

type [<Struct>] ApplicationWidget (attributes: Attribute[]) =
    static do register<ApplicationWidget, FabulousApplication>()

    static member inline Create(windows: seq<#IWindowWidget>) =
        ApplicationWidget([| Attributes.IApplication_Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) |])
    
    interface IApplicationWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute ApplicationWidget attributes attribute
        
type [<Struct>] WindowWidget (attributes: Attribute[]) =
    static do register<WindowWidget, FabulousWindow>()
    
    static member inline Create(title: string, content: #IViewWidget) =
        WindowWidget(
            [| Attributes.IWindow_Title.WithValue(title)
               Attributes.IWindow_Content.WithValue(content) |]
        )
    
    interface IWindowWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute WindowWidget attributes attribute
        
type [<Struct>] StackLayoutWidget (attributes: Attribute[]) =
    static do register<StackLayoutWidget, FabulousStackLayout>()
    
    static member inline Create(children: seq<IViewWidget>) =        
        StackLayoutWidget([| Attributes.IContainer_Children.WithValue(children) |])
        
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute StackLayoutWidget attributes attribute
        
type [<Struct>] LabelWidget (attributes: Attribute[]) =
    static do register<LabelWidget, FabulousLabel>()
    
    static member inline Create(text: string) =
        LabelWidget([| Attributes.IText_Text.WithValue(text) |])
        
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute LabelWidget attributes attribute
        
type [<Struct>] ButtonWidget =
    { Attributes: Attribute[] }
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute (fun attrs -> { Attributes = attrs }) this.Attributes attribute
    
    static member inline Create(text: string, clicked: #obj) =
        register<ButtonWidget, FabulousButton>()
        { Attributes =
            [| Attributes.IText_Text.WithValue(text)
               Attributes.IButton_Clicked.WithValue(box clicked) |] }

// EXTENSIONS
    
[<Extension>]
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline font<'T when 'T :> IViewWidget and 'T :> IControlWidget>(this: 'T, value: Font) =
        this.AddAttribute(Attributes.ITextStyle_Font.WithValue(value))
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline textColor(this: LabelWidget, value: Color) =
        this.AddAttribute(Attributes.ITextStyle_TextColor.WithValue(value))
        
[<Extension>]
type StackLayoutExtensions () =
    [<Extension>]
    static member inline spacing(this: StackLayoutWidget, value: int) =
        this.AddAttribute(Attributes.IStackLayout_Spacing.WithValue(value))
        
// EXPOSITION

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application(windows) = ApplicationWidget.Create(windows)
    static member inline Window(title, content) = WindowWidget.Create(title, content)
    static member inline StackLayout(children) = StackLayoutWidget.Create(children)
    static member inline Label(text) = LabelWidget.Create(text)
    static member inline Button(text, clicked) = ButtonWidget.Create(text, clicked)
    