namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open System.Runtime.CompilerServices


module MvuSplitView =
    let PanClosed =
        Attributes.Mvu.defineEvent "SplitView_PanClosed" (fun target -> (target :?> SplitView).PaneClosed)

    let PanClosing =
        Attributes.Mvu.defineEvent "SplitView_PanClosing" (fun target -> (target :?> SplitView).PaneClosing)

    let PanOpened =
        Attributes.Mvu.defineEvent "SplitView_PanOpened" (fun target -> (target :?> SplitView).PaneOpened)

    let PanOpening =
        Attributes.Mvu.defineEvent "SplitView_PanOpening" (fun target -> (target :?> SplitView).PaneOpening)

    let IsPresented =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "SplitView_IsPresented" SplitView.IsPaneOpenProperty

type MvuSplitViewModifiers =
    /// <summary>Listens to the SplitView PanClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosed event fires.</param>
    [<Extension>]
    static member inline onPanClosed(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuSplitView.PanClosed.WithValue(fn))

    /// <summary>Listens to the SplitView PanClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosing event fires.</param>
    [<Extension>]
    static member inline onPanClosing(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuSplitView.PanClosing.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpened event fires.</param>
    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuSplitView.PanOpened.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpening event fires.</param>
    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuSplitView.PanOpening.WithValue(fn))

    /// <summary>Listens to the SplitView IsPresented event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPresented value.</param>
    /// <param name="fn">Raised when the IsPresented event fires.</param>
    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuSplitView.IsPresented.WithValue(ValueEventData.create value fn))
