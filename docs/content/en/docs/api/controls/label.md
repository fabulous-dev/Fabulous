

## Label

Constructor

```f#
Label("Hello World")
```

Modifiers

- characterSpacing
```f#
Label("Hello word")
    .characterSpacing(1.)
```
- font
```f#
Label("Hello word")
    .font(size = 12.)
    
Label("Hello word")
    .font(namedSize = NamedSize.Large)
    
Label("Hello word")
    .font(attributes = FontAttributes.Bold)

Label("Hello word")
    .font(fontFamily = "Arial")
```

- horizontalTextAlignment
```f#
Label("Hello word")
    .horizontalTextAlignment(TextAlignment.Center)
```
- lineBreakMode
```f#
Label("Hello word")
    .lineBreakMode(LineBreakMode.WordWrap)
```
- lineHeight
```f#
Label("Hello word")
    .lineHeight(1.5)
```
- maxLines
```f#
Label("Hello word")
    .maxLines(1)
```

- padding
```f#
Label("Hello word")
    .padding(Thickness(10.))
    
Label("Hello word")
    .padding(10.)
    
Label("Hello word")
    .padding(10., 10., 10., 10.)
    
```
- textColor
```f#
Label("Hello word")
    .textColor(Color.Red)
    
Label("Hello word")
    .textColor(light = Color.Red, dark = Color.Blue)
```
- textDecoration
```f#
Label("Hello word")
    .textDecoration(TextDecorations.Underline)
```
- textTransform
```f#
Label("Hello word")
    .textTransform(TextTransform.Lowercase)
```
- textType
```f#
Label("Hello word")
    .textType(TextType.Text)
```
- verticalTextAlignment
```f#
Label("Hello word")
    .verticalTextAlignment(TextAlignment.Center)
```
- centerTextHorizontal
```f#
Label("Hello word")
    .centerTextHorizontal()
```
- centerTextVertical
```f#
Label("Hello word")
    .centerTextVertical()
```
- reference
```f#
let labelRef = ViewRef<Label>()
Label("Hello word")
    .reference(labelRef)
```
