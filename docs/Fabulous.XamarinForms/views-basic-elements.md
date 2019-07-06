Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Basic Elements
-------------------

The basic controls from `Xamarin.Forms.Core` are available.

### Button

Buttons are created using `View.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp
View.Button(text = "Deposit", command = (fun () -> dispatch (Add 10.0)))
```

<img src="https://user-images.githubusercontent.com/52166903/60180200-5dfc5b00-9817-11e9-87d1-e3d254b1cf2b.png" width="400">

See also:

* [Xamarin guide to Button](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button)
* [`Xamarin.Forms.Core.Button`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/)

### Slider

A simple `Slider` is as follows:

```fsharp
View.Slider(
    minimum = 0.0,
    maximum = 10.0,
    value= double step,
    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177363-9d737900-9810-11e9-8842-aeb904e7d739.png" width="400">

See also:

* [Xamarin guide to Slider](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider)
* [`Xamarin.Forms.Core.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider)

### ActivityIndicator

A simple `ActivityIndicator` is as follows:

```fsharp
View.ActivityIndicator(isRunning = (count > 0))
```

<img src="https://user-images.githubusercontent.com/52166903/60177355-9c424c00-9810-11e9-8275-bd8c2ebcf3c8.png" width="400">

See also:

* [`Xamarin.Forms.Core.ActivityIndicator`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ActivityIndicator)

### DatePicker

A simple `DatePicker` is as follows:

```fsharp
View.DatePicker(minimumDate = DateTime.Today,
    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0),
    date = startDate,
    dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)))
```

<img src="https://user-images.githubusercontent.com/52166903/60177357-9cdae280-9810-11e9-9979-1e91cf8c5ea6.png" width="400">

See also:

* [Xamarin guide to DatePicker](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker)
* [`Xamarin.Forms.Core.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker)

### Editor

An example `Editor` is as follows:

```fsharp
View.Editor(text = editorText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EditorEditCompleted text)))
```

<img src="https://user-images.githubusercontent.com/52166903/60175558-d2c99800-980b-11e9-9755-860cc9a60dcf.png" width="400">

See also:

* [`Xamarin.Forms.Core.Editor`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Editor)

### BoxView

An example `BoxView` is as follows:

```fsharp
View.BoxView(Color.CornflowerBlue, cornerRadius=10.)
```

<img src="https://user-images.githubusercontent.com/6429007/60753625-c1377b80-9fd5-11e9-91cc-eaef04a372cf.png" width="400">

See also:

* [`Xamarin.Forms.Core.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView)

### Entry

An example `Entry` is as follows:

```fsharp
View.Entry(
    text = entryText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with password is as follows:

```fsharp
View.Entry(
    text = password,
    isPassword = true,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with a placeholder is as follows:

```fsharp
View.Entry(
    placeholder = "Enter text",
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177359-9cdae280-9810-11e9-9d80-059a9a885b72.png" width="400">

See also:

* [`Xamarin.Forms.Core.Entry`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Entry)

### Frame

A frame contains other content. A simple `Frame` is as follows:

```fsharp
View.Frame(hasShadow = true, backgroundColor = Colors.Fuchsia)
```

<img src="https://user-images.githubusercontent.com/52166903/60180199-5d63c480-9817-11e9-9a64-f306924eb25d.png" width="400">

See also:

* [`Xamarin.Forms.Core.Frame`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Frame)

### Image

A simple image drawn from a resource or URL is as follows:

```fsharp
let monkey = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

View.Image(source = monkey)
```

<img src="https://user-images.githubusercontent.com/52166903/60180198-5d63c480-9817-11e9-9458-379a848ccca4.png" width="400">

See also:

* [Images in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=vswin)
* [`Xamarin.Forms.Core.Image`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Image)

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

View.Picker(
    title = "Choose Color:",
    textColor = snd pickerItems.[pickedColorIndex],
    selectedIndex = pickedColorIndex,
    itemsSource = Array.map fst pickerItems,
    selectedIndexChanged = (fun (i, item) -> dispatch (PickerItemChanged i))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177361-9d737900-9810-11e9-87a2-ade4880f7222.png" width="400">

See also:

* [`Xamarin.Forms.Core.Picker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Picker)

### SearchBar

A simple `SearchBar` is as follows:

```fsharp
View.SearchBar(
    placeholder = "Enter search term",
    searchCommand = (fun searchBarText -> dispatch  (ExecuteSearch searchBarText)),
    canExecute=true)
```

<img src="https://user-images.githubusercontent.com/52166903/60180196-5d63c480-9817-11e9-9c21-e8b19dee8474.png" width="400">

See also:

* [Xamarin.Forms.Core.SearchBar](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar?view=xamarin-forms)

