namespace Gallery


open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module TreeDataGridPage =
    let view () =
        TabControl() {
            TabItem("Countries", CountriesPage.view())
            TabItem("Files", FilesPage.view())
        }
