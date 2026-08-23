# Get Started

## Install the templates

\
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

{% hint style="info" %}
See the official [.NET MAUI documentation](https://learn.microsoft.com/en-us/dotnet/maui/supported-platforms) for more information on the supported platforms.
{% endhint %}

## Run a project

We are now ready to run the project!

Go into the `GetStartedApp` directory and run:

```bash
# run the Android app
dotnet build -f net7.0-android -t:Run

# run the iOS app
dotnet build -f net7.0-ios -t:Run

# for other platforms, use the corresponding TFM (net7.0-xxx)
```

You can also open the solution `GetStartedApp.sln` with your favorite IDE and select the platform you want, then press debug to deploy and run the app.
