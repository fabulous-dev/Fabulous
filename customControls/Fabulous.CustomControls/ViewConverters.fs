namespace Fabulous.DynamicViews

open Xamarin.Forms
open System

type CustomEntryCell() =
    inherit EntryCell()

    let textChanged = Event<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>()

    member x.Text
        with get () = base.Text
        and set (value) =
            let oldValue = base.Text
            base.Text <- value
            textChanged.Trigger(x, TextChangedEventArgs(oldValue, value))

    [<CLIEvent>] member __.TextChanged = textChanged.Publish