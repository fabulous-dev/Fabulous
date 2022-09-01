namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IRelativeLayout =
    inherit ILayoutOfView

module RelativeLayout =
    ()
//     let WidgetKey = Widgets.register<RelativeLayout>()
//
//     let XConstraint =
//         Attributes.defineBindableWithEquality<Constraint> RelativeLayout.XConstraintProperty
//
//     let YConstraint =
//         Attributes.defineBindableWithEquality<Constraint> RelativeLayout.YConstraintProperty
//
//     let WidthConstraint =
//         Attributes.defineBindableWithEquality<Constraint> RelativeLayout.WidthConstraintProperty
//
//     let HeightConstraint =
//         Attributes.defineBindableWithEquality<Constraint> RelativeLayout.HeightConstraintProperty
//
//     let BoundsConstraint =
//         Attributes.defineBindableWithEquality<BoundsConstraint> RelativeLayout.BoundsConstraintProperty
//
// [<AutoOpen>]
// module RelativeLayoutBuilders =
//     type Fabulous.Maui.View with
//         static member inline RelativeLayout<'msg>() =
//             CollectionBuilder<'msg, IRelativeLayout, IView>(RelativeLayout.WidgetKey, LayoutOfView.Children)
//
// [<Extension>]
// type RelativeLayoutModifiers =
//     /// <summary>Link a ViewRef to access the direct AbsoluteLayout control instance</summary>
//     [<Extension>]
//     static member inline reference(this: WidgetBuilder<'msg, IRelativeLayout>, value: ViewRef<RelativeLayout>) =
//         this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
//
// [<Extension>]
// type RelativeLayoutAttachedModifiers =
//     [<Extension>]
//     static member inline xConstraint(this: WidgetBuilder<'msg, #IView>, value: float) =
//         this.AddScalar(RelativeLayout.XConstraint.WithValue(Constraint.Constant(value)))
//
//     [<Extension>]
//     static member inline xConstraint(this: WidgetBuilder<'msg, #IView>, value: Func<RelativeLayout, float>) =
//         this.AddScalar(RelativeLayout.XConstraint.WithValue(Constraint.RelativeToParent(value)))
//
//     [<Extension>]
//     static member inline yConstraint(this: WidgetBuilder<'msg, #IView>, value: float) =
//         this.AddScalar(RelativeLayout.YConstraint.WithValue(Constraint.Constant(value)))
//
//     [<Extension>]
//     static member inline yConstraint(this: WidgetBuilder<'msg, #IView>, value: Func<RelativeLayout, float>) =
//         this.AddScalar(RelativeLayout.YConstraint.WithValue(Constraint.RelativeToParent(value)))
//
//     [<Extension>]
//     static member inline widthConstraint(this: WidgetBuilder<'msg, #IView>, value: float) =
//         this.AddScalar(RelativeLayout.WidthConstraint.WithValue(Constraint.Constant(value)))
//
//     [<Extension>]
//     static member inline widthConstraint(this: WidgetBuilder<'msg, #IView>, value: Func<RelativeLayout, float>) =
//         this.AddScalar(RelativeLayout.WidthConstraint.WithValue(Constraint.RelativeToParent(value)))
//
//     [<Extension>]
//     static member inline heightConstraint(this: WidgetBuilder<'msg, #IView>, value: float) =
//         this.AddScalar(RelativeLayout.HeightConstraint.WithValue(Constraint.Constant(value)))
//
//     [<Extension>]
//     static member inline heightConstraint(this: WidgetBuilder<'msg, #IView>, value: Func<RelativeLayout, float>) =
//         this.AddScalar(RelativeLayout.HeightConstraint.WithValue(Constraint.RelativeToParent(value)))
