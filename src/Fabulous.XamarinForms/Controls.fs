namespace Fabulous.XamarinForms

open System
open Xamarin.Forms

/// Represents a dimension for either the row or column definition of a Grid
type Dimension =
    /// Use a size that fits the children of the row or column.
    | Auto
    /// Use a proportional size of 1
    | Star
    /// Use a proportional size defined by the associated value
    | Stars of float
    /// Use the associated value as the number of device-specific units.
    | Absolute of float

type SizeAllocatedEventArgs = { Width: float; Height: float }

/// Set UseSafeArea to true by default because View DSL only shows `ignoreSafeArea`
type FabulousContentPage() as this =
    inherit ContentPage()
    do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true)

    let sizeAllocated =
        Event<EventHandler<SizeAllocatedEventArgs>, _>()

    [<CLIEvent>]
    member __.SizeAllocated = sizeAllocated.Publish

    override this.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(this, { Width = width; Height = height })

type TimeSelectedEventArgs(newTime: TimeSpan) =
    inherit EventArgs()
    member _.NewTime = newTime

/// Xamarin.Forms doesn't provide an event for selecting the time on a TimePicker, so we implement it
type FabulousTimePicker() =
    inherit TimePicker()

    let timeSelected =
        Event<EventHandler<TimeSelectedEventArgs>, _>()

    [<CLIEvent>]
    member _.TimeSelected = timeSelected.Publish

    override this.OnPropertyChanged(propertyName) =
        if propertyName = TimePicker.TimeProperty.PropertyName then
            timeSelected.Trigger(this, TimeSelectedEventArgs(this.Time))

/// Force ListView to recycle rows because DataTemplateSelector disables it by default
type FabulousListView() =
    inherit ListView(ListViewCachingStrategy.RecycleElement)

type CustomEntryCell() =
    inherit EntryCell()

    let mutable oldText = ""

    let textChanged =
        Event<EventHandler<TextChangedEventArgs>, _>()

    [<CLIEvent>]
    member _.TextChanged = textChanged.Publish

    override this.OnPropertyChanged(propertyName) =
        if propertyName = EntryCell.TextProperty.PropertyName then
            textChanged.Trigger(this, TextChangedEventArgs(oldText, this.Text))

    override this.OnPropertyChanging(propertyName) =
        if propertyName = EntryCell.TextProperty.PropertyName then
            oldText <- this.Text
