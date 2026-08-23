namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Labs.Lottie
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabLottie =
    inherit IFabControl

module Lottie =

    let WidgetKey = Widgets.registerWithFactory(fun () -> Lottie(baseUri = null))

    let Path = Attributes.defineAvaloniaPropertyWithEquality Lottie.PathProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Lottie.StretchProperty

    let StretchDirection =
        Attributes.defineAvaloniaPropertyWithEquality Lottie.StretchDirectionProperty

    let RepeatCount =
        Attributes.defineAvaloniaPropertyWithEquality Lottie.RepeatCountProperty

    let PlayBackRate =
        Attributes.defineAvaloniaPropertyWithEquality Lottie.PlayBackRateProperty

    let AutoPlay = Attributes.defineAvaloniaPropertyWithEquality Lottie.AutoPlayProperty

[<AutoOpen>]
module LottieBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Create an AsyncImage widget.</summary>
        static member Lottie(path: string) =
            WidgetBuilder<'msg, IFabLottie>(Lottie.WidgetKey, Lottie.Path.WithValue(path))

type LottieModifiers =
    /// <summary>Sets the Stretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stretch value.</param>
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabLottie>, value: Stretch) =
        this.AddScalar(Lottie.Stretch.WithValue(value))

    /// <summary>Sets the StretchDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StretchDirection value.</param>
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabLottie>, value: StretchDirection) =
        this.AddScalar(Lottie.StretchDirection.WithValue(value))

    /// <summary>Sets the RepeatCount property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RepeatCount value.</param>
    [<Extension>]
    static member inline repeatCount(this: WidgetBuilder<'msg, #IFabLottie>, value: int) =
        this.AddScalar(Lottie.RepeatCount.WithValue(value))

    /// <summary>Sets the PlayBackRate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlayBackRate value.</param>
    [<Extension>]
    static member inline playBackRate(this: WidgetBuilder<'msg, #IFabLottie>, value: int) =
        this.AddScalar(Lottie.PlayBackRate.WithValue(value))

    /// <summary>Sets the AutoPlay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoPlay value.</param>
    [<Extension>]
    static member inline autoPlay(this: WidgetBuilder<'msg, #IFabLottie>, value: bool) =
        this.AddScalar(Lottie.AutoPlay.WithValue(value))

    /// <summary>Link a ViewRef to access the direct AsyncImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLottie>, value: ViewRef<Lottie>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
