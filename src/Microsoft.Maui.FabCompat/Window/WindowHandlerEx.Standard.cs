namespace Microsoft.Maui.Handlers;

public partial class WindowHandlerEx : ElementHandler<IWindow, object>
{
    protected override object CreatePlatformElement() => throw new NotImplementedException();
    
    public static void MapContent(IWindowHandler handler, IWindow window) { }
}