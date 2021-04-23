{% include_relative _header.md %}

{% include_relative contents.md %}

Picker
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

displays a selected item from a list of text strings, and allows selecting that item when the view is tapped

<br /> 

### Basic example


```fsharp 
let pickerItems =
    [  ("Aqua", Color.Aqua); ("Black", Color.Black);
        ("Blue", Color.Blue); ("Fucshia", Color.Fuchsia);
        ("Gray", Color.Gray); ("Green", Color.Green);
        ("Lime", Color.Lime); ("Maroon", Color.Maroon);
        ("Navy", Color.Navy); ("Olive", Color.Olive);
        ("Purple", Color.Purple); ("Red", Color.Red);
        ("Silver", Color.Silver); ("Teal", Color.Teal);
        ("White", Color.White); ("Yellow", Color.Yellow ) ]

let pickedColorIndex = 2 // placeholder for testing purposes 
View.ContentPage(title ="Picker", content =                     
    View.Picker
        (
            title = "Choose Color:",
            textColor = snd pickerItems.[pickedColorIndex],
            selectedIndex = pickedColorIndex,
            items = List.map fst pickerItems
            //selectedIndexChanged = (fun (i, item) -> dispatch (PickerItemChanged i))
        )
)
```

<img src="images/views/picker-adr-basic.png" width="300">

<br /> <br /> 

See also:

* [Picker in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Picker)
* [`Xamarin.Forms.Picker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Picker)


### More examples

<img src="https://user-images.githubusercontent.com/52166903/60177361-9d737900-9810-11e9-87a2-ade4880f7222.png" width="400">