---
title : "Views"
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

The `view` function is a function returning your view elements based on the current model. For example:

```fs
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

```fs
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
    View.ContentPage(
        title="Pocket Piggy Bank",
        content=View.StackLayout(padding= Thickness 20.0,
            horizontalOptions=LayoutOptions.Center,
            verticalOptions=LayoutOptions.CenterAndExpand,
            children = [
                match model.User with
                | Some user ->
                    yield View.Label(text=sprintf "Logged in as : %s" user)
                    yield View.Label(text=sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
                    yield View.Button(text="Withdraw", command=(fun () -> dispatch (Spend 10.0m)), commandCanExecute=(model.Balance > 0.0m))
                    yield View.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0m)))
                    yield View.Button(text="Logout", command=(fun () -> dispatch (Login None)))
                | None ->
                    yield View.Button(text="Login", command=(fun () -> dispatch (Login (Some "user"))))
            ]))
```

The four main control groups used to create the user interface of a Xamarin.Forms application are:

* [Pages](view-pages.html)
* [Layouts](view-layouts.html)
* [Interface objects](view-interface-objects.html)
* [Cells](view-cells.html)

See also:

* [Views and Performance](view-a-performance.html)
* [Styling](view-a-styling.html)
