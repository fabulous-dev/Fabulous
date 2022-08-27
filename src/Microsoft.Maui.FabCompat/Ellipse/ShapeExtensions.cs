using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.FabCompat.Shapes;

public static partial class ShapeExtensions
{
    public static PathF GetPathForBounds(this IEllipse view, Rect bounds)
    {
        var path = new PathF();

        var x = (float)view.StrokeThickness / 2;
        var y = (float)view.StrokeThickness / 2;
        var w = (float)(bounds.Width - view.StrokeThickness);
        var h = (float)(bounds.Height - view.StrokeThickness);

        path.AppendEllipse(x, y, w, h);

        return path;
    }
}