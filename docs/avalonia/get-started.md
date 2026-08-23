# Get Started

## Install the templates

\
To install the templates for Fabulous for Avalonia, run the following command:

```bash
dotnet new install Fabulous.Avalonia.Templates
```

You can check the installed templates on your machine by running the command:

```bash
dotnet new list
```

You should see the installed Fabulous for Avalonia templates:

```
Template Name            Short Name         Language  Tags             
-----------------------  -----------------  --------  -----------------
Fabulous Avalonia Blank  fabulous-avalonia  F#        Fabulous/Avalonia
Fabulous Avalonia Multi  fabulous-avalonia-multi F#.  Fabulous/Avalonia
```

## Create a single project

To get started, we are going to use the simplest Fabulous for Avalonia template: `Fabulous Avalonia Blank` (or `fabulous-avalonia` in the CLI).

Run the command:

```bash
dotnet new fabulous-avalonia -n GetStartedApp
```

This will create a new folder called GetStartedApp containing the new project.

In this folder, you'll find a project named `GetStartedApp`. This project uses the single project format to target several platforms from a single codebase.&#x20;

Note: Browser target is not supported in the single project template

## Create a multi project

To get started, we are going to use the multi project template: `Fabulous Avalonia Multi` (or `fabulous-avalonia-multi` in the CLI).

Run the command:

```bash
dotnet new fabulous-avalonia-multi -n GetStartedApp
```

This will create a set of folders called GetStartedApp containing the supported platform targets.

{% hint style="info" %}
See the official [Avalonia documentation](https://docs.avaloniaui.net/docs/next/welcome) for more information on the supported platforms.
{% endhint %}

## Run a project

We are now ready to run the project!

Go into the `GetStartedApp` directory and run:

```bash
# run the Desktop app
dotnet run -f net8.0
```

You can also open the solution `GetStartedApp.sln` with your favorite IDE and select the platform you want, then press debug to deploy and run the app.
