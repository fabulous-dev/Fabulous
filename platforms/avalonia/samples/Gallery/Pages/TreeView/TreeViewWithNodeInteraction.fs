namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module NodeView =
    type Model = { Name: string; Counter: int }

    type Msg = Increment of RoutedEventArgs

    let init (name: string) = { Name = name; Counter = 0 }

    let update msg model =
        match msg with
        | Increment args ->
            { model with
                Counter = model.Counter + 1 }

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
            (*  TODO is this exception handling a good practice? What best practices are there in MVU?
                Is e.g. bubbling exception up to some app-level error log recommended or is it better to log them locally to a facade? *)
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false // unhandled
#else
            true // handled
#endif
        )

    let view (name) =
        Component("NodeView") {
            let! model = Context.Mvu(program, name)

            Border(
                HStack(5) {
                    TextBlock(model.Counter.ToString())
                    TextBlock(model.Name)
                }
            )
                .onTapped(Increment)
        }

module TreeViewWithNodeInteraction =
    type Node(name, children) =
        member this.Name = name
        member this.Children = children

    type Model =
        { Nodes: Node list
          Selected: Node option }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let branch name (children: Node list) = Node(name, children)

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

        { Nodes = nodes; Selected = None }, []

    let rec findNodes (predicate: Node -> bool) (nodes: Node list) =
        let rec matches (node: Node) =
            if predicate node then
                seq { node }
            else
                node.Children |> Seq.collect matches

        nodes |> Seq.collect matches

    let update msg model =
        match msg with
        | SelectionItemChanged args ->
            let node = args.AddedItems[0] :?> Node
            let modelNode = findNodes (fun n -> n = node) model.Nodes |> Seq.tryExactlyOne
            { model with Selected = modelNode }, Cmd.none

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
        Component("TreeViewWithNodeInteraction") {
            let! model = Context.Mvu program

            HStack() {
                TreeView(
                    model.Nodes,
                    (_.Children),
                    (fun x ->
                        NodeView
                            .view(x.Name)
                            .background(Brushes.Gray)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .borderThickness(1.0)
                            .cornerRadius(5.0)
                            .padding(15.0, 3.0))
                )
                    .onSelectionChanged(SelectionItemChanged)

                if model.Selected.IsSome then
                    TextBlock(model.Selected.Value.Name + " selected")
            }
        }
