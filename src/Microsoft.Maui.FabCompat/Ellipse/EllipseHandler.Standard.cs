using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class EllipseHandler: ViewHandler<IEllipse, object>
{
    protected override object CreatePlatformView() => throw new NotImplementedException();
}