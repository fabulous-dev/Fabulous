## Diagnostics for Fabulous.Avalonia

Avalonia has a built-in [DevTools](https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools) window which is enabled by calling the attached AttachDevTools()

### How to use
- Add the `Fabulous.Avalonia.Diagnostics` package to your project.
- Open `Fabulous.Avalonia` namespace at the top of the file where you declare your `SingleViewApplication` or `DesktopApplication` widgets.
- The default templates have this enabled when the program is compiled in DEBUG mode:

```fsharp
    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

#if DEBUG
            .attachDevTools()
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
```

## Other useful links:
- [DevTools](https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools)
- [Fabulous documentation](https://fabulous-dev.github.io/Fabulous/docs/)
- [Get started](https://fabulous-dev.github.io/Fabulous/docs/tutorials/avalonia/)

Additionally, we have the [Fabulous Discord server](https://discord.com/channels/196693847965696000/1541149327701971026) where you can ask any of your Fabulous related questions.