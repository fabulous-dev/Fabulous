namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabComboBox =
    inherit IFabSelectingItemsControl

module ComboBox =
    let WidgetKey = Widgets.register<ComboBox>()

    let IsDropDownOpen =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.IsDropDownOpenProperty

    let MaxDropDownHeight =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.MaxDropDownHeightProperty

    let PlaceholderText =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.PlaceholderTextProperty

    let PlaceholderForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget ComboBox.PlaceholderForegroundProperty

    let PlaceholderForeground =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.PlaceholderForegroundProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.VerticalContentAlignmentProperty

    let ItemTemplate =
        Attributes.defineSimpleScalar<obj -> Widget> "ComboBox_ItemTemplate" ScalarAttributeComparers.physicalEqualityCompare (fun _ newValueOpt node ->
            let comboBox = node.Target :?> ComboBox

            match newValueOpt with
            | ValueNone -> comboBox.ClearValue(ComboBox.ItemTemplateProperty)
            | ValueSome template ->
                comboBox.SetValue(ComboBox.ItemTemplateProperty, WidgetDataTemplate(node, template))
                |> ignore)

[<AutoOpen>]
module ComboBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        static member ComboBox(items: seq<_>) =
            WidgetBuilder<'msg, IFabComboBox>(ComboBox.WidgetKey, ItemsControl.ItemsSource.WithValue(items))

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ComboBox(items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>) =
            WidgetHelpers.buildItems<'msg, IFabComboBox, 'itemData, 'itemMarker> ComboBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, ItemsControl.Items)

type ComboBoxModifiers =
    /// <summary>Sets the IsDropDownOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDropDownOpen value.</param>
    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabComboBox>, value: bool) =
        this.AddScalar(ComboBox.IsDropDownOpen.WithValue(value))

    /// <summary>Sets the MaxDropDownHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxDropDownHeight value.</param>
    [<Extension>]
    static member inline maxDropDownHeight(this: WidgetBuilder<'msg, #IFabComboBox>, value: double) =
        this.AddScalar(ComboBox.MaxDropDownHeight.WithValue(value))

    /// <summary>Sets the PlaceholderText property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderText value.</param>
    [<Extension>]
    static member inline placeholderText(this: WidgetBuilder<'msg, #IFabComboBox>, value: string) =
        this.AddScalar(ComboBox.PlaceholderText.WithValue(value))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(ComboBox.PlaceholderForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: IBrush) =
        this.AddScalar(ComboBox.PlaceholderForeground.WithValue(value))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBoxItem>, value: Color) =
        ComboBoxModifiers.placeholderForeground(this, View.SolidColorBrush(value))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBoxItem>, value: string) =
        ComboBoxModifiers.placeholderForeground(this, View.SolidColorBrush(value))


    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: HorizontalAlignment) =
        this.AddScalar(ComboBox.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: VerticalAlignment) =
        this.AddScalar(ComboBox.VerticalContentAlignment.WithValue(value))

    /// <summary>Sets the ItemTemplate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="template">The template to render the items with.</param>
    [<Extension>]
    static member inline itemTemplate(this: WidgetBuilder<'msg, #IFabComboBox>, template: 'item -> WidgetBuilder<'msg, #IFabControl>) =
        this.AddScalar(ComboBox.ItemTemplate.WithValue(WidgetHelpers.compileTemplate template))

    /// <summary>Link a ViewRef to access the direct ComboBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComboBox>, value: ViewRef<ComboBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComboBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComboBoxItem>
        (_: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComboBoxItem>
        (_: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
