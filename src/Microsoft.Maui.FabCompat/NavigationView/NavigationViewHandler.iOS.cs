// namespace Microsoft.Maui.Handlers;
//
// public partial class NavigationViewHandler: ViewHandler<IStackNavigationView, UIView>, IPlatformViewHandler
// {
//     UIViewController _viewController;
//     UIViewController IPlatformViewHandler.ViewController => _viewController;
//     
//     protected override UIView CreatePlatformView()
//     {
//         var navigationController = new UINavigationController();
//         _viewController = navigationController;
//         return navigationController.View;
//     }
//
//     public static void RequestNavigation(INavigationViewHandler handler, IStackNavigationView view, object? args)
//     {
//         if (args is not NavigationRequest request) return;
//         
//         // TODO: Implement stack diffing here
//     }
// }