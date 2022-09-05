namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type ISearchBar =
    inherit Fabulous.Maui.IInputView

module SearchBar =
    let WidgetKey = Widgets.register<SearchBar>()

    let CancelButtonColor =
        Attributes.defineBindableAppThemeColor SearchBar.CancelButtonColorProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> SearchBar.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> SearchBar.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat SearchBar.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> SearchBar.HorizontalTextAlignmentProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> SearchBar.VerticalTextAlignmentProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool SearchBar.IsTextPredictionEnabledProperty

    let CursorPosition =
        Attributes.defineBindableInt SearchBar.CursorPositionProperty

    let SelectionLength =
        Attributes.defineBindableInt SearchBar.SelectionLengthProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool SearchBar.FontAutoScalingEnabledProperty

    let SearchButtonPressed =
        Attributes.defineEventNoArg
            "SearchBar_SearchButtonPressed"
            (fun target -> (target :?> SearchBar).SearchButtonPressed)

[<AutoOpen>]
module SearchBarBuilders =
    type Fabulous.Maui.View with
        static member inline SearchBar<'msg>(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
            WidgetBuilder<'msg, ISearchBar>(
                SearchBar.WidgetKey,
                InputView.TextWithEvent.WithValue(
                    ValueEventData.create text (fun args -> onTextChanged args.NewTextValue |> box)
                ),
                SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed)
            )

[<Extension>]
type SearchBarModifiers =
    /// <summary>Sets the color of the cancel button text.</summary>
    /// <param name="light">The color of the cancel button text in the light theme.</param>
    /// <param name="dark">The color of the cancel button text in the dark theme.</param>
    [<Extension>]
    static member inline cancelButtonColor(this: WidgetBuilder<'msg, #ISearchBar>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SearchBar.CancelButtonColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ISearchBar>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?fontAutoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontFamily.WithValue(v))

        match fontAutoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the horizontal text alignment</summary>
    /// param name="value">The horizontal text alignment</summary>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ISearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// param name="value">The vertical text alignment</summary>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ISearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.VerticalTextAlignment.WithValue(value))

    /// <summary>Determines whether text prediction and automatic text correction is enabled.</summary>
    [<Extension>]
    static member inline isTextPredictionEnabled(this: WidgetBuilder<'msg, #ISearchBar>, value: bool) =
        this.AddScalar(SearchBar.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Determines the position at which the next character will be inserted into the string stored in the Text property.</summary>
    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #ISearchBar>, value: int) =
        this.AddScalar(SearchBar.CursorPosition.WithValue(value))

    /// <summary>Set the length of text selection within the SearchBar.</summary>
    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #ISearchBar>, value: int) =
        this.AddScalar(SearchBar.SelectionLength.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SearchBar control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISearchBar>, value: ViewRef<SearchBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
