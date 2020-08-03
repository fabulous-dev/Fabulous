using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace ShapesDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new ShapesDemo.App());
        }
    }
}
