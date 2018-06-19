Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Views: Core Elements
------

### ContentPage

A single page app typically returns a `ContentPage`. For example:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content= Xaml.Label(text = sprintf "Hello world!")
    )
```

See also: 
* [`Xamarin.Forms.Core.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage).

### StackLayout

A stack layout is a vertically-stacked sequence of content:

```fsharp
    Xaml.StackLayout(padding=20.0,
        children = [
            Xaml.Label(text = sprintf "Welcome to the bank!")
            Xaml.Label(text = sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
        ])
```

See also:
* [`Xamarin.Forms.Core.StackLayout`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/stack-layout/).


### Button

Buttons are created using `Xaml.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp
    Xaml.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0)))
```

See also:
* [`Xamarin.Forms.Core.Button`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/).


### ListView, ListGroupedView

A simple `ListView` is as follows:
```fsharp
    Xaml.ListView(
        items = [ Xaml.Label "Ionide"
                  Xaml.Label "Visual Studio"
                  Xaml.Label "Emacs"
                  Xaml.Label "Visual Studio Code"
                  Xaml.Label "JetBrains Rider"], 
        itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
```

In the underlying implementation, each visual item is placed in a `ContentCell`.
Currently the `itemSelected` callback uses integers indexes for keys to identify the elements (NOTE: this may change in future updates).

There is also a `ListViewGrouped` for grouped items of data.  This uses the same Xamarin control under the hood but in a different mode of use.

See also:
* [`Xamarin.Forms.Core.ListView`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/).

### Slider

A simple `Slider` is as follows:
```fsharp
    Xaml.Slider(minimum=0.0, maximum=10.0, 
        value= double step, 
        valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))) 
```

See also:
* [`Xamarin.Forms.Core.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider).


### ActivityIndicator

A simple `ActivityIndicator` is as follows:
```fsharp
    Xaml.ActivityIndicator(isRunning=(count > 0))
```

See also:
* [`Xamarin.Forms.Core.ActivityIndicator`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ActivityIndicator).


### DatePicker

A simple `DatePicker` is as follows:
```fsharp
    Xaml.DatePicker(minimumDate= DateTime.Today, 
        maximumDate=DateTime.Today + TimeSpan.FromDays(365.0), 
        date=startDate, 
        dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)))
```

See also:
* [`Xamarin.Forms.Core.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker).


### Editor

An example `Editor` is as follows:
```fsharp
    Xaml.Editor(text= editorText, 
        textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
        completed=(fun text -> dispatch (EditorEditCompleted text)))
```

See also:
* [`Xamarin.Forms.Core.Editor`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Editor).


### BoxView

An example `BoxView` is as follows:
```fsharp
    Xaml.BoxView(Colors.Fuchsia)
```

See also:
* [`Xamarin.Forms.Core.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView).

### Entry

An example `Entry` is as follows:
```fsharp
    Xaml.Entry(text= entryText, 
        textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
        completed=(fun text -> dispatch (EntryEditCompleted text)))
```
An example `Entry` with password is as follows:
```fsharp
    Xaml.Entry(text= password, isPassword=true, 
        textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
        completed=(fun text -> dispatch (EntryEditCompleted text)))
```
An example `Entry` with a placeholder is as follows:
```fsharp
    Xaml.Entry(placeholder="Enter text", 
        textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))), 
        completed=(fun text -> dispatch (EntryEditCompleted text)))
```

See also:
* [`Xamarin.Forms.Core.Entry`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Entry).

### Frame

A simple `Frame` is as follows:
```fsharp
    Xaml.Frame(hasShadow=true, backgroundColor=Colors.Fuchsia)
```

See also:
* [`Xamarin.Forms.Core.Frame`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Frame).

### Grid

An example `Grid` is as follows:
```fsharp
    Xaml.Grid(
        rowdefs = [for i in 1 .. 6 -> box "auto"], 
        coldefs = [for i in 1 .. 6 -> box "auto"], 
        children =
            [ for i in 1 .. 6 do for j in 1 .. 6 -> 
                    let color = Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0)
                    Xaml.BoxView(color).GridRow(i-1).GridColumn(j-1) ] )
```
Notes:
* Row and column definitions can use `"*"`, `"auto"` or a thickness
* Fluent methods `.GridRow(..)` and `.GridColumn(..)` are used to place the items in locations on the grid.

See also:
* [`Xamarin.Forms.Core.Grid`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Grid).


### Image

A simple `` drawn from a resource or URL is as follows:
```fsharp
let monkey = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

...
    Xaml.Image(source = monkey) ]))
```

See also:
* [`Xamarin.Forms.Core.Image`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Image).


### Picker

A simple `Picker` is as follows:
```fsharp
let pickerItems = 
    [| ("Aqua", Color.Aqua); ("Black", Color.Black);
        ("Blue", Color.Blue); ("Fucshia", Color.Fuchsia);
        ("Gray", Color.Gray); ("Green", Color.Green);
        ("Lime", Color.Lime); ("Maroon", Color.Maroon);
        ("Navy", Color.Navy); ("Olive", Color.Olive);
        ("Purple", Color.Purple); ("Red", Color.Red);
        ("Silver", Color.Silver); ("Teal", Color.Teal);
        ("White", Color.White); ("Yellow", Color.Yellow ) |]

...
    Xaml.Picker(title = "Choose Color:", 
        textColor = snd pickerItems.[pickedColorIndex], 
        selectedIndex = pickedColorIndex, 
        itemsSource = Array.map fst pickerItems,
        selectedIndexChanged = (fun (i, item) -> dispatch (PickerItemChanged i)))
```

See also:
* [`Xamarin.Forms.Core.Picker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Picker).

### TableView

An example `TableView` is as follows:
```fsharp
    Xaml.TableView(
        items= [ ("Videos", [ Xaml.SwitchCell(on=true, text="Luca 2008", onChanged=(fun args -> ()) ) 
                                Xaml.SwitchCell(on=true, text="Don 2010", onChanged=(fun args -> ()) ) ] )
                    ("Books", [ Xaml.SwitchCell(on=true, text="Expert F#", onChanged=(fun args -> ()) ) 
                                Xaml.SwitchCell(on=false, text="Programming F#", onChanged=(fun args -> ()) ) ])
                    ("Contact", [ Xaml.EntryCell(label="Email", placeholder="foo@bar.com", completed=(fun args -> ()) )
                                Xaml.EntryCell(label="Phone", placeholder="+44 87654321", completed=(fun args -> ()) )] )]) 
```

See also:
* [`Xamarin.Forms.Core.TableView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TableView).

### RelativeLayout

An example `RelativeLayout` is as follows:
```fsharp
    Xaml.RelativeLayout(
        children=[ 
            Xaml.Label(text = "RelativeLayout Example", textColor = Color.Red)
                .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
            Xaml.Label(text = "Positioned relative to my parent", textColor = Color.Red)
                .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
        ])
```

See also:
* [`Xamarin.Forms.Core.RelativeLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RelativeLayout).

### Tap Gestures

Gesture recognizers can be added to any visual element.  For example, here is a `TapGestureRecognizer`:

```fsharp
    Xaml.Frame(hasShadow=true, 
        gestureRecognizers=[ Xaml.TapGestureRecognizer(command=(fun () -> dispatch FrameTapped)) ] )
```

See also:
* [`Xamarin.Forms.Core.TapGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TapGestureRecognizer).


### Pan Gestures

Here is an example of a `PanGestureRecognizer` used to recognize panning touch movements:

```fsharp
    Xaml.Frame(hasShadow=true, 
        gestureRecognizers=[ 
            Xaml.PanGestureRecognizer(touchPoints=1, panUpdated=(fun panArgs -> 
                    if panArgs.StatusType = GestureStatus.Running then 
                        dispatch (PanGesture panArgs)))]) 
```

See also:
* [`Xamarin.Forms.Core.PanGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.PanGestureRecognizer).

### Pinch Gestures

Here is an example of a `PinchGestureRecognizer` used to recognize pinch-or-expand touch movements:

```fsharp
    Xaml.Frame(hasShadow=true, 
        gestureRecognizers=
            [ Xaml.PinchGestureRecognizer(pinchUpdated=(fun pinchArgs -> 
                    dispatch (UpdateSize (pinchArgs.Scale, pinchArgs.Status)))) ] ))
```

See also:
* [`Xamarin.Forms.Core.PinchGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.PinchGestureRecognizer).



#### "Infinite" or "unbounded" ListViews 

"Infinite" (really "unbounded") lists are created by using the `itemAppearing` event to prompt a message which nudges the
underlying model in a direction that will then supply new items to the view. 

For example, consider this pattern:
```fsharp
type Model = 
    { ...
      LatestItemAvailable: int 
    }

type Message = 
    ...
    | GetMoreItems of int

let update msg model = 
    match msg with 
    | ...
    | GetMoreItems n -> { model with LatestItemAvailable = n }
    
let view model dispatch = 
    ...
    Xaml.ListView(
        items = [ for i in 1 .. model.LatestItemAvailable do 
                     yield Xaml.Label("Item " + string i) ], 
        itemAppearing=(fun idx -> if idx >= max - 2 then dispatch (GetMoreItems (idx + 10) ) )  )
...
```
Note:
* The underlying data in the model is just an integer `LatestItemAvailable` (normally it would really be a list of actual entities drawn from a data source)
* On each update to the view we produce all the visual items from `Item 1` onwards
* The `itemAppearing` event is called for each item, e.g. when item `10` appears
* When the event triggers we grow the underlying data model by 10
* This will trigger an update of the view again, with more visual elements available (but not yet appearing)

Surprisingly even this naive technique  is fairly efficient. There are numerous ways to make this more efficient (we aim to document more of these over time too).  One simple one is to memoize each individual visual item using `dependsOn`:
```fsharp
        items = [ for i in 1 .. model.LatestItemAvailable do 
                    yield dependsOn i (fun model i -> Xaml.Label("Item " + string i)) ]
```
With that, this simple list views scale to > 10,000 items on a modern phone, though your mileage may vary.
There are many other techniques (e.g. save the latest collection of visual element descriptions in the model, or to use a `ConditionalWeakTable` to associate it with the latest model).  We will document further techniques in due course. 

Thre is also an `itemDisappearing` event for `ListView` that can be used to discard data from the underlying model and restrict the
range of visual items that need to be generated.

### Other Controls

All other controls from `Xamarin.Forms.Core` are available in the programming model.  See the `AllControls` sample.

See also
* [`Xamarin.Forms` API docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms).



### Resource Dictionaries

In Elmish.XamarinForms, resources dictionaries are just "simple F# programming", e.g.
```fsharp
let horzOptions = LayoutOptions.Center
let vertOptions = LayoutOptions.CenterAndExpand
```
is basically the eqivalent of Xaml:
```xml
<ContentPage.Resources>
    <ResourceDictionary>
        <LayoutOptions x:Key="horzOptions"
                     Alignment="Center" />

        <LayoutOptions x:Key="vertOptions"
                     Alignment="Center"
                     Expands="True" />
    </ResourceDictionary>
</ContentPage.Resources>
```
In other words, you can normally forget about resource dictionaries and just program as you would normally in F#.

Other kinds of resources like images need a little more attention and you may need to ship multiple versions of images etc. for Android and iOS.  TBD: write a guide on these, in the meantime see the samples.


