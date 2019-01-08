Fabulous - Guide
=======

{% include_relative contents.md %}

Testing
------

The Model-View-Update architecture used by Fabulous makes it simple to unit test every part of your application.  
Apps are composed of 3 key pure F# functions: `init`, `update` and `view`  
They take some parameters and return a value. Ideal for unit testing.

### Testing `init`

`init` is the easiest one to test.  
It usually takes nothing and returns a value.

Let's take this code for example:

```fsharp
type Model =
    { Count: int
      Step: int }

let init () =
    { Count = 0; Step = 1 }
```

Here we can make sure that the default state stays exact throughout the life of the project.  
So using our favorite unit test framework (here we use [FsUnit](https://fsprojects.github.io/FsUnit/) for this example), we can write a simple test that will check if the value returned by `init` is the one we expect.

```fsharp
[<Test>]
let ``Init should return a valid initial state``() =
    App.init () |> should equal { Count = 0; Step = 1 }
```

### Testing `update`

`update` can be more complex but it remains a pure F# function.  
Testing it is equivalent to what we just did with `init`.

Let's take this code for example:

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

### Testing `init` and `update` when using `Cmd`

You might have noticed the previous examples weren't using `Cmd`.  
This is because `Cmd` can be complex to unit test and needs some further documentation on its own.

#### Testing `Cmd.none`

`Cmd.none` is an exception. It doesn't require anything special.  
We can just compare it to itself

```fsharp
let update msg model =
    match msg with
    | Increment -> { model with model.Count + 1 }, Cmd.none


[<Test>]
let ``Given the message Increment, Update should increment Count by 1``() =
    let initialModel = { Count = 5 }
    let expectedState = { Count = 6 }, Cmd.none // The expected state is a tuple of the model and a Cmd
    App.update Increment initialModel |> should equal expectedState
```

#### Testing `Cmd`s that always returns a value (`Cmd.ofMsg`, `Cmd.ofAsyncMsg`, etc.)

`Cmd` is highly asynchronous by nature.  
When creating a `Cmd`, we're really creating functions that will be called later by Fabulous (in its main update loop).  
So testing if our `Cmd`s do return the correct message(s), we need something to execute the `Cmd` and give us the generated message(s).

For this purpose, the module `Fabulous.Core.Cmd.Testing` contains an helper function:
- `execute: (cmd: Cmd<'msg>) -> 'msg list`

`execute` will give you every messages it got from the executed `Cmd`.

```fsharp
let update msg model =
    match msg with
    | LoadData data -> { model with Data = Some data }, Cmd.ofMsg Loaded

[<Test>]
let ``Given the message LoadData, Update should store the data and send a new message Loaded``() =
    let initialModel = { model with Data = None }
    let expectedModel = { model with Data = Some { Data = true } }
    let expectedCmdMessages = [ Msg.Loaded ]

    let actualModel, actualCmd = App.update (LoadData { Data = true }) initialModel

    let actualCmdMessages = Cmd.Testing.execute actualCmd

    actualModel |> should equal expectedModel
    actualCmdMessages |> should equal expectedCmdMessages
```

#### Testing `Cmd`s that might not return a value (`Cmd.ofMsgOption`, `Cmd.ofAsyncMsgOption`, etc.)

TBD

### Testing view

Views in Fabulous are testable as well, which makes it a clear advantage over more classic OOP frameworks (like C#/MVVM).  
The `view` function returns a `ViewElement` value (which is a glorified dictionary of attribute-value pairs). So we can check against that dictionary if we find the property we want, with the value we want.

Unfortunately when creating a control through `View.XXX`, we lose the control's type and access to its properties. Fabulous creates a `ViewElement` which encapsulates all those data.  

In order to allow testing in a safe way, Fabulous provides type-safe helpers for every controls from `Xamarin.Forms.Core`.  
You can find them in the `Fabulous.DynamicViews` namespace. They are each named after the control they represent.

Example: `StackLayoutViewer` will let you access the properties of a `StackLayout`.  

The Viewer only takes a `ViewElement` as a parameter.  
(If you pass a `ViewElement` that represents a different control than the Viewer expects, the Viewer will throw an exception)

Let's take this code for example:
```fsharp
let view (model: Model) dispatch =  
    View.ContentPage(
        content=View.StackLayout(
            children=[ 
                View.Label(text=sprintf "%d" model.Count)
                View.Button(text="Increment", command=(fun () -> dispatch Increment))
                View.Button(text="Decrement", command=(fun () -> dispatch Decrement)) 
                View.StackLayout(
                    orientation=StackOrientation.Horizontal, 
                    children=[
                        View.Label(text="Timer")
                        View.Switch(isToggled=model.TimerOn, toggled=(fun on -> dispatch (TimerToggled on.Value)))
                    ])
                View.Slider(minimumMaximum=(0.0, 10.0), value=double model.Step, valueChanged=(fun args -> dispatch (SetStep (int args.NewValue))))
                View.Label(text=sprintf "Step size: %d" model.Step)
            ]))   
```

We want to make sure that if the state changes, the view will update accordingly.

The first step is to call `view` with a given state and retrieve the generated `ViewElement`.  
`view` is expecting a `dispatch` function as well. In our case, we don't need to test the dispatching of messages, so we pass the function `ignore` instead.

From there, we create the Viewers to help us read the properties of the controls we want to check.

And finally, we assert that the properties have the expected values.

```fsharp
[<Test>]
let ``View should generate a valid interface``() =
    let model = { Count = 5; Step = 4; TimerOn = true }
    let actualView = App.view model ignore

    let contentPage = ContentPageViewer(actualView)
    let stackLayout = StackLayoutViewer(contentPage.Content)
    let countLabel = LabelViewer(stackLayout.Children.[0])
    let timerSwitch = SwitchViewer(StackLayoutViewer(stackLayout.Children.[3]).Children.[1])
    let stepSlider = SliderViewer(stackLayout.Children.[4])
    let stepSizeLabel = LabelViewer(stackLayout.Children.[5])

    countLabel.Text |> should equal "5"
    timerSwitch.IsToggled |> should equal true
    stepSlider.Value |> should equal 4.0
    stepSizeLabel.Text |> should equal "Step size: 4"
```

### Testing if a control dispatches the correct message

TBD


### See also
- [CounterApp.Tests sample](https://github.com/fsprojects/Fabulous/tree/master/samples/CounterApp/CounterApp.Tests)