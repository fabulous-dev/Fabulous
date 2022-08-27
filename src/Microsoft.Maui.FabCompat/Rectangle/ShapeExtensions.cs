using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.FabCompat.Shapes;

public static partial class ShapeExtensions
{
    public static PathF GetPathForBounds(this IRectangle view, Rect bounds)
    {
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