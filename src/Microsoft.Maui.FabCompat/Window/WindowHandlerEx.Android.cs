namespace Microsoft.Maui.Handlers;

public partial class WindowHandlerEx: ElementHandler<IWindow, Activity>
{
    public static void MapContent(IWindowHandler handler, IWindow window)
    {
        WindowHandler.MapContent(handler, window);
    }
}