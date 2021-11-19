namespace FabulousContacts.iOS

open Foundation
open Xamarin.Forms.Platform.iOS

type UnderlinedLabelRenderer() =
    inherit LabelRenderer()

    override this.OnElementChanged(e) =
        base.OnElementChanged(e)

        if (e.NewElement <> null) then
            this.Control.AttributedText <-
                new NSAttributedString(str = this.Element.Text,
                                       underlineStyle = NSUnderlineStyle.Single)

    override this.OnElementPropertyChanged(_, e) =
        if e.PropertyName = "Text" then
            this.Control.AttributedText <-
                new NSAttributedString(str = this.Element.Text,
                                       underlineStyle = NSUnderlineStyle.Single)

module Dummy_UnderlinedLabelRenderer =
    [<assembly: Xamarin.Forms.ExportRenderer(typeof<FabulousContacts.Controls.UnderlinedLabel>, typeof<UnderlinedLabelRenderer>)>]
    do ()