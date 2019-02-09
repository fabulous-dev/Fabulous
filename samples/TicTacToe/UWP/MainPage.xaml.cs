using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace TicTacToe.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new TicTacToe.App());
        }
    }
}
