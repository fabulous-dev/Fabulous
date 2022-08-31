using Microsoft.Maui.Platform;

namespace Microsoft.Maui.Handlers;

public partial class NavigationViewExHandler : ViewHandler<INavigationViewEx, UIView>
{
    private UINavigationController? _navigationController;
    
    protected override UIView CreatePlatformView()
    {
        _navigationController = new UINavigationController();
        return _navigationController?.View;
    }

    public void Push(IView view, bool animated)
    {
        _navigationController?.PushViewController(view.ToThemeEnabledUIViewController(this.MauiContext), animated);
    }

    public void Pop(bool animated)
    {
        _navigationController?.PopViewController(animated);
    }

    public void InsertAt(int index, IView view)
    {
        var temp = new List<UIViewController>();

        for(var i = index; i < _navigationController?.ViewControllers.Length; i++)
        {
            var popped = _navigationController?.PopViewController(false);
            temp.Add(popped);
        }
        
        _navigationController?.PushViewController(view.ToThemeEnabledUIViewController(this.MauiContext), false);
        
        foreach(var item in temp)
        {
            _navigationController?.PushViewController(item, false);
        }
    }

    public void RemoveAt(int index)
    {
        var temp = new List<UIViewController>();

        for(var i = index + 1; i < _navigationController?.ViewControllers.Length; i++)
        {
            var popped = _navigationController?.PopViewController(false);
            temp.Add(popped);
        }

        _navigationController?.PopViewController(false);
        
        foreach(var item in temp)
        {
            _navigationController?.PushViewController(item, false);
        }
    }
}