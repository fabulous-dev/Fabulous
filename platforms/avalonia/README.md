# Fabulous for Avalonia

[![build](https://img.shields.io/github/actions/workflow/status/fabulous-dev/Fabulous.Avalonia/build.yml?branch=main)](https://github.com/fabulous-dev/Fabulous.Avalonia/actions/workflows/build.yml) [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia)](https://www.nuget.org/packages/Fabulous.Avalonia#readme-body-tab) [![NuGet downloads](https://img.shields.io/nuget/dt/Fabulous.Avalonia)](https://www.nuget.org/packages/Fabulous.Avalonia) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK) [![Twitter Follow](https://img.shields.io/twitter/follow/FabulousAppDev?style=social)](https://twitter.com/FabulousAppDev)

Fabulous.Avalonia brings the great development experience of Fabulous to [AvaloniaUI](https://github.com/AvaloniaUI/Avalonia), allowing you to take advantage of this UI framework with a tailored declarative UI DSL and clean architecture.

Deploy to any platform supported by Avalonia, such as Android, iOS, macOS, Windows, Linux and more!

### MVU Sample

```fs
namespace CounterApp

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

module App =
    type Model =
        { Count: int; Step: int; TimerOn: bool }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick

    let initModel = { Count = 0; Step = 1; TimerOn = false }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.OfAsync.msg

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment ->
            { model with
                Count = model.Count + model.Step },
            Cmd.none
        | Decrement ->
            { model with
                Count = model.Count - model.Step },
            Cmd.none
        | Reset -> initModel, Cmd.none
        | SetStep n -> { model with Step = int(n + 0.5) }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd() else Cmd.none)
        | TimedTick ->
            if model.TimerOn then
                { model with
                    Count = model.Count + model.Step },
                timerCmd()
            else
                model, Cmd.none

    let program = Program.statefulWithCmd init update

    let content () =
        Component("CounterApp") {
            let! model = Context.Mvu program

            (VStack() {
                TextBlock($"%d{model.Count}").centerText()

                Button("Increment", Increment).centerHorizontal()

                Button("Decrement", Decrement).centerHorizontal()

                (HStack() {
                    TextBlock("Timer").centerVertical()

                    ToggleSwitch(model.TimerOn, TimerToggled)
                })
                    .margin(20.)
                    .centerHorizontal()

                Slider(0., 10., float model.Step, SetStep)

                TextBlock($"Step size: %d{model.Step}").centerText()

                Button("Reset", Reset).centerHorizontal()

            })
                .center()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif
    let create () =

        FabulousAppBuilder.Configure(FluentTheme, view)
```

## Additional Controls

We also provide additional binding for Avalonia controls, you can find them in the following packages:

- Fabulous.Avalonia.DataGrid [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.DataGrid)](https://www.nuget.org/packages/Fabulous.Avalonia.DataGrid#readme-body-tab)
- Fabulous.Avalonia.ColorPicker [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.ColorPicker)](https://www.nuget.org/packages/Fabulous.Avalonia.ColorPicker#readme-body-tab)
- Fabulous.Avalonia.Diagnostics [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.Diagnostics)](https://www.nuget.org/packages/Fabulous.Avalonia.Diagnostics#readme-body-tab)
- Fabulous.Avalonia.ItemsRepeater [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.ItemsRepeater)](https://www.nuget.org/packages/Fabulous.Avalonia.ItemsRepeater#readme-body-tab)
- Fabulous.Avalonia.TreeDataGrid [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.TreeDataGrid)](https://www.nuget.org/packages/Fabulous.Avalonia.TreeDataGrid#readme-body-tab)
- Fabulous.Avalonia.Labs [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.Labs)](https://www.nuget.org/packages/Fabulous.Avalonia.Labs#readme-body-tab)

## Getting Started

You can start your new Fabulous.Avalonia app in a matter of seconds using the dotnet CLI templates.  
For a starter guide see our [Get Started with Fabulous.Avalonia](https://docs.fabulous.dev/avalonia/get-started).

## How to use the templates

Using the dotnet CLI, install the templates:

```sh
dotnet new install Fabulous.Avalonia.Templates
```

Then, you will be able to create new Fabulous.Avalonia projects with `dotnet new`:

#### Desktop Project

Desktop project is a standard Avalonia project that can target Desktop platforms only.

```sh
dotnet new fabulous-avalonia-desktop -n MyApp
```

#### Single Project

Single project takes the platform-specific development experiences and abstracts them into a single shared project that can target Android, iOS, Desktop.

```sh
dotnet new fabulous-avalonia -n MyApp
```

```tree
MyApp
├── Platform
    ├── Android
    ├── iOS
    └── Desktop
```

Note: Browser is not supported in single project template.

#### Multi Project

Multi project takes the platform-specific development and abstracts them into a multiple projects that can target Android, iOS, Desktop, Browser.

```sh
dotnet new fabulous-avalonia-multi -n MyApp
```

```tree
MyApp
├── MyApp
├── MyApp.Android
├── MyApp.iOS
├── MyApp.Desktop
└── MyApp.Browser
```

net8.0-ios is not supported on Linux, thus net8.0-ios is excluded from build on a Linux host.

## Controls Gallery
To run the `Gallery` sample app from the command line:

- This will restore the required workloads for the samples

```shell
dotnet workload restore
```

- Then you can run the Gallery sample

```shell
cd samples/Gallery
dotnet run -f net8.0
```

You can also open the solution `Fabulous.Avalonia.sln` with your favorite IDE(We recommend [Rider](https://www.jetbrains.com/rider/)) and select the platform you want, then press debug to deploy and run the app.

## Documentation

The full documentation for Fabulous.Avalonia can be found at [docs.fabulous.dev/avalonia](https://docs.fabulous.dev/avalonia).

Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)
- [Samples](https://github.com/fabulous-dev/Fabulous.Avalonia/tree/main/samples)
- [API Reference](https://api.fabulous.dev/avalonia)
- [Contributor Guide](CONTRIBUTING.md)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.

## Supporting Fabulous

The simplest way to show us your support is by giving this project and the [Fabulous project](https://github.com/fabulous-dev/Fabulous) a star.

You can also support us by becoming our sponsor on the GitHub Sponsors program.  
This is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.

If you need support see Commercial Support section below.

## Contributing

Have you found a bug or have a suggestion of how to enhance Fabulous? Open an issue and we will take a look at it as soon as possible.

Do you want to contribute with a PR? PRs are always welcome, just make sure to create it from the correct branch (main) and follow the [Contributor Guide](CONTRIBUTING.md).

For bigger changes, or if in doubt, make sure to talk about your contribution to the team. Either via an issue, GitHub discussion, or reach out to the team either using the [Discord server](https://discord.gg/bpTJMbSSYK).

## Old Version

This repository is about Fabulous v2. You can find Version 1 [here.](https://github.com/fabulous-dev/Fabulous/tree/release/1.0)

## Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us: [support@fabulous.dev](mailto:support@fabulous.dev)
