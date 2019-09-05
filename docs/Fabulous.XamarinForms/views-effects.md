
Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Views: Effects
-------
Xamarin.Forms user interfaces are rendered using the native controls of the target platform, allowing Xamarin.Forms applications to retain the appropriate look and feel for each platform. Effects allow the native controls on each platform to be customized without having to resort to a custom renderer implementation.

### Create Effects
The process for creating an effect in each platform-specific project is as follows:

1.  Create a subclass of the `PlatformEffect` class.
2.  Override the `OnAttached` method and write logic to customize the control.
3.  Override the `OnDetached` method and write logic to clean up the control customization, if required.
4.  Add a [`ResolutionGroupName`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.resolutiongroupnameattribute) attribute to the effect class. This attribute sets a company wide namespace for effects, preventing collisions with other effects with the same name. Note that this attribute can only be applied once per project.
5.  Add an [`ExportEffect`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.exporteffectattribute) attribute to the effect class. This attribute registers the effect with a unique ID that's used by Xamarin.Forms, along with the group name, to locate the effect prior to applying it to a control. The attribute takes two parameters – the type name of the effect, and a unique string that will be used to locate the effect prior to applying it to a control.

The effect can then be consumed by attaching it to the appropriate control.

### Using Effects with Fabulous
There are two ways to attach an effect to a `ViewElement`.
1. Using the `created` function of the element:
```fsharp
View.Label(created = fun e -> e.Effects.Add <| Effect.Resolve "SomeResolutionGroup.SomeEffectName")
```

Because the solution 1 is a lot to write there is another way:
2. 
```fsharp
View.Button(effects = [View.Effect(name = "SomeResolutionGroup.SomeEffectName")])
```


See also:
* [Xamarin.Forms - Effects](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/)
* [Xamarin.Forms - Creating an Effect](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/creating)
* [Xamarin.Forms - Introduction to Effects](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/introduction)

