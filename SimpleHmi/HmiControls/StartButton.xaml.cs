using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleHmi.HmiControls
{
    /// <summary>
    /// Logika interakcji dla klasy StartButton.xaml
    /// </summary>

    public partial class StartButton : UserControl
    {
        public bool state = true;

        public StartButton()
        {
            InitializeComponent();
        }

        private async void ClickHandler(int miliseconds)
        {

            EllipseVisible.Visibility = Visibility.Hidden;
            EllipseHidden.Visibility = Visibility.Visible;

            await Task.Delay(miliseconds);

            EllipseVisible.Visibility = Visibility.Visible;
            EllipseHidden.Visibility = Visibility.Hidden;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(1000);
        }
    }

}
