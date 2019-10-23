Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents.md %}

Migrating from v0.42 to v0.50
--------

In Fabulous.XamarinForms v0.50, a few breaking changes have been introduced in order to provide support for missing controls, reduce unnecessary update calls (and fix a potential infinite loop on Android) as well as provide better type-safety for some properties.

Below you can find how to migrate your v0.42 views to v0.50.


__Changes to properties__
- [HeightRequest / WidthRequest renamed to Height / Width](#height_width)
- [Margin / Padding properties input changed from `obj` to `Xamarin.Forms.Thickness`](#thickness)
- [Image properties input changed from `obj` to `Image`](#imagesource)
- [FontSize properties input changed from `obj` to `FontSize`](#fontsize)
- [RowDefs / ColumnDefs input changed from `obj list` to `Dimension list`](#gridrow_gridcolumn)
- [StyleClass renamed to StyleClasses and input changed from `obj` to `string list`](#styleclasses)
- [ListView and ListViewGrouped now require items (and group headers) to be Cells, adds support for TextCell / ImageCell / SwitchCell / EntryCell / ViewCell](#listview-cells)

__Changes to events__
- [Events no longer triggered by changes in incremental updates](#events)

### HeightRequest / WidthRequest renamed to Height / Width

We simplified the View API a bit by renaming `heightRequest` and `widthRequest` to respectively `height` and `width`.

The `Request` part was only meaningful for Xamarin.Forms to differentiate the actual height/width from the requested height/width.  
In Fabulous.XamarinForms, this differentiation wasn't useful since you only provide a representation of the view you want.

_Old:_
```fsharp
View.StackLayout(
    heightRequest = 200.,
    widthRequest = 200.
)
```

_New:_
```fsharp
View.StackLayout(
    height = 200.,
    width = 200.
)
```

### Margin / Padding properties input changed from `obj` to `Xamarin.Forms.Thickness`

Thickness-based properties like `margin` and `padding` are now directly requesting a `Xamarin.Forms.Thickness` value instead of `obj`.

Previously Fabulous.XamarinForms was able to implicitly convert `float` to `Thickness`, but it wasn't adding much value and was to the detriment of type-safety.

_Old:_
```fsharp
View.StackLayout(
    margin = 200.
)
```

_New:_
```fsharp
open Xamarin.Forms

View.StackLayout(
    margin = Thickness 200. // or Thickness(10., 20.) or Thickness(10., 20., 30., 40.)
)
```

### Image properties input changed from `obj` to `Image`

Image properties are now requesting an `Image` value instead of `obj`.

Previously Fabulous.XamarinForms was able to implicitly convert `string` / `byte array` to `ImageSource`, but the input type wasn't providing type-safety.

`Image` is a discriminated union with the following values:
- `Path of string`: Represents a path to an image
- `Bytes of byte array`: Represents a byte array representing an image
- `Source of Xamarin.Forms.ImageSource`: Represents an already existing ImageSource

_Old:_
```fsharp
View.Image(
    source = "image.png" // or bytes[] or Xamarin.Forms.ImageSource
)
```

_New:_
```fsharp
// With a path
View.Image(
    source = Path "image.png"
)

// or with a byte array
let data : byte array = [| 0; 1 |]
View.Image(source = Bytes data)

// or with an already existing Xamarin.Forms.ImageSource
let imageSource = Xamarin.Forms.FileImageSource()
imageSource.File <- "image.png"
View.Image(source = Source imageSource)
```

### FontSize properties input changed from `obj` to `FontSize`

FontSize properties are now requesting a `FontSize` value instead of `obj`.

Previously Fabulous.XamarinForms was able to implicitly convert `string` / `int` to `float`, but the input type wasn't providing type-safety.

`FontSize` is a discriminated union with the following values:
- `FontSize of float`: Represents an absolute size value
- `Named of Xamarin.Forms.NamedSize`: Represents a device-dependent predefined size

_Old:_
```fsharp
View.Label(
    fontSize = 20.
)
```

_New:_
```fsharp
View.Label(
    fontSize = FontSize 20.
)

// or with a named size
View.Label(fontSize = Named NamedSize.Large)
```

### RowDefs / ColumnDefs input changed from `obj list` to `Dimension list`

RowDefs and ColumnDefs properties are now requesting a `Dimension list` value instead of `obj list`.

Previously Fabulous.XamarinForms was able to implicitly convert `string` / `int` to either `RowDefinition` or `ColumnDefinition`, but the string could be set to anything and was case-sensitive, resulting in the properties being ignored.

`Dimension` is a discriminated union with the following values:
- `Auto`: Represents a size that fits the children of the row or column
- `Star`: Represents a size using a proportional weight of 1
- `Stars of float`: Represents a size using a given proportional weight
- `Absolute of int`: Represents an absolute size using device-specific units

_Old:_
```fsharp
View.Grid(
    coldefs = [ "auto"; "*";  "2.5*"; "250" ],
    rowdefs = [ "auto"; "*";  "2.5*"; "250" ]
)
```

_New:_
```fsharp
open Fabulous.XamarinForms

View.Grid(
    coldefs = [ Auto; Star; Stars 2.5; Absolute 250 ],
    rowdefs = [ Auto; Star; Stars 2.5; Absolute 250 ]
)
```

### StyleClass renamed to StyleClasses and input changed from `obj` to `string list`

The StyleClass property was accepting both a single class (`string`) and multiple (`string list`) requiring us to use `obj` as the input type.

Since it wasn't adding much value and reducing type-safety, StyleClass has been renamed StyleClasses and only accepts `string list`.

_Old:_
```fsharp
View.Label(
    styleClass = "class-label" // or [ "class-labelA"; "class-labelB" ]
)
```

_New:_
```fsharp
View.Label(
    styleClasses = [ "class-label" ]
)

// or with multiple classes
View.Label(styleClasses = [ "class-labelA"; "class-labelB" ])
```

### ListView and ListViewGrouped now require items (and group headers) to be Cells, adds support for TextCell / ImageCell / SwitchCell / EntryCell / ViewCell

ListView in Xamarin.Forms requires the items to inherit from Cell.  
In v0.42 and before, Fabulous.XamarinForms was implicitly creating for you a ViewCell to let us create any cell content easily.  
While this was useful and required less code, it was preventing you from using premade cells like `TextCell`, `EntryCell`, etc. or even access the cell's properties like `ContextActions`.

So to allow those missing features, the cell is no longer created implicitly for you.  
`ListView` and `ListViewGrouped` will now only accept Cells as items.

_Old:_
```fsharp
View.ListView(
    items = [
        View.Label(text = model.Text)
    ]
)
```

_New:_
```fsharp
View.ListView(
    items = [
        View.ViewCell(
            view = View.Label(text = model.Text)
        )
    ]
)
```

You can now use premade cells like this:

```fsharp
View.ListView(
    items = [
        // TextCell
        View.TextCell(
            text = model.Text,
            details = model.Details
        )

        // ImageCell
        View.ImageCell(
            image = Path "image.png",
            text = model.Text,
            details = model.Details
        )

        // EntryCell
        View.EntryCell(
            text = model.Text,
            textChanged = fun args -> dispatch (SetText args.NewTextValue)
        )

        // SwitchCell
        View.SwitchCell(
            text = model.Text,
            on = model.IsToggled
            onChanged = fun args -> dispatch (SetToggled args.Value)
        )
    ]
)
```

And you can declare context actions like this

```
View.ListView(
    items = [
        View.ViewCell(
            view = View.Label(text = model.Text),
            contextActions = [
                View.MenuItem(text = "Delete", isDestructive = true, command = fun() -> dispatch Delete)
            ]
        )
    ]
)
```

### Events no longer triggered by changes in incremental updates

