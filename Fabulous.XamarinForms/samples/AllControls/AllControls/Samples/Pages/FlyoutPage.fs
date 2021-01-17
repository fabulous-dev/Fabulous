namespace AllControls.Samples.Pages

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module FlyoutPage =
    type Msg =
      | IsFlyoutPresentedChanged of bool
      | SetDetailPage of string
      
    type CmdMsg = Nothing
    
    type Model =
      { IsFlyoutPresented: bool 
        DetailPage: string }
      
    let mapToCmd _ = Cmd.none
      
    let init () =
        { IsFlyoutPresented = false
          DetailPage = "A" }
        
    let update msg model =
        match msg with
        | IsFlyoutPresentedChanged b -> { model with IsFlyoutPresented = b }, []
        | SetDetailPage s -> { model with DetailPage = s ; IsFlyoutPresented = false }, []
    
    let view model dispatch =
        dependsOn (model.DetailPage, model.IsFlyoutPresented) (fun model (detailPage, isFlyoutPresented) -> 
            View.FlyoutPage(
                flyoutLayoutBehavior = FlyoutLayoutBehavior.Popover, 
                isPresented = isFlyoutPresented, 
                isPresentedChanged = (fun () -> dispatch (IsFlyoutPresentedChanged (not isFlyoutPresented))), 
                flyout = View.ContentPage(
                    useSafeArea = true,
                    title = "Flyout", 
                    content = View.StackLayout(
                        backgroundColor = Color.Gray, 
                        children = [
                            View.Button(
                                text = "Detail A",
                                textColor = Color.White,
                                backgroundColor = Color.Navy,
                                command = fun () -> dispatch (SetDetailPage "A")
                            )
                            View.Button(
                                text = "Detail B",
                                textColor = Color.White,
                                backgroundColor = Color.Navy,
                                command = fun () -> dispatch (SetDetailPage "B")
                            )
                        ]
                    )
                ), 
                detail = View.NavigationPage( 
                    pages = [
                        View.ContentPage(
                            title = "Detail",
                            useSafeArea = true,
                            content = View.StackLayout(
                                backgroundColor = Color.Gray, 
                                children = [
                                    View.Label(
                                        text = "Detail " + detailPage,
                                        textColor = Color.White,
                                        backgroundColor = Color.Navy
                                    )
                                ]
                            ) 
                        ).HasNavigationBar(true)
                         .HasBackButton(true)
                    ], 
                    poppedToRoot = fun _ -> dispatch (IsFlyoutPresentedChanged true)
                )
            )
        )
