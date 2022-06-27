namespace Gallery

open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    // type Model =
    //     { SelectedWidget: string
    //       IsFlyoutPresented: bool }
    //
    // type Msg =
    //     | ItemSelected of int
    //     | FlyoutToggled of bool
    //
    // let init () =
    //     { SelectedWidget = "None"
    //       IsFlyoutPresented = false }
    //
    // let update msg model =
    //     match msg with
    //     | ItemSelected index ->
    //         { model with
    //               SelectedWidget = (Registry.getForIndex index).Name
    //               IsFlyoutPresented = false }
    //     | FlyoutToggled value -> { model with IsFlyoutPresented = value }
    //
    // let flyout () =
    //     ContentPage(
    //         "Flyout",
    //         (GroupedListView
    //             (Registry.categories)
    //             (fun category -> TextCell(category.Name))
    //             (fun widget -> TextCell(widget.Name)))
    //             .onItemSelected(ItemSelected)
    //     )
    //
    // let detail model =
    //     NavigationPage() {
    //         ContentPage(
    //             "Detail",
    //             VStack(spacing = 20.) {
    //                 (HStack() {
    //                     Label("Fabulous Gallery")
    //                         .font(namedSize = NamedSize.Title)
    //                         .textColor(Color.White.ToFabColor())
    //                         .centerHorizontal(expand = true)
    //                  })
    //                     .backgroundColor(FabColor.fromHex "#507aae")
    //                     .padding(Thickness(0., 44., 0., 8.))
    //
    //                 ScrollView(
    //                     VStack(spacing = 20.) {
    //                         Label("Description")
    //                             .font(namedSize = NamedSize.Subtitle)
    //                             .centerHorizontal()
    //
    //                         Label(model.SelectedWidget)
    //
    //                         FlexLayout(FlexWrap.Wrap) {
    //                             for category in Registry.categories do
    //                                 Label(category.Name)
    //                                     .height(175.)
    //                                     .width(175.)
    //                                     .centerTextHorizontal()
    //                                     .centerTextVertical()
    //                                     .backgroundColor(Color.Fuchsia.ToFabColor())
    //                                     .margin(10.)
    //                         }
    //                     }
    //                 )
    //                     .alignStartVertical(expand = true)
    //             }
    //         )
    //             .ignoreSafeArea()
    //             .hasNavigationBar(false)
    //     }
    //
    // let view model =
    //     Application(
    //         FlyoutPage(flyout(), detail model)
    //             .isPresented(model.IsFlyoutPresented, FlyoutToggled)
    //     )
    
    let init () =
        WidgetPage.init 1
        
    let update msg model =
        WidgetPage.update msg model
        
    let view model =
        Application(
            WidgetPage.view model
        )

    let program = Program.stateful init update view
