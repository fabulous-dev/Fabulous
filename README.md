<a href="https://fabulous.dev/">
  <h1 align="center">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="logo/logo-title.png">
      <img alt="Fabulous" src="logo/logo-title.png" height="180px">
    </picture>
  </h1>
</a>

[![build](https://img.shields.io/github/actions/workflow/status/fabulous-dev/Fabulous/build.yml?branch=v2.1)](https://github.com/fabulous-dev/Fabulous/actions/workflows/build.yml) [![NuGet version](https://img.shields.io/nuget/v/Fabulous)](https://www.nuget.org/packages/Fabulous) [![NuGet downloads](https://img.shields.io/nuget/dt/Fabulous)](https://www.nuget.org/packages/Fabulous) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK) [![Twitter Follow](https://img.shields.io/twitter/follow/FabulousAppDev?style=social)](https://twitter.com/FabulousAppDev)

Fabulous is a modern declarative UI framework for crafting cross-platform mobile and desktop apps in .NET.  
It aims to bring you a great development experience and confidence in your code by combining an expressive UI syntax, the simple & robust Model-View-Update (MVU) architecture, and functional programming.

## Documentation

The full documentation for Fabulous can be found at [docs.fabulous.dev](https://docs.fabulous.dev).

Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/get-started)
- [API Reference](https://api.fabulous.dev)
- [Contributor Guide](CONTRIBUTING.md)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.

## About Fabulous

We believe declarative UI, functional programming, and the MVU state management are a perfect fit for app development.

Fabulous will help you create mobile and desktop apps quickly and with confidence thanks to declarative UI and the [MVU](https://zaid-ajaj.github.io/the-elmish-book/#/chapters/elm/) architecture, all in one single language: [F#](https://fsharp.org) - a functional programing language.

Fabulous also aims to be performant by having low memory consumption and efficient view diffing mechanisms.

Note that Fabulous itself does not provide any UI rendering. You'll need to combine it with another framework like:
- [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui) with [Fabulous.MauiControls](https://github.com/fabulous-dev/Fabulous.MauiControls)
- [AvaloniaUI](https://avaloniaui.net) with [Fabulous.Avalonia](https://github.com/fabulous-dev/Fabulous.Avalonia)

### Declarative UI

Typical UI development can be a nightmare if not done properly.  
It is generally created in one place, then mutated here and there based on the need and what the user is doing. Related UI pieces end up in several places, making it hard to mentally think of all the possibilities; until the inevitable race condition or bug due to an unintended user flow.

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

## Supporting this project

The simplest way to show us your support is by giving the project a star.

You can also support us by becoming our sponsor on the GitHub Sponsors program.  
This is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.

If you need support see Commercial Support section below.

## Contributing

Have you found a bug or have a suggestion of how to enhance Fabulous? Open an issue and we will take a look at it as soon as possible.

Do you want to contribute with a PR? PRs are always welcome, just make sure to create it from the correct branch (main) and follow the [Contributor Guide](CONTRIBUTING.md).

For bigger changes, or if in doubt, make sure to talk about your contribution to the team. Either via an issue, GitHub discussion, or reach out to the team either using the [Discord server](https://discord.gg/bpTJMbSSYK).

## Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us: [support@fabulous.dev](mailto:support@fabulous.dev)

## Star History

<a href="https://star-history.com/#fabulous-dev/Fabulous&fabulous-dev/Fabulous.Avalonia&fabulous-dev/Fabulous.MauiControls&Date">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/svg?repos=fabulous-dev/Fabulous,fabulous-dev/Fabulous.Avalonia,fabulous-dev/Fabulous.MauiControls&type=Date&theme=dark" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/svg?repos=fabulous-dev/Fabulous,fabulous-dev/Fabulous.Avalonia,fabulous-dev/Fabulous.MauiControls&type=Date" />
   <img alt="Star History Chart" src="https://api.star-history.com/svg?repos=fabulous-dev/Fabulous,fabulous-dev/Fabulous.Avalonia,fabulous-dev/Fabulous.MauiControls&type=Date" />
 </picture>
</a>