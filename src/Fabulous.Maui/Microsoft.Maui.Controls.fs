namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous.ControlWidget
open System.Collections.Generic
open Microsoft.Maui.Controls

// ATTRIBUTES

module Attributes =
    let IApplication_Windows = Attributes.createDefinitionWithConverter<_,_> Seq.toArray
    let IApplication_ThemeChanged = Attributes.createDefinition<_>
    let IWindow_Activated = Attributes.createDefinition<_>
    let IWindow_Created = Attributes.createDefinition<_>
    let IWindow_Deactivated = Attributes.createDefinition<_>
    let IWindow_Destroying = Attributes.createDefinition<_>
    let IWindow_Resumed = Attributes.createDefinition<_>
    let IWindow_Stopped = Attributes.createDefinition<_>
    let IWindow_Title = Attributes.createDefinition<_>
    let IWindow_Content = Attributes.createDefinition<IViewWidget>
    let IContainer_Children = Attributes.createDefinitionWithConverter<_,_> Seq.toArray
    let IText_Text = Attributes.createDefinition<_>
    let ITextStyle_CharacterSpacing = Attributes.createDefinition<_>
    let ITextStyle_Font = Attributes.createDefinition<_>
    let ITextStyle_TextColor = Attributes.createDefinition<_>
    let IButton_Clicked = Attributes.createDefinition<_>
    let IButton_Pressed = Attributes.createDefinition<_>
    let IButton_Released = Attributes.createDefinition<_>
    let IButton_ImageSource = Attributes.createDefinition<IImageSource>
    let IButton_ImageSourceLoaded = Attributes.createDefinition<_>
    let IStackLayout_Orientation = Attributes.createDefinition<StackOrientation>
    let IStackLayout_Spacing = Attributes.createDefinition<_>
    let IView_AutomationId = Attributes.createDefinition<_>
    let IView_Background = Attributes.createDefinition<_>
    let IView_Clip = Attributes.createDefinition<IShape>
    let IView_FlowDirection = Attributes.createDefinition<_>
    let IView_Height = Attributes.createDefinition<_>
    let IView_HorizontalLayoutAlignment = Attributes.createDefinition<_>
    let IView_IsEnabled = Attributes.createDefinition<_>
    let IView_Margin = Attributes.createDefinition<_>
    let IView_MaximumHeight = Attributes.createDefinition<_>
    let IView_MaximumWidth = Attributes.createDefinition<_>
    let IView_MinimumHeight = Attributes.createDefinition<_>
    let IView_MinimumWidth = Attributes.createDefinition<_>
    let IView_Opacity = Attributes.createDefinition<_>
    let IView_Semantics = Attributes.createDefinition<_>
    let IView_VerticalLayoutAlignment = Attributes.createDefinition<_>
    let IView_Visibility = Attributes.createDefinition<_>
    let IView_Width = Attributes.createDefinition<_>
    let ITransform_AnchorX = Attributes.createDefinition<_>
    let ITransform_AnchorY = Attributes.createDefinition<_>
    let ITransform_Rotation = Attributes.createDefinition<_>
    let ITransform_RotationX = Attributes.createDefinition<_>
    let ITransform_RotationY = Attributes.createDefinition<_>
    let ITransform_Scale = Attributes.createDefinition<_>
    let ITransform_ScaleX = Attributes.createDefinition<_>
    let ITransform_ScaleY = Attributes.createDefinition<_>
    let ITransform_TranslationX = Attributes.createDefinition<_>
    let ITransform_TranslationY = Attributes.createDefinition<_>
    let ILayout_Padding = Attributes.createDefinition<_>
    let ISafeAreaView_IgnoreSafeArea = Attributes.createDefinition<_>
    let ILabel_LineBreakMode = Attributes.createDefinition<_>
    let ILabel_LineHeight = Attributes.createDefinition<_>
    let ILabel_MaxLines = Attributes.createDefinition<_>
    let ILabel_TextDecorations = Attributes.createDefinition<_>
    let ITextAlignment_HorizontalTextAlignment = Attributes.createDefinition<_>
    let ITextAlignment_VerticalTextAlignment = Attributes.createDefinition<_>

// MAUI CONTROLS

type FabulousComponent() =
    let mutable _attributes: Attribute[] = [||]

    member this.SetAttributes(attributes) =
        _attributes <- attributes

    member this.TryGetAttributeValue<'_a, 'modelType>(attrDef: Attributes.AttributeDefinition<'_a, 'modelType>): 'modelType option =
        _attributes
        |> Array.tryFind (fun a -> a.Key = attrDef.Key)
        |> Option.map (fun a -> unbox a.Value)

    member this.GetAttributeValueOrDefault<'_a, 'modelType>(attrDef: Attributes.AttributeDefinition<'_a, 'modelType>, defaultWith) =
        match this.TryGetAttributeValue(attrDef) with
        | None -> defaultWith ()
        | Some value -> value

    member this.TryExecuteFunction(attrDef: Attributes.AttributeDefinition<_,_>, arg) =
        match this.TryGetAttributeValue attrDef with
        | None -> ()
        | Some fn -> fn arg

type FabulousApplication () =
    inherit FabulousComponent()

    let _windows = List<IWindow>()

    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.ThemeChanged() = this.TryExecuteFunction(Attributes.IApplication_ThemeChanged, ())
        member this.Windows =
            match this.TryGetAttributeValue Attributes.IApplication_Windows with
            | None -> ()
            | Some windowWidgets ->
                for widget in windowWidgets do
                    let view = unbox ((widget :> IWindowWidget).CreateView())
                    _windows.Add(view)

            _windows :> IReadOnlyList<_>
                
        
type FabulousWindow () =
    inherit FabulousComponent()

    interface IWindow with
        member this.Activated() = this.TryExecuteFunction(Attributes.IWindow_Activated, ())
        member this.Created() = this.TryExecuteFunction(Attributes.IWindow_Created, ())
        member this.Deactivated() = this.TryExecuteFunction(Attributes.IWindow_Deactivated, ())
        member this.Destroying() = this.TryExecuteFunction(Attributes.IWindow_Destroying, ())
        member this.Resumed() = this.TryExecuteFunction(Attributes.IWindow_Resumed, ())
        member this.Stopped() = this.TryExecuteFunction(Attributes.IWindow_Stopped, ())
        member this.Content = 
            match this.TryGetAttributeValue(Attributes.IWindow_Content) with
            | None -> null
            | Some widget ->
                let view = unbox (widget.CreateView())
                view

        member val Handler = Microsoft.Maui.Handlers.WindowHandler() :> IElementHandler with get, set
        member this.Parent = failwith "todo"
        member this.Title = this.GetAttributeValueOrDefault(Attributes.IWindow_Title, (fun () -> ""))
        
type FabulousVerticalStackLayout () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.LayoutHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()

    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorX, fun () -> 0.5)
        member this.AnchorY = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorY, fun () -> 0.5)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = this.GetAttributeValueOrDefault(Attributes.IView_AutomationId, fun () -> null)
        member this.Background = this.GetAttributeValueOrDefault(Attributes.IView_Background, fun () -> null)
        member this.Clear() = failwith "todo"
        member this.Clip = this.GetAttributeValueOrDefault(Attributes.IView_Clip, fun () -> null)
        member this.Contains(item: IView) = _children.Contains(item)
        member this.CopyTo(array: IView [], arrayIndex: int) = failwith "todo"
        member this.Count = _children.Count
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = this.GetAttributeValueOrDefault(Attributes.IView_FlowDirection, fun () -> FlowDirection.LeftToRight)
        member this.Frame
            with get (): Rectangle = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.GetEnumerator() =
            _children.Clear()
            match this.TryGetAttributeValue(Attributes.IContainer_Children) with
            | None -> ()
            | Some children ->
                for child in children do
                    let view = unbox ((child :> IViewWidget).CreateView())
                    _children.Add(view)
        
            _children.GetEnumerator() :> System.Collections.Generic.IEnumerator<IView>

        member this.GetEnumerator() = _children.GetEnumerator() :> System.Collections.IEnumerator
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler) = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler) = _handler <- v
        member this.Height = this.GetAttributeValueOrDefault(Attributes.IView_Height, fun () -> -1.)
        member this.HorizontalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_HorizontalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Start)
        member this.IgnoreSafeArea = this.GetAttributeValueOrDefault(Attributes.ISafeAreaView_IgnoreSafeArea, fun () -> false)
        member this.IndexOf(item: IView) = _children.IndexOf(item)
        member this.Insert(index: int, item: IView) = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = this.GetAttributeValueOrDefault(Attributes.IView_IsEnabled, fun () -> true)
        member this.IsReadOnly = true
        member this.Item
            with get (index: int): IView = _children.[index]
            and set (index: int) (v: IView): unit = failwith "todo"
        member this.LayoutManager = Microsoft.Maui.Layouts.VerticalStackLayoutManager(this) :> Microsoft.Maui.Layouts.ILayoutManager
        member this.Margin = this.GetAttributeValueOrDefault(Attributes.IView_Margin, fun () -> Thickness.Zero)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MinimumWidth, fun () -> -1.)
        member this.MinimumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MinimumHeight, fun () -> -1.)
        member this.MaximumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MaximumWidth, fun () -> -1.)
        member this.MaximumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MaximumHeight, fun () -> -1.)
        member this.Opacity = this.GetAttributeValueOrDefault(Attributes.IView_Opacity, fun () -> 1.)
        member this.Padding = this.GetAttributeValueOrDefault(Attributes.ILayout_Padding, fun () -> Thickness.Zero)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Remove(item: IView) = failwith "todo"
        member this.RemoveAt(index: int) = failwith "todo"
        member this.Rotation = this.GetAttributeValueOrDefault(Attributes.ITransform_Rotation, fun () -> 0.)
        member this.RotationX = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationX, fun () -> 0.)
        member this.RotationY = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationY, fun () -> 0.)
        member this.Scale = this.GetAttributeValueOrDefault(Attributes.ITransform_Scale, fun () -> 1.)
        member this.ScaleX = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleX, fun () -> 1.)
        member this.ScaleY = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleY, fun () -> 1.)
        member this.Semantics = this.GetAttributeValueOrDefault(Attributes.IView_Semantics, fun () -> Semantics())
        member this.Spacing = this.GetAttributeValueOrDefault(Attributes.IStackLayout_Spacing, fun () -> 0.)
        member this.TranslationX = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationX, fun () -> 0.)
        member this.TranslationY = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationY, fun () -> 0.)
        member this.VerticalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_VerticalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Start)
        member this.Visibility = this.GetAttributeValueOrDefault(Attributes.IView_Visibility, fun () -> Visibility.Visible)
        member this.Width = this.GetAttributeValueOrDefault(Attributes.IView_Width, fun () -> -1.)
        
type FabulousLabel () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.LabelHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface ILabel with
        member this.AnchorX = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorX, fun () -> 0.5)
        member this.AnchorY = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorY, fun () -> 0.5)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = this.GetAttributeValueOrDefault(Attributes.IView_AutomationId, fun () -> null)
        member this.Background = this.GetAttributeValueOrDefault(Attributes.IView_Background, fun () -> null)
        member this.CharacterSpacing = this.GetAttributeValueOrDefault(Attributes.ITextStyle_CharacterSpacing, fun () -> 0.)
        member this.Clip = this.GetAttributeValueOrDefault(Attributes.IView_Clip, fun () -> null)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = this.GetAttributeValueOrDefault(Attributes.IView_FlowDirection, fun () -> FlowDirection.LeftToRight)
        member this.Font = this.GetAttributeValueOrDefault(Attributes.ITextStyle_Font, fun () -> Font.Default)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = this.GetAttributeValueOrDefault(Attributes.IView_Height, fun () -> -1.)
        member this.HorizontalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_HorizontalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Start)
        member this.HorizontalTextAlignment = this.GetAttributeValueOrDefault(Attributes.ITextAlignment_HorizontalTextAlignment, fun () -> TextAlignment.Start)
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = this.GetAttributeValueOrDefault(Attributes.IView_IsEnabled, fun () -> true)
        member this.LineBreakMode = this.GetAttributeValueOrDefault(Attributes.ILabel_LineBreakMode, fun () -> LineBreakMode.WordWrap)
        member this.LineHeight = this.GetAttributeValueOrDefault(Attributes.ILabel_LineHeight, fun () -> -1.)
        member this.Margin = this.GetAttributeValueOrDefault(Attributes.IView_Margin, fun () -> Thickness.Zero)
        member this.MaxLines = this.GetAttributeValueOrDefault(Attributes.ILabel_MaxLines, fun () -> -1)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MinimumWidth, fun () -> -1.)
        member this.MinimumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MinimumHeight, fun () -> -1.)
        member this.MaximumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MaximumWidth, fun () -> -1.)
        member this.MaximumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MaximumHeight, fun () -> -1.)
        member this.Opacity = this.GetAttributeValueOrDefault(Attributes.IView_Opacity, fun () -> 1.)
        member this.Padding = this.GetAttributeValueOrDefault(Attributes.ILayout_Padding, fun () -> Thickness.Zero)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Rotation = this.GetAttributeValueOrDefault(Attributes.ITransform_Rotation, fun () -> 0.)
        member this.RotationX = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationX, fun () -> 0.)
        member this.RotationY = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationY, fun () -> 0.)
        member this.Scale = this.GetAttributeValueOrDefault(Attributes.ITransform_Scale, fun () -> 1.)
        member this.ScaleX = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleX, fun () -> 1.)
        member this.ScaleY = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleY, fun () -> 1.)
        member this.Semantics = this.GetAttributeValueOrDefault(Attributes.IView_Semantics, fun () -> Semantics())
        member this.Text = this.GetAttributeValueOrDefault(Attributes.IText_Text, fun () -> "")
        member this.TextColor = this.GetAttributeValueOrDefault(Attributes.ITextStyle_TextColor, fun () -> Colors.Black)
        member this.TextDecorations = this.GetAttributeValueOrDefault(Attributes.ILabel_TextDecorations, fun () -> TextDecorations.None)
        member this.TranslationX = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationX, fun () -> 0.)
        member this.TranslationY = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationY, fun () -> 0.)
        member this.VerticalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_VerticalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Fill)
        member this.VerticalTextAlignment = this.GetAttributeValueOrDefault(Attributes.ITextAlignment_VerticalTextAlignment, fun () -> TextAlignment.Start)
        member this.Visibility = this.GetAttributeValueOrDefault(Attributes.IView_Visibility, fun () -> Visibility.Visible)
        member this.Width = this.GetAttributeValueOrDefault(Attributes.IView_Width, fun () -> -1.)

type FabulousButton () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.ButtonHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface IButton with
        member this.AnchorX = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorX, fun () -> 0.5)
        member this.AnchorY = this.GetAttributeValueOrDefault(Attributes.ITransform_AnchorY, fun () -> 0.5)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = this.GetAttributeValueOrDefault(Attributes.IView_AutomationId, fun () -> null)
        member this.Background = this.GetAttributeValueOrDefault(Attributes.IView_Background, fun () -> null)
        member this.CharacterSpacing = this.GetAttributeValueOrDefault(Attributes.ITextStyle_CharacterSpacing, fun () -> 0.)
        member this.Clicked() = this.TryExecuteFunction(Attributes.IButton_Clicked, ())
        member this.Clip = this.GetAttributeValueOrDefault(Attributes.IView_Clip, fun () -> null)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = this.GetAttributeValueOrDefault(Attributes.IView_FlowDirection, fun () -> FlowDirection.LeftToRight)
        member this.Font = this.GetAttributeValueOrDefault(Attributes.ITextStyle_Font, fun () -> Font.Default)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = this.GetAttributeValueOrDefault(Attributes.IView_Height, fun () -> -1.)
        member this.HorizontalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_HorizontalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Start)
        member this.ImageSource = this.GetAttributeValueOrDefault(Attributes.IButton_ImageSource, fun () -> null)
        member this.ImageSourceLoaded() = this.TryExecuteFunction(Attributes.IButton_ImageSourceLoaded, ())
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = this.GetAttributeValueOrDefault(Attributes.IView_IsEnabled, fun () -> true)
        member this.Margin = this.GetAttributeValueOrDefault(Attributes.IView_Margin, fun () -> Thickness.Zero)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MinimumWidth, fun () -> -1.)
        member this.MinimumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MinimumHeight, fun () -> -1.)
        member this.MaximumWidth = this.GetAttributeValueOrDefault(Attributes.IView_MaximumWidth, fun () -> -1.)
        member this.MaximumHeight = this.GetAttributeValueOrDefault(Attributes.IView_MaximumHeight, fun () -> -1.)
        member this.Opacity = this.GetAttributeValueOrDefault(Attributes.IView_Opacity, fun () -> 1.)
        member this.Padding = this.GetAttributeValueOrDefault(Attributes.ILayout_Padding, fun () -> Thickness.Zero)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Pressed() = this.TryExecuteFunction(Attributes.IButton_Pressed, ())
        member this.Released() = this.TryExecuteFunction(Attributes.IButton_Released, ())
        member this.Rotation = this.GetAttributeValueOrDefault(Attributes.ITransform_Rotation, fun () -> 0.)
        member this.RotationX = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationX, fun () -> 0.)
        member this.RotationY = this.GetAttributeValueOrDefault(Attributes.ITransform_RotationY, fun () -> 0.)
        member this.Scale = this.GetAttributeValueOrDefault(Attributes.ITransform_Scale, fun () -> 1.)
        member this.ScaleX = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleX, fun () -> 1.)
        member this.ScaleY = this.GetAttributeValueOrDefault(Attributes.ITransform_ScaleY, fun () -> 1.)
        member this.Semantics = this.GetAttributeValueOrDefault(Attributes.IView_Semantics, fun () -> Semantics())
        member this.Text = this.GetAttributeValueOrDefault(Attributes.IText_Text, fun () -> "")
        member this.TextColor = this.GetAttributeValueOrDefault(Attributes.ITextStyle_TextColor, fun () -> Colors.Black)
        member this.TranslationX = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationX, fun () -> 0.)
        member this.TranslationY = this.GetAttributeValueOrDefault(Attributes.ITransform_TranslationY, fun () -> 0.)
        member this.VerticalLayoutAlignment = this.GetAttributeValueOrDefault(Attributes.IView_VerticalLayoutAlignment, fun () -> Primitives.LayoutAlignment.Fill)
        member this.Visibility = this.GetAttributeValueOrDefault(Attributes.IView_Visibility, fun () -> Visibility.Visible)
        member this.Width = this.GetAttributeValueOrDefault(Attributes.IView_Width, fun () -> -1.)

// WIDGETS

type [<Struct>] ApplicationWidget (attributes: Attribute[]) =
    static do register<ApplicationWidget, FabulousApplication>()

    static member inline Create(windows: seq<#IWindowWidget>) =
        ApplicationWidget([| Attributes.IApplication_Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) |])
    
    interface IApplicationWidget with
        member this.CreateView() =
            let view = FabulousApplication()
            view.SetAttributes(attributes)
            box view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute ApplicationWidget attributes attribute
        
type [<Struct>] WindowWidget (attributes: Attribute[]) =
    static do register<WindowWidget, FabulousWindow>()
    
    static member inline Create(title: string, content: #IViewWidget) =
        WindowWidget(
            [| Attributes.IWindow_Title.WithValue(title)
               Attributes.IWindow_Content.WithValue(content) |]
        )
    
    interface IWindowWidget with
        member this.CreateView() =
            let view = FabulousWindow()
            view.SetAttributes(attributes)
            box view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute WindowWidget attributes attribute
        
type [<Struct>] VerticalStackLayoutWidget (attributes: Attribute[]) =
    static do register<VerticalStackLayoutWidget, FabulousVerticalStackLayout>()
    
    static member inline Create(children: seq<IViewWidget>) =        
        VerticalStackLayoutWidget([| Attributes.IContainer_Children.WithValue(children) |])
        
    interface IViewWidget with
        member this.CreateView() =
            let view = FabulousVerticalStackLayout()
            view.SetAttributes(attributes)
            box view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute VerticalStackLayoutWidget attributes attribute
        
type [<Struct>] LabelWidget (attributes: Attribute[]) =
    static do register<LabelWidget, FabulousLabel>()
    
    static member inline Create(text: string) =
        LabelWidget([| Attributes.IText_Text.WithValue(text) |])
        
    interface IViewWidget with
        member this.CreateView() = 
            let view = FabulousLabel()
            view.SetAttributes(attributes)
            view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute LabelWidget attributes attribute
        
type [<Struct>] ButtonWidget (attributes: Attribute[]) =
    static do register<ButtonWidget, FabulousButton>()
    
    static member inline Create(text: string, clicked: #obj) =
        ButtonWidget
            [| Attributes.IText_Text.WithValue(text)
               Attributes.IButton_Clicked.WithValue(ignore) |]

    interface IViewWidget with
        member this.CreateView() =
            let view = FabulousButton()
            view.SetAttributes(attributes)
            box view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute ButtonWidget attributes attribute

// EXTENSIONS
    
[<Extension>] 
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline background<'T when 'T :> IViewWidget and 'T :> IControlWidget>(this: 'T, value: Paint) =
        this.AddAttribute(Attributes.IView_Background.WithValue(value))
    [<Extension>]
    static member inline font<'T when 'T :> IViewWidget and 'T :> IControlWidget>(this: 'T, value: Font) =
        this.AddAttribute(Attributes.ITextStyle_Font.WithValue(value))
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline textColor(this: LabelWidget, value: Color) =
        this.AddAttribute(Attributes.ITextStyle_TextColor.WithValue(value))
        
[<Extension>]
type VerticalStackLayoutExtensions () =
    [<Extension>]
    static member inline spacing(this: VerticalStackLayoutWidget, value: float) =
        this.AddAttribute(Attributes.IStackLayout_Spacing.WithValue(value))
        
// EXPOSITION

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application(windows) = ApplicationWidget.Create(windows)
    static member inline Window(title, content) = WindowWidget.Create(title, content)
    static member inline VerticalStackLayout(children) = VerticalStackLayoutWidget.Create(children)
    static member inline Label(text) = LabelWidget.Create(text)
    static member inline Button(text, clicked) = ButtonWidget.Create(text, clicked)
    