namespace FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open System
open WeatherApi
open Xamarin.Forms

open type Fabulous.XamarinForms.View

module CityView =
    type WeatherData =
        { Date: DateTime
          Temperature: int<kelvin>
          WeatherKind: WeatherKind
          HourlyForecast: HourlyForecastValue list }

    type CityData =
        { Name: string
          Data: WeatherData option
          IsRefreshing: bool }

    let loadingView (cityName: string) =
        VStack() {
            Label(cityName.ToUpper())
                .font(namedSize = NamedSize.Title)
                .centerTextHorizontal()
                .padding(0., 20., 0., 0.)

            ActivityIndicator(true)
                .centerHorizontal()
                .centerVertical(expand = true)
        }

    let loadedView (index, cityName: string, isRefreshing, data) onRefreshing =
        let sanitizedCityName = cityName.Replace(" ", "_").ToLower()

        RefreshView(
            isRefreshing,
            onRefreshing,
            ScrollView(
                VStack() {
                    Label(cityName.ToUpper())
                        .font(Styles.CityNameFontSize)
                        .centerTextHorizontal()

                    Image(Aspect.AspectFit, $"{sanitizedCityName}.png")
                        .opacity(0.8)

                    Label($"{Helpers.kelvinToRoundedFahrenheit data.Temperature}°")
                        .font(Styles.CurrentTemperatureFontSize)
                        .centerTextHorizontal()
                        .margin(Thickness(30., 0., 0., 0.))

                    Label(data.WeatherKind.ToString().ToUpper())
                        .font(Styles.CurrentWeatherKindFontSize)
                        .centerTextHorizontal()
                        .margin(Thickness(0., 10., 0., 0.))

                    Label(
                        data
                            .Date
                            .ToString("dddd, MMMM dd, yyyy, h:mm tt")
                            .ToUpper()
                    )
                        .font(Styles.CurrentDateFontSize)
                        .centerTextHorizontal()

                    (HStack() {
                        for forecast in data.HourlyForecast do
                            ContentView(
                                PancakeView(
                                    Styles.HourlyForecastGradientStops,
                                    VStack() {
                                        Label(forecast.Date.ToString("h tt").ToLower())
                                            .centerTextHorizontal()

                                        Image(
                                            Aspect.AspectFit,
                                            Uri($"http://openweathermap.org/img/wn/{forecast.IconName}@2x.png")
                                        )
                                            .centerHorizontal()
                                            .centerVertical(expand = true)

                                        Label($"{Helpers.kelvinToRoundedFahrenheit forecast.Temperature}°")
                                            .centerTextHorizontal()
                                    }
                                )
                            )
                                .background(Styles.HourlyForecastStartColor)
                     })
                        .centerHorizontal()
                        .margin(0., 30., 0., 0.)
                }
            )
        )

    let cityView (index: int) (city: CityData) onRefreshing =
        let padding =
            if Device.RuntimePlatform = Device.Android then
                Thickness(0., 24., 0., 30.)
            else
                Thickness(0., 0., 0., 40.)

        match city.Data with
        | Some data ->
            ContentView(loadedView(index, city.Name, city.IsRefreshing, data) onRefreshing)
                .padding(padding)
        | None ->
            ContentView(loadingView city.Name)
                .padding(padding)
