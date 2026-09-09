# Get Started

## Install the templates

To install the templates for Fabulous for .NET MAUI, run the following command:

```bash
dotnet new install Fabulous.MauiControls.Templates
```

You can check the installed templates on your machine by running the command:

```bash
dotnet new list
```

You should see the installed Fabulous for .NET MAUI templates:

```
Template Name           Short Name             Language  Tags                       
----------------------  ---------------------  --------  ---------------------------
Fabulous Maui.Controls  fabulous-mauicontrols  F#        Fabulous/Maui/Maui.Controls
```

## Create a project

To get started, we are going to use the simplest Fabulous for .NET MAUI template: `Fabulous Maui.Controls` (or `fabulous-mauicontrols` in the CLI).

Run the command:

```bash
dotnet new fabulous-mauicontrols -n GetStartedApp
```

This will create a new folder called GetStartedApp containing the new project.

In this folder, you'll find a project named `GetStartedApp`. This project uses the single project format to target several platforms from a single codebase.

See the official [.NET MAUI documentation](https://learn.microsoft.com/en-us/dotnet/maui/supported-platforms) for more information about the supported platforms.

## Run a project

We are now ready to run the project!

Go into the `GetStartedApp` directory and run:

```bash
# run the Android app
dotnet build -f net10.0-android -t:Run

# run the iOS app
dotnet build -f net10.0-ios -t:Run

# for other platforms, use the corresponding TFM (net10.0-xxx)
```

You can also open the solution `GetStartedApp.sln` with your favorite IDE and select the platform you want (detailed information for Visual Studio see below), then press debug to deploy and run the app.

## Debugging on Windows from Visual Studio

*This section applies when running Visual Studio directly on a **Windows Machine** to debug the `net10.0-windows10.0.19041.0` target.*

Visual Studio has its own Solution Platform selector (the dropdown next to the `Debug/Release` configuration in the toolbar), tracked in the `.sln` file and completely independent of any `RuntimeIdentifier/Platform` set in the `.fsproj`. It defaults to `Any CPU`. Because a packaged Windows app host cannot be `Any CPU`, leaving this at the default causes deployment to fail.

Therefore, before debugging on Windows in Visual Studio you shall:

1) Open `Build` > `Configuration Manager`.
 
Under `Active solution platform`, select `x64` — create it first if it isn't listed (`New...` > `x64`, copying settings from `Any CPU`). This is a Visual Studio / solution-file setting, not a project-file setting — it is not affected by `RuntimeIdentifier` or `Platform defaults` in the `.fsproj`, so this step is required regardless of the template version and cannot be fixed upstream in Fabulous.

2) Confirm your project's row shows `x64` under Platform.

Rebuild the solution (`Build` > `Rebuild Solution`), not an incremental build. Switching platforms after a prior `Any CPU` build can leave stale intermediate/output files that reproduce the same error even once the platform is set correctly. If rebuilding does not clear it, delete the `bin` and `obj` folders and rebuild again.
