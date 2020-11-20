{% include_relative _header.md %}

{% include_relative contents.md %}

## Pitfalls and F# 5.0 support

Here are some common pitfalls you might encounter when using Fabulous.

### Can Fabulous target .NET 5 / use .NET 5 libraries?

Microsoft announced .NET 5 along with F# 5.0 during .NET Conf 2020.

Before .NET 5 came, there were 3 differents .NET frameworks: .NET Framework, .NET Core and Mono.  
Historically, all Xamarin projects (Android, iOS, macOS and many other) run on Mono.  
Since Fabulous.XamarinForms is built on top of Xamarin.Forms, it also shares the same framework.

This new .NET 5 framework marks the deprecation of .NET Framework in favor of .NET Core, this replacement is done under a new name: .NET 5.  
For the moment, Mono is still an independent framework and hence is not compatible with .NET 5.

Microsoft is planning to retire Mono and use .NET 5 even for Xamarin applications when .NET 6 comes out (planned for the end of 2021).

In the meantime, it is recommended you target either .NET Standard 2.0 or 2.1 so you can share code between .NET 5 apps and Fabulous apps.

### Can Fabulous use F# 5.0?

Short answer: Yes!  
You can use any of the new features of F# 5.0 with Fabulous.

But the reality of the moment is that the support is largely dependent on your IDE.

As of November 2020, here is the support level we noticed for the various IDEs:

- Visual Studio (Windows)

    You'll need to install Visual Studio 16.8 or newer.  
    The support of F# 5.0 is complete: can build, run, debug and support all new features (string interpolation, etc.).

    **Known issues**:
    - Android projects might fail to build because of [an issue with `Xamarin.Android.FSharp.ResourceProvider`](https://github.com/xamarin/Xamarin.Android.FSharp.ResourceProvider/issues/9). A [known workaround](https://github.com/fsprojects/Fabulous/issues/813#issuecomment-726210183) is to remove `System` and `System.Numerics` from the Android project references.  
    This issue only affects VS 16.8. So lower versions will require `System` and `System.Numerics` to build.

- Visual Studio (macOS)

    The current stable release of Visual Studio for Mac 8.8 doesn't support F# 5.0.  
    If you want to use F# 5.0, you'll need to switch to the preview channel and install Visual Studio for Mac 8.9 Preview.

    **Known issues**:
    - Stable release doesn't support F# 5.0. The workaround is to switch to the preview channel for the moment. [Support for F# 5.0 will be released for VS Mac 8.8 stable in the near future](https://github.com/mono/mono/pull/20511#issuecomment-729170963).
    - Syntax highlighting is broken when using new features like string interpolation. There is no workaround for it. We need to wait for Microsoft to fix that. [Hopefully with VS Mac 8.9](https://github.com/mono/mono/pull/20511#issuecomment-729212506).

- JetBrains Rider (Windows & macOS)

    It shares the same behavior than Visual Studio for Mac.  
    Depending on your OS, you'll either need Visual Studio 16.8 or Visual Studio 8.9 Preview installed next to it.

    **Known issues**:
    - Just like VS Mac, syntax highlighting is broken when using new features (string interpolation, `open type`). No workaround for it. We need to wait for a future update.