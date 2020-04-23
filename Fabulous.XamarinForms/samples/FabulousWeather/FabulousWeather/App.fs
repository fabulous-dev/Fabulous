namespace FabulousWeather

open System
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open WeatherApi
open Xamarin.Forms.PlatformConfiguration.iOSSpecific
open Xamarin.Forms
open CityView

module App =
    type Model =
        { CurrentCityIndex: int
          Cities: CityData array }
        
    type Msg =
        | CurrentCityChanged of cityIndex: int
        | RequestRefresh of cityIndex: int
        | WeatherRefreshed of cityIndex: int * WeatherData

    let getWeatherForCityAsync index cityName =
        async {
            let! currentWeather = WeatherApi.getCurrentWeatherForCityAsync cityName
            let! hourlyForecast = WeatherApi.getHourlyForecastForCityAsync cityName
            
            let model = 
                { Date = currentWeather.Date
                  Temperature = currentWeather.Temperature
                  WeatherKind = currentWeather.WeatherKind
                  HourlyForecast = hourlyForecast.Values }
                
            return WeatherRefreshed (index, model)
        } |> Cmd.ofAsyncMsg
                
    let initModel =
        { CurrentCityIndex = 0
          Cities =
            [| { Name = "Seattle"
                 Data = None
                 IsRefreshing = true }
               { Name = "New York"
                 Data = None
                 IsRefreshing = true }
               { Name = "Paris"
                 Data = None
                 IsRefreshing = true } |] }
        
    let init() =
        let cmd = Cmd.batch [
            for i in 0 .. initModel.Cities.Length - 1 ->
                getWeatherForCityAsync i initModel.Cities.[i].Name
        ]
        
        initModel, cmd

    let update msg model =
        match msg with
        | CurrentCityChanged index ->
            { model with CurrentCityIndex = index }, Cmd.none
            
        | RequestRefresh index ->
            let updatedCities =
                model.Cities
                |> Array.mapi (fun i c -> if i = index then { c with IsRefreshing = true } else c)

            let cmd = getWeatherForCityAsync index model.Cities.[index].Name
            
            { model with Cities = updatedCities }, cmd
            
        | WeatherRefreshed (index, data) ->
            let updatedCities =
                model.Cities
                |> Array.mapi (fun i c -> if i = index then { c with IsRefreshing = false; Data = Some data } else c)
            
            { model with Cities = updatedCities }, Cmd.none

    // View using a Grid with Previous/Next button to switch between cities (for when CarouselView is not available)
    let previousNextView model dispatch =
        // Event handlers
        let onPreviousButtonClicked () =
            let previousIndex = Math.Max(0, model.CurrentCityIndex - 1)
            dispatch (CurrentCityChanged previousIndex)

        let onNextButtonClicked () =
            let nextIndex = Math.Min(model.CurrentCityIndex + 1, model.Cities.Length - 1)
            dispatch (CurrentCityChanged nextIndex)

        // UI
        View.Grid([
            yield cityView model.CurrentCityIndex model.Cities.[model.CurrentCityIndex] (RequestRefresh >> dispatch)
            
            if model.CurrentCityIndex > 0 then
                yield View.Button(
                    text = sprintf "< %s" model.Cities.[model.CurrentCityIndex - 1].Name,
                    command = onPreviousButtonClicked,
                    horizontalOptions = LayoutOptions.Start,
                    verticalOptions = LayoutOptions.Start
                )

            if model.CurrentCityIndex < model.Cities.Length - 1 then
                yield View.Button(
                    text = sprintf "%s >" model.Cities.[model.CurrentCityIndex + 1].Name,
                    command = onNextButtonClicked,
                    horizontalOptions = LayoutOptions.End,
                    verticalOptions = LayoutOptions.Start
                )
        ])
        
        
    // View using CarouselView (available on Android and iOS only)
    let indicatorRef = ViewRef<IndicatorView>()
    let carouselView model dispatch =
        // Event handlers
        let onCarouselViewCurrentItemChanged (_, currentItemOpt: ViewElement option) =
            match currentItemOpt with
            | None -> ()
            | Some item ->
                let cityIndex = item.GetAttributeKeyed(ViewAttributes.TagAttribKey) :?> int
                dispatch (CurrentCityChanged cityIndex)
            
        // UI
        View.Grid([
            View.CarouselView(
                indicatorView = indicatorRef,
                currentItemChanged = onCarouselViewCurrentItemChanged,
                verticalOptions = LayoutOptions.FillAndExpand,
                items = [
                    for i in 0 .. model.Cities.Length - 1 ->
                        cityView i model.Cities.[i] (RequestRefresh >> dispatch)
                ]
            )
            View.IndicatorView(
                ref = indicatorRef,
                verticalOptions = LayoutOptions.End,
                margin = Thickness(0., 0., 0., 20.)
            )
        ])
    
    // Root view
    let view (model: Model) dispatch =
        let temperatureOfCurrentCity =
            model.Cities.[model.CurrentCityIndex].Data
            |> Option.map (fun d -> d.Temperature)
            |> Option.defaultValue 0<kelvin>
            
        // Event handlers
        let onPageCreated (page: ContentPage) =
            Page.SetUseSafeArea(page, false)
        
        // UI
        View.ContentPage(
            created = onPageCreated,
            content =
                 View.PancakeView(
                     backgroundGradientStartColor = Styles.getStartGradientColor temperatureOfCurrentCity, 
                     backgroundGradientEndColor = Styles.getEndGradientColor temperatureOfCurrentCity,
                     content =
                         match Device.RuntimePlatform with
                         | Device.Android | Device.iOS -> carouselView model dispatch
                         | _ -> previousNextView model dispatch
                 )
        )

    let program = 
        Program.mkProgram init update view
        |> Program.withConsoleTrace

type App () as app = 
    inherit Application ()

    do Styles.registerGlobalResources app
    
    let runner = App.program |> XamarinFormsProgram.run app

#if DEBUG
    //do runner.EnableLiveUpdate ()
#endif