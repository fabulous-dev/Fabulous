namespace Gallery

open System.Collections.ObjectModel
open System.Diagnostics
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.VisualTree
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module FocusAttributes =
    /// Allows setting the Focus on a AutoCompleteBox
    let Focus =
        let rec focusOnce obj _ =
            let autoComplete = unbox<AutoCompleteBox> obj
            autoComplete.Focus(NavigationMethod.Unspecified) |> ignore
            autoComplete.TemplateApplied.RemoveHandler(focusOnce) // to clean up

        Attributes.defineBool "Focus" (fun _ newValueOpt node ->
            if newValueOpt.IsSome && newValueOpt.Value then
                let autoComplete = unbox<AutoCompleteBox> node.Target
                autoComplete.TemplateApplied.RemoveHandler(focusOnce) // to avoid duplicate handlers

                (*  Wait to call Focus() on AutoCompleteBox until after TemplateApplied
                    because of internal Avalonia AutoCompleteBox implementation:
                    FocusChanged only applies the Focus to the nested TextBox if it is set - which happens in OnApplyTemplate.
                    See https://github.com/AvaloniaUI/Avalonia/blob/master/src/Avalonia.Controls/AutoCompleteBox/AutoCompleteBox.cs *)
                autoComplete.TemplateApplied.AddHandler(focusOnce))

type FocusModifiers =
    /// Sets the Focus on an IFabAutoCompleteBox if set is true; otherwise does nothing.
    [<Extension>]
    static member inline focus(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, set: bool) =
        this.AddScalar(FocusAttributes.Focus.WithValue(set))

type EditableNode(name, children) =
    let mutable _name: string = name
    let mutable _children: EditableNode list = children
    let mutable _expanded: bool = false
    let mutable _selected: bool = false

    // provides info for debugging node expansion and selection
    let getFlags () =
        [| let isBranch = _children.IsEmpty |> not

           if isBranch && _expanded then
               yield 'E'

           if _selected then
               yield 'S'

           if isBranch then yield 'B' else yield 'L' |]

    //TODO Is a mutable model required or can an updated immutable model be passed to the parent component?
    member this.Name
        with get () = _name
        and set value = _name <- value

    member this.Children
        with get () = _children
        and set value = _children <- value

    member this.IsExpanded
        with get () = _expanded
        and set value = _expanded <- value

    member this.IsSelected
        with get () = _selected
        and set value = _selected <- value

    // for debugging
    override this.ToString() =
        this.Name + " " + System.String(getFlags())

module EditableNodeView =
    type Model = { Node: EditableNode }

    type Msg = NameChanged of string

    let init node = { Node = node }

    let update msg (model: Model) =
        match msg with
        | NameChanged name ->
            model.Node.Name <- name
            model

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false // unhandled
#else
            true // handled
#endif
        )

    let view node =
        Component("EditableNodeView") {
            let _ = Context.Mvu(program, node)

            AutoCompleteBox([])
                .onTextChanged(node.Name, NameChanged)
                .focus(node.Name = "")
        }

module EditableTreeView =

    type Model =
        { Nodes: EditableNode list
          Filter: string
          JoinedSelection: string
          Selected: ObservableCollection<EditableNode> }

    type Msg =
        | AddNodeTo of string
        | RemoveNode of EditableNode
        | FilterChanged of string
        | SelectionChanged of SelectionChangedEventArgs

    let branch name (children: EditableNode list) = EditableNode(name, children)
    let leaf name = branch name []

    let private concat (nodes: EditableNode seq) =
        nodes |> Seq.map(_.Name) |> String.concat ", "

    // updated when Model.Selected changes
    let mutable joinedSelection = ""

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
                  [ branch "pyramid-building terrestrial" [ leaf "Alpaca"; leaf "Camel"; leaf "Lama" ]
                    branch "extra-terrestrial" [ leaf "Alf"; leaf "E.T."; leaf "Klaatu" ] ] ]

        let selected = ObservableCollection<EditableNode>()
        selected.CollectionChanged.Add(fun args -> joinedSelection <- concat selected)

        { Nodes = nodes
          Filter = ""
          JoinedSelection = ""
          Selected = selected },
        []

    let rec findNodes (predicate: EditableNode -> bool) (nodes: EditableNode seq) =
        let rec matches (node: EditableNode) =
            if predicate node then
                seq { node }
            else
                node.Children |> Seq.collect matches

        nodes |> Seq.collect matches

    let rec removeNode (removable: EditableNode) (node: EditableNode) : EditableNode option =
        if node = removable then
            None // Indicates that the node was found and removed
        else
            let remaining = node.Children |> List.choose(removeNode removable)

            if remaining.Length < node.Children.Length then
                node.Children <- remaining

            Some node

    let update msg model =
        match msg with
        | AddNodeTo parentNodeName ->
            let newNode = leaf ""

            let updated =
                match findNodes (fun n -> n.Name = parentNodeName) model.Nodes |> Seq.tryExactlyOne with
                | Some node ->
                    node.Children <- node.Children @ [ newNode ]
                    model
                | None ->
                    { model with
                        Nodes = model.Nodes @ [ newNode ] }

            updated, Cmd.none

        | RemoveNode node ->
            { model with
                Nodes = model.Nodes |> List.choose(removeNode node) },
            Cmd.none

        | FilterChanged filter -> { model with Filter = filter }, Cmd.none

        | SelectionChanged args ->
            let treeview = args.Source :?> TreeView
            let firstItem = treeview.FindDescendantOfType<TreeViewItem>()
            let nestedTreeViewItem = firstItem.FindDescendantOfType<TreeViewItem>()

            if
                nestedTreeViewItem <> null
                && nestedTreeViewItem <> firstItem // the items are not the same
                && nestedTreeViewItem.Parent = firstItem // one is the parent of the other
                && nestedTreeViewItem.DataContext = firstItem.DataContext // and they share the same node EditableNode as DataContext
            then
                (* Each TreeViewItem nests another! Is binding to the IsExpanded of the nested going to have any effect?
                    This is about WPF, but I think it may explain the same issue: https://stackoverflow.com/a/21123850 *)
                Debugger.Break()

            (*  Uncomment the following manual changes to model.Selected
                if you don't try to track node selection using TreeView.selectedItems(model.Selected) below.
                It tries to reproduce what selectedItems() should do IMO. *)
            (*for node in args.AddedItems |> Seq.cast<EditableNode> do
                node.IsSelected <- true // just to keep that info during debugging
                model.Selected.Add(node)

            for node in args.RemovedItems |> Seq.cast<EditableNode> do
                node.IsSelected <- false // just to keep that info during debugging

                if model.Selected.Remove(node) |> not then
                    Debugger.Break() // just to check whether node removal ever fails*)

            { model with
                JoinedSelection = concat model.Selected },
            Cmd.none

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

    /// Functions for leaf nodes for adding a node to a list.
    module AddLeaf =
        let private prefix = "addTo!"

        /// Appends an Add leaf Node (referencing the parentNode or the model if None) to the Node list.
        let appendTo list (parentNode: EditableNode option) =
            let parentName = parentNode |> Option.map(_.Name) |> Option.defaultValue ""
            list @ [ leaf(prefix + parentName) ]

        /// Identifies an Add leaf Node.
        let is (node: EditableNode) = node.Name.StartsWith(prefix)

        /// Retrieves the parent Node Name from the Node Name of an Add leaf Node.
        let getParentNodeName (node: EditableNode) = node.Name.Substring(prefix.Length)

    let view () =
        Component("EditableTreeView") {
            let! model = Context.Mvu program

            let rec filter (nodes: EditableNode list) =
                nodes
                |> List.filter(fun node ->
                    node.Name.Contains(model.Filter, System.StringComparison.InvariantCultureIgnoreCase)
                    || filter(node.Children) |> List.isEmpty |> not)

            Dock() {
                (*  TODO feeding this builder with a transient source
                    (like you'd want to do for filtering or sorting the input nodes here)
                    will re-render the TreeView on every interaction. Can this be avoided?
                    Is there a more elegant (maybe even declarative) way to preserve tree node expansion?
                    Or is there a better way to filter or sort? *)
                TreeView(
                    AddLeaf.appendTo (model.Nodes |> filter) None,
                    (fun node ->
                        if AddLeaf.is node then
                            null
                        else
                            AddLeaf.appendTo (node.Children |> filter) (Some node)),
                    (fun node ->
                        HStack(5) {
                            if AddLeaf.is node then
                                Button("+", AddNodeTo(AddLeaf.getParentNodeName node))
                                    .tip(ToolTip("Add a node"))
                            else
                                EditableNodeView
                                    .view(node)
                                    .horizontalAlignment(HorizontalAlignment.Left)

                                Button("x", RemoveNode node).tip(ToolTip("Remove"))
                        })
                )
                    .selectionMode(SelectionMode.Multiple)
                    (*  TODO For some reason for nodes on the top level,
                        a second event removing the selection again is triggered immediately after selection.
                        Why is that happening? *)
                    .selectedItems(model.Selected)
                    .onSelectionChanged(SelectionChanged)
                    .dock(Dock.Left)
                    (*  TODO This solution feels awkward because it requires XAML styles,
                        uses a TwoWay Binding against a mutable node model
                        and the name of the EditableNode.IsExpanded property is leaking out of this module.
                        Can either problem be avoided? *)
                    (*  Include styles binding Avalonia.Controls.TreeViewItem.IsExpanded to EditableNode.IsExpanded
                        to preserve tree node expansion on re-render, which is triggered by building the TreeView
                        from a new transient collection returned by the filter method above.

                        See https://github.com/AvaloniaUI/Avalonia/discussions/13903
                        and https://github.com/AvaloniaUI/Avalonia/discussions/12397 *)
                    .styleInclude([ "avares://Gallery/Styles/EditableTreeView.xaml" ])

                (VStack() {
                    HStack() {
                        Label "Filter"
                        TextBox(model.Filter, FilterChanged)
                    }

                    (*  TODO How to update these while or after editing the Selected node in the tree?
                        Updating currently requires triggering SelectionChanged by clicking the node. *)
                    if model.Selected.Count > 0 then
                        TextBlock(concat model.Selected + " selected (items)")
                            .margin(5)

                    if model.JoinedSelection.Length > 0 then
                        TextBlock(model.JoinedSelection + " selected (joined)")
                            .margin(5)

                    if joinedSelection.Length > 0 then
                        TextBlock(joinedSelection + " selected (mutable joined)")
                            .margin(5)
                })
                    .dock(Dock.Right)
            }
        }
