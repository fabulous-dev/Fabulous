{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

BoxView
--------

<br /> 

### Basic example


```fsharp 
View.BoxView()
```

<img src="../../images/views/BoxView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.BoxView
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor
    )
```


<img src="../../images/views/BoxView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView)

<br /> 

### More examples

An example `BoxView` is as follows:
```fsharp 
View.BoxView(
    color = Color.CornflowerBlue, 
    cornerRadius = CornerRadius 10., 
    horizontalOptions = LayoutOptions.Center
    )
```
<img src="https://user-images.githubusercontent.com/6429007/60753625-c1377b80-9fd5-11e9-91cc-eaef04a372cf.png" width="400">