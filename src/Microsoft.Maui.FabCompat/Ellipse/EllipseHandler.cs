using Microsoft.Maui.Handlers;

#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif ANDROID
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif WINDOWS
using PlatformView = Microsoft.Maui.Graphics.Win2D.W2DGraphicsView;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class EllipseHandler: IEllipseHandler
{
    public static IPropertyMapper<IEllipse, IEllipseHandler> Mapper =
        new PropertyMapper<IEllipse, IEllipseHandler>(ShapeViewHandler.Mapper);

    public static CommandMapper<IEllipse, IEllipseHandler> CommandMapper = new(ShapeViewHandler.CommandMapper);

    public EllipseHandler() : base(Mapper)
    {
    }

    public EllipseHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
    {
    }
    
    IEllipse IEllipseHandler.VirtualView => VirtualView;
    
    IShapeView IShapeViewHandler.VirtualView => VirtualView;

    PlatformView IShapeViewHandler.PlatformView => PlatformView;
}