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

namespace Microsoft.Maui.Handlers;

public partial class RectangleHandler: IRectangleHandler
{
    public static IPropertyMapper<IRectangle, IRectangleHandler> Mapper = new PropertyMapper<IRectangle, IRectangleHandler>(ShapeViewHandler.Mapper)
    {
        [nameof(IRectangle.RadiusX)] = MapRadiusX,
        [nameof(IRectangle.RadiusY)] = MapRadiusY
    };

    public static CommandMapper<IRectangle, IRectangleHandler> CommandMapper = new(ShapeViewHandler.CommandMapper)
    {
    };

    public RectangleHandler() : base(Mapper)
    {
    }

    public RectangleHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
    {
    }
    
    IRectangle IRectangleHandler.VirtualView => VirtualView;
    
    IShapeView IShapeViewHandler.VirtualView => VirtualView;

    PlatformView IShapeViewHandler.PlatformView => PlatformView;
}