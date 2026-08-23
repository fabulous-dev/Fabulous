namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module SpringAnimationsPage =
    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(
                Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .margin(5)
            )
            .size(200., 200.)
            .borderThickness(2.)
            .borderBrush(SolidColorBrush(Colors.Black))

    let view _ =
        Grid() {
            Border()
                .width(100.0)
                .height(100.0)
                .background(Brushes.Red)
                .renderTransform(TransformGroup() { TranslateTransform() })
                .animation(
                    (Animation(TimeSpan.FromSeconds(1.)) {
                        KeyFrame(TranslateTransform.XProperty, -300.).cue(0.)
                        KeyFrame(TranslateTransform.XProperty, -200.).cue(0.25)
                        KeyFrame(TranslateTransform.XProperty, -100.).cue(0.5)
                        KeyFrame(TranslateTransform.XProperty, 0.).cue(1.)
                    })
                        .playbackDirection(PlaybackDirection.Normal)
                        .easing(SpringEasing(1., 2000., 20., 0.))
                        .repeatForever()
                )
        }
