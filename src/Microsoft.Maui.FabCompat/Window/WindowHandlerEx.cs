namespace Microsoft.Maui.Handlers;

public partial class WindowHandlerEx: WindowHandler
{
    public static IPropertyMapper<IWindow, IWindowHandler> Mapper = new PropertyMapper<IWindow, IWindowHandler>(WindowHandler.Mapper)
    {
        [nameof(IWindow.Content)] = MapContent
    };

    public static CommandMapper<IWindow, IWindowHandler> CommandMapper = new(WindowHandler.CommandMapper);

    public WindowHandlerEx()
        : base(Mapper, CommandMapper)
    {
    }

    public WindowHandlerEx(IPropertyMapper? mapper = null)
        : base(mapper ?? Mapper, CommandMapper)
    {
    }

    public WindowHandlerEx(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null)
        : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
    {
    }
}