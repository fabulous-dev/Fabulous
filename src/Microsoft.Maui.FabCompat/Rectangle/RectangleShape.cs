using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.FabCompat.Shapes;

public class RectangleShape: IShape
{
    private readonly WeakReference<IRectangle> _view;

    public RectangleShape(IRectangle view)
    {
        _view = new WeakReference<IRectangle>(view);
    }

    public PathF PathForBounds(Rect bounds)
    {
        if (!_view.TryGetTarget(out var view))
            return new PathF();
        
        var path = new PathF();

        var x = (float)(view.StrokeThickness / 2);
        var y = (float)(view.StrokeThickness / 2);
        var w = (float)(bounds.Width - view.StrokeThickness);
        var h = (float)(bounds.Height - view.StrokeThickness);
        var cornerRadius = (float)(Math.Max(view.RadiusX, view.RadiusY));

        path.AppendRoundedRectangle(x, y, w, h, cornerRadius);

        return path;
    }
}