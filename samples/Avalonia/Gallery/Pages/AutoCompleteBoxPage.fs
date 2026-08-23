namespace Gallery

open System
open System.Diagnostics
open System.Threading
open System.Threading.Tasks
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

[<AutoOpen>]
module AutoCompleteBoxCommon =
    type StateData =
        { Name: string
          Abbreviation: string
          Capital: string }

        override this.ToString() = this.Name

    let usFederalStates =
        [ { Name = "Arkansas"
            Abbreviation = "AR"
            Capital = "Little Rock" }

          { Name = "California"
            Abbreviation = "CA"
            Capital = "Sacramento" }

          { Name = "Colorado"
            Abbreviation = "CO"
            Capital = "Denver" }

          { Name = "Connecticut"
            Abbreviation = "CT"
            Capital = "Hartford" }

          { Name = "Delaware"
            Abbreviation = "DE"
            Capital = "Dover" }

          { Name = "Florida"
            Abbreviation = "FL"
            Capital = "Tallahassee" }

          { Name = "Georgia"
            Abbreviation = "GA"
            Capital = "Atlanta" }

          { Name = "Hawaii"
            Abbreviation = "HI"
            Capital = "Honolulu" }

          { Name = "Idaho"
            Abbreviation = "ID"
            Capital = "Boise" }

          { Name = "Illinois"
            Abbreviation = "IL"
            Capital = "Springfield" }

          { Name = "Indiana"
            Abbreviation = "IN"
            Capital = "Indianapolis" }

          { Name = "Iowa"
            Abbreviation = "IA"
            Capital = "Des Moines" }

          { Name = "Kansas"
            Abbreviation = "KS"
            Capital = "Topeka" }

          { Name = "Kentucky"
            Abbreviation = "KY"
            Capital = "Frankfort" }

          { Name = "Louisiana"
            Abbreviation = "LA"
            Capital = "Baton Rouge" }

          { Name = "Maine"
            Abbreviation = "ME"
            Capital = "Augusta" }

          { Name = "Maryland"
            Abbreviation = "MD"
            Capital = "Annapolis" }

          { Name = "Massachusetts"
            Abbreviation = "MA"
            Capital = "Boston" }

          { Name = "Michigan"
            Abbreviation = "MI"
            Capital = "Lansing" }

          { Name = "Minnesota"
            Abbreviation = "MN"
            Capital = "St. Paul" }

          { Name = "Mississippi"
            Abbreviation = "MS"
            Capital = "Jackson" }

          { Name = "Missouri"
            Abbreviation = "MO"
            Capital = "Jefferson City" }

          { Name = "Montana"
            Abbreviation = "MT"
            Capital = "Helena" }

          { Name = "Nebraska"
            Abbreviation = "NE"
            Capital = "Lincoln" }

          { Name = "Nevada"
            Abbreviation = "NV"
            Capital = "Carson City" }

          { Name = "New Hampshire"
            Abbreviation = "NH"
            Capital = "Concord" }

          { Name = "New Jersey"
            Abbreviation = "NJ"
            Capital = "Trenton" }

          { Name = "New Mexico"
            Abbreviation = "NM"
            Capital = "Santa Fe" }

          { Name = "New York"
            Abbreviation = "NY"
            Capital = "Albany" }

          { Name = "North Carolina"
            Abbreviation = "NC"
            Capital = "Raleigh" }

          { Name = "North Dakota"
            Abbreviation = "ND"
            Capital = "Bismarck" }

          { Name = "Ohio"
            Abbreviation = "OH"
            Capital = "Columbus" }

          { Name = "Oklahoma"
            Abbreviation = "OK"
            Capital = "Oklahoma City" }

          { Name = "Oregon"
            Abbreviation = "OR"
            Capital = "Salem" }

          { Name = "Pennsylvania"
            Abbreviation = "PA"
            Capital = "Harrisburg" }

          { Name = "Rhode Island"
            Abbreviation = "RI"
            Capital = "Providence" }

          { Name = "South Carolina"
            Abbreviation = "SC"
            Capital = "Columbia" }

          { Name = "South Dakota"
            Abbreviation = "SD"
            Capital = "Pierre" }

          { Name = "Tennessee"
            Abbreviation = "TN"
            Capital = "Nashville" }

          { Name = "Texas"
            Abbreviation = "TX"
            Capital = "Austin" }

          { Name = "Utah"
            Abbreviation = "UT"
            Capital = "Salt Lake City" }

          { Name = "Vermont"
            Abbreviation = "VT"
            Capital = "Montpelier" }

          { Name = "Virginia"
            Abbreviation = "VA"
            Capital = "Richmond" }

          { Name = "Washington"
            Abbreviation = "WA"
            Capital = "Olympia" }

          { Name = "West Virginia"
            Abbreviation = "WV"
            Capital = "Charleston" }

          { Name = "Wisconsin"
            Abbreviation = "WI"
            Capital = "Madison" }

          { Name = "Wyoming"
            Abbreviation = "WY"
            Capital = "Cheyenne" } ]

    let contains (text: string) (term: string) =
        text.Contains(term, StringComparison.InvariantCultureIgnoreCase)

    /// allows searching US federal states asynchronously while cancelling running searches
    /// to ensure we only populate with the response of the latest request
    type UsFederalStateSearch(animateActiveInput) =
        let mutable running: CancellationTokenSource = null // enables cancelling any running search

        let isRunning () = running <> null

        /// cancels any running search
        let cancel () =
            if isRunning() then
                running.Cancel()
                running.Dispose()
                running <- null

        let simulateWork () =
            task {
                let randy = Random()
                let getDelay () = randy.Next(300, 3000)
                let mutable delay = getDelay()

                // wait for every uneven delay until we generate an even one
                while delay % 2 <> 0 do
                    do! Task.Delay(delay)
                    delay <- getDelay()

                do! Task.Delay(delay) // guarantee to wait a little bit
            }

        member this.SearchAsync (term: string) (cancellation: CancellationToken) : Task<obj seq> =
            task {
                cancellation.Register(cancel) |> ignore // register cancellation of running search when outer cancellation is requested
                cancel() // cancel any older running search
                running <- new CancellationTokenSource() // and create a new source for this one
                animateActiveInput(running.Token) // pass running search token to stop it when the search completes or is canceled
                do! simulateWork() // simulate a really sporadic remote search

                if isRunning() |> not || running.IsCancellationRequested then
                    cancel() // to stop animation
                    return Seq.empty
                else
                    cancel() // to stop animation

                    return
                        usFederalStates
                        |> Seq.filter(fun state -> contains state.Name term || contains state.Capital term)
                        |> Seq.cast<obj>
            }

    let getItemsAsync (_: string) (_: CancellationToken) : Task<seq<obj>> =
        task {
            return
                seq {
                    "Async Item 1"
                    "Async Item 2"
                    "Async Item 3"
                    "Async Product 1"
                    "Async Product 2"
                    "Async Product 3"
                }
        }

    let buildAllSentences () =
        [ "Hello world"
          "No this is Patrick"
          "Never gonna give you up"
          "How does one patch KDE2 under FreeBSD" ]
        |> List.map(fun x -> x.Split(' '))
        |> List.toArray

    let lastWordContains (searchText: string, item: string) =
        let words =
            if searchText = null then
                Array.Empty<string>()
            else
                searchText.Split(' ')

        let options = buildAllSentences() |> Array.collect id

        for i in 0 .. words.Length do
            if (i < words.Length) then
                let word = words[i]

                if (word <> null) then
                    for j in 0 .. options.Length do
                        if word <> null && j < options.Length then
                            let option = options[j]

                            if (option <> null) then

                                if (i = words.Length - 1) then

                                    options[j] <-
                                        if option.ToLower().Contains(word.ToLower()) then
                                            option
                                        else
                                            null

                                else
                                    let foo = option.Equals(word, StringComparison.InvariantCultureIgnoreCase)
                                    options[j] <- if foo then option else null

        options |> Array.exists(fun x -> x <> null && x = item)

    let appendWord (text: string, item: string) =
        if item <> null then
            let parts =
                if text <> null then
                    text.Split(' ')
                else
                    Array.Empty<string>()

            if (parts.Length = 0) then
                item
            else
                parts[parts.Length - 1] <- item
                String.Join(" ", parts)
        else
            String.Empty


    /// helps to animate an active remote search AutoCompleteBox
    module RemoteSearch =
        let input = ViewRef<AutoCompleteBox>()
        let heartBeat = ViewRef<Animation>()

        /// animates the input with the heartBeat until searchToken is cancelled
        let animate searchToken =
            heartBeat.Value.IterationCount <- IterationCount.Infinite
            heartBeat.Value.RunAsync(input.Value, searchToken) |> ignore

module AutoCompleteBoxPage =


    type Model =
        { IsOpen: bool
          SelectedItem: string
          Text: string
          AsyncSearchTerm: string
          UsStateSearch: UsFederalStateSearch
          Items: string seq
          UsFederalStates: StateData seq
          Custom: string seq }

    type Msg =
        | SearchTextChanged of string
        | AsyncSearchTermChanged of string
        | CustomAutoBoxLoaded of RoutedEventArgs

    let customAutoCompleteBoxRef = ViewRef<AutoCompleteBox>()

    let init () =
        { IsOpen = false
          Text = "Arkan"
          AsyncSearchTerm = ""
          UsStateSearch = UsFederalStateSearch(RemoteSearch.animate)
          SelectedItem = "Item 2"
          Items = [ "Item 1"; "Item 2"; "Item 3"; "Product 1"; "Product 2"; "Product 3" ]
          UsFederalStates = usFederalStates
          Custom = [] },
        Cmd.none

    let update msg model =
        match msg with
        | SearchTextChanged args -> { model with Text = args }, Cmd.none
        | AsyncSearchTermChanged term -> { model with AsyncSearchTerm = term }, Cmd.none

        | CustomAutoBoxLoaded _ ->
            let strings = buildAllSentences() |> Array.concat
            customAutoCompleteBoxRef.Value.ItemsSource <- strings
            customAutoCompleteBoxRef.Value.TextFilter <- AutoCompleteFilterPredicate(fun searchText item -> lastWordContains(searchText, item))
            customAutoCompleteBoxRef.Value.TextSelector <- AutoCompleteSelector(fun searchText item -> appendWord(searchText, item))
            model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("AutoCompleteBoxPage") {
            let! model = Context.Mvu program
            let stateData = Unchecked.defaultof<StateData> // helper instance to get compile-safe member names

            VStack() {
                TextBlock("A control into which the user can input text")

                UniformGrid() {
                    VStack() {
                        TextBlock("MinimumPrefixLength: 1")

                        AutoCompleteBox(model.UsFederalStates)
                            .minimumPrefixLength(1)
                            .watermark("Select an item")
                            .onTextChanged(model.Text, SearchTextChanged)
                    }

                    VStack() {
                        TextBlock("MinimumPrefixLength: 3")

                        AutoCompleteBox(model.Items)
                            .watermark("Select an item")
                            .minimumPrefixLength(3)
                    }

                    VStack() {
                        TextBlock("MinimumPopulateDelay: 1s")

                        AutoCompleteBox(model.Items)
                            .watermark("Select an item")
                            .minimumPopulateDelay(TimeSpan.FromSeconds(1.0))
                    }

                    VStack() {
                        TextBlock("MaxDropDownHeight: 60")

                        AutoCompleteBox(model.Items)
                            .maxDropDownHeight(60.0)
                            .watermark("Select an item")
                    }

                    VStack() {
                        TextBlock("Disabled")

                        AutoCompleteBox(model.Items)
                            .isEnabled(false)
                            .watermark("Select an item")
                    }

                    VStack() {
                        TextBlock("Multi-Binding")

                        AutoCompleteBox(model.UsFederalStates)
                            .watermark("Select an item")
                            .filterMode(AutoCompleteFilterMode.Contains)
                            .multiBindValue("{0} ({1})", nameof stateData.Name, nameof stateData.Abbreviation)
                    }

                    VStack() {
                        TextBlock("With an item template")
                            .tip(ToolTip("Somewhere, in pride, an eagle sheds\nA single splendid tear."))

                        AutoCompleteBox(model.UsFederalStates)
                            .itemTemplate(fun state ->
                                HStack(5) {
                                    TextBlock(state.Capital).foreground(Colors.Blue)
                                    TextBlock(state.Abbreviation + ",").foreground(Colors.White)
                                    TextBlock(state.Name).foreground(Colors.Red)
                                })
                            .watermark("Search a US state or capital")
                            .tip(ToolTip("the custom item filter searches the state name as well as the capital"))
                            .itemFilter(fun term item ->
                                let state = item :?> StateData
                                contains state.Name term || contains state.Capital term)
                    }

                    VStack() {
                        TextBlock("AsyncBox")

                        AutoCompleteBox(getItemsAsync)
                            .watermark("Select an item")
                            .filterMode(AutoCompleteFilterMode.Contains)
                    }

                    VStack() {
                        TextBlock("Async remote-filtered search")

                        AutoCompleteBox(model.UsStateSearch.SearchAsync)
                            .watermark("Search capitals of US federal states by name or state")
                            .minimumPopulateDelay(TimeSpan.FromMilliseconds 300) // debounce the requests
                            .onTextChanged(model.AsyncSearchTerm, AsyncSearchTermChanged)
                            .filterMode(AutoCompleteFilterMode.None) // remote filtered
                            .multiBindValue("{2}, {1} ({0})", nameof stateData.Name, nameof stateData.Abbreviation, nameof stateData.Capital)
                            .reference(RemoteSearch.input)
                            .animation(
                                // pulses the scale like a heart beat to indicate activity
                                (Animation(TimeSpan.FromSeconds(2.)) {
                                    // extend slightly but quickly to get a pulse effect
                                    KeyFrame(ScaleTransform.ScaleXProperty, 1.05).cue(0.1)
                                    KeyFrame(ScaleTransform.ScaleYProperty, 1.05).cue(0.1)
                                    // contract slightly to get a bounce-back effect
                                    KeyFrame(ScaleTransform.ScaleXProperty, 0.95).cue(0.15)
                                    KeyFrame(ScaleTransform.ScaleYProperty, 0.95).cue(0.15)
                                    // return to original size rather quickly
                                    KeyFrame(ScaleTransform.ScaleXProperty, 1).cue(0.2)
                                    KeyFrame(ScaleTransform.ScaleYProperty, 1).cue(0.2)
                                })
                                    .delay(TimeSpan.FromSeconds 1.) // to avoid a "heart attack", i.e. restarting the animation by typing
                                    .reference(RemoteSearch.heartBeat)
                            )
                    }

                    VStack() {
                        TextBlock("Custom AutoComplete")

                        AutoCompleteBox(model.Custom)
                            .watermark("Select an item")
                            .reference(customAutoCompleteBoxRef)
                            .filterMode(AutoCompleteFilterMode.None)
                            .onLoaded(CustomAutoBoxLoaded)

                    }

                    VStack() {
                        TextBlock("With Validation Errors")

                        AutoCompleteBox(model.Items)
                            .name("ValidationErrors")
                            .filterMode(AutoCompleteFilterMode.None)
                            .dataValidationErrors([ Exception() ])
                    }
                }
            }
        }
