<a href="https://fabulous.dev/">
  <h1 align="center">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="logo/logo-title.png">
      <img alt="Fabulous" src="logo/logo-title.png" height="180px">
    </picture>
  </h1>
</a>

[![build](https://img.shields.io/github/actions/workflow/status/fabulous-dev/Fabulous/build.yml?branch=main)](https://github.com/fabulous-dev/Fabulous/actions/workflows/build.yml) [![NuGet version](https://img.shields.io/nuget/v/Fabulous)](https://www.nuget.org/packages/Fabulous) [![NuGet downloads](https://img.shields.io/nuget/dt/Fabulous)](https://www.nuget.org/packages/Fabulous) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK) [![Twitter Follow](https://img.shields.io/twitter/follow/FabulousAppDev?style=social)](https://twitter.com/FabulousAppDev)

Fabulous is a modern declarative UI framework for crafting cross-platform mobile and desktop applications in .NET. It aims to bring you confidence in your apps and a great development experience by combining an expressive UI syntax, the simple & robust Model-View-Update (MVU) architecture, and functional programming.

## Documentation

- [Get started](https://fabulous.dev/get-started)
- [Fabulous documentation](https://docs.fabulous.dev)
- [Contribution guide](https://github.com/fabulous-dev/Fabulous/blob/main/CONTRIBUTING.md)

## About Fabulous

We believe declarative UI, functional programming, and the MVU state management are a perfect fit for app development.

Fabulous will help you create mobile and desktop apps quickly and with confidence thanks to declarative UI and the [MVU](https://zaid-ajaj.github.io/the-elmish-book/#/chapters/elm/) architecture, all in one single language: [F#](https://fsharp.org) - a functional programing language.

Fabulous also aims to be performant by having low memory consumption and efficient view diffing mechanisms.

Note that Fabulous itself does not provide any UI rendering. You'll need to combine it with another framework like:
- [Xamarin.Forms](https://dotnet.microsoft.com/en-us/apps/xamarin/xamarin-forms) with [Fabulous.XamarinForms](https://github.com/fabulous-dev/Fabulous.XamarinForms)
- [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui) with [Fabulous.MauiControls](https://github.com/fabulous-dev/Fabulous.MauiControls)
- [AvaloniaUI](https://avaloniaui.net) with [Fabulous.Avalonia](https://github.com/fabulous-dev/Fabulous.Avalonia)

### Declarative UI

Typical UI development can be a nightmare if not done properly. It is generally created in one place, then mutated here and there based on the need and what the user is doing.  
Related UI pieces end up in several places, making it hard to mentally think of all the possibilities; until the inevitable race condition or bug due to an unintended user flow.

Fabulous makes it easier to reason about UI thanks to its declarative UI inspired by SwiftUI.  
The UI of a component is defined in a single place and Fabulous will call it everytime the state of that component is changed.  

You don't need to think about how to mutate the UI, Fabulous will handle it for you to always match the latest UI you need.

```fs
/// A simple Counter app made with Fabulous.MauiControls
type Model =
    { Count: int }

type Msg =
    | Increment
    | Decrement

let view model =
    Application(
        ContentPage(
            "Counter app",
            VStack(spacing = 16.) {
                Image(Aspect.AspectFit, "fabulous.png")

                Label($"Count is {model.Count}")

                Button("Increment", Increment)
                Button("Decrement", Decrement)
            }
        )
    )
```

### MVU architecture

MVU makes every state and transition between those states explicit.  
You don't need to worry about unintended actions that could lead to an invalid state which would crash the app.

Instead, you can very easily model the state of your app or component and transitions between them using F# records and discriminated unions types.  
When starting, Fabulous will initialize the state. Then, when messages are being dispatched, Fabulous will let you transition from one state to the other given a specific message.

If several messages are received at the same time, Fabulous will queue them to let you update the state properly.

```fs
let init () =
    { Count = 0 }

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + 1 }
    | Decrement -> { model with Count = model.Count - 1 }
```

And finally, given the functional nature of MVU, it is extremely simple to unit test each and every possible state of your application.

```fs
[<Test>]
let ``When clicking the Increment button, increment the count by one``() =
    let previousState = { Count = 10 }
    let expectedState = { Count = 11 }

    let actualState = App.update Increment previousState

    actualState |> should equal expectedState
```

### Powered by .NET

.NET is a very mature and broad framework by Microsoft. It can run on any device and platform, is very efficient, and has a vast ecosystem of open-source and licensed libraries, plugins, and other frameworks.  
You will be able to benefit from the .NET ecosystem by using 3rd party packages directly in your Fabulous application.

## Sponsoring

Donating is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.  
We accept donations through the GitHub Sponsors program.

If you need support see Commercial Support section below.

## Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us: [support@fabulous.dev](mailto:support@fabulous.dev)