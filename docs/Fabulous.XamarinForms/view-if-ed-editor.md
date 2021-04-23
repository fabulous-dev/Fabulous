{% include_relative _header.md %}

{% include_relative contents.md %}

Editor
--------

<br /> 

### Basic example


```fsharp 
View.Editor
    ("Editor")
```

<img src="images/views/editor-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Editor
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        text = "Editor"
    )
```


<img src="images/views/editor-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Editor in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Editor)
* [`Xamarin.Forms.Editor`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Editor)

<br /> 

### More examples

An example `Editor` is as follows:

```fsharp
View.Editor(text = editorText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EditorEditCompleted text)))
```

<img src="https://user-images.githubusercontent.com/52166903/60175558-d2c99800-980b-11e9-9755-860cc9a60dcf.png" width="400">