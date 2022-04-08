namespace FabulousWeather

open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

open System
open CityView

module App =
    type Model =
        { CurrentCityIndex: int
          Cities: CityData array }

    type Msg =
        | GoToPreviousCity
        | GoToNextCity
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

            return WeatherRefreshed(index, model)
        }
        |> Cmd.ofAsyncMsg

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

    let init () =
        let cmd =
            Cmd.batch [ for i in 0 .. initModel.Cities.Length - 1 -> getWeatherForCityAsync i initModel.Cities.[i].Name ]

        initModel, cmd

    let update msg model =
        match msg with
        | GoToPreviousCity ->
            let prevIndex = Math.Max(0, model.CurrentCityIndex - 1)

            { model with
                  CurrentCityIndex = prevIndex },
            Cmd.none

        | GoToNextCity ->
            let nextIndex = Math.Max(0, model.CurrentCityIndex + 1)

            { model with
                  CurrentCityIndex = nextIndex },
            Cmd.none

        | RequestRefresh index ->
            let updatedCities =
                model.Cities
                |> Array.mapi
                    (fun i c ->
                        if i = index then
                            { c with IsRefreshing = true }
                        else
                            c)

            let cmd =
                getWeatherForCityAsync index model.Cities.[index].Name

            { model with Cities = updatedCities }, cmd

        | WeatherRefreshed (index, data) ->
            let updatedCities =
                model.Cities
                |> Array.mapi
                    (fun i c ->
                        if i = index then
                            { c with
                                  IsRefreshing = false
                                  Data = Some data }
                        else
                            c)

            { model with Cities = updatedCities }, Cmd.none

    let previousNextView model =
        (Grid() {
            cityView
                model.CurrentCityIndex
                model.Cities.[model.CurrentCityIndex]
                (RequestRefresh model.CurrentCityIndex)

            if model.CurrentCityIndex > 0 then
                Button($"< {model.Cities.[model.CurrentCityIndex - 1].Name}", GoToPreviousCity)
                    .alignStartHorizontal()
                    .alignStartVertical()
                    .margin(20., 0., 0., 0.)

            if model.CurrentCityIndex < model.Cities.Length - 1 then
                Button($"{model.Cities.[model.CurrentCityIndex + 1].Name} >", GoToNextCity)
                    .alignEndHorizontal()
                    .alignStartVertical()
                    .margin(0., 0., 20., 0.)
         })
            .padding(0., 35., 0., 0.)

    let view model =
        let temperatureOfCurrentCity =
            model.Cities.[model.CurrentCityIndex].Data
            |> Option.map(fun d -> d.Temperature)
            |> Option.defaultValue 0<kelvin>

        Application(
            ContentPage(
                "Weather",
                //PancakeView(Styles.gradientStops
                ContentView(previousNextView model)
                    .backgroundColor(Styles.getStartGradientColor temperatureOfCurrentCity)
            )
                .ignoreSafeArea()
        )
    //.resources([
    //    LabelStyle()
    //        .textColor(Styles.AccentTextColor)

    //    ButtonStyle()
    //        .textColor(Styles.AccentTextColor)
    //])

    let program =
        Program.statefulApplicationWithCmd init update view
