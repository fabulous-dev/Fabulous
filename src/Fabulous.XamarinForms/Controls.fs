namespace Fabulous.XamarinForms

open System
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

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

type SizeAllocatedEventArgs =
    { Width: float
      Height: float }

/// Set UseSafeArea to true by default because View DSL only shows `ignoreSafeArea`
type FabulousContentPage() as this =
    inherit ContentPage()
    do this.On<iOS>().SetUseSafeArea(true) |> ignore

    let sizeAllocated = Event<EventHandler<SizeAllocatedEventArgs>, _>()

    [<CLIEvent>] member __.SizeAllocated = sizeAllocated.Publish

    override this.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(this, { Width = width; Height = height })