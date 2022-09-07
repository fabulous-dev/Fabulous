---
id: "v2-editor"
title: "Editor"
description: ""
lead: ""
date: 2022-06-02T00:00:00+00:00
lastmod: 2022-06-02T00:00:00+00:00
draft: false
images: []
weight: 425
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}}) -> [InputView]({{< ref "input-view.md" >}})  
**Xamarin.Forms documentation:** Editor [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.editor) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/editor)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/editor).

## Constructors

| Constructors | Description |
|--|--|
| Editor(text: string, onTextChanged: string -> 'msg) | Defines a Editor widget with a text and onTextChanged event. |

## Properties

| Properties | Description |
|--|--|
| autoSize(value: EditorAutoSizeOption) | Sets a value that controls whether the editor will change size to accommodate input as the user enters it. |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| isTextPredictionEnabled(value: bool) | Sets whether the text prediction is enabled. |
| reference(value: ViewRef&lt;Editor&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Editor` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onCompleted(onCompleted: 'msg) | Sets the event handler for the entry onCompleted event |

## Usages

```fs
Editor("Enter a description", TextChanged)
    .keyboard(Keyboard.Email)
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
    .onCompleted(TextCompleted)
```

### Get access to the underlying Xamarin.Forms.Editor

```fs
let editorRef = ViewRef<Editor>()

Editor("Enter a description", TexChanged)
    .reference(editorRef)
```
