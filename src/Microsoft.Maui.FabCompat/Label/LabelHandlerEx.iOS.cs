using Microsoft.Maui.Platform;

namespace Microsoft.Maui.Handlers;

public partial class LabelHandlerEx
{
    protected override MauiLabel CreatePlatformView()
    {
        var label = base.CreatePlatformView();
        label.Lines = 0;
        return label;
    }
}