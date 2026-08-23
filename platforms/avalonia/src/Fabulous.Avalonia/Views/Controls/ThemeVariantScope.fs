namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThemeVariantScope =
    inherit IFabDecorator

module ThemeVariantScope =
    let WidgetKey = Widgets.register<ThemeVariantScope>()

    let RequestedThemeVariant =
        Attributes.definePropertyWithGetSet
            "Application_ThemeVariant"
            (fun target ->
                let target = target :?> ThemeVariantScope
                target.ActualThemeVariant)
            (fun target value ->
                let target = target :?> ThemeVariantScope
                target.RequestedThemeVariant <- value)

[<AutoOpen>]
module ThemeVariantScopeBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ThemeVariantScope widget.</summary>
        /// <param name="theme">The theme variant to use.</param>
        /// <param name="content">The content of the ThemeVariantScope.</param>
        static member ThemeVariantScope(theme: ThemeVariant, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabThemeVariantScope>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(ThemeVariantScope.RequestedThemeVariant.WithValue(theme)),
                    [| Decorator.ChildWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

type ThemeVariantScopeModifiers =

    /// <summary>Link a ViewRef to access the direct ThemeVariantScope control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabThemeVariantScope>, value: ViewRef<ThemeVariantScope>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
