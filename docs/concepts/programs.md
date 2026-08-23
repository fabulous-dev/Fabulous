# Programs and commands

The authoritative constructors are in [Program.fs](https://github.com/fabulous-dev/Fabulous/blob/main/src/neutral/Fabulous.Core/Program.fs). Their current signatures and behavior are:

```fsharp
Program.stateful
    (init: 'arg -> 'model)
    (update: 'msg -> 'model -> 'model)

Program.statefulWithCmd
    (init: 'arg -> 'model * Cmd<'msg>)
    (update: 'msg -> 'model -> 'model * Cmd<'msg>)

Program.statefulWithCmdMsg
    (init: 'arg -> 'model * 'cmdMsg list)
    (update: 'msg -> 'model -> 'model * 'cmdMsg list)
    (mapCmd: 'cmdMsg -> Cmd<'msg>)
```

`stateful` is for synchronous state transitions. Internally it supplies `Cmd.none` after both `init` and `update`.

`statefulWithCmd` lets either function return a `Cmd<'msg>`. A command starts work and dispatches messages back into the loop; it does not directly mutate the model. The [MAUI CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/CounterApp/App.fs) shows an asynchronous timer command.

`statefulWithCmdMsg` keeps domain decisions independent of Fabulous commands. The application returns a list of domain command messages; `mapCmd` converts each value to `Cmd<'msg>`, and Fabulous batches the resulting commands. This is useful for deterministic unit tests: assert command-message values without running effects. The [TestableApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/TestableApp/App.fs) and its [unit tests](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/TestableApp.UnitTests/Tests.fs) use this form.

After choosing a constructor, attach rendering with `Program.withView` for the direct MVU style, or consume the program through `Context.Mvu` inside a component. Optional configuration includes `Program.withSubscription`, `Program.withLogger`, `Program.withTrace`, and `Program.withExceptionHandler`.

Keep `init`, `update`, and `view` deterministic. Put I/O and timers in commands, translate exceptions into messages where the UI can recover, and reserve the exception handler for uncaught failures.

## Throttling external updates

Use a `DispatchThrottle` when a background producer reports values faster than the UI should process them. Choose the behavior explicitly:

- `Dispatch.throttle` forwards the leading value and drops intermediate values.
- `Dispatch.throttleLatest` forwards the leading value and guarantees the latest pending value.
- `Dispatch.batchThrottled` forwards the leading value, then batches every pending value.

Create the throttle once for the lifetime of the producer or program. Do not create it in `update`, because that resets its interval and leaves timers undisposed. Calls to `Dispatch` are thread-safe, including calls from multiple producers.

This progress reporter preserves the final update from a high-frequency stream:

```fsharp
let reportProgress (dispatch: Dispatch<Msg>) =
    let throttle =
        Dispatch.throttleLatest
            (TimeSpan.FromMilliseconds(100.))
            ProgressChanged
            dispatch

    let progress = Progress<float>(throttle.Dispatch)

    task {
        try
            do! copyFiles progress
            do! throttle.FlushAsync()
            dispatch CopyCompleted
        finally
            throttle.Dispose()
    }
```

`FlushAsync` immediately forwards pending values and resets the interval. Call it before `Dispose` when completion must preserve the final value. `Dispose` cancels the timer and drops pending values; later calls to `Dispatch` or `FlushAsync` throw `ObjectDisposedException`. Mapping or dispatch exceptions from timer callbacks are sent to the `onError` function by the `With` factories. Immediate leading-edge calls and `FlushAsync` report exceptions to their caller.

The default factories use a timer. Tests can use `throttleWith`, `throttleLatestWith`, or `batchThrottledWith` with an `IDispatchThrottleScheduler` implementation to advance callbacks deterministically.