namespace FabulousWeather

open Xamarin.Forms

module Styles =
    let coldStartColor = Color.FromHex("#BDE3FA")
    let coldEndColor = Color.FromHex("#A5C9FD")
    let WarmStartColor = Color.FromHex("#F6CC66")
    let WarmEndColor  = Color.FromHex("#FCA184")
    let NightStartColor = Color.FromHex("#172941")
    let NightEndColor = Color.FromHex("#3C6683")
    let MainTextColor = Color.White
    let itemStartColor = Color.FromHex("#98FFFFFF")
    let itemEndColor = Color.FromHex("#60FFFFFF")
    
    let getStartGradientColor temp =
        if temp > 288<kelvin> then 
            WarmStartColor
        else if temp < 199<kelvin> then 
            NightStartColor
        else
            coldStartColor

    let getEndGradientColor temp =
        if temp > 288<kelvin> then 
            WarmEndColor
        else if temp < 199<kelvin> then 
            NightEndColor
        else
            coldEndColor