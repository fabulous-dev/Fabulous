using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace NewApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new NewApp.App());
        }
    }
}
