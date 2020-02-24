namespace AllControls.Samples.Pages

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module MasterDetailPage =
    type Msg =
      | IsMasterPresentedChanged of bool
      | SetDetailPage of string
      
    type CmdMsg = Nothing
    
    type Model =
      { IsMasterPresented: bool 
        DetailPage: string }
      
    let mapToCmd _ = Cmd.none
      
    let init () =
        { IsMasterPresented = false
          DetailPage = "A" }
        
    let update msg model =
        match msg with
        | IsMasterPresentedChanged b -> { model with IsMasterPresented = b }, []
        | SetDetailPage s -> { model with DetailPage = s ; IsMasterPresented = false }, []
    
    let view model dispatch =
        // MasterDetail where the Master acts as a hamburger-style menu
        dependsOn (model.DetailPage, model.IsMasterPresented) (fun model (detailPage, isMasterPresented) -> 
            View.MasterDetailPage(
                masterBehavior = MasterBehavior.Popover, 
                isPresented = isMasterPresented, 
                isPresentedChanged = (fun b -> dispatch (IsMasterPresentedChanged b)), 
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
                    ], 
                    poppedToRoot = fun _ -> dispatch (IsMasterPresentedChanged true)
                )
            )
        )

