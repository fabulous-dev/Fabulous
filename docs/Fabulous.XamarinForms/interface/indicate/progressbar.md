{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

ProgressBar
--------

The Progress Bar represents progress as a horizontal bar, that is filled to a percentage, represented by a float value. 

<br /> 

### Basic example


```fsharp 
View.ProgressBar(progress = 0.5)
```

<img src="../../images/views/ProgressBar-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.ProgressBar
(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    progress = 0.5
)
```


<img src="../../images/views/ProgressBar-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.ProgressBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ProgressBar)

<br /> 

### More examples

`to-do`