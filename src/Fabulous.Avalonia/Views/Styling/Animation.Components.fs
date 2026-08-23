namespace Fabulous.Avalonia

open System
open Avalonia.Animation
open Fabulous
open Fabulous.Avalonia

module ComponentAnimation =
    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Animation_KeyFramesProperty" (fun target -> (target :?> Animation).Children)

[<AutoOpen>]
module ComponentAnimationBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates an Animation widget with the specified duration and keyframes.</summary>
        /// <param name="duration">The main Window of the Application.</param>
        static member Animation(duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, ComponentAnimation.Children, Animation.Duration.WithValue(duration))

        /// <summary>Creates an Animation widget with keyframes.</summary>
        static member Animation() =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, ComponentAnimation.Children)

[<AutoOpen>]
module ComponentAnimationAttachedBuilders =
    type Fabulous.Avalonia.View with

        /// <summary> Creates a Animation widget with the specified duration and keyframes.</summary>
        /// <param name="keyFrame">The keyframe to add to the animation.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member inline Animation(keyFrame: WidgetBuilder<'msg, IFabKeyFrame>, duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, ComponentAnimation.Children, Animation.Duration.WithValue(duration)) {
                keyFrame
            }
