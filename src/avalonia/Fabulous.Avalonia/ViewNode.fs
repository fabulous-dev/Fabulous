namespace Fabulous.Avalonia

open Fabulous

module ViewNode =
    let ViewNodeProperty =
        Avalonia.StyledProperty.RegisterAttached<ViewNode, Avalonia.AvaloniaObject, IViewNode>("ViewNode")

    /// Gets the view node associated with the specified object.
    let get (target: obj) =
        (target :?> Avalonia.AvaloniaObject)
            .GetValue(ViewNodeProperty)

    /// Sets the view node associated with the specified object.
    let set (node: IViewNode) (target: obj) =
        (target :?> Avalonia.AvaloniaObject)
            .SetValue(ViewNodeProperty, node)
        |> ignore
