---
id: "v1-dev-pitfalls"
title : "Pitfalls and F# 5.0 support"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "tutorials"
toc: true
---

Here are some common pitfalls you might encounter when using Fabulous.

## Can Fabulous target .NET 5 / use .NET 5 libraries?

Microsoft announced .NET 5 along with F# 5.0 during .NET Conf 2020.

Before .NET 5 came, there were 3 differents .NET frameworks: .NET Framework, .NET Core and Mono.  
Historically, all Xamarin projects (Android, iOS, macOS and many other) run on Mono.  
Since Fabulous.XamarinForms is built on top of Xamarin.Forms, it also shares the same framework.

This new framework marks the deprecation of .NET Framework in favor of .NET Core, this replacement is done under a new name: .NET 5.  
For the moment, Mono is still an independent framework and hence is not compatible with .NET 5.

Microsoft is planning to retire Mono and use the same framework for everything including Xamarin when .NET 6 comes out (planned for the end of 2021).

In the meantime, it is recommended you target either .NET Standard 2.0 or 2.1 so you can share code between .NET 5 apps and Fabulous apps.

## Can Fabulous use F# 5.0?

Yes!  
You can use any of the new features of F# 5.0 with Fabulous.

But the reality of the moment is that the support is largely dependent on your IDE.

As of January 2021, here is the support level we noticed for the various IDEs:

- Visual Studio (Windows)

  Works perfectly out of the box with Visual Studio 16.8 or newer.

  **Known issues**:
  - Android projects might fail to build because of [an issue with `Xamarin.Android.FSharp.ResourceProvider`](https://github.com/xamarin/Xamarin.Android.FSharp.ResourceProvider/issues/9). A [known workaround](https://github.com/fabulous-dev/Fabulous/issues/813#issuecomment-726210183) is to remove `System` and `System.Numerics` from the Android project references.  
  This issue only affects VS 16.8. So lower versions will require `System` and `System.Numerics` to build.

  - iOS projects may fail after updating FSharp.Core. You will see an exception about a missing ValueOption type. This is caused by VS making a breaking change to the iOS fsproj file.  
  This block:

  ```xml
  <Reference Include="FSharp.Core">
    <HintPath>..\packages\FSharp.Core.4.7.2\lib\netstandard2.0\FSharp.Core.dll</HintPath>
  </Reference>
  ```

  gets replaced with this:

  ```xml
  <Reference Include="FSharp.Core">
    <Private>True</Private>
  </Reference>
  ```
  
  There is a simple fix - reverse the change in the proj file, but update the `FSharp.Core.4.7.2` part of the hint path to the new version you have just installed.

- Visual Studio (macOS)

  The current stable release of Visual Studio for Mac 8.8.4 doesn't fully support F# 5.0.  
  You can compile and debug F# 5.0 apps with it, but the syntax highlighting is broken if you try to use F# 5.0 features (like `open type` or string interpolation), which severely impede the development experience.

  **Known issues**:
  - Syntax highlighting is broken when using new features like string interpolation. There is no workaround for it. We need to wait for Microsoft to fix that. [Hopefully with VS Mac 8.9](https://github.com/mono/mono/pull/20511#issuecomment-729212506).

- JetBrains Rider (Windows & macOS)

  Works perfectly out of the box with Jetbrains Rider 2020.3 or newer.
