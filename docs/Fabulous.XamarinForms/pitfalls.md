{% include_relative _header.md %}

{% include_relative contents-views.md %}

## Pitfalls

Here are some common pitfalls which you'll maybe encounter.

### .NET 5 / F# 5

.NET 5.0 is not supported at all by Xamarin.
F# 5.0 can be used but the support is uneven depending on your IDE.

### Build failure with VS / MSBuild 16.8

Android can't be build with VS 16.8 on Windows.
[Possible Workaround](https://github.com/fsprojects/Fabulous/issues/813) seems to be to remove both System and System.Numerics from the References in the Android project.

[Another Android Problem](https://github.com/xamarin/Xamarin.Android.FSharp.ResourceProvider/issues/9) is that `Xamarin.Android.FSharp.ResourceProvider` throws an error.
