using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace CounterApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new CounterApp());
        }
    }
}
