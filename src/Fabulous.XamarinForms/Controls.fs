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

type PositionChangedEventArgs(previousPosition: int, currentPosition: int) =
    inherit EventArgs()
    member _.PreviousPosition = previousPosition
    member _.CurrentPosition = currentPosition

/// Xamarin.Forms doesn't provide an event for selecting the time on a TimePicker, so we implement it
type FabulousTimePicker() =
    inherit TimePicker()

    let timeSelected =
        Event<EventHandler<TimeSelectedEventArgs>, _>()

    [<CLIEvent>]
    member _.TimeSelected = timeSelected.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)

        if propertyName = TimePicker.TimeProperty.PropertyName then
            timeSelected.Trigger(this, TimeSelectedEventArgs(this.Time))

/// Force ListView to recycle rows because DataTemplateSelector disables it by default
type FabulousListView() =
    inherit ListView(ListViewCachingStrategy.RecycleElement)

/// Xamarin.Forms doesn't provide an event for textChanged the EntryCell, so we implement it
type CustomEntryCell() =
    inherit EntryCell()

    let mutable oldText = ""

    let textChanged =
        Event<EventHandler<TextChangedEventArgs>, _>()

    [<CLIEvent>]
    member _.TextChanged = textChanged.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)

        if propertyName = EntryCell.TextProperty.PropertyName then
            textChanged.Trigger(this, TextChangedEventArgs(oldText, this.Text))

    override this.OnPropertyChanging(propertyName) =
        base.OnPropertyChanging(propertyName)

        if propertyName = EntryCell.TextProperty.PropertyName then
            oldText <- this.Text

/// Xamarin.Forms doesn't have an event args on the SelectedIndexChanged event, so we implement it
type CustomPicker() =
    inherit Picker()

    let mutable oldSelectedIndex = -1

    let selectedIndexChanged =
        Event<EventHandler<PositionChangedEventArgs>, _>()

    [<CLIEvent>]
    member _.CustomSelectedIndexChanged = selectedIndexChanged.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)

        if propertyName = Picker.SelectedIndexProperty.PropertyName then
            selectedIndexChanged.Trigger(this, PositionChangedEventArgs(oldSelectedIndex, this.SelectedIndex))

    override this.OnPropertyChanging(propertyName) =
        base.OnPropertyChanging(propertyName)

        if propertyName = Picker.SelectedIndexProperty.PropertyName then
            oldSelectedIndex <- this.SelectedIndex

type CustomNavigationPage() as this =
    inherit NavigationPage()

    let backNavigated = Event<EventHandler, EventArgs>()

    let mutable popCount = 0

    do this.Popped.Add(this.OnPopped)

    [<CLIEvent>]
    member _.BackNavigated = backNavigated.Publish

    member this.Push(page, ?animated) =
        let animated =
            match animated with
            | Some v -> v
            | None -> true

        this.PushAsync(page, animated) |> ignore

    member this.Pop() =
        popCount <- popCount + 1
        this.PopAsync() |> ignore

    member this.OnPopped(_: NavigationEventArgs) =
        // Only trigger BackNavigated if Fabulous isn't the one popping the page (e.g. user tapped back button)
        if popCount > 0 then
            popCount <- popCount - 1
        else
            backNavigated.Trigger(this, EventArgs())

/// FlyoutPage doesn't say if the Flyout is visible or not on IsPresentedChanged, so we implement it
type CustomFlyoutPage() as this =
    inherit FlyoutPage()

    let isPresentedChanged = Event<EventHandler<bool>, bool>()

    do this.IsPresentedChanged.Add(this.OnIsPresentedChanged)

    [<CLIEvent>]
    member _.CustomIsPresentedChanged = isPresentedChanged.Publish

    member _.OnIsPresentedChanged(_) =
        isPresentedChanged.Trigger(this, this.IsPresented)

type CustomApplication() =
    inherit Application()

    let start = Event<EventHandler, EventArgs>()
    let sleep = Event<EventHandler, EventArgs>()
    let resume = Event<EventHandler, EventArgs>()

    [<CLIEvent>]
    member _.Start = start.Publish

    override this.OnStart() = start.Trigger(this, EventArgs())

    [<CLIEvent>]
    member _.Sleep = sleep.Publish

    override this.OnSleep() = sleep.Trigger(this, EventArgs())

    [<CLIEvent>]
    member _.Resume = resume.Publish

    override this.OnResume() = resume.Trigger(this, EventArgs())
