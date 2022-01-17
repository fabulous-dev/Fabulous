namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type INavigationPage =
    inherit IPage

module NavigationPage =
    let WidgetKey = Widgets.register<NavigationPage> ()

    let Pages =
        Attributes.defineWidgetCollectionWithConverter
            "NavigationPage_Pages"
            ViewUpdaters.applyDiffNavigationPagePages
            ViewUpdaters.updateNavigationPagePages

    let BarBackgroundColor =
        Attributes.defineBindable<Color> NavigationPage.BarBackgroundColorProperty

    let BarTextColor =
        Attributes.defineBindable<Color> NavigationPage.BarTextColorProperty

    let HasNavigationBar =
        Attributes.defineBindable<bool> NavigationPage.HasNavigationBarProperty

    let HasBackButton =
        Attributes.defineBindable<bool> NavigationPage.HasBackButtonProperty

    let Popped =
        Attributes.defineEvent<NavigationEventArgs>
            "NavigationPage_Popped"
            (fun target -> (target :?> NavigationPage).Popped)

[<AutoOpen>]
module NavigationPageBuilders =
    type Fabulous.XamarinForms.View with
        static member inline NavigationPage<'msg>() =
            CollectionBuilder<'msg, INavigationPage, IPage>(NavigationPage.WidgetKey, NavigationPage.Pages)

[<Extension>]
type NavigationPageModifiers =
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #INavigationPage>, value: Color) =
        this.AddScalar(NavigationPage.BarBackgroundColor.WithValue(value))

    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #INavigationPage>, value: Color) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(value))

    [<Extension>]
    static member inline popped(this: WidgetBuilder<'msg, #INavigationPage>, value: 'msg) =
        this.AddScalar(NavigationPage.Popped.WithValue(fun _ -> box value))

[<Extension>]
type NavigationPageAttachedModifiers =
    [<Extension>]
    static member inline hasNavigationBar(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasNavigationBar.WithValue(value))

    [<Extension>]
    static member inline hasBackButton(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasBackButton.WithValue(value))
