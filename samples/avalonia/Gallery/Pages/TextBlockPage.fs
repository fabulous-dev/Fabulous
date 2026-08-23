namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TextBlockPage =
    let view () =
        VStack(spacing = 15.) {
            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .margin(10., 0., 10., 0.)
                .textTrimming(TextTrimming.CharacterEllipsis)
                .textWrapping(TextWrapping.Wrap)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .margin(10., 0., 10., 0.)
                .textTrimming(TextTrimming.WordEllipsis)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Left)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Center)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Right)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Justify)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Start)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.End)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textTrimming(TextTrimming.None)
                .textWrapping(TextWrapping.NoWrap)

            TextBlock(
                "Multiline TextBlock with TextWrapping.&#xD;&#xD;Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus magna. Cras in mi at felis aliquet congue. Ut a est eget ligula molestie gravida. Curabitur massa. Donec eleifend, libero at sagittis mollis, tellus est malesuada tellus, at luctus turpis elit sit amet quam. Vivamus pretium ornare est."
            )
                .textWrapping(TextWrapping.Wrap)

            let fontFamily = FontFamily("avares://Gallery/Assets/Fonts#Source Sans Pro")

            Border(
                VStack(8.) {
                    TextBlock("Custom font regular")
                        .fontFamily(fontFamily)
                        .fontStyle(FontStyle.Normal)
                        .fontWeight(FontWeight.Normal)

                    TextBlock("Custom font bold")
                        .fontFamily(fontFamily)
                        .fontStyle(FontStyle.Normal)
                        .fontWeight(FontWeight.Bold)

                    TextBlock("Custom font italic")
                        .fontFamily(fontFamily)
                        .fontStyle(FontStyle.Italic)
                        .fontWeight(FontWeight.Normal)

                    TextBlock("Custom font italic bold")
                        .fontFamily(fontFamily)
                        .fontStyle(FontStyle.Italic)
                        .fontWeight(FontWeight.Bold)
                }
            )

            Border(
                VStack(8.0) {
                    TextBlock("Underline").textDecorations() { TextDecoration(TextDecorationLocation.Underline) }

                    TextBlock("Strikethrough").textDecorations() { TextDecoration(TextDecorationLocation.Strikethrough) }

                    TextBlock("Overline").textDecorations() { TextDecoration(TextDecorationLocation.Overline) }

                    TextBlock("Baseline").textDecorations() { TextDecoration(TextDecorationLocation.Baseline) }

                    TextBlock("Custom TextDecorations").textDecorations() {
                        TextDecoration(TextDecorationLocation.Overline)
                            .strokeThickness(2.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(Colors.Red, 0.)
                                    GradientStop(Colors.Green, 1.)
                                }
                            )

                        TextDecoration(TextDecorationLocation.Strikethrough)
                            .strokeThickness(1.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(Colors.Green, 0.)
                                    GradientStop(Colors.Blue, 1.)
                                }
                            )

                        TextDecoration(TextDecorationLocation.Underline)
                            .strokeThickness(2.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(Colors.Blue, 0.)
                                    GradientStop(Colors.Red, 1.)
                                }
                            )

                    }

                    Border(
                        VStack() {
                            TextBlock("🏻 👌🏻")
                            TextBlock("🏼 👌🏼")
                            TextBlock("🏽 👌🏽")
                            TextBlock("🏾 👌🏾")
                            TextBlock("🏿 👌🏿")
                        }
                    )

                    Border(TextBlock("👪 👨‍👩‍👧 👨‍👩‍👧‍👦"))
                }
            )

            TextBlock() {
                Run("This ")

                Span() { Run("is").fontWeight(FontWeight.Bold) }

                Run(" a ")

                Span() {
                    Run("TextBlock")
                        .background(SolidColorBrush(Colors.Silver))
                        .foreground(SolidColorBrush(Colors.Maroon))
                }

                Run(" with ")

                Span() { Run("several").textDecorations() { TextDecoration(TextDecorationLocation.Underline) } }

                Span() { Run("Span").fontStyle(FontStyle.Italic) }

                Run(" elements, ")

                Span() {
                    Run("using a ")
                    Bold("variety")
                    Run(" of ")
                    Italic("styles")
                    Underline("Underlined 11")
                }
            }
        }
