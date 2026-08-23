namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuTemplatedControl =
    let TemplateApplied =
        Attributes.Mvu.defineEvent "TemplatedControl_TemplateApplied" (fun target -> (target :?> TemplatedControl).TemplateApplied)

type MvuTemplatedControlModifiers =
    /// <summary>Listens to the TemplateApplied event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the template is applied.</param>
    [<Extension>]
    static member inline onTemplateApplied(this: WidgetBuilder<'msg, #IFabTemplatedControl>, fn: TemplateAppliedEventArgs -> 'msg) =
        this.AddScalar(MvuTemplatedControl.TemplateApplied.WithValue(fn))
