# Glossary

## Application backend

A Fabulous integration that turns widgets into controls from a UI framework. The maintained backends are `Fabulous.MauiControls` for .NET MAUI and `Fabulous.Avalonia` for Avalonia.

## Attribute

The compiled representation of a widget value, child widget, widget collection, environment value, or event handler. During reconciliation, attributes describe the changes to apply to an existing native view.

## Command (`Cmd<'msg>`)

A list of effects that may dispatch messages. Commands represent work requested by `init` or `update`, such as asynchronous operations, without performing that work inside the pure state transition.

## Command message (`CmdMsg`)

An application-defined discriminated union describing requested effects as data. A separate function maps each command message to a `Cmd<'msg>`. This pattern keeps `init` and `update` straightforward to unit test.

## Component

A stateful, composable Fabulous UI unit. Components can own local state, bind environment values, receive external events, and produce widgets.

## Dispatch

A function of type `'msg -> unit` that sends a message into the program's processing loop.

## Effect

A function that receives `dispatch` and may perform work or dispatch messages. `Cmd<'msg>` is a list of effects.

## Environment

Values propagated through a component/widget tree without being passed explicitly through every intermediate function.

## Marker type

A compile-time interface used by `WidgetBuilder` to constrain which constructors, children, and modifiers are valid for a widget. Marker types do not represent runtime controls.

## Model

The immutable F# value representing application or component state at a point in time.

## Modifier

An extension method that returns a new `WidgetBuilder` with an additional or replaced attribute. Modifiers configure properties, events, layout metadata, references, and other widget behavior.

## Model-View-Update (MVU)

The architecture used by Fabulous programs:

1. The model stores state.
2. The view describes UI for that state.
3. Messages describe events.
4. The update function produces the next model and optional commands.

## Program

The functions and configuration required to run an MVU loop: initialization, update, subscriptions, logging, exception handling, and, for a rendered program, the view function.

## Reconciliation

The process of comparing the previous and next widget trees and applying only the required changes to native views.

## Runner

The runtime host that initializes a program, executes commands/subscriptions, processes messages, reconciles views, and handles errors.

## Subscription (`Sub<'msg>`)

A long-lived external event source associated with a stable identifier. The runner starts and disposes subscriptions as the model changes.

## View function

A function that converts the current model into a widget description. A view function describes desired UI; it should not mutate native controls directly.

## View node (`IViewNode` / `ViewNode`)

The runtime object connecting a compiled widget to its native view. It stores tree context, handlers, component state, and child-node relationships used during reconciliation.

## View reference (`ViewRef<'T>`)

An escape hatch that provides access to the native control created for a widget. Prefer declarative widgets and modifiers; use a view reference when an imperative platform API has no declarative equivalent.

## Widget

An immutable, compiled description of a native view, including its registered widget key and attributes. Widgets are compared during reconciliation.

## Widget builder (`WidgetBuilder<'msg, 'marker>`)

The typed F# value returned by Fabulous constructors and modifiers. Compiling a widget builder produces a widget for reconciliation.
