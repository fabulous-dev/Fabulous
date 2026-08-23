# Animation

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** Animation [API](https://reference.avaloniaui.net/api/Avalonia.Animation/Animation/)

## Constructors

| Constructors                  | Description                                                           |
| ----------------------------- | --------------------------------------------------------------------- |
| Animation(duration: TimeSpan) | Creates a Animation widget with the specified duration and keyframes. |
| Animation()                   | Creates a Animation widget with keyframes.                            |

## Properties

| Properties                                               | Description                                                    |
| -------------------------------------------------------- | -------------------------------------------------------------- |
| repeatForever(this: WidgetBuilder<'msg, #IFabAnimation>) | Sets the IterationCount property to Infinite                   |
| repeatCount(value: int)                                  | Sets the IterationCount property to the specified value        |
| playbackDirection(value: PlaybackDirection)              | Sets the PlaybackDirection property                            |
| fillMode(value: FillMode)                                | Sets the FillMode property                                     |
| easing(value: Easing)                                    | Sets the Easing property                                       |
| delay(value: TimeSpan)                                   | Sets the Delay property                                        |
| delayBetweenIterations(value: TimeSpan)                  | Sets the DelayBetweenIterations property                       |
| speedRatio(value: float)                                 | Sets the SpeedRatio property                                   |
| reference(value: ViewRef)                                | Link a ViewRef to access the direct Animation control instance |

## Usages

```fsharp
Animation(KeyFrame(RotateTransform.AngleProperty, 360.).cue(1.), TimeSpan.FromSeconds(2.))
    .repeatForever()

(Animation(TimeSpan.FromSeconds(3.)) {
    KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
    KeyFrame(Visual.ZIndexProperty, 4).cue(0.)
    KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.25)
    KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
    KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(1.)
    KeyFrame(Visual.ZIndexProperty, 4).cue(1.)
})
.repeatForever()

```

#### Get access to the underlying Animation

```fsharp
let animationRef = ViewRef<Animation>()

Animation(KeyFrame(RotateTransform.AngleProperty, 360.).cue(1.), TimeSpan.FromSeconds(2.))
    .reference(keyFrameRef)
```
