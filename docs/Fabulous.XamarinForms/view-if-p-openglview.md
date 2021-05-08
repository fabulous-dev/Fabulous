{% include_relative _header.md %}

{% include_relative contents.md %}

OpenGLView
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.OpenGLView(hasRenderLoop = true)
```

<img src="images/view/OpenGLView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.OpenGLView
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        margin = style.Thickness,
        hasRenderLoop = true                                                    
    )
```


<img src="images/view/OpenGLView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.OpenGLView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.OpenGLView)

<br /> 

### More examples

`to-do`