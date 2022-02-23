namespace Fabulous.XamarinForms

open Fabulous

[<AutoOpen>]
module InputTypes =

    module Content =

        type Value =
            | String of string
            | Widget of Widget

        let fromString value = String value

        let fromWidget<'msg, 'marker> (builder: WidgetBuilder<'msg, 'marker>) = Widget(builder.Compile())
