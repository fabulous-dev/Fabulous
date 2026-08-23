namespace Playground

open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context

module App =
    let firstNameView (value: StateValue<string>) =
        Component("firstNameView") {
            let! firstName = Binding(value)
            TextBox(firstName.Current, firstName.Set)
        }

    let lastNameView (value: StateValue<string>) =
        Component("lastNameView") {
            let! lastName = Binding(value)
            TextBox(lastName.Current, lastName.Set)
        }

    let content () =
        Component("content") {
            let! firstName = State("")
            let! lastName = State("")

            VStack() {
                Label($"Full name is {firstName.Current} {lastName.Current}")
                firstNameView firstName
                lastNameView lastName
            }
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() {
            Window(content())
#if DEBUG
                .attachDevTools()
#endif
        }
#endif


    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
