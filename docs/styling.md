Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Views: Styling
-------

Styling is a significant topic in Xamarin.Forms programming.  

See also:
* [Xamarin.Forms styling](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/).

#### F#-coded styling

The easiest approach is to manually code up styling simply by using normal F# programming to abstract away commonality between
various parts of your view logic.

We do not give a guide here as it is routine application of F# coding.  The [Fulma](https://mangelmaxime.github.io/Fulma/#fulma) approach to styling may also be of interest and provide inspiration.

There are many upsides to this approach. The downsides are:
* styling is done using F# coding, and some UI designers may prefer to work with CSS or another styling technique
* there is no easy way to provide default styling base on selectors like "All buttons" (except of course to carefully code your F# to make sure all button creations go through a particular helper)
* you may end up hand-rolling certain selector queries and patterns from other styling languages.

#### CSS styling with Xamarin.Forms 3.0

1. create a CSS file with appropriate selectors and property specifications, e.g.
```css
stacklayout {
    margin: 20;
}

.mainPageTitle {
    font-style: bold;
    font-size: medium;
}

.detailPageTitle {
    font-style: bold;
    font-size: medium;
    text-align: center;
}

```
where `stacklayout` referes to all elements of that type, and `.mainPageTitle` refers to a specific element style-class path. 

2. Add the style sheet to your app as an `EmbeddedResource` node

3. Load it into your app:
```
type App () as app = 
    inherit Application ()
    do app.Resources.Add(StyleSheet.FromAssemblyResource(Assembly.GetExecutingAssembly(),"MyProject.Assets.styles.css"))
```

4. Set `StyleClass` for named elements, e.g. 

```fsharp
      Xaml.Label(text="Hello", styleClass="detailPageTitle")
      ...
      Xaml.Label(text="Main Page", styleClass="mainPageTitle")
```

You can also add style sheets for particular elements and their contents by using the `styleSheets` property for each visual element. For example:

```fsharp
// Always define your style sheets as static values, sine their object identity is signficant!
let styleSheet = StyleSheet.FromAssemblyResource(Assembly.GetExecutingAssembly(),"MyProject.Assets.styles.css")

let view model disptch = 
    Xaml.ContentPage(styleSheets=[myStyleSheet], ...)
```

#### "Xaml" coding via explicit `Style` objects

You can also use "Xaml styling" by creating specific `Style` objects using the `Xamarin.Forms` APIs directly
and attaching them to your application.   We don't go into details here

```fsharp
// Always define your styles as static values, sine their object identity is signficant!
let style = Style...
let view model disptch = 
    Xaml.ContentPage(styles=[myStyle], ...)
```

See also:
* [Xamarin.Forms styles](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/xaml/). 

