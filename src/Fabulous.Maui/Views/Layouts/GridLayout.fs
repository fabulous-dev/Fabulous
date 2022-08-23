namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Microsoft.Maui.Layouts

module GridLayout =
    let ColumnDefinitions = Attributes.defineMauiScalarWithEquality<IReadOnlyList<IGridColumnDefinition>> "ColumnDefinitions"
    let RowDefinitions = Attributes.defineMauiScalarWithEquality<IReadOnlyList<IGridRowDefinition>> "RowDefinitions"
    let ColumnSpacing = Attributes.defineMauiScalarWithEquality<float> "ColumnSpacing"
    let RowSpacing = Attributes.defineMauiScalarWithEquality<float> "RowSpacing"
    
    module Defaults =
        let [<Literal>] ColumnDefinitions: IReadOnlyList<IGridColumnDefinition> = null
        let [<Literal>] RowDefinitions: IReadOnlyList<IGridRowDefinition> = null
        let [<Literal>] ColumnSpacing: float = 6.
        let [<Literal>] RowSpacing: float = 6.
        
module GridLayoutAttached =
    let Column = Attributes.defineMauiScalarWithEquality<int> "Column"
    let Row = Attributes.defineMauiScalarWithEquality<int> "Row"
    let ColumnSpan = Attributes.defineMauiScalarWithEquality<int> "ColumnSpan"
    let RowSpan = Attributes.defineMauiScalarWithEquality<int> "RowSpan"
    
    module Defaults =
        let [<Literal>] Column: int = 0
        let [<Literal>] Row: int = 0
        let [<Literal>] ColumnSpan: int = 1
        let [<Literal>] RowSpan: int = 1
    
type FabGridLayout(handler: IViewHandler, layoutManagerFn: ILayout -> ILayoutManager) =
    inherit FabLayout(handler, layoutManagerFn)
    
    static let _widgetKey = Widgets.register<FabGridLayout>()
    static member WidgetKey = _widgetKey

    new() = FabGridLayout(LayoutHandler(), fun l -> GridLayoutManager(l :?> IGridLayout))

    interface IGridLayout with
        member this.GetColumn(view) = (view :?> Node).GetScalar(GridLayoutAttached.Column, GridLayoutAttached.Defaults.Column)
        member this.GetColumnSpan(view) = (view :?> Node).GetScalar(GridLayoutAttached.ColumnSpan, GridLayoutAttached.Defaults.ColumnSpan)
        member this.GetRow(view) = (view :?> Node).GetScalar(GridLayoutAttached.Row, GridLayoutAttached.Defaults.Row)
        member this.GetRowSpan(view) = (view :?> Node).GetScalar(GridLayoutAttached.RowSpan, GridLayoutAttached.Defaults.RowSpan)
        member this.ColumnDefinitions = this.GetScalar(GridLayout.ColumnDefinitions, GridLayout.Defaults.ColumnDefinitions)
        member this.ColumnSpacing = this.GetScalar(GridLayout.ColumnSpacing, GridLayout.Defaults.ColumnSpacing)
        member this.RowDefinitions = this.GetScalar(GridLayout.RowDefinitions, GridLayout.Defaults.RowDefinitions)
        member this.RowSpacing = this.GetScalar(GridLayout.RowSpacing, GridLayout.Defaults.RowSpacing)
        
[<AutoOpen>]
module GridLayoutBuilders =
    type Fabulous.Maui.View with
        static member inline GridLayout<'msg>() =
            CollectionBuilder<'msg, IGridLayout, IView>(
                FabGridLayout.WidgetKey,
                Layout.Children
            )
            
        static member inline GridLayout<'msg>(coldefs: GridLength seq, rowdefs: GridLength seq) =
            CollectionBuilder<'msg, IGridLayout, IView>(
                FabGridLayout.WidgetKey,
                Layout.Children,
                GridLayout.ColumnDefinitions.WithValue(coldefs |> Seq.map (fun v -> { new IGridColumnDefinition with member this.Width = v }) |> System.Collections.Generic.List),
                GridLayout.RowDefinitions.WithValue(rowdefs |> Seq.map (fun v -> { new IGridRowDefinition with member this.Height = v }) |> System.Collections.Generic.List)
            )
    
[<Extension>]    
type GridLayoutModifiers =
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IGridLayout>, value: float) =
        this.AddScalar(GridLayout.ColumnSpacing.WithValue(value))
        
    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IGridLayout>, value: float) =
        this.AddScalar(GridLayout.RowSpacing.WithValue(value))
        
[<Extension>]    
type GridLayoutAttachedModifiers =
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridLayoutAttached.Column.WithValue(value))
        
    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridLayoutAttached.Row.WithValue(value))
        
    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridLayoutAttached.ColumnSpan.WithValue(value))
        
    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridLayoutAttached.RowSpan.WithValue(value))
        
[<Extension>]
type GridLayoutCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IGridLayout, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>
        
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IGridLayout, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>