using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace StaticViewCounterApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new StaticViewCounterApp());
        }
    }
}
