namespace AllControls.Pages

open Fabulous.XamarinForms
open Xamarin.Forms

module Shell =
    let shellView () =
        View.Shell(
            title = "TitleShell", 
            items = [
                View.ShellItem(
                    items = [
                        View.ShellSection(
                            items = [
                                View.ShellContent(
                                    content = View.ContentPage(
                                        title = "Title",
                                        content = View.Label(text = "Shell content")
                                    )
                                )         
                            ]
                        )
                    ]
                )
            ]
        )
    
    let view () =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 
            shellView()            
        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support Shell")
                ]
            )

