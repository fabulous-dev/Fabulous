using Fabulous.Maui.Samples.CounterApp.Core;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Hosting;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace Fabulous.Maui.Samples.CounterApp
{
    public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseFabulousAppWithArgs(App.widget, 1)
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}