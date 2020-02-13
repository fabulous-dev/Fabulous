# Getting started

Contributing is easy:

1. [Fork](https://help.github.com/articles/fork-a-repo/) the repository
2. Create a new branch for the feature/fix and give it an appropriate name, e.g. `my_fabulous_fix`
3. Do your best work
4. Build/Test as per the below
5. Create a pull request back to the [appropriate branch](CONTRIBUTING.md#Merge-Process) (or to `master` if you're not sure)

## Prerequisites

- Visual Studio 2017 / Visual Studio for Mac 7 / JetBrains Rider 2019.1 or newer
- Xamarin SDK (Visual Studio Workload: Mobile Development with .NET)
- .NET Core SDK 3.1.100 or newer (or Visual Studio Workload: .NET Desktop Development -> .NET Core 3.1 development tools)

For more information, please refer to the Xamarin.Forms requirements.
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/installation

.NET Core SDK 3.1.100 or newer is required for building .NET Core 3.1 projects. (e.g. Fabulous.XamarinForms generator)

## Understanding the structure

There are 4 distinct libraries in this repository:
- Fabulous
- Fabulous.CodeGen
- Fabulous.XamarinForms
- Fabulous.StaticView.XamarinForms

They are separated into different folders, except Fabulous which is at the root of the repository.

Each library follows the same base structure:

| Name  | Description                                  |
--------|----------------------------------------------|
| samples | (If applicable) The sample projects showcasing how the library usage |
| src   | The source code, split into 1 or more projects |
| tests | The unit & integration test projects |

Since we're hosting the documentation on GitHub Pages, the markdown files can be found in the `docs` folder at the root of the repository, each library has its own subfolder.

As a general rule, each `fsproj` in the `src` folders will be packaged in a NuGet package.

A `sln` file is available at the root of the repository.

### The special case of Fabulous.XamarinForms

To start, it has a few other folders in addition to `samples`, `src`, and `tests`.

| Name  | Description                                  |
--------|----------------------------------------------|
| extensions | The source code of the bindings libraries of 3rd party XF libs (e.g. Maps, SkiaSharp) |
| templates | The files used to create the `dotnet` templates (e.g. `fabulous-xf-app`) |
| tools | The tools used to create Fabulous.XamarinForms. Most notably the bindings generator. |


Then, since Xamarin.Forms has dozens of controls, each with dozens of properties/events, with a new release each month or so, it is really difficult to follow and write the appropriate XF bindings manually to make it compatible with Fabulous.  
To help with that, a tool called Fabulous.XamarinForms.Generator (relying on Fabulous.CodeGen) is used to automate the generation of those bindings at build time, via a JSON file (which can be found in the Fabulous.XamarinForms project).

To support this automated code generation, unlike the other libraries, Fabulous.XamarinForms compiles 2 projects into a single NuGet package: Fabulous.XamarinForms and Fabulous.XamarinForms.Core.

The Core project is where you can make changes (addition, deletion, etc.). The other project is only there to bundle the Core files along with the generated XF bindings in a NuGet package.

## Building

Fabulous can be built with a single command, making use of FAKE 5.  
It will take care of every steps: install FAKE, clean, restore, build and pack.

| Platform | Command |
|----------|---------|
| Unix (Linux & macOS) | `./build.sh` |
| Windows | `.\build` |

It is recommended to run this command at least once before working on Fabulous, as some of the code will be generated.
At minimum, you need to run Fabulous.XamarinForms.Generator to ensure that you have all the dependencies before opening your IDE.

### Running Fabulous.XamarinForms.Generator

The generator is built and run as part of the default build command.  
If you only want to build and run the generator, use the following command:

| Platform | Command |
|----------|---------|
| Unix (Linux & macOS) | `./build.sh RunGeneratorForFabulousXamarinForms` |
| Windows | `.\build RunGeneratorForFabulousXamarinForms` |

**Please run the generator if there are build errors related to "Missing Xamarin.Forms.Core.fs".**

## Testing

The default build command includes the unit tests but ignore the samples as well as the templates.  
This is because it takes a substantial time to complete compared to only building the projects and running their unit tests (3min vs 30min).

If you want to do a "full build", run the following command:

| Platform | Command |
|----------|---------|
| Unix (Linux & macOS) | `./build.sh Test` |
| Windows | `.\build Test` |

## Testing LiveUpdate

Use the CounterApp to test.  To run the equivalent of the `fabulous` CLI tool use this:

    cd Fabulous.XamarinForms\samples\CounterApp\CounterApp
    adb -d forward  tcp:9867 tcp:9867
    dotnet run --project ..\..\..\..\src\Fabulous.Cli\Fabulous.Cli.fsproj -- --watch --send 

If you want to update your (global!) install of the `fabulous-cli` tool, first bump the version number to avoid clashes, then:

    dotnet pack src\Fabulous.Cli
    dotnet tool uninstall --global fabulous-cli  
    dotnet tool install --global --add-source C:\GitHub\dsyme\Fabulous\src\Fabulous.Cli\bin\Debug\ fabulous-cli
    fabulous --watch --send

## Other readings

- [Contributor guide](CONTRIBUTING.md)
- [Maintainer guide](MAINTAINER_GUIDE.md)
