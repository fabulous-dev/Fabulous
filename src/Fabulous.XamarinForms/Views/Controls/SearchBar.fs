namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ISearchBar =
    inherit IInputView

module SearchBar =
    let WidgetKey = Widgets.register<SearchBar> ()

    let Text =
        Attributes.defineBindable<string> SearchBar.TextProperty

    let CancelButtonColor =
        Attributes.defineBindable<Color> SearchBar.CancelButtonColorProperty

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
                SearchBar.Text.WithValue(text),
                InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box),
                SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed)
            )

[<Extension>]
type SearchBarModifiers =
    [<Extension>]
    static member inline cancelButtonColor(this: WidgetBuilder<'msg, #ISearchBar>, value: Color) =
        this.AddScalar(SearchBar.CancelButtonColor.WithValue(value))
