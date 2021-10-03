namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open System.Collections.Generic
open Fabulous
open Fabulous.Controls
open Fabulous.Maui.Widgets
open Fabulous.Maui.Attributes


// MAUI CONTROLS

type ViewNode(handler) =
    let mutable _attributes: Attribute[] = [||]
    let mutable _context = Unchecked.defaultof<_>
    let mutable _handler : IElementHandler = handler

    member _.Context = _context

    member _.Handler
        with get() = _handler
        and set(v) = _handler <- v

    member _.ViewHandler
        with get() = _handler :?> IViewHandler
        and set(v: IViewHandler) = _handler <- v

    interface IAttributedViewNode with
        member _.Attributes = _attributes
        member _.Context = _context

        member _.SetContext(context) =
            _context <- context

        member _.ApplyDiff(diff) =
            // TODO: Update the attributes array from the diff result and then trigger event on each updated properties to let MAUI know about it
            match diff with
            | WidgetDiff.Identical -> ()
            | WidgetDiff.ReplacedBy (:? IControlWidget as newWidget) ->
                // TODO: Reset unset properties
                _attributes <- newWidget.Attributes

                printfn "ViewNode - Handler is %s" (if _handler = null then "null" else "not null")
                if _handler <> null then
                    for attribute in newWidget.Attributes do
                         match PropertyAttributes.tryGetMauiPropertyName(attribute) with
                         | ValueNone -> ()
                         | ValueSome propertyName ->
                            printfn $"ViewNode - UpdateValue for '{propertyName}'"
                            _handler.UpdateValue(propertyName)

            | _ -> failwith "Not implemented"
            

type FabulousApplication () =
    inherit ViewNode(null)

    let _windows = List<IWindow>()

    interface IApplication with
        member this.CreateWindow(activationState) = failwith "todo"
        member this.ThemeChanged() = Application.ThemeChanged.Execute(this, ())
        member this.Windows =
            match Application.Windows.TryGetValue(this) with
            | None -> ()
            | Some windowWidgets ->
                for widget in windowWidgets do
                    let view = unbox (widget.CreateView(this.Context))
                    _windows.Add(view)

            _windows :> IReadOnlyList<_>
                
        
type FabulousWindow () =
    inherit ViewNode(Microsoft.Maui.Handlers.WindowHandler())

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
                let view = unbox (widget.CreateView(this.Context))
                view
        member this.Handler 
            with get() = this.Handler
            and set(v) = this.Handler <- v
        member this.Parent = failwith "todo"
        member this.Title = Window.Title.GetValue(this)
        
type FabulousVerticalStackLayout () =
    inherit ViewNode(Microsoft.Maui.Handlers.LayoutHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()

    interface IStackLayout with
        member this.Add(item: IView) = failwith "todo"
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
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
                    let view = unbox (child.CreateView(this.Context))
                    _children.Add(view)
        
            _children.GetEnumerator() :> System.Collections.Generic.IEnumerator<IView>

        member this.GetEnumerator() = _children.GetEnumerator() :> System.Collections.IEnumerator
        member this.Handler
            with get () = this.Handler
            and set (v: IElementHandler) = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler) = this.ViewHandler <- v
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
    inherit ViewNode(Microsoft.Maui.Handlers.LabelHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface ILabel with
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
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
            with get () = this.Handler
            and set (v: IElementHandler): unit = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler): unit = this.ViewHandler <- v
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
    inherit ViewNode(Microsoft.Maui.Handlers.ButtonHandler())

    let mutable _frame = Rectangle.Zero
    let mutable _desiredSize = Size.Zero

    interface IButton with
        member this.AnchorX = Transform.AnchorX.GetValue(this)
        member this.AnchorY = Transform.AnchorY.GetValue(this)
        member this.Arrange(bounds: Rectangle) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            if this.ViewHandler <> null then this.ViewHandler.NativeArrange(_frame)
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
            with get () = this.Handler
            and set (v: IElementHandler): unit = this.Handler <- v
        member this.Handler
            with get () = this.ViewHandler
            and set (v: IViewHandler): unit = this.ViewHandler <- v
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

type [<Struct>] ApplicationWidget<'msg> (attributes: Attribute[]) =
    static do ControlWidget.register<ApplicationWidget<'msg>, FabulousApplication>()

    static member inline Create(windows: seq<#IWindowWidget<'msg>>) =
        ApplicationWidget<'msg> ([| Application.Windows.WithValue(windows |> Seq.map (fun w -> w :> IWindowWidget)) |])
            
    interface IApplicationControlWidget<'msg> with
        member _.TargetType = typeof<FabulousApplication>
        member _.Attributes = attributes
        member this.CreateView(context) = ControlWidget.createView<FabulousApplication> context this
        
type [<Struct>] WindowWidget<'msg> (attributes: Attribute[]) =
    static do ControlWidget.register<WindowWidget<'msg>, FabulousWindow>()
    
    static member inline Create(title: string, content: #IViewWidget<'msg>) =
        WindowWidget<'msg> (
            [| Window.Title.WithValue(title)
               Window.Content.WithValue(ValueSome (content :> IViewWidget)) |]
        )
        
    interface IWindowControlWidget<'msg> with
        member _.TargetType = typeof<FabulousWindow>
        member _.Attributes = attributes
        member this.CreateView(context) = ControlWidget.createView<FabulousWindow> context this
        
type [<Struct>] VerticalStackLayoutWidget<'msg> (attributes: Attribute[]) =
    static do ControlWidget.register<VerticalStackLayoutWidget<'msg>, FabulousVerticalStackLayout>()
    
    static member inline Create(children: seq<IViewWidget<'msg>>) =        
        VerticalStackLayoutWidget<'msg> ([| Container.Children.WithValue(children |> Seq.map (fun c -> c :> IViewWidget)) |])
        
    interface IViewControlWidget<'msg> with
        member _.TargetType = typeof<FabulousVerticalStackLayout>
        member _.Attributes = attributes
        member this.CreateView(context) = ControlWidget.createView<FabulousVerticalStackLayout> context this
        
type [<Struct>] LabelWidget<'msg> (attributes: Attribute[]) =
    static do ControlWidget.register<LabelWidget<'msg>, FabulousLabel>()
    
    static member inline Create(text: string) =
        LabelWidget<'msg> ([| Text.Text.WithValue(text) |])
        
    interface IViewControlWidget<'msg> with
        member _.TargetType = typeof<FabulousLabel>
        member _.Attributes = attributes
        member this.CreateView(context) = ControlWidget.createView<FabulousLabel> context this
        
type [<Struct>] ButtonWidget<'msg> (attributes: Attribute[]) =
    static do ControlWidget.register<ButtonWidget<'msg>, FabulousButton>()
    
    static member inline Create(text: string, clicked: 'msg) =
        ButtonWidget<'msg>
            [| Text.Text.WithValue(text)
               Button.Clicked.WithValue(fun () -> box clicked) |]

    interface IViewControlWidget<'msg> with
        member _.TargetType = typeof<FabulousButton>
        member _.Attributes = attributes
        member this.CreateView(context) = ControlWidget.createView<FabulousButton> context this

// EXTENSIONS
    
[<Extension>] 
type IViewWidgetExtensions () =
    [<Extension>]
    static member inline background(this: #IViewControlWidget<_>, value: Paint) =
        this.AddAttribute(View.Background.WithValue(value))
    [<Extension>]
    static member inline font(this: #IViewControlWidget<_>, value: Font) =
        this.AddAttribute(TextStyle.Font.WithValue(value))
    [<Extension>]
    static member inline horizontalLayoutAlignment(this: #IViewControlWidget<_>, value: Primitives.LayoutAlignment) =
        this.AddAttribute(View.HorizontalLayoutAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalLayoutAlignment(this: #IViewControlWidget<_>, value: Primitives.LayoutAlignment) =
        this.AddAttribute(View.VerticalLayoutAlignment.WithValue(value))
    [<Extension>]
    static member inline margin(this: #IViewControlWidget<_>, value: Thickness) =
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
    