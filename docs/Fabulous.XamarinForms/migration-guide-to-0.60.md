{% include_relative _header.md %}

{% include_relative contents.md %}

## Migrating from v0.57 to v0.60

Fabulous.XamarinForms 0.60 brings a whole lot of performance improvements, most of them are completely transparent for you.  
Simply update the Fabulous.XamarinForms package to 0.60 to benefit as much as 50% reduction of memory allocation!

Along with this boost in performance, 0.60 brings a couple of changes:

### Changes to view bindings to better support attached properties

When writing manual bindings for your own controls (or 3rd party), you were require to pass 2 functions to `ViewElement.Create`: `create` and `update`.  
`update` took a `registry` as the first parameter to handle attached properties updates, but it was not enough in some special cases.

To provide better support for attached properties, `ViewElement.Create` requires a 3rd function: `updateAttachedProperties`.  
In this function, like `update`, if your control inherits one known by Fabulous, you need to call `ViewBuilders.UpdateXXXAttachedProperties`.

_Old:_

```fsharp
module TestLabel = 
    (...)

    type Fabulous.XamarinForms.View with
        static member inline TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) = 
            (...) 

            // The creation method
            let create () = Xamarin.Forms.Label()

            // The incremental update method
            let update registry (prevOpt: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.Label) = 
                ViewBuilders.UpdateView(registry, prevOpt, source, target)
                (...)

            ViewElement.Create<Xamarin.Forms.Label>(create, update, attribs)
```

_New:_

```fsharp
module TestLabel = 
    (...)

    type Fabulous.XamarinForms.View with
        static member inline TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) = 
            (...)

            // The creation method
            let create () = Xamarin.Forms.Label()

            // The incremental update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.Label) = 
                ViewBuilders.UpdateView(prevOpt, source, target)
                (...)

            // The increment update method for attached properties
            let updateAttachedProperties propertyKey prevOpt source targetChild =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, prevOpt, source, targetChild)
                (...) // You can update your own attached properties here

            ViewElement.Create<Xamarin.Forms.Label>(create, update, updateAttachedProperties, attribs)
```

### FSharp.Core is a now public NuGet dependency

Before Fabulous 0.60, FSharp.Core was implicitly used by Fabulous requiring you to remember including it in all your projects with a version compatible with the one Fabulous uses.  
This is no longer the case. FSharp.Core (>= 4.7.2) is now a public dependency on the Fabulous NuGet package.

You're still free to use a newer FSharp.Core version in your projects, like 5.0.0 to be able to use F# 5.0.

### ViewRef now updates its target at each message. Also triggers Attached/Detached events when the target changes or is reused by another ViewElement.

Before Fabulous 0.60, ViewRef was only getting the target reference if the ViewElement actually created the control itself.  
This was not the case if the control was previously created and Fabulous simply reused it.  
This was mostly an issue with ListView / CollectionView where rows are always reused.

Fabulous 0.60 changes that by updating ViewRef during updates too.  
In addition, you have access to `Attached`/`Detached` events to let you know when Fabulous updates the ViewRef.

_Old:_

```fsharp
let viewRef = ViewRef<Label>()

// Triggered when the ViewRef is attached to a new target (creation or reuse an existing control)
viewRef.Attached.Add(fun target -> (...))

// Triggered when the currently attached target is reused by another ViewElement
viewRef.Detached.Add(fun _ -> (...))

View.Label(
    ref = viewRef
)
```

## CollectionView Header and Footer now accept ViewElement

Before Fabulous 0.60, CollectionView Header and Footer properties only accepted string, any other type were converted to string to match.  
Now, Header and Footer also accept ViewElement to let you create complex headers and footers.

_Old:_

```fsharp
View.CollectionView(
    header = "My header",
    footer = "My footer",
    items = [
        (...)
    ]
)
```

_New:_

```fsharp
View.CollectionView(
    header = StructuredItems.fromString "My header",
    footer = StructuredItems.fromString "My footer",
    items = [
        (...)
    ]
)

View.CollectionView(
    header = StructuredItems.fromElement(
        View.Grid([
            View.Label("My complex header")
        ])
    ),
    footer = StructuredItems.fromElement(
        View.Grid([
            View.Label("My complex footer")
        ])
    ),
    items = [
        (...)
    ]
)
```
