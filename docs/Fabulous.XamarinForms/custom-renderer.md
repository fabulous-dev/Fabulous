{% include_relative _header.md %}

{% include_relative contents-views.md %}

Views: Custom renderers and Custom controls
------
##### (topic last updated: pending)
<br /> 

### Custom renderers

In Xamarin.Forms, custom renderers define how a control is rendered on the UI, and are specific to a platform (iOS, Android, etc.).  
For example, the default iOSButtonRenderer will render a Xamarin.Forms.Button as a UIKit.UIButton and will handle all the properties such as `Text`, `Color`, etc.

Custom renderers are renderers you create to either change the default behavior of an existing renderer or create a completely new one.

With Fabulous for Xamarin.Forms, you can still use custom renderers like you would in plain Xamarin.Forms.

Please read the [custom renderer official documentation](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/custom-renderer/) to learn more about them.

Here's an example of a custom renderer for displaying a Label with underlined text, which is not supported by Xamarin.Forms but the native platforms can do it:
- [UnderlinedLabel](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts/Controls/UnderlinedLabel.fs)
- [UnderlinedLabelRenderer - iOS](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.iOS/UnderlinedLabelRenderer.fs)
- [UnderlinedLabelRenderer - Android](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.Android/UnderlinedLabelRenderer.fs)

### Custom controls

In Xamarin.Forms, custom controls are controls that not part of the default controls of Xamarin.Forms.  
They can either be extended controls (like the UnderlinedLabel above) or brand new ones.

Those custom controls necessarily have custom renderers attached to them, because Xamarin.Forms doesn't know how to render them by default.

When using with Fabulous, you'll need to both create the control class and its wrapper for Fabulous.

Here's an example where we extend the Xamarin.Forms Entry control to add a `BorderColor` property:
```fs
type BorderedEntry() =
    inherit Xamarin.Forms.Entry()

    static let borderColorProperty =
        BindableProperty.Create("BorderColor", typeof<Color>, typeof<BorderedEntry>, Color.Default)

    member this.BorderColor
        with get () =
            this.GetValue(borderColorProperty) :?> Color
        and set (value) =
            this.SetValue(borderColorProperty, value)
```

Along with this control, we create the wrapper (like defined in the [View Extensions documentation](https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/views-extending.html)) so we can use it in our Fabulous application:
```fs
[<AutoOpen>]
module FabulousBorderedEntry =
    let BorderedEntryBorderColorAttributeKey = AttributeKey<_> "BorderedEntry_BorderColor"

    type Fabulous.XamarinForms.View with
        static member inline BorderedEntry(?borderColor: Color, ?placeholder, ?text, ?textChanged, ?keyboard) =
            let attribCount = match borderColor with None -> 0 | Some _ -> 1
            let attribs =
                ViewBuilders.BuildEntry(attribCount,
                                        ?placeholder = placeholder,
                                        ?text = text,
                                        ?textChanged = textChanged,
                                        ?keyboard = keyboard)

            match borderColor with None -> () | Some v -> attribs.Add(BorderedEntryBorderColorAttributeKey, v)

            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: BorderedEntry) =
                ViewBuilders.UpdateEntry(prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, BorderedEntryBorderColorAttributeKey, (fun target v -> target.BorderColor <- v))

            let updateAttachedProperties propertyKey prevOpt source target =
                ViewBuilders.UpdateEntryAttachedProperties(propertyKey, prevOpt, source, target)

            ViewElement.Create(BorderedEntry, update, updateAttachedProperties, attribs)
```

Once this is done, we'll need a custom renderer _per platform_ for that control to handle the new BorderColor property.

Here's the example for iOS:
```fs
type BorderedEntryRenderer() =
    inherit EntryRenderer()

    member this.BorderedEntry
        with get() =
            this.Element :?> FabulousContacts.Controls.BorderedEntry

    override this.OnElementChanged(e) =
        base.OnElementChanged(e)

        if (e.NewElement <> null) then
            this.Control.Layer.BorderColor <- this.BorderedEntry.BorderColor.ToCGColor()
            this.Control.Layer.BorderWidth <- nfloat 1.
            this.Control.Layer.CornerRadius <- nfloat 5.
        else
            ()

    override this.OnElementPropertyChanged(_, e) =
        if e.PropertyName = "BorderColor" then
            this.Control.Layer.BorderColor <- this.BorderedEntry.BorderColor.ToCGColor()
            this.Control.Layer.BorderWidth <- nfloat 1.
            this.Control.Layer.CornerRadius <- nfloat 5.

/// This dummy module is required by F# to be able to use [<assembly:ExportRendererAttribute>]
/// so Xamarin.Forms can find your custom renderer
module Dummy_BorderedEntryRenderer =
    [<assembly: Xamarin.Forms.ExportRenderer(typeof<FabulousContacts.Controls.BorderedEntry>, typeof<BorderedEntryRenderer>)>]
    do ()
```

Complete example:
- [BorderedEntry](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts/Controls/BorderedEntry.fs)
- [BorderedEntryRenderer - iOS](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.iOS/BorderedEntryRenderer.fs)
- [BorderedEntryRenderer - Android](https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts.Android/BorderedEntryRenderer.fs)

See also:

- [Xamarin.Forms - Custom Renderer](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)
- [Xamarin.Forms - Introduction to Custom Renderers](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/custom-renderer/introduction)
- [Xamarin.Forms - Renderer List](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/custom-renderer/renderers)
