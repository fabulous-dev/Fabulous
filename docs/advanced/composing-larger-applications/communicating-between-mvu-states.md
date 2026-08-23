---
description: >-
  Learn how to use the Intent pattern to communicate between independent MVU
  states
---

# Communicating between MVU states

Like we saw in the previous sections, most MVU apps adopt the following signatures to model how their state changes and the side effects to be executed:

```fsharp
val init : unit -> Model * Cmd<Msg>
val update : Msg -> Model -> Model * Cmd<Msg>
```

MVU programs are meant to be well isolated from the outside world to be reliable and predictable, producing only pure init and update functions. But how does a program communicate with other programs when something goes out of its scope such as navigating to another page?

### Communicating from child to parent

While technically the parent could peek into the child's Model to eventually react to a specific state and do additional work (see [Splitting into independent MVU states](splitting-into-independent-mvu-states.md)). This approach is pretty bad because it depends greatly on the internal implementation of the child which can change at any time.

Since we know the parent will always call the child's init and update functions, we can take advantage of this by returning a new value specifically for the parent.

Comes in the Intent pattern:

```fsharp
val init: unit -> Model * Cmd<Msg> * Intent option
val update: Msg -> Model -> Model * Cmd<Msg> * Intent option
```

As you can see, we are returning one more value after executing init and update: Intent option.

The Intent is a discriminated union created by you just like Msg. Its goal is to notify the caller of extra intention that needs to be taken care of outside the child.

Let's take the example of an app going through several pages of forms that the user needs to fill in.

The App module will take care of the whole workflow between the pages, but each individual page has its own MVU state. By returning an intent, the page can notify the app to do cross-page actions.

{% code title="Form1.fs" %}
```fsharp
type Msg =
    | TextChanged of string
    | Complete

type Intent =
    | SaveDraft of string
    | GoToNextStep
    
let init () =
    { ... }, Cmd.none, None
    
let update msg model =
    match msg with
    | TextChanged newValue -> { model with Text = newValue }, Cmd.none, Some (SaveDraft draft)
    | Complete -> model, Cmd.none, Some GoToNextStep
```
{% endcode %}

{% code title="App.fs" %}
```fsharp
type Msg =
    | NextStep
    | ...
            
let saveDraftOnDisk draft =
    Cmd.ofAsyncMsg(async { ... })

let update msg model =
    match msg with
    | Form1Msg f1 ->
        let m, c, i = Form1.update f1 model.Form1Model
        let intentCmd =
            match i with
            | Some Form1.Intent.SaveDraft draft -> saveDraftOnDisk draft
            | Some Form1.Intent.GoToNextStep -> Cmd.ofMsg NextStep
            | _ -> Cmd.none
            
        { model with Form1Model = m },
        Cmd.batch [
            intentCmd
            Cmd.map Form1Msg c
        ]
```
{% endcode %}

### Communicating between siblings

Just like parent-child communication, communicating between siblings involves using an intent. Except the intent this time tells the parent to forward a message to the child's sibling.

{% code title="Form1.fs" %}
```fsharp
type Intent =
    | SelectNextField

let update msg model =
    match msg with
    | FocusNextForm -> model, Cmd.none, Some SelectNextField
```
{% endcode %}

{% code title="Form2.fs" %}
```fsharp
let update msg model =
    match msg with
    | FocusFirstField -> { model with ... }, Cmd.none, None
```
{% endcode %}

{% code title="App.fs" %}
```fsharp
let update msg model =
    match msg with
    | Form1Msg f1 ->
        let m, c, i = Form1.update f1 model.Form1Model
        let intentCmd =
            match i with
            | Some Form1.Intent.SelectNextField -> Cmd.ofMsg (Form2Msg Form2.Msg.FocusFirstField)
            | _ -> Cmd.none
        { model with Form1Model = m },
        Cmd.batch [
            intentCmd
            Cmd.map Form1Msg c
        ]
        
    | Form2Msg f2 ->
        let m, c, i = Form2.update f2 model.Form2Model
        let intentCmd =
            match i with
            | _ -> Cmd.none
        { model with Form2Model = m },
        Cmd.map Form2Msg c
```
{% endcode %}

To learn more about the Intent pattern, please read [The Elmish Book - The Intent Pattern](https://zaid-ajaj.github.io/the-elmish-book/#/chapters/scaling/intent).
