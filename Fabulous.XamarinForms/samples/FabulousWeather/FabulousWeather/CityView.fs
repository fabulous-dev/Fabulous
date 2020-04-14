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

    let loadingView (cityName: string) =
        dependsOn cityName (fun _ cityName ->
            View.StackLayout([
                View.Label(
                    text = cityName.ToUpper(),
                    fontSize = Named NamedSize.Title,
                    horizontalOptions = LayoutOptions.Center,
                    padding = Thickness(0., 20., 0., 0.),
                    textColor = Styles.MainTextColor
                )
                View.ActivityIndicator(
                    horizontalOptions = LayoutOptions.Center,
                    verticalOptions = LayoutOptions.CenterAndExpand,
                    isRunning = true
                )
            ])
        )
    
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
                            fontSize = FontSize 30.,
                            horizontalOptions = LayoutOptions.Center,
                            padding = Thickness(0., 20., 0., 0.),
                            textColor = Styles.MainTextColor
                        )
                            
                        View.Image(
                            source = Path (sprintf "%s.png" (cityName.Replace(" ", "_").ToLower())),
                            aspect = Aspect.AspectFit,
                            opacity = 0.8, 
                            verticalOptions = LayoutOptions.FillAndExpand
                        ).Row(1)
                            
                        View.Label(
                            text = (Helpers.kelvinToRoundedFahrenheit data.Temperature).ToString() + "°",
                            margin = Thickness(30., 0., 0., 0.),
                            horizontalTextAlignment = TextAlignment.Center,
                            textColor = Styles.MainTextColor,
                            fontSize = FontSize 100.
                        ).Row(2)
                            
                        View.Label(
                            text = data.WeatherKind.ToString().ToUpper(),
                            fontSize = FontSize 25.,
                            horizontalOptions = LayoutOptions.Center,
                            margin = Thickness(0., 10., 0., 0.),
                            textColor = Styles.MainTextColor
                        ).Row(3)
                            
                        View.Label(
                            text = data.Date.ToString("dddd, MMMM dd, yyyy, h:mm tt").ToUpper(),
                            fontSize = FontSize 15.,
                            horizontalOptions = LayoutOptions.Center,
                            textColor = Styles.MainTextColor
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
                                        backgroundGradientStartColor = Color.FromHex("#22EDEDED"),
                                        backgroundGradientEndColor = Color.FromHex("#44EDEDED"),
                                        backgroundGradientAngle = 315,
                                        cornerRadius = CornerRadius(10.),
                                        content =
                                            View.StackLayout(
                                                spacing = 0.,
                                                children = [
                                                    View.Label(
                                                        text = forecast.Date.ToString("h tt").ToLower(),
                                                        textColor = Color.White,
                                                        horizontalTextAlignment = TextAlignment.Center
                                                    )
                                                    View.Image(
                                                        horizontalOptions = LayoutOptions.Center,
                                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                                        source = Path (sprintf "http://openweathermap.org/img/wn/%s@2x.png" forecast.IconName),
                                                        aspect = Aspect.AspectFit
                                                    )
                                                    View.Label(
                                                        text = (Helpers.kelvinToRoundedFahrenheit forecast.Temperature).ToString() + "°",
                                                        textColor = Color.White,
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