using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Fabulous.Maui.Samples.CounterApp.Core;

namespace Fabulous.Maui.Samples.CounterApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseFabulousApp(App.widget)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}