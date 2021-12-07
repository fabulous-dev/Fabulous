namespace Fabulous.XamarinForms.Samples.CounterApp

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms
open type Fabulous.XamarinForms.View

module App =
    type Model =
        { Count: int
          Step: int
          TimerOn: bool }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | StepChanged of double
        | TimerToggled of bool
        | TimedTick
        | OsThemeChanged of OSAppTheme

    type CmdMsg =
        | TickTimer

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.ofAsyncMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | TickTimer -> timerCmd ()

    let initModel () =
        { Count = 0
          Step = 1
          TimerOn = false }

    let init () =
        initModel (), []

    let createStyleFor<'T when 'T :> BindableObject> setters =
        let style = Style(typeof<'T>)
        for property, value in setters do
            style.Setters.Add(Setter(Property = property, Value = value))
        style

    let private resources =
        let resources = ResourceDictionary()
        resources.Add(
            // make sure you define the Element type for the Style so the global style can be applied
            createStyleFor<Label>
                [ Label.TextColorProperty, box Color.Green
                  Label.FontSizeProperty, box 24. ])
        resources

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, []
        | Decrement -> { model with Count = model.Count - model.Step }, []
        | Reset -> init ()
        | StepChanged n -> { model with Step = int (n + 0.5) }, []
        | TimerToggled on -> { model with TimerOn = on }, [ if on then TickTimer ]
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, [ TickTimer ] else model, []
        | OsThemeChanged osAppTheme ->
            printfn $"{osAppTheme}"
            model, []

    let view model =
        Application(
            NavigationPage([
                ContentPage("Counter",
                    VerticalStackLayout([
                        Label(string model.Count)
                            .automationId("CountLabel")
                            .centerTextHorizontal()
                            .style (
                                createStyleFor [ Label.TextColorProperty, box Color.Green
                                                 Label.FontSizeProperty, box 24. ]
                            )

                        Button("Increment", Increment)
                            .style(
                                createStyleFor [ Button.BackgroundColorProperty, box Color.Green
                                                 Button.TextColorProperty, box Color.White ]
                                )
                            .automationId("IncrementButton")

                        Button("Decrement", Decrement)
                            .automationId("DecrementButton")
                            .alignStartVertical(expand = true)

                        HorizontalStackLayout([
                            Label("Timer")

                            Switch(model.TimerOn, TimerToggled)
                                .automationId("TimerSwitch")
                        ])
                            .paddingLayout(20.)
                            .centerHorizontal()

                        Slider(min = 0., max = 10., value = float model.Step, onValueChanged = StepChanged)
                            .automationId("StepSlider")
                            .centerHorizontal()

                        Label($"Step size: {model.Step}")
                            .automationId("StepSizeLabel")
                            .centerHorizontal()

                        Button("Reset", Reset)
                            .automationId("ResetButton")
                            .isEnabled(model <> initModel ())
                            .centerHorizontal()
                    ])
                        .paddingLayout(30.)
                        .centerVertical()
            ).hasNavigationBar(false)
            ])
        )
         .onRequestedThemeChanged(fun args -> OsThemeChanged args.RequestedTheme)
         .resources(resources)

    let program = Program.statefulApplicationWithCmdMsg init update view mapCmdMsgToCmd
