namespace FabulousWeather

open System
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open WeatherApi
open Xamarin.Forms.PlatformConfiguration.iOSSpecific
open Xamarin.Forms

module AppStyles =
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

    let createLabel value =
        View.Label(
            text = value,
            fontSize = FontSize 100.,
            horizontalOptions = LayoutOptions.Center,
            textColor = MainTextColor
        )

module App =
    type WeatherData =
        { Date: DateTime
          Temperature: int<kelvin>
          WeatherKind: WeatherKind
          HourlyForecast: HourlyForecastValue list }
        
    type CityData = 
        { Name: string
          Data: WeatherData option
          IsRefreshing: bool }
        
    type Model =
        { CurrentCityName: string
          Cities: CityData list }
        
    type Msg =
        | CurrentCityChanged of cityName: string
        | RequestRefresh of cityName: string
        | WeatherRefreshed of cityName: string * WeatherData

    let getWeatherForCityAsync cityName =
        async {
            let! currentWeather = WeatherApi.getCurrentWeatherForCityAsync cityName
            let! hourlyForecast = WeatherApi.getHourlyForecastForCityAsync cityName
            
            let model = 
                { Date = currentWeather.Date
                  Temperature = currentWeather.Temperature
                  WeatherKind = currentWeather.WeatherKind
                  HourlyForecast = hourlyForecast.Values }
                
            return WeatherRefreshed (cityName, model)
        } |> Cmd.ofAsyncMsg
                
    let initModel =
        { CurrentCityName = "Seattle"
          Cities =
            [ { Name = "Seattle"
                Data = None
                IsRefreshing = true }
              { Name = "New York"
                Data = None
                IsRefreshing = true }
              { Name = "Paris"
                Data = None
                IsRefreshing = true } ] }
        
    let initial() =
        let cmd = Cmd.batch [
            for city in initModel.Cities ->
                getWeatherForCityAsync city.Name
        ]
        
        initModel, cmd

    let update msg model =
        match msg with
        | CurrentCityChanged cityName ->
            { model with CurrentCityName = cityName }, Cmd.none
            
        | RequestRefresh cityName ->
            let updatedCities =
                model.Cities
                |> List.map (fun c -> if c.Name = cityName then { c with IsRefreshing = true } else c)
            
            let cmd = getWeatherForCityAsync cityName
            
            { model with Cities = updatedCities }, cmd
            
        | WeatherRefreshed (cityName, data) ->
            let updatedCities =
                model.Cities
                |> List.map (fun c -> if c.Name = cityName then { c with IsRefreshing = false; Data = Some data } else c)
            
            { model with Cities = updatedCities }, Cmd.none

    let loadingView (cityName: string) =
        dependsOn cityName (fun _ cityName ->
            View.StackLayout([
                View.Label(
                    text = cityName.ToUpper(),
                    fontSize = Named NamedSize.Title,
                    horizontalOptions = LayoutOptions.Center,
                    padding = Thickness(0., 20., 0., 0.),
                    textColor = AppStyles.MainTextColor
                )
                View.ActivityIndicator(
                    horizontalOptions = LayoutOptions.Center,
                    verticalOptions = LayoutOptions.CenterAndExpand,
                    isRunning = true
                )
            ])
        )
        
    let loadedView (cityName: string, isRefreshing: bool, data: WeatherData) dispatch =
        dependsOn (cityName, isRefreshing, data) (fun _ (cityName, isRefreshing, data) ->
            // Event handlers
            let onRefreshing () = dispatch (RequestRefresh cityName)
            
            // UI
            View.RefreshView(
                isRefreshing = isRefreshing,
                refreshing = onRefreshing,
                content =
                    View.ScrollView(
                        View.Grid(
                            padding = Thickness(20., 0.),
                            rowdefs = [ Auto; Star; Auto; Auto; Auto; Absolute 135. ],
                            children = [
                                View.Label(
                                    text = cityName.ToUpper(),
                                    fontSize = FontSize 30.,
                                    horizontalOptions = LayoutOptions.Center,
                                    padding = Thickness(0., 20., 0., 0.),
                                    textColor = AppStyles.MainTextColor
                                )
                                
                                View.Image(
                                    source = Path (sprintf "%s.png" (cityName.Replace(" ", "_").ToLower())),
                                    opacity = 0.8, 
                                    verticalOptions = LayoutOptions.FillAndExpand
                                ).Row(1)
                                
                                View.Label(
                                    text = (Helpers.kelvinToRoundedFahrenheit data.Temperature).ToString() + "°",
                                    margin = Thickness(30., 0., 0., 0.),
                                    horizontalTextAlignment = TextAlignment.Center,
                                    textColor = AppStyles.MainTextColor,
                                    fontSize = FontSize 100.
                                ).Row(2)
                                
                                View.Label(
                                    text = data.WeatherKind.ToString().ToUpper(),
                                    fontSize = FontSize 25.,
                                    horizontalOptions = LayoutOptions.Center,
                                    margin = Thickness(0., 10., 0., 0.),
                                    textColor = AppStyles.MainTextColor
                                ).Row(3)
                                
                                View.Label(
                                    text = data.Date.ToString("dddd, MMMM dd, yyyy, h:mm tt").ToUpper(),
                                    fontSize = FontSize 15.,
                                    horizontalOptions = LayoutOptions.Center,
                                    textColor = AppStyles.MainTextColor
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
            )
        ) 
        
    let carouselViewRef = ViewRef<CustomCarouselView>()
    
    let view (model: Model) dispatch =
        let temperatureOfCurrentCity =
            model.Cities
            |> List.tryFind (fun c -> c.Name = model.CurrentCityName)
            |> Option.bind (fun c -> c.Data)
            |> Option.map (fun d -> d.Temperature)
            |> Option.defaultValue 0<kelvin>
            
        // Event handlers
        let onPageCreated (page: ContentPage) =
            Page.SetUseSafeArea(page, false)
        
        let onCarouselViewCurrentItemChanged (args: CurrentItemChangedEventArgs) =
            let viewElementHolder = args.CurrentItem :?> ViewElementHolder
            let cityName = viewElementHolder.ViewElement.GetAttributeKeyed(ViewAttributes.TagAttribKey) :?> string
            dispatch (CurrentCityChanged cityName)
        
        // UI
        View.ContentPage(
            created = onPageCreated,
            content =
                 View.PancakeView(
                     backgroundGradientStartColor = AppStyles.getStartGradientColor temperatureOfCurrentCity, 
                     backgroundGradientEndColor = AppStyles.getEndGradientColor temperatureOfCurrentCity,
                     content =
                         View.Grid([
                             View.CarouselView(
                                 ref = carouselViewRef,
                                 currentItemChanged = onCarouselViewCurrentItemChanged,
                                 verticalOptions = LayoutOptions.FillAndExpand,
                                 items = [
                                     for city in model.Cities ->
                                         View.ContentView(
                                            tag = city.Name,
                                            padding = (
                                                if Device.RuntimePlatform = Device.Android then
                                                    Thickness(0., 24., 0., 30.)
                                                else
                                                    Thickness(0., 44., 0., 40.)
                                            ),
                                            content =
                                                match city.Data with
                                                | Some data ->
                                                    loadedView (city.Name, city.IsRefreshing, data) dispatch
                                                | _  ->
                                                    loadingView city.Name
                                        )
                                 ]
                             )
                             View.IndicatorView(
                                  itemsSourceBy = carouselViewRef,
                                  verticalOptions = LayoutOptions.End,
                                  margin = Thickness(0., 0., 0., 20.)
                             )
                         ])
                 )
                
        )

    let program = 
        Program.mkProgram initial update view
        |> Program.withConsoleTrace

type App () as app = 
    inherit Application ()

    let runner = App.program |> XamarinFormsProgram.run app

#if DEBUG
    do runner.EnableLiveUpdate ()
#endif