using System;
using Microsoft.FSharp.Core;
using Microsoft.Maui.Controls;

namespace Fabulous.Maui.Samples.CounterApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Core.App.runner.Start(1);
		}

		int count = 0;
		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
		}
	}
}
