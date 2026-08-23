namespace Gallery

open System
open System.Diagnostics
open System.Reflection
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

(* Are these builders worth including into Fabulous.Avalonia in one form or the other?
    Otherwise - how to create empty HWraps or VWraps for itemsPanel() extensions like below? *)
[<AutoOpen>]
module EmptyWrapPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Vertical" />
        /// rendering child elements from left to right while they fit the width and starting a new line when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member EmptyVWrap() =
            WidgetBuilder<'msg, IFabPanel>(WrapPanel.WidgetKey, WrapPanel.Orientation.WithValue(Orientation.Vertical))

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Horizontal" />
        /// rendering child elements from top to bottom while they fit the height and starting a new column when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member EmptyHWrap() =
            WidgetBuilder<'msg, IFabPanel>(WrapPanel.WidgetKey, WrapPanel.Orientation.WithValue(Orientation.Horizontal))

open type Fabulous.Avalonia.View

module ColorsByChannel =
    type ColorInfo =
        { Name: string
          Color: Color
          Hsv: HsvColor
          Hsl: HslColor }

    type SortOption =
        | R = 0
        | G = 1
        | B = 2
        | H = 3
        | Sl = 4
        | Sv = 5
        | L = 6
        | V = 7
        | A = 8

    type Model =
        { AllColors: ColorInfo list option
          SortOptions: SortOption list
          SortBy: SortOption }

    type Msg =
        | ExpandingColors
        | SortBy of SortOption

    let private getSortStrategy sortBy : (ColorInfo -> float) =
        match sortBy with
        | SortOption.R -> fun c -> float c.Color.R
        | SortOption.G -> fun c -> float c.Color.G
        | SortOption.B -> fun c -> float c.Color.B
        | SortOption.H -> _.Hsl.H
        | SortOption.Sl -> _.Hsl.S
        | SortOption.Sv -> _.Hsv.S
        | SortOption.L -> _.Hsl.L
        | SortOption.V -> _.Hsv.V
        | SortOption.A -> _.Hsl.A
        | _ -> failwith "unknown sort option"

    let private getStaticProperties<'T> () =
        typeof<'T>
            .GetProperties(BindingFlags.Public ||| BindingFlags.Static)

    let private loadColors () =
        getStaticProperties<Colors>()
        |> Seq.map(fun prop ->
            let color = prop.GetValue(null) |> unbox<Color>

            { Name = prop.Name
              Color = color
              Hsl = color.ToHsl()
              Hsv = color.ToHsv() })

    let private init () =
        { AllColors = None
          SortOptions = Enum.GetValues<SortOption>() |> List.ofSeq
          SortBy = SortOption.L },
        Cmd.none

    let private update msg model =
        match msg with
        | ExpandingColors ->
            let model =
                if model.AllColors.IsSome then
                    model
                else
                    { model with
                        AllColors = loadColors() |> Seq.sortBy(getSortStrategy model.SortBy) |> List.ofSeq |> Some }

            model, Cmd.none

        | SortBy option ->
            { model with
                SortBy = option
                AllColors =
                    match model.AllColors with
                    | Some value -> value |> List.sortBy(getSortStrategy option) |> Some
                    | None -> None },
            Cmd.none

    let private displaySortBy sortBy =
        match sortBy with
        | SortOption.Sl -> "S (HSL)"
        | SortOption.Sv -> "S (HSV)"
        | _ -> sortBy.ToString()

    let private program =
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

    (* may also/alternatively be used as a show case for
        horizontal ListBox, horizontal ItemsControl,
        lazy-loaded Expander, WrapPanel or ThemeAware *)
    let view () =
        Component("ColorsByChannel") {
            let! model = Context.Mvu program

            Expander(
                "Named Avalonia UI Colors",
                VStack(5) {
                    HStack(5) {
                        TextBlock("Sort by channel")
                            .verticalAlignment(VerticalAlignment.Center)

                        ListBox(model.SortOptions, (fun s -> TextBlock(displaySortBy s)))
                            .selectedItem(model.SortBy)
                            .onSelectionChanged(fun args ->
                                let o = unbox<SortOption>(args.AddedItems.Item 0)
                                SortBy o)
                            .itemsPanel(EmptyHWrap())
                    }

                    ScrollViewer(
                        ItemsControl(
                            model.AllColors |> Option.defaultValue [],
                            fun c ->
                                Border(
                                    Border(TextBlock(c.Name))
                                        .background(ThemeAware.With(Colors.White, Colors.Black))
                                )
                                    .padding(50, 20, 0, 0)
                                    .background(c.Color)
                        )
                            .itemsPanel(EmptyHWrap())
                    )
                }
            )
                .maxWidth(600)
                .onExpanding(fun _ -> ExpandingColors)
        }
