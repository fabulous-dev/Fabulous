
Fabulous for Xamarin.Forms - Guide
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
So using our favorite unit test framework (here we use [FsUnit](https://fsprojects.github.io/FsUnit/) for this example), we can write a test that will check if the value returned by `init` is the one we expect.

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

### Testing `init` and `update` when using commands

Testing `Cmd<'msg>` can be hard, because there's no way of knowing what the functions inside `Cmd` really are before executing them.

The recommended way is to apply the `CmdMsg` pattern.  
See [Replacing commands with command messages for better testability](https://fsprojects.github.io/Fabulous/update.html#replacing-commands-with-command-messages-for-better-testability)

### Testing view

Views in Fabulous are testable as well, which makes it a clear advantage over more classic OOP frameworks (like C#/MVVM).  
The `view` function returns a `ViewElement` value (which is a dictionary of attribute-value pairs). So we can check against that dictionary if we find the property we want, with the value we want.

Unfortunately when creating a control through `View.XXX`, we lose the control's type and access to its properties. Fabulous creates a `ViewElement` which encapsulates all those data.  

In order to test in a safe way, Fabulous provides type-safe helpers for every controls from `Xamarin.Forms.Core`.  
You can find them in the `Fabulous.XamarinForms` namespace. They are each named after the control they represent.

Example: `StackLayoutViewer` will let you access the properties of a `StackLayout`.  

The Viewer only takes a `ViewElement` as a parameter.  
(If you pass a `ViewElement` that represents a different control than the Viewer expects, the Viewer will throw an exception)

Let's take this code for example:
```fsharp
let view (model: Model) dispatch =  
    View.ContentPage(
        content=View.StackLayout(
            automationId="stackLayoutId"
            children=[ 
                View.Label(automationId="CountLabel", text=sprintf "%d" model.Count)
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

#### Viewer API
The following approach uses the Viewer API. This is a way but with this you have to know exactly at which position the child you need is. 

```fsharp
[<Test>]
let ``View should generate a label showing the count number of the model``() =
    let model = { Count = 5; Step = 4; TimerOn = true }
    let actualView = App.view model ignore
    
    let contentPage = ContentPageViewer(actualView)
    let stackLayout = StackLayoutViewer(contentPage.Content)
    let countLabel = LabelViewer(stackLayout.Children.[0])
    
    countLabel.Text |> should equal "5"
```

#### FindViewElement / TryFindViewElement
With `findViewElement` and `tryFindViewElement` you don't need to know where exactly the child is positioned. You have to set `automationId` on the ViewElements which will be used by those functions to find the element in the tree. 
This approach is the recommended way for testing and to get the ViewElements in a View.

##### findViewElement
```fsharp
[<Test>]
let ``View should generate a label showing the count number of the model``() =
    let model = { Count = 5; Step = 4; TimerOn = true }
    let actualView = App.view model ignore
    
    let countLabel = findViewElement "CountLabel" actualView |> LabelViewer
    
    countLabel.Text |> should equal "5"
```

##### tryFindViewElement
`tryFindViewElement` delivers a quickaccess to a ViewElement as findViewElement but here you get an Option Type. With this you can also check for the existence of a ViewElement. 

```fsharp
[<Test>]
let ``When user is authenticated, View should not include a connection button``() =
    let model = { Count = 5; Step = 4; TimerOn = true }
    let actualView = App.view model ignore
    
    tryFindViewElement "ConnectionButton" actualView |> should equal None
``` 

### Testing if a control dispatches the correct message

If you want to test your event handlers, you can retrieve them in the same way than a regular property.  
Then, you can execute the event handler like a normal function and check its result through a mocked dispatch.

```fsharp
[<Test>]
let ``Clicking the button Increment should send the message Increment``() =
    let mockedDispatch msg =
        msg |> should equal Increment

    let model = { Count = 5; Step = 4; TimerOn = true }
    let actualView = App.view model mockedDispatch

    let contentPage = ContentPageViewer(actualView)
    let stackLayout = StackLayoutViewer(contentPage.Content)
    let incrementButton = ButtonViewer(stackLayout.Children.[1])

    incrementButton.Command ()
```


### See also
- [CounterApp.Tests sample](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/samples/CounterApp/CounterApp.Tests/Tests.fs)
