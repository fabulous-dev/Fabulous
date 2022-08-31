namespace Microsoft.Maui.Handlers;

public partial class NavigationViewExHandler : ViewHandler<INavigationViewEx, object>
{
    protected override object CreatePlatformView() => throw new NotImplementedException();

    public void Push(IView view, bool animated)
    {
        throw new NotImplementedException();
    }

    public void Pop(bool animated)
    {
        throw new NotImplementedException();
    }

    public void InsertAt(int index, IView view)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }
}