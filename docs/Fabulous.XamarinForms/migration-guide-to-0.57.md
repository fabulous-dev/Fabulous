{% include_relative _header.md %}

{% include_relative contents.md %}

## Migrating from v0.56 to v0.57

Fabulous.XamarinForms 0.56 first introduced initial support for the new Path controls, followed by improved support in 0.57.

The new Path controls make heavy use of implicit conversion. For example, to declare a polyline you could either pass it a list of points or a string of a specific format (better for complex paths).
Fabulous handled those kind of multiple types with discriminated unions (e.g. `View.Image(source = ImageSrc imageSource)` vs `View.Image(source = ImagePath "path/to/img.png")`).
But it was not easily discoverable and not really scalable, among other issues.

In Fabulous.XamarinForms 0.57, these discriminated unions have been replaced with functions inside properly-named modules.

### `Image.ImagePath`/`Image.ImageSrc`/etc become `Image.fromPath`/`Image.fromImageSource`/etc

_Old:_

```fsharp
View.Image(
    source = ImagePath "path/to/image.png"
)
View.Image(
    source = ImageBytes myByteArray
)
View.Image(
    source = ImageStream myStream
)
View.Image(
    source = ImageFont myFontImageSource
)
View.Image(
    source = ImageSrc imageSource
)
```

_New:_

```fsharp
View.Image(
    source = Image.fromPath "path/to/image.png"
)
View.Image(
    source = Image.fromBytes myByteArray
)
View.Image(
    source = Image.fromStream myStream
)
View.Image(
    source = Image.fromFont myFontImageSource
)
View.Image(
    source = Image.fromImageSource imageSource
)
```

### `Media.MediaPath`/`Media.MediaSrc` become `Media.fromPath`/`Media.fromMediaSource`

_Old:_

```fsharp
View.Media(
    source = MediaPath "path/to/video.mp4"
)
View.Media(
    source = MediaSrc mediaSource
)
```

_New:_

```fsharp
View.Media(
    source = Media.fromPath "path/to/video.mp4"
)
View.Media(
    source = Media.fromMediaSource mediaSource
)
```

### `FontSize.FontSize`/`FontSize.Named` become `FontSize.fromValue`/`FontSize.fromNamedSize`

_Old:_

```fsharp
View.Label(
    fontSize = FontSize 14.
)
View.Label(
    fontSize = Named NamedSize.Title
)
```

_New:_

```fsharp
View.Label(
    fontSize = FontSize.fromValue 14.
)
View.Label(
    fontSize = FontSize.fromNamedSize NamedSize.Title
)
```

## Xamarin.Forms.SelectableItemsView - SelectionChanged signature changed

_Old:_

```fsharp
SelectionChangedEventArgs ->  unit.
```

_New:_

```fsharp
(ViewElement list option*ViewElement list option)  ->  unit
```

_Example:_

```fsharp
let  navigateToAfterSelectionChanged dispatch (_,  (currentItems:  ViewElement list option))  =
    match currentItems |> Option.bind (List.tryHead)  with
        | None ->  ()
        | Some item ->
            let  animal  = item.TryGetTag<Animal>().Value
            dispatch (SelectAnimal animal)

View.CollectionView(
	selectionMode=SelectionMode.Single,
	selectionChanged=(navigateToAfterSelectionChanged dispatch),
	items=(allAnimals |> List.map Templates.animalTemplate)
)
```

## Extension Changes

The update function for extensions changed because the attached properties are handled different internally now.
_Old:_

```fsharp
    let update (prev: ViewElement voption) (source: ViewElement) (target: ABC) =
        ViewBuilders.UpdateBASE (prev, source, target)
```

_New:_

```fsharp
    let update registry (prev: ViewElement voption) (source: ViewElement) (target: ABC) =
        ViewBuilders.UpdateBASE (registry, prev, source, target)
```
