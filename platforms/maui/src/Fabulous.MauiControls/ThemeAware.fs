namespace Fabulous.Maui

open Microsoft.Maui.Controls
open Microsoft.Maui.ApplicationModel
open Fabulous
open Fabulous.Maui

[<AbstractClass; Sealed>]
type Theme =
    static let mutable _currentTheme = AppTheme.Unspecified
    static member Current = _currentTheme

    static member ListenForChanges(app: Application) =
        app.RequestedThemeChanged.Add(fun args -> _currentTheme <- args.RequestedTheme)

[<AbstractClass; Sealed>]
type ThemeAware =
    static member With(light: 'T, dark: 'T) =
        if Theme.Current = AppTheme.Dark then dark else light

module ThemeAwareProgram =
    type Model<'model> = { Theme: AppTheme; Model: 'model }

    type Msg<'msg> =
        | ThemeChanged of AppTheme
        | ModelMsg of 'msg

    let init (init: 'arg -> 'model * Cmd<'msg>) (arg: 'arg) =
        let model, cmd = init arg

        { Theme = Theme.Current; Model = model }, Cmd.map ModelMsg cmd

    let update (update: 'msg * 'model -> 'model * Cmd<'msg>) (msg: Msg<'msg>, model: Model<'model>) =
        match msg with
        | ThemeChanged theme -> { model with Theme = theme }, Cmd.none
        | ModelMsg msg ->
            let subModel, cmd = update(msg, model.Model)
            { model with Model = subModel }, Cmd.map ModelMsg cmd

    let view (subView: 'model -> WidgetBuilder<'msg, #IFabApplication>) (model: Model<'model>) =
        (View.map ModelMsg (subView model.Model)).onRequestedThemeChanged(ThemeChanged)
