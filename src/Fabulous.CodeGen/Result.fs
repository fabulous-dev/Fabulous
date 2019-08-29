namespace Fabulous.CodeGen

open System.IO

type InformationMessage = string
type WarningMessage = string
type ErrorMessage = string
type WorkflowResult<'T> = Result<'T * InformationMessage list * WarningMessage list, ErrorMessage list>
type ProgramResult = Result<InformationMessage list * WarningMessage list, ErrorMessage list>

module WorkflowResult =
    let bind f result =
        match result with
        | Error messages -> Error messages
        | Ok (data, informations, warnings) ->
            f data
            |> Result.map (fun (d, i, w) -> (d, List.append informations i, List.append warnings w))
            
    let map f result =
        match result with
        | Error messages -> Error messages
        | Ok (data, informations, warnings) -> Ok ((f data), informations, warnings)
        
    let tie f result =
        match result with
        | Error messages -> Error messages
        | Ok (data, informations, warnings) ->
            f data
            Ok (data, informations, warnings) 
        
    let toProgramResult result : ProgramResult =
        match result with
        | Error messages -> Error messages
        | Ok (_, informations, warnings) ->
            Ok (informations, warnings)
            
    let debug isDebugMode fileName =
        tie (fun d ->
            if isDebugMode then
                let json = Json.serialize d
                File.WriteAllText(fileName, json)
        )
            
    let ok data =
        Ok (data, [], [])
        
    let okWarnings data informations warnings =
        Ok (data, informations, warnings)
        
    let error messages =
        Error messages

