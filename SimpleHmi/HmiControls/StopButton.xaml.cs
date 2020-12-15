using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleHmi.HmiControls
{
    /// <summary>
    /// Logika interakcji dla klasy StopButton.xaml
    /// </summary>
    public partial class StopButton : UserControl
    {      
        public bool state = true;

        public StopButton()
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

        public void stopButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(1000);
        }
    }
}
