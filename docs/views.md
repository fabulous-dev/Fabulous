{% include_relative contents.md %}

Views
=======

The `view` function is a function returning your view elements based on the current model. For example:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title = "Pocket Piggy Bank",
        content= Xaml.Label(text = sprintf "Hello world!")
    )
```

The view function is normal F# code that returns elements expressed using the `Xaml.*` F# DSL.

View functions excel in cases where the existence, characteristics and layout of the view depends on information
in the model. Differential update is used to efficiently update the Xamarin.Forms display based on the previous
and current view descriptions.

Here is a larger example:
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
    | Spend x -> {model with Balance = model.Balance - x}, Cmd.none
    | Add x -> {model with Balance = model.Balance + x}, Cmd.none
    | Login user -> { model with User = user }, Cmd.none

let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content=Xaml.StackLayout(padding=20.0,
            horizontalOptions=LayoutOptions.Center,
            verticalOptions=LayoutOptions.CenterAndExpand,
            children = [
                match model.User with
                | Some user ->
                    yield Xaml.Label(text=sprintf "Logged in as : %s" user)
                    yield Xaml.Label(text=sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
                    yield Xaml.Button(text="Withdraw", command=(fun () -> dispatch (Spend 10.0m)), canExecute=(model.Balance > 0.0m))
                    yield Xaml.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0m)))
                    yield Xaml.Button(text="Logout", command=(fun () -> dispatch (Login None)))
                | None ->
                    yield Xaml.Button(text="Login", command=(fun () -> dispatch (Login (Some "user"))))
            ]))
```


See also: 
* [Catalog of Core Elements](elements.md).
* [Views and Performance](views-perf.md).
* [Views and Styling](styling.md).
* [Views and Navigation](navigation.md).



### Views: Other Controls

All other controls from `Xamarin.Forms.Core` are available in the programming model.  See the `AllControls` sample.

See also
* [`Xamarin.Forms` API docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms).


### Views: Resource Dictionaries

In Xamarin.Forms documentation you may see references to resource dictionaries.
In Elmish.XamarinForms, resources dictionaries are replaced by "simple F# programming", e.g.
```fsharp
let horzOptions = LayoutOptions.Center
let vertOptions = LayoutOptions.CenterAndExpand
```
is basically the eqivalent of Xaml:
```xml
<ContentPage.Resources>
    <ResourceDictionary>
        <LayoutOptions x:Key="horzOptions"
                     Alignment="Center" />

        <LayoutOptions x:Key="vertOptions"
                     Alignment="Center"
                     Expands="True" />
    </ResourceDictionary>
</ContentPage.Resources>
```
In other words, you can normally forget about resource dictionaries and just program as you would normally in F#.

Other kinds of resources like images need a little more attention and you may need to ship multiple versions of images etc. for Android and iOS.  TBD: write a guide on these, in the meantime see the samples.


