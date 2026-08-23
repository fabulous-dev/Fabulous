namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuAutoCompleteBox =
    let Text =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.Mvu.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.Mvu.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.Mvu.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target -> (target :?> AutoCompleteBox).SelectionChanged)

type MvuAutoCompleteBoxModifiers =
    /// <summary>Binds the AutoCompleteBox.TextProperty.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to bind.</param>
    /// <param name="fn">A function mapping the updated text to a 'msg to raise on user change.</param>
    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string, fn: string -> 'msg) =
        this.AddScalar(MvuAutoCompleteBox.Text.WithValue(ValueEventData.create value fn))

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatingEventArgs -> 'msg) =
        this.AddScalar(MvuAutoCompleteBox.Populating.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox Populated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox Populated event is fired.</param>
    [<Extension>]
    static member inline onPopulated(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatedEventArgs -> 'msg) =
        this.AddScalar(MvuAutoCompleteBox.Populated.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">The IsOpen value.</param>
    /// <param name="fn">Raised when the AutoCompleteBox DropDownOpened event is fired.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, isOpen: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuAutoCompleteBox.DropDownOpened.WithValue(ValueEventData.create isOpen fn))

    /// <summary>Listens to the AutoCompleteBox SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(MvuAutoCompleteBox.SelectionChanged.WithValue(fn))
