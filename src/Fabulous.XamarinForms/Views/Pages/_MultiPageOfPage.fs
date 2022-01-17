namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module MultiPageOfPage =
    let Children =
        Attributes.defineWidgetCollection
            "MultiPageOfPage"
            (fun target ->
                (target :?> MultiPage<Page>)
                    .Children)