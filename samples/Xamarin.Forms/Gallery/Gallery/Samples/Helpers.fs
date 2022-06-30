namespace Gallery.Samples

open System.IO
open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

type SampleProgram =
    { init: unit -> obj
      update: obj -> obj -> obj
      view: obj -> WidgetBuilder<obj, IView> }
    
type Sample =
    { Name: string
      Description: string
      SourceFilename: string
      SourceLink: string
      DocumentationName: string
      DocumentationLink: string
      SampleCode: string
      SampleCodeFormatted: unit -> WidgetBuilder<obj, IView>
      Program: SampleProgram }

module Helper =
    let createProgram (init: unit -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { init = init >> box
          update = (fun msg model -> update (unbox msg) (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view (unbox model)))) }
        
    type BlockType =
        | Normal
        | Comment
        | Type
        | Keyword
        | String
        | Property
        | Value
        | Message
    
    let tryRead (reader: StringReader) (current: char outref) =
        let value = reader.Read()
        if value = -1 then
            current <- Unchecked.defaultof<_>
            false
        else
            current <- char value
            true
    
    let peek (reader: StringReader) =
        let value = reader.Peek()
        char value
    
    let createFormattedLabelFromString (str: string) =
        use reader = new StringReader(str)
        let tokens = System.Collections.Generic.List<string * BlockType>()
        let sb = System.Text.StringBuilder()
        
        let mutable blockType = Normal
        let mutable current = Unchecked.defaultof<_>
        while (tryRead reader &current) do
            if current = '|' then
                let marker = peek reader
                
                let newBlockType, skip =
                    match marker with
                    | 'C' -> Comment, 2
                    | 'T' -> Type, 2
                    | 'K' -> Keyword, 2
                    | 'S' -> String, 2
                    | 'P' -> Property, 2
                    | 'V' -> Value, 2
                    | 'M' -> Message, 2
                    | _ -> blockType, -1 // Not a marker
                    
                // Discard block delimiters
                for i in 1..skip do
                    let _ = reader.Read()
                    ()
                    
                // The | char was not a change of block type, simply output it to the StringBuilder
                if blockType = newBlockType then
                    sb.Append(current) |> ignore
                    
                // We're changing block, add the accumulate string to the list
                elif sb.Length > 0 then
                    tokens.Add((sb.ToString(), blockType))
                    sb.Clear() |> ignore
                        
                blockType <- newBlockType
                
            elif current = ':' then
                let marker = peek reader
                
                // End block, add the accumulate string to the list
                if marker = '|' then
                    let _ = reader.Read()
                    tokens.Add((sb.ToString(), blockType))
                    sb.Clear() |> ignore
                    blockType <- Normal
                else
                    sb.Append(current) |> ignore
                
            else
                sb.Append(current) |> ignore
                
        if sb.Length > 0 then
            tokens.Add((sb.ToString(), blockType))
        
        FormattedLabel() {
            for str, blockType in tokens do
                let textColor =
                    match blockType with
                    | Normal -> FabColor.fromHex "#383838"
                    | Comment -> FabColor.fromHex "#3e851a"
                    | Type -> FabColor.fromHex "#449275"
                    | Keyword -> FabColor.fromHex "#3252d2"
                    | String -> FabColor.fromHex "#8a714b"
                    | Property -> FabColor.fromHex "#4092a2"
                    | Value -> FabColor.fromHex "#a03b6a"
                    | Message -> FabColor.fromHex "#6833b6"
                
                Span(str).textColor(textColor)
        }
        
    let cleanMarkersFromSampleCode (str: string) =
        str
            .Replace("|C:", "")
            .Replace("|T:", "")
            .Replace("|K:", "")
            .Replace("|P:", "")
            .Replace("|V:", "")
            .Replace("|S:", "")
            .Replace("|M:", "")
            .Replace("|:", "")
            .Trim('\n')
        
    let createSampleCodeFormatted (str: string) =
        let fn2 () =
            AnyView(createFormattedLabelFromString (str.Trim('\n')))
        fn2