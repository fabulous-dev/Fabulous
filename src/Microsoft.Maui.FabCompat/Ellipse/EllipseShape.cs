using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Shapes;

public class EllipseShape: IShape
{
    private readonly WeakReference<IEllipse> _view;

    public EllipseShape(IEllipse view)
    {
        _view = new WeakReference<IEllipse>(view);
    }

    public PathF PathForBounds(Rect bounds)
    {
        if (!_view.TryGetTarget(out var view))
            return new PathF();
        
        var path = new PathF();

        var x = (float)view.StrokeThickness / 2;
        var y = (float)view.StrokeThickness / 2;
        var w = (float)(bounds.Width - view.StrokeThickness);
        var h = (float)(bounds.Height - view.StrokeThickness);

        path.AppendEllipse(x, y, w, h);

        return path;
    }
}