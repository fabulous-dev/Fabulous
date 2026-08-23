# AnyView

**AnyView** allows changing the type of view used in a given view hierarchy. Whenever the type of view used with an AnyView changes.

### Constructors&#x20;

<table><thead><tr><th width="324">Constructors</th><th>Description</th></tr></thead><tbody><tr><td>AnyView&#x3C;‘msg, ‘marker when ‘marker :> IView>(widget: WidgetBuilder&#x3C;‘msg, ‘marker>)</td><td>Downcast to IView to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.)</td></tr></tbody></table>
