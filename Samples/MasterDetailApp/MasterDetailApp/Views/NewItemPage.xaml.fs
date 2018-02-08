
namespace MasterDetailApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type NewItemPage() = 
    inherit ContentPage()
    do base.LoadFromXaml(typeof<NewItemPage>) |> ignore



(*
using System;

using Xamarin.Forms;

namespace MasterDetailApp
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
*)
