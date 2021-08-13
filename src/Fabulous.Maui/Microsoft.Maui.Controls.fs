namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous.ControlWidget

// MAUI CONTROLS

type FabulousApplication () =
    interface IApplication with
        member this.ThemeChanged() = failwith "todo"
        member this.CreateWindow(activationState) = failwith "todo"
        member this.Windows = failwith "todo"
        
type FabulousWindow () =
    interface IWindow with
        member this.Activated() = failwith "todo"
        member this.Created() = failwith "todo"
        member this.Deactivated() = failwith "todo"
        member this.Destroying() = failwith "todo"
        member this.Resumed() = failwith "todo"
        member this.Stopped() = failwith "todo"
        member this.Content = failwith "todo"
        member val Handler = failwith "todo" with get, set
        member this.Parent = failwith "todo"
        member this.Title = failwith "todo"
        
type FabulousStackLayout () =
    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = failwith "todo"
        member this.AnchorY = failwith "todo"
        member this.Arrange(bounds: Rectangle) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.Clear() = failwith "todo"
        member this.Clip = failwith "todo"
        member this.Contains(item: IView) = failwith "todo"
        member this.CopyTo(array: IView [], arrayIndex: int) = failwith "todo"
        member this.Count = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Frame
            with get (): Rectangle = 
                raise (System.NotImplementedException())
            and set (v: Rectangle): unit = 
                raise (System.NotImplementedException())
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<IView> = 
            raise (System.NotImplementedException())
        member this.GetEnumerator(): System.Collections.IEnumerator = 
            raise (System.NotImplementedException())
        member this.Handler
            with get (): IElementHandler = 
                raise (System.NotImplementedException())
            and set (v: IElementHandler): unit = 
                raise (System.NotImplementedException())
        member this.Handler
            with get (): IViewHandler = 
                raise (System.NotImplementedException())
            and set (v: IViewHandler): unit = 
                raise (System.NotImplementedException())
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.IgnoreSafeArea = failwith "todo"
        member this.IndexOf(item: IView) = failwith "todo"
        member this.Insert(index: int, item: IView) = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.IsReadOnly = failwith "todo"
        member this.Item
            with get (index: int): IView = 
                raise (System.NotImplementedException())
            and set (index: int) (v: IView): unit = 
                raise (System.NotImplementedException())
        member this.LayoutHandler = failwith "todo"
        member this.LayoutManager = failwith "todo"
        member this.Margin = failwith "todo"
        member this.Measure(widthConstraint: float, heightConstraint: float) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Remove(item: IView) = failwith "todo"
        member this.RemoveAt(index: int) = failwith "todo"
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
        member this.Arrange(bounds: Rectangle) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.CharacterSpacing = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Font = failwith "todo"
        member this.Frame
            with get (): Rectangle = 
                raise (System.NotImplementedException())
            and set (v: Rectangle): unit = 
                raise (System.NotImplementedException())
        member this.Handler
            with get (): IElementHandler = 
                raise (System.NotImplementedException())
            and set (v: IElementHandler): unit = 
                raise (System.NotImplementedException())
        member this.Handler
            with get (): IViewHandler = 
                raise (System.NotImplementedException())
            and set (v: IViewHandler): unit = 
                raise (System.NotImplementedException())
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
        member this.Measure(widthConstraint: float, heightConstraint: float) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
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
        member this.Arrange(bounds: Rectangle) = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.CharacterSpacing = failwith "todo"
        member this.Clicked() = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Font = failwith "todo"
        member this.Frame
            with get (): Rectangle = 
                raise (System.NotImplementedException())
            and set (v: Rectangle): unit = 
                raise (System.NotImplementedException())
        member this.Handler
            with get (): IElementHandler = 
                raise (System.NotImplementedException())
            and set (v: IElementHandler): unit = 
                raise (System.NotImplementedException())
        member this.Handler
            with get (): IViewHandler = 
                raise (System.NotImplementedException())
            and set (v: IViewHandler): unit = 
                raise (System.NotImplementedException())
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.Margin = failwith "todo"
        member this.Measure(widthConstraint: float, heightConstraint: float) = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
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
        member this.CreateView() = box (FabulousApplication())
        
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
        member this.CreateView() = Unchecked.defaultof<_>
        
type [<Struct>] StackLayoutWidget (attributes: Attribute[]) =
    static do register<StackLayoutWidget, FabulousStackLayout>()
    
    static member inline Create(children: seq<IViewWidget>) =        
        StackLayoutWidget([| Attributes.IContainer_Children.WithValue(children) |])
        
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute StackLayoutWidget attributes attribute
        member this.CreateView() = box (FabulousWindow())
        
type [<Struct>] LabelWidget (attributes: Attribute[]) =
    static do register<LabelWidget, FabulousLabel>()
    
    static member inline Create(text: string) =
        LabelWidget([| Attributes.IText_Text.WithValue(text) |])
        
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute LabelWidget attributes attribute
        member this.CreateView() = box (FabulousLabel())
        
type [<Struct>] ButtonWidget =
    { Attributes: Attribute[] }
    interface IViewWidget
    interface IControlWidget with
        member this.Add(attribute) = addAttribute (fun attrs -> { Attributes = attrs }) this.Attributes attribute
        member this.CreateView() = box (FabulousButton())
    
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
    