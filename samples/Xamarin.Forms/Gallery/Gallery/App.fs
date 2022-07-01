namespace Gallery

open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

[<assembly: ExportFont("icomoon.ttf", Alias = "Icomoon")>]
[<assembly: ExportFont("JetBrainsMono-Regular.ttf", Alias = "JetBrainsMono")>]
do ()

module App =
    type Model =
        { SelectedWidget: WidgetPage.Model option
          IsFlyoutPresented: bool }
    
    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | ItemSelected of int
        | FlyoutToggled of bool
    
    let init () =
        { SelectedWidget = None
          IsFlyoutPresented = false }, Cmd.none
    
    let update msg model =
        match msg with
        | WidgetPageMsg msg ->
            let m, c = WidgetPage.update msg model.SelectedWidget.Value
            { model with
                SelectedWidget = Some m }, (Cmd.map WidgetPageMsg c)
        
        | ItemSelected index ->
            { model with
                  SelectedWidget = Some (WidgetPage.init index)
                  IsFlyoutPresented = false }, Cmd.none
            
        | FlyoutToggled value ->
            { model with IsFlyoutPresented = value }, Cmd.none
    
    let flyout () =
        ContentPage(
            "Flyout",
            (GroupedListView
                (Samples.Registry.categories)
                (fun category -> TextCell(category.Name))
                (fun widget -> TextCell(widget.Name)))
                .onItemSelected(ItemSelected)
        )
    
    let detail model =
        (NavigationPage() {
            (
                match model.SelectedWidget with
                | None ->
                    ContentPage("", Label("Choose a sample"))
                | Some widgetModel ->
                    View.map WidgetPageMsg (WidgetPage.view widgetModel)
            )
                .backgroundColor(Color.White.ToFabColor(), FabColor.fromHex "#262626")
        })
            .barBackgroundColor(Color.White.ToFabColor(), FabColor.fromHex "#262626")
            .barTextColor(Color.Black.ToFabColor(), Color.White.ToFabColor())
    
    let view model =
        Application(
            FlyoutPage(flyout(), detail model)
                .isPresented(model.IsFlyoutPresented, FlyoutToggled)
        )
        
    let program = Program.statefulWithCmd init update view
