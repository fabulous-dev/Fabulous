using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Handlers;

public partial class RectangleHandler: ViewHandler<IRectangle, object>
{
    protected override object CreatePlatformView() => throw new NotImplementedException();
    
    public static void MapRadiusX(IRectangleHandler handler, IRectangle rectangle) { }
    public static void MapRadiusY(IRectangleHandler handler, IRectangle rectangle) { }
}