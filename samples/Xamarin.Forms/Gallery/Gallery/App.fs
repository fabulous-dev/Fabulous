namespace Gallery

open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model =
        { SelectedWidget: string
          IsFlyoutPresented: bool }

    type Msg =
        | ItemSelected of int
        | FlyoutToggled of bool

    let init () =
        { SelectedWidget = "None"
          IsFlyoutPresented = false }

    let update msg model =
        match msg with
        | ItemSelected index -> { model with SelectedWidget = Registry.widgets.[index]; IsFlyoutPresented = false }
        | FlyoutToggled value -> { model with IsFlyoutPresented = value }
        
    let flyout () =
        ContentPage(
            "Flyout",
            (ListView(Registry.widgets) (fun widget ->
                TextCell(widget)
            ))
                .onItemSelected(ItemSelected)
        )
        
    let detail model =
        NavigationPage() {
            ContentPage(
                "Detail",
                VStack() {
                    (HStack() {
                        Label("Fabulous Gallery")
                            .font(namedSize = NamedSize.Title)
                            .textColor(Color.White.ToFabColor())
                            .centerHorizontal(expand = true)
                    })
                        .backgroundColor(FabColor.fromHex "#507aae")
                        .padding(Thickness(0., 44., 0., 8.))
                        
                    ScrollView(                        
                        VStack() {
                            Label(model.SelectedWidget)
                            
                            for i = 0 to 1000 do
                                Label("Test")
                        }
                    )
                        .alignStartVertical(expand = true)
                }
            )
        }

    let view model =
        Application(
            FlyoutPage(
                flyout(),
                detail model
            )
                .isPresented(model.IsFlyoutPresented, FlyoutToggled)
        )

    let program = Program.stateful init update view
