namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ISearchBar =
    inherit IInputView

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

    let SearchButtonPressed =
        Attributes.defineEventNoArg
            "SearchBar_SearchButtonPressed"
            (fun target -> (target :?> SearchBar).SearchButtonPressed)

[<AutoOpen>]
module SearchBarBuilders =
    type Fabulous.XamarinForms.View with
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
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontSize.WithValue(Device.GetNamedSize(v, typeof<SearchBar>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(SearchBar.FontFamily.WithValue(v))

        res

    /// <summary>Set the horizontal text alignment</summary>
    /// param name="alignment">The horizontal text alignment</summary>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ISearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// param name="alignment">The vertical text alignment</summary>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ISearchBar>, value: TextAlignment) =
        this.AddScalar(SearchBar.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SearchBar control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISearchBar>, value: ViewRef<SearchBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
