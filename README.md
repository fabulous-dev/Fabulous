<h1 align="center">
  <a href="https://fabulous-dev.github.io/Fabulous/">
    <img alt="Fabulous" src="logo/logo-title.png" height="180">
  </a>
</h1>

<p align="center">
  Declarative, functional applications for .NET using F#.
</p>

<p align="center">
  <a href="https://github.com/fabulous-dev/Fabulous/actions/workflows/pull_request.yml"><img alt="Build and test" src="https://github.com/fabulous-dev/Fabulous/actions/workflows/pull_request.yml/badge.svg?branch=main"></a>
  <a href="https://github.com/fabulous-dev/Fabulous/actions/workflows/pages.yml"><img alt="Documentation" src="https://github.com/fabulous-dev/Fabulous/actions/workflows/pages.yml/badge.svg?branch=main"></a>
  <a href="https://www.nuget.org/packages/Fabulous"><img alt="NuGet version" src="https://img.shields.io/nuget/v/Fabulous"></a>
  <a href="https://www.nuget.org/packages/Fabulous"><img alt="NuGet downloads" src="https://img.shields.io/nuget/dt/Fabulous"></a>
  <a href="https://discord.com/channels/196693847965696000/1541149327701971026"><img alt="Discord" src="https://img.shields.io/discord/716980335593914419?label=discord&logo=discord"></a>
</p>

Fabulous combines F#, declarative UI, and Model-View-Update (MVU) to build mobile and desktop applications with explicit state transitions and testable application logic.

Fabulous provides the application architecture and declarative DSL. Choose a UI backend for rendering:

- **.NET MAUI** with `Fabulous.MauiControls`
- **Avalonia** with `Fabulous.Avalonia`

Core, both backends, extensions, templates, samples, tests, documentation, packaging, and CI are maintained together in this repository.

## Documentation

- [Documentation home](https://fabulous-dev.github.io/Fabulous/)
- [Get started](https://fabulous-dev.github.io/Fabulous/docs/get-started/)
- [Authored documentation](https://fabulous-dev.github.io/Fabulous/docs/)
- [API reference](https://fabulous-dev.github.io/Fabulous/docs/api/)
- [Samples](samples/)
- [Contributing](CONTRIBUTING.md)

For questions and community support, join the [Fabulous Discord server](https://discord.com/channels/196693847965696000/1541149327701971026).

## Example

An MVU application keeps state and transitions separate from its declarative view:

```fsharp
type Model = { Count: int }

type Msg =
    | Increment
    | Decrement

let init () = { Count = 0 }

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + 1 }
    | Decrement -> { model with Count = model.Count - 1 }

let view model =
    Application(
        ContentPage(
            "Counter",
            VStack(spacing = 16.) {
                Label($"Count is {model.Count}")
                Button("Increment", Increment)
                Button("Decrement", Decrement)
            }
        )
    )
```

Fabulous reconciles successive widget descriptions with the native UI. Application state remains ordinary F# data, making update functions straightforward to test.

## Repository layout

```text
src/neutral/       Fabulous.Core, tests, and benchmarks
src/maui/          .NET MAUI backend and extensions
src/avalonia/      Avalonia backend and extensions
samples/           MAUI and Avalonia applications
templates/         dotnet new template packages
docs/              Authored and API documentation
website/           GitHub Pages site
eng/               Migration and release tooling
```

`Fabulous.sln` is the consolidated build and package solution. The package ID remains `Fabulous`; its core assembly is named `Fabulous.Core.dll`.

## Build and test

Prerequisites are a supported .NET SDK and any workloads required by the platform projects you build.

```bash
dotnet restore Fabulous.sln
dotnet test Fabulous.sln -c Release
```

CI additionally validates formatting, package creation, Avalonia headless UI tests with rendered screenshot artifacts, generated templates, a Windows MAUI sample, WinUI compatibility, and documentation deployment. Successful pull-request runs receive timeline links to their package and screenshot artifacts.

## Packages and releases

All Fabulous packages use the unified `10.0.x` version line and are released from [.github/workflows/release.yml](.github/workflows/release.yml). To publish, move the completed notes from `Unreleased` into a new top-level `## [10.0.x] - YYYY-MM-DD` section, add a fresh `Unreleased` section, and push it to `main`. Every `main` push treats the top release section as pending while its matching tag is absent. After the full `Build and test` workflow succeeds, the release workflow publishes packages, creates the matching tag, and creates a GitHub release. A newer `main` push cancels an in-progress attempt and retries the untagged version from the newer commit. NuGet publishing uses GitHub OIDC trusted publishing; no long-lived NuGet API key is stored in the repository.

## Contributing

Issues and pull requests are welcome. Start with [CONTRIBUTING.md](CONTRIBUTING.md), and discuss substantial API changes in an issue before implementation.

## License

Fabulous is licensed under the [Apache License 2.0](LICENSE.md).
