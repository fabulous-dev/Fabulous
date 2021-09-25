namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous.ControlWidget
open System.Collections.Generic
open Attributes

// MAUI CONTROLS

type FabulousComponent() =
    let mutable _attributes: Attribute[] = [||]

    member this.SetAttributes(attributes) =
        _attributes <- attributes

    member this.Attributes = _attributes

type FabulousApplication () =
    inherit FabulousComponent()

    let _windows = List<IWindow>()

    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.ThemeChanged() = Application.ThemeChanged.Execute(this.Attributes, ())
        member this.Windows =
            match Application.Windows.TryGetValue(this.Attributes) with
            | None -> ()
            | Some windowWidgets ->
                for widget in windowWidgets do
                    let view = unbox (widget.CreateView())
                    _windows.Add(view)

            _windows :> IReadOnlyList<_>
                
        
type FabulousWindow () =
    inherit FabulousComponent()

    let mutable _handler = Microsoft.Maui.Handlers.WindowHandler() :> IElementHandler

    interface IWindow with
        member this.Activated() = Window.Activated.Execute(this.Attributes, ())
        member this.Created() = Window.Created.Execute(this.Attributes, ())
        member this.Deactivated() = Window.Deactivated.Execute(this.Attributes, ())
        member this.Destroying() = Window.Destroying.Execute(this.Attributes, ())
        member this.Resumed() = Window.Resumed.Execute(this.Attributes, ())
        member this.Stopped() = Window.Stopped.Execute(this.Attributes, ())
        member this.Content = 
            match Window.Content.TryGetValue(this.Attributes) with
            | None -> null
            | Some ValueNone -> null
            | Some (ValueSome widget) ->
                let view = unbox (widget.CreateView())
                view
        member this.Handler 
            with get() = _handler
            and set(v) = _handler <- v
        member this.Parent = failwith "todo"
        member this.Title = Window.Title.GetValue(this.Attributes)
        
type FabulousVerticalStackLayout () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.LayoutHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()

    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this.Attributes)
        member this.Background = View.Background.GetValue(this.Attributes)
        member this.Clear() = failwith "todo"
        member this.Clip = View.Clip.GetValue(this.Attributes)
        member this.Contains(item: IView) = _children.Contains(item)
        member this.CopyTo(array: IView [], arrayIndex: int) = failwith "todo"
        member this.Count = _children.Count
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this.Attributes)
        member this.Frame
            with get (): Rectangle = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.GetEnumerator() =
            _children.Clear()
            match Container.Children.TryGetValue(this.Attributes) with
            | None -> ()
            | Some children ->
                for child in children do
                    let view = unbox (child.CreateView())
                    _children.Add(view)
        
            _children.GetEnumerator() :> System.Collections.Generic.IEnumerator<IView>

        member this.GetEnumerator() = _children.GetEnumerator() :> System.Collections.IEnumerator
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler) = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler) = _handler <- v
        member this.Height = View.Height.GetValue(this.Attributes)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this.Attributes)
        member this.IgnoreSafeArea = SafeAreaView.IgnoreSafeArea.GetValue(this.Attributes)
        member this.IndexOf(item: IView) = _children.IndexOf(item)
        member this.Insert(index: int, item: IView) = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this.Attributes)
        member this.IsReadOnly = true
        member this.Item
            with get (index: int): IView = _children.[index]
            and set (index: int) (v: IView): unit = failwith "todo"
        member this.LayoutManager = Microsoft.Maui.Layouts.VerticalStackLayoutManager(this) :> Microsoft.Maui.Layouts.ILayoutManager
        member this.Margin = View.Margin.GetValue(this.Attributes)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this.Attributes)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this.Attributes)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this.Attributes)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this.Attributes)
        member this.Opacity = View.Opacity.GetValue(this.Attributes)
        member this.Padding = Layout.Padding.GetValue(this.Attributes)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Remove(item: IView) = failwith "todo"
        member this.RemoveAt(index: int) = failwith "todo"
        member this.Rotation = Transform.Rotation.GetValue(this.Attributes)
        member this.RotationX = Transform.RotationX.GetValue(this.Attributes)
        member this.RotationY = Transform.RotationY.GetValue(this.Attributes)
        member this.Scale = Transform.Scale.GetValue(this.Attributes)
        member this.ScaleX = Transform.ScaleX.GetValue(this.Attributes)
        member this.ScaleY = Transform.ScaleY.GetValue(this.Attributes)
        member this.Semantics = View.Semantics.GetValue(this.Attributes)
        member this.Spacing = StackLayout.Spacing.GetValue(this.Attributes)
        member this.TranslationX = Transform.TranslationX.GetValue(this.Attributes)
        member this.TranslationY = Transform.TranslationY.GetValue(this.Attributes)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this.Attributes)
        member this.Visibility = View.Visibility.GetValue(this.Attributes)
        member this.Width = View.Width.GetValue(this.Attributes)
        
type FabulousLabel () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.LabelHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface ILabel with
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this.Attributes)
        member this.Background = View.Background.GetValue(this.Attributes)
        member this.CharacterSpacing = TextStyle.CharacterSpacing.GetValue(this.Attributes)
        member this.Clip = View.Clip.GetValue(this.Attributes)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this.Attributes)
        member this.Font = TextStyle.Font.GetValue(this.Attributes)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = View.Height.GetValue(this.Attributes)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this.Attributes)
        member this.HorizontalTextAlignment = TextAlignment.HorizontalTextAlignment.GetValue(this.Attributes)
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this.Attributes)
        member this.LineBreakMode = Label.LineBreakMode.GetValue(this.Attributes)
        member this.LineHeight = Label.LineHeight.GetValue(this.Attributes)
        member this.Margin = View.Margin.GetValue(this.Attributes)
        member this.MaxLines = Label.MaxLines.GetValue(this.Attributes)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this.Attributes)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this.Attributes)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this.Attributes)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this.Attributes)
        member this.Opacity = View.Opacity.GetValue(this.Attributes)
        member this.Padding = Layout.Padding.GetValue(this.Attributes)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Rotation = Transform.Rotation.GetValue(this.Attributes)
        member this.RotationX = Transform.RotationX.GetValue(this.Attributes)
        member this.RotationY = Transform.RotationY.GetValue(this.Attributes)
        member this.Scale = Transform.Scale.GetValue(this.Attributes)
        member this.ScaleX = Transform.ScaleX.GetValue(this.Attributes)
        member this.ScaleY = Transform.ScaleY.GetValue(this.Attributes)
        member this.Semantics = View.Semantics.GetValue(this.Attributes)
        member this.Text = Text.Text.GetValue(this.Attributes)
        member this.TextColor = TextStyle.TextColor.GetValue(this.Attributes)
        member this.TextDecorations = Label.TextDecorations.GetValue(this.Attributes)
        member this.TranslationX = Transform.TranslationX.GetValue(this.Attributes)
        member this.TranslationY = Transform.TranslationY.GetValue(this.Attributes)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this.Attributes)
        member this.VerticalTextAlignment = TextAlignment.VerticalTextAlignment.GetValue(this.Attributes)
        member this.Visibility = View.Visibility.GetValue(this.Attributes)
        member this.Width = View.Width.GetValue(this.Attributes)

type FabulousButton () =
    inherit FabulousComponent()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.ButtonHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface IButton with
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this.Attributes)
        member this.Background = View.Background.GetValue(this.Attributes)
        member this.CharacterSpacing = TextStyle.CharacterSpacing.GetValue(this.Attributes)
        member this.Clicked() = Button.Clicked.Execute(this.Attributes, ())
        member this.Clip = View.Clip.GetValue(this.Attributes)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this.Attributes)
        member this.Font = TextStyle.Font.GetValue(this.Attributes)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = View.Height.GetValue(this.Attributes)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this.Attributes)
        member this.ImageSource = Button.ImageSource.GetValue(this.Attributes)
        member this.ImageSourceLoaded() = Button.ImageSourceLoaded.Execute(this.Attributes, ())
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this.Attributes)
        member this.Margin = View.Margin.GetValue(this.Attributes)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this.Attributes)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this.Attributes)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this.Attributes)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this.Attributes)
        member this.Opacity = View.Opacity.GetValue(this.Attributes)
        member this.Padding = Layout.Padding.GetValue(this.Attributes)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Pressed() = Button.Pressed.Execute(this.Attributes, ())
        member this.Released() = Button.Released.Execute(this.Attributes, ())
        member this.Rotation = Transform.Rotation.GetValue(this.Attributes)
        member this.RotationX = Transform.RotationX.GetValue(this.Attributes)
        member this.RotationY = Transform.RotationY.GetValue(this.Attributes)
        member this.Scale = Transform.Scale.GetValue(this.Attributes)
        member this.ScaleX = Transform.ScaleX.GetValue(this.Attributes)
        member this.ScaleY = Transform.ScaleY.GetValue(this.Attributes)
        member this.Semantics = View.Semantics.GetValue(this.Attributes)
        member this.Text = Text.Text.GetValue(this.Attributes)
        member this.TextColor = TextStyle.TextColor.GetValue(this.Attributes)
        member this.TranslationX = Transform.TranslationX.GetValue(this.Attributes)
        member this.TranslationY = Transform.TranslationY.GetValue(this.Attributes)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this.Attributes)
        member this.Visibility = View.Visibility.GetValue(this.Attributes)
        member this.Width = View.Width.GetValue(this.Attributes)

// WIDGETS

type [<Struct>] ApplicationWidget (attributes: Attribute[]) =
    static do register<ApplicationWidget, FabulousApplication>()

    static member inline Create(windows: seq<#IWindowWidget>) =
        ApplicationWidget([| Application.Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) |])
    
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
            [| Window.Title.WithValue(title)
               Window.Content.WithValue(ValueSome (content :> IViewWidget)) |]
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
        VerticalStackLayoutWidget([| Container.Children.WithValue(children) |])
        
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
        LabelWidget([| Text.Text.WithValue(text) |])
        
    interface IViewWidget with
        member this.CreateView() = 
            let view = FabulousLabel()
            view.SetAttributes(attributes)
            box view

    interface IControlWidget with
        member this.Add(attribute) = addAttribute LabelWidget attributes attribute
        
type [<Struct>] ButtonWidget (attributes: Attribute[]) =
    static do register<ButtonWidget, FabulousButton>()
    
    static member inline Create(text: string, clicked: #obj) =
        ButtonWidget
            [| Text.Text.WithValue(text)
               Button.Clicked.WithValue(ignore) |]

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
        this.AddAttribute(View.Background.WithValue(value))
    [<Extension>]
    static member inline font<'T when 'T :> IViewWidget and 'T :> IControlWidget>(this: 'T, value: Font) =
        this.AddAttribute(TextStyle.Font.WithValue(value))
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline textColor(this: LabelWidget, value: Color) =
        this.AddAttribute(TextStyle.TextColor.WithValue(value))
        
[<Extension>]
type VerticalStackLayoutExtensions () =
    [<Extension>]
    static member inline spacing(this: VerticalStackLayoutWidget, value: float) =
        this.AddAttribute(StackLayout.Spacing.WithValue(value))
        
// EXPOSITION

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application(windows) = ApplicationWidget.Create(windows)
    static member inline Window(title, content) = WindowWidget.Create(title, content)
    static member inline VerticalStackLayout(children) = VerticalStackLayoutWidget.Create(children)
    static member inline Label(text) = LabelWidget.Create(text)
    static member inline Button(text, clicked) = ButtonWidget.Create(text, clicked)
    