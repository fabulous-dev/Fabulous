namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IGrid =
    inherit ILayoutOfView

module GridUpdaters =
    let updateGridColumnDefinitions _ (newValueOpt: Dimension [] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

    let updateGridRowDefinitions _ (newValueOpt: Dimension [] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

module Grid =
    let WidgetKey = Widgets.register<Grid>()

    let ColumnDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array>
            "Grid_ColumnDefinitions"
            GridUpdaters.updateGridColumnDefinitions

    let RowDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array>
            "Grid_RowDefinitions"
            GridUpdaters.updateGridRowDefinitions

    let Column =
        Attributes.defineBindableInt Grid.ColumnProperty

    let Row =
        Attributes.defineBindableInt Grid.RowProperty

    let ColumnSpacing =
        Attributes.defineBindableFloat Grid.ColumnSpacingProperty

    let RowSpacing =
        Attributes.defineBindableFloat Grid.RowSpacingProperty

    let ColumnSpan =
        Attributes.defineBindableInt Grid.ColumnSpanProperty

    let RowSpan =
        Attributes.defineBindableInt Grid.RowSpanProperty

[<AutoOpen>]
module GridBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IGrid, IView>(
                Grid.WidgetKey,
                LayoutOfView.Children,
                Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
                Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
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

    /// <summary>Link a ViewRef to access the direct Grid control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IGrid>, value: ViewRef<Grid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

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
