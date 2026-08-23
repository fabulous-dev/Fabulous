namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabExperimentalAcrylicMaterial =
    inherit IFabElement

module ExperimentalAcrylicMaterial =
    let WidgetKey = Widgets.register<ExperimentalAcrylicMaterial>()

    let TintColor =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.TintColorProperty

    let BackgroundSource =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.BackgroundSourceProperty

    let TintOpacity =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.TintOpacityProperty

    let MaterialOpacity =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.MaterialOpacityProperty

    let PlatformTransparencyCompensationLevel =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty

    let FallbackColor =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.FallbackColorProperty

[<AutoOpen>]
module ExperimentalAcrylicMaterialBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ExperimentalAcrylicMaterial widget.</summary>
        static member ExperimentalAcrylicMaterial() =
            WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>(ExperimentalAcrylicMaterial.WidgetKey)

type ExperimentalAcrylicMaterialModifiers =

    /// <summary>Sets the TintColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TintColor value.</param>
    [<Extension>]
    static member inline tintColor(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: Color) =
        this.AddScalar(ExperimentalAcrylicMaterial.TintColor.WithValue(value))

    /// <summary>Sets the BackgroundSource property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundSource value.</param>
    [<Extension>]
    static member inline backgroundSource(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: AcrylicBackgroundSource) =
        this.AddScalar(ExperimentalAcrylicMaterial.BackgroundSource.WithValue(value))

    /// <summary>Sets the TintOpacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TintOpacity value.</param>
    [<Extension>]
    static member inline tintOpacity(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.TintOpacity.WithValue(value))

    /// <summary>Sets the MaterialOpacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaterialOpacity value.</param>
    [<Extension>]
    static member inline materialOpacity(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.MaterialOpacity.WithValue(value))

    /// <summary>Sets the PlatformTransparencyCompensationLevel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlatformTransparencyCompensationLevel value.</param>
    [<Extension>]
    static member inline platformTransparencyCompensationLevel(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevel.WithValue(value))

    /// <summary>Sets the FallbackColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FallbackColor value.</param>
    [<Extension>]
    static member inline fallbackColor(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: Color) =
        this.AddScalar(ExperimentalAcrylicMaterial.FallbackColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ExperimentalAcrylicMaterial control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>, value: ViewRef<ExperimentalAcrylicMaterial>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
