namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabAccessText =
    inherit IFabTextBlock

module AccessText =
    let WidgetKey = Widgets.register<AccessText>()

    let ShowAccessKey =
        Attributes.defineAvaloniaPropertyWithEquality AccessText.ShowAccessKeyProperty

[<AutoOpen>]
module AccessTextBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a AccessText widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="showAccessKey">Whether to underline the access key in the text.</param>
        static member inline AccessText(text: string, showAccessKey: bool) =
            WidgetBuilder<'msg, IFabAccessText>(AccessText.WidgetKey, TextBlock.Text.WithValue(text), AccessText.ShowAccessKey.WithValue(showAccessKey))

type AccessTextModifiers =
    /// <summary>Link a ViewRef to access the direct AccessText control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAccessText>, value: ViewRef<AccessText>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
