namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabSearchBar =
    inherit IFabInputView

module SearchBar =
    let WidgetKey = Widgets.register<SearchBar>()

    let CancelButtonColor =
        Attributes.defineBindableColor SearchBar.CancelButtonColorProperty

    let CursorPosition = Attributes.defineBindableInt SearchBar.CursorPositionProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> SearchBar.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool SearchBar.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> SearchBar.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat SearchBar.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> SearchBar.HorizontalTextAlignmentProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool SearchBar.IsTextPredictionEnabledProperty

    let SearchButtonPressed =
        Attributes.Mvu.defineEventNoArg "SearchBar_SearchButtonPressed" (fun target -> (target :?> SearchBar).SearchButtonPressed)

    let SelectionLength = Attributes.defineBindableInt SearchBar.SelectionLengthProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> SearchBar.VerticalTextAlignmentProperty

[<AutoOpen>]
module SearchBarBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a SearchBar widget with a text and listen for both text changes and search button presses</summary>
        /// <param name="text">The text value</param>
        /// <param name="onTextChanged">Message to dispatch</param>
        /// <param name="onSearchButtonPressed">Message to dispatch</param>
        static member inline SearchBar<'msg when 'msg: equality>(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
            WidgetBuilder<'msg, IFabSearchBar>(
                SearchBar.WidgetKey,
                InputView.TextWithEvent.WithValue(ValueEventData.create text (fun (args: TextChangedEventArgs) -> onTextChanged args.NewTextValue)),
                SearchBar.SearchButtonPressed.WithValue(MsgValue(onSearchButtonPressed))
            )

[<Extension>]
type SearchBarModifiers =
    /// <summary>Set the color of the cancel button text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the cancel button text</param>
    [<Extension>]
    static member inline cancelButtonColor(this: WidgetBuilder<'msg, #IFabSearchBar>, value: Color) =
        this.AddScalar(SearchBar.CancelButtonColor.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabSearchBar>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
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

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the horizontal text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal text alignment</param>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabSearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the value indicating whether the field is enabled for text prediction and suggestion</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the field is enabled for text prediction and suggestion</param>
    [<Extension>]
    static member inline isTextPredictionEnabled(this: WidgetBuilder<'msg, #IFabSearchBar>, value: bool) =
        this.AddScalar(SearchBar.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Set the position of the cursor</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The position of the cursor</param>
    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #IFabSearchBar>, value: int) =
        this.AddScalar(SearchBar.CursorPosition.WithValue(value))

    /// <summary>Set the selection length</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The selection length</param>
    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #IFabSearchBar>, value: int) =
        this.AddScalar(SearchBar.SelectionLength.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical text alignment</param>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabSearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SearchBar control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSearchBar>, value: ViewRef<SearchBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
