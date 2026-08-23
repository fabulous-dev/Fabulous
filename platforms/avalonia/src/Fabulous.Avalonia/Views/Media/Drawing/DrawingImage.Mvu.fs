namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

module MvuDrawingImage =
    let Invalidated =
        Attributes.Mvu.defineEventNoArg "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)


type MvuDrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabDrawingImage>, msg: 'msg) =
        this.AddScalar(MvuDrawingImage.Invalidated.WithValue(MsgValue msg))
