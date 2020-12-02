{% include_relative _header.md %}

{% include_relative contents-views.md %}

## Views: Custom Renderer / ViewElements

Xamarin.Forms user interfaces are rendered using the native controls of the target platform, allowing Xamarin.Forms applications to retain the appropriate look and feel for each platform. Developers can implement their own custom Renderer classes to customize the appearance and/or behavior of a control.

### Customized ViewElements

Sometimes you just want to change normal properties of a class to create your own viewelement e.g. a customized label.
In this example we have a label which only allows a text, a fontFamily, a backgroundcolor and a rotation. Everything else is not possible to set on this label.

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

If it is not enough to customize specific properties but you want to make platform-specific enhancements and customizations you have to implemen a custom renderer.

1. Create a custom renderer in the platform project. In this example we use the AllControls-Sample with a iOS-specific implementation.

```fsharp
type MyListViewRenderer() =
    inherit ListViewRenderer()

    override this.OnElementPropertyChanged(sender: obj, e: PropertyChangedEventArgs) =
        base.OnElementPropertyChanged(sender, e)

        match e.PropertyName with
        | "SelectedItem" ->
            match this.Element, this.Control with
            | null, null -> ()
            | _ ->
                this.Control.VisibleCells
                |> Array.iter (fun v -> v.SelectionStyle <- UITableViewCellSelectionStyle.None ) // disable all selectionpossibilities
        | _ -> ()
```

2. Export the renderer with the following code. **Be careful** if you use a Fabulous.XamarinForms.\* it will effect every element of this type.

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

See also:

- [Xamarin.Forms - Custom Renderer](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)
- [Xamarin.Forms - Introduction to Custom Renderers](https://docs.microsoft.com/de-de/xamarin/xamarin-forms/app-fundamentals/custom-renderer/introduction)
