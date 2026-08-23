namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabRun =
    inherit IFabInline

module Run =
    let WidgetKey = Widgets.register<Run>()

    let Text = Attributes.defineAvaloniaPropertyWithEquality Run.TextProperty

[<AutoOpen>]
module RunBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Run widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Run(text: string) =
            WidgetBuilder<'msg, IFabRun>(Run.WidgetKey, Run.Text.WithValue(text))

type RunModifiers =
    /// <summary>Link a ViewRef to access the direct Run control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRun>, value: ViewRef<Run>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
