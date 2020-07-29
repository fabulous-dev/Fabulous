using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace LoginShape.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new LoginShape.App());
        }
    }
}
