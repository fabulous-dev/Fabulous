namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous.XamarinForms
open Xamarin.Forms

module SwipeView =
    let view() =
        View.NonScrollingContentPage(
            title = "SwipeView sample",
            content = View.SwipeView(
                leftItems = View.SwipeItems(
                    sItems = [
                        View.SwipeItem(text="Left 1", backgroundColor=Color.LightPink)
                        View.SwipeItem(text="Left 2", backgroundColor=Color.LightGreen)
                    ]
                ),
                rightItems = View.SwipeItems(
                    sItems = [
                        View.SwipeItem(text="Right 1", backgroundColor=Color.LightPink)
                        View.SwipeItem(text="Right 2", backgroundColor=Color.LightGreen)
                    ]
                ),
                content = View.Grid(
                    height=60.0,
                    width=300.0,
                    backgroundColor=Color.LightGray,

                    children = [
                        View.BoxView(Color.Blue)
                    ]
                )
            )
        )

