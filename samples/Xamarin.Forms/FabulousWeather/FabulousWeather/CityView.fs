namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System
open WeatherApi
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
        VerticalStackLayout([
            Label(cityName.ToUpper())
                .font(NamedSize.Title)
                .centerTextHorizontally()
                .padding(Thickness(0., 20., 0., 0.))

            ActivityIndicator(true)
                .centerHorizontally()
                .verticalOptions(LayoutOptions.CenterAndExpand)
        ])

    let loadedView (index, cityName: string, isRefreshing, data) onRefreshing =
        let sanitizedCityName = cityName.Replace(" ", "_").ToLower()

        RefreshView(isRefreshing, onRefreshing,
            ScrollView(
                Grid(
                    coldefs = [ Star ],
                    rowdefs = [ Auto; Star; Auto; Auto; Auto; Absolute 135. ],
                    children = [
                        Label(cityName.ToUpper())
                            .font(Styles.CityNameFontSize)
                            .centerTextHorizontally()
                            .padding(Thickness(0., 20., 0., 0.))

                        Image($"{sanitizedCityName}.png", Aspect.AspectFit)
                            .opacity(0.8)
                            .verticalOptions(LayoutOptions.FillAndExpand)
                            .gridRow(1)

                        Label($"{Helpers.kelvinToRoundedFahrenheit data.Temperature}°")
                            .font(Styles.CurrentTemperatureFontSize)
                            .centerTextHorizontally()
                            .margin(Thickness(30., 0., 0., 0.))
                            .gridRow(2)

                        Label(data.WeatherKind.ToString().ToUpper())
                            .font(Styles.CurrentWeatherKindFontSize)
                            .centerTextHorizontally()
                            .margin(Thickness(0., 10., 0., 0.))
                            .gridRow(3)

                        Label(data.Date.ToString("dddd, MMMM dd, yyyy, h:mm tt").ToUpper())
                            .font(Styles.CurrentDateFontSize)
                            .centerTextHorizontally()
                            .gridRow(4)

                        HorizontalStackLayout([
                            for forecast in data.HourlyForecast ->
                                PancakeView(
                                    Styles.HourlyForecastGradientStops,
                                    VerticalStackLayout([
                                        Label(forecast.Date.ToString("h tt").ToLower())
                                            .centerTextHorizontally()

                                        Image($"http://openweathermap.org/img/wn/{forecast.IconName}@2x.png", Aspect.AspectFit)
                                            .centerHorizontally()
                                            .centerVertically(expand = true)

                                        Label($"{Helpers.kelvinToRoundedFahrenheit forecast.Temperature}°")
                                            .centerTextHorizontally()
                                    ])
                                )
                        ])
                            .centerHorizontally()
                            .margin(Thickness(0., 30., 0., 0.))
                            .gridRow(5)
                    ]
                )

            )
        )

    let cityView (index: int) (city: CityData) onRefreshing =
        (match city.Data with
         | Some data ->
             ContentView(
                 loadedView (index, city.Name, city.IsRefreshing, data) onRefreshing
             )
         | None ->
             ContentView(
                 loadingView city.Name
             )
        )
            .padding(
                if Device.RuntimePlatform = Device.Android then
                    Thickness(0., 24., 0., 30.)
                else
                    Thickness(0., 44., 0., 40.)
            )