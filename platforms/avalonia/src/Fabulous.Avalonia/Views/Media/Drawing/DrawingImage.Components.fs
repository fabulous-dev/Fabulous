namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentDrawingImage =
    let Invalidated =
        Attributes.Component.defineEventNoArg "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)

type ComponentDrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabDrawingImage>, msg: unit -> unit) =
        this.AddScalar(ComponentDrawingImage.Invalidated.WithValue(msg))
