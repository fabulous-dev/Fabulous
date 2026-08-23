namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module WrapPanelsPage =
    let horizontalWrapPanelView () =
        VStack(spacing = 20.) {
            TextBlock("Horizontal WrapPanel with Spacing")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Items wrap to next line when they exceed container width")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                HWrap() {
                    Border(TextBlock("60×50"))
                        .width(60.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("70×50"))
                        .width(70.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightPink))

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightYellow))
                }
                |> _.width(100.)
                |> _.itemSpacing(10.)
                |> _.lineSpacing(20.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- First line: Blue (60×50) and Green (30×50) with 10px space between them")
                .margin(10., 0., 0., 0.)

            TextBlock("- Second line: Pink (70×50) starting 20px below first line")
                .margin(10., 0., 0., 0.)

            TextBlock("- Third line: Yellow (30×50) starting 20px below second line")
                .margin(10., 0., 0., 0.)
        }

    let horizontalWrapPanelWithInvisibleView () =
        VStack(spacing = 20.) {
            TextBlock("Horizontal WrapPanel with Invisible Item")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Invisible items don't affect layout and don't use spacing")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                HWrap() {
                    Border(TextBlock("60×50"))
                        .width(60.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("30×50 (Invisible)"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.Gray))
                        .opacity(0.3)
                        .isVisible(false)

                    Border(TextBlock("50×50"))
                        .width(50.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightPink))
                }
                |> _.itemSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- Total width: 120px (60px + 10px spacing + 50px)")
                .margin(10., 0., 0., 0.)

            TextBlock("- Only Blue and Pink items are visible with 10px spacing between them")
                .margin(10., 0., 0., 0.)
        }

    let verticalWrapPanelView () =
        VStack(spacing = 20.) {
            TextBlock("Vertical WrapPanel with Spacing")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Items flow vertically and wrap to the next column when they exceed container height")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                VWrap() {
                    Border(TextBlock("50×60"))
                        .width(50.)
                        .height(60.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("50×30"))
                        .width(50.)
                        .height(30.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("50×70"))
                        .width(50.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightPink))

                    Border(TextBlock("50×30"))
                        .width(50.)
                        .height(30.)
                        .background(SolidColorBrush(Colors.LightYellow))
                }
                |> _.height(100.)
                |> _.itemSpacing(10.)
                |> _.lineSpacing(20.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- First column: Blue (50×60) and Green (50×30) with 10px space between them")
                .margin(10., 0., 0., 0.)

            TextBlock("- Second column: Pink (50×70) starting 20px to the right of first column")
                .margin(10., 0., 0., 0.)

            TextBlock("- Third column: Yellow (50×30) starting 20px to the right of second column")
                .margin(10., 0., 0., 0.)
        }

    let zeroSizeChildView () =
        VStack(spacing = 20.) {
            TextBlock("WrapPanel with Zero-Size Visible Child")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Zero-sized children still occupy their place in the layout flow")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                HWrap() {
                    Border(TextBlock("Zero Size"))
                        .background(SolidColorBrush(Colors.LightGray))
                        .opacity(0.5)
                    // No width/height set = zero size

                    Border(TextBlock("50×50"))
                        .width(50.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightBlue))
                }
                |> _.width(50.)
                |> _.itemSpacing(10.)
                |> _.lineSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- First line: Zero-size gray border (0×0)")
                .margin(10., 0., 0., 0.)

            TextBlock("- Second line: Blue border (50×50) starting 10px below the first item")
                .margin(10., 0., 0., 0.)

            TextBlock("- Total size: 50px × 60px (width × height)")
                .margin(10., 0., 0., 0.)
        }

    let hwrapView () =
        VStack(spacing = 20.) {
            TextBlock("HWrap Panel - Horizontal Orientation")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Using the HWrap() convenience function creates a WrapPanel with horizontal orientation")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                HWrap() {
                    Border(TextBlock("60×40"))
                        .width(60.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("40×40"))
                        .width(40.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("50×40"))
                        .width(50.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightPink))

                    Border(TextBlock("70×40"))
                        .width(70.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightYellow))

                    Border(TextBlock("30×40"))
                        .width(30.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightCyan))
                }
                |> _.width(160.)
                |> _.itemSpacing(10.)
                |> _.lineSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- First line: Blue (60×40) and Green (40×40) and Pink (50×40)")
                .margin(10., 0., 0., 0.)

            TextBlock("- Second line: Yellow (70×40) and Cyan (30×40)")
                .margin(10., 0., 0., 0.)
        }

    let vwrapView () =
        VStack(spacing = 20.) {
            TextBlock("VWrap Panel - Vertical Orientation")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Using the VWrap() convenience function creates a WrapPanel with vertical orientation")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                VWrap() {
                    Border(TextBlock("40×60"))
                        .width(40.)
                        .height(60.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("40×40"))
                        .width(40.)
                        .height(40.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("40×50"))
                        .width(40.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightPink))

                    Border(TextBlock("40×70"))
                        .width(40.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightYellow))

                    Border(TextBlock("40×30"))
                        .width(40.)
                        .height(30.)
                        .background(SolidColorBrush(Colors.LightCyan))
                }
                |> _.height(160.)
                |> _.itemSpacing(10.)
                |> _.lineSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- First column: Blue (40×60) and Green (40×40) and Pink (40×50)")
                .margin(10., 0., 0., 0.)

            TextBlock("- Second column: Yellow (40×70) and Cyan (40×30)")
                .margin(10., 0., 0., 0.)
        }

    let hwrapWithAlignmentView () =
        VStack(spacing = 20.) {
            TextBlock("HWrap with ItemsAlignment")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Using HWrap with WrapPanelItemsAlignment.Center aligns items to the center of the row")
                .textWrapping(TextWrapping.Wrap)
                .margin(0., 0., 0., 10.)

            Border(
                HWrap(WrapPanelItemsAlignment.Center) {
                    Border(TextBlock("60×30"))
                        .width(60.)
                        .height(30.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("40×50"))
                        .width(40.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("70×20"))
                        .width(70.)
                        .height(20.)
                        .background(SolidColorBrush(Colors.LightPink))
                }
                |> _.width(180.)
                |> _.itemSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)

            TextBlock("Expected layout:").margin(0., 10., 0., 5.)

            TextBlock("- All items are vertically centered in their row")
                .margin(10., 0., 0., 0.)

            TextBlock("- Items of different heights are aligned to the center")
                .margin(10., 0., 0., 0.)
        }

    let view () =
        TabControl() {
            TabItem("Horizontal WrapPanel", horizontalWrapPanelView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("With Invisible Item", horizontalWrapPanelWithInvisibleView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("Vertical WrapPanel", verticalWrapPanelView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("Zero-Size Child", zeroSizeChildView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("HWrap Example", hwrapView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("VWrap Example", vwrapView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("HWrap with Alignment", hwrapWithAlignmentView())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)
        }
