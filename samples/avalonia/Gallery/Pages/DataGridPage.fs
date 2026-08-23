namespace Gallery

open System.Collections.ObjectModel
open Avalonia.Controls
open Avalonia.Data
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module DataGridPage =
    type Person(name, age, male) =
        member val Name = name with get, set
        member val Age = age with get, set
        member val IsMale = male with get, set

    let items =
        ObservableCollection [ Person("John", 20, true); Person("Jane", 21, false); Person("Bob", 22, true) ]

    let view () =
        VStack() {
            DataGrid(items)
                .gridLinesVisibility(DataGridGridLinesVisibility.Horizontal ||| DataGridGridLinesVisibility.Vertical)
                .horizontalGridLinesBrush(Colors.Yellow)
                .rowBackground(Colors.LightBlue)
                .verticalGridLinesBrush(Colors.Red)

            (CustomDataGrid(items) {
                DataGridTextColumn("Name", Binding("Name"))
                    .foreground(Colors.Green)

                DataGridTextColumn(TextBlock("Age"), Binding("Age"))

                DataGridCheckBoxColumn("IsMale", Binding("IsMale"))
                    .isThreeState(true)
            })
                .gridLinesVisibility(DataGridGridLinesVisibility.Horizontal)
                .borderThickness(1.0)
                .borderBrush(SolidColorBrush(Colors.Gray))
        }
