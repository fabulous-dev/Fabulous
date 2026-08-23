namespace MultiWindow

open System
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context

module FirstWindow =
    let content () =
        Component("CounterApp") {
            let! count = State(0)
            let! timerOn = State(false)
            let! step = State(1)

            let timer =
                DispatcherTimer(Interval = TimeSpan.FromSeconds(1.), IsEnabled = timerOn.Current)

            (VStack() {
                TextBlock($"%d{count.Current}")
                    .centerText()
                    .onReceive(timer.Tick, (fun _ -> count.Set(count.Current + step.Current)))

                Button("Increment", (fun _ -> count.Set(count.Current + step.Current)))
                    .centerHorizontal()

                Button("Decrement", (fun _ -> count.Set(count.Current - step.Current)))
                    .centerHorizontal()

                (HStack() {
                    TextBlock("Timer").centerVertical()

                    ToggleSwitch(timerOn.Current, (fun on -> timerOn.Set(on)))

                })
                    .margin(20.)
                    .centerHorizontal()

                Slider(0., 10., float step.Current, (fun n -> step.Set(int(n + 0.5))))

                TextBlock($"Step size: %d{step.Current}").center()

                Button(
                    "Reset",
                    fun _ ->
                        count.Set(0)
                        timerOn.Set(false)
                        step.Set(1)
                )
                    .centerHorizontal()

                Button("Show Second Window", (fun _ -> FabApplication.Current.ShowWindow("SecondWindow")))
                    .centerHorizontal()

                Button("Hide Second Window", (fun _ -> FabApplication.Current.HideWindow("SecondWindow")))
                    .centerHorizontal()

                Button("Close Second Window", (fun _ -> FabApplication.Current.CloseWindow("SecondWindow")))
                    .centerHorizontal()

            })
                .center()
        }

module SecondWindow =
    let content () =
        Component("CounterApp") {
            let! count = State(0)
            let! timerOn = State(false)
            let! step = State(1)

            let timer =
                DispatcherTimer(Interval = TimeSpan.FromSeconds(1.), IsEnabled = timerOn.Current)

            (VStack() {
                TextBlock($"%d{count.Current}")
                    .centerText()
                    .onReceive(timer.Tick, (fun _ -> count.Set(count.Current + step.Current)))

                Button("Increment", (fun _ -> count.Set(count.Current + step.Current)))
                    .centerHorizontal()

                Button("Decrement", (fun _ -> count.Set(count.Current - step.Current)))
                    .centerHorizontal()

                (HStack() {
                    TextBlock("Timer").centerVertical()

                    ToggleSwitch(timerOn.Current, (fun on -> timerOn.Set(on)))

                })
                    .margin(20.)
                    .centerHorizontal()

                Slider(0., 10., float step.Current, (fun n -> step.Set(int(n + 0.5))))

                TextBlock($"Step size: %d{step.Current}").center()

                Button(
                    "Reset",
                    fun _ ->
                        count.Set(0)
                        timerOn.Set(false)
                        step.Set(1)
                )
                    .centerHorizontal()

                Button("Hide First Window", (fun _ -> FabApplication.Current.HideWindow("FirstWindow")))
                    .centerHorizontal()

                Button("Show First Window", (fun _ -> FabApplication.Current.ShowWindow("FirstWindow")))
                    .centerHorizontal()

                Button("Close First Window", (fun _ -> FabApplication.Current.CloseWindow("FirstWindow")))
                    .centerHorizontal()
            })
                .center()
        }

module App =

    let view () =
#if MOBILE
        SingleViewApplication(FirstWindow.content())
#else
        DesktopApplication() {
            Window(FirstWindow.content())
                .title("First Window")
                .windowId("FirstWindow")

            Window(SecondWindow.content())
                .title("Second Window")
                .windowId("SecondWindow")
        }
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
