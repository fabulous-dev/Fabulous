namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentAutoCompleteBox =
    let Text =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.Component.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.Component.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.Component.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target ->
            (target :?> AutoCompleteBox).SelectionChanged)

type ComponentAutoCompleteBoxModifiers =
    /// <summary>Binds the AutoCompleteBox.TextProperty.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to bind.</param>
    /// <param name="fn">A function mapping the updated text to a 'msg to raise on user change.</param>
    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string, fn: string -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Text.WithValue(ComponentValueEventData.create value fn))

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatingEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Populating.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox Populated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox Populated event is fired.</param>
    [<Extension>]
    static member inline onPopulated(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatedEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Populated.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">The IsOpen value.</param>
    /// <param name="fn">Raised when the AutoCompleteBox DropDownOpened event is fired.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.DropDownOpened.WithValue(ComponentValueEventData.create isOpen fn))

    /// <summary>Listens to the AutoCompleteBox SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.SelectionChanged.WithValue(fn))
