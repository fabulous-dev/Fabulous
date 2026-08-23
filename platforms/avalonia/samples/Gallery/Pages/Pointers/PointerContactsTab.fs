namespace Gallery

open System
open Avalonia
open System.Collections.Generic
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Fabulous.StackAllocatedCollections.StackList

type PointerInfo() =
    member val Color = Unchecked.defaultof<Color> with get, set
    member val Point = Unchecked.defaultof<Point> with get, set

and PointerContacts() =
    inherit Control()

    let _allColors =
        [|

           Colors.Aqua
           Colors.Beige
           Colors.Chartreuse
           Colors.Coral
           Colors.Fuchsia
           Colors.Crimson
           Colors.Lavender
           Colors.Orange
           Colors.Orchid
           Colors.ForestGreen
           Colors.SteelBlue
           Colors.PapayaWhip
           Colors.PaleVioletRed
           Colors.Goldenrod
           Colors.Maroon
           Colors.Moccasin
           Colors.Navy
           Colors.Wheat
           Colors.Violet
           Colors.Sienna
           Colors.Indigo
           Colors.Honeydew |]

    let _pointers = Dictionary<IPointer, PointerInfo>()

    do base.ClipToBounds <- true

    member this.UpdatePointer(e: PointerEventArgs) =
        let hasValue, info = _pointers.TryGetValue(e.Pointer)

        if hasValue then
            info.Point <- e.GetPosition(this)
            base.InvalidateVisual()
        else if (e.RoutedEvent = InputElement.PointerMovedEvent) then
            ()
        else
            let colors =
                _allColors
                |> Array.except(_pointers |> Seq.map(fun (KeyValue(_, v)) -> v.Color))

            let color = colors[Random().Next(0, colors.Length - 1)]
            let info = PointerInfo()
            info.Color <- color
            _pointers[e.Pointer] <- info

    override this.OnPointerPressed(e: PointerPressedEventArgs) =
        this.UpdatePointer(e)
        e.Pointer.Capture(this)
        e.Handled <- true
        base.OnPointerPressed(e)

    override this.OnPointerMoved(e: PointerEventArgs) =
        this.UpdatePointer(e)
        e.Handled <- true
        base.OnPointerMoved(e)

    override this.OnPointerReleased(e: PointerReleasedEventArgs) =
        _pointers.Remove(e.Pointer) |> ignore
        e.Handled <- true
        base.InvalidateVisual()

    override this.OnPointerCaptureLost(e: PointerCaptureLostEventArgs) =
        _pointers.Remove(e.Pointer) |> ignore
        base.InvalidateVisual()

    override this.Render(context: DrawingContext) =
        context.FillRectangle(Brushes.Transparent, Rect(Unchecked.defaultof<_>, this.Bounds.Size))

        for KeyValue(_, pt) in _pointers do
            let brush = ImmutableSolidColorBrush(pt.Color)
            context.DrawEllipse(brush, null, pt.Point, 75., 75.)

type IFabPointerContacts =
    inherit IFabControl

module PointerContacts =
    let WidgetKey = Widgets.register<PointerContacts>()

[<AutoOpen>]
module PointerContactsTabBuilders =
    type Fabulous.Avalonia.View with

        static member PointerContactsTab() =
            WidgetBuilder<'msg, IFabPointerContacts>(PointerContacts.WidgetKey)
