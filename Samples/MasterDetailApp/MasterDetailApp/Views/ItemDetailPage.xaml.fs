namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type ItemDetailPage() as self = 
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<ItemDetailPage>)
(*
    let item = 
            {
                Text = "Item 1";
                Description = "This is an item description."
            }

    do self.InitializeComponent();
    do self.BindingContext <- viewModel;
    *)
