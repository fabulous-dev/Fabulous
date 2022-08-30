using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Microsoft.Maui.Handlers;

public partial class RectangleHandler : ViewHandler<IRectangle, MauiShapeView>
{
    protected override MauiShapeView CreatePlatformView()
        => new MauiShapeView(Context);

    public override bool NeedsContainer =>
        VirtualView?.Background != null ||
        base.NeedsContainer;
    
    public static void MapRadiusX(IRectangleHandler handler, IRectangle rectangle)
    {
        handler.PlatformView?.InvalidateShape(rectangle);
    }
    
    public static void MapRadiusY(IRectangleHandler handler, IRectangle rectangle)
    {
        handler.PlatformView?.InvalidateShape(rectangle);
    }
}