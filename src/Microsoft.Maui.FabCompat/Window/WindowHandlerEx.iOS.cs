using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Microsoft.Maui.Platform
{
    /// Microsoft.Maui.Platform.ContainerViewController does not listen to the change between light and dark modes
    /// Microsoft.Maui.Platform.PageViewController does, but it's only used by Microsoft.Maui.Handlers.PageHandler
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
    
    public static class ElementExtensionsEx
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
    public partial class WindowHandlerEx
    {
        /// Do exactly the same than Microsoft.Maui.WindowHandler.MapContent
        /// but use a ThemeEnabledContainerViewController instead of ContainerViewController
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