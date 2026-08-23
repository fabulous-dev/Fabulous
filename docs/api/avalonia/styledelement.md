# StyledElement

**Inheritance:** [Animatable](animatable.md)\
AvaloniaUI **documentation:** StyledElement [API](https://reference.avaloniaui.net/api/Avalonia/StyledElement/)

### Properties&#x20;

<table><thead><tr><th width="324">Properties</th><th>Description</th></tr></thead><tbody><tr><td>name(value: string)</td><td>Sets the Name property.</td></tr><tr><td>classes(value: string list)</td><td>Sets the Classes property.</td></tr><tr><td>classes(value: string)</td><td>Sets the Classes property.</td></tr><tr><td>style(fn: WidgetBuilder&#x3C;'msg, #IFabAvaloniaObject> -> WidgetBuilder&#x3C;'msg, #IFabAvaloniaObject>)</td><td>Sets the Style property.</td></tr><tr><td>contentType(value:TextInputContentType)</td><td>Sets the ContentType property.</td></tr><tr><td>returnKeyType(value: TextInputReturnKeyType)</td><td>Sets the ReturnKeyType property.</td></tr><tr><td>multiline(value: bool)</td><td>Sets the Multiline property.</td></tr><tr><td>lowercase(value: bool)</td><td>Sets the Lowercase property.</td></tr><tr><td>uppercase(value: bool)</td><td>Sets the Uppercase property.</td></tr><tr><td>autoCapitalization(value: bool)</td><td>Sets the AutoCapitalization property.</td></tr><tr><td>isSensitive(value: bool)</td><td>Sets the IsSensitive property.</td></tr><tr><td>styles(value: string list)</td><td>Sets the application styles</td></tr><tr><td>themeKey(value: string)</td><td>Sets the ThemeKey property. The ThemeKey is used to lookup the ControlTheme from the application styles that is applied to the control.</td></tr><tr><td></td><td></td></tr></tbody></table>

### Events&#x20;

| Properties                                                            | Description                                                            |
| --------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| onAttachedToLogicalTree(fn: LogicalTreeAttachmentEventArgs -> 'msg)   | Raised when the styled element is attached to a rooted logical tree.   |
| onDetachedFromLogicalTree(fn: LogicalTreeAttachmentEventArgs -> 'msg) | Raised when the styled element is detached from a rooted logical tree. |
| onActualThemeVariantChanged(msg: 'msg)                                | Raised when the actual theme variant changes.                          |

### Usages

<pre class="language-fsharp"><code class="lang-fsharp"><strong>let textBlockStyle (this: WidgetBuilder&#x3C;'msg, IFabTextBlock>) =
</strong>    this
        .verticalAlignment(VerticalAlignment.Center)
        .foreground(SolidColorBrush(Colors.Black))
            
TextBlock("Hello Wrold")
    .style(textBlockStyle)
</code></pre>
