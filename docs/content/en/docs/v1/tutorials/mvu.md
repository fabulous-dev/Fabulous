---
title : "MVU"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "tutorials"
weight: 101
toc: true
---

Applications built with Fabulous use the MVU design pattern (Model-View-Update, also known from the origin The Elm Architecture). 

Here is the typical structure for the main logic of an app:
```fs
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

type App () as app = 
    inherit Application ()

    let runner = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> XamarinFormsProgram.run app
```

### The model

The model is the core data from which the whole state of the app can be resurrected.  When designing your model,
ask yourself  "what is the information I would need on restart to get the app back to the same essential state". The model is generally immutable but may also contain elements such as service connections.
It is common for the desgin of the model to grow "organically" as you prototype your app.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

The init function returns your initial model.  The update function updates the model as messages are received.

### The view function

The view function computes an immutable Xaml-like description.

### The update function

Each model gets an `update` function for message processing. The messages are either messages from the `view` or from external events.
If using `Program.mkProgram` your `update` function may also return new commands to trigger as a result of processing a message. (A command is simply a function that may dispatch one or more messages at some point, and is called by the Fabulous runtime.)

Further Resources
--------
[Fabulous: Functional App Development](https://devblogs.microsoft.com/xamarin/fabulous-functional-app-development/) 