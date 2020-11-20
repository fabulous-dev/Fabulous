namespace FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System
open WeatherApi

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

    // View to display when loading the weather data of the city
    let loadingView (cityName: string) =
        dependsOn cityName (fun _ cityName ->
            View.StackLayout([
                View.Label(
                    text = cityName.ToUpper(),
                    fontSize = FontSize.fromNamedSize NamedSize.Title,
                    horizontalOptions = LayoutOptions.Center,
                    padding = Thickness(0., 20., 0., 0.)
                )
                View.ActivityIndicator(
                    isRunning = true,
                    horizontalOptions = LayoutOptions.Center,
                    verticalOptions = LayoutOptions.CenterAndExpand
                )
            ])
        )

    // View to display once we have data
    let loadedView (cityIndex: int, cityName: string, isRefreshing: bool, data: WeatherData) requestRefresh =
        dependsOn (cityName, isRefreshing, data) (fun _ (cityName, isRefreshing, data) ->

            // Use RefreshView if available
            let containerView content =
                // Event handlers
                let onRefreshing () = requestRefresh cityIndex

                match Device.RuntimePlatform with
                | Device.Android | Device.iOS ->
                    View.RefreshView(
                        isRefreshing = isRefreshing,
                        refreshing = onRefreshing,
                        content =
                            View.ScrollView(
                                content
                            )
                    )
                | _ ->
                    content

            // UI
            containerView <|
                View.Grid(
                    padding = Thickness(20., 0.),
                    rowdefs = [ Auto; Star; Auto; Auto; Auto; Absolute 135. ],
                    children = [
                        View.Label(
                            text = cityName.ToUpper(),
                            fontSize = Styles.CityNameFontSize,
                            horizontalOptions = LayoutOptions.Center,
                            padding = Thickness(0., 20., 0., 0.)
                        )

                        View.Image(
                            source = Image.fromPath (sprintf "%s.png" (cityName.Replace(" ", "_").ToLower())),
                            aspect = Aspect.AspectFit,
                            opacity = 0.8,
                            verticalOptions = LayoutOptions.FillAndExpand
                        ).Row(1)

                        View.Label(
                            text = (Helpers.kelvinToRoundedFahrenheit data.Temperature).ToString() + "°",
                            margin = Thickness(30., 0., 0., 0.),
                            horizontalTextAlignment = TextAlignment.Center,
                            fontSize = Styles.CurrentTemperatureFontSize
                        ).Row(2)

                        View.Label(
                            text = data.WeatherKind.ToString().ToUpper(),
                            fontSize = Styles.CurrentWeatherKindFontSize,
                            horizontalOptions = LayoutOptions.Center,
                            margin = Thickness(0., 10., 0., 0.)
                        ).Row(3)

                        View.Label(
                            text = data.Date.ToString("dddd, MMMM dd, yyyy, h:mm tt").ToUpper(),
                            fontSize = Styles.CurrentDateFontSize,
                            horizontalOptions = LayoutOptions.Center
                        ).Row(4)

                        View.StackLayout(
                            orientation = StackOrientation.Horizontal,
                            horizontalOptions = LayoutOptions.Center,
                            margin = Thickness(0., 30., 0., 0.),
                            children = [
                                for forecast in data.HourlyForecast ->
                                    View.PancakeView(
                                        width = 50.,
                                        height = 130.,
                                        padding = Thickness(10.),
                                        backgroundGradientStops = Styles.HourlyForecastGradientStops,
                                        backgroundGradientStartPoint = Point(0., 0.),
                                        backgroundGradientEndPoint = Point(1., 1.),
                                        cornerRadius = CornerRadius(10.),
                                        content =
                                            View.StackLayout(
                                                spacing = 0.,
                                                children = [
                                                    View.Label(
                                                        text = forecast.Date.ToString("h tt").ToLower(),
                                                        horizontalTextAlignment = TextAlignment.Center
                                                    )
                                                    View.Image(
                                                        source = Image.fromPath (sprintf "http://openweathermap.org/img/wn/%s@2x.png" forecast.IconName),
                                                        aspect = Aspect.AspectFit,
                                                        horizontalOptions = LayoutOptions.Center,
                                                        verticalOptions = LayoutOptions.CenterAndExpand
                                                    )
                                                    View.Label(
                                                        text = (Helpers.kelvinToRoundedFahrenheit forecast.Temperature).ToString() + "°",
                                                        horizontalTextAlignment = TextAlignment.Center
                                                    )
                                                ]
                                            )
                                    )
                            ]
                        ).Row(5)
                    ]
                )
            )

    let cityView index city requestRefresh =
        View.ContentView(
            tag = index,
            padding = (
                if Device.RuntimePlatform = Device.Android then
                    Thickness(0., 24., 0., 30.)
                else
                    Thickness(0., 44., 0., 40.)
            ),
            content =
                match city.Data with
                | Some data ->
                    loadedView (index, city.Name, city.IsRefreshing, data) requestRefresh
                | _  ->
                    loadingView city.Name
        )