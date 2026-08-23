## ColorPicker for Fabulous.Avalonia

The ColorPicker control is a cross-platform view for selecting, previewing, and editing colors in a Fabulous.Avalonia app.
It is based on the Avalonia . See the [Avalonia documentation]

### How to use
- Add the `Fabulous.Avalonia.ColorPicker` package to your project.
- Open `Fabulous.Avalonia` at the top of the file where you declare your Fabulous program (eg. Program.stateful).

```fsharp
open Fabulous.Aavalonia

open type Fabulous.Avalonia.View
```

#### Using the `ColorPicker` Widget

Now you can use the `ColorView`, `ColorPicker`, `ColorSpectrum`, `ColorSlider` and `ColorPreviewer` widgets in your Fabulous app as follows:

```fsharp
ColorView(...)
    .colorSpectrumShape(ColorSpectrumShape.Ring)

ColorPicker(...)
    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))
    .palette(FlatHalfColorPalette())
    
ColorSpectrum(...)
    .cornerRadius(10.)
    .height(256.)
    .width(256.)

ColorSlider(...)
    .colorComponent(ColorComponent.Component1)
    .colorModel(ColorModel.Hsva)
    .hsvColor(model.ColorSpectrum.ToHsv())
    
ColorPreviewer(...)
    .isAccentColorsVisible(false)
    .hsvColor(model.ColorSpectrum.ToHsv())
```

A full, working example is included in the [ColorPicker](https://github.com/fabulous-dev/Fabulous.Avalonia/blob/main/samples/Gallery/Pages/ColorPickerPage.fs) sample

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.