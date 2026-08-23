namespace Gallery

open System
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Runtime.InteropServices
open Avalonia.Controls
open Avalonia.Controls.Models.TreeDataGrid
open Avalonia.Controls.Selection
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module FilesPage =

    type Model =
        { Drives: string list
          SelectedDrive: string
          SelectedPathText: string
          CellSelection: bool
          Source: HierarchicalTreeDataGridSource<FileTreeNodeModel> }

    type Msg =
        | SelectedPathTextChanged of string
        | SelectedPathKeyDown of Avalonia.Input.KeyEventArgs
        | CellSelectionChanged of bool

    let init () =
        let drives = DriveInfo.GetDrives() |> Array.map(fun x -> x.Name) |> Array.toList

        let source =
            new HierarchicalTreeDataGridSource<FileTreeNodeModel>(Array.Empty<FileTreeNodeModel>())

        source.Columns.AddRange(
            [ CheckBoxColumn<FileTreeNodeModel>(
                  header = null,
                  getter = (fun x -> x.IsChecked),
                  setter = (fun o v -> o.IsChecked <- v),
                  width = Unchecked.defaultof<_>,
                  options = CheckBoxColumnOptions<FileTreeNodeModel>(CanUserResizeColumn = false)
              )

              HierarchicalExpanderColumn<FileTreeNodeModel>(
                  TemplateColumn<FileTreeNodeModel>(
                      "Name",
                      "FileNameCell",
                      "FileNameEditCell",
                      GridLength(1, GridUnitType.Star),
                      TemplateColumnOptions(
                          CompareAscending = FileTreeNodeModel.SortAscending(fun x -> x.Name),
                          CompareDescending = FileTreeNodeModel.SortDescending(fun x -> x.Name),
                          IsTextSearchEnabled = true,
                          TextSearchValueSelector = fun x -> x.Name
                      )
                  ),
                  (fun x -> x.Children),
                  (fun x -> x.HasChildren),
                  (fun x -> x.IsExpanded)
              )

              TextColumn<FileTreeNodeModel, _>(
                  header = "Size",
                  getter = (fun x -> x.Size),
                  options =
                      TextColumnOptions<FileTreeNodeModel>(
                          CompareAscending = FileTreeNodeModel.SortAscending(fun x -> x.Size),
                          CompareDescending = FileTreeNodeModel.SortDescending(fun x -> x.Size)
                      )
              )

              TextColumn<FileTreeNodeModel, DateTimeOffset>(
                  header = "Modified",
                  getter = (fun x -> x.Modified),
                  options =
                      TextColumnOptions<FileTreeNodeModel>(
                          CompareAscending = FileTreeNodeModel.SortAscending(fun x -> x.Modified),
                          CompareDescending = FileTreeNodeModel.SortDescending(fun x -> x.Modified)
                      )
              ) ]
        )

        let selectedDrive =
            if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
                "C:\\"
            else
                drives
                |> List.tryHead
                |> Option.map(fun x -> if x <> null then "/" else "")
                |> Option.defaultValue ""

        source.RowSelection.SingleSelect <- false
        source.RowSelection.SelectionChanged.Add(fun _ -> ())

        let root = FileTreeNodeModel(selectedDrive, isDirectory = true, isRoot = true)
        source.Items <- [| root |]

        { SelectedDrive = selectedDrive
          Drives = drives
          SelectedPathText = ""
          CellSelection = false
          Source = source },
        Cmd.none

    let update msg model =
        match msg with
        | SelectedPathTextChanged text ->
            let mutable selectedDrive = model.SelectedDrive

            if String.IsNullOrEmpty(text) then
                model.Source.RowSelection.Clear()
            else
                let path = text
                let components = Stack<string>()
                let mutable d: DirectoryInfo = null

                if File.Exists(path) then
                    let f = FileInfo(path)
                    components.Push(f.Name)
                    d <- f.Directory

                elif Directory.Exists(path) then
                    d <- DirectoryInfo(path)

                while d <> null do
                    components.Push(d.Name)
                    d <- d.Parent

                let mutable index = IndexPath.Unselected

                if components.Count > 0 then
                    let drive = components.Pop()

                    let driveIndex =
                        model.Drives
                        |> List.findIndex(fun x -> String.Equals(x, drive, StringComparison.OrdinalIgnoreCase))

                    if driveIndex >= 0 then
                        selectedDrive <- model.Drives[driveIndex]

                    let mutable node: FileTreeNodeModel = model.Source.Items |> Seq.head
                    index <- IndexPath(0)

                    while node <> Unchecked.defaultof<_> && components.Count > 0 do
                        node.IsExpanded <- true

                        let component' = components.Pop()

                        let i =
                            node.Children
                            |> Seq.findIndex(fun x -> String.Equals(x.Name, component', StringComparison.OrdinalIgnoreCase))

                        node <- if i >= 0 then node.Children[i] else Unchecked.defaultof<_>
                        index <- if i >= 0 then index.Append(i) else IndexPath.Unselected

                model.Source.RowSelection.SelectedIndex <- index

            { model with
                SelectedPathText = text
                SelectedDrive = selectedDrive },
            Cmd.none
        | SelectedPathKeyDown args ->
            if args.Key = Avalonia.Input.Key.Enter then
                { model with
                    SelectedPathText = model.SelectedPathText },
                Cmd.none
            else
                model, Cmd.none
        | CellSelectionChanged v ->
            if v then
                let treeDataGridCellSelectionModel =
                    TreeDataGridCellSelectionModel<FileTreeNodeModel>(model.Source)

                treeDataGridCellSelectionModel.SingleSelect <- false
                model.Source.Selection <- treeDataGridCellSelectionModel
            else
                let treeDataGridRowSelectionModel =
                    TreeDataGridRowSelectionModel<FileTreeNodeModel>(model.Source)

                treeDataGridRowSelectionModel.SingleSelect <- false
                model.Source.Selection <- treeDataGridRowSelectionModel

            { model with CellSelection = v }, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("FilesPage") {
            let! model = Context.Mvu program

            Dock() {
                (Dock() {
                    ComboBox(model.Drives)
                        .selectedItem(model.SelectedDrive)
                        .dock(Dock.Left)

                    CheckBox("Cell Selection", model.CellSelection, CellSelectionChanged)
                        .margin(4, 0, 0, 0)
                        .dock(Dock.Right)

                    TextBox(model.SelectedPathText, SelectedPathTextChanged)
                        .margin(4, 0, 0, 0)
                        .verticalContentAlignment(VerticalAlignment.Center)
                        .onKeyDown(SelectedPathKeyDown)
                })
                    .dock(Dock.Top)
                    .margin(0, 4)

                TreeDataGrid(model.Source).autoDragDropRows(true)
            }
        }
