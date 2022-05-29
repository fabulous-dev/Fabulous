namespace FabulousWeather

open Fabulous.SmallScalars
open Xamarin.Forms
open Fabulous.XamarinForms

module Styles =
    let AccentTextColor = Color.White
    let HourlyForecastStartColor = FabColor.fromHex "#22EDEDED"
    let HourlyForecastEndColor = FabColor.fromHex "#44EDEDED"
    let ColdStartColor = FabColor.fromHex "#BDE3FA"
    let ColdEndColor = FabColor.fromHex "#A5C9FD"
    let WarmStartColor = FabColor.fromHex "#F6CC66"
    let WarmEndColor = FabColor.fromHex "#FCA184"
    let NightStartColor = FabColor.fromHex "#172941"
    let NightEndColor = FabColor.fromHex "#3C6683"

    let CityNameFontSize = 30.
    let CurrentTemperatureFontSize = 100.
    let CurrentWeatherKindFontSize = 25.
    let CurrentDateFontSize = 15.

    let createStyleFor<'T when 'T :> BindableObject> setters =
        let style = Style(typeof<'T>)

        for property, value in setters do
            style.Setters.Add(Setter(Property = property, Value = value))

        style

    let addStyles (styles: Style list) (app: Application) =
        for style in styles do
            app.Resources.Add(style)

    let registerGlobalResources (app: Application) =
        app
        |> addStyles [ createStyleFor<Label> [ Label.TextColorProperty, box AccentTextColor ]
                       createStyleFor<Button> [ Button.TextColorProperty, box AccentTextColor ] ]

    let getStartGradientColor temp =
        if temp > 288<kelvin> then
            WarmStartColor
        else if temp < 199<kelvin> then
            NightStartColor
        else
            ColdStartColor

    let getEndGradientColor temp =
        if temp > 288<kelvin> then
            WarmEndColor
        else if temp < 199<kelvin> then
            NightEndColor
        else
            ColdEndColor

    let gradientStops temp =
        let coll =
            Xamarin.Forms.PancakeView.GradientStopCollection()

        coll.Add(PancakeView.GradientStop(Color = (getStartGradientColor temp).ToXFColor(), Offset = float32 0.))
        coll.Add(PancakeView.GradientStop(Color = (getEndGradientColor temp).ToXFColor(), Offset = float32 1.))
        coll

    let HourlyForecastGradientStops =
        let coll =
            Xamarin.Forms.PancakeView.GradientStopCollection()

        coll.Add(PancakeView.GradientStop(Color = HourlyForecastStartColor.ToXFColor(), Offset = float32 0.))
        coll.Add(PancakeView.GradientStop(Color = HourlyForecastEndColor.ToXFColor(), Offset = float32 1.))
        coll
