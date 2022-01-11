# Architecture - Virtualized collections

Virtualized collection enables displaying a scrolling list of data while only instantiating the visible rows.
When scrolling, the no longer visible rows are reused and updated with the new data.

In Xamarin.Forms, this is done via 2 controls: ListView and CollectionView.
Also those controls support grouping data and displaying a group header/footer.

My main idea was to let the user pass in its data source and declare a template function (as well as 2 others for header/footer).
Fabulous would just remap the data source (`Seq.map templateFn items`) and pass it to Xamarin.Forms,  avoiding enumeration.

Usages
--

```fs
let items = [ 1 .. 1000 ]

ListView(items)
    (fun item -> TextCell($"{item}"))

CollectionView(items)
    (fun item -> Label($"{item}"))
```
```fs
// According to Xamarin.Forms documentation, when grouping, data source should be an IEnumerable of IEnumerable
type Group(headerData: string, footerData: string, items: IEnumerable<int>) =
    inherit ObservableCollection<int>(items)
    member _.HeaderData = headerData
    member _.FooterData = footerData

let groups =
    ObservableCollection<Group>(
        [ for i = 0 .. 100 do
            Group($"Header {i}", $"Footer {i}", [1 .. 100]) ]
    )

// ListView has no Footer for groups
GroupedListView(groups)
    (fun group -> TextCell(group.HeaderData))
    (fun item -> TextCell($"{item}"))

GroupedCollectionView(items)
    (fun group -> Label(group.HeaderData))
    (fun item -> Label($"{item}")
    (fun group -> Label(group.FooterData))
```

How ListView and CollectionView work in Xamarin.Forms
--

Virtualization in ListView/CollectionView works by combining 2 properties:
- `ItemsSource`: a list of raw data
- `DataTemplate`: a template object used to describe what the row should look like

Given the MVVM nature of XF, row reuse is mostly driven by bindings.
DataTemplate doesn't know about the raw data it will receive and only setups binding.

```xml
<ListView ItemsSource="{Binding Items}">
    <ListView.ItemTemplate>
        <DataTemplate>
            <TextCell Text="{Binding MyProperty}" />
        <DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

Xamarin.Forms creates a row using the `DataTemplate` and sets its `BindingContext` with the raw item.
This triggers refresh of the row UI.
Same on row reuse, XF sets the new raw item into `BindingContext` and refreshes the bindings.

This model doesn't work with Fabulous at all, due to the lack of Binding.
Fortunately, we can work with `DataTemplateSelector` to access the current item before returning the appropriate `DataTemplate`.
This allows Fabulous to support virtualization.

How it works in Fabulous
--

Semantically speaking, our `Widget` is very close to `DataTemplate`. They both describe what a specific piece of UI should look like. The main difference is that `DataTemplate` doesn't know of the data it will work with in advance, whereas `Widget` has been built with that data.

So the main challenge was to make the 2 concepts compatible.

### Simple collections (aka not grouped)

#### Storing data and the template function

In Fabulous v1, we were creating all `ViewElement` items (`Widget` in v2) on each view update. This can be problematic in case you have a large number of items.

Actually thanks to how virtualization works, we only need to "process" a couple of items for the visible rows.
No need to go create all widgets on each view update.

To support that, the following type has been created:
```fs
type WidgetItems =
    {
        // The raw list of data provided by the user
        OriginalItems: IEnumerable
       
        // Function to convert one item to a widget
        // Returns obj to support grouping as well
        Template: obj -> obj
    }
```

This `WidgetItems` is created by the function `ViewHelpers.buildItems` and is stored directly in the `ItemsSource` scalar attribute.

```fs
let buildItems<'msg, 'marker, 'itemData, 'itemMarker> key attrDef (items: seq<'itemData>) (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>) = (...)

static member inline ListView<'msg, 'itemData, 'itemMarker when 'itemMarker :> ICell>(items: seq<'itemData>) =
    ViewHelpers.buildItems<'msg, IListView, 'itemData, 'itemMarker> ViewKeys.ListView ItemsViewOfCell.ItemsSource items
```
_Note the use of `'itemMarker` to enforce the type of widget items_

Keeping the original items allows us to directly compare them on each update to determine if we need to update the UI.
```fs
(fun (a, b) -> ScalarAttributeComparers.equalityCompare(a.OriginalItems, b.OriginalItems))
```

Currently, scalar attributes in Fabulous have 2 generic parameters: the `'inputType` and `'modelType`.

The `'inputType` is what we expect the users to provide us.
The `'modelType` is an optimized representation of the same data (eg. `'inputType` is `int list`, `'modelType` will be `int[]`).

Before storing the attribute value, we convert `'inputType` to `'modelType` through the `Convert` function declared in the `ScalarAttributeDefinition`; `'inputType` is never stored.

But the comparison function shown just above is only done between 2 `'modelType`s, but ListView/CollectionView expect an `IEnumerable` and not a `WidgetItems`.

So to support this, we need another generic parameter `'valueType` and the corresponding `ConvertValue: 'modelType -> 'valueType` function.
```fs
type ScalarAttributeDefinition<'inputType, 'modelType, 'valueType> =
    { (...)
      Compare: 'modelType -> 'modelType
      ConvertValue: 'modelType -> 'valueType }
```

With this, we can still store and compare `WidgetItems`, but when we actually need to apply the value to the XF property, we call `ConvertValue` to transform it. Attributes that don't need conversion can use the `id` function to make it transparent.

For `WidgetItems`, we build an IEnumerable on the fly using the original items and the template function before assigning it to the XF property `ItemsSource`.
```fs
(fun modelValue -> seq { for x in modelValue.OriginalItems do modelValue.Template x })
```

Now Xamarin.Forms has a list of Widgets, and thanks to `seq`, it will only enumerate the items it needs to display.

#### Loading Widgets into rows

Unlike DataTemplate in MVVM apps, instead of setting bindings to capture the raw data inside `BindingContext`, we now have a `Widget`.

To make it work, we need 2 things:
- A DataTemplateSelector that will know which DataTemplate to create based on the widget
- A DataTemplate that will listen to `BindingContextChanged` and run the Reconciler when a widget is attached to the row

```fs
// IsHeader is only for grouping
type WidgetDataTemplateSelector internal (node: IViewNode, isHeader: bool, getWidget: obj -> Widget) =
    inherit DataTemplateSelector()
    
    /// Reuse data template for already known widget target type
    let cache = Dictionary<Type, WidgetDataTemplate>()
    
    override _.OnSelectTemplate(item, _) =
        let widget = getWidget item
        let widgetDefinition = WidgetDefinitionStore.get widget.Key
        let targetType = widgetDefinition.GetTargetType(widget)
        match cache.TryGetValue(targetType) with
        | true, dataTemplate -> dataTemplate
        | false, _ ->
            let dataTemplate = WidgetDataTemplate(targetType, isHeader, node)
            cache.Add(targetType, dataTemplate)
            dataTemplate
```

Note that like said earlier, DataTemplate are created _before_ knowing which value they will host.
This means we can only create an empty row for now.
So to enable row reuse later, we extract the root target type of a widget and create an empty row with it.

eg.
```fs
fun item ->
    ViewCell(
        Grid(...)
    )
```
will have a target type of `ViewCell` and we create an empty `ViewCell`.

_Side note:_ to make it compatible with `View.Memo`, the target type is a function that can return the memoized widget target type.

This DataTemplateSelector instantiates a `WidgetDataTemplate` that will create the appropriate XF control and listen to `BindingContextChanged`.
```fs
/// Create a DataTemplate for a specific root type (TextCell, ViewCell, etc.)
/// that listen for BindingContext change to apply the Widget content to the cell
type WidgetDataTemplate(``type``, isHeader, parent: IViewNode) =
    inherit DataTemplate(fun () ->
        let bindableObject = Activator.CreateInstance ``type`` :?> BindableObject
        
        let viewNode = ViewNode(ValueSome parent, parent.TreeContext, WeakReference(bindableObject))
        bindableObject.SetValue(ViewNode.ViewNodeProperty, viewNode)
        
        let onBindingContextChanged = BindableHelpers.createOnBindingContextChanged parent.TreeContext.CanReuseView isHeader bindableObject
        bindableObject.BindingContextChanged.Add (fun _ -> onBindingContextChanged ())
        
        bindableObject :> obj
    )
```

For fresh rows, Xamarin.Forms will execute that function and then set the `BindingContext` with the widget from our list. When XF reuses a row, it will set the new widget in the `BindingContext` as well.
Each time, we call the Reconciler to update the row.

Final step is to pass this `WidgetDataTemplateSelector` in the XF property `ItemTemplate`.
Since it will never change, we assign it when creating the controls.
```fs
/// Force ListView to recycle rows because DataTemplateSelector disables it by default, only possible in ctor
/// CollectionView recycles by default
type FabulousListView() = inherit ListView(ListViewCachingStrategy.RecycleElement)

let ListView = Widgets.registerWithAdditionalSetup<FabulousListView>(fun target node ->
    target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
)
let CollectionView = Widgets.registerWithAdditionalSetup<Xamarin.Forms.CollectionView>(fun target node ->
    target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
)
```

A `registerWithAdditionalSetup` was needed because `DataTemplateSelector` requires access to the `ViewNode` of the ListView/CollectionView, and it was not possible to do it in the constructor of the controls.

### Grouped collections

Grouped ListView/CollectionView is slightly different.
Instead of having a 1-dimensional enumerable of raw data, we have a 2-dimension one (eg. `IEnumerable<IEnumerable<T>>`)

To support this with everything we saw just before, `GroupItem` has been created.
```fs
type GroupItem(header: Widget, footer: Widget, source: IEnumerable<Widget>) =
    member _.Header = header
    member _.Footer = footer
    interface IEnumerable<Widget> with
        member this.GetEnumerator(): IEnumerator<Widget> = source.GetEnumerator()
        member this.GetEnumerator(): IEnumerator = source.GetEnumerator()
```

Instead of applying a list of `IEnumerable<Widget>` to XF property `ItemsSource`, we apply a list of `IEnumerable<GroupItem>`.

The builder function takes 3 template functions instead of 1: the group header template, the item template and the group footer template. All of which are called on `ConvertValue` to create the list of 'GroupItem'.

Since the data source is different, we need a different `DataTemplate` for XF properties `GroupHeaderTemplate` and `GroupFooterTemplate`.
Even with grouping enabled, `ItemTemplate` remains a simple `Widget` -> row.

`GroupedWidgetDataTemplateSelector` will either use the `Header` or `Footer` widgets to create the corresponding rows.

And when registering the ListView/CollectionView types, we enable the `IsGrouped` flag.
```fs
let GroupedListView = Widgets.registerWithAdditionalSetup<FabulousListView>(fun target node ->
    target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
    target.GroupHeaderTemplate <- GroupedWidgetDataTemplateSelector(node, true)
    target.IsGroupingEnabled <- true
)
let GroupedCollectionView = Widgets.registerWithAdditionalSetup<Xamarin.Forms.CollectionView>(fun target node ->
    target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
    target.GroupHeaderTemplate <- GroupedWidgetDataTemplateSelector(node, true)
    target.GroupFooterTemplate <- GroupedWidgetDataTemplateSelector(node, false)
    target.IsGrouped <- true
)
```
