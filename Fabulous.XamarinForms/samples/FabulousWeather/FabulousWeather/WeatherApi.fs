namespace FabulousWeather

open System
open FSharp.Data

module WeatherApi =
    // Get an API key from https://openweathermap.org/appid and replace the value here
    let apiKey = "1c2085c0fef3730151d71b9d0a5da530"
    
    let baseEndpoint = "http://api.openweathermap.org/data/2.5"
    let currentWeatherEndpoint = sprintf "%s/weather?appid=%s" baseEndpoint apiKey
    let hourlyForecastEndpoint = sprintf "%s/forecast?appid=%s" baseEndpoint apiKey
    
    type CurrentWeatherApi = JsonProvider<"WeatherSamples/current-weather.json">
    type HourlyForecastApi = JsonProvider<"WeatherSamples/hourly-forecast.json">
    
    type WeatherKind =
        | Thunderstorm
        | Drizzle
        | Rain
        | Snow
        | Mist
        | Smoke
        | Haze
        | Dust
        | Fog
        | Sand
        | Ash
        | Squall
        | Tornado
        | Clear
        | Clouds
        | Unknown of string

        /// Parse the strings of the API to ensure having a valid value
        static member Parse str =
            match str with
            | "Thunderstorm" -> Thunderstorm
            | "Drizzle" -> Drizzle
            | "Rain" -> Rain
            | "Snow" -> Snow
            | "Mist" -> Mist
            | "Smoke" -> Smoke
            | "Haze" -> Haze
            | "Dust" -> Dust
            | "Fog" -> Fog
            | "Sand" -> Sand
            | "Ash" -> Ash
            | "Squall" -> Squall
            | "Tornado" -> Tornado
            | "Clear" -> Clear
            | "Clouds" -> Clouds
            | kind -> Unknown kind 
    
    type CurrentWeather =
        { Date: DateTime
          Temperature: int<kelvin>
          WeatherKind: WeatherKind }
        
    type HourlyForecastValue =
        { Date: DateTime
          Temperature: int<kelvin>
          WeatherKind: WeatherKind
          IconName: string }
        
    type HourlyForecast =
        { Values: HourlyForecastValue list }

    let getCurrentWeatherForCityAsync name = async {
        let! currentWeather = CurrentWeatherApi.AsyncLoad (sprintf "%s&q=%s" currentWeatherEndpoint name)
        return
            { Date = currentWeather.Dt |> Helpers.unixTimestampToDateTime
              WeatherKind = currentWeather.Weather.[0].Main |> WeatherKind.Parse
              Temperature = (int currentWeather.Main.Temp) * 1<kelvin> }
    }
    
    let getHourlyForecastForCityAsync name = async {
        let! hourlyForecast = HourlyForecastApi.AsyncLoad (sprintf "%s&q=%s" hourlyForecastEndpoint name)
        return
            { Values =
                hourlyForecast.List
                |> Array.toList
                |> List.take 5
                |> List.map (fun v ->
                    { Date = v.Dt |> Helpers.unixTimestampToDateTime
                      Temperature = (int v.Main.Temp) * 1<kelvin>
                      WeatherKind = v.Weather.[0].Main |> WeatherKind.Parse
                      IconName = v.Weather.[0].Icon } ) }
    }
        
