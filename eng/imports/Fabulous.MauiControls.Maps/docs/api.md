### Map widget

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visualelement/) -> [View](https://docs.fabulous.dev/v2/api/visual-element/)  
**Xamarin.Forms documentation:** Button [API](https://learn.microsoft.com/en-us/dotnet/api/xamarin.forms.maps.map) / [Guide](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/).

## Constructors

| Constructors | Description |
|--|--|
| Map() | Defines a Map widget |

## Properties

| Properties | Description |
|--|--|
| reference(value: ViewRef&lt;Map&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Maps.Map` instance associated to this widget |

## Usages

```fs
Map()
```

### Get access to the underlying Xamarin.Forms.Maps.Map

```fs
let mapRef = ViewRef<Map>()

Map()
    .reference(mapRef)
```