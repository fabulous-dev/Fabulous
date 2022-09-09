namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IBorder =
    inherit Fabulous.Maui.IView

module Border =
    let WidgetKey = Widgets.register<Border>()

    let Content =
        Attributes.defineBindableWidget Border.ContentProperty
        
    let Padding = Attributes.defineBindableWithEquality<Thickness> Border.PaddingProperty
    
    let StrokeShapeWidget = Attributes.defineBindableWidget Border.StrokeShapeProperty
    
    let StrokeShapeString =
        Attributes.defineSimpleScalarWithEquality<string>
            "Border_StrokeShapeString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Border.StrokeShapeProperty)
                | ValueSome value ->
                    target.SetValue(
                        Border.StrokeShapeProperty,
                        StrokeShapeTypeConverter()
                            .ConvertFromInvariantString(value)
                    ))

       
    let Stroke = Attributes.defineBindableAppThemeColor Border.StrokeProperty
    
    let StrokeThickness = Attributes.defineBindableFloat Border.StrokeThicknessProperty
    
    let StrokeDashArrayString =
        Attributes.defineSimpleScalarWithEquality<string>
            "Border_StrokeDashArrayString"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
                | ValueSome string ->
                    target.SetValue(
                        Shape.StrokeDashArrayProperty,
                        DoubleCollectionConverter()
                            .ConvertFromInvariantString(string)
                    ))

    let StrokeDashArrayList =
        Attributes.defineSimpleScalarWithEquality<float array>
            "Border_StrokeDashArrayList"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
                | ValueSome points ->
                    let coll = DoubleCollection()
                    points |> Array.iter coll.Add
                    target.SetValue(Border.StrokeDashArrayProperty, coll))
    
    let StrokeDashOffset = Attributes.defineBindableFloat Border.StrokeDashOffsetProperty
    
    let StrokeLineCap = Attributes.defineBindableWithEquality<PenLineCap> Border.StrokeLineCapProperty
    
    let StrokeLineJoin = Attributes.defineBindableWithEquality<PenLineJoin> Border.StrokeLineJoinProperty

    let StrokeMiterLimit = Attributes.defineBindableFloat Border.StrokeMiterLimitProperty
        
[<AutoOpen>]
module BorderBuilders =
    type Fabulous.Maui.View with
        static member inline Border<'msg, 'marker when 'marker :> Fabulous.Maui.IView>
            (content: WidgetBuilder<'msg, 'marker>, light: FabColor, ?dark: FabColor)
            =
            WidgetHelpers.buildWidgets<'msg, 'marker>
                Border.WidgetKey,
                Border.Content.WithValue(content.Compile()),
                Border.Stroke.WithValue(AppTheme.create light dark)

[<Extension>]
type BorderModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IBorder>, value: Thickness) =
        this.AddScalar(Border.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IBorder>, value: float) =
        BorderModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #IBorder>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        BorderModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline fill<'msg, 'marker, 'contentMarker when 'marker :> IBorder and 'contentMarker :> IShape>
         (
             this: WidgetBuilder<'msg, 'marker>,
             content: WidgetBuilder<'msg, 'contentMarker>
         ) =
         this.AddWidget(Border.StrokeShapeWidget.WithValue(content.Compile()))

    /// <summary>Link a ViewRef to access the direct Switch control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IBorder>, value: ViewRef<Border>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
