{% include_relative _header.md %}

{% include_relative contents-views.md %}

## Views: Custom Renderer / ViewElements

If you want to know more about **Custom Renderers** in Xamarin.Forms and how it works take a look [here](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/).

### Customized ViewElements

If an existing control does not provide the feature you want, you can extend it through a custom control.
To create a custom control you have to use the [extension API](https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/views-extending.html).
Usually you don't use a custom control without a custom renderer because to apply new features like underlining a label you have to use a custom renderer. Take a look at `UnderlinedLabel` in the `Pracitical Examples` section.

In this example we have a label which only allows to set a text, a fontFamily, a backgroundcolor and a rotation.

```fsharp
module TestLabel =
    /// Test the extension API be making a 2nd wrapper for "Label":
    let TestLabelTextAttribKey = AttributeKey<_> "TestLabel_Text"
    let TestLabelFontFamilyAttribKey = AttributeKey<_> "TestLabel_FontFamily"

    type Fabulous.XamarinForms.View with

        static member inline TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) =

            // Get the attributes for the base element. The number is the expected number of attributes.
            // You can add additional base element attributes here if you like
            let attribCount = 0
            let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount, ?backgroundColor = backgroundColor, ?rotation = rotation)

            // Add our own attributes. They must have unique names.
            match text with None -> () | Some v -> attribs.Add(TestLabelTextAttribKey, v)
            match fontFamily with None -> () | Some v -> attribs.Add(TestLabelFontFamilyAttribKey, v)

            // The creation method
            let create () = Xamarin.Forms.Label()

            // The incremental update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.Label) =
                ViewBuilders.UpdateView(prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, TestLabelTextAttribKey, (fun target v -> target.Text <- v))
                source.UpdatePrimitive(prevOpt, target, TestLabelFontFamilyAttribKey, (fun target v -> target.FontFamily <- v))

            let updateAttachedProperties propertyKey prevOpt source targetChild =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, prevOpt, source, targetChild)

            ViewElement.Create<Xamarin.Forms.Label>(create, update, updateAttachedProperties, attribs)
```

### Custom Renderer

To create a custom renderer you can follow the example below or take a look in the `Pracitical Examples` section.
There are different types of renderer in Xamarin.Forms which you can find [here](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/renderers)

1. Create a custom renderer in the platform project. In this example we use the AllControls-Sample and a `ListViewRenderer` with a iOS-specific implementation.

```fsharp
type MyListViewRenderer() =
    inherit ListViewRenderer()

    override this.OnElementPropertyChanged(sender: obj, e: PropertyChangedEventArgs) =
        base.OnElementPropertyChanged(sender, e)

        if e.PropertyName = "SelectedItem" then
            for cell in this.Controls.VisibleCells do
                cell.SelectionStyle <- UITableViewCellSelectionStyle.None
```

2. Export the renderer with the following code. **Be careful** if you use a Fabulous.XamarinForms. It will effect every element of this type.

```fsharp
[<assembly: ExportRenderer(typeof<Fabulous.XamarinForms.CustomListView>, typeof<MyListViewRenderer>)>]
```

If you only want to modify **one specific** ListView then you need to create your own type as follows:

```fsharp
module TestListViewModule =
    type TLV() = inherit CustomListView() // define a custom type

    type Fabulous.XamarinForms.View with
            // use the specific properties you need
            static member inline TestListView(?items: ViewElement list, ?itemAppearing: int -> unit, ?itemSelected: int option -> unit) =

                let attribCount = 0
                // input the props you need to the correct builder
                let attribs = ViewBuilders.BuildListView(attribCount, ?items=items, ?itemAppearing=itemAppearing, ?itemSelected=itemSelected)

                let update (prevOpt: ViewElement voption) (source: ViewElement) (target: TLV) =
                    ViewBuilders.UpdateListView(prevOpt, source, target) // use the correct updatefunction

                let updateAttachedProperties propertyKey prevOpt source targetChild =
                    ViewBuilders.UpdateListViewAttachedProperties(propertyKey, prevOpt, source, targetChild) // use the correct updatefunction for attachedproperties

                ViewElement.Create<TLV>(TLV, update, updateAttachedProperties, attribs) // create your customtype
```

Now we can export it with the correct type and it will only effect this specific type `TLV` in the example.

```fsharp
// use the correct path to your specific type - TLV is the example here
[<assembly: ExportRenderer(typeof<AllControls.Samples.TestListViewModule.TLV>, typeof<MyListViewRenderer>)>]
```

### Practical Examples

- [FabulousContacts](https://github.com/TimLariviere/FabulousContacts)
  - Renderer Example:
    - BorderedEntry
      - [BorderedEntryRenderer - iOS](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.iOS/BorderedEntryRenderer.fs)
      - [BorderedEntryRenderer - Android](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.Android/BorderedEntryRenderer.fs)
      - [Fabulous.XamarinForms - BorderedEntry](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts/Controls/BorderedEntry.fs)
    - UnderlinedLabel
      - [UnderlinedLabelRenderer - iOS](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.iOS/UnderlinedLabelRenderer.fs)
      - [UnderlinedLabelRenderer - Android](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.Android/UnderlinedLabelRenderer.fs)
      - [Fabulous.XamarinForms - UnderlinedLabel](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts/Controls/UnderlinedLabel.fs)

See also:

- [Xamarin.Forms - Custom Renderer](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)
- [Xamarin.Forms - Introduction to Custom Renderers](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/introduction)
- [Xamarin.Forms - Renderer List](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/renderers)
