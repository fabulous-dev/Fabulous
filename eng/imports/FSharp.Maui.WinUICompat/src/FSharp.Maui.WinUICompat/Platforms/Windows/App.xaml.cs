using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace FSharp.Maui.WinUICompat;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected override MauiApp CreateMauiApp() => throw new NotImplementedException();
}

// Normally WinUI will generate this file inside the XamlTypeInfo.g.cs file but for some reason
// if the App.Xaml is part of a reference assembly it doesn't
public partial class App : global::Microsoft.UI.Xaml.Markup.IXamlMetadataProvider
{
    private global::Microsoft.UI.Xaml.Markup.IXamlMetadataProvider? __appProvider;

    private global::Microsoft.UI.Xaml.Markup.IXamlMetadataProvider _AppProvider
    {
        get
        {
            if (__appProvider == null)
            {
                var type = typeof(Program).Assembly.GetType("FSharp.Maui.WinUICompat.FSharp_Maui_WinUICompat_XamlTypeInfo.XamlMetaDataProvider");
                __appProvider = type is not null ? Activator.CreateInstance(type) as global::Microsoft.UI.Xaml.Markup.IXamlMetadataProvider : null;
            }
            return __appProvider!;
        }
    }

    public global::Microsoft.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
    {
        return _AppProvider.GetXamlType(type);
    }


    public global::Microsoft.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
    {
        var result = _AppProvider.GetXamlType(fullName);
        System.Diagnostics.Debug.WriteLine(fullName);
        return result;
    }


    public global::Microsoft.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
    {
        return _AppProvider.GetXmlnsDefinitions();
    }
}

public static class Program
{
    [global::System.Runtime.InteropServices.DllImport("Microsoft.ui.xaml.dll")]
    private static extern void XamlCheckProcessRequirements();

    [global::System.STAThreadAttribute]
    public static void Main(string[] args, Type appType)
    {
        XamlCheckProcessRequirements();

        global::WinRT.ComWrappersSupport.InitializeComWrappers();
        global::Microsoft.UI.Xaml.Application.Start((p) => {
            var context = new global::Microsoft.UI.Dispatching.DispatcherQueueSynchronizationContext(global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread());
            global::System.Threading.SynchronizationContext.SetSynchronizationContext(context);
            Activator.CreateInstance(appType);
        });
    }
}