using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Maui
{
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
}

namespace Microsoft.Maui.Platform
{
    /// Microsoft.Maui.Platform.ContainerViewController does not listen to the change between light and dark modes
    /// Microsoft.Maui.Platform.PageViewController does, but it's only used by Microsoft.Maui.Controls.Page
    /// while any view added to the window will be wrapped in a ContainerView
    /// So we replace the default ContainerViewController by ThemeEnabledContainerViewController
    ///
    /// ContainerViewController: https://github.com/dotnet/maui/blob/main/src/Core/src/Platform/iOS/ContainerViewController.cs
    /// PageViewController: https://github.com/dotnet/maui/blob/main/src/Core/src/Platform/iOS/PageViewController.cs#L31
    public class ThemeEnabledContainerViewController : ContainerViewController
    {
        public override void TraitCollectionDidChange(UITraitCollection? previousTraitCollection)
        {
            if (CurrentView?.Handler is ElementHandler handler)
            {
                var application = handler.GetRequiredService<IApplication>();
                application?.ThemeChanged();
            }

            base.TraitCollectionDidChange(previousTraitCollection);
        }
    }
    
    public static partial class ElementExtensions
    {
        public static UIViewController ToThemeEnabledUIViewController(this IElement view, IMauiContext context)
        {
            var platformView = view.ToPlatform(context);
            if (view?.Handler is IPlatformViewHandler nvh && nvh.ViewController != null)
                return nvh.ViewController;

            return new ThemeEnabledContainerViewController { CurrentView = view, Context = context };
        }
    }
}

namespace Microsoft.Maui.Handlers
{
    public partial class WindowHandlerEx : ElementHandler<IWindow, UIWindow>
    {
        /// Do exactly the same than Microsoft.Maui.FabCompat.WindowHandler.MapContent
        /// but use a ThemeEnabledContainerViewController instead of a ContainerViewController
        public static void MapContent(IWindowHandler handler, IWindow window)
        {
            _ = handler.MauiContext ??
                throw new InvalidOperationException($"{nameof(MauiContext)} should have been set by base class.");

            var nativeContent = window.Content.ToThemeEnabledUIViewController(handler.MauiContext);

            handler.PlatformView.RootViewController = nativeContent;

            if (window.VisualDiagnosticsOverlay != null)
                window.VisualDiagnosticsOverlay.Initialize();
        }
    }
}