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

This section applies when running Visual Studio directly on a Windows machine to debug the `net10.0-windows10.0.19041.0` target.

Visual Studio has its own Solution Platform selector (the dropdown next to the `Debug`/`Release` configuration in the toolbar), tracked in the `.sln` file and completely independent of any `RuntimeIdentifier`/`Platform` set in the `.fsproj`. It defaults to `Any CPU`.

#### Packaged apps (`WindowsPackageType=MSIX`, the default)

A packaged Windows app host cannot be architecture-neutral — MSIX requires a concrete architecture, enforced by the Windows App SDK build pipeline itself, not by Fabulous. In Visual Studio, this requirement interacts badly with Solution Platform, intermediate output paths, splash-screen packaging, and Appx deployment. In practice, reliable F5 debugging of packaged Fabulous/F# MAUI Windows apps from Visual Studio is not something we can currently document as working.

Typical failures include a missing `splashSplashScreen.png` (`DEP0700`), a missing `.appxrecipe`, activation/registration errors, and path mismatches when Solution Platform is switched to `x64`.

For local development, switch to unpackaged (see below) instead of fighting packaged deploy in Visual Studio.

#### Unpackaged apps (`<WindowsPackageType>None</WindowsPackageType>`)

This constraint doesn't apply — the MSIX-specific check never runs, so `Any CPU` debugging works fine. Unpackaged builds also skip the MSIX packaging step entirely, which speeds up local build/debug cycles considerably. Use this during development if you don't need MSIX-specific features (e.g. Store packaging).

1. In your `.fsproj`:

```xml
   <PropertyGroup>
     <WindowsPackageType>None</WindowsPackageType>
     <!-- F#: avoid WASDK injecting a .cs auto-initializer (FS0226) -->
     <WindowsAppSdkUndockedRegFreeWinRTInitialize>false</WindowsAppSdkUndockedRegFreeWinRTInitialize>
   </PropertyGroup>
```

2. In `Properties/launchSettings.json`:

```json
   {
     "profiles": {
       "Windows Machine": {
         "commandName": "Project",
         "nativeDebugging": false
       }
     }
   }
```

   Use `"commandName": "Project"` (not `"MsixPackage"`).

3. Run:

```bash
   dotnet build -f net10.0-windows10.0.19041.0 -c Debug
   dotnet run   -f net10.0-windows10.0.19041.0 -c Debug
```

   Or press F5 in Visual Studio with the Windows TFM selected. Leave Solution Platform on `Any CPU`.

