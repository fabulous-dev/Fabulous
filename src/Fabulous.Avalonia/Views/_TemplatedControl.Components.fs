namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentTemplatedControl =
    let TemplateApplied =
        Attributes.Component.defineEvent "TemplatedControl_TemplateApplied" (fun target -> (target :?> TemplatedControl).TemplateApplied)

type ComponentTemplatedControlModifiers =
    /// <summary>Listens to the TemplateApplied event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the template is applied.</param>
    [<Extension>]
    static member inline onTemplateApplied(this: WidgetBuilder<'msg, #IFabTemplatedControl>, fn: TemplateAppliedEventArgs -> unit) =
        this.AddScalar(ComponentTemplatedControl.TemplateApplied.WithValue(fn))
