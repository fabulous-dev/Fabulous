namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type ItemDetailPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<ItemDetailPage>) |> ignore
(*
    let item = 
            {
                Text = "Item 1";
                Description = "This is an item description."
            }

    do self.InitializeComponent();
    do self.BindingContext <- viewModel;
    *)
