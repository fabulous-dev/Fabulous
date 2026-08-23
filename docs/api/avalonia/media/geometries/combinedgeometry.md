# CombinedGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** CombinedGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/Geometry/)

## Constructors

| Constructors                                                                                                   | Description                        |
| -------------------------------------------------------------------------------------------------------------- | ---------------------------------- |
| CombinedGeometry(geometry1: WidgetBuilder<'msg, #IFabGeometry>, geometry2: WidgetBuilder<'msg, #IFabGeometry>) | Creates a CombinedGeometry widget. |

## Properties

| Properties                                      | Description                                                            |
| ----------------------------------------------- | ---------------------------------------------------------------------- |
| geometryCombineMode(value: GeometryCombineMode) | Sets the GeometryCombineMode property.                                 |
| reference(value: ViewRef)                       | Link a ViewRef to access the direct CombinedGeometry control instance. |

## Usages

```fsharp
CombinedGeometry(RectangleGeometry(Rect(10., 10., 100., 100.)), EllipseGeometry(50., 50.).center(Point(50., 50.)))
    .geometryCombineMode(GeometryCombineMode.Union)
```

#### Get access to the underlying CombinedGeometry

```fsharp
let geometryRef = ViewRef<CombinedGeometry>()

CombinedGeometry(RectangleGeometry(Rect(10., 10., 100., 100.)), EllipseGeometry(50., 50.).center(Point(50., 50.)))
    .geometryCombineMode(GeometryCombineMode.Union)
    .reference(geometryRef)
```
