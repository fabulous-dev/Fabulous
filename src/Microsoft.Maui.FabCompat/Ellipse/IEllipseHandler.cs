using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public interface IEllipseHandler : IShapeViewHandler
{
    new IEllipse VirtualView { get; }
}