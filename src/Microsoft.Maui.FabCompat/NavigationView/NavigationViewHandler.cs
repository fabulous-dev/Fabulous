// namespace Microsoft.Maui.Handlers;
//
// #if __IOS__ || MACCATALYST
// using PlatformView = UIKit.UIView;
// #endif
//
// public partial class NavigationViewHandler: INavigationViewHandler
// {
//     public static IPropertyMapper<IStackNavigationView, INavigationViewHandler> Mapper = new PropertyMapper<IStackNavigationView, INavigationViewHandler>(ViewHandler.ViewMapper)
//     {
//     };
//
//     public static CommandMapper<IStackNavigationView, INavigationViewHandler> CommandMapper = new()
//     {
//         [nameof(IStackNavigation.RequestNavigation)] = RequestNavigation
//     };
//
//     public NavigationViewHandler() : base(Mapper)
//     {
//     }
//
//     public NavigationViewHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
//     {
//     }
//     
//     IStackNavigationView INavigationViewHandler.VirtualView => VirtualView;
//
//     PlatformView INavigationViewHandler.PlatformView => PlatformView;
// }