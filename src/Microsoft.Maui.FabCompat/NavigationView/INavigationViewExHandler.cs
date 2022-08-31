#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIView;
#elif ANDROID
using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.Frame;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.StackNavigationManager;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers;

public interface INavigationViewExHandler : IViewHandler
{
    new INavigationViewEx VirtualView { get; }
    new PlatformView PlatformView { get; }
    
    void Push(IView view, bool animated);
    void Pop(bool animated);
    void InsertAt(int index, IView view);
    void RemoveAt(int index);
}