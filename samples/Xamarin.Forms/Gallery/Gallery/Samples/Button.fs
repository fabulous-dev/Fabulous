namespace Gallery.Samples

open System.IO
open Fabulous.XamarinForms
open Xamarin.Forms

open type Fabulous.XamarinForms.View

module Button =
    type Model =
        { Count: int }
        
    type Msg =
        | Clicked
        
    let init () =
        { Count = 0 }
        
    let update msg model =
        match msg with
        | Clicked ->
            { model with Count = model.Count + 1 }
    
    let view model =
        VStack() {
            Label("Default Buttons")
                .font(namedSize = NamedSize.Subtitle)
            
            Frame(
                VStack() {
                    let text = if model.Count = 0 then "Click me!" else $"Click count: {model.Count}"
                    Button(text, Clicked)
                    
                    Button("Disabled button", Clicked)
                        .isEnabled(false)
                }
            )
                .hasShadow(false)
                .borderColor(Color.Gray.ToFabColor())
        }
        
    let sampleCode = """
|C:// Button with dynamic text:|
|T:Button:|(
    |K:if:| model.|P:Count:| = |V:0:| |K:then:|
        |S:"Click me!":|
    |K:else:|
        |S:$"Click count::| {model.|P:Count:|}|S:":|,
    |M:Clicked:|
)

|C:// Disabled button:|
|T:Button:|(|S:"Disabled button":|, |M:Clicked:|)
    .|T:isEnabled:|(|K:false:|)
"""

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
    
    let createFormattedLabelFromString (str: string) () =
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
        
    let sample =
        { Name = "Button"
          Description = "A button widget that reacts to touch events."
          SourceFilename = "Views/Controls/Button.fs"
          SourceLink = "https://github.com/fsprojects/Fabulous/blob/v2.0/src/Fabulous.XamarinForms/Views/Controls/Button.fs"
          DocumentationName = "Button API reference"
          DocumentationLink = "https://docs.fabulous.dev/v2/api/controls/button"
          SampleCode = cleanMarkersFromSampleCode sampleCode
          SampleCodeFormatted = Helper.createSampleCodeFormatted (createFormattedLabelFromString sampleCode)
          Program = Helper.createProgram init update view }