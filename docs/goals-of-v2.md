Refactoring of Fabulous v2
----

### High-level goals

- **High performance**: Blazing fast computations and Low memory footprint
- **Advanced Use-cases**: Support for advanced use-cases that are not supported by Fabulous v1
- **Developer Experience**: Overall simplicity of the code (powerful yet readable) and Modern tooling (instant reload of changes while debugging)
- **Extensibility**: Cleaner architecture to allow for 3rd party extensibility


### Details

#### High performance
Fabulous runs on all kind of devices, from high-end PCs to low-end smartphones. Performances are critical on those low-end Android phones. Today, we can already see slowness with Fabulous v1 on those kind of devices.

How to improve it?
- Proper diff algorithm (like Myers diff)
- Support Stateful widgets with their own init-update-view cycle to avoid having to parse the whole app UI tree on each update
- Make as much things as possible `struct` rather than `reference` to lower the need for garbage collection
- Reuse as much things as possible (eg. State can survive Runner, Multiple views can be driven by a single Runner, etc.)
- Implement new architecture with benchmarking tools (Benchmark.NET, Assert timers in unit tests that fail if algo takes too long, etc.)
- Decorrelate Update from View to allow for faster update loops
- Use the new .NET types to get the best performances (byref, spans, etc)

NOTE: Flutter seems to not use diff algorithms. Instead they just optimize for the most common paths. See https://flutter.dev/docs/resources/inside-flutter#linear-reconciliation

#### Advanced Use-cases

How to improve it?
- Apply diff to UI using Async/Await to handle things like `Navigation.PopAsync` from Xamarin.Forms
- Implement a proper lifecycle for components (eg. enable starting an event stream at creation, disposed when component removed from UI)

#### Developer Experience

How to improve it?
- New DSL (more expressive like SwiftUI; more safe with strong typing)
- Working LiveUpdate
- Ability to use Fabulous parts in existing XF apps
- Ability to use existing XF parts in Fabulous app
- Easier integration of 3rd party controls
- Take into account the new .NET types like AsyncEnumerable and how to use them with Fabulous
- Produce smallest binaries as possible (linker friendly)

#### Extensibility

How to improve it?
- Compute diff between views in Fabulous rather than in framework specific implementations (Fabulous.XamarinForms, Fabulous.MAUI)
- Compute diff at attribute level rather than control level (allows for obsoleting and overriding of attributes)
- Create a common base that allows for different ViewElement (Static, Dynamic, Adaptive, etc.)


<img src="State store-6.png" />