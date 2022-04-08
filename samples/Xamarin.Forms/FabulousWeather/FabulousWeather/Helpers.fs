namespace FabulousWeather

open System

[<Measure>]
type kelvin

[<Measure>]
type fahrenheit

module Helpers =
    let kelvinToRoundedFahrenheit K =
        let realValue =
            (9. / 5. * (float(K - 273<kelvin>)) + 32.)

        let roundedValue = Math.Round realValue |> int
        roundedValue * 1<fahrenheit>

    let unixTimestampToDateTime (timestamp: int) =
        let epoch =
            DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)

        epoch.AddSeconds(float timestamp).ToLocalTime()
