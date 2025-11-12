namespace Fabulous.Tests.APISketchTests

open Fabulous

[<AutoOpen>]
module TestUI_ComponentBuilders =
    type TestUI_Widgets.View with
        static member Component<'msg, 'marker when 'msg: equality>(key: string) = ComponentBuilder<'msg, 'marker>(key)
