namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module StylesPage =

    let private coloredTextBoxWatermark (color: IBrush) =
        (*  Create a style that targets the Watermark TextBlock of the TextBox Template,
            which is neither accessible in the Logical- nor the VisualTree. *)
        let style =
            Style(
                // see https://docs.avaloniaui.net/docs/reference/styles/style-selector-syntax
                _.OfType<TextBox>()
                    .Template()
                    .OfType<TextBlock>()
                    (*  matches the Name of the Watermark TextBlock in the Avalonia TextBox template;
                        see https://github.com/AvaloniaUI/Avalonia/blob/master/src/Avalonia.Themes.Fluent/Controls/TextBox.xaml *)
                    .Name("PART_Watermark")
            )

        (*  Set the Foreground of the nested TextBlock using a StyledProperty
            because this is otherwise unsupported by the Avalonia TextBox API. *)
        style.Setters.Add(Setter(Avalonia.Controls.TextBlock.ForegroundProperty, box color))

        style

    let private acceptReturnOnAutoCompleteTextBox () =
        (*  Create a style that targets the TextBox part of the AutoCompleteBox Template,
            which is neither accessible in the Logical- nor the VisualTree. *)
        let style =
            Style(
                // see https://docs.avaloniaui.net/docs/reference/styles/style-selector-syntax
                _.OfType<AutoCompleteBox>()
                    .Template()
                    .OfType<TextBox>()
                    (*  matches the Name of the TextBox in the Avalonia AutoCompleteBox template;
                        see https://github.com/AvaloniaUI/Avalonia/blob/master/src/Avalonia.Themes.Fluent/Controls/AutoCompleteBox.xaml *)
                    .Name("PART_TextBox")
            )

        (*  Set the AcceptsReturn of the nested TextBox using a StyledProperty
            because this is otherwise unsupported by the Avalonia AutoCompleteBox API. *)
        style.Setters.Add(Setter(TextBox.AcceptsReturnProperty, box true))

        style

    let view () =
        UserControl(
            (VStack(spacing = 15.) {
                TextBlock("I'm a Heading1!").classes([ "h1" ])

                TextBlock("I'm a Heading2!").classes([ "h2" ])

                TextBlock("I'm a Heading3!").classes([ "h3" ])

                TextBlock("I'm a Heading4!").classes([ "h4" ])

                TextBlock("I'm a Heading5!").classes([ "h5" ])

                TextBlock("I'm a Heading6!").classes([ "h6" ])

                TextBlock("I'm a Body1!").classes([ "h7" ])

                TextBlock("I'm a Body2!").classes([ "h8" ])

                TextBlock("I'm a Body3!").classes([ "h9" ])

                TextBlock("I'm just a text")

                AutoCompleteBox([])
                    .watermark("I'm an AutoCompleteBox styled to have a crimson watermark and accept Return/Enter")
                    .styles(
                        [ coloredTextBoxWatermark(Brushes.Crimson)
                          acceptReturnOnAutoCompleteTextBox() ]
                    )
            })
        )
            .styleInclude("avares://Gallery/Styles/TextStyles.xaml")
