using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Handlers;

public interface IRectangleHandler : IShapeViewHandler
{
    new IRectangle VirtualView { get; }
}