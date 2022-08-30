using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui;

/// Duplicate Microsoft.Maui.ElementHandlerExtensions because it is marked as internal
/// https://github.com/dotnet/maui/blob/9ee62c1b125424ea54c99661de8be951f21203a3/src/Core/src/Handlers/ElementHandlerExtensions.cs
public static class ElementHandlerExtensions
{
    public static IServiceProvider GetServiceProvider(this IElementHandler handler)
    {
        var context = handler.MauiContext ??
                      throw new InvalidOperationException($"Unable to find the context. The {nameof(ElementHandler.MauiContext)} property should have been set by the host.");

        var services = context?.Services ??
                       throw new InvalidOperationException($"Unable to find the service provider. The {nameof(ElementHandler.MauiContext)} property should have been set by the host.");

        return services;
    }
        
    public static T GetRequiredService<T>(this IElementHandler handler)
        where T : notnull
    {
        var services = handler.GetServiceProvider();

        var service = services.GetRequiredService<T>();

        return service;
    }
}