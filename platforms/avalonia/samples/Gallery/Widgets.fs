namespace Gallery

open System.Runtime.CompilerServices
open Avalonia.Media
open Controls.HamburgerMenu
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

module Paths =

    [<Literal>]
    let Path1 =
        "F1 M 16.6309,18.6563C 17.1309,8.15625 29.8809,14.1563 29.8809,14.1563C 30.8809,11.1563 34.1308,11.4063 34.1308,11.4063C 33.5,12 34.6309,13.1563 34.6309,13.1563C 32.1309,13.1562 31.1309,14.9062 31.1309,14.9062C 41.1309,23.9062 32.6309,27.9063 32.6309,27.9062C 24.6309,24.9063 21.1309,22.1562 16.6309,18.6563 Z M 16.6309,19.9063C 21.6309,24.1563 25.1309,26.1562 31.6309,28.6562C 31.6309,28.6562 26.3809,39.1562 18.3809,36.1563C 18.3809,36.1563 18,38 16.3809,36.9063C 15,36 16.3809,34.9063 16.3809,34.9063C 16.3809,34.9063 10.1309,30.9062 16.6309,19.9063 Z"

    [<Literal>]
    let Path2 =
        "M 272.70141,238.71731 C 206.46141,238.71731 152.70146,292.4773 152.70146,358.71731 C 152.70146,493.47282 288.63461,528.80461 381.26391,662.02535 C 468.83815,529.62199 609.82641,489.17075 609.82641,358.71731 C 609.82641,292.47731 556.06651,238.7173 489.82641,238.71731 C 441.77851,238.71731 400.42481,267.08774 381.26391,307.90481 C 362.10311,267.08773 320.74941,238.7173 272.70141,238.71731 z"

    [<Literal>]
    let Path3 =
        "M3 17h18a1 1 0 0 1 .117 1.993L21 19H3a1 1 0 0 1-.117-1.993L3 17h18H3Zm0-6 18-.002a1 1 0 0 1 .117 1.993l-.117.007L3 13a1 1 0 0 1-.117-1.993L3 11l18-.002L3 11Zm0-6h18a1 1 0 0 1 .117 1.993L21 7H3a1 1 0 0 1-.117-1.993L3 5h18H3Z"

type IFabHamburgerMenu =
    inherit IFabTabControl

module HamburgerMenu =
    let WidgetKey = Widgets.register<HamburgerMenu>()

    let PaneBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.PaneBackgroundProperty

    let ContentBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ContentBackgroundProperty

    let ExpandedModeThresholdWidth =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ExpandedModeThresholdWidthProperty

[<AutoOpen>]
module HamburgerMenuBuilders =

    type Fabulous.Avalonia.View with

        static member HamburgerMenu() =
            CollectionBuilder<'msg, IFabHamburgerMenu, IFabTabItem>(HamburgerMenu.WidgetKey, ItemsControl.Items)


type HamburgerMenuModifiers =
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: ViewRef<HamburgerMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.PaneBackground.WithValue(value))

    [<Extension>]
    static member inline contentBackground(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.ContentBackground.WithValue(value))

    [<Extension>]
    static member inline expandedModeThresholdWidth(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: int) =
        this.AddScalar(HamburgerMenu.ExpandedModeThresholdWidth.WithValue(value))

open Avalonia.Layout
open type Fabulous.Avalonia.View

[<AutoOpen>]
module CustomNotificationBuilders =
    type Fabulous.Avalonia.View with

        static member InlinedYesNoQuestion(title: string, message: string, yesCommand: 'msg, noCommand: 'msg) =
            Border(
                Grid(coldefs = [ Auto; Star ], rowdefs = [ Auto ]) {
                    (Panel() {
                        TextBlock("❔")
                            .foreground(SolidColorBrush(Colors.White))
                            .fontWeight(FontWeight.Bold)
                            .fontSize(20.)
                            .textAlignment(TextAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                    })
                        .margin(0., 0., 12., 0.)
                        .width(25.)
                        .height(25.)
                        .verticalAlignment(VerticalAlignment.Top)

                    (Dock() {
                        TextBlock(title)
                            .dock(Dock.Top)
                            .fontWeight(FontWeight.Medium)

                        (HStack(20.) {
                            Button("No", noCommand)
                                .closeOnClick(true)
                                .margin(0., 0., 8., 0.)
                                .dock(Dock.Right)

                            Button("Yes", yesCommand)
                                .closeOnClick(true)
                                .dock(Dock.Right)
                        })
                            .dock(Dock.Bottom)
                            .margin(0., 8., 0., 0.)

                        TextBlock(message)
                            .margin(0., 8., 0., 0.)
                            .textWrapping(TextWrapping.Wrap)
                            .opacity(0.8)

                    })
                        .gridColumn(1)
                }
            )
                .padding(12.)
                .minHeight(20.)
                .background(SolidColorBrush(Colors.DodgerBlue))

        static member inline CardItem(text: string) =
            Border(
                TextBlock(text)
                    .centerHorizontal()
                    .centerVertical()
                    .padding(8.)
            )
                .height(50.)
                .cornerRadius(8.)
                .margin(8.)
                .borderBrush(SolidColorBrush(Colors.DarkGray))
                .borderThickness(2.)
