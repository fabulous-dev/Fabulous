namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Styling

[<AbstractClass; Sealed>]
type ThemeAware =
    /// <summary>Sets the theme-aware value</summary>
    /// <param name="light">The value for the light theme</param>
    /// <param name="dark">The value for the dark theme</param>
    static member With(light: 'T, dark: 'T) =
        if Application.Current.ActualThemeVariant = ThemeVariant.Dark then
            dark
        else
            light
