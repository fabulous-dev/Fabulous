# Get Started

## Install the templates

\
To install the templates for Fabulous for Xamarin.Forms, run the following command:

```bash
dotnet new install Fabulous.XamarinForms.Templates
```

You can check the installed templates on your machine by running the command:

```bash
dotnet new list
```

You should see the installed Fabulous for Xamarin.Forms templates:

```
Template Name           Short Name         Language  Tags                  
----------------------  -----------------  --------  ----------------------
Fabulous XF Blank       fabulous-xf        F#        Fabulous/Xamarin.Forms
Fabulous XF VS Windows  fabulous-xf-vswin  F#        Fabulous/Xamarin.Forms
```

{% hint style="info" %}
If you are using Visual Studio on Windows, we recommend that you use the template `fabulous-xf-vswin`. This template uses the `nuget.config` file to reference dependencies, instead of `PackageReference`, to ensure compatibility with Visual Studio.
{% endhint %}

## Create a project

To get started, we are going to use the simplest Fabulous for Xamarin.Forms template: `Fabulous XF Blank` (or `fabulous-xf` in the CLI).

Run the command:

```bash
dotnet new fabulous-xf -n GetStartedApp
```

This will create a new folder called GetStartedApp containing the new project.

In this folder, you'll find a shared project `GetStartedApp` as well as 2 other folders `GetStartedApp.Android` and `GetStartedApp.iOS` containing the head projects that will produce the application for the corresponding platform.

{% hint style="info" %}
The templates only include Android and iOS projects, but Fabulous is also compatible with any platform supported by Xamarin.Forms such as WPF, macOS and Linux. See the official [Xamarin.Forms documentation](https://learn.microsoft.com/en-us/xamarin/get-started/supported-platforms) for more information.&#x20;
{% endhint %}

## Run a project

To run a project, we recommend you open the solution `GetStartedApp.sln` with your favorite IDE.

Once loaded, you'll be able to select which project to run (Android or iOS) along with the emulator or device to run on.

Press the debug button to deploy and run the application.

{% hint style="info" %}
Please note that due to some limitations between F# and Xamarin, the Android project will fail to build the first time because of missing resources. Please build a second time to be able to debug.
{% endhint %}
