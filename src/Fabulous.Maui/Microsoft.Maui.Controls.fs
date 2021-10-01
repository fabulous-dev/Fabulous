namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous.Widgets
open System.Collections.Generic
open Attributes
open Fabulous.Widgets.ControlWidget
open Fabulous.Maui.Widgets

// MAUI CONTROLS

type ControlView() =
    let mutable _attributes: Attribute[] = [||]

    interface IControlView with
        member _.Attributes = _attributes
        member _.SetAttributes(attributes) =
            _attributes <- attributes

type FabulousApplication () =
    inherit ControlView()

    let _windows = List<IWindow>()

    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.ThemeChanged() = Application.ThemeChanged.Execute(this, ())
        member this.Windows =
            match Application.Windows.TryGetValue(this) with
            | None -> ()
            | Some windowWidgets ->
                for widget in windowWidgets do
                    let view = unbox (widget.CreateView())
                    _windows.Add(view)

            _windows :> IReadOnlyList<_>
                
        
type FabulousWindow () =
    inherit ControlView()

    let mutable _handler = Microsoft.Maui.Handlers.WindowHandler() :> IElementHandler

    interface IWindow with
        member this.Activated() = Window.Activated.Execute(this, ())
        member this.Created() = Window.Created.Execute(this, ())
        member this.Deactivated() = Window.Deactivated.Execute(this, ())
        member this.Destroying() = Window.Destroying.Execute(this, ())
        member this.Resumed() = Window.Resumed.Execute(this, ())
        member this.Stopped() = Window.Stopped.Execute(this, ())
        member this.Content = 
            match Window.Content.TryGetValue(this) with
            | None -> null
            | Some ValueNone -> null
            | Some (ValueSome widget) ->
                let view = unbox (widget.CreateView())
                view
        member this.Handler 
            with get() = _handler
            and set(v) = _handler <- v
        member this.Parent = failwith "todo"
        member this.Title = Window.Title.GetValue(this)
        
type FabulousVerticalStackLayout () =
    inherit ControlView()

    let mutable _handler: IViewHandler = Microsoft.Maui.Handlers.LayoutHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()

    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this)
        member this.Background = View.Background.GetValue(this)
        member this.Clear() = failwith "todo"
        member this.Clip = View.Clip.GetValue(this)
        member this.Contains(item: IView) = _children.Contains(item)
        member this.CopyTo(array: IView [], arrayIndex: int) = failwith "todo"
        member this.Count = _children.Count
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this)
        member this.Frame
            with get (): Rectangle = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.GetEnumerator() =
            _children.Clear()
            match Container.Children.TryGetValue(this) with
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
        member this.Height = View.Height.GetValue(this)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this)
        member this.IgnoreSafeArea = SafeAreaView.IgnoreSafeArea.GetValue(this)
        member this.IndexOf(item: IView) = _children.IndexOf(item)
        member this.Insert(index: int, item: IView) = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this)
        member this.IsReadOnly = true
        member this.Item
            with get (index: int): IView = _children.[index]
            and set (index: int) (v: IView): unit = failwith "todo"
        member this.LayoutManager = Microsoft.Maui.Layouts.VerticalStackLayoutManager(this) :> Microsoft.Maui.Layouts.ILayoutManager
        member this.Margin = View.Margin.GetValue(this)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this)
        member this.Opacity = View.Opacity.GetValue(this)
        member this.Padding = Layout.Padding.GetValue(this)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Remove(item: IView) = failwith "todo"
        member this.RemoveAt(index: int) = failwith "todo"
        member this.Rotation = Transform.Rotation.GetValue(this)
        member this.RotationX = Transform.RotationX.GetValue(this)
        member this.RotationY = Transform.RotationY.GetValue(this)
        member this.Scale = Transform.Scale.GetValue(this)
        member this.ScaleX = Transform.ScaleX.GetValue(this)
        member this.ScaleY = Transform.ScaleY.GetValue(this)
        member this.Semantics = View.Semantics.GetValue(this)
        member this.Spacing = StackLayout.Spacing.GetValue(this)
        member this.TranslationX = Transform.TranslationX.GetValue(this)
        member this.TranslationY = Transform.TranslationY.GetValue(this)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this)
        member this.Visibility = View.Visibility.GetValue(this)
        member this.Width = View.Width.GetValue(this)
        
type FabulousLabel () =
    inherit ControlView()

    let mutable _handler = Microsoft.Maui.Handlers.LabelHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface ILabel with
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this)
        member this.Background = View.Background.GetValue(this)
        member this.CharacterSpacing = TextStyle.CharacterSpacing.GetValue(this)
        member this.Clip = View.Clip.GetValue(this)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this)
        member this.Font = TextStyle.Font.GetValue(this)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = View.Height.GetValue(this)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this)
        member this.HorizontalTextAlignment = TextAlignment.HorizontalTextAlignment.GetValue(this)
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this)
        member this.LineBreakMode = Label.LineBreakMode.GetValue(this)
        member this.LineHeight = Label.LineHeight.GetValue(this)
        member this.Margin = View.Margin.GetValue(this)
        member this.MaxLines = Label.MaxLines.GetValue(this)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this)
        member this.Opacity = View.Opacity.GetValue(this)
        member this.Padding = Layout.Padding.GetValue(this)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Rotation = Transform.Rotation.GetValue(this)
        member this.RotationX = Transform.RotationX.GetValue(this)
        member this.RotationY = Transform.RotationY.GetValue(this)
        member this.Scale = Transform.Scale.GetValue(this)
        member this.ScaleX = Transform.ScaleX.GetValue(this)
        member this.ScaleY = Transform.ScaleY.GetValue(this)
        member this.Semantics = View.Semantics.GetValue(this)
        member this.Text = Text.Text.GetValue(this)
        member this.TextColor = TextStyle.TextColor.GetValue(this)
        member this.TextDecorations = Label.TextDecorations.GetValue(this)
        member this.TranslationX = Transform.TranslationX.GetValue(this)
        member this.TranslationY = Transform.TranslationY.GetValue(this)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this)
        member this.VerticalTextAlignment = TextAlignment.VerticalTextAlignment.GetValue(this)
        member this.Visibility = View.Visibility.GetValue(this)
        member this.Width = View.Width.GetValue(this)

type FabulousButton () =
    inherit ControlView()

    let mutable _handler = Microsoft.Maui.Handlers.ButtonHandler() :> IViewHandler
    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface IButton with
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if _handler <> null then _handler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this)
        member this.Background = View.Background.GetValue(this)
        member this.CharacterSpacing = TextStyle.CharacterSpacing.GetValue(this)
        member this.Clicked() = Button.Clicked.Execute(this, ())
        member this.Clip = View.Clip.GetValue(this)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this)
        member this.Font = TextStyle.Font.GetValue(this)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = _handler :> IElementHandler
            and set (v: IElementHandler): unit = _handler <- (v :?> IViewHandler)
        member this.Handler
            with get () = _handler
            and set (v: IViewHandler): unit = _handler <- v
        member this.Height = View.Height.GetValue(this)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this)
        member this.ImageSource = Button.ImageSource.GetValue(this)
        member this.ImageSourceLoaded() = Button.ImageSourceLoaded.Execute(this, ())
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.IsEnabled = View.IsEnabled.GetValue(this)
        member this.Margin = View.Margin.GetValue(this)
        member this.Measure(widthConstraint: float, heightConstraint: float) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.MinimumWidth = View.MinimumWidth.GetValue(this)
        member this.MinimumHeight = View.MinimumHeight.GetValue(this)
        member this.MaximumWidth = View.MaximumWidth.GetValue(this)
        member this.MaximumHeight = View.MaximumHeight.GetValue(this)
        member this.Opacity = View.Opacity.GetValue(this)
        member this.Padding = Layout.Padding.GetValue(this)
        member this.Parent: IElement = 
            raise (System.NotImplementedException())
        member this.Parent: IView = 
            raise (System.NotImplementedException())
        member this.Pressed() = Button.Pressed.Execute(this, ())
        member this.Released() = Button.Released.Execute(this, ())
        member this.Rotation = Transform.Rotation.GetValue(this)
        member this.RotationX = Transform.RotationX.GetValue(this)
        member this.RotationY = Transform.RotationY.GetValue(this)
        member this.Scale = Transform.Scale.GetValue(this)
        member this.ScaleX = Transform.ScaleX.GetValue(this)
        member this.ScaleY = Transform.ScaleY.GetValue(this)
        member this.Semantics = View.Semantics.GetValue(this)
        member this.Text = Text.Text.GetValue(this)
        member this.TextColor = TextStyle.TextColor.GetValue(this)
        member this.TranslationX = Transform.TranslationX.GetValue(this)
        member this.TranslationY = Transform.TranslationY.GetValue(this)
        member this.VerticalLayoutAlignment = View.VerticalLayoutAlignment.GetValue(this)
        member this.Visibility = View.Visibility.GetValue(this)
        member this.Width = View.Width.GetValue(this)

// WIDGETS

type [<Struct>] ApplicationWidget (attributes: Attribute[]) =
    static do ControlWidget.register<ApplicationWidget, FabulousApplication>()

    static member inline Create(windows: seq<#IWindowWidget>) =
        ApplicationWidget([| Application.Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) |])
            
    interface IApplicationControlWidget with
        member _.Attributes = attributes
        member _.CreateView() = ControlWidget.createView<FabulousApplication> attributes
        
type [<Struct>] WindowWidget (attributes: Attribute[]) =
    static do ControlWidget.register<WindowWidget, FabulousWindow>()
    
    static member inline Create(title: string, content: #IViewWidget) =
        WindowWidget(
            [| Window.Title.WithValue(title)
               Window.Content.WithValue(ValueSome (content :> IViewWidget)) |]
        )
        
    interface IWindowControlWidget with
        member _.Attributes = attributes
        member _.CreateView() = ControlWidget.createView<FabulousWindow> attributes
        
type [<Struct>] VerticalStackLayoutWidget (attributes: Attribute[]) =
    static do ControlWidget.register<VerticalStackLayoutWidget, FabulousVerticalStackLayout>()
    
    static member inline Create(children: seq<IViewWidget>) =        
        VerticalStackLayoutWidget([| Container.Children.WithValue(children) |])
        
    interface IViewControlWidget with
        member _.Attributes = attributes
        member _.CreateView() = ControlWidget.createView<FabulousVerticalStackLayout> attributes
        
type [<Struct>] LabelWidget (attributes: Attribute[]) =
    static do ControlWidget.register<LabelWidget, FabulousLabel>()
    
    static member inline Create(text: string) =
        LabelWidget([| Text.Text.WithValue(text) |])
        
    interface IViewControlWidget with
        member _.Attributes = attributes
        member _.CreateView() = ControlWidget.createView<FabulousLabel> attributes
        
type [<Struct>] ButtonWidget (attributes: Attribute[]) =
    static do ControlWidget.register<ButtonWidget, FabulousButton>()
    
    static member inline Create(text: string, clicked: #obj) =
        ButtonWidget
            [| Text.Text.WithValue(text)
               Button.Clicked.WithValue(ignore) |]

    interface IViewControlWidget with
        member _.Attributes = attributes
        member _.CreateView() = ControlWidget.createView<FabulousButton> attributes

// EXTENSIONS
    
[<Extension>] 
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline background(this: ^T when ^T :> IViewControlWidget, value: Paint) =
        this.AddAttribute(View.Background.WithValue(value))
    [<Extension>]
    static member inline font(this: ^T when ^T :> IViewControlWidget, value: Font) =
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
    