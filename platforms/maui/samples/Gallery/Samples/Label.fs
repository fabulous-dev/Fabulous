namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module Label =
    let view () =
        VStack(spacing = 15.) {
            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .alignStartTextHorizontal()

            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .centerTextHorizontal()

            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .alignEndTextHorizontal()

            ContentView(
                VStack(8.) {
                    Label("Custom font regular")
                        .font(fontFamily = Fonts.SourceSansProRegular, size = 20.)

                    Label("Custom font bold").font(fontFamily = Fonts.SourceSansProBold, size = 20.)

                    Label("Custom font italic")
                        .font(fontFamily = Fonts.SourceSansProItalic, size = 20.)

                    Label("Custom font italic bold")
                        .font(fontFamily = Fonts.SourceSansProBoldItalic, size = 20.)
                }
            )

            ContentView(
                VStack(8.0) {
                    Label("Underline").textDecorations(TextDecorations.Underline)

                    Label("Strikethrough").textDecorations(TextDecorations.Strikethrough)

                    ContentView(
                        VStack() {
                            Label("🏻 👌🏻")
                            Label("🏼 👌🏼")
                            Label("🏽 👌🏽")
                            Label("🏾 👌🏾")
                            Label("🏿 👌🏿")
                        }
                    )

                    ContentView(Label("👪 👨‍👩‍👧 👨‍👩‍👧‍👦"))
                }
            )
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "Label"
          Description = "A label widget that displays text on the interface"
          Program = sampleProgram }
