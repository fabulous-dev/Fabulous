// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CustomControls

open Xamarin.Forms
open System

type CustomEntryCell() as self =
    inherit EntryCell()

    let mutable oldValue = ""
    let textChanged = Event<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>()

    do self.PropertyChanging.Add(
        fun args ->
            if args.PropertyName = "Text" then
                oldValue <- self.Text)

    do self.PropertyChanged.Add(
        fun args ->
            if args.PropertyName = "Text" then
                textChanged.Trigger(self, TextChangedEventArgs(oldValue, self.Text)))

    [<CLIEvent>] member __.TextChanged = textChanged.Publish