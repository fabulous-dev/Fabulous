namespace AllControls.Samples.Pages

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module MasterDetailPage =
    type Msg =
      | SetDetailPage of string
      
    type CmdMsg = Nothing
    
    type Model =
      { DetailPage: string }
      
    let mapToCmd _ = Cmd.none
      
    let init () =
        { DetailPage = "A" }
        
    let update msg model =
        match msg with
        | SetDetailPage s -> { model with DetailPage = s }, []
    
    let view model dispatch =
        // MasterDetail where the Master acts as a hamburger-style menu
        dependsOn (model.DetailPage) (fun model (detailPage) -> 
            View.MasterDetailPage(
                masterBehavior = MasterBehavior.Popover, 
                master = View.ContentPage(
                    useSafeArea = true,
                    title = "Master", 
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
                    ]
                )
            )
        )

