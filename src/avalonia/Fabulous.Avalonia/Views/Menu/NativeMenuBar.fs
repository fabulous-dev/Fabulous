namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabNativeMenuBar =
    inherit IFabTemplatedControl

module NativeMenuBar =

    let WidgetKey = Widgets.register<NativeMenuBar>()

[<AutoOpen>]
module NativeMenuBarBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenuBar widget.</summary>
        static member NativeMenuBar() =
            WidgetBuilder<'msg, IFabNativeMenuBar>(NativeMenuBar.WidgetKey)


type NativeMenuBarAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuBar>, value: ViewRef<NativeMenuBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
