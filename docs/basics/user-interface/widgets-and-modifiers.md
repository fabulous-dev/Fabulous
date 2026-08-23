---
description: The building blocks of a declarative UI
---

# Widgets and modifiers

The `view` function is a function returning your view elements based on the current model.

Here is an example using Fabulous for .NET MAUI:

```fsharp
open Fabulous.Maui
open type Fabulous.Maui.View

let view model =
    ContentPage(
        "Pocket Piggy Bank",
        Label("Hello world!")
    )
```

The view function is normal F# code that returns elements created using the `View.*`method calls.

View functions are particularly useful when the existence, characteristics and layout of the view depends on information in the model. Differential update is used to efficiently update the Xamarin.Forms display based on the previous and current view descriptions.

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

let init() = 
    { Balance = 2m
      CurrencySymbol = "$"
      User = Some "user"
    }, Cmd.none

let update msg model =
    match msg with
    | Spend x -> { model with Balance = model.Balance - x }, Cmd.none
    | Add x -> { model with Balance = model.Balance + x }, Cmd.none
    | Login user -> { model with User = user }, Cmd.none

let view model dispatch =
    ContentPage(
        "Pocket Piggy Bank",
        (VStack() {
            match model.User with
            | None ->
                Button("Login", Login (Some "user"))
                
            | Some user ->
                Label($"Logged in as : {user}")
                Label($"Balance: {model.CurrencySymbol}%.2f{model.Balance}")
                Button("Withdraw", Spend 10.m)
                Button("Deposit", Add 10.m)
                Button("Logout", Login None)
        })
            .padding(20.)
            .center()
    )
```
