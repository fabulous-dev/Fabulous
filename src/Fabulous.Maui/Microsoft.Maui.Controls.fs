namespace Fabulous.Maui

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


type IApplicationWidget = interface end
type IWindowWidget = interface end
type IViewWidget = interface end

module Attributes =
    let IApplication_Windows = Attributes.createDefinitionWithConverter<_,_> "IApplication_Windows" Seq.toArray
    let IWindow_Title = Attributes.createDefinition<_> "IWindow_Title"
    let IWindow_Content = Attributes.createDefinition<IViewWidget> "IWindow_Content"
    let IContainer_Children = Attributes.createDefinitionWithConverter<_,_> "IContainer_Children" Seq.toArray
    let IText_Text = Attributes.createDefinition<_> "IText_Text"
    let ITextStyle_Font = Attributes.createDefinition<_> "ITextStyle_Font"
    let ITextStyle_TextColor = Attributes.createDefinition<_> "ITextStyle_TextColor"
    let IButton_Clicked = Attributes.createDefinition<_> "IButton_Clicked"

/////////// WIDGET
type [<Struct>] ApplicationWidget =
    { Attributes: Attribute list }
    interface IApplicationWidget
    interface ControlWidget.IControlWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
        
    static member inline Create(windows: seq<#IWindowWidget>) =
        ControlWidget.register<ApplicationWidget, FabulousApplication>()
        { Attributes = [ Attributes.IApplication_Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) ] }
        
type [<Struct>] WindowWidget =
    { Attributes: Attribute list }
    interface IWindowWidget
    interface ControlWidget.IControlWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(title: string, content: #IViewWidget) =
        ControlWidget.register<WindowWidget, FabulousWindow>()
        { Attributes =
            [ Attributes.IWindow_Title.WithValue(title)
              Attributes.IWindow_Content.WithValue(content) ] }
        
type [<Struct>] StackLayoutWidget =
    { Attributes: Attribute list }
    interface IViewWidget
    interface ControlWidget.IControlWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(children: seq<IViewWidget>) =
        ControlWidget.register<StackLayoutWidget, FabulousStackLayout>()
        { Attributes = [ Attributes.IContainer_Children.WithValue(children) ] }
        
type [<Struct>] LabelWidget =
    { Attributes: Attribute list }
    interface IViewWidget
    interface ControlWidget.IControlWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(text: string) =
        ControlWidget.register<LabelWidget, FabulousLabel>()
        { Attributes = [ Attributes.IText_Text.WithValue(text) ] }
        
type [<Struct>] ButtonWidget =
    { Attributes: Attribute list }
    interface IViewWidget
    interface ControlWidget.IControlWidget with
        member this.Add(attribute) = { Attributes = attribute :: this.Attributes } :> ControlWidget.IControlWidget
    
    static member inline Create(text: string, clicked: #obj) =
        ControlWidget.register<ButtonWidget, FabulousButton>()
        { Attributes =
            [ Attributes.IText_Text.WithValue(text)
              Attributes.IButton_Clicked.WithValue(box clicked) ] }

/////////// WIDGET EXTENSIONS
[<Extension>]
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline Font<'T when 'T :> IViewWidget and 'T :> ControlWidget.IControlWidget>(this: 'T, value: Font) =
        this.Add(Attributes.ITextStyle_Font.WithValue(value)) :?> 'T
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline TextColor(this: LabelWidget, value: Color) =
        (this :> ControlWidget.IControlWidget).Add(Attributes.ITextStyle_TextColor.WithValue(value)) :?> LabelWidget
        
/////////// WIDGET EXPOSURE
[<AbstractClass; Sealed>]
type View private () =
    static member inline Application(windows) = ApplicationWidget.Create(windows)
    static member inline Window(title, content) = WindowWidget.Create(title, content)
    static member inline StackLayout(children) = StackLayoutWidget.Create(children)
    static member inline Label(text) = LabelWidget.Create(text)
    static member inline Button(text, clicked) = ButtonWidget.Create(text, clicked)
    
    
/////////// STATEFUL WIDGETS
type StatefulApplication<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget and 'view :> IWidget> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> Attribute[] -> 'view }
    interface IApplicationWidget
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model, attributes) = x.View model attributes

type StatefulView<'arg, 'model, 'msg, 'view when 'view :> IViewWidget and 'view :> IWidget> =
    { State: RunnerKey option
      Init: 'arg -> 'model
      Update: 'msg -> 'model -> 'model
      View: 'model -> Attribute[] -> 'view }
    interface IViewWidget
    interface IStatefulWidget<'arg, 'model, 'msg, 'view> with
        member x.State = x.State
        member x.Init(arg) = x.Init arg
        member x.Update(msg, model) = x.Update msg model
        member x.View(model, attributes) = x.View model attributes
    
module StatefulWidget =
    let mkSimpleView init update view : StatefulView<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }
        
    let mkSimpleApp init update view : StatefulApplication<_,_,_,_> =
        { State = None
          Init = init
          Update = update
          View = view }
        
/////////// STATELESS WIDGETS
type StatelessView<'view when 'view :> IViewWidget and 'view :> IWidget> =
    { View: Attribute[] -> 'view }
    interface IViewWidget
    interface IStatelessWidget<'view> with
        member x.View(attrs) = x.View attrs
        
module StatelessWidget =
    let mkSimpleView view : StatelessView<_> =
        { View = view }