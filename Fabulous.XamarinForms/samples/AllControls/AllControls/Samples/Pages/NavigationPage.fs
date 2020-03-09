namespace AllControls.Samples.Pages

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module NavigationPage =
    type Msg =
        | GoHomePage
        | PopPage 
        | PagePopped 
        | ReplacePage of string
        | PushPage of string
        
    type CmdMsg = Nothing
    
    type Model =
        { PageStack: string option list }
        
    let mapToCmd _ = Cmd.none
    
    let init () =
        { PageStack = [Some "Home"] }
        
    let update msg model =
        match msg with
        | GoHomePage -> { model with PageStack = [ Some "Home" ] }, []
        | PagePopped -> 
            if model.PageStack |> List.exists Option.isNone then 
               { model with PageStack = model.PageStack |> List.filter Option.isSome }, []
            else
               { model with PageStack = (match model.PageStack with [] -> model.PageStack | _ :: t -> t) }, []
        | PopPage -> 
               { model with PageStack = (match model.PageStack with [] -> model.PageStack | _ :: t -> None :: t) }, []
        | PushPage page -> 
            { model with PageStack = Some page :: model.PageStack}, []
        | ReplacePage page -> 
            { model with PageStack = (match model.PageStack with [] -> Some page :: model.PageStack | _ :: t -> Some page :: t) }, []
    
    let view model dispatch =
        dependsOn model.PageStack (fun model pageStack -> 
            View.NavigationPage( 
                popped = (fun _ -> dispatch PagePopped), 
                poppedToRoot = (fun _ -> dispatch GoHomePage),
                pages = [
                    for page in List.rev pageStack do
                        match page with 
                        | Some "Home" -> 
                            yield View.ContentPage(
                                useSafeArea = true,
                                content = View.StackLayout([
                                    View.Label(
                                        text = "Home Page",
                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                        horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Button(
                                        text = "Push Page A",
                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                        horizontalOptions = LayoutOptions.Center,
                                        command = fun () -> dispatch (PushPage "A")
                                    )
                                    View.Button(
                                        text = "Push Page B",
                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                        horizontalOptions = LayoutOptions.Center,
                                        command = fun () -> dispatch (PushPage "B")
                                    )
                                ])
                            ).HasNavigationBar(true)
                             .HasBackButton(false)
                             
                        | Some "A" -> 
                            yield View.ContentPage(
                                useSafeArea = true,
                                content = View.StackLayout([
                                    View.Label(
                                        text = "Page A",
                                        verticalOptions = LayoutOptions.Center,
                                        horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Button(
                                       text = "Page B",
                                       verticalOptions = LayoutOptions.Center,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "B")
                                    )
                                    View.Button(
                                       text = "Page C",
                                       verticalOptions = LayoutOptions.Center,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "C")
                                    )
                                    View.Button(
                                       text = "Replace by Page B",
                                       verticalOptions = LayoutOptions.Center,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (ReplacePage "B")
                                    )
                                    View.Button(
                                       text = "Replace by Page C",
                                       verticalOptions = LayoutOptions.Center,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (ReplacePage "C")
                                    )
                                    View.Button(
                                       text = "Back",
                                       verticalOptions = LayoutOptions.Center,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch PopPage
                                    )
                                ])
                            ).HasNavigationBar(true)
                             .HasBackButton(true)
                        
                        | Some "B" -> 
                            yield View.ContentPage(
                                useSafeArea = true,
                                content = View.StackLayout([
                                    View.Label(
                                      text = "Page B",
                                      verticalOptions = LayoutOptions.CenterAndExpand,
                                      horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Label(
                                      text = "(nb. no back button in navbar)",
                                      verticalOptions = LayoutOptions.CenterAndExpand,
                                      horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Button(
                                       text = "Page A",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "A")
                                    )
                                    View.Button(
                                       text = "Page C",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "C")
                                    )
                                    View.Button(
                                       text = "Back",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch PopPage
                                    )
                                ])
                            ).HasNavigationBar(true)
                             .HasBackButton(false)
                        
                        | Some "C" -> 
                            yield View.ContentPage(useSafeArea=true,
                                content = View.StackLayout([
                                    View.Label(
                                      text = "Page C",
                                      verticalOptions = LayoutOptions.CenterAndExpand,
                                      horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Label(
                                      text = "(nb. no navbar)",
                                      verticalOptions = LayoutOptions.CenterAndExpand,
                                      horizontalOptions = LayoutOptions.Center
                                    )
                                    View.Button(
                                       text = "Page A",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "A")
                                    )
                                    View.Button(
                                       text = "Page B",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch (PushPage "B")
                                    )
                                    View.Button(
                                       text = "Back",
                                       verticalOptions = LayoutOptions.CenterAndExpand,
                                       horizontalOptions = LayoutOptions.Center,
                                       command = fun () -> dispatch PopPage
                                    )
                                ])
                            ).HasNavigationBar(false)
                             .HasBackButton(false)

                        | _ -> 
                            ()
                ]
            )
        )

