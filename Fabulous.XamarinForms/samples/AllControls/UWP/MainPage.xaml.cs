using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace AllControls.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new AllControls.App());
        }
    }
}
