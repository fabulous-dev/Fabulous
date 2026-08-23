# KeyFrame

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** KeyFrame [API](https://reference.avaloniaui.net/api/Avalonia.Animation/KeyFrame/)

## Constructors

<table><thead><tr><th width="252">Constructors</th><th>Description</th></tr></thead><tbody><tr><td>KeyFrames(setters: IAnimationSetter seq)</td><td>Creates a KeyFrame widget.</td></tr><tr><td>KeyFrame(property: AvaloniaProperty, value: obj)</td><td>Creates a KeyFrame widget.</td></tr></tbody></table>

## Properties

| Properties                  | Description                                                    |
| --------------------------- | -------------------------------------------------------------- |
| cue(value: Cue)             | Sets the Cue property.                                         |
| cue(value: float)           | Sets the Cue property.                                         |
| cue(value: string)          | Sets the Cue property.                                         |
| keySpline(value: KeySpline) | Sets the KeySpline property.                                   |
| keySpline(value: string)    | Sets the KeySpline property.                                   |
| keyTime(value: TimeSpan)    | Sets the KeyTime property.                                     |
| reference(value: ViewRef)   | Link a ViewRef to access the direct KeyFrame control instance. |

## Usages

<pre class="language-fsharp"><code class="lang-fsharp"><strong>KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
</strong>
KeyFrames([
    Setter(Rotate3DTransform.AngleXProperty, 0.)
    Setter(Visual.ZIndexProperty, 4)
    Setter(Rotate3DTransform.AngleXProperty, 90.)
    Setter(Visual.ZIndexProperty, 1)
    Setter(Rotate3DTransform.AngleXProperty, 360.)
    Setter(Visual.ZIndexProperty, 4)
])
</code></pre>

#### Get access to the underlying KeyFrame

```fsharp
let keyFrameRef = ViewRef<KeyFrame>()

KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
    .reference(keyFrameRef)
```
