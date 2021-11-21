namespace FabulousContacts.iOS

open System
open Xamarin.Forms.Platform.iOS

type BorderedEntryRenderer() =
    inherit EntryRenderer()

    member this.BorderedEntry
        with get() =
            this.Element :?> FabulousContacts.Controls.BorderedEntry

    override this.OnElementChanged(e) =
        base.OnElementChanged(e)

        if (e.NewElement <> null) then
            this.Control.Layer.BorderColor <- this.BorderedEntry.BorderColor.ToCGColor()
            this.Control.Layer.BorderWidth <- nfloat 1.
            this.Control.Layer.CornerRadius <- nfloat 5.
        else
            ()

    override this.OnElementPropertyChanged(_, e) =
        if e.PropertyName = "BorderColor" then
            this.Control.Layer.BorderColor <- this.BorderedEntry.BorderColor.ToCGColor()
            this.Control.Layer.BorderWidth <- nfloat 1.
            this.Control.Layer.CornerRadius <- nfloat 5.

module Dummy_BorderedEntryRenderer =
    [<assembly: Xamarin.Forms.ExportRenderer(typeof<FabulousContacts.Controls.BorderedEntry>, typeof<BorderedEntryRenderer>)>]
    do ()