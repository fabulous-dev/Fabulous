Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Views: Styling
-------

### F#-coded styling

The easiest approach is to manually code up styling simply by using normal F# programming to abstract away commonality between
various parts of your view logic.

For example, if a set of Labels share the same margin and color you can write this:
```fsharp
let Label text = 
	View.Label(text=text, margin=Thickness(0.0, 4.0), textColor=Color.Black)

Label(text="This monkey is laid back and relaxed, and likes to watch the world go by.")
Label(text="  - Often smiles mysteriously")
Label(text="  - Sleeps sitting up")
```

We do not give a full guide here as it is routine application of F# coding.  

There are many upsides to this approach. The downsides are:
* styling is done using F# coding, and some UI designers may prefer to work with CSS or another styling technique
* there is no easy way to provide default styling base on selectors like "All buttons" (except of course to carefully code your F# to make sure all button creations go through a particular helper)
* you may end up hand-rolling certain selector queries and patterns from other styling languages.

### CSS styling with Xamarin.Forms 3.0

1. create a CSS file with appropriate selectors and property specifications.

2. Add the style sheet to your app as an `EmbeddedResource` node.

3. Load it into your app.

4. Set `styleClass` for named elements.

For example, places the following CSS into "MyProject.Assets.styles.css":
```
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

Here `stacklayout` referes to all elements of that type, and `.mainPageTitle` refers to a specific element style-class path. 

The CSS is added to the app in your main app code:
```fsharp
type App () as app = 
    inherit Application ()
    do app.Resources.Add(StyleSheet.FromAssemblyResource(Assembly.GetExecutingAssembly(),"MyProject.Assets.styles.css"))
```
Set the style classes as follows:
```fsharp
    View.Label(text="Hello", styleClass="detailPageTitle")
    ...
    View.Label(text="Main Page", styleClass="mainPageTitle")
```

You can also add style sheets for particular elements and their contents by using the `styleSheets` property for each visual element. For example:

```fsharp
// Always define your style sheets as static values, sine their object identity is signficant!
let styleSheet = StyleSheet.FromAssemblyResource(Assembly.GetExecutingAssembly(),"MyProject.Assets.styles.css")

let view model disptch = 
    View.ContentPage(styleSheets=[myStyleSheet], ...)
```

### "Xaml" coding via explicit `Style` objects

You can also use "Xaml styling" by creating specific `Style` objects using the `Xamarin.Forms` APIs directly
and attaching them to your application.   We don't go into details here

```fsharp
// Always define your styles as static values, sine their object identity is signficant!
let style = Style...
let view model disptch = 
    View.ContentPage(styles=[myStyle], ...)
```

### Resource Dictionaries

In Xamarin.Forms documentation you may see references to resource dictionaries.
In Fabulous, resources dictionaries are replaced by "simple F# programming", e.g.
```fsharp
let horzOptions = LayoutOptions.Center
let vertOptions = LayoutOptions.CenterAndExpand
```
is basically the equivalent of Xaml:
```xml
<ContentPage.Resources>
    <ResourceDictionary>
        <LayoutOptions x:Key="horzOptions"
                     Alignment="Center" />

        <LayoutOptions x:Key="vertOptions"
                     Alignment="Center"
                     Expands="True" />
    </ResourceDictionary>
</ContentPage.Resources>
```
In other words, you can normally forget about resource dictionaries and just program as you would normally in F#.

Other kinds of resources like images need a little more attention and you may need to ship multiple versions of images etc. for Android and iOS.  TBD: write a guide on these, in the meantime see the samples.


See also:
* [Xamarin.Forms styling](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/)


