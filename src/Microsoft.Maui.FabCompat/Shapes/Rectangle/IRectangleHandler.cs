using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public interface IRectangleHandler : IShapeViewHandler
{
    new IRectangle VirtualView { get; }
}