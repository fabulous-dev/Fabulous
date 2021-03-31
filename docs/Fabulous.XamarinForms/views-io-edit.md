{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for editing text
------
##### `topic last updated: v 0.61.0 - 31.03.2021 - 02:29pm,`
<br /> 

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

<br /> 

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
