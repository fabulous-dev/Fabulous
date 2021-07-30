namespace Fabulous.Maui

open System.ComponentModel
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics

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


type IApplicationWidget = inherit ControlWidget.IControlWidget
type IWindowWidget = inherit ControlWidget.IControlWidget
type IViewWidget = inherit ControlWidget.IControlWidget


type [<Struct>] ApplicationWidget =
    private { Attributes: Attribute list }
    interface IApplicationWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
        
    static member inline Create(windows: seq<#IWindowWidget>) =
        ControlWidget.register<ApplicationWidget, FabulousApplication>()
        { Attributes = [] }
        
type [<Struct>] WindowWidget =
    private { Attributes: Attribute list }
    interface IWindowWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(title: string, content: #IViewWidget) =
        ControlWidget.register<WindowWidget, FabulousWindow>()
        { Attributes = [] }
        
type [<Struct>] StackLayoutWidget =
    private { Attributes: Attribute list }
    interface IViewWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(children: seq<IViewWidget>) =
        ControlWidget.register<StackLayoutWidget, FabulousStackLayout>()
        { Attributes = [] }
        
type [<Struct>] LabelWidget =
    private { Attributes: Attribute list }
    interface IViewWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create() =
        ControlWidget.register<LabelWidget, FabulousLabel>()
        { Attributes = [] }
        
type [<Struct>] ButtonWidget =
    private { Attributes: Attribute list }
    interface IViewWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create() =
        ControlWidget.register<ButtonWidget, FabulousButton>()
        { Attributes = [] }

[<Extension>]
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline Font<'T when 'T :> IViewWidget>(this: 'T, fontFamily: string) =
        this.Add({ Key = AttributeKey 1; Value = null }) :?> 'T
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline TextColor(this: LabelWidget, value: Color) =
        this
    
[<AbstractClass; Sealed>]
type View private () =
    static member inline Application(windows) = ApplicationWidget.Create(windows)
    static member inline Window(title, content) = WindowWidget.Create(title, content)
    static member inline StackLayout(children) = StackLayoutWidget.Create(children)
    static member inline Label() = LabelWidget.Create()
    static member inline Button() = ButtonWidget.Create()