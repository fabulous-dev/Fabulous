namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IGrid =
    inherit ILayoutOfView

module Grid =
    let WidgetKey = Widgets.register<Grid> ()

    let ColumnDefinitions =
        Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array, Dimension array>
            "Grid_ColumnDefinitions"
            Array.ofSeq
            id
            ScalarAttributeComparers.equalityCompare
            ViewUpdaters.updateGridColumnDefinitions

    let RowDefinitions =
        Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array, Dimension array>
            "Grid_RowDefinitions"
            Array.ofSeq
            id
            ScalarAttributeComparers.equalityCompare
            ViewUpdaters.updateGridRowDefinitions

    let Column =
        Attributes.defineBindable<int> Grid.ColumnProperty

    let Row =
        Attributes.defineBindable<int> Grid.RowProperty

    let ColumnSpacing =
        Attributes.defineBindable<float> Grid.ColumnSpacingProperty

    let RowSpacing =
        Attributes.defineBindable<float> Grid.RowSpacingProperty

    let ColumnSpan =
        Attributes.defineBindable<int> Grid.ColumnSpanProperty

    let RowSpan =
        Attributes.defineBindable<int> Grid.RowSpanProperty

[<AutoOpen>]
module GridBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IGrid, IView>(
                Grid.WidgetKey,
                LayoutOfView.Children,
                Grid.ColumnDefinitions.WithValue(coldefs),
                Grid.RowDefinitions.WithValue(rowdefs)
            )

        static member inline Grid<'msg>() = View.Grid<'msg>([ Star ], [ Star ])

[<Extension>]
type GridModifiers =
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IGrid>, value: float) =
        this.AddScalar(Grid.ColumnSpacing.WithValue(value))

    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IGrid>, value: float) =
        this.AddScalar(Grid.RowSpacing.WithValue(value))

[<Extension>]
type GridAttachedModifiers =
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.Column.WithValue(value))

    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.Row.WithValue(value))

    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.ColumnSpan.WithValue(value))

    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.RowSpan.WithValue(value))
