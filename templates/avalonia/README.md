# Templates for Fabulous.Avalonia

Fabulous.Avalonia brings the great development experience of Fabulous to Avalonia, allowing you to take advantage of the latest cross-platform UI framework from Microsoft with a tailored declarative UI DSL and clean architecture.

Deploy to any platform supported by Avalonia, such as Android, iOS, macOS, Windows, Linux and more!

## How to use the templates

Using the dotnet CLI, install the templates:

```sh
dotnet new install Fabulous.Avalonia.Templates
```

Then, you will be able to create new Fabulous.Avalonia projects with `dotnet new`:

#### Single Project

Single project takes the platform-specific development experiences and abstracts them into a single shared project that can target Android, iOS, Desktop.

```sh
dotnet new fabulous-avalonia -n MyApp
```

- MyApp
    - Platform
      - Android
      - iOS
      - Desktop

Note: Browser is not supported in single project template.

#### Multi Project

Multi project takes the platform-specific development and abstracts them into a multiple projects that can target Android, iOS, Desktop, Browser.

```sh
dotnet new fabulous-avalonia-multi -n MyApp
```

- MyApp
  - MyApp
  - MyApp.Android
  - MyApp.iOS
  - MyApp.Desktop

Note: Browser is not supported in multi project template.

### Documentation

Documentation can be found at https://docs.fabulous.dev/v2/avalonia