namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Input.TextInput
open Avalonia.Markup.Xaml.Styling
open Avalonia.Styling
open Fabulous

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let StylesWidget =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_StylesWidget" (fun target -> (target :?> StyledElement).Styles)

    let Styles =
        Attributes.definePropertyWithGetSet<IStyle seq> "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles) (fun target value ->
            let target = (target :?> StyledElement)
            target.Styles.Clear()

            for an in value do
                target.Styles.Add(an))

    let Classes =
        Attributes.definePropertyWithGetSet<string seq> "StyledElement_Classes" (fun target -> (target :?> StyledElement).Classes) (fun target value ->
            let target = (target :?> StyledElement)
            target.Classes.Clear()

            for an in value do
                target.Classes.Add(an))

    let ContentType =
        Attributes.defineAvaloniaPropertyWithEquality<TextInputContentType> TextInputOptions.ContentTypeProperty

    let ReturnKeyType =
        Attributes.defineAvaloniaPropertyWithEquality<TextInputReturnKeyType> TextInputOptions.ReturnKeyTypeProperty

    let Multiline =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.MultilineProperty

    let Lowercase =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.LowercaseProperty

    let Uppercase =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.UppercaseProperty

    let AutoCapitalization =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.AutoCapitalizationProperty

    let IsSensitive =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.IsSensitiveProperty

    let ShowSuggestions =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.ShowSuggestionsProperty

    let StyleInclude =
        Attributes.defineProperty "StyledElement_StyleInclude" Unchecked.defaultof<string list> (fun target values ->
            let target = (target :?> StyledElement)
            target.Styles.Clear()

            for value in values do
                let style = StyleInclude(baseUri = null)
                style.Source <- Uri(value)
                target.Styles.Add(style))

    let ThemeKey =
        Attributes.defineSimpleScalarWithEquality<string> "StyledElement_ThemeKey" (fun _ newValueOpt node ->
            let target = node.Target :?> StyledElement

            match newValueOpt with
            | ValueNone -> target.Theme <- null
            | ValueSome themeKey ->
                match Application.Current.Styles.TryGetResource(themeKey, null) with
                | true, value ->
                    match value with
                    | :? ControlTheme as controlTheme -> target.Theme <- controlTheme
                    | _ ->
                        node.TreeContext.Logger.Warn("The resource '{0}' is not a ControlTheme. The theme has been unset.", themeKey)
                        target.Theme <- null
                | _ ->
                    node.TreeContext.Logger.Warn("The resource '{0}' was not found. The theme has been unset", themeKey)
                    target.Theme <- null)

type StyledElementModifiers =
    /// <summary>Sets the Name property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Name value.</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Name.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string list) =
        this.AddScalar(StyledElement.Classes.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Classes.WithValue([ value ]))

    /// <summary>Sets the ContentType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContentType value.</param>
    [<Extension>]
    static member inline contentType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: TextInputContentType) =
        this.AddScalar(StyledElement.ContentType.WithValue(value))

    /// <summary>Sets the ReturnKeyType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ReturnKeyType value.</param>
    [<Extension>]
    static member inline returnKeyType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: TextInputReturnKeyType) =
        this.AddScalar(StyledElement.ReturnKeyType.WithValue(value))

    /// <summary>Sets the Multiline property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Multiline value.</param>
    [<Extension>]
    static member inline multiline(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Multiline.WithValue(value))

    /// <summary>Sets the Lowercase property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Lowercase value.</param>
    [<Extension>]
    static member inline lowercase(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Lowercase.WithValue(value))

    /// <summary>Sets the Uppercase property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Uppercase value.</param>
    [<Extension>]
    static member inline uppercase(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Uppercase.WithValue(value))

    /// <summary>Sets the AutoCapitalization property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoCapitalization value.</param>
    [<Extension>]
    static member inline autoCapitalization(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.AutoCapitalization.WithValue(value))

    /// <summary>Sets the IsSensitive property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSensitive value.</param>
    [<Extension>]
    static member inline isSensitive(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.IsSensitive.WithValue(value))

    /// <summary>Sets the application styles.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Application styles to be used for the control.</param>
    [<Extension>]
    static member inline styleInclude(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string list) =
        this.AddScalar(StyledElement.StyleInclude.WithValue(value))

    /// <summary>Sets the application styles.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Application styles to be used for the control.</param>
    [<Extension>]
    static member inline styleInclude(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        StyledElementModifiers.styleInclude(this, [ value ])

    /// <summary>Sets the ShowSuggestions property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowSuggestions value.</param>
    [<Extension>]
    static member inline showSuggestions(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.ShowSuggestions.WithValue(value))

    /// <summary>Adds inline styles used by the widget and its descendants.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Inline styles to be used for the widget and its descendants.</param>
    /// <remarks>Note: Fabulous will recreate the Style/Styles during the view diffing as opposed to a single styled element property.</remarks>
    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabStyledElement>, value: IStyle list) =
        this.AddScalar(StyledElement.Styles.WithValue(value))

    /// <summary>Add inline style used by the widget and its descendants.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Inline style to be used for the widget and its descendants.</param>
    /// <remarks>Note: Fabulous will recreate the Style/Styles during the view diffing as opposed to a single styled element property.</remarks>
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabStyledElement>, value: IStyle) =
        StyledElementModifiers.styles(this, [ value ])

    /// <summary>Sets the ThemeKey property. The ThemeKey is used to lookup the ControlTheme from the
    /// application styles that is applied to the control.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ThemeKey value.</param>
    [<Extension>]
    static member inline themeKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.ThemeKey.WithValue(value))
