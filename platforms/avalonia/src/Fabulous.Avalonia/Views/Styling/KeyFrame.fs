namespace Fabulous.Avalonia

open System
open System.Globalization
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Styling
open Fabulous

type IFabKeyFrame =
    inherit IFabElement

module KeyFrame =

    let WidgetKey = Widgets.register<KeyFrame>()

    let Setters =
        Attributes.definePropertyWithGetSet<IAnimationSetter seq> "KeyFrame_Setters" (fun target -> (target :?> KeyFrame).Setters) (fun target value ->
            let target = (target :?> KeyFrame)
            target.Setters.Clear()

            for an in value do
                target.Setters.Add(an))

    let Setter =
        Attributes.definePropertyWithGetSet<IAnimationSetter>
            "KeyFrame_Setter"
            (fun target -> (target :?> KeyFrame).Setters.GetEnumerator().Current)
            (fun target value ->
                let target = (target :?> KeyFrame)
                target.Setters.Add(value))

    let Cue =
        Attributes.defineProperty "KeyFrame_Cue" (Cue(0.)) (fun target value -> (target :?> KeyFrame).Cue <- value)

    let KeySpline =
        Attributes.defineProperty "KeyFrame_KeySpline" (KeySpline(0., 0., 1., 1.)) (fun target value -> (target :?> KeyFrame).KeySpline <- value)

    let KeyTime =
        Attributes.defineProperty "KeyFrame_KeyTime" TimeSpan.Zero (fun target value -> (target :?> KeyFrame).KeyTime <- value)

[<AutoOpen>]
module KeyFrameBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="setters">The animation setters to apply.</param>
        static member KeyFrames(setters: IAnimationSetter seq) =
            WidgetBuilder<'msg, IFabKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setters.WithValue(setters))

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="value">The value to animate to.</param>
        static member KeyFrame(property: AvaloniaProperty, value: obj) =
            WidgetBuilder<'msg, IFabKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setter.WithValue(Setter(property, value)))

type KeyFrameModifiers =
    /// <summary>Sets the Cue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Cue value.</param>
    [<Extension>]
    static member inline cue(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: Cue) =
        this.AddScalar(KeyFrame.Cue.WithValue(value))

    /// <summary>Sets the Cue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Cue value.</param>
    [<Extension>]
    static member inline cue(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: float) =
        this.AddScalar(KeyFrame.Cue.WithValue(Cue(value)))

    /// <summary>Sets the Cue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Cue value.</param>
    [<Extension>]
    static member inline cue(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: string) =
        this.AddScalar(KeyFrame.Cue.WithValue(Cue.Parse(value, CultureInfo.InvariantCulture)))

    /// <summary>Sets the KeySpline property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The KeySpline value.</param>
    [<Extension>]
    static member inline keySpline(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: KeySpline) =
        this.AddScalar(KeyFrame.KeySpline.WithValue(value))

    /// <summary>Sets the KeySpline property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The KeySpline value.</param>
    [<Extension>]
    static member inline keySpline(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: string) =
        this.AddScalar(KeyFrame.KeySpline.WithValue(KeySpline.Parse(value, CultureInfo.InvariantCulture)))

    /// <summary>Sets the KeyTime property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The KeyTime value.</param>
    [<Extension>]
    static member inline keyTime(this: WidgetBuilder<'msg, #IFabKeyFrame>, value: TimeSpan) =
        this.AddScalar(KeyFrame.KeyTime.WithValue(value))

    /// <summary>Link a ViewRef to access the direct KeyFrame control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabKeyFrame>, value: ViewRef<KeyFrame>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
