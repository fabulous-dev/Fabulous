#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIView;
#elif ANDROID
using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.Frame;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.StackNavigationManager;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers;

public record NavigationHandlerPushUpdate(IView View, bool Animated);
public record NavigationHandlerPopUpdate(bool Animated);
public record NavigationHandlerInsertUpdate(int Index, IView View);
public record NavigationHandlerRemoveUpdate(int Index);

public partial class NavigationViewExHandler: INavigationViewExHandler
{
    public static IPropertyMapper<INavigationViewEx, INavigationViewExHandler> Mapper = new PropertyMapper<INavigationViewEx, INavigationViewExHandler>(ViewHandler.ViewMapper)
    {
    };

    public static CommandMapper<INavigationViewEx, INavigationViewExHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
    {
        [nameof(INavigationViewExHandler.Push)] = MapPush,
        [nameof(INavigationViewExHandler.Pop)] = MapPop,
        [nameof(INavigationViewExHandler.InsertAt)] = MapInsertAt,
        [nameof(INavigationViewExHandler.RemoveAt)] = MapRemoveAt
    };

    public NavigationViewExHandler() : base(Mapper, CommandMapper)
    {
    }

    public NavigationViewExHandler(IPropertyMapper? mapper = null) : base(mapper ?? Mapper, CommandMapper)
    {
    }

    public NavigationViewExHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null) : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
    {
    }

    INavigationViewEx INavigationViewExHandler.VirtualView => VirtualView;

    PlatformView INavigationViewExHandler.PlatformView => PlatformView;

    private static void MapPush(INavigationViewExHandler handler, INavigationViewEx view, object? arg)
    {
        if (arg is NavigationHandlerPushUpdate args)
        {
            handler.Push(args.View, args.Animated);
        }
    }

    private static void MapPop(INavigationViewExHandler handler, INavigationViewEx view, object? arg)
    {
        if (arg is NavigationHandlerPopUpdate args)
        {
            handler.Pop(args.Animated);
        }
    }

    private static void MapInsertAt(INavigationViewExHandler handler, INavigationViewEx view, object? arg)
    {
        if (arg is NavigationHandlerInsertUpdate args)
        {
            handler.InsertAt(args.Index, args.View);
        }
    }

    private static void MapRemoveAt(INavigationViewExHandler handler, INavigationViewEx view, object? arg)
    {
        if (arg is NavigationHandlerRemoveUpdate args)
        {
            handler.RemoveAt(args.Index);
        }
    }
}