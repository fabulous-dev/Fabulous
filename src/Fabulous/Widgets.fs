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
    type WidgetDefinition =
        { Key: WidgetKey
          Name: string
          CreateView: Widget * ViewTreeContext -> obj }

        interface IWidgetDefinition with
            member x.CreateView (w, tree) = x.CreateView (w, tree)