{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

Entry
--------

<br /> 

### Basic example


```fsharp 
View.Entry("Entry")
```

<img src="../../images/views/entry-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Entry
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        text = "Entry"
    )
```

<img src="../../images/views/entry-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Entry in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Entry)
* [`Xamarin.Forms.`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.)

<br />

### More examples

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