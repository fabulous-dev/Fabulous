namespace FabulousWeather

open Fabulous.XamarinForms.InputTypes
open Xamarin.Forms

module Styles =
    let AccentTextColor = Color.White
    let HourlyForecastStartColor = Color.FromHex("#22EDEDED")
    let HourlyForecastEndColor = Color.FromHex("#44EDEDED")
    let ColdStartColor = Color.FromHex("#BDE3FA")
    let ColdEndColor = Color.FromHex("#A5C9FD")
    let WarmStartColor = Color.FromHex("#F6CC66")
    let WarmEndColor  = Color.FromHex("#FCA184")
    let NightStartColor = Color.FromHex("#172941")
    let NightEndColor = Color.FromHex("#3C6683")
    
    let CityNameFontSize = FontSize 30.
    let CurrentTemperatureFontSize = FontSize 100.
    let CurrentWeatherKindFontSize = FontSize 25.
    let CurrentDateFontSize = FontSize 15.
    
    let createStyleFor<'T when 'T :> BindableObject> setters =
        let style = Style(typeof<'T>)
        for (property, value) in setters do
            style.Setters.Add(Setter(Property = property, Value = value))
        style
        
    let addStyles (styles: Style list) (app: Application) =
        for style in styles do
            app.Resources.Add(style)
    
    let registerGlobalResources (app: Application) =
        app |> addStyles [
            createStyleFor<Label> [
                Label.TextColorProperty, box AccentTextColor
            ]
            createStyleFor<Button> [
                Button.TextColorProperty, box AccentTextColor
            ]
        ]
    
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