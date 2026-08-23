---
description: >-
  Learn how to use Cmd.map and Cmd.batch to compose Cmds from independent MVU
  states
---

# Integrating commands

In [Splitting into independent MVU states](splitting-into-independent-mvu-states.md), we learned how to decompose larger apps into individual MVU states by using simple init and update functions returning only a Model, like in those signatures:

```fsharp
val init: unit -> Model
val update: Msg -> Model -> Model
```

Though most apps will need more complex signatures to handle side effects such as processing data, network calls, access to the camera or storage, etc. Those apps will use commands to model those side-effects:

```fsharp
val init: unit -> Model * Cmd<Msg>
val update: Msg -> Model -> Model * Cmd<Msg>
```

If we simply do the same than in the previous section, we will face the same compilation issue we saw by composing views with different Msg types.

```fsharp
let update msg model =
    match msg with
    | Form1Msg f1 ->
        let m, c = Form1.update f1 model.Form1Model
        { model with Form1Model = m }, c
        
    | Form1Msg f2 ->
        let m, c = Form2.update f2 model.Form2Model
        { model with Form2Model = m }, c // ERROR: Expected Cmd<Form1.Msg>, got Cmd<Form2.Msg>
```

We solved that issue with View.map previously. Since the issue is similar, the solution is also similar.

### Converting a command's Msg type

Just like View.map to convert a widget's Msg type to the parent's Msg type  to allow for composition, Fabulous has Cmd.map to do the same for commands.

```fsharp
val Cmd.map : ('oldMsg -> 'newMsg) -> Cmd<'oldMsg> -> Cmd<'newMsg>
```

Using Cmd.map is very similar to View.map.

```fsharp
Cmd.map Form1Msg form1Cmd
```

{% code title="App.fs" %}
```fsharp
type Msg =
    | Form1Msg of Form1.Msg
    | Form2Msg of Form2.Msg

let init () =
    let m, c = Form1.init()
    { Form1Model = m }, Cmd.map Form1Msg c
    
let update msg model =
    match msg with
    | Form1Msg f1 ->
        let m, c = Form1.update f1 model.Form1Model
        { model with Form1Model = m }, Cmd.map Form1Msg c
        
    | Form2Msg f2 ->
        let m, c = Form1.update f2 model.Form2Model
        { model with Form2Model = m }, Cmd.map Form2Msg c
```
{% endcode %}

### Batching several Cmds together

Sometimes, an app needs to execute several side effects at the same time. To enable that, Fabulous provides a Cmd.batch function to merge several commands into a single one.

```fsharp
val Cmd.batch : Cmd<'msg> list -> Cmd<'msg>
```

We can combine Cmd.batch with Cmd.map as we want.

```fsharp
let init () =
    let m1, c1 = Counter.init()
    let m2, c2 = Input.init()
    { CounterModel = m1
      InputModel = m2 },
    Cmd.batch [
        Cmd.ofAsyncMsg(loadDataAsync())
        Cmd.map CounterMsg c1
        Cmd.map InputMsg c2
    ]
```

To learn more about integrating commands, read [The Elmish Book - Integrating Commands](https://zaid-ajaj.github.io/the-elmish-book/#/chapters/scaling/integrating-commands).
