using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace Calculator.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Calculator.CalculatorApp());
        }
    }
}
