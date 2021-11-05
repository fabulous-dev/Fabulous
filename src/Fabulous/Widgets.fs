namespace Fabulous

/// Dev notes:
///
/// This file contains all the definitions that for a given key
/// will tell us how to work with a widget or an attribute.
///
/// This is how Fabulous will allow for extensibility. Any framework
/// like Fabulous.Maui, Fabulous.XF can add they're own definitions
/// if they want to do something differently than the base
/// attribute-based widgets

module Widgets =
    [<Struct; RequireQualifiedAccess>]
    type WidgetComparison =
        | Identical

    type WidgetDefinition =
        {
          Key: WidgetKey
          Name: string
          Compare: struct (Widget voption * Widget) -> WidgetComparison
          CreateView: Widget * ViewTreeContext -> IViewNode
        }
        interface IWidgetDefinition with
            member x.CreateView (w, tree) = x.CreateView (w, tree )

    let register<'targetType when 'targetType :> IViewNode> (create: Widget * ViewTreeContext -> 'targetType) =
        let key = WidgetDefinitionStore.getNextKey ()
        let definition =
            { Key = key
              Name = nameof<'targetType>
              Compare = fun _ -> WidgetComparison.Identical
              CreateView =
                fun w ->
                    let target = create w
                    target :> IViewNode }
        WidgetDefinitionStore.set key definition
        key