namespace Gallery

open Fabulous.Avalonia
open type Fabulous.Avalonia.View

[<AutoOpen>]
module App =
    [<Struct>]
    type DetailPage =
        | AcrylicPage
        | AdornerLayerPage
        | AutoCompleteBoxPage
        | AsyncImagePage
        | ButtonsPage
        | ButtonSpinnerPage
        | BorderPage
        | CalendarPage
        | CalendarDatePickerPage
        | CanvasPage
        | CheckBoxPage
        | CarouselPage
        | ComboBoxPage
        | ColorPickerPage
        | CompositionPage
        | ContextMenuPage
        | ContextFlyoutPage
        | ClipboardPage
        | DataGridPage
        | DockPanelPage
        | DialogsPage
        | DragAndDropPage
        | DropDownButtonPage
        | EffectsPage
        | ExpanderPage
        | FlyoutPage
        | GesturesPage
        | GeometriesPage
        | GridPage
        | GridSplitterPage
        | ImagePage
        | ItemsRepeaterPage
        | ItemsControlPage
        | LabelPage
        | LayoutTransformControlPage
        | ListBoxPage
        | LottiePage
        | MenuFlyoutPage
        | MaskedTextBoxPage
        | MenuPage
        | NumericUpDownPage
        | NotificationsPage
        | OpenGLPage
        | ProgressBarPage
        | PanelPage
        | PathIconPage
        | PopupPage
        | PointersPage
        | PageTransitionsPage
        | RepeatButtonPage
        | RadioButtonPage
        | RefreshContainerPage
        | SelectableTextBlockPage
        | SplitButton
        | SliderPage
        | ShapesPage
        | ScrollBarPage
        | SplitViewPage
        | StackPanelPage
        | StylesPage
        | ScrollViewerPage
        | ToggleSplitButtonPage
        | TextBlockPage
        | TextBoxPage
        | ThumbPage
        | TickBarPage
        | ToggleSwitchPage
        | ToggleButtonPage
        | ToolTipPage
        | TabControlPage
        | TabStripPage
        | TreeViewPage
        | TreeDataGridPage
        | TransitioningContentControlPage
        | ThemeAwarePage
        | UniformGridPage
        | ViewBoxPage
        | ImplicitAnimations
        | DrawLineAnimation
        | CompositorAnimations
        | Animations
        | SpringAnimations
        | Transitions
        | RenderTransform
        | Brushes
        | Clipping
        | Drawing
        | LineBounds
        | Transform3D
        | WritableBitmap
        | RenderTargetBitmap
        | PathMeasurement
        | CustomAnimator
        | GlyphRun
        | FormattedText
        | TextFormatter
        | WrapPanel

    [<return: Struct>]
    let (|CurrentPage|_|) page =
        match page with
        | "Acrylic" -> ValueSome AcrylicPage
        | "AdornerLayer" -> ValueSome AdornerLayerPage
        | "AutoCompleteBox" -> ValueSome AutoCompleteBoxPage
        | "AsyncImage" -> ValueSome AsyncImagePage
        | "Buttons" -> ValueSome ButtonsPage
        | "ButtonSpinner" -> ValueSome ButtonSpinnerPage
        | "Border" -> ValueSome BorderPage
        | "Calendar" -> ValueSome CalendarPage
        | "CalendarDatePicker" -> ValueSome CalendarDatePickerPage
        | "Canvas" -> ValueSome CanvasPage
        | "CheckBox" -> ValueSome CheckBoxPage
        | "Carousel" -> ValueSome CarouselPage
        | "ComboBox" -> ValueSome ComboBoxPage
        | "ColorPicker" -> ValueSome ColorPickerPage
        | "Composition" -> ValueSome CompositionPage
        | "ContextMenu" -> ValueSome ContextMenuPage
        | "ContextFlyout" -> ValueSome ContextFlyoutPage
        | "Clipboard" -> ValueSome ClipboardPage
        | "DataGrid" -> ValueSome DataGridPage
        | "DockPanel" -> ValueSome DockPanelPage
        | "Dialogs" -> ValueSome DialogsPage
        | "DragAndDrop" -> ValueSome DragAndDropPage
        | "DropDownButton" -> ValueSome DropDownButtonPage
        | "Effects" -> ValueSome EffectsPage
        | "Expander" -> ValueSome ExpanderPage
        | "Flyout" -> ValueSome FlyoutPage
        | "Gestures" -> ValueSome GesturesPage
        | "Geometries" -> ValueSome GeometriesPage
        | "Grid" -> ValueSome GridPage
        | "GridSplitter" -> ValueSome GridSplitterPage
        | "Image" -> ValueSome ImagePage
        | "ItemsRepeater" -> ValueSome ItemsRepeaterPage
        | "ItemsControl" -> ValueSome ItemsControlPage
        | "Label" -> ValueSome LabelPage
        | "LayoutTransformControl" -> ValueSome LayoutTransformControlPage
        | "ListBox" -> ValueSome ListBoxPage
        | "Lottie" -> ValueSome LottiePage
        | "MenuFlyout" -> ValueSome MenuFlyoutPage
        | "MaskedTextBox" -> ValueSome MaskedTextBoxPage
        | "Menu" -> ValueSome MenuPage
        | "NumericUpDown" -> ValueSome NumericUpDownPage
        | "Notifications" -> ValueSome NotificationsPage
        | "OpenGL" -> ValueSome OpenGLPage
        | "ProgressBar" -> ValueSome ProgressBarPage
        | "Panel" -> ValueSome PanelPage
        | "PathIcon" -> ValueSome PathIconPage
        | "Popup" -> ValueSome PopupPage
        | "Pointers" -> ValueSome PointersPage
        | "Transitions" -> ValueSome PageTransitionsPage
        | "RepeatButton" -> ValueSome RepeatButtonPage
        | "RadioButton" -> ValueSome RadioButtonPage
        | "RefreshContainer" -> ValueSome RefreshContainerPage
        | "SelectableTextBlock" -> ValueSome SelectableTextBlockPage
        | "SplitButton" -> ValueSome SplitButton
        | "Slider" -> ValueSome SliderPage
        | "Shapes" -> ValueSome ShapesPage
        | "ScrollBar" -> ValueSome ScrollBarPage
        | "SplitView" -> ValueSome SplitViewPage
        | "StackPanel" -> ValueSome StackPanelPage
        | "Styles" -> ValueSome StylesPage
        | "ScrollViewer" -> ValueSome ScrollViewerPage
        | "ToggleSplitButton" -> ValueSome ToggleSplitButtonPage
        | "TextBlock" -> ValueSome TextBlockPage
        | "TextBox" -> ValueSome TextBoxPage
        | "Thumb" -> ValueSome ThumbPage
        | "TickBar" -> ValueSome TickBarPage
        | "ToggleSwitch" -> ValueSome ToggleSwitchPage
        | "ToggleButton" -> ValueSome ToggleButtonPage
        | "ToolTip" -> ValueSome ToolTipPage
        | "TabControl" -> ValueSome TabControlPage
        | "TabStrip" -> ValueSome TabStripPage
        | "TreeView" -> ValueSome TreeViewPage
        | "TreeDataGrid" -> ValueSome TreeDataGridPage
        | "TransitioningContent" -> ValueSome TransitioningContentControlPage
        | "ThemeAware" -> ValueSome ThemeAwarePage
        | "UniformGrid" -> ValueSome UniformGridPage
        | "ViewBox" -> ValueSome ViewBoxPage
        | "Implicit Animations" -> ValueSome ImplicitAnimations
        | "Draw Line Animation" -> ValueSome DrawLineAnimation
        | "Compositor Animations" -> ValueSome CompositorAnimations
        | "Animations" -> ValueSome Animations
        | "Spring Animations" -> ValueSome SpringAnimations
        | "RenderTransitions" -> ValueSome Transitions
        | "Render Transform" -> ValueSome RenderTransform
        | "Brushes" -> ValueSome Brushes
        | "Clipping" -> ValueSome Clipping
        | "Drawing" -> ValueSome Drawing
        | "Line Bounds" -> ValueSome LineBounds
        | "Transform3D" -> ValueSome Transform3D
        | "Writable Bitmap" -> ValueSome WritableBitmap
        | "Render Target Bitmap" -> ValueSome RenderTargetBitmap
        | "Path Measurement" -> ValueSome PathMeasurement
        | "Custom Animator" -> ValueSome CustomAnimator
        | "GlyphRun" -> ValueSome GlyphRun
        | "FormattedText" -> ValueSome FormattedText
        | "TextFormatter" -> ValueSome TextFormatter
        | "WrapPanel" -> ValueSome WrapPanel
        | _ -> ValueNone

    [<return: Struct>]
    let (|CurrentWidget|_|) page =
        match page with
        | AcrylicPage -> ValueSome(View.AnyView(MvuAcrylicPage.view()))
        | AdornerLayerPage -> ValueSome(AnyView(AdornerLayerPage.view()))
        | AutoCompleteBoxPage -> ValueSome(AnyView(AutoCompleteBoxPage.view()))
        | AsyncImagePage -> ValueSome(AnyView(AsyncImagePage.view()))
        | ButtonsPage -> ValueSome(AnyView(ButtonsPage.view()))
        | ButtonSpinnerPage -> ValueSome(AnyView(ButtonSpinnerPage.view()))
        | BorderPage -> ValueSome(AnyView(BorderPage.view()))
        | CalendarPage -> ValueSome(AnyView(CalendarPage.view()))
        | CalendarDatePickerPage -> ValueSome(AnyView(CalendarDatePickerPage.view()))
        | CanvasPage -> ValueSome(AnyView(CanvasPage.view()))
        | CheckBoxPage -> ValueSome(AnyView(CheckBoxPage.view()))
        | CarouselPage -> ValueSome(AnyView(CarouselPage.view()))
        | ComboBoxPage -> ValueSome(AnyView(ComboBoxPage.view()))
        | ColorPickerPage -> ValueSome(AnyView(ColorPickerPage.view()))
        | CompositionPage -> ValueSome(AnyView(CompositionPageControl()))
        | ContextMenuPage -> ValueSome(AnyView(ContextMenuPage.view()))
        | ContextFlyoutPage -> ValueSome(AnyView(ContextFlyoutPage.view()))
        | ClipboardPage -> ValueSome(AnyView(ClipboardPage.view()))
        | DataGridPage -> ValueSome(AnyView(DataGridPage.view()))
        | DockPanelPage -> ValueSome(AnyView(DockPanelPage.view()))
        | DialogsPage -> ValueSome(AnyView(DialogsPage.view()))
        | DragAndDropPage -> ValueSome(AnyView(DragAndDropPage.view()))
        | DropDownButtonPage -> ValueSome(AnyView(DropDownButtonPage.view()))
        | EffectsPage -> ValueSome(AnyView(EffectsPage.view()))
        | ExpanderPage -> ValueSome(AnyView(ExpanderPage.view()))
        | FlyoutPage -> ValueSome(AnyView(FlyoutPage.view()))
        | GesturesPage -> ValueSome(AnyView(GesturesPage.view()))
        | GeometriesPage -> ValueSome(AnyView(GeometriesPage.view()))
        | GridPage -> ValueSome(AnyView(GridPage.view()))
        | GridSplitterPage -> ValueSome(AnyView(GridSplitterPage.view()))
        | ImagePage -> ValueSome(AnyView(ImagePage.view()))
        | ItemsRepeaterPage -> ValueSome(AnyView(ItemsRepeaterPage.view()))
        | ItemsControlPage -> ValueSome(AnyView(ItemsControlPage.view()))
        | LabelPage -> ValueSome(AnyView(LabelPage.view()))
        | ListBoxPage -> ValueSome(AnyView(ListBoxPage.view()))
        | LottiePage -> ValueSome(AnyView(LottiePage.view()))
        | LayoutTransformControlPage -> ValueSome(AnyView(LayoutTransformControlPage.view()))
        | MenuFlyoutPage -> ValueSome(AnyView(MenuFlyoutPage.view()))
        | MaskedTextBoxPage -> ValueSome(AnyView(MaskedTextBoxPage.view()))
        | MenuPage -> ValueSome(AnyView(MenuPage.view()))
        | NumericUpDownPage -> ValueSome(AnyView(NumericUpDownPage.view()))
        | NotificationsPage -> ValueSome(AnyView(NotificationsPage.view()))
        | OpenGLPage -> ValueSome(AnyView(OpenGLPage.view()))
        | ProgressBarPage -> ValueSome(AnyView(ProgressBarPage.view()))
        | PanelPage -> ValueSome(AnyView(PanelPage.view()))
        | PathIconPage -> ValueSome(AnyView(PathIconPage.view()))
        | PopupPage -> ValueSome(AnyView(PopupPage.view()))
        | PointersPage -> ValueSome(AnyView(PointersPage.view()))
        | PageTransitionsPage -> ValueSome(AnyView(PageTransitionsPage.view()))
        | RepeatButtonPage -> ValueSome(AnyView(RepeatButtonPage.view()))
        | RadioButtonPage -> ValueSome(AnyView(RadioButtonPage.view()))
        | RefreshContainerPage -> ValueSome(AnyView(RefreshContainerPage.view()))
        | SelectableTextBlockPage -> ValueSome(AnyView(SelectableTextBlockPage.view()))
        | SplitButton -> ValueSome(AnyView(SplitButtonPage.view()))
        | SliderPage -> ValueSome(AnyView(SliderPage.view()))
        | ShapesPage -> ValueSome(AnyView(ShapesPage.view()))
        | ScrollBarPage -> ValueSome(AnyView(ScrollBarPage.view()))
        | SplitViewPage -> ValueSome(AnyView(SplitViewPage.view()))
        | StackPanelPage -> ValueSome(AnyView(StackPanelPage.view()))
        | StylesPage -> ValueSome(AnyView(StylesPage.view()))
        | ScrollViewerPage -> ValueSome(AnyView(ScrollViewerPage.view()))
        | ToggleSplitButtonPage -> ValueSome(AnyView(ToggleSplitButtonPage.view()))
        | TextBlockPage -> ValueSome(AnyView(TextBlockPage.view()))
        | TextBoxPage -> ValueSome(AnyView(TextBoxPage.view()))
        | ThumbPage -> ValueSome(AnyView(ThumbPage.view()))
        | TickBarPage -> ValueSome(AnyView(TickBarPage.view()))
        | ToggleSwitchPage -> ValueSome(AnyView(ToggleSwitchPage.view()))
        | ToggleButtonPage -> ValueSome(AnyView(ToggleButtonPage.view()))
        | ToolTipPage -> ValueSome(AnyView(ToolTipPage.view()))
        | TabControlPage -> ValueSome(AnyView(TabControlPage.view()))
        | TabStripPage -> ValueSome(AnyView(TabStripPage.view()))
        | TreeViewPage -> ValueSome(AnyView(TreeViewPage.view()))
        | TreeDataGridPage -> ValueSome(AnyView(TreeDataGridPage.view()))
        | TransitioningContentControlPage -> ValueSome(AnyView(TransitioningContentControlPage.view()))
        | ThemeAwarePage -> ValueSome(AnyView(ThemeAwarePage.view()))
        | UniformGridPage -> ValueSome(AnyView(UniformGridPage.view()))
        | ImplicitAnimations -> ValueSome(AnyView(ImplicitCanvasAnimationsPage.view()))
        | DrawLineAnimation -> ValueSome(AnyView(DrawLineAnimationPage.view()))
        | CompositorAnimations -> ValueSome(AnyView(CompositorAnimationsPage.view()))
        | Animations -> ValueSome(AnyView(AnimationsPage.view()))
        | SpringAnimations -> ValueSome(AnyView(SpringAnimationsPage.view()))
        | Transitions -> ValueSome(AnyView(TransitionsPage.view()))
        | RenderTransform -> ValueSome(AnyView(RenderTransformPage.view()))
        | Brushes -> ValueSome(AnyView(BrushesPage.view()))
        | Clipping -> ValueSome(AnyView(ClippingPage.view()))
        | Drawing -> ValueSome(AnyView(DrawingPage.view()))
        | LineBounds -> ValueSome(AnyView(LineBoundsPage.view()))
        | Transform3D -> ValueSome(AnyView(Transform3DPage.view()))
        | WritableBitmap -> ValueSome(AnyView(WriteableBitmapPage.view()))
        | RenderTargetBitmap -> ValueSome(AnyView(RenderTargetBitmapPage.view()))
        | PathMeasurement -> ValueSome(AnyView(PathMeasurementPage.view()))
        | CustomAnimator -> ValueSome(AnyView(CustomAnimatorPage.view()))
        | GlyphRun -> ValueSome(AnyView(GlyphRunPage.view()))
        | FormattedText -> ValueSome(AnyView(FormattedTextPage.view()))
        | TextFormatter -> ValueSome(AnyView(TextFormatterPage.view()))
        | ViewBoxPage -> ValueSome(AnyView(ViewBoxPage.view()))
        | WrapPanel -> ValueSome(AnyView(WrapPanelsPage.view()))
