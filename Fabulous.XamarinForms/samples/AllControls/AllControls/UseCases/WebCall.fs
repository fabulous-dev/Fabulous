namespace AllControls.UseCases

open Fabulous
open Fabulous.XamarinForms
open FSharp.Data

module WebCall =
    type Msg =
        | ReceivedDataSuccess of string option
        | ReceivedDataFailure of string option
        | ReceiveData
        
    type CmdMsg =
        | GetWebData
    
    type Model =
        { IsRunning: bool
          ReceivedData: bool
          WebCallData: string option }
    
    let getWebData () =
        async {
            do! Async.SwitchToThreadPool()
            let! response = 
                Http.AsyncRequest(url="https://api.myjson.com/bins/1ecasc", httpMethod="GET", silentHttpErrors=true)
            let r = 
                match response.StatusCode with
                | 200 -> Msg.ReceivedDataSuccess (Some (response.Body |> string))
                | _ -> Msg.ReceivedDataFailure (Some "Failed to get data")
            return r
        } |> Cmd.ofAsyncMsg
        
    let mapToCmd cmdMsg =
        match cmdMsg with
        | GetWebData -> getWebData ()
    
    let init () =
        { IsRunning = false
          ReceivedData = false
          WebCallData = None }

    let update msg model =
        match msg with
        | ReceiveData ->
            {model with IsRunning=true}, [GetWebData]
        | ReceivedDataFailure value ->
            {model with ReceivedData=false; IsRunning=false; WebCallData = value}, []
        | ReceivedDataSuccess value ->
            {model with ReceivedData=true; IsRunning=false; WebCallData = value}, []
    
    let view model dispatch =
        let data =
            match model.WebCallData with
            | Some v -> v
            | None -> ""

        View.ContentPage(
            View.StackLayout(
                children = [
                    View.Button(text="Get Data", command = (fun () -> dispatch ReceiveData))
                    View.ActivityIndicator(isRunning = model.IsRunning)
                    View.Label(text = data)
                ]
            )
        )

