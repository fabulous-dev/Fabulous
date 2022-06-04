---
id: "v2-entry"
title: "Entry"
description: ""
lead: ""
date: 2022-06-02T00:00:00+00:00
lastmod: 2022-06-02T00:00:00+00:00
draft: false
images: []
menu:
docs:
parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}}) -> [InputView]({{< ref "input-view.md" >}})  
**Xamarin.Forms documentation:** Entry [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.entry) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/entry)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/entry).

## Constructors

| Constructors | Description |
|--|--|
| Entry(text: string, onTextChanged: string -> 'msg) | Defines a Entry widget with a text and onTextChanged event. |

## Properties

| Properties | Description |
|--|--|
| clearButtonVisibility(value: ClearButtonVisibility) | Sets the clear button visibility. i.e. Never, WhileEditing. |
| cursorPosition(value: int) | Sets the cursor position. |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| horizontalTextAlignment(value: TextAlignment) | Sets the horizontal text alignment. |
| verticalTextAlignment(value: TextAlignment) | Sets the vertical text alignment. |
| isPassword(value: bool) | Sets whether the entry is a password. |
| isTextPredictionEnabled(value: bool) | Sets whether the text prediction is enabled. |
| returnType(value: ReturnType) | Sets the return type. i.e. Done, Go, Next, Search, Send.  |
| selectionLength(value: int) | Sets the text selection length. |
| reference(value: ViewRef&lt;Entry&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Entry` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onCompleted(onCompleted: 'msg) | Sets the event handler for the entry onCompleted event |

## iOS-specific Properties

| Properties | Description |
|--|--|
| cursorColor(value: FabColor) | Sets the cursor color. |

## Usages

```fs
Entry("Enter an email", TextChanged)
    .keyboard(Keyboard.Email)
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
    .onCompleted(TextCompleted)
```

### Get access to the underlying Xamarin.Forms.Entry

```fs
let entryRef = ViewRef<Entry>()

Entry("Enter an email", TexChanged)
    .reference(entryRef)
```
