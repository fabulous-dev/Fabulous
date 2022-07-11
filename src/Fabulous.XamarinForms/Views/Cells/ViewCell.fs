namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IViewCell =
    inherit ICell

module ViewCell =
    let WidgetKey = Widgets.register<ViewCell>()

    let View =
        Attributes.definePropertyWidget
            "ViewCell_View"
            (fun target -> (target :?> ViewCell).View)
            (fun target value -> (target :?> ViewCell).View <- value)

[<AutoOpen>]
module ViewCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ViewCell<'msg, 'marker when 'marker :> IView>(view: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IViewCell> ViewCell.WidgetKey [| ViewCell.View.WithValue(view.Compile()) |]

[<Extension>]
type ViewCellModifiers =
    /// <summary>Link a ViewRef to access the direct ViewCell control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IViewCell>, value: ViewRef<ViewCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
