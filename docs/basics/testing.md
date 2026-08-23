# Testing

The Model-View-Update architecture used by Fabulous makes it simple to unit test every part of your application.\
Apps are composed of 3 key pure F# functions: `init`, `update` and `view`\
They take some parameters and return a value. Ideal for unit testing.

### Testing `init`&#x20;

`init` is the easiest one to test.\
It usually takes nothing and returns a value.

Let’s take this code for example:

```fsharp
type Model =
    { Count: int
      Step: int }

let init () =
    { Count = 0; Step = 1 }
```

Here we can make sure that the default state stays exact throughout the life of the project.\
So using our favorite unit test framework (here we use [FsUnit](https://fabulous-dev.github.io/FsUnit/) for this example), we can write a test that will check if the value returned by `init` is the one we expect.

```fsharp
[<Test>]
let ``Init should return a valid initial state``() =
    App.init () |> should equal { Count = 0; Step = 1 }
```

### Testing `update`&#x20;

`update` can be more complex but it remains a pure F# function.\
Testing it is equivalent to what we just did with `init`.

Let’s take this code for example:

```fsharp
type Model =
    { Count: int
      Step: int }

type Msg =
    | Increment
    | Decrement
    | Reset 

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + model.Step }
    | Decrement -> { model with Count = model.Count - model.Step }
    | Reset -> { model with Count = 0; Step = 1 }
```

We can write the following tests:

```fsharp
[<Test>]
let ``Given the message Increment, Update should increment Count by Step``() =
    let initialModel = { Count = 5; Step = 4 }
    let expectedModel = { Count = 9; Step = 4 }
    App.update Increment initialModel |> should equal expectedModel

[<Test>]
let ``Given the message Decrement, Update should decrement Count by Step``() =
    let initialModel = { Count = 5; Step = 4 }
    let expectedModel = { Count = 1; Step = 4 }
    App.update Decrement initialModel |> should equal expectedModel

[<Test>]
let ``Given the message Reset, Update should reset the state``() =
    let initialModel = { Count = 5; Step = 4 }
    let expectedModel = { Count = 0; Step = 1 }
    App.update Reset initialModel |> should equal expectedModel
```

### Testing `init` and `update` when using commands&#x20;

Commands are a great way for executing a set of tasks (asynchronous or not) after receiving a message.

But behind the scenes, `Cmd<'msg>` is really only an array of functions. This makes testing `Cmd<'msg>` really difficult (no way to know what the functions are) and the functions `init` and `update` as well.

In the case you want to unit test your code, even if you’re using `Cmd<'msg>` inside `init`and `update`, the best way is to use of the `CmdMsg` pattern.

This is a general pattern, applicable when using an Elm-like programming model.\
It is not linked to Fabulous specifically.

Fabulous only provides some helpers to help you achieve this with less code.

The principle is to replace any direct usage of `Cmd<'msg>` from `init` and `update`, and instead use a discriminated union called `CmdMsg`.

```fsharp
type Model = 
    { TimerOn: bool
      Count: int
      Step: int }
        
type Msg = 
    | TimedTick
    | TimerToggled of bool

type CmdMsg =
    | TimerTick

let init () =
    { TimerOn = false; Count = 0; Step = 1 }, [] // An empty list means no action
    
let update msg model =
    match msg with
    | TimerToggled on ->
       { model with TimerOn = on }, [ if on then yield TimerTick ]
    | TimedTick ->
       if model.TimerOn then
          { model with Count = model.Count + model.Step }, [ TimerTick ]
       else
          model, []
```

Doing this transforms the output of both `init` and `update` to pure data output, which can then be easily unit tested

```fsharp
[<Test>]
let togglingOnShouldTriggerTimerTick () =
    let initialModel = { TimerOn = false; Count = 0; Step = 1 }
    let expectedReturn = { TimerOn = true; Count = 0; Step = 1 }, [ TimerTick ]
    App.update (TimerToggled true) initialModel |> should equal expectedReturn
```

The actual commands are still executed as `Cmd<'msg>` though.\
So in order to make this work with Fabulous, you need a function that will convert a `CmdMsg` to a `Cmd<'msg>`

Fabulous then helps you boot your application using `Program.mkProgramWithCmdMsg`

```fsharp
let mapCommands cmdMsg =
    match cmdMsg with
    | TimerTick -> timerCmd()

type App() as app =
    inherit Application()

    let runner =
        Program.mkProgramWithCmdMsg init update view mapCommands
        |> XamarinFormsProgram.run app
```

Note that `Program.mkProgramWithCmdMsg` doesn’t do anything magic.\
It only applies `mapCommands` to any `CmdMsg` returned by `init` and `update`.\
You could achieve the exact same behavior by converting them yourself and using `Program.mkProgram`.\
\
