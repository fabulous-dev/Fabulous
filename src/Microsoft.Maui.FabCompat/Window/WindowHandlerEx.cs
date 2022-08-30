using Microsoft.Extensions.DependencyInjection;

#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIWindow;
#elif ANDROID
using PlatformView = Android.App.Activity;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Window;
#elif TIZEN
using PlatformView = Tizen.NUI.Window;
#endif

namespace Microsoft.Maui.Handlers;

public partial class WindowHandlerEx: IWindowHandler
{
    public static IPropertyMapper<IWindow, IWindowHandler> Mapper = new PropertyMapper<IWindow, IWindowHandler>(WindowHandler.Mapper)
    {
        [nameof(IWindow.Content)] = MapContent
    };
    
    public static CommandMapper<IWindow, IWindowHandler> CommandMapper = new(WindowHandler.CommandMapper)
    {
    };

    public WindowHandlerEx()
        : base(Mapper, CommandMapper)
    {
    }

    public WindowHandlerEx(IPropertyMapper? mapper = null)
        : base(mapper ?? Mapper, CommandMapper)
    {
    }

    public WindowHandlerEx(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null)
        : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
    {
    }

#if !(NETSTANDARD || !(__IOS__ || MACCATALYST || WINDOWS || TIZEN || ANDROID))
	protected override PlatformView CreatePlatformElement() =>
	    MauiContext?.Services.GetService<PlatformView>() ?? throw new InvalidOperationException($"MauiContext did not have a valid window.");
#endif
}