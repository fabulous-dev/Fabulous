namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open Fabulous.Avalonia.Expander
open type Fabulous.Avalonia.View

module SimpleTreeViewItem =
    type Node =
        { Name: string
          Children: Node list }

        static member Empty = { Name = ""; Children = [] }

    type Model =
        { Items: Node list
          SelectedItems: Node list
          SelectionMode: SelectionMode
          IsExpanded: bool
          Root: Node }

    type Msg = OnExpanded of bool

    let branch name children = { Name = name; Children = children }

    let leaf name = branch name []

    let init () =
        let nodes =
            [ branch
                  "Animals"
                  [ branch "Mammals" [ leaf "Lion"; leaf "Cat"; leaf "Zebra" ]
                    branch
                        "Birds"
                        [ leaf "Eagle"
                          leaf "Sparrow"
                          leaf "Dove"
                          leaf "Owl"
                          leaf "Parrot"
                          leaf "Pigeon" ]
                    leaf "Platypus" ]
              branch
                  "Aliens"
                  [ branch "pyramid-building terrestrial" [ leaf "Camel"; leaf "Lama"; leaf "Alpaca" ]
                    branch "extra-terrestrial" [ leaf "Alf"; leaf "E.T."; leaf "Klaatu" ] ] ]

        { Items = nodes
          SelectedItems = []
          IsExpanded = false
          SelectionMode = SelectionMode.Single
          Root = Node.Empty },
        []

    let update msg model =
        match msg with
        | OnExpanded isExpnaded -> { model with IsExpanded = isExpnaded }, Cmd.none

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
        Component("SimpleTreeViewItem") {
            let! model = Context.Mvu program

            VStack() {
                TreeView(
                    model.Items,
                    _.Children,
                    (fun x ->
                        TreeViewItem(
                            Border(TextBlock(x.Name))
                                .background(Brushes.Gray)
                                .horizontalAlignment(HorizontalAlignment.Left)
                                .borderThickness(1.0)
                                .cornerRadius(5.0)
                                .padding(15.0, 3.0)
                        )
                            .isHitTestVisible(false)
                            .focusable(false)
                            .onExpandedChanged(model.IsExpanded, OnExpanded))
                )
            }
        }
