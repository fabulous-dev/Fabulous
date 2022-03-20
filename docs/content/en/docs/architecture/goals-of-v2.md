---
title: "Reasonable goals of v2"
description: ""
lead: ""
date: 2020-10-06T08:48:57+00:00
lastmod: 2020-10-06T08:48:57+00:00
draft: false
images: []
menu:
  docs:
    parent: "architecture"
toc: true
---

Due to the complex nature of GUI framework development, Fabulous v2 represents a substantial amount of work.  
In order to manage and optimize the time of everyone involved, more reasonable goals are required to get a version 2 out as fast as possible.

Doing a complete redesign of the architecture + adding .NET 6 / MAUI support at the same time feels really discouraging.

That's why this version 2 will be done in 4 separate releases:

- Focus on performance and Xamarin.Forms 5.0 support
- Migration path from version 1
- Components
- .NET 6 / MAUI support

## Focus on performance and extensibility

While Fabulous v1 works perfectly well, it relies a lot on object allocations, does a lot of cache misses, etc.  
The primary goal of v1 was not to get something optimized but to get something working.

Over the years, it has become apparent we need to optimize for speed and memory usage.  
Especially on Android where low-end devices can be found, frequent garbage collections are noticed and can freeze the app, sometimes for up to several seconds!

Also in addition to perf improvements, v2 will focus on making extensibility easier.

To improve that, here's what will be done:

- Redesign of the internal architecture
  - Reduce garbage collection to a minimum on hot paths (heavy use of structs, optimize against cache misses, etc)
  - Improve computation speed (micro-benchmarking on critical paths - benchmarking end-to-end on typical use cases)
- Implement a generic Reconciler in Core
  - This will help us optimize allocations and speed
  - It will also be useful for framework integration (like Fabulous.XF, Fabulous.MAUI, etc). They won't need to worry about reconciliation.
- Attribute level diff instead of control level diff
  - This change will make it easier to extend an existing control without having to rewrite the whole mapping each time. (eg. https://github.com/TimLariviere/FabulousContacts/blob/master/FabulousContacts/Controls/BorderedEntry.fs)
  - Such extensibilty can be done via method extensions à la SwiftUI
- Decorrelate Update from View
  - This will be useful in cases where we receive numerous updates in a short timeframe or we received them continously (streams).
  - The runner will still treat all the updates and update the model, but the view will be able to take only the latest available model if diffing is not keeping up with the updates.
  - The update loop will be able to run on another thread since it won't need to access the UI, resulting in faster updates.
- Enable having multiple instances of Fabulous in the same app (no singleton)
  - Today, Fabulous is limited to only 1 Program running at the same time.
  - This change will allow to have multiple programs in a same app - like for example 2 Fabulous controls in a C# XF app.
- Add lifecycle to ViewElement (on mount, on dismount, on create, on destroy)
- Produce smallest binaries as possible
  - Make sure all unused types are trimmed away by the Android / iOS linkers

This version 2 will focus 100% on dynamic views (main selling point).
Fabulous.StaticViews will be removed completely.  
Support for Fabulous.AdaptiveViews won't be considered.

**Release target**: December 2021 (include v2 architecture and XF 5.0 support)

## Xamarin.Forms 5.0 support

So that we can validate and use the new architecture of Fabulous v2, a framework integration with XF 5.0 will be required.  
Initially, we wanted to test it with MAUI and only later on write a migration path from Fabulous v1 / XF 5.0 but the development experience with MAUI is still way too fragile as of November 2021.  
For that reason, we believe it is better to start with Xamarin.Forms 5.0 support.

Here's what will be done:

- Design a new View DSL
  - Strongly-typed
    - Each control will return a typed element instead of just `ViewElement`
    - This will prevent combining incompatible controls (eg. a `Label` inside a `ListView`)
    - This will also prevent combining 2 UIs using incompatible messages
  - Better for autocompletion
    - Having uniquely-typed elements, IDEs will be able to show only available properties and events
  - Better defaults
    - Each control can have specialized constructors to enforce meaningful defaults (eg. `Label` will always have `Text`, `Button` will always have `Text` and an `Action`, etc.)
  - Easier to extend
    - Adding a new property to an element will be as simple as creating an extension method (https://github.com/TimLariviere/Fabulous-new/blob/618c8226533134cb73f7f79049d1fa737d2b83d6/src/Fabulous.Maui/Microsoft.Maui.Controls.fs#L363-L394)
  - No dispatch
    - Avoid accidentally keeping the dispatch function passed as argument when this one can be swapped with another dispatch at any moment by Fabulous
- Update Fabulous.XamarinForms.Generator to generate the wrappers for the new DSL
- Port all the existing samples to v2 and the new DSL

This is an early example of the new DSL done with MAUI.

```fs
type Msg =
    | Increment
    | Decrement

let view model =
    Application([
        Window("Main",
            VerticalStackLayout([
                Label($"Hello World from Fabulous: {model.Count}")
                    .font(Font.SystemFontOfSize(20.))
                    .horizontalLayoutAlignment(Primitives.LayoutAlignment.Fill)
                    .verticalLayoutAlignment(Primitives.LayoutAlignment.Fill)
                    .horizontalTextAlignment(TextAlignment.Center)
                    .background(SolidPaint(Colors.Red))
                    
                Button("Click me", Increment)
                
            ])
            .spacing(10.)
            .background(SolidPaint(Colors.Aqua))
        )
    ])

```

**Release target**: December 2021 (include v2 architecture and XF 5.0 support)

## Migration path from version 1

When v2 and the new DSL will be validated by early adopters, we will need to work on a migration path for users that developped their apps with Fabulous v1.  
Ideally, there should be the least amount of breaking changes possible since it's mostly internal stuffs that will change.

To permit this, here's what we will be done:

- Make the old DSL work with v2
  - This will allow (ideally) seamless transition from v1 to v2
- Make Fabulous.XamarinForms.Generator outputs both the new DSL and old DSL for Xamarin.Forms 5.0
- Release everything related to the migration (old DSL) in a compatibility package instead of directly in Fabulous.XamarinForms

**Release target**: February 2022

## Components

The concept of components was one of the inital motivators for making a version 2.
The idea was to create smaller programs with their own MVU loop and runner, and then embed them in a `ViewElement` so they can be included in a larger program.
This had the advantage to reduce the UI tree to process during diffing.

Turns out it's not that simple to implement.

@twop recommended to take a similar approach than Elm: Actor Model.
Instead of implementing the concept directly in the core of Fabulous with dedicated widgets, we can create an Actor Model library to facilitate communication between independent parts of the application.

Each part is given a Process ID and they can send messages to each other using that id.
This will still trigger a whole update from the root of the app, but with v2 architecture, diffing should be way more efficient than today so it shouldn't be an issue to not have isolated components.

Inspiration: https://www.youtube.com/watch?v=YV_qrjN8bRA

We're still discussing how to implement such a library.

**Release target**: April 2022

## .NET 6 / MAUI support

Finally when everything else will be done and .NET 6.0 / MAUI is in a stable state, we will be able to start working on support for MAUI in Fabulous.

**Release target**: Depends on the MAUI team. Earliest possible - May / June 2022

## What about all the other stuff?

Things like LiveUpdate, more advanced use case support, etc won't be included as part of the official repository.
At least not initially.

Anyway, they will have to wait after we get version 2 fully released and production-ready before consideration.
