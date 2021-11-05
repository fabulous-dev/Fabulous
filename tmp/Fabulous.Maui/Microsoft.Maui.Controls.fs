namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open System.Collections.Generic
open Fabulous
open Fabulous.Attributes
open Fabulous.Maui.Attributes

// MAUI CONTROLS

type FabulousApplication () =
    inherit ViewNode(null)

    let _windows = List<IWindow>()

    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.ThemeChanged() = Application.ThemeChanged.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Windows =
            match Application.Windows.TryGetValue(this.Attributes) with
            | None -> ()
            | Some windowWidgets ->
                for widget in windowWidgets do
                    let definition = WidgetDefinitionStore.get widget.Key
                    let view = definition.CreateView()
                    let diff = Reconciler.diff ValueNone widget
                    view.SetContext(this.Context)
                    view.ApplyDiff(diff)
                    _windows.Add(view :?> IWindow)

            _windows :> IReadOnlyList<_>
                
        
type FabulousWindow () =
    inherit ViewNode(Microsoft.Maui.Handlers.WindowHandler())

    interface IWindow with
        member this.Activated() = Window.Activated.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Created() = Window.Created.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Deactivated() = Window.Deactivated.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Destroying() = Window.Destroying.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Resumed() = Window.Resumed.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Stopped() = Window.Stopped.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Content = 
            match Window.Content.TryGetValue(this.Attributes) with
            | None -> null
            | Some ValueNone -> null
            | Some (ValueSome widget) ->
                let definition = WidgetDefinitionStore.get widget.Key
                let view = definition.CreateView()
                let diff = Reconciler.diff ValueNone widget
                view.SetContext(this.Context)
                view.ApplyDiff(diff)
                view :?> IView
        member this.Handler 
            with get() = this.Handler
            and set(v) = this.Handler <- v
        member this.Parent = failwith "todo"
        member this.Title = Window.Title.GetValue(this.Attributes)
        
type FabulousVerticalStackLayout () =
    inherit ViewNode(Microsoft.Maui.Handlers.LayoutHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()

    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
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
            | Some widgets ->
                for widget in widgets do
                    let definition = WidgetDefinitionStore.get widget.Key
                    let view = definition.CreateView()
                    let diff = Reconciler.diff ValueNone widget
                    view.SetContext(this.Context)
                    view.ApplyDiff(diff)
                    _children.Add(view :?> IView)
        
            _children.GetEnumerator() :> System.Collections.Generic.IEnumerator<IView>

        member this.GetEnumerator() = _children.GetEnumerator() :> System.Collections.IEnumerator
        member this.Handler
            with get () = this.Handler
            and set (v: IElementHandler) = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler) = this.ViewHandler <- v
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
    inherit ViewNode(Microsoft.Maui.Handlers.LabelHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface ILabel with
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
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
            with get () = this.Handler
            and set (v: IElementHandler): unit = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler): unit = this.ViewHandler <- v
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
    inherit ViewNode(Microsoft.Maui.Handlers.ButtonHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface IButton with
        member this.AnchorX = Transform.AnchorX.GetValue(this.Attributes)
        member this.AnchorY = Transform.AnchorY.GetValue(this.Attributes)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
            _frame.Size
        member this.AutomationId = View.AutomationId.GetValue(this.Attributes)
        member this.Background = View.Background.GetValue(this.Attributes)
        member this.CharacterSpacing = TextStyle.CharacterSpacing.GetValue(this.Attributes)
        member this.Clicked() = Button.Clicked.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Clip = View.Clip.GetValue(this.Attributes)
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = View.FlowDirection.GetValue(this.Attributes)
        member this.Font = TextStyle.Font.GetValue(this.Attributes)
        member this.Frame
            with get () = _frame
            and set (v: Rectangle): unit = _frame <- v
        member this.Handler
            with get () = this.Handler
            and set (v: IElementHandler): unit = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler): unit = this.ViewHandler <- v
        member this.Height = View.Height.GetValue(this.Attributes)
        member this.HorizontalLayoutAlignment = View.HorizontalLayoutAlignment.GetValue(this.Attributes)
        member this.ImageSource = Button.ImageSource.GetValue(this.Attributes)
        member this.ImageSourceLoaded() = Button.ImageSourceLoaded.Execute(this.Attributes, this.Context.Dispatch, ())
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
        member this.Pressed() = Button.Pressed.Execute(this.Attributes, this.Context.Dispatch, ())
        member this.Released() = Button.Released.Execute(this.Attributes, this.Context.Dispatch, ())
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
// The DSL enforces the type constraints on Application, Window, View, etc.
// Once the creation of the widget is done, Compile is called to get an optimized Widget struct type

type [<Struct>] ApplicationWidget<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<ApplicationWidget<'msg>, FabulousApplication> ()

    static member inline Create(windows: seq<#IWindowWidget<'msg>>) =
        ApplicationWidget<'msg> ([| Application.Windows.WithValue(windows |> Seq.map (fun w -> w.Compile())) |])

    interface IApplicationWidget<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes }            
        
type [<Struct>] WindowWidget<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<WindowWidget<'msg>, FabulousWindow> ()
    
    static member inline Create(title: string, content: #IViewWidget<'msg>) =
        WindowWidget<'msg> (
            [| Window.Title.WithValue(title)
               Window.Content.WithValue(ValueSome (content.Compile())) |]
        )
        
    interface IWindowWidget<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes } 
        
type [<Struct>] VerticalStackLayoutWidget<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<VerticalStackLayoutWidget<'msg>, FabulousVerticalStackLayout> ()
    
    static member inline Create(children: seq<IViewWidget<'msg>>) =        
        VerticalStackLayoutWidget<'msg> ([| Container.Children.WithValue(children |> Seq.map (fun c -> c.Compile())) |])
        
    interface IViewWidget<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes } 
        
type [<Struct>] LabelWidget<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<LabelWidget<'msg>, FabulousLabel> ()
    
    static member inline Create(text: string) =
        LabelWidget<'msg> ([| Text.Text.WithValue(text) |])
        
    interface IViewWidget<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes } 
        
type [<Struct>] ButtonWidget<'msg> (attributes: Attribute[]) =
    static let key = Widgets.register<ButtonWidget<'msg>, FabulousButton> ()
    
    static member inline Create(text: string, clicked: 'msg) =
        ButtonWidget<'msg>
            [| Text.Text.WithValue(text)
               Button.Clicked.WithValue(fun () -> box clicked) |]

    interface IViewWidget<'msg> with
        member _.Attributes = attributes
        member _.Compile() =
            { Key = key
              Attributes = attributes } 

// EXTENSIONS
    
[<Extension>]
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline background(this: #IViewWidget<_>, value: Paint) =
        this.AddAttribute(View.Background.WithValue(value))
    [<Extension>]
    static member inline font(this: #IViewWidget<_>, value: Font) =
        this.AddAttribute(TextStyle.Font.WithValue(value))
    [<Extension>]
    static member inline horizontalLayoutAlignment(this: #IViewWidget<_>, value: Primitives.LayoutAlignment) =
        this.AddAttribute(View.HorizontalLayoutAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalLayoutAlignment(this: #IViewWidget<_>, value: Primitives.LayoutAlignment) =
        this.AddAttribute(View.VerticalLayoutAlignment.WithValue(value))
    [<Extension>]
    static member inline margin(this: #IViewWidget<_>, value: Thickness) =
        this.AddAttribute(View.Margin.WithValue(value))
        
[<Extension>]
type LabelWidgetExtensions () =
    [<Extension>]
    static member inline textColor(this: LabelWidget<_>, value: Color) =
        this.AddAttribute(TextStyle.TextColor.WithValue(value))
    [<Extension>]
    static member inline horizontalTextAlignment(this: LabelWidget<_>, value: TextAlignment) =
        this.AddAttribute(TextAlignment.HorizontalTextAlignment.WithValue(value))
        
[<Extension>]
type VerticalStackLayoutExtensions () =
    [<Extension>]
    static member inline spacing(this: VerticalStackLayoutWidget<_>, value: float) =
        this.AddAttribute(StackLayout.Spacing.WithValue(value))
        
// PUBLIC API

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(windows) = ApplicationWidget<'msg>.Create(windows)
    static member inline Window<'msg>(title, content) = WindowWidget<'msg>.Create(title, content)
    static member inline VerticalStackLayout<'msg>(children) = VerticalStackLayoutWidget<'msg>.Create(children)
    static member inline Label<'msg>(text) = LabelWidget<'msg>.Create(text)
    static member inline Button<'msg>(text, clicked) = ButtonWidget<'msg>.Create(text, clicked)
    