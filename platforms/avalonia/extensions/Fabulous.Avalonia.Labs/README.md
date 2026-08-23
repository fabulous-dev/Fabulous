## Fabulous.Avalonia.Labs

Experimental Controls for [Avalonia](https://github.com/AvaloniaUI/Avalonia.Labs).

This repository serves as a staging ground for new controls for Avalonia, with the intention of including them in the core AvaloniaUI controls. 

The controls available here are unstable and are suspected to breaking changes as they are being worked on.

> NOTE: This package is not yet stable and is subject to change.

### How to use
- Add the `Fabulous.Avalonia.Labs` package to your project.
- Open `Fabulous.Avalonia` namespace at the top of the file.

### Controls

#### AsyncImage
```fsharp
VStack() {
    AsyncImage(ImageSource.fromString("avares://Gallery/Assets/Icons/fsharp-icon.png"))

    AsyncImage("https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png")
}
```

#### Lottie
```fsharp
Lottie("lottie-file.json")
```

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.