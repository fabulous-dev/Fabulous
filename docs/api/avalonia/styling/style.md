# Style

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** Style [API](https://reference.avaloniaui.net/api/Avalonia.Styling/Style/)

## Constructors

| Constructors | Description                  |
| ------------ | ---------------------------- |
| Animations() | Creates a Animations widget. |

## Properties

| Properties                                           | Description                                                 |
| ---------------------------------------------------- | ----------------------------------------------------------- |
| animation(value: WidgetBuilder<'msg, IFabAnimation>) | Sets the Animations property.                               |
| animation(value: WidgetBuilder<'msg, IFabStyle>)     | Sets the Animations property.                               |
| reference(value: ViewRef                             | Link a ViewRef to access the direct Style control instance. |

## Usages

<pre class="language-fsharp"><code class="lang-fsharp">Border(...)
    .animation(
        Animations() {
            (Animation(TimeSpan.FromSeconds(3.)) {
<strong>                KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
</strong>                KeyFrame(Visual.ZIndexProperty, 4).cue(0.)
                KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.25)
                KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
                KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(1.)
                KeyFrame(Visual.ZIndexProperty, 4).cue(1.)
            })
                .repeatForever()
        }
    )

Border(...)
    .animation(
        (Animation(TimeSpan.FromSeconds(3.)) {
            KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
            KeyFrame(Visual.ZIndexProperty, 4).cue(0.)
            KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.25)
            KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
            KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(1.)
            KeyFrame(Visual.ZIndexProperty, 4).cue(1.)
        })
            .repeatForever()
    )
</code></pre>

#### Get access to the underlying Style

```fsharp
let styleRef = ViewRef<Style>()

(Animation(TimeSpan.FromSeconds(3.)) {
    KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
    KeyFrame(Visual.ZIndexProperty, 4).cue(0.)
    KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.25)
    KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
    KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(1.)
    KeyFrame(Visual.ZIndexProperty, 4).cue(1.)
})
    .repeatForever()
    .reference(styleRef)
    
```
