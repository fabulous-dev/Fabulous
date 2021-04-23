{% include_relative _header.md %}

{% include_relative contents.md %}

Image
--------

<br /> 

### Basic example


```fsharp 
View.Image(source = Image.ImagePath "icon.png")
```

<img src="images/views/Image-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Image
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        source = Image.ImagePath "icon.png"
    )
```


<img src="images/views/Image-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Image in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Images)
* [`Xamarin.Forms.Image`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Image)

<br /> 

### More examples

A simple image drawn from a resource or URL is as follows:

```fsharp
let monkey =  "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                    
View.Image( source =  Image.ImagePath monkey)
```

<img src="https://user-images.githubusercontent.com/52166903/60180198-5d63c480-9817-11e9-9458-379a848ccca4.png" width="400">