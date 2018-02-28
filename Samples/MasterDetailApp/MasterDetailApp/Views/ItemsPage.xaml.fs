namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type ItemsPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<ItemsPage>) |> ignore


(*
    member __.OnItemSelected(sender:obj, args: SelectedItemChangedEventArgs) = 
        async {
            match args.SelectedItem with 
            | :? Item as item -> 

                return! Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

                // Manually deselect item
                //ItemsListView.SelectedItem = null;
             | _ -> ()
         } |> Async.StartAsTask

    async void AddItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewItemPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (viewModel.Items.Count == 0)
            viewModel.LoadItemsCommand.Execute(null);
    }
    }
}
*)

