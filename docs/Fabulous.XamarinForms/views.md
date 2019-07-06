Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Views
------

The `view` function is a function returning your view elements based on the current model. For example:

```fsharp
let view model dispatch =
    View.ContentPage(
        title="Pocket Piggy Bank",
        content=View.Label(text = sprintf "Hello world!")
    )
```

The view function is normal F# code that returns elements created using the `View.*` method calls.

View functions are particularly useful when the existence, characteristics and layout of the view depends on information
in the model. Differential update is used to efficiently update the Xamarin.Forms display based on the previous
and current view descriptions.

Here is a larger example:

```fsharp
type Model =
    { Balance : decimal
      CurrencySymbol : string
      User: string option }

type Msg =
    | Spend of decimal
    | Add of decimal
    | Login of string option

let update msg model =
    match msg with
    | Spend x -> { model with Balance = model.Balance - x }, Cmd.none
    | Add x -> { model with Balance = model.Balance + x }, Cmd.none
    | Login user -> { model with User = user }, Cmd.none

let view model dispatch =
    View.ContentPage(
        title="Pocket Piggy Bank",
        content=View.StackLayout(padding=20.0,
            horizontalOptions=LayoutOptions.Center,
            verticalOptions=LayoutOptions.CenterAndExpand,
            children = [
                match model.User with
                | Some user ->
                    yield View.Label(text=sprintf "Logged in as : %s" user)
                    yield View.Label(text=sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
                    yield View.Button(text="Withdraw", command=(fun () -> dispatch (Spend 10.0m)), canExecute=(model.Balance > 0.0m))
                    yield View.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0m)))
                    yield View.Button(text="Logout", command=(fun () -> dispatch (Login None)))
                | None ->
                    yield View.Button(text="Login", command=(fun () -> dispatch (Login (Some "user"))))
            ]))
```

See also:

* [Core Elements](views-elements.md).
* [Views and Performance](views-perf.md).
* [Styling](views-styling.md).
* [Multi-page Applications and Navigation](views-navigation.md).
