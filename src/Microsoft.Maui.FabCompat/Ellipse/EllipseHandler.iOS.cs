using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class EllipseHandler : ViewHandler<IEllipse, MauiShapeView>
{
    protected override MauiShapeView CreatePlatformView()
        => new MauiShapeView();

    public override bool NeedsContainer =>
        VirtualView?.Background != null ||
        base.NeedsContainer;
}