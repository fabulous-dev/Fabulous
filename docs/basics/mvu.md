---
description: Model-View-Update
---

# MVU

Applications built with Fabulous use the MVU design pattern (Model-View-Update, also known from the origin The Elm Architecture).

Here is the typical structure for the main logic of an app:

```fsharp
type Msg =
    | ...

/// The MODEL from which the view is generated
type Model = 
    { ... }

/// Returns the initial state
let init() = { ... }
    
/// The funtion to UPDATE the view
let update (msg:Msg) (model:Model) = ...

/// The VIEW function giving updated content for the page
let view (model: Model) dispatch = ...

module App =
    let runner =
        Program.stateful init update view
        |> Program.withConsoleTrace
```

### The model&#x20;

The model is the core data from which the whole state of the app can be resurrected. When designing your model, ask yourself “what is the information I would need on restart to get the app back to the same essential state”. The model is generally immutable but may also contain elements such as service connections. It is common for the desgin of the model to grow “organically” as you prototype your app.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

The init function returns your initial model. The update function updates the model as messages are received.

### The view function&#x20;

The view function computes an immutable Xaml-like description.

### The update function&#x20;

Each model gets an `update` function for message processing. The messages are either messages from the `view` or from external events. If using `Program.mkProgram` your `update` function may also return new commands to trigger as a result of processing a message. (A command is simply a function that may dispatch one or more messages at some point, and is called by the Fabulous runtime.)
