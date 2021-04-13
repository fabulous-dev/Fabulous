{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

Button
--------

<br /> 

### Basic example


```fsharp 
View.Button("Button")
```

<img src="../../images/views/Button-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Button
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ButtonColor,
        padding = style.Padding,
        text = "Button"
    )
```


<img src="../../images/views/Button-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.Button`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Button)

<br /> 

### More examples

Buttons are created using `View.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp 
View.Button(text = "Deposit", command = (fun () -> dispatch (Add 10.0)))
```
<img src="https://user-images.githubusercontent.com/52166903/60180200-5dfc5b00-9817-11e9-87d1-e3d254b1cf2b.png" width="400">