// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CustomControls

open Xamarin.Forms
open System

/// A custom control used to implement the 'textChanged' attribute on the EntryCell view element 
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

/// EventArgs for the SizeChanged event
type SizeChangedEventArgs(width: float, height: float) =
    inherit EventArgs()

    member __.Width = width
    member __.Height = height